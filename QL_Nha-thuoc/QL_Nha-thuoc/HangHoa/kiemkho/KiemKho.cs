using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc;
using QL_Nha_thuoc.model;
using QL_Nha_thuoc.NhanVien;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QL_Nha_thuoc.DanhMucThuoc;

namespace QL_Nha_thuoc
{
    public partial class KiemKho : Form
    {
        private FormMain formMain;


        public KiemKho(FormMain main)
        {
            InitializeComponent();
            formMain = main;

            LoadThuocTinhKiemKhoComboBox();
            LoadDanhSachPhieuKiemKho();
        }




        public KiemKho()
        {
            InitializeComponent();
            LoadThuocTinhKiemKhoComboBox();
            LoadDanhSachPhieuKiemKho();
        }

        private void LoadDanhSachPhieuKiemKho()
        {
            using (SqlConnection connection = DBHelperPK.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT PKK.MA_KIEM_KHO, NV.HO_TEN_NV, PKK.NGAY_KIEM_KHO, PKK.NGAY_CAN_BANG_KHO, PKK.TRANG_THAI_PHIEU_KIEM,PKK.GHI_CHU_KIEM_KHO
                             FROM PHIEU_KIEM_KHO PKK
                             JOIN NHAN_VIEN NV ON PKK.MA_NV = NV.MA_NV";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PhieuKiemKho> danhSachPhieu = new List<PhieuKiemKho>();

                    while (reader.Read())
                    {
                        string maPhieu = reader["MA_KIEM_KHO"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();
                        DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
                        DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
                        string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();
                        string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? string.Empty : reader["GHI_CHU_KIEM_KHO"].ToString();

                        danhSachPhieu.Add(new PhieuKiemKho(maPhieu, tenNV, ngayKiem, ngayCanBang, trangThai, ghiChu));
                    }

                    dataGridViewdsPhieuKiemKho.DataSource = danhSachPhieu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách phiếu kiểm kho: " + ex.Message);
                }
            }
        }


        private void LoadThuocTinhKiemKhoComboBox()
        {
            List<ThuocTinhHienThi> danhSachThuocTinh = new List<ThuocTinhHienThi>
            {
                new ThuocTinhHienThi { GiaTri = "NV.HO_TEN_NV", HienThi = "Tên nhân viên" },
                new ThuocTinhHienThi { GiaTri = "PKK.MA_KIEM_KHO", HienThi = "Mã phiếu kiểm kho" }
                // Nếu có thêm cột khác thì thêm vào
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
                textBoxTimPhieuKiem.PlaceholderText = $"Tìm theo {thuocTinh.HienThi}";
            }
        }

        private void TimKiemPhieuKiemKho(string cotTimKiem, string giaTriTimKiem)
        {
            using (SqlConnection connection = DBHelperPK.GetConnection())
            {
                try
                {
                    connection.Open();

                    string query = $@"SELECT PKK.MA_KIEM_KHO, NV.HO_TEN_NV, PKK.NGAY_KIEM_KHO, PKK.NGAY_CAN_BANG_KHO, PKK.TRANG_THAI_PHIEU_KIEM, PKK.GHI_CHU_KIEM_KHO
                              FROM PHIEU_KIEM_KHO PKK
                              JOIN NHAN_VIEN NV ON PKK.MA_NV = NV.MA_NV
                              WHERE {cotTimKiem} LIKE @GiaTriTimKiem";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@GiaTriTimKiem", $"%{giaTriTimKiem}%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<PhieuKiemKho> ketQuaTim = new List<PhieuKiemKho>();

                    while (reader.Read())
                    {
                        string maPhieu = reader["MA_KIEM_KHO"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();
                        DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
                        DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
                        string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();
                        string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? string.Empty : reader["GHI_CHU_KIEM_KHO"].ToString();

                        ketQuaTim.Add(new PhieuKiemKho(maPhieu, tenNV, ngayKiem, ngayCanBang, trangThai, ghiChu));
                    }

                    dataGridViewdsPhieuKiemKho.DataSource = ketQuaTim;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }


        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string cotTimKiem = LayCotTimKiem();
            string giaTriTimKiem = textBoxTimPhieuKiem.Text.Trim();

            if (string.IsNullOrEmpty(cotTimKiem) || string.IsNullOrEmpty(giaTriTimKiem))
            {
                LoadDanhSachPhieuKiemKho(); // Không nhập gì thì load lại toàn bộ
            }
            else
            {
                TimKiemPhieuKiemKho(cotTimKiem, giaTriTimKiem);
            }
        }

        private void dataGridViewdsPhieuKiemKho_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewdsPhieuKiemKho.Rows.Count)
            {
                DataGridViewRow row = dataGridViewdsPhieuKiemKho.Rows[e.RowIndex];
                string maPhieuKiem = row.Cells["MaPhieuKiemKho"].Value.ToString(); // ✅ sửa lại đúng tên thuộc tính
                FormChiTietKiemKho chiTietForm = new FormChiTietKiemKho(maPhieuKiem);
                chiTietForm.ShowDialog();
            }
        }



        private void buttonThemKiemKho_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = DBHelperPK.GetConnection())
            {
                try
                {
                    connection.Open();

                    // ✅ Sinh mã mới
                    string maPhieuKiem = PhieuKiemKho.SinhMaPhieuMoi();



                    // ✅ Thêm vào CSDL
                    string query = @"INSERT INTO PHIEU_KIEM_KHO (MA_KIEM_KHO,MA_KHO, MA_NV, NGAY_KIEM_KHO, TRANG_THAI_PHIEU_KIEM)
                             VALUES (@MaPhieu,'1', @MaNV, @NgayKiem, N'Phiếu tạm')";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieuKiem);
                    //Session.TaiKhoanDangNhap.NhanVien.MaNhanVien
                    cmd.Parameters.AddWithValue("@MaNV",Session.TaiKhoanDangNhap.MaNhanVien);
                    cmd.Parameters.AddWithValue("@NgayKiem", DateTime.Now);
                    cmd.ExecuteNonQuery();

                    // ✅ Tạo form mới và truyền mã vào
                    FormThemKiemKho formThemKiemKho = new FormThemKiemKho(maPhieuKiem);
                    formMain.LoadFormVaoPanel(formThemKiemKho);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo phiếu kiểm kho: " + ex.Message);
                }
            }
        }



    }
}
