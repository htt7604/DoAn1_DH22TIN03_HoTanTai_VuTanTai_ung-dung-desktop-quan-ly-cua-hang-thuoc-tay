using QL_Nha_thuoc.model;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlThanhToanChuyenKhoan : UserControl
    {
        public string _maHoaDon;
        public UserControlThanhToanChuyenKhoan(Panel panelChonTaiKhoan,string maHD)
        {
            InitializeComponent();
            _panelChonTaiKhoan = panelChonTaiKhoan;
            LoadThongTinChuyenKhoan();
            _maHoaDon = maHD;

        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MaTaiKhoanNganHangDangChon
        {
            get
            {
                var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoanTheoSTK(labelSoTaiKhoan.Text);
                return taiKhoan?.MaTaiKhoanNH;
            }
        }


        //lấy panel 
        private Panel _panelChonTaiKhoan;


        private void LoadThongTinChuyenKhoan()
        {
            var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoan();//lay tai khoan dau tien 
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản ngân hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenChuTK = taiKhoan.TenChuTK;
            string soTK = taiKhoan.SoTaiKhoan;
            string tenNH = taiKhoan.TenNganHang;
            string noiDung = "Thanh toan don thuoc";

            labelTenNganHang.Text = tenNH;
            labelTenChuTaiKhoan.Text = tenChuTK;
            labelSoTaiKhoan.Text = soTK;
            labelSoTien.Text = "0 VND";

            string url = TaoUrlQRCode(tenNH, soTK, tenChuTK, 0, noiDung, compact: true);
            HienThiQRCode(url);
        }

        public decimal _soTien;
        public void CapNhatQRCode(decimal soTien)
        {
            _soTien = soTien;
            var taiKhoan = ClassTaiKhoanNganHang.LayTaiKhoan();
            if (taiKhoan == null)
            {
                MessageBox.Show("Không tìm thấy tài khoản ngân hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string tenChuTK = taiKhoan.TenChuTK;
            string soTK = taiKhoan.SoTaiKhoan;
            string tenNH = taiKhoan.TenNganHang;
            string noiDung = $"Thanh toan hoa don " +_maHoaDon ;

            labelTenNganHang.Text = tenNH;
            labelTenChuTaiKhoan.Text = tenChuTK;
            labelSoTaiKhoan.Text = soTK;
            labelSoTien.Text = $"{soTien:#,##0} VND";

            string url = TaoUrlQRCode(tenNH, soTK, tenChuTK, soTien, noiDung, compact: false);
            HienThiQRCode(url);
        }



        public event Action<string> QRCodeUrlChanged;

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



        public string QRCodeUrl { get; private set; }

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



                    QRCodeUrl = url;
                    QRCodeUrlChanged?.Invoke(url);
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

        private void buttonChonTK_Click(object sender, EventArgs e)
        {
            var danhSach = ClassTaiKhoanNganHang.LayDanhSachTaiKhoan();
            var formChon = new FormChonTaiKhoanNganHang(danhSach);

            formChon.TaiKhoanDuocChon += (s, taiKhoan) =>
            {
                labelTenNganHang.Text = taiKhoan.TenNganHang;
                labelTenChuTaiKhoan.Text = taiKhoan.TenChuTK;
                labelSoTaiKhoan.Text = taiKhoan.SoTaiKhoan;
                labelSoTien.Text = _soTien.ToString();

                string noiDung = "Thanh toan don thuoc";
                string url = TaoUrlQRCode(taiKhoan.TenNganHang, taiKhoan.SoTaiKhoan, taiKhoan.TenChuTK, _soTien, noiDung, compact: true);
                HienThiQRCode(url);
            };

            formChon.ShowDialog(); // mở form chọn tài khoản
        }






























        //private void HienThiDanhSachTaiKhoan()
        //{
        //    panelTaiKhoanNganHang.Visible = true;
        //    flowLayoutPanelDSTaiKhoangNganHang.Controls.Clear();
        //    flowLayoutPanelDSTaiKhoangNganHang.FlowDirection = FlowDirection.TopDown;
        //    flowLayoutPanelDSTaiKhoangNganHang.WrapContents = false;
        //    flowLayoutPanelDSTaiKhoangNganHang.AutoScroll = true;

        //    var danhSach = ClassTaiKhoanNganHang.LayDanhSachTaiKhoan();

        //    foreach (var tk in danhSach)
        //    {
        //        var item = new UserControlitemtkNganHang();
        //        item.Setdata(tk);

        //        // Gắn sự kiện: khi chọn tài khoản → cập nhật thông tin & QR
        //        item.TaiKhoanDuocChon += (s, taiKhoan) =>
        //        {
        //            labelTenChuTaiKhoan.Text = taiKhoan.TenChuTK;
        //            labelSoTaiKhoan.Text = taiKhoan.SoTaiKhoan;
        //            labelSoTien.Text = "0 VND";

        //            string noiDung = "Thanh toan don thuoc";
        //            string url = TaoUrlQRCode(taiKhoan.TenNganHang, taiKhoan.SoTaiKhoan, taiKhoan.TenChuTK, 0, noiDung, compact: true);
        //            HienThiQRCode(url);

        //            panelTaiKhoanNganHang.Visible = false;
        //        };

        //        // Kích thước phù hợp với flow layout
        //        item.Margin = new Padding(5);
        //        item.Width = flowLayoutPanelDSTaiKhoangNganHang.ClientSize.Width - 25; // trừ scroll bar nếu có

        //        flowLayoutPanelDSTaiKhoangNganHang.Controls.Add(item);
        //    }
        //}
    }
}
