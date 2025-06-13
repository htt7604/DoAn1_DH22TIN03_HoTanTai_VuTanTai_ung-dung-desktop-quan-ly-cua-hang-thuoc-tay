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
    public partial class FormThemThuoc : Form
    {
        public FormThemThuoc(string loai)
        {
            InitializeComponent();
        }

        //load comboBoxDonViTinh
        private void LoadComboBoxDonViTinh()
        {
            try
            {
                using (SqlConnection conn = new CSDL().GetConnection())
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
                        comboBoxDonViTinh.SelectedIndex = -1;
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
                        comboBoxLoaiHang.SelectedValue = 'T';
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
                            comboBoxNhomHang.SelectedIndex = -1;
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
                using (SqlConnection conn = new CSDL().GetConnection())
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
                        comboBoxHangSanXuat.SelectedIndex = -1;
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
        private void FormThemThuoc_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxLoaiHanghoa();
            LoadComboBoxDonViTinh();
            LoadComboBoxHangSanXuat();
        }

        public string MaHangSXThem { get; set; }
        private void textBoxTenThuoc_TextChanged(object sender, EventArgs e)
        {
            //them cac usercontrolitemthemthuoc vao flowlayoutpanelListThuoc
            string keyword = textBoxTenThuoc.Text.Trim();

            // Xóa hết các item cũ trước khi hiển thị cái mới
            flowLayoutPanelListThuoc.Controls.Clear();

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
                    MaHangSXThem = selectedThuoc.MaHangSanXuat; // Lưu mã nhà sản xuất để sử dụng sau này



                    flowLayoutPanelListThuoc.Visible = false; // Ẩn danh sách sau khi chọn

                };
            }
            flowLayoutPanelListThuoc.Visible = danhSach.Count > 0; // Hiển thị flowLayoutPanel nếu có kết quả
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //kiem tra xem đã nhập đủ thông tin chưa
            if (textBoxTenHH.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Vui lòng them thuoc.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            if (comboBoxNhomHang.SelectedIndex == -1 || comboBoxNhomHang.Text == null)
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBoxDonViTinh.SelectedIndex == -1 || comboBoxDonViTinh.Text == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrWhiteSpace(comboBoxHangSanXuat.Text))
            {
                MessageBox.Show("Vui lòng chọn nhà sản xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string mahh = ClassHangHoa.TaoMaHangHoaTuDong(); // Tạo mã hàng hóa tự động
                ClassHangHoa thuoc = new ClassHangHoa
                {
                    MaHangHoa = mahh,
                    MaThuoc = textBoxMaThuoc.Text.Trim(),
                    TenHangHoa = textBoxTenThuoc.Text.Trim(),
                    SoDangKy = textBoxSoDangKy.Text.Trim(),
                    HoatChatChinh = textBoxHoatChat.Text.Trim(),
                    HamLuong = textBoxHamLuong.Text.Trim(),
                    QuyCachDongGoi = textBoxQuyCachDongGoi.Text.Trim(),
                    MaHangSX = MaHangSXThem,
                    MaDonViTinh = comboBoxDonViTinh.SelectedValue.ToString(),
                    MaNhomHang = comboBoxNhomHang.SelectedValue.ToString()
                };
                //them thuoc vao csdl

                bool kq = ClassHangHoa.ThemThuocMoi(thuoc);
                //luu hang hoa vao csdl
                try
                {
                    if (kq)
                    {
                        //them gia ban hang hoa
                        ClassGiaBanHH gia = new ClassGiaBanHH
                        {
                            MaHangHoa = mahh,
                            MaDonViTinh = comboBoxDonViTinh.SelectedValue.ToString(),
                            GiaVon = 0, // Giá vốn có thể để 0 hoặc nhập từ người dùng
                            GiaBan = 0 // Giá bán có thể để 0 hoặc nhập từ người dùng
                        };
                        if (ClassGiaBanHH.ThemGiaBan(gia))
                        {
                            MessageBox.Show("Thêm thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi thêm thành công
                            return;
                        }
                    }
                    else
                    {
                        //in loi neu them khong thanh cong
                        MessageBox.Show("Không thể thêm thuốc. Vui lòng kiểm tra lại thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm thuốc: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
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
            textBoxTenHH.Clear(); // Xóa tên hàng hóa nếu có
        }





    }
}
