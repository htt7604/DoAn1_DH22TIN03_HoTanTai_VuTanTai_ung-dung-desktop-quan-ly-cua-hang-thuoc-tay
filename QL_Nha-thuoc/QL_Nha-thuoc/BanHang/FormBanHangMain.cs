using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.HangHoa.Them;
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

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormBanHangMain : Form
    {
        public FormBanHangMain()
        {
            InitializeComponent();
        }

        //load combobox bang gia 
        private void LoadComBoBoxBangGia()
        {
            // Lấy danh sách bảng giá đang áp dụng
            List<ClassBangGia> classBangGias = ClassBangGia.LayTatCaBangGiaDangApDUng();

            // Gán vào ComboBox
            comboBoxBangGia.DataSource = classBangGias;
            comboBoxBangGia.DisplayMember = "TEN_BANG_GIA";  // Tên hiển thị
            comboBoxBangGia.ValueMember = "MA_BANG_GIA";      // Giá trị thực sự

            // Nếu có ít nhất 1 bảng giá, chọn mặc định dòng đầu tiên
            if (classBangGias.Count > 0)
            {
                comboBoxBangGia.SelectedIndex = 0;
            }
            else
            {
                comboBoxBangGia.Text = "Không có bảng giá";
            }
        }



        private void FormBanHangMain_Load(object sender, EventArgs e)
        {
            //load labeltentaiKhoan
            labelTenTaiKhoan.Text = Session.TaiKhoanDangNhap.TenTaiKhoan;

            if (tabControlHoaDon.TabPages.Count == 0)
                return;

            TabPage currentTab = tabControlHoaDon.TabPages[0];
            currentTab.Controls.Clear();

            var userControlHoaDon = new UserControlFormHoaDon
            {
                Dock = DockStyle.Fill
            };

            userControlHoaDon.LoadTaiKhoan();
            currentTab.Controls.Add(userControlHoaDon);
        }




        //them tab hoa don moi
        private void ThemTabHoaDonMoi()
        {
            var newTab = new TabPage("Hóa đơn " + (tabControlHoaDon.TabCount + 1));
            var userControlHoaDon = new UserControlFormHoaDon();
            userControlHoaDon.Dock = DockStyle.Fill;

            newTab.Controls.Add(userControlHoaDon);
            tabControlHoaDon.TabPages.Add(newTab);
            tabControlHoaDon.SelectedTab = newTab;
        }
        private void buttonThemHoaDon_Click(object sender, EventArgs e)
        {
            ThemTabHoaDonMoi();
        }






        //xoa tab hoa don hien tai
        private void buttonXoaHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có tab nào không
            if (tabControlHoaDon.TabPages.Count > 1)
            {
                //thong báo người dùng co muon xóa không
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn hiện tại không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //neu người dùng đồng ý xóa
                if (result == DialogResult.Yes)
                {
                    // Xóa tab hiện tại
                    var currentTab = tabControlHoaDon.SelectedTab;
                    if (currentTab != null)
                    {
                        tabControlHoaDon.TabPages.Remove(currentTab);
                    }
                }
            }
        }





        //su kien sau khi click vao item trong danh sach tinh kiem hang hoa thi them va flowplayourpanel cua userControlFormHoaDon
        private void ThemHangVaoTabHienTai(ClassHangHoa hangHoa)
        {
            if (tabControlHoaDon.TabPages.Count > 0)
            {
                var currentTab = tabControlHoaDon.SelectedTab;

                // Tìm UserControlFormHoaDon trong TabPage hiện tại
                var ucFormHoaDon = currentTab.Controls.OfType<UserControlFormHoaDon>().FirstOrDefault();

                if (ucFormHoaDon != null)
                {
                    ucFormHoaDon.ThemHang(hangHoa); // Gọi tới hàm them usecontrolHanghoa va flowplayourpanel đã định nghĩa trong UserControlFormHoaDon
                }
            }
        }
        //su kien tim kiem hang hoa 
        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            string keyword = textBoxTimHH.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var dsHangHoa = ClassHangHoa.TimKiemHangHoaTheoTuKhoa(keyword);
            panelKetQuaTimKiem.Controls.Clear();

            foreach (var hanghoa in dsHangHoa)
            {
                UC_ItemThuoc item = new UC_ItemThuoc();
                item.SetData(hanghoa);
                item.Dock = DockStyle.Top;

                //khi người dùng click vào item thi them vao tabpage hiện tại cua tabControlHoaDon hien tai 
                item.Click += (s, ev) =>
                {
                    ThemHangVaoTabHienTai(hanghoa);
                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Clear();
                };

                panelKetQuaTimKiem.Controls.Add(item);
            }

        }





















        private void tabControlHoaDon_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage currentTab = tabControl.TabPages[e.Index];

            // Kiểm tra nếu là tab được chọn
            bool isSelected = (e.Index == tabControl.SelectedIndex);

            // Chọn màu nền và chữ
            Color backColor = isSelected ? Color.Blue : SystemColors.Control;
            Color textColor = isSelected ? Color.White : Color.Black;

            using (SolidBrush bgBrush = new SolidBrush(backColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                // Vẽ nền tab
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

                // Vẽ chữ tiêu đề tab
                e.Graphics.DrawString(currentTab.Text, this.Font, textBrush, e.Bounds, sf);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}




















