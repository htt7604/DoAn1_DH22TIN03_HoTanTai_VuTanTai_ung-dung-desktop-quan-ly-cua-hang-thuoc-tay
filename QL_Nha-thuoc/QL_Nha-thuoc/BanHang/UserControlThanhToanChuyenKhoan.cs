using QL_Nha_thuoc.model;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlThanhToanChuyenKhoan : UserControl
    {
        public UserControlThanhToanChuyenKhoan()
        {
            InitializeComponent();
            LoadThongTinChuyenKhoan();
        }

        private void LoadThongTinChuyenKhoan()
        {
            var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoan();
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản ngân hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenChuTK = taiKhoan.TenChuTK;
            string soTK = taiKhoan.SoTaiKhoan;
            string tenNH = taiKhoan.TenNganHang;
            string noiDung = "Thanh toan don thuoc";

            labelTenChuTaiKhoan.Text = tenChuTK;
            labelSoTaiKhoan.Text = soTK;
            labelSoTien.Text = "0 VND";

            string url = TaoUrlQRCode(tenNH, soTK, tenChuTK, 0, noiDung, compact: true);
            HienThiQRCode(url);
        }

        public void CapNhatQRCode(decimal soTien)
        {
            var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoan();
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản ngân hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenChuTK = taiKhoan.TenChuTK;
            string soTK = taiKhoan.SoTaiKhoan;
            string tenNH = taiKhoan.TenNganHang;
            string noiDung = $"Thanh toan hoa don {DateTime.Now:yyyyMMddHHmmss}";

            labelTenChuTaiKhoan.Text = tenChuTK;
            labelSoTaiKhoan.Text = soTK;
            labelSoTien.Text = $"{soTien:#,##0} VND";

            string url = TaoUrlQRCode(tenNH, soTK, tenChuTK, soTien, noiDung, compact: false);
            HienThiQRCode(url);
        }

        private string TaoUrlQRCode(string tenNH, string soTK, string tenChuTK, decimal soTien, string noiDung, bool compact)
        {
            string style = compact ? "compact" : "full";
            string url = $"https://img.vietqr.io/image/{tenNH.ToLower()}-{soTK}-{style}.png" +
                         $"?accountName={Uri.EscapeDataString(tenChuTK)}" +
                         $"&addInfo={Uri.EscapeDataString(noiDung)}";

            if (soTien > 0)
                url += $"&amount={soTien}";

            return url;
        }

        private void HienThiQRCode(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                using (WebResponse response = request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    pictureBoxQR.Image = Bitmap.FromStream(stream);
                    pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải mã QR: " + ex.Message);
            }
        }

        private void buttonHienQR_Click(object sender, EventArgs e)
        {
            var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoan();
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản ngân hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Lấy thông tin từ label hoặc biến đã lưu
            string bankCode = taiKhoan.TenNganHang.ToLower(); // cần đúng mã ngân hàng theo VietQR
            string soTaiKhoan = taiKhoan.SoTaiKhoan;
            string tenChuTK = taiKhoan.TenChuTK;

            // Lấy số tiền từ label (đã định dạng "100,000 VND") nên cần parse lại
            decimal soTien = 0;
            if (decimal.TryParse(labelSoTien.Text.Replace("VND", "").Trim().Replace(",", ""), out decimal parsedTien))
            {
                soTien = parsedTien;
            }

            // Mở form QR toàn màn hình
            FormQRThanhToan formQR = new FormQRThanhToan(bankCode, soTaiKhoan, tenChuTK, soTien);
            formQR.ShowDialog();
        }


        private void buttonChonTaiKhoanNH_Click(object sender, EventArgs e)
        {
            // TODO: Hiển thị danh sách tài khoản hoặc mở form chọn tài khoản
        }
    }
}
