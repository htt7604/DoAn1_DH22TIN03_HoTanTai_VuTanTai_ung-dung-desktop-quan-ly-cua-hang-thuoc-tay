using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormGiamGia : Form
    {
        //bien truyền ra 
        public string LoaiGiamGia => loaigiamgia;

        public FormGiamGia()
        {
            InitializeComponent();
            buttonVND.BackColor = Color.LightGreen;
            buttonPhanTram.BackColor = SystemColors.Control;
        }
        public event EventHandler CoSuThayDoiGiamGia;
        
        private string loaigiamgia="VND";

        //bien nhan tong tien hang
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal tongTienHang { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //bieen luu gia tri nhap 
        public decimal GiaTriNhapGiamGia
        {
            get
            {
                if (decimal.TryParse(textBoxGiaTriGiamGiaTongHang.Text, out decimal giamGia))
                    return giamGia;
                return 0m;
            }
            set
            {
                textBoxGiaTriGiamGiaTongHang.Text = value.ToString("N0");
            }
        }

        //ham tinh so tien giam gia
        public decimal TinhSoTienGiamGia()
        {
            if (loaigiamgia == "VND")
            {
                return GiaTriNhapGiamGia; // Giam gia la so tien
            }
            else if (loaigiamgia == "%")
            {
                return tongTienHang * GiaTriNhapGiamGia / 100; // Giam gia la phan tram
            }
            return 0m;
        }



        private void buttonVND_Click(object sender, EventArgs e)
        {
            //khi cick. neu khong phai VND 
            if (loaigiamgia != "VND")
            {
                // Đổi từ % → VND
                if (decimal.TryParse(textBoxGiaTriGiamGiaTongHang.Text, out decimal giamGiaPercent))
                {
                    // Tính lại số tiền
                    decimal tienGiam = tongTienHang * giamGiaPercent / 100;
                    textBoxGiaTriGiamGiaTongHang.Text = tienGiam.ToString("N0");
                }

                loaigiamgia = "VND";
                buttonVND.BackColor = Color.LightGreen;
                buttonPhanTram.BackColor = SystemColors.Control;
            }
            //neu la VND
            else
            {
                TinhSoTienGiamGia();
            }
            CoSuThayDoiGiamGia?.Invoke(this, EventArgs.Empty);
        }

        private void buttonPhanTram_Click(object sender, EventArgs e)
        {
            if (loaigiamgia != "%")
            {
                // Đổi từ VND → %
                if (decimal.TryParse(textBoxGiaTriGiamGiaTongHang.Text, out decimal giamGiaTien) && tongTienHang > 0)
                {
                    decimal giamGiaPhanTram = giamGiaTien * 100 / tongTienHang;
                    textBoxGiaTriGiamGiaTongHang.Text = giamGiaPhanTram.ToString("0.##");
                }

                loaigiamgia = "%";
                buttonPhanTram.BackColor = Color.LightGreen;
                buttonVND.BackColor = SystemColors.Control;
            }
            else
            {
                TinhSoTienGiamGia();
            }
            CoSuThayDoiGiamGia?.Invoke(this, EventArgs.Empty);
        }



        private void textBoxGiaTriGiamGiaTongHang_TextChanged(object sender, EventArgs e)
        {
            //goi ham de truyen gia tri giam gia ra form cha
            CoSuThayDoiGiamGia?.Invoke(this, EventArgs.Empty);
            //tinh giam gia theo VND
            TinhSoTienGiamGia();
            //neu la % thi khong nhap qua 100%
            //neus laf VND thi khong nhap qua tongTienHang 
        }



    }
}
