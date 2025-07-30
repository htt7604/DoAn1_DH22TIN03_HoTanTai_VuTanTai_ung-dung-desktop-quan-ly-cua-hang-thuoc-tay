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
        public FormGiamGia()
        {
            InitializeComponent();
        }
        public event EventHandler CoSuThayDoiGiamGia;
        
        private string loaigiamgia="VND";

        //bien nhan tong tien hang
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal tongTienHang { get; set; }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal GiaTriGiamGiaTongHang
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

        private void buttonVND_Click(object sender, EventArgs e)
        {
            //set loai giam gia la VND
            if (loaigiamgia != "VND")
            {
                loaigiamgia = "VND";
                buttonVND.BackColor = Color.LightGreen;
                buttonPhanTram.BackColor = SystemColors.Control;
            }
            else
            {
                TinhGiamGia(tongTienHang, GiaTriGiamGiaTongHang);
            }
        }

        private void buttonPhanTram_Click(object sender, EventArgs e)
        {
            //set loai giam gia la %
            if (loaigiamgia != "%")
            {
                loaigiamgia = "%";
                buttonPhanTram.BackColor = Color.LightGreen;
                buttonVND.BackColor = SystemColors.Control;
            }
            else
            {
                TinhGiamGia(tongTienHang, GiaTriGiamGiaTongHang);
            }
        }

        //ham tinh giam gia
        private decimal TinhGiamGia(decimal tongTienHang, decimal giamGia)
        {
            if (loaigiamgia == "VND")
            {
                return giamGia; // Giam gia la so tien
            }
            else if (loaigiamgia == "%")
            {
                return tongTienHang * giamGia / 100; // Giam gia la phan tram
            }
            return 0m;
        }
        private void textBoxGiaTriGiamGiaTongHang_TextChanged(object sender, EventArgs e)
        {
            //goi ham de truyen gia tri giam gia ra form cha
            CoSuThayDoiGiamGia?.Invoke(this, EventArgs.Empty);    
            TinhGiamGia(tongTienHang, GiaTriGiamGiaTongHang);
        }



    }
}
