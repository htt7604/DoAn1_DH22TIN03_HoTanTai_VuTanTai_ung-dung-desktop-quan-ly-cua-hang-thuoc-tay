using QL_Nha_thuoc.BanHang;
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

namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    public partial class UserControlFormKiemKho : UserControl
    {
        public string ghiChu { get; private set; }
        public string MaKiemKho { get; private set; }
        public UserControlFormKiemKho(string maKiemKho)
        {
            InitializeComponent();
            MaKiemKho = maKiemKho;
            ghiChu=textBoxGhiChu.Text;
            SetTrangThaiPhieu();
        }

        public void CapNhatTongSoLuongThucTe()
        {
            int tong = flowLayoutPanelKiemKho.Controls
                .OfType<UserControlHangHoaKiemKho>()
                .Sum(ctrl => ctrl.SoLuongThucTe);

            textBoxTongThucTe.Text = tong.ToString();
        }


        public void ThemHang(model.ClassHangHoa thongtin)
        {
            if (thongtin == null || string.IsNullOrWhiteSpace(thongtin.MaHangHoa))
            {
                MessageBox.Show("Thông tin hàng hóa không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra xem hàng hóa đã tồn tại trong danh sách chưa
            bool daTonTai = flowLayoutPanelKiemKho.Controls
                .OfType<UserControlHangHoaKiemKho>()
                .Any(ctrl => ctrl.MaHangHoa == thongtin.MaHangHoa);

            if (daTonTai)
            {
                MessageBox.Show("Hàng hóa này đã có trong danh sách kiểm kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Nếu chưa có, tạo mới và thêm vào
            var item = new UserControlHangHoaKiemKho(thongtin.MaHangHoa);
            item.SetData(thongtin);

            item.Margin = new Padding(0, 5, 0, 0);
            item.Width = flowLayoutPanelKiemKho.ClientSize.Width - flowLayoutPanelKiemKho.Padding.Horizontal - 5;

            item.OnSoLuongThucTeThayDoi += (s, e) =>
            {
                CapNhatTongSoLuongThucTe();
            };

            flowLayoutPanelKiemKho.Controls.Add(item);



        }
        //ham truyen trang thai phieu kiem kho
        public void SetTrangThaiPhieu()
        {
            PhieuKiemKho phieukiemkho = PhieuKiemKho.LayPhieuKiemKho(MaKiemKho);
            if (phieukiemkho == null)
            {
                MessageBox.Show("No record found for the given MaKiemKho.");
                return;
            }
            textBoxTrangThai.Text = phieukiemkho.TrangThaiPhieuKiem;
            textBoxGhiChu.Text = phieukiemkho.GhiChu;
            textBoxMaKiemKho.Text = phieukiemkho.MaPhieuKiemKho;
            labelTime.Text = phieukiemkho.NgayKiemKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
            comboBoxTaiKhoan.Text = phieukiemkho.TenNhanVien;

        }


    }
}
