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
    public partial class UserControlFormHoaDon : UserControl
    {
        public UserControlFormHoaDon()
        {
            InitializeComponent();
        }
        public void ThemHang(string ten, string mah)
        {
            var item = new UserControlHangHoa();
            item.SetData(ten, mah);

            item.Width = flowLayoutPanelTTHH.ClientSize.Width - 20;
            item.Margin = new Padding(0, 5, 0, 0);
            flowLayoutPanelTTHH.Controls.Add(item);
        }



    }
}
