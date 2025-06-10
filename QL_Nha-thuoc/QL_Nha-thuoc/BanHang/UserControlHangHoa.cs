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
    public partial class UserControlHangHoa : UserControl
    {
        public UserControlHangHoa()
        {
            InitializeComponent();

        }

        public event EventHandler? SoLuongHoacGiaThayDoi;
        public event EventHandler? XoaYeuCau;

        public NumericUpDown SoLuongControl => numericUpDown1;
        public decimal SoLuongTon { get; set; }


        //set du lieu cho control
        public void SetData(string tenThuoc, string mah, float giaBan)
        {
            textBoxTenHang.Text = tenThuoc;
            labelMaHangHoa.Text = mah;
            textBoxGiaBan.Text = giaBan.ToString("N0");
        }


        //thay doi so luong va gia ban
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SoLuongHoacGiaThayDoi?.Invoke(this, EventArgs.Empty);
        }
        private void textBoxGiaBan_TextChanged(object sender, EventArgs e)
        {
            SoLuongHoacGiaThayDoi?.Invoke(this, EventArgs.Empty);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            XoaYeuCau?.Invoke(this, EventArgs.Empty); // Gửi yêu cầu xóa đến control cha
        }



        //truyen gia tri 
        public decimal GiaBan
        {
            get
            {
                decimal.TryParse(textBoxGiaBan.Text.Replace(",", ""), out decimal giaBan);
                return giaBan;
            }
            set
            {
                textBoxGiaBan.Text = value.ToString("N0");
            }
        }


        public int SoLuong
        {
            get => (int)numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }




    }
}
