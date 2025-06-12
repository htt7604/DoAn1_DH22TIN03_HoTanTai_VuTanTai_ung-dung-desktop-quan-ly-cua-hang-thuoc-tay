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

namespace QL_Nha_thuoc.HangHoa
{
    public partial class FormThemThuoc : Form
    {
        public FormThemThuoc(string loai)
        {
            InitializeComponent();
        }

        private void textBoxTenThuoc_TextChanged(object sender, EventArgs e)
        {
            //them cac usercontrolitemthemthuoc vao flowlayoutpanelListThuoc
            string keyword = textBoxTenThuoc.Text.Trim();

            // Xóa hết các item cũ trước khi hiển thị cái mới
            flowLayoutPanelListThuoc.Controls.Clear();

            // Lấy danh sách thuốc theo từ khóa
            List<ClassThuoc> danhSach = ClassThuoc.LayDanhSachThuoc(keyword);

            // Duyệt từng thuốc và tạo UserControl hiển thị
            foreach (var thuoc in danhSach)
            {
                var item = new UserControlItemThuoc();
                item.SetValues(thuoc); // Gán dữ liệu thuốc vào usercontrol
                flowLayoutPanelListThuoc.Controls.Add(item);

                // Khi click vào UserControl, điền dữ liệu vào các TextBox trong form
                item.ThuocDuocChon += (s, selectedThuoc) =>
                {
                    textBoxMaThuoc.Text = selectedThuoc.MaThuoc;
                    textBoxTenThuoc.Text = selectedThuoc.TenThuoc;
                    textBoxSoDangKy.Text = selectedThuoc.SoDangKy;
                    textBoxHoatChat.Text = selectedThuoc.HoatChatChinh;
                    textBoxHamLuong.Text = selectedThuoc.HamLuong;
                    textBoxQuyCachDongGoi.Text = selectedThuoc.QuyCachDongGoi;
                    textBoxHangSanXuat.Text = selectedThuoc.TenHangSanXuat;
                    comboBoxDonViTinh.Text = selectedThuoc.TenDonViTinh;

                    flowLayoutPanelListThuoc.Visible = false; // Ẩn danh sách sau khi chọn

                };
                flowLayoutPanelListThuoc.Visible = danhSach.Count > 0; // Hiển thị flowLayoutPanel nếu có kết quả


            }
        }




    }
}
