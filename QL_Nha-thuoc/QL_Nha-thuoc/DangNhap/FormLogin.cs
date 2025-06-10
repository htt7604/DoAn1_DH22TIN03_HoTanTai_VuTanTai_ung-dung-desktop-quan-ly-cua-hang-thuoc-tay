using Microsoft.Data.SqlClient;
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

namespace QL_Nha_thuoc.DangNhap
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        public static bool KiemTraDangNhap(string tenTK, string matKhau)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM TAI_KHOAN WHERE TEN_TAI_KHOAN = @TK AND MAT_KHAU = @MK";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TK", tenTK);
                cmd.Parameters.AddWithValue("@MK", matKhau);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
        private void buttonDangNhap_Click(object sender, EventArgs e)
        {
            string tenTK = textBoxTenDangNhap.Text.Trim();
            string matKhau = textBoxMatKhau.Text.Trim();

            if (KiemTraDangNhap(tenTK, matKhau))
            {
                var taiKhoan = ClassTaiKhoan.LayTaiKhoan(tenTK);
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                FormMain formMain = new FormMain(taiKhoan);
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
