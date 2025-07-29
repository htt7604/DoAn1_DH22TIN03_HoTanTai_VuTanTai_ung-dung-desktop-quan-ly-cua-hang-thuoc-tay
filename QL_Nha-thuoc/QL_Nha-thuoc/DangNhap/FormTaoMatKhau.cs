using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.model;
using System;
using System.Windows.Forms;

namespace QL_Nha_thuoc.DangNhap
{
    public partial class FormTaoMatKhau : Form
    {
        private string _tenTaiKhoan;

        public FormTaoMatKhau(string tenTaiKhoan)
        {
            InitializeComponent();
            _tenTaiKhoan = tenTaiKhoan;
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            string mkMoi = textBoxMatKhauMoi.Text.Trim();
            string mkNhapLai = textBoxNhapLai.Text.Trim();

            if (string.IsNullOrEmpty(mkMoi) || string.IsNullOrEmpty(mkNhapLai))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            if (mkMoi != mkNhapLai)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi");
                return;
            }

            // Cập nhật mật khẩu trong DB
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "UPDATE TAI_KHOAN SET MAT_KHAU = @MK WHERE TEN_TAI_KHOAN = @TK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MK", BaoMatHelper.BamMatKhau(mkMoi)); // Có thể mã hóa nếu cần
                cmd.Parameters.AddWithValue("@TK", _tenTaiKhoan);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông báo");
            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
