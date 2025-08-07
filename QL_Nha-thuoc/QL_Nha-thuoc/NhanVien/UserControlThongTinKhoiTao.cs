using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.NhanVien
{
    public partial class UserControlThongTinKhoiTao : UserControl
    {
        private TabPage targetTabPage;
        private FormThemNhanVien parentForm;

        public UserControlThongTinKhoiTao(TabPage tabPage, FormThemNhanVien form)
        {
            InitializeComponent();
            this.targetTabPage = tabPage;
            this.parentForm = form;
        }


        private UserControlThongTinThem userControlThem;
        private int originalFormHeight = -1; // lưu chiều cao gốc

        private void buttonHienThiThem_Click(object sender, EventArgs e)
        {
            if (userControlThem == null)
            {
                // Lần đầu tiên tạo control
                userControlThem = new UserControlThongTinThem();
                userControlThem.Dock = DockStyle.Bottom;
                targetTabPage.Controls.Add(userControlThem);
                userControlThem.Visible = false; // ban đầu ẩn
            }

            // Lưu chiều cao gốc nếu chưa lưu
            if (originalFormHeight == -1)
            {
                originalFormHeight = parentForm.Height;
            }

            // Toggle hiển thị
            if (!userControlThem.Visible)
            {
                userControlThem.Visible = true;

                // Giãn form theo chiều cao màn hình
                Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
                parentForm.Location = new Point(parentForm.Location.X, workingArea.Top);
                parentForm.Height = workingArea.Height;
            }
            else
            {
                userControlThem.Visible = false;

                // Thu form lại về kích thước ban đầu
                parentForm.Height = originalFormHeight;
            }
        }






    }

}
