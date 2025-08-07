using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormChonTaiKhoanNganHang : Form
    {
        public event EventHandler<ClassTaiKhoanNganHang> TaiKhoanDuocChon;

        private List<ClassTaiKhoanNganHang> _danhSach;

        public FormChonTaiKhoanNganHang(List<ClassTaiKhoanNganHang> danhSach)
        {
            InitializeComponent();
            _danhSach = danhSach;
        }

        private void FormChonTaiKhoanNganHang_Load(object sender, EventArgs e)
        {
            HienThiDanhSachTaiKhoan(_danhSach);
            flowLayoutPanelTaiKhoan.Controls.Clear();

            foreach (var tk in _danhSach)
            {
                var item = new UserControlitemtkNganHang();
                item.Setdata(tk);
                item.Margin = new Padding(5);
                item.Width = flowLayoutPanelTaiKhoan.ClientSize.Width - flowLayoutPanelTaiKhoan.Padding.Horizontal - item.Margin.Horizontal;

                item.TaiKhoanDuocChon += (s, taiKhoan) =>
                {
                    TaiKhoanDuocChon?.Invoke(this, taiKhoan);
                    this.Close();
                };

                flowLayoutPanelTaiKhoan.Controls.Add(item);
            }

            // ✅ Thêm nút "Thêm tài khoản" cuối danh sách
            Button btnThemTaiKhoan = new Button();
            btnThemTaiKhoan.Text = "+ Thêm tài khoản";
            btnThemTaiKhoan.AutoSize = false;
            btnThemTaiKhoan.Width = flowLayoutPanelTaiKhoan.ClientSize.Width - flowLayoutPanelTaiKhoan.Padding.Horizontal - btnThemTaiKhoan.Margin.Horizontal;
            btnThemTaiKhoan.Height = 40;
            btnThemTaiKhoan.Margin = new Padding(5);
            btnThemTaiKhoan.BackColor = Color.LightGreen;

            btnThemTaiKhoan.Click += (s, e2) =>
            {
                // Mở form thêm tài khoản (tùy bạn thiết kế)
                FormThemTaiKhoanNganHang frmThem = new FormThemTaiKhoanNganHang();
                frmThem.FormDaDong += (s2, e2) =>
                {
                    // Sau khi form thêm đóng, luôn reload lại danh sách tài khoản
                    _danhSach = ClassTaiKhoanNganHang.LayDanhSachTaiKhoan();
                    FormChonTaiKhoanNganHang_Load(null, null);
                };

                if (frmThem.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi thêm, bạn có thể reload lại danh sách:
                    _danhSach = ClassTaiKhoanNganHang.LayDanhSachTaiKhoan();
                    FormChonTaiKhoanNganHang_Load(null, null); // Gọi lại để refresh danh sách
                }

            };

            flowLayoutPanelTaiKhoan.Controls.Add(btnThemTaiKhoan);
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            var ketQua = _danhSach
                .Where(tk =>
                    tk.TenChuTK.ToLower().Contains(keyword) ||
                    tk.SoTaiKhoan.ToLower().Contains(keyword)
                )
                .ToList();

            HienThiDanhSachTaiKhoan(ketQua);
        }
        private void HienThiDanhSachTaiKhoan(List<ClassTaiKhoanNganHang> danhSach)
        {
            flowLayoutPanelTaiKhoan.Controls.Clear();

            foreach (var tk in danhSach)
            {
                var item = new UserControlitemtkNganHang();
                item.Setdata(tk);
                item.Margin = new Padding(5);
                item.Width = flowLayoutPanelTaiKhoan.ClientSize.Width - 25;

                item.TaiKhoanDuocChon += (s, taiKhoan) =>
                {
                    TaiKhoanDuocChon?.Invoke(this, taiKhoan);
                    this.Close();
                };

                flowLayoutPanelTaiKhoan.Controls.Add(item);
            }

            // Nút thêm tài khoản
            Button btnThemTaiKhoan = new Button();
            btnThemTaiKhoan.Text = "+ Thêm tài khoản";
            btnThemTaiKhoan.Width = flowLayoutPanelTaiKhoan.ClientSize.Width - 25;
            btnThemTaiKhoan.Height = 40;
            btnThemTaiKhoan.Margin = new Padding(5);
            btnThemTaiKhoan.BackColor = Color.LightGreen;

            btnThemTaiKhoan.Click += (s, e2) =>
            {
                FormThemTaiKhoanNganHang frmThem = new FormThemTaiKhoanNganHang();
                if (frmThem.ShowDialog() == DialogResult.OK)
                {
                    _danhSach = ClassTaiKhoanNganHang.LayDanhSachTaiKhoan();
                    HienThiDanhSachTaiKhoan(_danhSach);
                }
            };

            flowLayoutPanelTaiKhoan.Controls.Add(btnThemTaiKhoan);
        }

        private void flowLayoutPanelTaiKhoan_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelTaiKhoan.Controls)
            {
                if (ctrl is UserControlitemtkNganHang || ctrl is Button)
                {
                    ctrl.Width = flowLayoutPanelTaiKhoan.ClientSize.Width - 20;
                }
            }
        }



    }
}
