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
            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();

            string query = @"
        SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA,HH.TEN_VIET_TAT,HH.TRONG_LUONG_HH,HH.SO_DANG_KY_THUOC,HH.MA_THUOC,HH.HAM_LUONG,
               HH.HOAT_CHAT, GHH.GIA_BAN_HH, 
               NH.TEN_NHOM, LH.TEN_LOAI_HH, HH.HINH_ANH_HH, HH.MA_VACH, GHH.GIA_VON_HH, 
               HSX.MA_HANG_SX,HSX.TEN_HANG_SX, HH.DUONG_DUNG_CHO_THUOC, HH.QUY_CACH_DONG_GOI, HH.GHI_CHU_HH, 
               NCC.TEN_NHA_CUNG_CAP, HH.NGAY_HET_HAN_HH, DVT.TEN_DON_VI_TINH,HH.TINH_TRANG_HH
 FROM HANG_HOA HH
 JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
 JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
 LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX
 LEFT JOIN GIA_HANG_HOA GHH ON GHH.MA_HANG_HOA = HH.MA_HANG_HOA
 LEFT JOIN DON_VI_TINH DVT ON GHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
 LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON CTPN.MA_HANG_HOA=HH.MA_HANG_HOA
 LEFT JOIN PHIEU_NHAP_HANG PN ON PN.MA_PHIEU_NHAP=CTPN.MA_PHIEU_NHAP
 LEFT JOIN NHA_CUNG_CAP NCC ON NCC.MA_NHA_CUNG_CAP=PN.MA_NHA_CUNG_CAP
        WHERE HH.MA_HANG_HOA = @maHH";

            try
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHH", maHangHoa);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Hiển thị thông tin
                            textBoxTenHH.Text = reader["TEN_HANG_HOA"].ToString();
                            textBoxMaHH.Text = reader["MA_HANG_HOA"].ToString();
                            textBoxMaVach.Text = reader["MA_VACH"]?.ToString() ?? string.Empty;
                            textBoxNhomHang.Text = reader["TEN_NHOM"]?.ToString() ?? string.Empty; // Nếu có trường nhóm hàng hóa
                            textBoxLoaiHang.Text = reader["TEN_LOAI_HH"]?.ToString() ?? string.Empty; // Nếu có trường loại hàng hóa
                            textBoxTenVietTat.Text = reader["TEN_VIET_TAT"].ToString();
                            textBoxGiaVon.Text = reader["GIA_VON_HH"]?.ToString() ?? "0"; // Nếu cần hiển thị giá nhập
                            textBoxGiaBan.Text = reader["GIA_BAN_HH"]?.ToString() ?? "0"; // Tránh lỗi nếu giá bán là null
                            textBoxTrongLuong.Text = reader["TRONG_LUONG_HH"]?.ToString() ?? "0"; // Tránh lỗi nếu trọng lượng là null
                            textBoxDuongDung.Text = reader["DUONG_DUNG_CHO_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường đường dùng
                            textBoxSoDangKy.Text = reader["SO_DANG_KY_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường số đăng ký thuốc
                            textBoxMaThuoc.Text = reader["MA_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường mã thuốc
                            textBoxHamLuong.Text = reader["HAM_LUONG"]?.ToString() ?? string.Empty; // Nếu có trường hàm lượng
                            textBoxHoatChat.Text = reader["HOAT_CHAT"]?.ToString() ?? string.Empty; // Nếu có trường hoạt chất
                            textBoxHangSanXuat.Text = reader["TEN_HANG_SX"]?.ToString() ?? string.Empty; // Nếu có trường nhà sản xuất
                            textBoxQuyCachDongGoi.Text = reader["QUY_CACH_DONG_GOI"]?.ToString() ?? string.Empty;
                            textBoxGhiChu.Text = reader["GHI_CHU_HH"]?.ToString() ?? string.Empty; // Nếu có trường ghi chú
                            textBoxNhaCungCap.Text = reader["TEN_NHA_CUNG_CAP"]?.ToString() ?? string.Empty; // Nếu có trường nhà cung cấp


                            dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
                            dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
                            dateTimePickerNgayHetHan.Value = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : DateTime.Now; // Nếu có trường ngày hết hạn, nếu không thì mặc định là ngày hiện tại
                            dateTimePickerNgayHetHan.Enabled = false; // hoặc dateTimePicker1.Visible = false nếu muốn ẩn

                            // Xử lý ảnh
                            string tenHinh = reader["HINH_ANH_HH"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(tenHinh))
                            {
                                string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa";
                                string duongDan = Path.Combine(thuMucAnh, tenHinh);

                                if (File.Exists(duongDan))
                                {
                                    using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                                    {
                                        using (MemoryStream ms = new MemoryStream())
                                        {
                                            fs.CopyTo(ms);
                                            ms.Position = 0;
                                            pictureBoxHangHoa.Image = Image.FromStream(ms);
                                        }
                                    }
                                }
                                else
                                {
                                    pictureBoxHangHoa.Image = Properties.Resources._default;
                                    //MessageBox.Show("Không tìm thấy ảnh: " + duongDan, "Lỗi hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                pictureBoxHangHoa.Image = Properties.Resources._default;
                                //MessageBox.Show("Không có thông tin tên hình ảnh cho hàng hóa này.", "Thiếu hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin hàng hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }















        private void buttonDong_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            ////ham luu hang hoa voi ghi chu moi 
            //try
            //{
            //    // thêm dữ liệu như đã làm trước
            //    using (var conn = new CSDL().GetConnection())
            //    {
            //        conn.Open();
            //        string query = "UPDATE HANG_HOA " +
            //            "SET GHI_CHU_HH = @GhiChu WHERE MA_HANG_HOA IN " +
            //            "( SELECT MA_HANG_HOA FROM HANG_HOA  " +
            //            " WHERE MA_HANG_HOA = @maHH  );";
            //        using (var cmd = new SqlCommand(query, conn))
            //        {
            //            cmd.Parameters.AddWithValue("@GhiChu", textBoxGhiChu.Text);
            //            cmd.Parameters.AddWithValue("@maHH", textBoxMaHH.Text);
            //            cmd.ExecuteNonQuery();
            //        }
            //    }
            //    MessageBox.Show("Luu thay doi thành công!");
            //    ChitietHangHoa_Load(sender, e); // Tải lại thông tin hàng hóa để cập nhật giao diện
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi: " + ex.Message);
            //}

            //mo user control de sua thong tin hang hoa

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
                    using (SqlConnection conn = new CSDL().GetConnection())
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
                    using (SqlConnection conn = new CSDL().GetConnection())
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
