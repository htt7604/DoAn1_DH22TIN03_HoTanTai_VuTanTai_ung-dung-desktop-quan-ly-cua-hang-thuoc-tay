using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static QL_Nha_thuoc.DanhMucThuoc;
using static QL_Nha_thuoc.model.ClassChiTietPhieuNhap;
using QL_Nha_thuoc.model;


namespace QL_Nha_thuoc
{
    public partial class NhapHang : Form
    {
        private FormMain _formMain; // biến để giữ tham chiếu FormMain

        public NhapHang(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;



            textBoxTimHH.KeyDown += textBoxTimHH_KeyDown;
        }


        private void LoadDanhSachPhieuNhapHang()
        {
            try
            {
                dataGridViewdsNhapHang.AutoGenerateColumns = false;
                dataGridViewdsNhapHang.Columns.Clear();

                // Cột Mã phiếu nhập (ẩn nhưng vẫn truy cập được)
                dataGridViewdsNhapHang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "MaPhieuNhap", // Dùng để truy cập bằng row.Cells["MaPhieuNhap"]
                    HeaderText = "Mã phiếu nhập",
                    DataPropertyName = "MaPhieuNhap",
                    Visible = false // Ẩn cột nếu không muốn hiển thị
                });

                // Cột Ngày nhập
                dataGridViewdsNhapHang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "NgayNhap",
                    HeaderText = "Ngày nhập",
                    DataPropertyName = "NgayNhap",
                    DefaultCellStyle = { Format = "dd/MM/yyyy" },
                    FillWeight = 15
                });

                // Cột Tên nhà cung cấp
                dataGridViewdsNhapHang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TenNhaCungCap",
                    HeaderText = "Nhà cung cấp",
                    DataPropertyName = "TenNhaCungCap",
                    FillWeight = 30
                });

                // Cột Số tiền đã trả
                dataGridViewdsNhapHang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "SoTienDaTra",
                    HeaderText = "Số tiền đã trả",
                    DataPropertyName = "SoTienDaTra",
                    DefaultCellStyle = { Format = "N0", Alignment = DataGridViewContentAlignment.MiddleRight },
                    FillWeight = 20
                });

                // Cột Trạng thái
                dataGridViewdsNhapHang.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "TrangThai",
                    HeaderText = "Trạng thái",
                    DataPropertyName = "TrangThai",
                    FillWeight = 20
                });

                // Gán nguồn dữ liệu
                dataGridViewdsNhapHang.DataSource = ClassPhieuNhapHang.GetDanhSachPhieuNhapHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách phiếu nhập: " + ex.Message);
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



        private void NhapHang_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhieuNhapHang();
            LoadThuocTinhKiemKhoComboBox();
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

            using (SqlConnection conn = CSDL.GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = $@"
                        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
                               NCC.TEN_NHA_CUNG_CAP, 
                               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_TRA, 0)) AS SO_TIEN_CON_NO,
                               PN.TRANG_THAI
                        FROM PHIEU_NHAP_HANG PN
                        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
                        WHERE {cotTimKiem} LIKE @TuKhoa
                        ORDER BY PN.NGAY_NHAP DESC";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                    SqlDataReader reader = cmd.ExecuteReader();

                    List<ClassPhieuNhapHang> danhSachPhieu = new List<ClassPhieuNhapHang>();

                    while (reader.Read())
                    {
                        danhSachPhieu.Add(new ClassPhieuNhapHang
                        {
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                            NgayNhap = reader["NGAY_NHAP"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_NHAP"]) : (DateTime?)null,
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
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
            string maPhieuNhap = ClassPhieuNhapHang.TaoMaPhieuNhap(); // Tạo mã phiếu nhập mới
            FormThemNhapHang formThemNhapHang = new FormThemNhapHang(maPhieuNhap);
            formThemNhapHang.setData();
            formThemNhapHang.FormThemNhapDong += () =>
            {
                _formMain.LoadFormVaoPanel(this); // Gọi lại form thêm nhập hàng
                NhapHang_Load(sender, e); // Tải lại danh sách phiếu nhập khi form thêm đóng
            };
            _formMain.LoadFormVaoPanel(formThemNhapHang); // dùng biến đã truyền
        }

        private void dataGridViewdsNhapHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Open the form for detailed receipt
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewdsNhapHang.Rows.Count)
            {
                DataGridViewRow row = dataGridViewdsNhapHang.Rows[e.RowIndex];
                string maPhieuNhap = row.Cells["MaPhieuNhap"].Value.ToString();
                FormChiTietPhieuNhap formChiTietPhieuNhap = new FormChiTietPhieuNhap(_formMain);
                ClassPhieuNhapHang phieuNhapHang = ClassPhieuNhapHang.TimTheoMaPhieuNhap(maPhieuNhap);
                if (phieuNhapHang != null)
                {
                    formChiTietPhieuNhap.SetData(phieuNhapHang);
                    formChiTietPhieuNhap.FormDong += () =>
                    {
                        _formMain.LoadFormVaoPanel(this); // Gọi lại form nhập hàng
                        NhapHang_Load(sender, e); // Tải lại danh sách phiếu nhập khi form chi tiết đóng
                    };
                    formChiTietPhieuNhap.ShowDialog(); // Hiển thị form chi tiết phiếu nhập
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu nhập với mã: " + maPhieuNhap);
                }
            }
        }


        private void LoadPhieuNhapTheoTrangThai(string trangThai)
        {
            List<ClassPhieuNhapHang> danhSach;

            if (trangThai == "Tất cả")
            {
                danhSach = ClassPhieuNhapHang.GetDanhSachPhieuNhapHang();
            }
            else
            {
                danhSach = ClassPhieuNhapHang.GetDanhSachPhieuNhapHang()
                             .Where(p => p.TrangThai != null && p.TrangThai.Equals(trangThai, StringComparison.OrdinalIgnoreCase))
                             .ToList();
            }

            dataGridViewdsNhapHang.DataSource = danhSach;
        }


        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTatCa.Checked)
            {
                LoadPhieuNhapTheoTrangThai("Tất cả");
            }
        }

        private void radioButtonDaNhap_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDaNhap.Checked)
            {
                LoadPhieuNhapTheoTrangThai("Đã nhập hàng");
            }
        }

        private void radioButtonDaHuy_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDaHuy.Checked)
            {
                LoadPhieuNhapTheoTrangThai("Đã hủy");
            }
        }

    }
}
