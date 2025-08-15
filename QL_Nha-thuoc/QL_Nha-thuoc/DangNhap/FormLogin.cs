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

        private FormMain formMainInstance; // biến thành viên trong FormLogin
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
            // **Thêm kiểm tra trạng thái nghỉ việc ở đây**
            // Kiểm tra trạng thái nghỉ việc
            string trangthainv =ClassNhanVien.LayNhanVienTheoMa(taiKhoan.MaNhanVien).TrangThai;
            if (trangthainv != null && trangthainv.Equals("Đã nghỉ", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tài khoản này đã nghỉ việc, không được phép đăng nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string matKhauDaBam = BaoMatHelper.BamMatKhau(matKhau);
            if (taiKhoan.MatKhau != matKhauDaBam)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Thông báo");
                return;
            }

            // Kiểm tra vai trò và quyền truy cập theo nút nhấn
            if (taiKhoan.VaiTro == "Quản lý")
            {
                // Nếu vai trò quản lý:
                // - Nút quản lý thì mở form quản lý
                // - Nút bán hàng thì mở form bán hàng
                // Không giới hạn gì
            }
            else if (taiKhoan.VaiTro == "Bán hàng")
            {
                if (vaiTroYeuCau != "Bán hàng")
                {
                    MessageBox.Show("Bạn không có quyền truy cập vai trò này.", "Thông báo");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn không có quyền truy cập vai trò này.", "Thông báo");
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
            this.Hide();

            Form frm;

            if (taiKhoan.VaiTro == "Quản lý")
            {
                // Tạo formMain 1 lần duy nhất
                formMainInstance = new FormMain();

                if (vaiTroYeuCau == "Quản lý")
                {
                    frm = formMainInstance;
                }
                else // vaiTroYeuCau == "Bán hàng"
                {
                    // Truyền formMainInstance vào FormBanHangMain
                    frm = new FormBanHangMain(formMainInstance);
                }
            }
            else
            {
                // Vai trò là bán hàng thì chỉ có thể vào bán hàng
                frm = new FormBanHangMain(null); // Không có formMain truyền vào
            }

            //frm.FormClosed += (s, args) => this.Show();
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
