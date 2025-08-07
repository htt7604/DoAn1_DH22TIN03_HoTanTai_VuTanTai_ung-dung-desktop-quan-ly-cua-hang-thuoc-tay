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

namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlitemtkNganHang : UserControl
    {
        public event EventHandler Clicked;

        public UserControlitemtkNganHang()
        {
            InitializeComponent();
            // Gắn sự kiện click vào toàn bộ UserControl
            this.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            // Gắn click cho các control bên trong (nếu có Label, PictureBox...)
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            }
        }

    
        private ClassTaiKhoanNganHang _taiKhoan;
        public event EventHandler<ClassTaiKhoanNganHang> TaiKhoanDuocChon;
        public event EventHandler FormDaDong;
        public void Setdata(ClassTaiKhoanNganHang taiKhoan)
        {
            _taiKhoan = taiKhoan;
            // Gán dữ liệu vào các label
            labelTenTaiKhoan.Text = taiKhoan.TenChuTK;
            labelSTK.Text = taiKhoan.SoTaiKhoan;
            labelTenNganHang.Text = taiKhoan.TenNganHang;
        }

        private void UserControlitemtkNganHang_Click(object sender, EventArgs e)
        {
            TaiKhoanDuocChon?.Invoke(this, _taiKhoan);
        }

        private void UserControlitemtkNganHang_Load(object sender, EventArgs e)
        {
            this.Click += UserControlitemtkNganHang_Click;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Click += UserControlitemtkNganHang_Click;
            }
        }

    }
}
