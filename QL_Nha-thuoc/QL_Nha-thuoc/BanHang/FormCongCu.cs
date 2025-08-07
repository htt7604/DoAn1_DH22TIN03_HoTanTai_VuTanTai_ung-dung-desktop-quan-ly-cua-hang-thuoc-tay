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
    public partial class FormCongCu : Form
    {
        private string vaiTro;

        public FormCongCu(string vaiTro)
        {
            InitializeComponent();
            this.vaiTro = vaiTro;
            HienThiNutTheoVaiTro();
            this.Deactivate += (s, e) => { this.Close(); }; // Tự đóng khi mất focus
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
        }
        private void HienThiNutTheoVaiTro()
        {
            if (vaiTro == "Bán hàng")
            {
                btnDangXuat.Visible = true;
                btnQuayLaiQL.Visible = false;
            }
            else if (vaiTro == "Quản lý")
            {
                btnDangXuat.Visible = true;
                btnQuayLaiQL.Visible = true;
            }
            else
            {
                // Mặc định ẩn hết nếu không xác định
                btnDangXuat.Visible = false;
                btnQuayLaiQL.Visible = false;
            }
        }
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            this.Close();
        }


        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            Application.Restart(); // hoặc mở lại form đăng nhập
        }

        public event EventHandler QuayLai;

        private void btnQuayLaiQL_Click(object sender, EventArgs e)
        {
            QuayLai?.Invoke(this, EventArgs.Empty); // Gọi quay lại
            this.Hide(); // Ẩn thay vì Close để không mất form
        }




    }
}
