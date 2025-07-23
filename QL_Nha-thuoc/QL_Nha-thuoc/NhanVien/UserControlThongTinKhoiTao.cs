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


        private void buttonHienThiThem_Click(object sender, EventArgs e)
        {
            UserControlThongTinThem userControl = new UserControlThongTinThem();
            userControl.Dock = DockStyle.Bottom;

            if (!targetTabPage.Controls.Contains(userControl))
            {
                targetTabPage.Controls.Add(userControl);
            }
            else
            {
                userControl.BringToFront();
            }

            // Kéo giãn form vừa khít chiều cao màn hình
            Rectangle workingArea = Screen.PrimaryScreen.WorkingArea;
            parentForm.Location = new Point(parentForm.Location.X, workingArea.Top);
            parentForm.Height = workingArea.Height;
        }




    }

}
