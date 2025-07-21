using System;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class FormGiamGiaPopup : Form
    {
        public event EventHandler<GiamGiaEventArgs> GiamGiaDaChon;

        private string loaiDangChon = "VND"; // Mặc định

        private decimal donGiaHH; // Giá trị đơn giá để tính giảm giá
        public FormGiamGiaPopup(decimal donGia, string giaTriMacDinh)
        {
            InitializeComponent();
            textBoxGiaTri.Text = giaTriMacDinh;
            SetLoaiGiam(loaiDangChon);
            donGiaHH = donGia;
            // Chặn nhập ký tự không hợp lệ
            textBoxGiaTri.KeyPress += TextBoxGiaTri_KeyPress;

        }

        private void SetLoaiGiam(string loai)
        {
            loaiDangChon = loai;

            if (loai == "VND")
            {
                buttonVND.BackColor = Color.LightGreen;
                buttonPhanTram.BackColor = SystemColors.Control;
            }
            else if (loai == "%")
            {
                buttonPhanTram.BackColor = Color.LightGreen;
                buttonVND.BackColor = SystemColors.Control;
            }
        }


        //ham chuyen doi giam gia
        private decimal ChuyenDoiGiaTriGiamGia(decimal giaTriHienTai, decimal donGia, string loaiGiamHienTai)
        {
            if (donGia <= 0) return 0;

            if (loaiGiamHienTai == "VND")
            {
                // Chuyển từ VND sang %
                return giaTriHienTai * 100 / donGia;
            }
            else if (loaiGiamHienTai == "%")
            {
                // Chuyển từ % sang VND
                return donGia * giaTriHienTai / 100;
            }

            return 0;
        }
        private void buttonPhanTram_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxGiaTri.Text, out var giaTriHienTai))
            {
                var phanTram = ChuyenDoiGiaTriGiamGia(giaTriHienTai, donGiaHH, "VND");
                SetLoaiGiam("%");
                textBoxGiaTri.Text = phanTram.ToString("N2");
            }
        }


        private void buttonVND_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxGiaTri.Text, out var giaTriHienTai))
            {
                var tienGiam = ChuyenDoiGiaTriGiamGia(giaTriHienTai, donGiaHH, "%");
                SetLoaiGiam("VND");
                textBoxGiaTri.Text = tienGiam.ToString("N0");
            }
        }


        private void TextBoxGiaTri_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số, dấu chấm và các phím điều khiển
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // Không cho nhập nhiều dấu chấm
            if (e.KeyChar == '.' && textBoxGiaTri.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void textBoxGiaTri_TextChanged(object sender, EventArgs e)
        {
            // Gửi sự kiện mỗi khi giá trị thay đổi
            GiamGiaDaChon?.Invoke(this, new GiamGiaEventArgs
            {
                LoaiGiam = loaiDangChon,
                GiaTri = decimal.TryParse(textBoxGiaTri.Text, out var g) ? g : 0
            });
        }



    }

    public class GiamGiaEventArgs : EventArgs
    {
        public string LoaiGiam { get; set; }
        public decimal GiaTri { get; set; }
    }
}
