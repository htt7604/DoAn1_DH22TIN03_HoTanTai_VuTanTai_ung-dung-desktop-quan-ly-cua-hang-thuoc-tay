using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.Them;
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
    public partial class FormCapNhatHangHoa : Form
    {
        public string tonKhohientai; // Biến toàn cục để lưu trữ tồn kho hiện tại, nếu cần sử dụng sau này
        public FormCapNhatHangHoa(string maHangHoa)
        {
            InitializeComponent();
            LoadDataToForm(maHangHoa);
            //LoadDataToComboBoxLoaiHanghoa();
            //LoadDataToComboboxHangSX(); // Load dữ liệu hãng sản xuất
            //LoadDataToComboboxDonViTinh(); // Load dữ liệu đơn vị tính
        }




        // Load dữ liệu vào combobox Loại hàng
        private void LoadDataToComboBoxLoaiHanghoa()
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_LOAI_HH, MA_LOAI_HH FROM LOAI_HANG";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxLoaiHang.DataSource = table;
                        comboBoxLoaiHang.DisplayMember = "TEN_LOAI_HH";
                        comboBoxLoaiHang.ValueMember = "MA_LOAI_HH";
                        //comboBoxLoaiHang.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load loại hàng: " + ex.Message);
            }
        }

        // Load nhóm hàng theo loại hàng được chọn
        private void LoadDataToComboBoxNhomHanghoa()
        {
            if (comboBoxLoaiHang.SelectedItem is DataRowView selectedRow)
            {
                string maLoai = selectedRow["MA_LOAI_HH"].ToString();

                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MA_NHOM_HH, TEN_NHOM 
                                     FROM NHOM_HANG 
                                     WHERE MA_LOAI_HH = @loaihang";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@loaihang", maLoai);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            comboBoxNhomHang.DataSource = dt;
                            comboBoxNhomHang.DisplayMember = "TEN_NHOM";
                            comboBoxNhomHang.ValueMember = "MA_NHOM_HH";
                            //comboBoxNhomHang.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        private void comboBoxLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLoaiHang.SelectedIndex == -1)
            {
                comboBoxNhomHang.DataSource = null; // Xóa dữ liệu nhóm hàng khi không có loại hàng nào được chọn
                return;
            }
            LoadDataToComboBoxNhomHanghoa();
        }

        // Load dữ liệu hãng sản xuất vào combobox
        private void LoadDataToComboboxHangSX()
        {

            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_HANG_SX, MA_HANG_SX FROM HANG_SAN_XUAT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxHangSX.DataSource = table;
                        comboBoxHangSX.DisplayMember = "TEN_HANG_SX";
                        comboBoxHangSX.ValueMember = "MA_HANG_SX";
                        //comboBoxHangSX.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load hãng sản xuất: " + ex.Message);
            }
        }

        //load du lieu va combobox don vi tinh
        private void LoadDataToComboboxDonViTinh()
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_DON_VI_TINH, MA_DON_VI_TINH FROM DON_VI_TINH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxDonViTinh.DataSource = table;
                        comboBoxDonViTinh.DisplayMember = "TEN_DON_VI_TINH";
                        comboBoxDonViTinh.ValueMember = "MA_DON_VI_TINH";
                        //comboBoxDonViTinh.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load đơn vị tính: " + ex.Message);
            }
        }



        //load toan do du lieu cua hang hoa co maHangHoa
        private void LoadDataToForm(string maHangHoa)
        {
            CSDL cSDL = new CSDL();
            SqlConnection conn = CSDL.GetConnection();
            string query = @"
        SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GHH.GIA_BAN_HH, 
               NH.TEN_NHOM, LH.TEN_LOAI_HH, HH.HINH_ANH_HH, HH.MA_VACH, GHH.GIA_VON_HH, 
               DDT.MA_DUONG_DUNG, HH.QUY_CACH_DONG_GOI, HH.GHI_CHU_HH,HSX.TEN_HANG_SX, HH.MA_HANG_SX,HH.TON_KHO,
               NCC.TEN_NHA_CUNG_CAP, HH.NGAY_HET_HAN_HH, DVT.TEN_DON_VI_TINH,HH.MA_NHOM_HH, NH.MA_LOAI_HH,HH.QUY_CACH_DONG_GOI,DVT.MA_DON_VI_TINH,DVT.TEN_DON_VI_TINH,
               GHH.Ti_LE_LOI
        FROM HANG_HOA HH
         JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
         JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
        LEFT JOIN DUONG_DUNG_THUOC DDT ON HH.MA_DUONG_DUNG=DDT.MA_DUONG_DUNG
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
                            // Gán thông tin cơ bản
                            textBoxTenHangHoa.Text = reader["TEN_HANG_HOA"].ToString();
                            textBoxMaHH.Text = reader["MA_HANG_HOA"].ToString();
                            textBoxMaVach.Text = reader["MA_VACH"]?.ToString() ?? string.Empty;
                            textBoxGiaBan.Text = reader["GIA_BAN_HH"]?.ToString() ?? "0";
                            textBoxGiaVon.Text = reader["GIA_VON_HH"]?.ToString() ?? "0";
                            textBoxTiLeLoiNhuan.Text = reader["Ti_LE_LOI"]?.ToString() ?? "0";
                            textBoxQuyCachDongGoi.Text = reader["QUY_CACH_DONG_GOI"]?.ToString() ?? string.Empty;
                            textBoxGhiChu.Text = reader["GHI_CHU_HH"]?.ToString() ?? string.Empty;
                            textBoxTonKho.Text = reader["TON_KHO"]?.ToString() ?? "0";

                            tonKhohientai = textBoxTonKho.Text; // Lưu tồn kho hiện tại vào biến toàn cục

                            // Load và chọn Loại hàng hóa
                            LoadDataToComboBoxLoaiHanghoa();
                            string maLoai = reader["MA_LOAI_HH"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(maLoai))
                            {
                                comboBoxLoaiHang.SelectedValue = maLoai;
                            }
                            else
                            {
                                comboBoxLoaiHang.SelectedIndex = -1;
                            }

                            // Load và chọn Nhóm hàng hóa
                            LoadDataToComboBoxNhomHanghoa();
                            string maNhom = reader["MA_NHOM_HH"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(maNhom))
                            {
                                comboBoxNhomHang.SelectedValue = maNhom;
                            }
                            else
                            {
                                comboBoxNhomHang.SelectedIndex = -1;
                            }


                            //load va chon hang san xuat
                            LoadDataToComboboxHangSX();
                            string maHangSX = reader["MA_HANG_SX"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(maHangSX))
                            {
                                comboBoxHangSX.SelectedValue = maHangSX;
                            }
                            else
                            {
                                comboBoxHangSX.SelectedIndex = -1;
                            }


                            //load va chon don vi tinh
                            LoadDataToComboboxDonViTinh();
                            string maDonViTinh = reader["MA_DON_VI_TINH"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(maDonViTinh))
                            {
                                comboBoxDonViTinh.SelectedValue = maDonViTinh;
                            }
                            else
                            {
                                comboBoxDonViTinh.SelectedIndex = -1;
                            }



                            // Xử lý hình ảnh
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




        // Load dữ liệu khi form khởi tạo
        private void FormCapNhatHanghoa_Load(object sender, EventArgs e)
        {

            textBoxMaHH.ReadOnly = true; // Mã hàng hóa không cho phép sửa
            textBoxGiaBan.ReadOnly = true; // Giá bán không cho phép sửa
            comboBoxLoaiHang.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxHangSX.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxNhomHang.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDonViTinh.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonThemHangSX_Click(object sender, EventArgs e)
        {
            var formThem = new FormThemHangSX();
            formThem.StartPosition = FormStartPosition.CenterParent;

            formThem.DuLieuDaThayDoi += (s, ev) =>
            {
                // Load lại danh sách hãng SX
                LoadDataToComboboxHangSX();

                // Tìm tên hãng vừa thêm và chọn nó
                string tenMoi = formThem.TenHangSXMoi;
                if (!string.IsNullOrEmpty(tenMoi))
                {
                    int index = comboBoxHangSX.FindStringExact(tenMoi);
                    if (index >= 0)
                    {
                        comboBoxHangSX.SelectedIndex = index;
                    }
                }
            };

            formThem.ShowDialog();
        }


        private string duongDanAnhTam = ""; // Đường dẫn ảnh tạm được chọn từ máy
        private string tenAnhLuu = ""; // Tên ảnh sẽ lưu trong thư mục dự án


        //hinh anh 
        private void buttonChonAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn ảnh hàng hóa";
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Image img = Image.FromFile(ofd.FileName);
                        pictureBoxHangHoa.Image = img;

                        duongDanAnhTam = ofd.FileName;
                        tenAnhLuu = Path.GetFileName(ofd.FileName); // Lưu lại tên ảnh
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể mở ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        //nut luu
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string maHH = textBoxMaHH.Text.Trim();
            string tenHH = textBoxTenHangHoa.Text.Trim();
            string maVach = textBoxMaVach.Text.Trim();
            string giaBan = textBoxGiaBan.Text.Trim();
            string giaVon = textBoxGiaVon.Text.Trim();
            string tiLeLoi = textBoxTiLeLoiNhuan.Text.Trim();
            string ghiChu = textBoxGhiChu.Text.Trim();
            string quyCach = textBoxQuyCachDongGoi.Text.Trim();
            string tonKhoStr = textBoxTonKho.Text.Trim();
            string maLoai = comboBoxLoaiHang.SelectedValue?.ToString();
            string maNhom = comboBoxNhomHang.SelectedValue?.ToString();
            string maHangSX = comboBoxHangSX.SelectedValue?.ToString();
            string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString();

            try
            {
                // ==== Kiểm tra logic bổ sung ====
                bool coGiaBan = !string.IsNullOrWhiteSpace(giaBan) && decimal.TryParse(giaBan, out _);
                bool coGiaVon = !string.IsNullOrWhiteSpace(giaVon) && decimal.TryParse(giaVon, out _);
                bool coTiLeLoi = !string.IsNullOrWhiteSpace(tiLeLoi) && decimal.TryParse(tiLeLoi, out _);
                bool coDonViTinh = !string.IsNullOrEmpty(maDonViTinh);


                if (coGiaVon && !coDonViTinh)
                {
                    MessageBox.Show("Vui lòng chọn Đơn vị tính khi có Giá von.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (coTiLeLoi && !coGiaVon)
                {
                    MessageBox.Show("Vui lòng nhập Giá vốn khi có Tỷ lệ lợi nhuận.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (coGiaVon && coTiLeLoi && !coDonViTinh)
                {
                    MessageBox.Show("Vui lòng chọn Đơn vị tính khi có cả Giá vốn và Tỷ lệ lợi nhuận.", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // ==== Kết thúc kiểm tra bổ sung ====

                if (!string.IsNullOrEmpty(duongDanAnhTam) && File.Exists(duongDanAnhTam))
                {
                    string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa";
                    string duongDanLuu = Path.Combine(thuMucAnh, tenAnhLuu);
                    File.Copy(duongDanAnhTam, duongDanLuu, true);
                }

                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    StringBuilder query = new StringBuilder();
                    query.Append("UPDATE HANG_HOA SET TEN_HANG_HOA = @tenHH, MA_VACH = @maVach, MA_NHOM_HH = @maNhom, MA_HANG_SX = @maHangSX, MA_DUONG_DUNG = NULL, QUY_CACH_DONG_GOI = @quyCach, GHI_CHU_HH = @ghiChu,TON_KHO=@tonKho");

                    if (!string.IsNullOrEmpty(tenAnhLuu))
                    {
                        query.Append(", HINH_ANH_HH = @tenAnh");
                    }

                    query.Append(" WHERE MA_HANG_HOA = @maHH;");

                    using (SqlCommand cmd = new SqlCommand(query.ToString(), conn))
                    {
                        cmd.Parameters.AddWithValue("@maHH", maHH);
                        cmd.Parameters.AddWithValue("@tenHH", tenHH);
                        cmd.Parameters.AddWithValue("@maVach", maVach);
                        cmd.Parameters.AddWithValue("@ghiChu", ghiChu);
                        cmd.Parameters.AddWithValue("@quyCach", quyCach);
                        cmd.Parameters.AddWithValue("@maNhom", maNhom);
                        cmd.Parameters.AddWithValue("@maHangSX", string.IsNullOrEmpty(maHangSX) ? DBNull.Value : (object)maHangSX);
                        cmd.Parameters.AddWithValue("@maDonViTinh", string.IsNullOrEmpty(maDonViTinh) ? DBNull.Value : (object)maDonViTinh);
                        cmd.Parameters.AddWithValue("@tonKho",string.IsNullOrEmpty(tonKhoStr) ? 0 : int.Parse(tonKhoStr));
                        if (!string.IsNullOrEmpty(tenAnhLuu))
                        {
                            cmd.Parameters.AddWithValue("@tenAnh", tenAnhLuu);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    if (coDonViTinh)
                    {
                        string queryCheck = "SELECT COUNT(*) FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH";
                        using (SqlCommand checkCmd = new SqlCommand(queryCheck, conn))
                        {
                            checkCmd.Parameters.AddWithValue("@maHH", maHH);
                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                string updateGia = "UPDATE GIA_HANG_HOA SET TI_LE_LOI = @tiLeLoi, GIA_VON_HH = @giaVon, MA_DON_VI_TINH = @maDonViTinh WHERE MA_HANG_HOA = @maHH";
                                using (SqlCommand updateCmd = new SqlCommand(updateGia, conn))
                                {
                                    updateCmd.Parameters.AddWithValue("@maHH", maHH);
                                    updateCmd.Parameters.AddWithValue("@tiLeLoi", string.IsNullOrEmpty(tiLeLoi) ? 0 : decimal.Parse(tiLeLoi));
                                    updateCmd.Parameters.AddWithValue("@giaVon", string.IsNullOrEmpty(giaVon) ? 0 : decimal.Parse(giaVon));
                                    updateCmd.Parameters.AddWithValue("@maDonViTinh", maDonViTinh);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                string insertGia = "INSERT INTO GIA_HANG_HOA (MA_HANG_HOA, TI_LE_LOI, GIA_VON_HH, MA_DON_VI_TINH) VALUES (@maHH, @tiLeLoi, @giaVon, @maDonViTinh)";
                                using (SqlCommand insertCmd = new SqlCommand(insertGia, conn))
                                {
                                    insertCmd.Parameters.AddWithValue("@maHH", maHH);
                                    insertCmd.Parameters.AddWithValue("@tiLeLoi", string.IsNullOrEmpty(tiLeLoi) ? 0 : decimal.Parse(tiLeLoi));
                                    insertCmd.Parameters.AddWithValue("@giaVon", string.IsNullOrEmpty(giaVon) ? 0 : decimal.Parse(giaVon));
                                    insertCmd.Parameters.AddWithValue("@maDonViTinh", maDonViTinh);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                    else if (string.IsNullOrWhiteSpace(giaVon) && string.IsNullOrWhiteSpace(tiLeLoi))
                    {
                        // Nếu không có giá vốn và không có tỷ lệ lợi nhuận, thì xóa bản ghi trong GIA_HANG_HOA
                        string deleteGia = "DELETE FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH";
                        using (SqlCommand deleteCmd = new SqlCommand(deleteGia, conn))
                        {
                            deleteCmd.Parameters.AddWithValue("@maHH", maHH);
                            deleteCmd.ExecuteNonQuery();
                        }
                    }

                    //neu thay doi ton kho thi tao ra phieu kiem kho 
                    if (tonKhohientai != tonKhoStr)
                    {
                        //tao ma phieu kiem kho moi 
                        string makiemkho = ClassPhieuKiemKho.SinhMaPhieuMoi();
                        //them phieu kiem kho
                        ClassPhieuKiemKho phieuKiemKho = new ClassPhieuKiemKho
                        {
                            MaPhieuKiemKho = makiemkho,
                            NgayKiemKho = DateTime.Now,
                            MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien, // Cần thay đổi theo mã nhân viên thực tế
                            GhiChu = "Cập nhật tồn kho hàng hóa",
                            TrangThaiPhieuKiem= "Đã cân bằng kho"
                        };
                        ClassPhieuKiemKho.ThemPhieuKiemKho(phieuKiemKho);
                        //tao chi tiet phieu kiem kho
                        ClassChiTietPhieuKiemKho chiTietPhieuKiemKho = new ClassChiTietPhieuKiemKho
                        {
                            MaPhieuKiemKho = makiemkho,
                            MaHangHoa = maHH,
                            TenHangHoa = tenHH,
                            SoLuongHeThong = int.Parse(tonKhohientai),
                            SoLuongThucTe = int.Parse(tonKhoStr),

                        };
                        ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTietPhieuKiemKho);
                        MessageBox.Show("Tạo phiếu kiểm kho với mã: " + makiemkho, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }




                    MessageBox.Show("Cập nhật hàng hóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formChiTiet?.LoadData();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private ChitietHangHoa formChiTiet;

        public FormCapNhatHangHoa(string maHangHoa, ChitietHangHoa formChiTiet = null)
        {
            InitializeComponent();
            this.formChiTiet = formChiTiet;
            LoadDataToForm(maHangHoa);
        }

        private void textBoxGiaVon_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra nếu giá vốn khong co giá trị hoặc không phải là số thi dat về 0
            if (string.IsNullOrEmpty(textBoxGiaVon.Text) || !decimal.TryParse(textBoxGiaVon.Text, out _))
            {
                textBoxGiaVon.Text = "0"; // Đặt giá trị về 0 nếu không hợp lệ
            }
            //neu giá trị hợp lệ thì không làm gì cả
            else
            {
                // Chuyển đổi giá trị sang định dạng số thập phân
                if (decimal.TryParse(textBoxGiaVon.Text, out decimal giaVon))
                {
                    textBoxGiaVon.Text = giaVon.ToString("N0"); // Định dạng lại với dấu phẩy ngàn
                    textBoxGiaVon.SelectionStart = textBoxGiaVon.Text.Length; // Đặt con trỏ ở cuối
                    //bat texbox loi nhuan 

                }

            }
        }

        private void buttonThemNhomHang_Click(object sender, EventArgs e)
        {
            using (var formThemNhom = new FormThemNhomHangHoa())
            {
                formThemNhom.StartPosition = FormStartPosition.CenterParent;

                // Hiển thị form con để thêm nhóm hàng
                var ketQua = formThemNhom.ShowDialog();

                // Nếu người dùng bấm "Lưu" và đóng form thành công thì cập nhật lại combobox
                if (ketQua == DialogResult.OK)
                {
                    LoadDataToComboBoxNhomHanghoa();

                    // Nếu form con có thuộc tính trả về tên nhóm vừa thêm thì chọn nó
                    string tenMoi = formThemNhom.TenNhomMoi;
                    if (!string.IsNullOrEmpty(tenMoi))
                    {
                        int index = comboBoxNhomHang.FindStringExact(tenMoi);
                        if (index >= 0)
                        {
                            comboBoxNhomHang.SelectedIndex = index;
                        }
                    }
                }
            }
        }

        private void buttonXoaNhomHangHoa_Click(object sender, EventArgs e)
        {
            string maNhom = comboBoxNhomHang.SelectedValue?.ToString();
            string tenNhom = comboBoxNhomHang.Text;

            if (string.IsNullOrEmpty(maNhom))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng '{tenNhom}' không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra xem nhóm hàng có đang được dùng ở nơi khác không (tuỳ theo hệ thống bạn có thể bỏ qua)
                    string checkUsage = "SELECT COUNT(*) FROM HANG_HOA WHERE MA_NHOM_HH = @maNhom";
                    using (SqlCommand checkCmd = new SqlCommand(checkUsage, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maNhom", maNhom);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Không thể xóa nhóm hàng này vì đang được sử dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Xóa nhóm hàng
                    string deleteQuery = "DELETE FROM NHOM_HANG WHERE MA_NHOM_HH = @maNhom";
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhom", maNhom);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Xóa nhóm hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Load lại combobox nhóm hàng
                    LoadDataToComboBoxNhomHanghoa();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa nhóm hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}

