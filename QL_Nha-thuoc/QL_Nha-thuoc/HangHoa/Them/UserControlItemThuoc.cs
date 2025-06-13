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
using static QL_Nha_thuoc.DanhMuc;

namespace QL_Nha_thuoc.HangHoa.Them
{
    public partial class UserControlItemThuoc : UserControl
    {
        private ClassThuoc _thuoc;
        // Sự kiện để báo cho form biết thuốc được chọn
        public event EventHandler<ClassThuoc> ThuocDuocChon;

        public UserControlItemThuoc()
        {
            InitializeComponent();

            // Gắn sự kiện cho chính control
            this.Click += UserControlItemThuoc_Click;

            // Gắn sự kiện cho tất cả các control con để đảm bảo click ở đâu cũng bắt được
            foreach (Control c in this.Controls)
            {
                c.Click += UserControlItemThuoc_Click;
                // Nếu control con có control con nữa, gắn đệ quy
                foreach (Control sub in c.Controls)
                {
                    sub.Click += UserControlItemThuoc_Click;
                }
            }
        }




        //ham set giá trị cho các thuộc tính của UserControlItemThemThuoc
        public void SetValues(ClassThuoc thuoc)
        {
            _thuoc = thuoc;
            labelTenThuoc.Text = thuoc.TenThuoc;
            labelSoDangKy.Text = thuoc.SoDangKy;
            labelHoatChat.Text = thuoc.HoatChatChinh;
            labelHamLuong.Text = thuoc.HamLuong;
            labelQuyCachDongGoi.Text = thuoc.QuyCachDongGoi;
            labelHangSanXuat.Text = thuoc.TenHangSanXuat;
        }

        private void UserControlItemThuoc_Click(object sender, EventArgs e)
        {
            ThuocDuocChon?.Invoke(this, _thuoc);
        }




    }
}
