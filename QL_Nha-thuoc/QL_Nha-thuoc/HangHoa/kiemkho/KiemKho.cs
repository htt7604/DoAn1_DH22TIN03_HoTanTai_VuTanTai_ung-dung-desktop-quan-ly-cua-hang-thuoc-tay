using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QL_Nha_thuoc.DanhMucThuoc;

namespace QL_Nha_thuoc
{
    public partial class KiemKho : Form
    {
        public KiemKho()
        {
            InitializeComponent();
            LoadThuocTinhKiemKhoComboBox();
            LoadDanhSachPhieuKiemKho();
        }

        private void LoadDanhSachPhieuKiemKho()
        {
            using (SqlConnection connection = DBHelperPK.GetConnection()) // Sử dụng đúng DBHelperPK
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT PKK.MA_KIEM_KHO, NV.HO_TEN_NV 
                                     FROM PHIEU_KIEM_KHO PKK
                                     JOIN NHAN_VIEN NV ON PKK.MA_NV = NV.MA_NV";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<PhieuKiemKho> danhSachPhieu = new List<PhieuKiemKho>();

                    while (reader.Read())
                    {
                        string maPhieu = reader["MA_KIEM_KHO"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();

                        danhSachPhieu.Add(new PhieuKiemKho(maPhieu, tenNV));
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

                    string query = $@"SELECT PKK.MA_KIEM_KHO, NV.HO_TEN_NV 
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

                        ketQuaTim.Add(new PhieuKiemKho(maPhieu, tenNV));
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





    }
}
