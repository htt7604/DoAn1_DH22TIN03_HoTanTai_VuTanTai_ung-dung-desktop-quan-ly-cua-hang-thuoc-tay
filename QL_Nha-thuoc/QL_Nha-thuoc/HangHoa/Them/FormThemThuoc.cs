using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.Them;
using QL_Nha_thuoc.model;
using QL_Nha_thuoc.Usercontrol;
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
    public partial class FormThemThuoc : Form
    {

        private ICoTheReload _formChaInterface;
        private Action _onReloadCallback;

        public FormThemThuoc(string loai, ICoTheReload formCha)
        {
            InitializeComponent();
            this.Text = "Thêm " + loai;
            _formChaInterface = formCha;
            this.FormClosed += FormThemThuoc_FormClosed;
        }

        public FormThemThuoc(string loai, Action onReload)
        {
            InitializeComponent();
            this.Text = "Thêm " + loai;
            _onReloadCallback = onReload;
            this.FormClosed += FormThemThuoc_FormClosed;
        }
        private void FormThemThuoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formChaInterface?.ReloadSauKhiThayDoi();
            _onReloadCallback?.Invoke();
        }



        //load comboBoxDonViTinh
        private void LoadComboBoxDonViTinh()
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MA_DON_VI_TINH,TEN_DON_VI_TINH FROM DON_VI_TINH";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxDonViTinh.DataSource = table;
                        comboBoxDonViTinh.DisplayMember = "TEN_DON_VI_TINH";
                        comboBoxDonViTinh.ValueMember = "MA_DON_VI_TINH";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load don vi tinh: " + ex.Message);
            }
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
                        }
                    }
                }
            }
        }

        //laod comboxboxhangsanxuat
        private void LoadComboBoxHangSanXuat()
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MA_HANG_SX, TEN_HANG_SX FROM HANG_SAN_XUAT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxHangSanXuat.DataSource = table;
                        comboBoxHangSanXuat.DisplayMember = "TEN_HANG_SX";
                        comboBoxHangSanXuat.ValueMember = "MA_HANG_SX";

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhà sản xuất: " + ex.Message);
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
        private void LoadComboBoxDuongDung()
        {
            DataTable dt = ClassDuongDungThuoc.LayDanhSachDuongDung();
            ComboBoxHelper.EnableComboBoxFiltering(comboBoxDuongDung, dt, "TEN_DUONG_DUNG", "MA_DUONG_DUNG");

            comboBoxDuongDung.DataSource = dt;
            comboBoxDuongDung.DisplayMember = "TEN_DUONG_DUNG";
            comboBoxDuongDung.ValueMember = "MA_DUONG_DUNG";

            // Đừng đặt SelectedIndex = -1 ở đây nữa.
        }

        private void FormThemThuoc_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxLoaiHanghoa();
            LoadComboBoxDonViTinh();
            LoadComboBoxHangSanXuat();
            LoadComboBoxDuongDung();
            textBoxMaHH.Text = ClassHangHoa.TaoMaHangHoaTuDong(); // Tạo mã hàng hóa tự động khi mở form
            textBoxGiaBan.Text = "0"; // Mặc định giá bán là 0
            textBoxGiaVon.Text = "0"; // Mặc định giá vốn là 0
            comboBoxDuongDung.SelectedIndex = -1; // Đặt giá trị mặc định cho đường dùng là không chọn gì
            comboBoxHangSanXuat.SelectedIndex = -1;
            comboBoxDonViTinh.SelectedIndex = -1; // Đặt giá trị mặc định cho đơn vị tính là không chọn gì
            comboBoxNhomHang.SelectedIndex = -1; // Đặt giá trị mặc định cho nhóm hàng là không chọn gì
            comboBoxLoaiHang.SelectedValue = 'T';
            comboBoxDonViTinh.SelectedIndex = -1;
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string MaHangSXThem { get; set; }



        // Xử lý sự kiện khi người dùng nhập vào TextBox tên thuốc
        public string _TenVietTat;
        private void textBoxTenThuoc_TextChanged(object sender, EventArgs e)
        {

            //them cac usercontrolitemthemthuoc vao flowlayoutpanelListThuoc
            string keyword = textBoxTenThuoc.Text.Trim();

            // Xóa hết các item cũ trước khi hiển thị cái mới
            flowLayoutPanelListThuoc.Controls.Clear();
            //add usercontrolthuoctinhitemthemthuoc vao flowlayoutpanelListThuoc
            flowLayoutPanelListThuoc.Controls.Add(new Usercontrolthuoctinhitemthemthuoc());
            // Lấy danh sách thuốc theo từ khóa
            List<ClassThuoc> danhSach = ClassThuoc.LayDanhSachThuoc(keyword);

            // Duyệt từng thuốc và tạo UserControl hiển thị
            foreach (var thuoc in danhSach)
            {
                var item = new UserControlItemThuoc();
                item.SetValues(thuoc); // Gán dữ liệu thuốc vào usercontrol
                flowLayoutPanelListThuoc.Controls.Add(item);

                // Khi click vào UserControl, điền dữ liệu vào các TextBox trong form
                item.ThuocDuocChon += (s, selectedThuoc) =>
                {
                    textBoxMaThuoc.Text = selectedThuoc.MaThuoc;
                    textBoxTenThuoc.Text = selectedThuoc.TenThuoc;
                    textBoxSoDangKy.Text = selectedThuoc.SoDangKy;
                    textBoxHoatChat.Text = selectedThuoc.HoatChatChinh;
                    textBoxHamLuong.Text = selectedThuoc.HamLuong;
                    textBoxQuyCachDongGoi.Text = selectedThuoc.QuyCachDongGoi;
                    comboBoxHangSanXuat.SelectedValue = selectedThuoc.MaHangSanXuat;
                    comboBoxDonViTinh.SelectedValue = selectedThuoc.MaDonViTinh;
                    MaHangSXThem = selectedThuoc.MaHangSanXuat;
                    _TenVietTat = selectedThuoc.TenVietTat; // Lưu tên viết tắt nếu cần


                    flowLayoutPanelListThuoc.Visible = false; // Ẩn danh sách sau khi chọn

                };
            }
            flowLayoutPanelListThuoc.Visible = danhSach.Count > 0; // Hiển thị flowLayoutPanel nếu có kết quả
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra đầu vào
            if (comboBoxNhomHang.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comboBoxDonViTinh.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBoxHangSanXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxTenThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên thuốc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra và chuyển đổi số liệu giá bán - giá vốn
            decimal giaBan = 0, giaVon = 0;
            if (!decimal.TryParse(textBoxGiaBan.Text.Trim(), out giaBan) || giaBan < 0)
            {
                MessageBox.Show("Giá bán không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(textBoxGiaVon.Text.Trim(), out giaVon) || giaVon < 0)
            {
                MessageBox.Show("Giá vốn không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Tạo thuốc mới
            string mahh = ClassThuoc.TaoMaHangHoaTuDong(); // Tạo mã hàng hóa tự động
            ClassThuoc thuoc = new ClassThuoc
            {
                MaHangHoa = mahh,
                MaThuoc = textBoxMaThuoc.Text.Trim(),              
                TenThuoc = textBoxTenThuoc.Text.Trim(), // sẽ dùng làm TEN_HANG_HOA
                TenVietTat = _TenVietTat, // Lưu tên viết tắt nếu cần
                HinhAnh = _duongDanAnh,
                SoDangKy = textBoxSoDangKy.Text.Trim(),
                HoatChatChinh = textBoxHoatChat.Text.Trim(),
                HamLuong = textBoxHamLuong.Text.Trim(),
                QuyCachDongGoi = textBoxQuyCachDongGoi.Text.Trim(),
                MaDuongDung = comboBoxDuongDung.SelectedValue.ToString(), // Giả sử bạn có combobox này
                MaHangSanXuat = MaHangSXThem,
                MaNhomHang = comboBoxNhomHang.SelectedValue.ToString(),
                GiaBan = giaBan,
                GiaVon = giaVon,
                GhiChu = textBoxGhiChu.Text.Trim(),
                MaVach = textBoxMaVach.Text.Trim(),
                TinhTrang= "Đang kinh doanh", // Mặc định là còn hàng
                MaDonViTinh=comboBoxDonViTinh.SelectedValue.ToString()
            };

            // 4. Gọi hàm thêm thuốc vào CSDL
            bool kq = ClassThuoc.ThemThuocMoi(thuoc);

            // 5. Thông báo kết quả
            if (kq)
            {
                // Tạo mã phiếu kiểm kho mới và thêm vào CSDL
                string makiemkho = ClassPhieuKiemKho.SinhMaPhieuMoi();

                ClassPhieuKiemKho phieuKiemKho = new ClassPhieuKiemKho
                {
                    MaPhieuKiemKho = makiemkho,
                    NgayKiemKho = DateTime.Now,
                    MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien,
                    GhiChu = "Cập nhật tồn kho hàng hóa khi thêm hàng hóa",
                    TrangThaiPhieuKiem = "Đã cân bằng kho"
                };
                ClassPhieuKiemKho.ThemPhieuKiemKho(phieuKiemKho);

                ClassChiTietPhieuKiemKho chiTietPhieuKiemKho = new ClassChiTietPhieuKiemKho
                {
                    MaPhieuKiemKho = makiemkho,
                    MaHangHoa = mahh,
                    TenHangHoa = thuoc.TenThuoc,
                    SoLuongHeThong = 0,
                    SoLuongThucTe = 0,
                };
                ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTietPhieuKiemKho);

                MessageBox.Show("Tạo phiếu kiểm kho với mã: " + makiemkho, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Thêm thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            else
            {
                MessageBox.Show("Không thể thêm thuốc. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void buttonXoaTT_Click(object sender, EventArgs e)
        {
            //xoa thông tin trong các TextBox và ComboBox
            textBoxMaThuoc.Clear();
            textBoxTenThuoc.Clear();
            textBoxSoDangKy.Clear();
            textBoxHoatChat.Clear();
            textBoxHamLuong.Clear();
            textBoxQuyCachDongGoi.Clear();
            comboBoxHangSanXuat.SelectedIndex = -1;
            comboBoxDonViTinh.SelectedIndex = -1;
            comboBoxNhomHang.SelectedIndex = -1;
            flowLayoutPanelListThuoc.Visible = false; // Ẩn danh sách thuốc
            textBoxTenThuoc.Clear(); // Xóa tên hàng hóa nếu có
        }

        private void buttonThemNhomHang_Click(object sender, EventArgs e)
        {
            //moform them nhom hang
            FormThemNhomHangHoa formThemNhomHang = new FormThemNhomHangHoa();
            formThemNhomHang.ShowDialog(); // Hiển thị form ThemNhomHangHoa
            formThemNhomHang.FormClosed += (s, args) =>
            {
                // Sau khi form ThemNhomHang đóng, load lại dữ liệu nhóm hàng
                LoadDataToComboBoxNhomHanghoa();
            };
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            //dong form
            this.Close();

        }
        private string _duongDanAnh = null;

        private void buttonThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    // Giải phóng ảnh cũ nếu có
                    if (pictureBoxHangHoa.Image != null)
                    {
                        pictureBoxHangHoa.Image.Dispose();
                        pictureBoxHangHoa.Image = null;
                    }

                    // Load ảnh an toàn bằng MemoryStream
                    using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        byte[] imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);

                        using (MemoryStream ms = new MemoryStream(imageData))
                        {
                            pictureBoxHangHoa.Image = Image.FromStream(ms);
                        }
                    }

                    _duongDanAnh = filePath; // Lưu đường dẫn ảnh
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể tải ảnh. Lỗi: " + ex.Message, "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonThemDuongDung_Click(object sender, EventArgs e)
        {
            FormThemDuongDung formThemDuongDung = new FormThemDuongDung();

            if (formThemDuongDung.ShowDialog() == DialogResult.OK)
            {
                string maMoi = formThemDuongDung.MaDuongDungMoi;

                LoadComboBoxDuongDung();

                if (!string.IsNullOrEmpty(maMoi))
                {
                    comboBoxDuongDung.SelectedValue = maMoi;
                }
            }
        }



    }
}
