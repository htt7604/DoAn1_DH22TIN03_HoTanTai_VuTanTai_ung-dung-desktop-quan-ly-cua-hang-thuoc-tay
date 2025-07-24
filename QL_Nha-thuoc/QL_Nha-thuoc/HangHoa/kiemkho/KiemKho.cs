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
        private void KiemKho_Load(object sender, EventArgs e)
        {
            // Tạo cột checkbox đầu tiên
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "Tất cả";
            colCheck.Width = 50;

            // Custom header có checkbox
            var header = new DatagridViewCheckBoxHeaderCell();
            colCheck.HeaderCell = header;

            dataGridViewdsPhieuKiemKho.Columns.Insert(0, colCheck);

            // Gắn sự kiện khi click vào header checkbox
            header.OnCheckAllChanged += (isChecked) =>
            {
                dataGridViewdsPhieuKiemKho.EndEdit(); // <<== Dừng edit dòng hiện tại (có thể đang chọn)

                foreach (DataGridViewRow row in dataGridViewdsPhieuKiemKho.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells["Tất cả"].Value = isChecked;
                    }
                }
            };

            // Gán sự kiện để xử lý checkbox
            dataGridViewdsPhieuKiemKho.CellValueChanged += dataGridViewdsPhieuKiemKho_CellValueChanged;
            dataGridViewdsPhieuKiemKho.CurrentCellDirtyStateChanged += dataGridViewdsPhieuKiemKho_CurrentCellDirtyStateChanged;


            buttonGopPhieu.Visible = false; // Ẩn nút gộp phiếu ban đầu
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
                string maPhieuKiem = row.Cells["MaPhieuKiemKho"].Value.ToString();

                FormChiTietKiemKho chiTietForm = new FormChiTietKiemKho(maPhieuKiem);
                // GÁN SỰ KIỆN TRƯỚC KHI SHOW
                chiTietForm.FormDong += () =>
                {
                    LoadDanhSachPhieuKiemKho(); // Cập nhật lại danh sách phiếu
                };

                chiTietForm.ShowDialog(); // Gọi sau khi gán sự kiện
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


        private void CapNhatSoLuongDaChon()
        {
            int soLuongChon = 0;
            int soLuongPhieuTam = 0; // Đếm phiếu tạm đã được chọn

            foreach (DataGridViewRow row in dataGridViewdsPhieuKiemKho.Rows)
            {
                bool isChecked = false;

                if (row.Cells["Tất cả"].Value != null)
                    isChecked = Convert.ToBoolean(row.Cells["Tất cả"].Value);

                if (isChecked)
                {
                    soLuongChon++;

                    // Chỉ đếm phiếu tạm nếu nó đang được chọn
                    string trangThai = row.Cells["TrangThaiPhieuKiem"].Value?.ToString();
                    if (trangThai == "Phiếu tạm")
                    {
                        soLuongPhieuTam++;
                    }
                }
            }

            if (soLuongChon > 0)
            {
                labelSoX.Text = $"Đã chọn {soLuongChon} ({soLuongPhieuTam} phiếu tạm)";
                labelSoX.Visible = true;
                buttonX.Visible = true;
                buttonGopPhieu.Visible = true;
            }
            else
            {
                labelSoX.Text = "";
                labelSoX.Visible = false;
                buttonX.Visible = false;
                buttonGopPhieu.Visible = false;
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewdsPhieuKiemKho.Rows)
            {
                row.Cells[0].Value = false; // Bỏ tích checkbox ở cột đầu tiên
            }

            // Ẩn các thành phần liên quan đến việc chọn
            labelSoX.Text = "";
            labelSoX.Visible = false;
            buttonX.Visible = false;
            buttonGopPhieu.Visible = false; // Ẩn nút
        }

        private void dataGridViewdsPhieuKiemKho_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Cột checkbox
            {
                bool isChecked = Convert.ToBoolean(dataGridViewdsPhieuKiemKho.Rows[e.RowIndex].Cells[0].Value);
                //string maHH = dataGridViewdsDMHH.Rows[e.RowIndex].Cells["Mã hàng hóa"].Value?.ToString();

                CapNhatSoLuongDaChon();
            }
        }

        private void dataGridViewdsPhieuKiemKho_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewdsPhieuKiemKho.IsCurrentCellDirty)
            {
                dataGridViewdsPhieuKiemKho.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonGopPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> danhSachMaPhieuTam = new List<string>();

                // 1. Lấy danh sách phiếu tạm được chọn
                foreach (DataGridViewRow row in dataGridViewdsPhieuKiemKho.Rows)
                {
                    if (row.Cells["Tất cả"].Value != null && Convert.ToBoolean(row.Cells["Tất cả"].Value))
                    {
                        string trangThai = row.Cells["TrangThaiPhieuKiem"].Value?.ToString();
                        if (trangThai == "Phiếu tạm")
                        {
                            string maPhieu = row.Cells["MaPhieuKiemKho"].Value?.ToString();
                            if (!string.IsNullOrEmpty(maPhieu))
                                danhSachMaPhieuTam.Add(maPhieu);
                        }
                    }
                }

                if (danhSachMaPhieuTam.Count < 2)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất 2 phiếu tạm để gộp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Tạo phiếu kiểm kho mới
                string maNV = Session.TaiKhoanDangNhap.MaNhanVien;
                string maPhieuMoi = ClassPhieuKiemKho.ThemPhieuKiemKhoMoi(maNV);

                string ghiChu = "Gộp các phiếu kiểm kho: " + string.Join(", ", danhSachMaPhieuTam);
                ClassPhieuKiemKho.CapNhatGhiChu(maPhieuMoi, ghiChu);

                // 3. Tổng hợp chi tiết từ các phiếu
                var tongHopChiTiet = new Dictionary<string, ClassChiTietPhieuKiemKho>();

                foreach (var maPhieu in danhSachMaPhieuTam)
                {
                    var chiTiets = ClassChiTietPhieuKiemKho.LayDanhSachChiTietPhieuKiemKho(maPhieu);

                    foreach (var chiTiet in chiTiets)
                    {
                        if (tongHopChiTiet.ContainsKey(chiTiet.MaHangHoa))
                        {
                            tongHopChiTiet[chiTiet.MaHangHoa].SoLuongThucTe += chiTiet.SoLuongThucTe;
                        }
                        else
                        {
                            // Tạo bản sao và gán mã phiếu mới
                            var moi = new ClassChiTietPhieuKiemKho
                            {
                                MaPhieuKiemKho = maPhieuMoi,
                                MaHangHoa = chiTiet.MaHangHoa,
                                TenHangHoa = chiTiet.TenHangHoa,
                                SoLuongHeThong = chiTiet.SoLuongHeThong,
                                SoLuongThucTe = chiTiet.SoLuongThucTe,
                                GhiChu = ""
                            };
                            tongHopChiTiet.Add(moi.MaHangHoa, moi);
                        }
                    }
                }

                // 4. Lưu các chi tiết gộp vào phiếu mới
                foreach (var chiTiet in tongHopChiTiet.Values)
                {
                    ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTiet);
                }

                // 5. Xoá các phiếu cũ và chi tiết của chúng
                foreach (var maPhieu in danhSachMaPhieuTam)
                {
                    ClassChiTietPhieuKiemKho.XoaChiTietPhieuKiemKho(maPhieu);
                    ClassPhieuKiemKho.XoaPhieuKiemKho(maPhieu);
                }

                MessageBox.Show("Gộp phiếu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 6. Refresh lại danh sách
                LoadDanhSachPhieuKiemKho(); // bạn cần đảm bảo có hàm này

                buttonX.PerformClick(); // Bỏ chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gộp phiếu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Nếu checkbox được chọn, hiển thị phieu kiem kho 
        }
    }
}
