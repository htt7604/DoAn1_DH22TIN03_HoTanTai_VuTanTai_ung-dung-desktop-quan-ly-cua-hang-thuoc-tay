using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc
{
    public partial class FormTuyChonMain : Form
    {
        public FormTuyChonMain()
        {
            InitializeComponent();
            this.Deactivate += (s, e) => { this.Close(); }; // Tự đóng khi mất focus
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart(); // hoặc mở lại form đăng nhập

        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }


    }
}
