using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.model;
using System;
using System.Windows.Forms;

namespace QL_Nha_thuoc.DangNhap
{
    public partial class FormLogin : Form
    {
        // Sự kiện để thông báo khi form đăng nhập đã đóng
        public event Action FormDaDong;
        public string trangthai = "login"; // Biến để xác định trạng thái khi mở form xác thực email
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

            var taiKhoan = ClassTaiKhoan.LayTaiKhoan(tenTK);
            if (taiKhoan == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string matKhauDaBam = BaoMatHelper.BamMatKhau(matKhau);
            if (taiKhoan.MatKhau != matKhauDaBam)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo");
                return;
            }

            // Kiểm tra vai trò
            if (taiKhoan.VaiTro != vaiTroYeuCau)
            {
                MessageBox.Show("Bạn không có quyền truy cập với vai trò này.", "Thông báo");
                return;
            }

            // Xác thực email nếu chưa xác thực
            if (!taiKhoan.DaXacThucEmail)
            {
                MessageBox.Show("Tài khoản chưa xác thực email. Vui lòng xác thực trước khi tiếp tục.", "Thông báo");
                var formXacThuc = new FormXacThucEmail(taiKhoan, "xacminhdangnhap");
                formXacThuc.ShowDialog();

                taiKhoan = ClassTaiKhoan.LayTaiKhoan(tenTK); // reload lại
                if (!taiKhoan.DaXacThucEmail)
                {
                    MessageBox.Show("Bạn chưa hoàn tất xác thực email!", "Thông báo");
                    return;
                }
            }

            // Bắt buộc đổi mật khẩu nếu là lần đầu
            if (taiKhoan.LanDauDangNhap)
            {
                //thog báo và mở form tạo mật khẩu mới
                MessageBox.Show("Đây là lần đầu bạn đăng nhập. Vui lòng tạo mật khẩu mới.", "Thông báo");
                var formTaoMK = new FormTaoMatKhau(tenTK);
                var result = formTaoMK.ShowDialog();
                if (result != DialogResult.OK)
                    return;

                using (var conn = CSDL.GetConnection())
                {
                    var cmd = new SqlCommand("UPDATE TAI_KHOAN SET LAN_DAU_DANG_NHAP = 0 WHERE TEN_TAI_KHOAN = @TK", conn);
                    cmd.Parameters.AddWithValue("@TK", tenTK);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            // Lưu phiên
            Session.TaiKhoanDangNhap = taiKhoan;

            MessageBox.Show("Đăng nhập thành công!", "Thông báo");
            this.Hide(); // Ẩn login form, không đóng

            Form frm;
            if (vaiTroYeuCau == "Quản lý")
                frm = new FormMain();
            else
                frm = new FormBanHangMain();

            frm.FormClosed += (s, args) => this.Show(); // Khi form chính đóng, hiển thị lại login
            frm.Show();

        }



        private void checkBoxHienThiMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            textBoxMatKhau.UseSystemPasswordChar = !textBoxMatKhau.UseSystemPasswordChar;
        }

        private void linkLabelQuenMatKhai_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            trangthai = "quenmatkhau"; // Đặt trạng thái để xác định khi mở form xác thực email
            //kiem tra co ten tai khoan hay khong 
            string tenTaiKhoan = textBoxTenDangNhap.Text.Trim();
            if (string.IsNullOrEmpty(tenTaiKhoan))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập trước khi lấy lại mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Lấy thông tin tài khoản
            var taiKhoan = ClassTaiKhoan.LayTaiKhoan(tenTaiKhoan);
            if (taiKhoan == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //mo form xac thuc email
            FormXacThucEmail formXacThuc = new FormXacThucEmail(taiKhoan,trangthai);
            formXacThuc.ShowDialog();

        }



    }
}
