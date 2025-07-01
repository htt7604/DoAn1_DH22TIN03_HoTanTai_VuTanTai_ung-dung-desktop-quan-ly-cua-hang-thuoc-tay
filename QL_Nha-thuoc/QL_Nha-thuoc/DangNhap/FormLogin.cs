using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.model;
using System;
using System.Windows.Forms;

namespace QL_Nha_thuoc.DangNhap
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonQuanLy.PerformClick(); // Mặc định Enter là quản lý
            }
        }

        private void buttonQuanLy_Click(object sender, EventArgs e)
        {
            DangNhapTheoVaiTro("Quản lý"); // vai trò đúng theo cột TEN_VAI_TRO trong bảng VAI_TRO
        }

        private void buttonBanHang_Click(object sender, EventArgs e)
        {
            DangNhapTheoVaiTro("Bán hàng"); // vai trò đúng theo cột TEN_VAI_TRO trong bảng VAI_TRO
        }

        private void DangNhapTheoVaiTro(string vaiTroYeuCau)
        {
            string tenTK = textBoxTenDangNhap.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();

            if (string.IsNullOrEmpty(tenTK) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy thông tin tài khoản từ database
            var taiKhoan = ClassTaiKhoan.LayTaiKhoan(tenTK);

            if (taiKhoan != null && taiKhoan.MatKhau == matKhau)
            {
                if (taiKhoan.VaiTro != vaiTroYeuCau)
                {
                    MessageBox.Show($"Tài khoản không có quyền truy cập với vai trò '{vaiTroYeuCau}'!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ✅ Lưu thông tin đăng nhập
                Session.TaiKhoanDangNhap = taiKhoan;

                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                FormMain formMain = new FormMain();
                formMain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
