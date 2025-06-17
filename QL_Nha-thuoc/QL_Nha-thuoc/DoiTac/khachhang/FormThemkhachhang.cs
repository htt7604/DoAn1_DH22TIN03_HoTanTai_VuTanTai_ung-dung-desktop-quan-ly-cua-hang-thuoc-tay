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

namespace QL_Nha_thuoc.DoiTac.khachhang
{
    public partial class FormThem_Suakhachhang : Form
    {
        public ClassKhachHang khachhang = new ClassKhachHang();
        public FormThem_Suakhachhang()
        {
            InitializeComponent();
        }

        private void FormThem_Suakhachhang_Load(object sender, EventArgs e)
        {
            radioButtonCaNhan.Checked = true;
            radioButtonNam.Checked = true;
        }

        //ham kiem tra thong tin nhap vao
        private bool KiemTraThongTinNhapVao()
        {
            if (string.IsNullOrWhiteSpace(textBoxTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //kiem tra thong tin nhap vao
            if (!KiemTraThongTinNhapVao())
            {
                return;
            }
            //luu thong tin khach hang
            khachhang.MaKH = ClassKhachHang.TaoMaKhachHangTuDong();
            khachhang.TenKH = textBoxTenKH.Text.Trim();
            khachhang.SDT = textBoxDienThoai.Text.Trim();
            khachhang.DiaChiKH = textBoxDiaChi.Text.Trim();
            khachhang.Email = textBoxEmail.Text.Trim();
            khachhang.GhiChu = textBoxGhiChu.Text.Trim();
            khachhang.NgayTaoKH = DateTime.Now; // Ngày tạo mặc định là ngày hiện tại
            khachhang.nguoiTao = Session.TaiKhoanDangNhap.TenNhanVien; // Người tạo là người đăng nhập hiện tại
            khachhang.MaNV = Session.TaiKhoanDangNhap.MaNhanVien; // Mã nhân viên là mã của người đăng nhập hiện tại
            khachhang.TrangThaiKH = "Đang hoạt động";
            khachhang.HinhAnhKh = hinhAnhKhachHang; // Lưu đường dẫn ảnh nếu có
            khachhang.SoCCCD_CMND = textBoxCCCD.Text.Trim();
            khachhang.NgaySinh = dateTimePickerNgaySinh.Checked ? dateTimePickerNgaySinh.Value : (DateTime?)null;
            if (radioButtonCaNhan.Checked)
            {
                khachhang.MaNhomKH = "CN";
            }
            else if (radioButtonCongTy.Checked)
            {
                khachhang.TenCongTy=textBoxTenCongTy.Text.Trim();
                khachhang.MaNhomKH = "TC";
            }
            if (radioButtonNam.Checked)
            {
                khachhang.GioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                khachhang.GioiTinh = "Nữ";
            }

            bool luukh = ClassKhachHang.ThemKhachHang(khachhang);
            if (luukh)
            {
                MessageBox.Show("Lưu thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Đặt kết quả của hộp thoại là OK
                this.Close(); // Đóng hộp thoại
            }
            else
            {
                MessageBox.Show("Lưu thông tin khách hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //dong form va cap nhat lai danh sach khach hang
            this.DialogResult = DialogResult.OK; // Đặt kết quả của hộp thoại là OK
            this.Close(); // Đóng hộp thoại
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đặt kết quả của hộp thoại là Cancel
            this.Close();
        }

        private void textBoxDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép phím số và phím điều khiển (backspace, delete,...)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private string hinhAnhKhachHang = ""; // Biến lưu chuỗi đường dẫn ảnh

        private void buttonThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh khách hàng";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                try
                {
                    using (var originalImage = Image.FromFile(path))
                    {
                        // Resize ảnh vừa khung pictureBox
                        Image resized = new Bitmap(originalImage, pictureBoxKhachHang.Width, pictureBoxKhachHang.Height);
                        pictureBoxKhachHang.Image = resized;
                        pictureBoxKhachHang.SizeMode = PictureBoxSizeMode.Zoom;

                        // Gán chuỗi đường dẫn
                        hinhAnhKhachHang = path;
                        textBoxCHinh.Text = Path.GetFileName(path);
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Tệp không phải ảnh hợp lệ hoặc quá lớn.", "Lỗi bộ nhớ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void radioButtonCongTy_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTenCongTy.Enabled = radioButtonCongTy.Checked;
        }
    }
}
