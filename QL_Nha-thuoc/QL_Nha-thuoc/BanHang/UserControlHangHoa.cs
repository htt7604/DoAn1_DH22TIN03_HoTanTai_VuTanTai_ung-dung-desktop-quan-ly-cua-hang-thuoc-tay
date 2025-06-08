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

        public void SetData(string tenThuoc, string mah)
        {
            labelTenHang.Text = tenThuoc;
            labelMaHangHoa.Text = mah;       
        }




    }
}
