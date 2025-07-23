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

        public void LoadDanhSachPhieuKiemKho()
        {
            using (SqlConnection connection = DBHelperPK.GetConnection())
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT PKK.MA_KIEM_KHO,PKK.NGAY_KIEM_KHO,PKK.NGAY_CAN_BANG_KHO,PKK.TONG_THUC_TE,
                               PKK.TONG_CHECH_LECH,PKK.SO_LUONG_LECH_TANG,PKK.SO_LUONG_LECH_GIAM,pkk.GHI_CHU_KIEM_KHO,pkk.TRANG_THAI_PHIEU_KIEM,
                              NV.HO_TEN_NV,PKK.MA_NV
                       FROM PHIEU_KIEM_KHO PKK 
                       JOIN NHAN_VIEN NV ON NV.MA_NV = PKK.MA_NV";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ClassPhieuKiemKho> danhSachPhieu = new List<ClassPhieuKiemKho>();

                    while (reader.Read())
                    {
                        string maPhieu = reader["MA_KIEM_KHO"].ToString();
                        string maNV = reader["MA_NV"].ToString();
                        string hoTenNV = reader["HO_TEN_NV"].ToString();
                        string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();
                        DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
                        DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
                        string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? "" : reader["GHI_CHU_KIEM_KHO"].ToString();
                        int tongThucTe = reader["TONG_THUC_TE"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_THUC_TE"]);
                        int tongChechLech = reader["TONG_CHECH_LECH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_CHECH_LECH"]);
                        int soLuongLechGiam = reader["SO_LUONG_LECH_GIAM"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_GIAM"]);
                        int soLuongLechTang = reader["SO_LUONG_LECH_TANG"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_TANG"]);

                        danhSachPhieu.Add(new ClassPhieuKiemKho(maPhieu, hoTenNV, ngayKiem, ngayCanBang, tongThucTe, tongChechLech, soLuongLechGiam, soLuongLechTang, ghiChu, trangThai));
                    }

                    dataGridViewdsPhieuKiemKho.DataSource = danhSachPhieu;


                    dataGridViewdsPhieuKiemKho.Columns["MaPhieuKiemKho"].HeaderText = "Mã phiếu kiểm kho";
                    dataGridViewdsPhieuKiemKho.Columns["NgayKiemKho"].HeaderText = "Ngày kiểm kho";
                    dataGridViewdsPhieuKiemKho.Columns["ThoiGianCanBangKho"].HeaderText = "Ngày cân bằng";
                    dataGridViewdsPhieuKiemKho.Columns["TongThucTe"].HeaderText = "Tổng thực tế";
                    dataGridViewdsPhieuKiemKho.Columns["TongChechLech"].HeaderText = "Tổng chênh lệch";
                    dataGridViewdsPhieuKiemKho.Columns["SoLuongLechGiam"].HeaderText = "SL lệch giảm";
                    dataGridViewdsPhieuKiemKho.Columns["SoLuongLechTang"].HeaderText = "SL lệch tăng";
                    dataGridViewdsPhieuKiemKho.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dataGridViewdsPhieuKiemKho.Columns["TrangThaiPhieuKiem"].HeaderText = "Trạng thái";
                    dataGridViewdsPhieuKiemKho.Columns["TenNhanVien"].HeaderText = "Nhân viên thực hiện";





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

                    string query = $@"SELECT PKK.MA_KIEM_KHO,PKK.NGAY_KIEM_KHO,PKK.NGAY_CAN_BANG_KHO,PKK.TONG_THUC_TE,
                               PKK.TONG_CHECH_LECH,PKK.SO_LUONG_LECH_TANG,PKK.SO_LUONG_LECH_GIAM,pkk.GHI_CHU_KIEM_KHO,pkk.TRANG_THAI_PHIEU_KIEM,
                              NV.HO_TEN_NV,PKK.MA_NV
                       FROM PHIEU_KIEM_KHO PKK 
                       JOIN NHAN_VIEN NV ON NV.MA_NV = PKK.MA_NV
                              WHERE {cotTimKiem} LIKE @GiaTriTimKiem";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@GiaTriTimKiem", $"%{giaTriTimKiem}%");

                    SqlDataReader reader = cmd.ExecuteReader();
                    List<ClassPhieuKiemKho> ketQuaTim = new List<ClassPhieuKiemKho>();

                    while (reader.Read())
                    {
                        string maPhieu = reader["MA_KIEM_KHO"].ToString();
                        string maNV = reader["MA_NV"].ToString();
                        string hoTenNV = reader["HO_TEN_NV"].ToString();
                        DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
                        DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
                        int tongThucTe = reader["TONG_THUC_TE"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_THUC_TE"]);
                        int tongChechLech = reader["TONG_CHECH_LECH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_CHECH_LECH"]);
                        int soLuongLechGiam = reader["SO_LUONG_LECH_GIAM"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_GIAM"]);
                        int soLuongLechTang = reader["SO_LUONG_LECH_TANG"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_TANG"]);
                        string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();
                        string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? "" : reader["GHI_CHU_KIEM_KHO"].ToString();

                        ketQuaTim.Add(new ClassPhieuKiemKho(maPhieu, hoTenNV, ngayKiem, ngayCanBang, tongThucTe, tongChechLech, soLuongLechGiam, soLuongLechTang, ghiChu, trangThai));
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
            try
            {
                string maNV = Session.TaiKhoanDangNhap.MaNhanVien;
                string maPhieuKiem = ClassPhieuKiemKho.ThemPhieuKiemKhoMoi(maNV);

                FormThemKiemKho formThemKiemKho = new FormThemKiemKho(maPhieuKiem);
                // Gán sự kiện callback
                formThemKiemKho.FormDaDong += () =>
                {
                    //them KiemKho vao panel
                    formMain.LoadFormVaoPanel(this); // Quay lại form KiemKho
                    LoadDanhSachPhieuKiemKho(); // Cập nhật lại danh sách phiếu kiểm kho sau khi đóng form
                };
                formMain.LoadFormVaoPanel(formThemKiemKho);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo phiếu kiểm kho: " + ex.Message);
            }
        }




    }
}
