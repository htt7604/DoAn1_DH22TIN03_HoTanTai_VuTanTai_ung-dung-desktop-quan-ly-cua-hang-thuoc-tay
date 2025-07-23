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

namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class UserControlNhaCungCap : UserControl
    {
        public UserControlNhaCungCap()
        {
            InitializeComponent();
        }
        public void setdata(ClassNhaCungCap nhaCungCap)
        {
            labelTenNCC.Text=nhaCungCap.TenNhaCungCap;
            labelSDT.Text = nhaCungCap.DienThoai;

        }
    }
}
