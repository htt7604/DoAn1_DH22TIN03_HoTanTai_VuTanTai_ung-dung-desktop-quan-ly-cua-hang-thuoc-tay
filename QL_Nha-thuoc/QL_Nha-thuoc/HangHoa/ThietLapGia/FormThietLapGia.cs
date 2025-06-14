using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc.HangHoa.ThietLapGia;
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
    public partial class FormThietLapGia : Form
    {
        public FormThietLapGia()
        {
            InitializeComponent();
        }
        private void CapNhatKichThuocUserControl()
        {
            int newWidth = flowLayoutPanelThietLapGia.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
            int y = 0; // Biến để theo dõi vị trí Y của các control

            foreach (Control ctrl in flowLayoutPanelThietLapGia.Controls)
            {
                ctrl.Width = newWidth;
            }
        }

        private void flowLayoutPanelThietLapGia_SizeChanged(object sender, EventArgs e)
        {
            CapNhatKichThuocUserControl();

        }
        //load form

        public void FormThietLapGia_Load(object sender, EventArgs e)
        {
            // Lấy danh sách toàn bộ giá bán từ CSDL
            List<ClassGiaBanHH> danhSachGiaBan = ClassGiaBanHH.LayDanhSachToanboGiaBan();

            // Xóa các control cũ nếu có
            flowLayoutPanelThietLapGia.Controls.Clear();

            // Thêm header nếu cần (nếu là tiêu đề)
            UserControlTTGia userControlTTGia = new UserControlTTGia();
            flowLayoutPanelThietLapGia.Controls.Add(userControlTTGia);

            // Duyệt danh sách và thêm từng UserControl vào FlowLayoutPanel
            foreach (var giaBan in danhSachGiaBan)
            {
                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
                item.Setdata(giaBan); // Gán dữ liệu vào UserControl
                flowLayoutPanelThietLapGia.Controls.Add(item);
            }

            // Cập nhật lại kích thước các UserControl ngay khi load
            CapNhatKichThuocUserControl();
        }
    }
}
