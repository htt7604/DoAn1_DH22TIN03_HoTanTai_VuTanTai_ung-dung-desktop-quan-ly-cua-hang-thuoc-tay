using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormGiamGiaHHHoaDonPopup : Form
    {
        //tao du kien khi co thay doi gia tri
        public event EventHandler? CoSuThayDoiGiaBan;
        //khai bao bien nhan gia ban tu form usecontrolhanghoa

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal DonGia
        {
            get
            {
                if (decimal.TryParse(textBoxDonGia.Text, out decimal donGia))
                    return donGia;
                return 0m;
            }
            set
            {
                textBoxDonGia.Text = value.ToString("N0");
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal GiaBan
        {
            get
            {
                if (decimal.TryParse(textBoxGiaBan.Text, out decimal giaBan))
                    return giaBan;
                return 0m;
            }
            set
            {
                textBoxGiaBan.Text = value.ToString("N0");
            }
        }


        public string loaiDangChon;
        private bool isUpdating = false;

        public FormGiamGiaHHHoaDonPopup()
        {
            InitializeComponent();
            this.Load += FormGiamGiaHHHoaDonPopup_Load;

            textBoxDonGia.TextChanged += Input_TextChanged;
            textBoxGiamGia.TextChanged += Input_TextChanged;
            textBoxGiaBan.TextChanged += GiaBan_TextChanged;
            //mac dinh chon VND
            buttonVND.BackColor = Color.LightGreen;
        }

        private void FormGiamGiaHHHoaDonPopup_Load(object sender, EventArgs e)
        {
            SetLoaiGiam(loaiDangChon);
        }


        private void SetLoaiGiam(string loai)
        {
            if (loai == loaiDangChon) return;

            decimal donGia = 0m;
            decimal giamGia = 0m;

            bool canConvert = decimal.TryParse(textBoxDonGia.Text, out donGia)
                           && decimal.TryParse(textBoxGiamGia.Text, out giamGia)
                           && donGia > 0;

            if (canConvert)
            {
                if (loai == "%")
                {
                    // VND → %
                    giamGia = (giamGia / donGia) * 100m;
                    loaiDangChon = loai;
                }
                else
                {
                    // % → VND
                    giamGia = donGia * (giamGia / 100m);
                    loaiDangChon = loai;
                }

                textBoxGiamGia.Text = giamGia.ToString("0.##");

                UpdateGiaBan();

            }

            loaiDangChon = loai;

            buttonVND.BackColor = (loai == "VND") ? Color.LightGreen : SystemColors.Control;
            buttonPhanTram.BackColor = (loai == "%") ? Color.LightGreen : SystemColors.Control;
        }






        private void buttonPhanTram_Click(object sender, EventArgs e)
        {
            SetLoaiGiam("%");
        }

        private void buttonVND_Click(object sender, EventArgs e)
        {
            SetLoaiGiam("VND");

        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
            if (isUpdating) return;
            isUpdating = true;

            // Nếu người dùng đang nhập giá bán trực tiếp, thì clear 2 ô còn lại
            if (sender == textBoxGiaBan && textBoxGiaBan.Focused)
            {
                textBoxDonGia.Text = "0";
                textBoxGiamGia.Text = "0";
                isUpdating = false;
                return;
            }

            UpdateGiaBan();
            isUpdating = false;
        }

        private void GiaBan_TextChanged(object sender, EventArgs e)
        {
            CoSuThayDoiGiaBan?.Invoke(this, EventArgs.Empty); // Gọi sự kiện khi có thay đổi
            if (isUpdating) return;
            if (textBoxGiaBan.Focused)
            {
                isUpdating = true;
                textBoxDonGia.Text = "0";
                textBoxGiamGia.Text = "0";
                isUpdating = false;
            }
        }

        private void UpdateGiaBan()
        {
            if (!decimal.TryParse(textBoxDonGia.Text, out decimal donGia))
            {
                textBoxGiaBan.Text = "0";
                textBoxGiamGia.Text = "0";
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxGiamGia.Text))
            {
                textBoxGiaBan.Text = donGia.ToString("N0");
                return;
            }

            if (!decimal.TryParse(textBoxGiamGia.Text, out decimal giamGia))
            {
                textBoxGiaBan.Text = donGia.ToString("N0");
                return;
            }

            decimal giaBan = 0;
            if (loaiDangChon == "VND")
                giaBan = donGia - giamGia;
            else // %
                giaBan = donGia * (1 - giamGia / 100m);

            if (giaBan < 0) giaBan = 0;
            textBoxGiaBan.Text = giaBan.ToString("N0");
        }

        //tao su kien khi dong form truyen ra ngoai
        public event EventHandler? FormDong;

        //khai bao bien su dung de truyen giam gia ra ngoai
        public string chuoihienthi;
        //khai bao su kien dong form
        private void FormGiamGiaHHHoaDonPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxGiamGia.Text) && !string.IsNullOrWhiteSpace(textBoxGiaBan.Text))
            {
                decimal giamGia = 0;
                if (decimal.TryParse(textBoxGiamGia.Text, out giamGia))
                {
                    if (loaiDangChon == "%")
                    {
                        chuoihienthi = "-" + giamGia.ToString("0.##") + "%";
                    }
                    else // VND
                    {
                        chuoihienthi = "-" + giamGia.ToString("N0");
                    }
                }
            }

            FormDong?.Invoke(this, EventArgs.Empty); // Gửi sự kiện khi đóng form (bất kể có giảm giá hay không)
        }






        //bien luu gia tri giam gia sau khi tinh toan
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal GiaTriGiamGia
        {
            get
            {
                if (decimal.TryParse(textBoxGiamGia.Text, out decimal val))
                    return val;
                return 0m;
            }
            set
            {
                textBoxGiamGia.Text = value.ToString("0.##");
            }
        }





    }
}
