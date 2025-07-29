using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.CapNhat;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa
{
    public partial class FormChiTietThuoc : Form
    {
        public FormChiTietThuoc(string maHH,string maDVT)
        {
            InitializeComponent();
            maHangHoa = maHH;
            maDoViTinh = maDVT; // Lưu mã đơn vị tính nếu cần
            this.Load += ChitietThuoc_Load; // Gọi hàm khi form load
        }
        private string maHangHoa;
        private string maDoViTinh;

        private void ChitietThuoc_Load(object sender, EventArgs e)
        {
            HienThiThongTinThuoc();
            this.Controls.OfType<TextBox>().ToList().ForEach(tb => { tb.ReadOnly = true; tb.TabStop = false; tb.Cursor = Cursors.Default; });
            textBoxGhiChu.ReadOnly = true; // Chỉ cho phép ghi chú được chỉnh sửa
        }
        public void LoadData()
        {
            // Gọi lại code bên trong ChitietHangHoa_Load hoặc tách ra phần dùng chung
            // Ví dụ:
            //string maHH = labelMaHH.Text; // Hoặc cách lấy mã HH hiện tại

            // Gọi lại xử lý hiển thị chi tiết theo mã hàng hóa
            HienThiThongTinThuoc();
        }
        private void HienThiThongTinThuoc()
        {
            ClassThuoc row = ClassThuoc.LayChiTietThuocTheoMaHH(maHangHoa);

            if (row == null)
            {
                MessageBox.Show("Không tìm thấy thông tin hàng hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Gán thông tin từ đối tượng
            textBoxTenHH.Text = row.TenThuoc;
            textBoxMaHH.Text = row.MaHangHoa;
            textBoxMaVach.Text = row.MaVach ?? string.Empty;
            textBoxNhomHang.Text = row.TenNhomHang ?? string.Empty;
            textBoxLoaiHang.Text = row.TenLoaiHang ?? string.Empty;
            textBoxTenVietTat.Text = row.TenVietTat;
            textBoxGiaVon.Text = row.GiaVon.ToString("N0");
            textBoxGiaBan.Text = row.GiaBan.ToString("N0");
            textBoxTrongLuong.Text = row.TrongLuong ?? "0";
            textBoxDuongDung.Text = row.TenDuongDung ?? string.Empty;
            textBoxSoDangKy.Text = row.SoDangKy ?? string.Empty;
            textBoxMaThuoc.Text = row.MaThuoc ?? string.Empty;
            textBoxHamLuong.Text = row.HamLuong ?? string.Empty;
            textBoxHoatChat.Text = row.HoatChatChinh ?? string.Empty;
            textBoxHangSanXuat.Text = row.TenHangSanXuat ?? string.Empty;
            textBoxQuyCachDongGoi.Text = row.QuyCachDongGoi ?? string.Empty;
            textBoxGhiChu.Text = row.GhiChu ?? string.Empty;
            textBoxNhaCungCap.Text = row.TenNhaCungCap ?? string.Empty;

            dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
            dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
            dateTimePickerNgayHetHan.Value = row.NgayHetHan ?? DateTime.Now;
            dateTimePickerNgayHetHan.Enabled = false;

            // Ảnh
            string tenHinh = row.HinhAnh?.Trim();
            if (!string.IsNullOrEmpty(tenHinh))
            {
                string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa";
                string duongDan = Path.Combine(thuMucAnh, tenHinh);


                if (File.Exists(duongDan))
                {
                    using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        pictureBoxHangHoa.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBoxHangHoa.Image = Properties.Resources._default;
                }
            }
            else
            {
                pictureBoxHangHoa.Image = Properties.Resources._default;
            }
        }















        private void buttonDong_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            FormCapNhatThuoc formCapNhatThuoc = new FormCapNhatThuoc(maHangHoa, this);
            formCapNhatThuoc.ShowDialog(); // Hiển thị form cập nhật
            // Đăng ký sự kiện FormClosed để tải lại thông tin khi form cập nhật đóng
            formCapNhatThuoc.FormClosed += (s, args) => ChitietThuoc_Load(sender, e); // Tải lại thông tin khi form cập nhật đóng



        }

        private void buttonNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn ngừng kinh doanh mặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = CSDL.GetConnection())
                    {
                        conn.Open();

                        string query = "UPDATE HANG_HOA SET TINH_TRANG_HH = @TinhTrang WHERE MA_HANG_HOA = @MaHH";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@TinhTrang", "Ngừng kinh doanh");
                            cmd.Parameters.AddWithValue("@MaHH", maHangHoa); // hoặc textBoxMaHH.Text nếu dùng textbox

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật trạng thái thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //formDanhMuc?.Getthongtinhanghoa(); // Gọi lại danh sách nếu cần
                                this.Close(); // Đóng form chi tiết nếu cần
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hàng hóa cần cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hàng hóa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    //xoa gia hang hoa truoc
                    ClassGiaBanHH.XoaGiaBanTheoMaHangHoaVaDVT(maHangHoa,maDoViTinh);
                    using (SqlConnection conn = CSDL.GetConnection())
                    {
                        conn.Open();

                        // Nếu cần xóa luôn giá hàng hóa trước (nếu không có ON DELETE CASCADE)
                        string deleteGiaHH = "DELETE FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH";
                        using (SqlCommand cmdGia = new SqlCommand(deleteGiaHH, conn))
                        {
                            cmdGia.Parameters.AddWithValue("@maHH", maHangHoa);
                            cmdGia.ExecuteNonQuery();
                        }

                        // Sau đó xóa hàng hóa
                        string deleteHangHoa = "DELETE FROM HANG_HOA WHERE MA_HANG_HOA = @maHH";
                        using (SqlCommand cmd = new SqlCommand(deleteHangHoa, conn))
                        {
                            cmd.Parameters.AddWithValue("@maHH", maHangHoa);
                            int rows = cmd.ExecuteNonQuery();

                            if (rows > 0)
                            {
                                MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close(); // Đóng form chi tiết
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy hàng hóa để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
