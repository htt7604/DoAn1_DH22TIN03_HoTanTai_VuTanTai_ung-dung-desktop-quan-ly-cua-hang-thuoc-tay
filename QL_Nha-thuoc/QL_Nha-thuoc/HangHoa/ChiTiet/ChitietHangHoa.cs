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
            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();

            string query = @"
         SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GHH.GIA_BAN_HH, 
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
     WHERE HH.MA_HANG_HOA = @maHH ";

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
                            // Thông tin hàng hóa
                            textBoxMaHH.Text = reader["MA_HANG_HOA"].ToString();
                            textBoxTenHH.Text = reader["TEN_HANG_HOA"].ToString();
                            textBoxMaVach.Text = reader["MA_VACH"]?.ToString() ?? string.Empty;
                            textBoxGiaBan.Text = reader["GIA_BAN_HH"]?.ToString() ?? "0";
                            textBoxGiaVon.Text = reader["GIA_VON_HH"]?.ToString() ?? "0";
                            textBoxHangSanXuat.Text = reader["TEN_HANG_SX"]?.ToString() ?? string.Empty;
                            textBoxNhomHang.Text = reader["TEN_NHOM"]?.ToString() ?? string.Empty;
                            textBoxLoaiHang.Text = reader["TEN_LOAI_HH"]?.ToString() ?? string.Empty;
                            textBoxQuyCachDongGoi.Text = reader["QUY_CACH_DONG_GOI"]?.ToString() ?? string.Empty;
                            textBoxGhiChu.Text = reader["GHI_CHU_HH"]?.ToString() ?? string.Empty;
                            textBoxNhaCungCap.Text = reader["TEN_NHA_CUNG_CAP"]?.ToString() ?? string.Empty;
                            textBoxDonViTinh.Text = reader["TEN_DON_VI_TINH"]?.ToString() ?? string.Empty;
                            buttonNgungKinhDoanh.Text = reader["TINH_TRANG_HH"]?.ToString() == "Đang kinh doanh " ? "Kích hoạt kinh doanh" : "Ngừng kinh doanh";
                            // Ngày hết hạn
                            if (reader["NGAY_HET_HAN_HH"] != DBNull.Value)
                            {
                                dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
                                dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
                                dateTimePickerNgayHetHan.Value = Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]);
                            }
                            else
                            {
                                dateTimePickerNgayHetHan.Value = DateTime.Now;
                            }
                            dateTimePickerNgayHetHan.Enabled = false;

                            // Xử lý ảnh
                            string tenHinh = reader["HINH_ANH_HH"]?.ToString().Trim();
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
