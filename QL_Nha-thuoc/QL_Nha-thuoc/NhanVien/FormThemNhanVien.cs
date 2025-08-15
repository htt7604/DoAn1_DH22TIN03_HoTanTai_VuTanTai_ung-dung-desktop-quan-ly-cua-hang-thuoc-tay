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
using System.Text.RegularExpressions;
namespace QL_Nha_thuoc.NhanVien
{
    public partial class FormThemNhanVien : Form
    {
        public FormThemNhanVien()
        {
            InitializeComponent();
        }

        private void FormThemNhanVien_Load(object sender, EventArgs e)
        {
            // Tạo mã nhân viên tự động
            textBoxMaNhanVien.Text = model.ClassNhanVien.TaoMaNhanVienTuDong();
            // Thiết lập ngày sinh mặc định là ngày hiện tại
            dateTimePickerNgaySinh.Value = DateTime.Now;
            dateTimePickerNgayBatDauLamViec.Value = DateTime.Now;
            // Thiết lập giới tính mặc định là "Nam"
            radioButtonNam.Checked = true;
            radioButtonNu.Checked = false;
            // Thiết lập trạng thái mặc định là "Đang làm việc"
        }

        // Biến lưu đường dẫn ảnh nhân viên
        private string duongDanHinhAnh;

        private void buttonThemHinhAnh_Click(object sender, EventArgs e)
        {
            // Sự kiện thêm hình ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Chọn hình ảnh nhân viên"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Hiển thị hình ảnh trong PictureBox
                    pictureBoxHinhAnhNhanVien.Image = new Bitmap(openFileDialog.FileName);

                    // Lưu đường dẫn ảnh vào biến
                    duongDanHinhAnh = openFileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể hiển thị hình ảnh: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTenNhanVien.Text))
            {
                MessageBox.Show("Vui lòng điền tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrWhiteSpace(textBoxEmail.Text))
{
                MessageBox.Show("Vui lòng điền email.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Regex chuẩn RFC 5322 (đơn giản hóa nhưng đủ bao quát hầu hết trường hợp hợp lệ)
            string email = textBoxEmail.Text.Trim();
            string pattern = @"^(?:[a-zA-Z0-9_'^&amp;/+-])+(?:\.(?:[a-zA-Z0-9_'^&amp;/+-])+)*@" +
                             @"(?:[a-zA-Z0-9-]+\.)+[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(email, pattern))
            {
                MessageBox.Show("Email không hợp lệ. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //neu khong co ten tai khoan thi thong
            if (string.IsNullOrWhiteSpace(textBoxTenTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng điền tên tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClassNhanVien nv = new ClassNhanVien
            {
                MaNhanVien = textBoxMaNhanVien.Text,
                HoTenNhanVien = textBoxTenNhanVien.Text,
                DiaChi = textBoxDiaChi.Text,
                SoDienThoai = textBoxSoDienThoai.Text,
                SoCCCD = textBoxSoCCCD.Text,
                NgaySinh = dateTimePickerNgaySinh.Value,
                GioiTinh = radioButtonNam.Checked ? "Nam" : "Nữ",
                TrangThai = "Đang làm việc",
                NgayBatDauLamViec = dateTimePickerNgayBatDauLamViec.Value,
                HinhAnh = duongDanHinhAnh, // lưu đường dẫn ảnh
                Email = textBoxEmail.Text,
                Facebook = textBoxFacebook.Text
            };


            if (ClassNhanVien.ThemNhanVien(nv))
            {
                //neu mat khau khong trung nhau
                if (textBoxMatKhau.Text != textBoxNhapLaiMatKhau.Text)
                {
                    MessageBox.Show("Mật khẩu không khớp. Vui lòng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //neu khong co mat khau thi mat khau mac dinh la tai khoan dang nhap
                if (string.IsNullOrWhiteSpace(textBoxMatKhau.Text))
                {
                    textBoxMatKhau.Text = textBoxTenTaiKhoan.Text; // Mật khẩu mặc định
                    //thong bao mat khau mac dinh la "tên tài khoản"
                    MessageBox.Show("Mật khẩu mặc định là tên tài khoản: " + textBoxTenTaiKhoan.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //them tai khoan vao 

                ClassTaiKhoan tk = new ClassTaiKhoan
                {
                    TenTaiKhoan = textBoxTenTaiKhoan.Text,
                    MatKhau = BaoMatHelper.BamMatKhau(textBoxMatKhau.Text),
                    MaNhanVien = nv.MaNhanVien,
                    VaiTro = "BH",
                    DaXacThucEmail = false,
                    LanDauDangNhap = true,
                };
                ClassTaiKhoan.ThemTaiKhoan(tk);

                MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void checkBoxMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn mật khẩu
            if (checkBoxMatKhau.Checked)
            {
                textBoxMatKhau.UseSystemPasswordChar = false; // Hiển thị mật khẩu
            }
            else
            {
                textBoxMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }

        private void checkBoxNhapLai_CheckedChanged(object sender, EventArgs e)
        {
            // Hiển thị hoặc ẩn mật khẩu nhập lại
            if (checkBoxNhapLai.Checked)
            {
                textBoxNhapLaiMatKhau.UseSystemPasswordChar = false; // Hiển thị mật khẩu
            }
            else
            {
                textBoxNhapLaiMatKhau.UseSystemPasswordChar = true; // Ẩn mật khẩu
            }
        }
    }
}
