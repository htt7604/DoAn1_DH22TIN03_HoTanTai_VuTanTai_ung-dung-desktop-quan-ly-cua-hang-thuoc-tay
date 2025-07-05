using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Nha_thuoc.model;

namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlKhachHangitem : UserControl
    {
        public UserControlKhachHangitem()
        {
            InitializeComponent();
        }





        public void Setdata(ClassKhachHang khachHang)
        {
            if (khachHang == null)
            {
                labelTenKachHang.Text = "Chưa có khách hàng";
                labelMaKhachHang.Text = string.Empty;
                return;
            }
            else
            {
                labelTenKachHang.Text = khachHang.ThongTinDayDu;
                labelMaKhachHang.Text = khachHang.MaKH.ToString();
            }
        }
    }
}
