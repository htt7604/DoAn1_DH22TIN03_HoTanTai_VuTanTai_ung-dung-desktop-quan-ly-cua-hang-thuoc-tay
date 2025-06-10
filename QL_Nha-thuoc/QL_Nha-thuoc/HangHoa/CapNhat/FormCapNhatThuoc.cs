using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa.CapNhat
{
    public partial class FormCapNhatThuoc : Form
    {
        public FormCapNhatThuoc(string maHangHoa)
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
                using (SqlConnection conn = new CSDL().GetConnection())
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

                using (SqlConnection conn = new CSDL().GetConnection())
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
                using (SqlConnection conn = new CSDL().GetConnection())
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
                using (SqlConnection conn = new CSDL().GetConnection())
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
        //load nha cung cap vao combobox
        private void LoadDataToComboboxNhaCungCap()
        {
            try
            {
                using (SqlConnection conn = new CSDL().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_NHA_CUNG_CAP, MA_NHA_CUNG_CAP FROM NHA_CUNG_CAP";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxNhaCungCap.DataSource = table;
                        comboBoxNhaCungCap.DisplayMember = "TEN_NHA_CUNG_CAP";
                        comboBoxNhaCungCap.ValueMember = "MA_NHA_CUNG_CAP";
                        //comboBoxNhaCungCap.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhà cung cấp: " + ex.Message);
            }
        }


        //load toan do du lieu cua hang hoa co maHangHoa
        private void LoadDataToForm(string maHangHoa)
        {
            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();
            string query = @"
        SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA,HH.TEN_VIET_TAT,HH.TRONG_LUONG_HH,HH.SO_DANG_KY_THUOC,HH.MA_THUOC,HH.HAM_LUONG,
               HH.HOAT_CHAT, GHH.GIA_BAN_HH,NH.MA_LOAI_HH, HH.MA_NHOM_HH,
               NH.TEN_NHOM, LH.TEN_LOAI_HH, HH.HINH_ANH_HH, HH.MA_VACH, GHH.GIA_VON_HH, 
               HSSX.MA_HANG_SX,HSSX.TEN_HANG_SX, HH.DUONG_DUNG_CHO_THUOC, HH.QUY_CACH_DONG_GOI, HH.GHI_CHU_HH, 
               NCC.TEN_NHA_CUNG_CAP, HH.NGAY_HET_HAN_HH, DVT.TEN_DON_VI_TINH,HH.TINH_TRANG_HH,DVT.MA_DON_VI_TINH,GHH.TI_LE_LOI,NCC.MA_NHA_CUNG_CAP
        FROM HANG_HOA HH
        JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
        JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
        LEFT JOIN HANG_SAN_XUAT HSSX ON HH.MA_HANG_SX = HSSX.MA_HANG_SX
        LEFT JOIN PHIEU_NHAP_HANG PN ON HH.MA_HANG_HOA = PN.MA_HANG_HOA
        LEFT JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
        LEFT JOIN GIA_HANG_HOA GHH ON GHH.MA_HANG_HOA = HH.MA_HANG_HOA
        LEFT JOIN DON_VI_TINH DVT ON GHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
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
                            textBoxMaVach.Text = reader["MA_VACH"]?.ToString() ?? string.Empty;
                            textBoxTenHangHoa.Text = reader["TEN_HANG_HOA"]?.ToString() ?? string.Empty; // Tránh lỗi nếu tên hàng hóa là null
                            textBoxMaThuoc.Text = reader["MA_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường mã thuốc
                            textBoxTenVietTat.Text = reader["TEN_VIET_TAT"].ToString();
                            textBoxGiaVon.Text = reader["GIA_VON_HH"]?.ToString() ?? "0"; // Nếu cần hiển thị giá nhập
                            textBoxGiaBan.Text = reader["GIA_BAN_HH"]?.ToString() ?? "0"; // Tránh lỗi nếu giá bán là null
                            textBoxTrongLuong.Text = reader["TRONG_LUONG_HH"]?.ToString() ?? "0"; // Tránh lỗi nếu trọng lượng là null
                            textBoxDuongDung.Text = reader["DUONG_DUNG_CHO_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường đường dùng
                            textBoxSoDangKy.Text = reader["SO_DANG_KY_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường số đăng ký thuốc
                            textBoxMaThuoc.Text = reader["MA_THUOC"]?.ToString() ?? string.Empty; // Nếu có trường mã thuốc
                            textBoxHamLuong.Text = reader["HAM_LUONG"]?.ToString() ?? string.Empty; // Nếu có trường hàm lượng
                            textBoxHoatChat.Text = reader["HOAT_CHAT"]?.ToString() ?? string.Empty; // Nếu có trường hoạt chất
                            textBoxTiLeLoiNhuan.Text = reader["TI_LE_LOI"]?.ToString() ?? "0"; // Nếu có trường tỷ lệ lợi nhuận, nếu không thì mặc định là 0
                            textBoxQuyCachDongGoi.Text = reader["QUY_CACH_DONG_GOI"]?.ToString() ?? string.Empty;
                            textBoxGhiChu.Text = reader["GHI_CHU_HH"]?.ToString() ?? string.Empty; // Nếu có trường ghi chú



                            dateTimePickerNgayHetHan.Format = DateTimePickerFormat.Custom;
                            dateTimePickerNgayHetHan.CustomFormat = "dd/MM/yyyy";
                            dateTimePickerNgayHetHan.Value = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : DateTime.Now; // Nếu có trường ngày hết hạn, nếu không thì mặc định là ngày hiện tại
                            dateTimePickerNgayHetHan.Enabled = false; // hoặc dateTimePicker1.Visible = false nếu muốn ẩn


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
                            LoadDataToComboboxNhaCungCap(); // Load dữ liệu nhà cung cấp
                            string maNhaCungCap = reader["MA_NHA_CUNG_CAP"]?.ToString().Trim();
                            if (!string.IsNullOrEmpty(maNhaCungCap))
                            {
                                comboBoxNhaCungCap.SelectedValue = maNhaCungCap;
                            }
                            else
                            {
                                comboBoxNhaCungCap.SelectedIndex = -1;
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

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string maHH = textBoxMaHH.Text.Trim();
            string tenHH = textBoxTenHangHoa.Text.Trim();
            string tenVietTat = textBoxTenVietTat.Text.Trim();
            string maThuoc = textBoxMaThuoc.Text.Trim();
            string soDangKy = textBoxSoDangKy.Text.Trim();
            string hoatChat = textBoxHoatChat.Text.Trim();
            string hamLuong = textBoxHamLuong.Text.Trim();
            string duongDung = textBoxDuongDung.Text.Trim();
            string quyCach = textBoxQuyCachDongGoi.Text.Trim();
            string ghiChu = textBoxGhiChu.Text.Trim();
            string maVach = textBoxMaVach.Text.Trim();
            string giaVonStr = textBoxGiaVon.Text.Trim();
            string giaBanStr = textBoxGiaBan.Text.Trim();
            string trongLuongStr = textBoxTrongLuong.Text.Trim();
            string tiLeLoiStr = textBoxTiLeLoiNhuan.Text.Trim();
            DateTime ngayHetHan = dateTimePickerNgayHetHan.Value;

            string maNhom = comboBoxNhomHang.SelectedValue?.ToString();
            string maLoai = comboBoxLoaiHang.SelectedValue?.ToString(); // nếu cần dùng
            string maHangSX = comboBoxHangSX.SelectedValue?.ToString();
            string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString();

            bool coGiaVon = decimal.TryParse(giaVonStr, out decimal giaVon);
            bool coGiaBan = decimal.TryParse(giaBanStr, out decimal giaBan);
            bool coTiLeLoi = decimal.TryParse(tiLeLoiStr, out decimal tiLeLoi);
            bool coTrongLuong = decimal.TryParse(trongLuongStr, out decimal trongLuong);
            bool coDonViTinh = !string.IsNullOrEmpty(maDonViTinh);

            // ----------- KIỂM TRA ĐIỀU KIỆN TRƯỚC KHI LƯU ------------
            if (string.IsNullOrEmpty(maHH) || string.IsNullOrEmpty(tenHH) )
            {
                MessageBox.Show("Mã hàng hóa, tên hàng hóa  không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(maNhom))
            {
                MessageBox.Show("Bạn phải chọn nhóm hàng hóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!coDonViTinh)
            {
                MessageBox.Show("Bạn phải chọn đơn vị tính .", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((coGiaVon || coGiaBan || coTiLeLoi) && !coDonViTinh)
            {
                MessageBox.Show("Bạn phải chọn đơn vị tính khi nhập giá vốn, giá bán hoặc tỷ lệ lợi nhuận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (coTiLeLoi && !coGiaVon)
            {
                MessageBox.Show("Phải có giá vốn khi nhập tỷ lệ lợi nhuận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            CSDL csdl = new CSDL();
            using (SqlConnection conn = csdl.GetConnection())
            {
                try
                {
                    conn.Open();

                    // Copy ảnh nếu có
                    if (!string.IsNullOrEmpty(duongDanAnhTam) && File.Exists(duongDanAnhTam))
                    {
                        string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa"; // cập nhật đúng đường dẫn thực tế
                        string duongDanLuu = Path.Combine(thuMucAnh, tenAnhLuu);
                        File.Copy(duongDanAnhTam, duongDanLuu, true);
                    }

                    // Kiểm tra tồn tại mã hàng hóa
                    string checkQuery = "SELECT COUNT(*) FROM HANG_HOA WHERE MA_HANG_HOA = @maHH";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@maHH", maHH);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            // Cập nhật hàng hóa
                            StringBuilder updateHH = new StringBuilder();
                            updateHH.AppendLine("UPDATE HANG_HOA SET");
                            updateHH.AppendLine(" TEN_HANG_HOA = @tenHH,");
                            updateHH.AppendLine(" TEN_VIET_TAT = @tenVT,");
                            updateHH.AppendLine(" MA_THUOC = @maThuoc,");
                            updateHH.AppendLine(" SO_DANG_KY_THUOC = @soDK,");
                            updateHH.AppendLine(" HOAT_CHAT = @hoatChat,");
                            updateHH.AppendLine(" HAM_LUONG = @hamLuong,");
                            updateHH.AppendLine(" DUONG_DUNG_CHO_THUOC = @duongDung,");
                            updateHH.AppendLine(" QUY_CACH_DONG_GOI = @quyCach,");
                            updateHH.AppendLine(" GHI_CHU_HH = @ghiChu,");
                            updateHH.AppendLine(" MA_NHOM_HH = @maNhom,");
                            updateHH.AppendLine(" MA_VACH = @maVach,");
                            updateHH.AppendLine(" NGAY_HET_HAN_HH = @ngayHetHan,");
                            updateHH.AppendLine(" MA_HANG_SX = @maHangSX,");
                            updateHH.AppendLine(" TRONG_LUONG_HH = @trongLuong");
                            if (!string.IsNullOrEmpty(tenAnhLuu))
                                updateHH.AppendLine(", HINH_ANH_HH = @tenAnh");
                            updateHH.AppendLine(" WHERE MA_HANG_HOA = @maHH;");

                            using (SqlCommand cmdUpdateHH = new SqlCommand(updateHH.ToString(), conn))
                            {
                                cmdUpdateHH.Parameters.AddWithValue("@tenHH", tenHH);
                                cmdUpdateHH.Parameters.AddWithValue("@tenVT", tenVietTat);
                                cmdUpdateHH.Parameters.AddWithValue("@maThuoc", maThuoc);
                                cmdUpdateHH.Parameters.AddWithValue("@soDK", soDangKy);
                                cmdUpdateHH.Parameters.AddWithValue("@hoatChat", hoatChat);
                                cmdUpdateHH.Parameters.AddWithValue("@hamLuong", hamLuong);
                                cmdUpdateHH.Parameters.AddWithValue("@duongDung", duongDung);
                                cmdUpdateHH.Parameters.AddWithValue("@quyCach", quyCach);
                                cmdUpdateHH.Parameters.AddWithValue("@ghiChu", ghiChu);
                                cmdUpdateHH.Parameters.AddWithValue("@maNhom", (object)maNhom ?? DBNull.Value);
                                cmdUpdateHH.Parameters.AddWithValue("@maVach", maVach);
                                cmdUpdateHH.Parameters.AddWithValue("@ngayHetHan", ngayHetHan);
                                cmdUpdateHH.Parameters.AddWithValue("@maHangSX", (object)maHangSX ?? DBNull.Value);
                                cmdUpdateHH.Parameters.AddWithValue("@trongLuong", trongLuongStr);
                                if (!string.IsNullOrEmpty(tenAnhLuu))
                                    cmdUpdateHH.Parameters.AddWithValue("@tenAnh", tenAnhLuu);
                                cmdUpdateHH.Parameters.AddWithValue("@maHH", maHH);

                                cmdUpdateHH.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // Thêm mới hàng hóa
                            string insertHH = @"
INSERT INTO HANG_HOA (MA_HANG_HOA, TEN_HANG_HOA, TEN_VIET_TAT, MA_THUOC, SO_DANG_KY_THUOC, HOAT_CHAT, HAM_LUONG,
    DUONG_DUNG_CHO_THUOC, QUY_CACH_DONG_GOI, GHI_CHU_HH, MA_NHOM_HH, MA_VACH, NGAY_HET_HAN_HH, MA_HANG_SX, TRONG_LUONG_HH, HINH_ANH_HH)
VALUES (@maHH, @tenHH, @tenVT, @maThuoc, @soDK, @hoatChat, @hamLuong, @duongDung, @quyCach,
    @ghiChu, @maNhom, @maVach, @ngayHetHan, @maHangSX, @trongLuong, @tenAnh)";

                            using (SqlCommand cmdInsertHH = new SqlCommand(insertHH, conn))
                            {
                                cmdInsertHH.Parameters.AddWithValue("@maHH", maHH);
                                cmdInsertHH.Parameters.AddWithValue("@tenHH", tenHH);
                                cmdInsertHH.Parameters.AddWithValue("@tenVT", tenVietTat);
                                cmdInsertHH.Parameters.AddWithValue("@maThuoc", maThuoc);
                                cmdInsertHH.Parameters.AddWithValue("@soDK", soDangKy);
                                cmdInsertHH.Parameters.AddWithValue("@hoatChat", hoatChat);
                                cmdInsertHH.Parameters.AddWithValue("@hamLuong", hamLuong);
                                cmdInsertHH.Parameters.AddWithValue("@duongDung", duongDung);
                                cmdInsertHH.Parameters.AddWithValue("@quyCach", quyCach);
                                cmdInsertHH.Parameters.AddWithValue("@ghiChu", ghiChu);
                                cmdInsertHH.Parameters.AddWithValue("@maNhom", (object)maNhom ?? DBNull.Value);
                                cmdInsertHH.Parameters.AddWithValue("@maVach", maVach);
                                cmdInsertHH.Parameters.AddWithValue("@ngayHetHan", ngayHetHan);
                                cmdInsertHH.Parameters.AddWithValue("@maHangSX", (object)maHangSX ?? DBNull.Value);
                                cmdInsertHH.Parameters.AddWithValue("@trongLuong", trongLuongStr);
                                cmdInsertHH.Parameters.AddWithValue("@tenAnh", string.IsNullOrEmpty(tenAnhLuu) ? DBNull.Value : (object)tenAnhLuu);

                                cmdInsertHH.ExecuteNonQuery();
                            }
                        }
                    }

                    // Cập nhật hoặc thêm giá
                    string checkGiaQuery = "SELECT COUNT(*) FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH";
                    using (SqlCommand checkGiaCmd = new SqlCommand(checkGiaQuery, conn))
                    {
                        checkGiaCmd.Parameters.AddWithValue("@maHH", maHH);
                        int countGia = (int)checkGiaCmd.ExecuteScalar();

                        if (countGia > 0)
                        {
                            string updateGia = @"
UPDATE GIA_HANG_HOA SET
    GIA_VON_HH = @giaVon,
    GIA_BAN_HH = @giaBan,
    TI_LE_LOI = @tiLeLoi,
    MA_DON_VI_TINH = @maDVT
WHERE MA_HANG_HOA = @maHH";

                            using (SqlCommand cmdUpdateGia = new SqlCommand(updateGia, conn))
                            {
                                cmdUpdateGia.Parameters.AddWithValue("@giaVon", coGiaVon ? giaVon : 0);
                                cmdUpdateGia.Parameters.AddWithValue("@giaBan", coGiaBan ? giaBan : 0);
                                cmdUpdateGia.Parameters.AddWithValue("@tiLeLoi", coTiLeLoi ? tiLeLoi : 0);
                                cmdUpdateGia.Parameters.AddWithValue("@maDVT", coDonViTinh ? (object)maDonViTinh : DBNull.Value);
                                cmdUpdateGia.Parameters.AddWithValue("@maHH", maHH);

                                cmdUpdateGia.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            string insertGia = @"
INSERT INTO GIA_HANG_HOA (MA_HANG_HOA, GIA_VON_HH, GIA_BAN_HH, MA_DON_VI_TINH, TI_LE_LOI)
VALUES (@maHH, @giaVon, @giaBan, @maDVT, @tiLeLoi)";

                            using (SqlCommand cmdInsertGia = new SqlCommand(insertGia, conn))
                            {
                                cmdInsertGia.Parameters.AddWithValue("@maHH", maHH);
                                cmdInsertGia.Parameters.AddWithValue("@giaVon", coGiaVon ? giaVon : 0);
                                cmdInsertGia.Parameters.AddWithValue("@giaBan", coGiaBan ? giaBan : 0);
                                cmdInsertGia.Parameters.AddWithValue("@maDVT", coDonViTinh ? (object)maDonViTinh : DBNull.Value);
                                cmdInsertGia.Parameters.AddWithValue("@tiLeLoi", coTiLeLoi ? tiLeLoi : 0);

                                cmdInsertGia.ExecuteNonQuery();
                            }
                        }
                    }

                    MessageBox.Show("Lưu thông tin hàng hóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    formChiTietThuoc?.LoadData();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu thông tin thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }










        private FormChiTietThuoc formChiTietThuoc;

        public FormCapNhatThuoc(string maHangHoa, FormChiTietThuoc formChiTietThuoc = null)
        {
            InitializeComponent();
            this.formChiTietThuoc = formChiTietThuoc;
            // Load dữ liệu vào form
            LoadDataToForm(maHangHoa);
        }












    }
}
