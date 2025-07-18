using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QL_Nha_thuoc.DanhMucThuoc;

namespace QL_Nha_thuoc
{
    public partial class NhapHang : Form
    {
        private FormMain _formMain; // biến để giữ tham chiếu FormMain

        public NhapHang(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;

            LoadDanhSachPhieuNhapHang();
            LoadThuocTinhKiemKhoComboBox();

            textBoxTimHH.KeyDown += textBoxTimHH_KeyDown;
        }


        private void LoadDanhSachPhieuNhapHang()
        {
            using (SqlConnection connection = DBHelperPN.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
                               NCC.TEN_NHA_CUNG_CAP, 
                               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_THANH_TOAN, 0)) AS SO_TIEN_CON_NO,
                               PN.TRANG_THAI
                        FROM PHIEU_NHAP_HANG PN
                        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
                        ORDER BY PN.NGAY_NHAP DESC";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PhieuNhapHang> danhSachPhieu = new List<PhieuNhapHang>();

                    while (reader.Read())
                    {
                        danhSachPhieu.Add(new PhieuNhapHang
                        {
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                            NgayNhap = reader["NGAY_NHAP"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_NHAP"]) : (DateTime?)null,
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                            SoTienConNo = reader["SO_TIEN_CON_NO"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_CON_NO"]) : 0,
                            TrangThai = reader["TRANG_THAI"]?.ToString()
                        });
                    }

                    dataGridViewdsNhapHang.DataSource = danhSachPhieu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách phiếu nhập: " + ex.Message);
                }
            }
        }

        private void LoadThuocTinhKiemKhoComboBox()
        {
            var danhSachThuocTinh = new List<ThuocTinhHienThi>
            {
                new ThuocTinhHienThi { GiaTri = "NCC.TEN_NHA_CUNG_CAP", HienThi = "Tên nhà cung cấp" },
                new ThuocTinhHienThi { GiaTri = "PN.MA_PHIEU_NHAP", HienThi = "Mã phiếu nhập" }
            };

            comboBoxLoaiTimKiem.Items.Clear();
            comboBoxLoaiTimKiem.Items.AddRange(danhSachThuocTinh.ToArray());
            if (comboBoxLoaiTimKiem.Items.Count > 0)
                comboBoxLoaiTimKiem.SelectedIndex = 0;
        }

        private string LayCotTimKiem()
        {
            if (comboBoxLoaiTimKiem.SelectedItem is ThuocTinhHienThi thuocTinh)
            {
                return thuocTinh.GiaTri;
            }
            return null;
        }

        private void comboBoxLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLoaiTimKiem.SelectedItem is ThuocTinhHienThi thuocTinh)
            {
                textBoxTimHH.PlaceholderText = $"Tìm theo {thuocTinh.HienThi}";
            }
        }

        private void TimKiemPhieuNhapHang(string cotTimKiem, string tuKhoa)
        {
            if (string.IsNullOrWhiteSpace(cotTimKiem) || string.IsNullOrWhiteSpace(tuKhoa))
                return;

            using (SqlConnection connection = DBHelperPN.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = $@"
                        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
                               NCC.TEN_NHA_CUNG_CAP, 
                               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_THANH_TOAN, 0)) AS SO_TIEN_CON_NO,
                               PN.TRANG_THAI
                        FROM PHIEU_NHAP_HANG PN
                        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
                        WHERE {cotTimKiem} LIKE @TuKhoa
                        ORDER BY PN.NGAY_NHAP DESC";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PhieuNhapHang> danhSachPhieu = new List<PhieuNhapHang>();

                    while (reader.Read())
                    {
                        danhSachPhieu.Add(new PhieuNhapHang
                        {
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                            NgayNhap = reader["NGAY_NHAP"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_NHAP"]) : (DateTime?)null,
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                            SoTienConNo = reader["SO_TIEN_CON_NO"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_CON_NO"]) : 0,
                            TrangThai = reader["TRANG_THAI"]?.ToString()
                        });
                    }

                    dataGridViewdsNhapHang.DataSource = danhSachPhieu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void textBoxTimHH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                string cotTimKiem = LayCotTimKiem();
                string tuKhoa = textBoxTimHH.Text.Trim();

                TimKiemPhieuNhapHang(cotTimKiem, tuKhoa);
            }
        }

        // Nếu không dùng tìm theo từng chữ thì có thể bỏ sự kiện này:
        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            // Có thể để trống nếu chỉ muốn tìm khi nhấn Enter
        }

        private void buttonThemNhapHang_Click(object sender, EventArgs e)
        {
            FormThemNhapHang formThemNhapHang = new FormThemNhapHang();
            _formMain.LoadFormVaoPanel(formThemNhapHang); // dùng biến đã truyền
        }



    }
}
