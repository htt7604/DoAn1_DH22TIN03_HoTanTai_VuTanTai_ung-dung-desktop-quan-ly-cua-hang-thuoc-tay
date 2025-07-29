using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.DangNhap
{
    public partial class FormXacThucEmail : Form
    {
        private string _tenTaiKhoan;
        public string _trangthai;
        private string _email;
        private string _maOTP;
        private int _thoiGianConLai = 180; // 3 phút = 180 giây
        private System.Windows.Forms.Timer _timer;

        public FormXacThucEmail(ClassTaiKhoan classTaiKhoan, string trangthai)
        {
            InitializeComponent();
            _tenTaiKhoan = classTaiKhoan.TenTaiKhoan;
            _trangthai = trangthai;
        }

        private void buttonXacNhan_Click(object sender, EventArgs e)
        {
            string maNhap = textBoxMaXacThuc.Text.Trim();
            if (maNhap == _maOTP)
            {
                // Cập nhật trạng thái đã xác thực email trong DB
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    string query = "UPDATE TAI_KHOAN SET DA_XAC_THUC_EMAIL = 1 WHERE TEN_TAI_KHOAN = @TK";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TK", _tenTaiKhoan);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                // Kiểm tra trạng thái và thực hiện theo mục đích
                if (_trangthai == "quenmatkhau")
                {
                    this.Hide(); // Ẩn form xác thực
                    var formDatLai = new FormTaoMatKhau(_tenTaiKhoan); // Giả sử bạn có form này
                    formDatLai.ShowDialog();
                    this.Close(); // Đóng form sau khi đặt lại xong
                }
                else // Nếu là đăng nhập
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Mã xác thực không đúng!", "Lỗi");
            }
        }


        private string TaoMaOTP()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString(); // mã 6 số
        }
        private void GuiEmail(string toEmail, string otp)
        {
            string fromEmail = _email;        // Thay bằng email của bạn
            string appPassword = "cqrj erhj imrp eqdh";         // Thay bằng app password (16 ký tự)

            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(fromEmail);
                    mail.To.Add(toEmail);
                    mail.Subject = "Mã xác thực OTP từ hệ thống quản lý nhà thuốc";
                    mail.Body = $"Xin chào,\n\nMã xác thực của bạn là: {otp}\n\nMã có hiệu lực trong 3 phút.\n\nTrân trọng!";
                    mail.IsBodyHtml = false;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential(fromEmail, appPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi email thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void BatDauDemNguoc()
        {
            _thoiGianConLai = 10;
            labelHieuLuc.LinkBehavior = LinkBehavior.NeverUnderline;
            labelHieuLuc.LinkColor = Color.Black;
            labelHieuLuc.Text = $"Thời gian còn lại: 03:00";
            labelHieuLuc.Enabled = false; // Không click được khi đang đếm

            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 1000; // mỗi giây
            _timer.Tick += (s, e) =>
            {
                _thoiGianConLai--;
                TimeSpan ts = TimeSpan.FromSeconds(_thoiGianConLai);
                labelHieuLuc.Text = $"Thời gian còn lại: {ts.Minutes:D2}:{ts.Seconds:D2}";

                if (_thoiGianConLai <= 0)
                {
                    _timer.Stop();
                    labelHieuLuc.Text = "Gửi lại mã xác thực";
                    labelHieuLuc.LinkColor = Color.Blue;
                    labelHieuLuc.Enabled = true;
                }
            };
            _timer.Start();
        }


        private string AnEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
                return "********";

            var parts = email.Split('@');
            string ten = parts[0];
            string domain = parts[1];

            if (ten.Length <= 6)
                return new string('*', ten.Length) + "@" + domain;

            string dau = ten.Substring(0, 5); // 5 ký tự đầu
            string cuoi = ten.Substring(ten.Length - 3); // 3 ký tự cuối

            return $"{dau}.....{cuoi}@{domain}";
        }


        private void FormXacThucEmail_Load(object sender, EventArgs e)
        {
            labelTenTaiKhoan.Text = _tenTaiKhoan;

            // Lấy email từ DB
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT NV.EMAIL FROM NHAN_VIEN NV JOIN TAI_KHOAN TK ON TK.MA_NV = NV.MA_NV WHERE TK.TEN_TAI_KHOAN = @TK";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TK", _tenTaiKhoan);
                conn.Open();
                var result = cmd.ExecuteScalar();
                _email = result?.ToString();
            }

            labelThongTin.Text = $"Mã xác thực đã gửi tới: {AnEmail(_email)}";

            // Tạo và gửi mã OTP
            _maOTP = TaoMaOTP();
            GuiEmail(_email, _maOTP);

            // Bắt đầu đếm ngược
            BatDauDemNguoc();
        }

        private void labelHieuLuc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_thoiGianConLai > 0) return; // Không làm gì nếu vẫn còn thời gian

            // Tạo mã mới và gửi lại
            _maOTP = TaoMaOTP();
            GuiEmail(_email, _maOTP);

            // Khởi động lại đếm ngược
            BatDauDemNguoc();
        }


    }
}
