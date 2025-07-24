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
            ghiChu = textBoxGhiChu.Text;
            SetTrangThaiPhieu();
        }

        public void CapNhatTongSoLuongThucTe()
        {
            int tong = flowLayoutPanelKiemKho.Controls
                .OfType<UserControlHangHoaKiemKho>()
                .Sum(ctrl => ctrl.SoLuongThucTe);

            labelTongThucTe.Text = tong.ToString();
        }

        public int CapNhatSTT()
        {
            int stt = 1;

            // Giả sử bạn đặt tên FlowLayoutPanel là flowLayoutPanelKiemKho
            var flPanel = this.Controls.Find("flowLayoutPanelKiemKho", true).FirstOrDefault() as FlowLayoutPanel;
            if (flPanel == null) return 0;

            foreach (Control control in flPanel.Controls)
            {
                if (control is UserControlHangHoaKiemKho item)
                {
                    item.SetSTT(stt);
                    stt++;
                }
            }

            return stt - 1;
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
            //add usercontrolhanghoakiemkho vao flowlayoutpanel
            ClassPhieuKiemKho phieukiemkho = ClassPhieuKiemKho.LayPhieuKiemKho(MaKiemKho);
            if (phieukiemkho == null)
            {
                MessageBox.Show("No record found for the given MaKiemKho.");
                return;
            }
            labelTrangThai.Text = phieukiemkho.TrangThaiPhieuKiem;
            textBoxGhiChu.Text = phieukiemkho.GhiChu;
            textBoxMaKiemKho.Text = phieukiemkho.MaPhieuKiemKho;
            labelTime.Text = phieukiemkho.NgayKiemKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
            comboBoxTaiKhoan.Text = phieukiemkho.TenNhanVien;
            //them usercontrolcotkiemkho vao flowlayoutpanel
            var usercontrolCotKiemKho = new UserControlCotKiemKho();
            //usercontrolCotKiemKho.Width = flowLayoutPanelKiemKho.ClientSize.Width - flowLayoutPanelKiemKho.Padding.Horizontal - 5;
            usercontrolCotKiemKho.Dock = DockStyle.Top;
            flowLayoutPanelKiemKho.Controls.Add(usercontrolCotKiemKho);

        }
        private void buttonLuuTam_Click(object sender, EventArgs e)
        {
            var danhSachHangHoa = flowLayoutPanelKiemKho.Controls.OfType<UserControlHangHoaKiemKho>().ToList();

            if (danhSachHangHoa.Count == 0)
            {
                MessageBox.Show("Không có hàng hóa nào trong phiếu kiểm kho để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ClassChiTietPhieuKiemKho> danhSachChiTiet = new List<ClassChiTietPhieuKiemKho>();

            foreach (var item in danhSachHangHoa)
            {
                ClassChiTietPhieuKiemKho chiTiet = new ClassChiTietPhieuKiemKho
                {
                    MaPhieuKiemKho = MaKiemKho,
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    SoLuongHeThong = item.SoLuongHeThong,
                    SoLuongThucTe = item.SoLuongThucTe,
                    GhiChu = textBoxGhiChu.Text.Trim()
                };
                danhSachChiTiet.Add(chiTiet);
            }

            foreach (var chiTiet in danhSachChiTiet)
            {
                try
                {
                    var danhSachCu = ClassChiTietPhieuKiemKho.LayDanhSachChiTietPhieuKiemKho(MaKiemKho);
                    bool daTonTai = danhSachCu.Any(x => x.MaHangHoa == chiTiet.MaHangHoa);

                    if (daTonTai)
                        ClassChiTietPhieuKiemKho.CapNhatChiTietPhieuKiemKho(chiTiet);
                    else
                        ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTiet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu hàng hóa {chiTiet.MaHangHoa}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Lưu tạm phiếu kiểm kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            var danhSachHangHoa = flowLayoutPanelKiemKho.Controls.OfType<UserControlHangHoaKiemKho>().ToList();

            if (danhSachHangHoa.Count == 0)
            {
                MessageBox.Show("Không thể hoàn thành vì không có hàng hóa trong phiếu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ClassChiTietPhieuKiemKho> danhSachChiTiet = new List<ClassChiTietPhieuKiemKho>();

            int tongChenhLech = 0;
            int soLuongLechTang = 0;
            int soLuongLechGiam = 0;

            foreach (var item in danhSachHangHoa)
            {
                var chiTiet = new ClassChiTietPhieuKiemKho
                {
                    MaPhieuKiemKho = MaKiemKho,
                    MaHangHoa = item.MaHangHoa,
                    TenHangHoa = item.TenHangHoa,
                    SoLuongHeThong = item.SoLuongHeThong,
                    SoLuongThucTe = item.SoLuongThucTe,
                    GhiChu = textBoxGhiChu.Text.Trim()
                };

                danhSachChiTiet.Add(chiTiet);

                tongChenhLech += Math.Abs(chiTiet.ChenhLech);

                if (chiTiet.ChenhLech > 0)
                    soLuongLechTang++;
                else if (chiTiet.ChenhLech < 0)
                    soLuongLechGiam++;
            }

            // Cập nhật hoặc thêm chi tiết kiểm kho
            foreach (var chiTiet in danhSachChiTiet)
            {
                try
                {
                    var danhSachCu = ClassChiTietPhieuKiemKho.LayDanhSachChiTietPhieuKiemKho(MaKiemKho);
                    bool daTonTai = danhSachCu.Any(x => x.MaHangHoa == chiTiet.MaHangHoa);

                    if (daTonTai)
                        ClassChiTietPhieuKiemKho.CapNhatChiTietPhieuKiemKho(chiTiet);
                    else
                        ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTiet);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi lưu hàng hóa {chiTiet.MaHangHoa}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Cập nhật thông tin phiếu kiểm kho
            ClassPhieuKiemKho phieukiemkho = new ClassPhieuKiemKho
            {
                MaPhieuKiemKho = MaKiemKho,
                MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien,
                TenNhanVien = comboBoxTaiKhoan.Text.Trim(),
                NgayKiemKho = DateTime.Now,
                ThoiGianCanBangKho = DateTime.Now,
                TongThucTe = danhSachChiTiet.Sum(x => x.SoLuongThucTe),
                GhiChu = textBoxGhiChu.Text.Trim(),
                TrangThaiPhieuKiem = "Đã cân bằng kho",
                TongChechLech = tongChenhLech,
                // Nếu class ClassPhieuKiemKho chưa có 2 dòng dưới, bạn có thể bỏ hoặc thêm vào class.
                SoLuongLechTang = soLuongLechTang,
                SoLuongLechGiam = soLuongLechGiam
            };

            try
            {
                ClassPhieuKiemKho.CapNhatPhieuKiemKho(phieukiemkho);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật phiếu kiểm kho: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cập nhật tồn kho thực tế
            foreach (var item in danhSachChiTiet)
            {
                try
                {
                    ClassHangHoa.CapNhatTonKho(item.MaHangHoa, item.SoLuongThucTe);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật tồn kho cho {item.MaHangHoa}: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Hoàn thành phiếu kiểm kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }







    }
}
