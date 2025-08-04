using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;


namespace QL_Nha_thuoc.BanHang
{
    public partial class FormQRThanhToan : Form
    {
        public FormQRThanhToan(string bankCode, string soTaiKhoan, string tenChuTaiKhoan, decimal soTien)
        {
            InitializeComponent();


            string url = $"https://img.vietqr.io/image/{bankCode}-{soTaiKhoan}-compact2.png?amount={soTien}&addInfo=ThanhToan&accountName={Uri.EscapeDataString(tenChuTaiKhoan)}";

            using (HttpClient client = new HttpClient())
            {
                var imageBytes = client.GetByteArrayAsync(url).Result;
                using (var ms = new MemoryStream(imageBytes))
                {
                    pictureBoxQR.Image = Image.FromStream(ms);
                }
            }
        }

        private Image qrImageToPrint;
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (qrImageToPrint != null)
            {
                // Giới hạn chiều rộng/chiều cao ảnh để không vượt quá vùng in
                int maxWidth = e.MarginBounds.Width;
                int maxHeight = e.MarginBounds.Height;

                // Tính tỉ lệ thu phóng để ảnh vừa trong khung in
                float scale = Math.Min((float)maxWidth / qrImageToPrint.Width, (float)maxHeight / qrImageToPrint.Height);
                int printWidth = (int)(qrImageToPrint.Width * scale);
                int printHeight = (int)(qrImageToPrint.Height * scale);

                // Căn giữa trong vùng margin
                int x = e.MarginBounds.Left + (e.MarginBounds.Width - printWidth) / 2;
                int y = e.MarginBounds.Top + (e.MarginBounds.Height - printHeight) / 2;

                e.Graphics.DrawImage(qrImageToPrint, x, y, printWidth, printHeight);
            }
        }


        private void buttonIn_Click(object sender, EventArgs e)
        {
            if (pictureBoxQR.Image == null)
            {
                MessageBox.Show("Không có ảnh QR để in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            qrImageToPrint = pictureBoxQR.Image;

            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Pd_PrintPage;

            PrintPreviewDialog previewDialog = new PrintPreviewDialog
            {
                Document = pd,
                Width = 800,
                Height = 600,
                StartPosition = FormStartPosition.CenterScreen
            };

            try
            {
                previewDialog.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị bản xem trước: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
