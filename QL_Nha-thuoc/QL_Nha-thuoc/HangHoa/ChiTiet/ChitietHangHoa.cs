using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.model;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa
{
    public partial class ChitietHangHoa : Form
    {
        private string maHangHoa;
        private string maDonViTinh;
        private string maNV;
        public ChitietHangHoa(string maHH,string maDVT)
        {
            InitializeComponent();
            maHangHoa = maHH;
            maDonViTinh = maDVT;
            this.Load += ChitietHangHoa_Load; // Gọi hàm khi form load
            maNV=Session.TaiKhoanDangNhap.MaNhanVien; // Lấy mã nhân viên từ session
        }

        private void ChitietHangHoa_Load(object sender, EventArgs e)
        {
            this.Controls.OfType<TextBox>().ToList().ForEach(tb => { tb.ReadOnly = true; tb.TabStop = false; tb.Cursor = Cursors.Default; });
            textBoxGhiChu.ReadOnly = true; // Chỉ cho phép ghi chú được chỉnh sửa
            HienThiThongTinHangHoa(maHangHoa);
        }

        public void LoadData()
        {
            // Gọi lại code bên trong ChitietHangHoa_Load hoặc tách ra phần dùng chung
            // Ví dụ:
            //string maHH = labelMaHH.Text; // Hoặc cách lấy mã HH hiện tại

            // Gọi lại xử lý hiển thị chi tiết theo mã hàng hóa
            HienThiThongTinHangHoa(maHangHoa);
        }
        private void HienThiThongTinHangHoa(string maHangHoa)
        {
            ClassHangHoa row = ClassHangHoa.LayThongTinMotHangHoa(maHangHoa);

            if (row == null)
            {
                MessageBox.Show("Không tìm thấy thông tin hàng hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Thông tin hàng hóa
            textBoxMaHH.Text = row.MaHangHoa;
            textBoxTenHH.Text = row.TenHangHoa;
            textBoxMaVach.Text = row.MaVach ?? string.Empty;
            textBoxGiaBan.Text = row.GiaBan.ToString("0");
            textBoxGiaVon.Text = row.GiaVon.ToString("0");
            textBoxHangSanXuat.Text = row.TenHangSanXuat ?? string.Empty;
            textBoxNhomHang.Text = row.TenNhomHangHoa ?? string.Empty;
            textBoxLoaiHang.Text = row.TenLoaiHangHoa ?? string.Empty;
            textBoxQuyCachDongGoi.Text = row.QuyCachDongGoi ?? string.Empty;
            textBoxGhiChu.Text = row.GhiChu ?? string.Empty;
            textBoxNhaCungCap.Text = row.TenNhaCungCap ?? string.Empty;
            textBoxDonViTinh.Text = row.TenDonViTinh ?? string.Empty;

            buttonNgungKinhDoanh.Text = row.TinhTrang == "Đang kinh doanh" ? "Ngừng kinh doanh" : "Kích hoạt kinh doanh ";

            // Ngày hết hạn
            if (row.HanSuDung.HasValue)
            {
                dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
                dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
                dateTimePickerNgayHetHan.Value = row.HanSuDung.Value;
            }
            else
            {
                dateTimePickerNgayHetHan.Value = DateTime.Now;
            }
            dateTimePickerNgayHetHan.Enabled = false;

            // Ảnh
            string tenHinh = row.HinhAnh?.Trim();
            if (!string.IsNullOrEmpty(tenHinh))
            {
                string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa\";
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


            //mo user control de sua thong tin hang hoa

            FormCapNhatHangHoa formCapNhat = new FormCapNhatHangHoa(maHangHoa, this);
            formCapNhat.ShowDialog(); // Hiển thị form cập nhật
            // Đăng ký sự kiện FormClosed để tải lại thông tin khi form cập nhật đóng
            formCapNhat.FormClosed += (s, args) => ChitietHangHoa_Load(sender, e); // Tải lại thông tin khi form cập nhật đóng



        }




        private DanhMuc formDanhMuc;

        public ChitietHangHoa(string maHH, DanhMuc formDanhMuc = null)
        {
            InitializeComponent();
            this.maHangHoa = maHH;
            this.formDanhMuc = formDanhMuc;

            this.Load += ChitietHangHoa_Load;
        }

        private void buttonNgungKinhDoanh_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc muốn thay đổi trạng thái kinh doanh của mặt hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = CSDL.GetConnection())
                    {
                        conn.Open();

                        // Bước 1: Lấy trạng thái hiện tại
                        string currentStatus = "";
                        string getStatusQuery = "SELECT TINH_TRANG_HH FROM HANG_HOA WHERE MA_HANG_HOA = @MaHH";
                        using (SqlCommand getStatusCmd = new SqlCommand(getStatusQuery, conn))
                        {
                            getStatusCmd.Parameters.AddWithValue("@MaHH", maHangHoa);
                            var statusResult = getStatusCmd.ExecuteScalar();
                            if (statusResult != null)
                                currentStatus = statusResult.ToString();
                        }

                        // Bước 2: Xác định trạng thái mới
                        string newStatus = (currentStatus == "Ngừng kinh doanh") ? "Đang kinh doanh" : "Ngừng kinh doanh";

                        // Bước 3: Cập nhật
                        string updateQuery = "UPDATE HANG_HOA SET TINH_TRANG_HH = @TinhTrang WHERE MA_HANG_HOA = @MaHH";
                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@TinhTrang", newStatus);
                            updateCmd.Parameters.AddWithValue("@MaHH", maHangHoa);

                            int rowsAffected = updateCmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show($"Cập nhật trạng thái thành công: {newStatus}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // formDanhMuc?.Getthongtinhanghoa(); // Nếu cần cập nhật danh sách
                                this.Close();
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
                    bool xoaGiaBan = ClassGiaBanHH.XoaGiaBanTheoMaHangHoa(maHangHoa);
                    if (xoaGiaBan)
                    {
                        MessageBox.Show("Xóa giá bán hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    bool xoaHangHoa = ClassHangHoa.XoaHangHoa(maHangHoa,maNV);
                    if (xoaHangHoa)
                    {
                        MessageBox.Show("Xóa hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form chi tiết
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hàng hóa để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //cap nhat  chi tiet phieu kiem kho
                    //tim toan bo chi tiet phieu kiem kho co ma hang hoa nay
                    // Cập nhật chi tiết phiếu kiểm kho

                    ClassPhieuKiemKho maphieukiemcochuahanghoa = ClassPhieuKiemKho.LayPhieuKiemKho(maHangHoa);
                    ClassChiTietPhieuKiemKho ClassChiTietPhieuKiemKho = new ClassChiTietPhieuKiemKho
                    {
                        MaPhieuKiemKho = maHangHoa, // Giả sử MaPhieuKiemKho là mã hàng hóa
                        MaHangHoa = maHangHoa,
                        SoLuongHeThong = 0, // Cập nhật số lượng hệ thống về 0
                        SoLuongThucTe = 0, // Cập nhật số lượng thực tế về 0
                        GhiChu = "Hàng hóa đã bị xóa" // Ghi chú nếu cần
                    };
                    ClassChiTietPhieuKiemKho.CapNhatChiTietPhieuKiemKho(ClassChiTietPhieuKiemKho);
                }

                //xoa phieu kiem kho
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




    }
}
