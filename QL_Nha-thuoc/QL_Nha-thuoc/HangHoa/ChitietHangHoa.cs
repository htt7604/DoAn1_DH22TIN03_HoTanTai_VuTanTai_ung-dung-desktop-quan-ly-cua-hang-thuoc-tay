using Microsoft.Data.SqlClient;
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

        public ChitietHangHoa(string maHH)
        {
            InitializeComponent();
            maHangHoa = maHH;
            this.Load += ChitietHangHoa_Load; // Gọi hàm khi form load
        }

        private void ChitietHangHoa_Load(object sender, EventArgs e)
        {
            HienThiThongTinHangHoa();
            this.Controls.OfType<TextBox>().ToList().ForEach(tb => { tb.ReadOnly = true; tb.TabStop = false; tb.Cursor = Cursors.Default; });

        }

        private void HienThiThongTinHangHoa()
        {
            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();

            string query = @"
        SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, HH.GIA_BAN_HH, 
               NH.TEN_NHOM, LH.TEN_LOAI_HH, HH.HINH_ANH_HH,HH.MA_VACH, HH.GIA_VON_HH, HH.HANG_SAN_XUAT,NH.TEN_NHOM, LH.TEN_LOAI_HH,HH.DUONG_DUNG_CHO_THUOC, HH.QUY_CACH_DONG_GOI,PN.GHI_CHU_PHIEU_NHAP, NCC.TEN_NHA_CUNG_CAP ,HH.NGAY_HET_HAN_HH
        FROM HANG_HOA HH
        JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
        JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
        LEFT JOIN PHIEU_NHAP_HANG PN ON HH.MA_HANG_HOA = PN.MA_HANG_HOA
        LEFT JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
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
                            textBoxMaHH.Text = reader["MA_HANG_HOA"].ToString();
                            textBoxTenHH.Text = reader["TEN_HANG_HOA"].ToString();
                            textBoxMaVach.Text = reader["MA_VACH"]?.ToString() ?? string.Empty;
                            textBoxGiaBan.Text = reader["GIA_BAN_HH"]?.ToString() ?? "0"; // Tránh lỗi nếu giá bán là null
                            textBoxGiaVon.Text = reader["GIA_VON_HH"]?.ToString() ?? "0"; // Nếu cần hiển thị giá nhập
                            textBoxHangSanXuat.Text= reader["HANG_SAN_XUAT"]?.ToString() ?? string.Empty; // Nếu có trường nhà sản xuất
                            textBoxNhomHang.Text = reader["TEN_NHOM"]?.ToString() ?? string.Empty; // Nếu có trường nhóm hàng hóa
                            textBoxLoaiHang.Text = reader["TEN_LOAI_HH"]?.ToString() ?? string.Empty; // Nếu có trường loại hàng hóa
                            textBoxDuongDung.Text = reader["DUONG_DUNG_CHO_THUOC"]?.ToString() ?? string.Empty;
                            textBoxQuyCachDongGoi.Text= reader["QUY_CACH_DONG_GOI"]?.ToString() ?? string.Empty;
                            textBoxGhiChu.Text = reader["GHI_CHU_PHIEU_NHAP"]?.ToString() ?? string.Empty; // Nếu có trường ghi chú
                            textBoxNhaCungCap.Text = reader["TEN_NHA_CUNG_CAP"]?.ToString() ?? string.Empty; // Nếu có trường nhà cung cấp


                            dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
                            dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
                            dateTimePickerNgayHetHan.Value= reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : DateTime.Now; // Nếu có trường ngày hết hạn, nếu không thì mặc định là ngày hiện tại
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
                                    pictureBoxHangHoa.Image = null;
                                    MessageBox.Show("Không tìm thấy ảnh: " + duongDan, "Lỗi hình ảnh", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                pictureBoxHangHoa.Image = null;
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
    }
}
