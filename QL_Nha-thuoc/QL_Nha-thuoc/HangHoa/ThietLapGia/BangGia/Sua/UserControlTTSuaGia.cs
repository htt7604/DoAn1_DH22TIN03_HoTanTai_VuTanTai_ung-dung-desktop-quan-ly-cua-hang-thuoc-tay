using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa.ThietLapGia.BangGia
{
    public partial class UserControlTTSuaGia : UserControl
    {
        public UserControlTTSuaGia()
        {
            InitializeComponent();
        }
        public void Setdata(string tenBangGia)
        {
            labelTenBangGiaSua.Text = tenBangGia;
        }
    }
}
