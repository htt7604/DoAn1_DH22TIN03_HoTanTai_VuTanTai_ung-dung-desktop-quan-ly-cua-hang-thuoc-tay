using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.BanHang.TRA_HANG;
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
using QL_Nha_thuoc.BanHang.TRA_HANG;
using static QL_Nha_thuoc.DanhMuc;



namespace QL_Nha_thuoc.BanHang
{
    public partial class FormBanHangMain : Form
    {
        private FormMain parentMain; // tham chiếu tới FormMain (có thể null nếu ko cần)

        public FormBanHangMain(FormMain formMain)
        {
            InitializeComponent();
            parentMain = formMain; // Lưu tham chiếu tới FormMain
        }

        // Constructor mới nhận parent FormMain
        //public FormBanHangMain(FormMain parent) : this()
        //{
        //    parentMain = parent;
        //}

        //load combobox bang gia 
        private void LoadComBoBoxBangGia()
        {
            // Lấy danh sách bảng giá đang áp dụng
            List<ClassBangGia> classBangGias = ClassBangGia.LayTatCaBangGiaDangApDung();

            // Gán vào ComboBox
            comboBoxBangGia.DataSource = classBangGias;
            comboBoxBangGia.DisplayMember = "TenBangGia";
            comboBoxBangGia.ValueMember = "MaBangGia";


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

            var maHDMoi = ClassHoaDon.TaoMaHoaDonTuDong();
            var userControlHoaDon = new UserControlFormHoaDon(maHDMoi)
            {
                Dock = DockStyle.Fill
            };

            userControlHoaDon.LoadTaiKhoan();
            currentTab.Controls.Add(userControlHoaDon);
            LoadComBoBoxBangGia();
        }




        //them tab hoa don moi
        private void ThemTabHoaDonMoi(string Tenform)
        {
            var maHDMoi = ClassHoaDon.TaoMaHoaDonTuDong();
            var newTab = new TabPage(Tenform + " " + (tabControlHoaDon.TabCount + 1));
            var userControlHoaDon = new UserControlFormHoaDon(maHDMoi);
            userControlHoaDon.Dock = DockStyle.Fill;

            newTab.Controls.Add(userControlHoaDon);
            tabControlHoaDon.TabPages.Add(newTab);
            tabControlHoaDon.SelectedTab = newTab;
        }
        private void buttonThemHoaDon_Click(object sender, EventArgs e)
        {
            string tenForm = "Hóa đơn";
            ThemTabHoaDonMoi(tenForm);

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
        private void ThemHangVaoTabHienTaiHoaDon(ClassHangHoa hangHoa)
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

        private void ThemHangVaoTabHienTaiTraHang(ClassHangHoa hangHoa)
        {
            if (tabControlHoaDon.TabPages.Count > 0)
            {
                var currentTab = tabControlHoaDon.SelectedTab;

                // Tìm UserControlFormHoaDon trong TabPage hiện tại
                var ucFormHoaDonTraHang = currentTab.Controls.OfType<UserControlFormTraHang>().FirstOrDefault();

                if (ucFormHoaDonTraHang != null)
                {
                    ucFormHoaDonTraHang.ThemHangTraHang(hangHoa);
                }
            }

        }



        bool LaBangGiaChung(ClassBangGia bangGia)
        {
            return bangGia != null && bangGia.MaBangGia.Equals("Bảng giá chung", StringComparison.OrdinalIgnoreCase);
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




        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public static ClassBangGia BangGiaDuocChon { get; set; }
        private void comboBoxBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật bảng giá được chọn
            BangGiaDuocChon = comboBoxBangGia.SelectedItem as ClassBangGia;

            // Gọi lại tìm kiếm nếu có
            textBoxTimHH_TextChanged(sender, e);

            // Tìm tab hiện tại chứa UserControlFormHoaDon
            var currentTab = tabControlHoaDon.SelectedTab;
            if (currentTab != null)
            {
                foreach (Control control in currentTab.Controls)
                {
                    if (control is UserControlFormHoaDon uc)
                    {
                        uc.XoaTatCaHangHoaTrongHoaDon();
                    }
                }
            }
        }



        public event EventHandler FormHidden;

        private void buttonHienCongCu_Click(object sender, EventArgs e)
        {
            string vaiTro = Session.TaiKhoanDangNhap.VaiTro;

            FormCongCu popup = new FormCongCu(vaiTro);
            popup.QuayLai += (s, args) =>
            {
                if (parentMain != null)
                {
                    parentMain.Show();
                    parentMain.BringToFront();
                }

                this.Close();

            };


            // Lấy vị trí button trên màn hình
            Point buttonScreenLocation = buttonHienCongCu.PointToScreen(Point.Empty);

            // Vị trí hiển thị form: Dưới – trái của button
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(
                buttonScreenLocation.X - popup.Width + buttonHienCongCu.Width, // Canh trái
                buttonScreenLocation.Y + buttonHienCongCu.Height               // Canh dưới
            );

            popup.Show();
        }

        //ham tim kiem hang hoa theo ban gia 
        private void Timkiemhanghoatheobanggia()
        {
            var bangGiaChon = comboBoxBangGia.SelectedItem as ClassBangGia;

            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            string keyword = textBoxTimHH.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var dsHangHoa = ClassHangHoa.TimKiemHangHoaTheoBangGiaTheoTuKhoa(keyword, bangGiaChon);
            panelKetQuaTimKiem.Controls.Clear();

            foreach (var hanghoa in dsHangHoa)
            {
                UC_ItemThuoc item = new UC_ItemThuoc();
                item.SetData(hanghoa);
                item.Dock = DockStyle.Top;

                //khi người dùng click vào item thi them vao tabpage hiện tại cua tabControlHoaDon hien tai 
                item.Click += (s, ev) =>
                {
                    ThemHangVaoTabHienTaiHoaDon(hanghoa);
                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Clear();
                };

                panelKetQuaTimKiem.Controls.Add(item);
            }
        }
        private void TimKiemHangHoaTraHang()
        {
            if (string.IsNullOrWhiteSpace(maHD_TraHangDangChon))
                return;

            string keyword = textBoxTimHH.Text.Trim();
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            // Lấy danh sách chi tiết phiếu trả theo Mã HĐ + từ khóa
            var dsChiTietTra = ClassChiTietHoaDon.LayChiTietTheoMaHD(maHD_TraHangDangChon);

            panelKetQuaTimKiem.Controls.Clear();
            foreach (var chitiet in dsChiTietTra)
            {
                var hh = new ClassHangHoa
                {
                    MaHangHoa = chitiet.MaHangHoa,
                    TenHangHoa = chitiet.TenHangHoa,
                    GiaBan = chitiet.DonGiaBan ?? 0,
                    MaDonViTinh = chitiet.MaDonViTinh,
                    SoLuongTon = chitiet.SoLuong ?? 0
                };
                UC_ItemThuoc item = new UC_ItemThuoc();

                item.SetData(hh);
                item.Dock = DockStyle.Top;

                item.Click += (s, ev) =>
                {
                    ThemHangVaoTabHienTaiTraHang(hh);
                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Clear();
                };

                panelKetQuaTimKiem.Controls.Add(item);
            }
            
        }


        //su kien tim kiem hang hoa 
        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            if (trangthaitrahang == false)
            {
                Timkiemhanghoatheobanggia();
            }
            else
            {
                TimKiemHangHoaTraHang();
            }

        }



        private string maHD_TraHangDangChon = null; // để lưu mã HĐ trả hàng đang xử lý
        private string LayMaHDDangTra()
        {
            var currentTab = tabControlHoaDon.SelectedTab;

            if (currentTab?.Tag is not null)
            {
                var tagInfo = currentTab.Tag;

                // Nếu Tag là anonymous type { Loai, MaHD }
                var loaiProp = tagInfo.GetType().GetProperty("Loai")?.GetValue(tagInfo)?.ToString();
                var maHDProp = tagInfo.GetType().GetProperty("MaHD")?.GetValue(tagInfo)?.ToString();

                if (loaiProp == "TraHang")
                {
                    return maHDProp; // trả về mã hóa đơn
                }
            }

            return null;
        }

        private bool trangthaitrahang = false;
        //private void buttonTraHang_Click(object sender, EventArgs e)
        //{
        //    var formChonHDTraHang = new FormChonHDTraHang();

        //    formChonHDTraHang.ThemMoiTraHang += (hoaDon) =>
        //    {
        //        var newTab = new TabPage("Trả hàng " + (tabControlHoaDon.TabCount + 1))
        //        {
        //            Tag = new { Loai = "TraHang", MaHD = hoaDon.MaHoaDon } // lưu cả loại và mã hóa đơn
        //        };

        //        var ucHoaDon = new UserControlFormTraHang(hoaDon.MaHoaDon)
        //        {
        //            Dock = DockStyle.Fill
        //        };
        //        //ucHoaDon.LoadHoaDonTraHang(hoaDon);

        //        newTab.Controls.Add(ucHoaDon);
        //        tabControlHoaDon.TabPages.Add(newTab);
        //        tabControlHoaDon.SelectedTab = newTab;
        //    };



        //    formChonHDTraHang.Show();
        //}

        private void buttonTraHang_Click(object sender, EventArgs e)
        {
            var formChonHDTraHang = new FormChonHDTraHang();

            formChonHDTraHang.ThemMoiTraHang += (hoaDon) =>
            {
                var newTab = new TabPage("Trả hàng " + (tabControlHoaDon.TabCount + 1))
                {
                    Tag = new { Loai = "TraHang", MaHD = hoaDon.MaHoaDon }
                };

                var ucHoaDon = new UserControlFormTraHang(hoaDon.MaHoaDon)
                {
                    Dock = DockStyle.Fill
                };

                // Bắt sự kiện trả hàng thành công để làm mới tab
                ucHoaDon.TraHangThanhCong += (s, ev) =>
                {
                    if (tabControlHoaDon.TabPages.Count > 1)
                    {
                        var currentTab = tabControlHoaDon.SelectedTab;
                        if (currentTab != null)
                        {
                            tabControlHoaDon.TabPages.Remove(currentTab);
                        }
                    }
                };

                newTab.Controls.Add(ucHoaDon);
                tabControlHoaDon.TabPages.Add(newTab);
                tabControlHoaDon.SelectedTab = newTab;
            };
            formChonHDTraHang.Show();
        }



        private void tabControlHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentTab = tabControlHoaDon.SelectedTab;

            if (currentTab?.Tag != null)
            {
                var tagInfo = currentTab.Tag;
                var loai = tagInfo.GetType().GetProperty("Loai")?.GetValue(tagInfo)?.ToString();
                var maHD = tagInfo.GetType().GetProperty("MaHD")?.GetValue(tagInfo)?.ToString();

                if (loai == "TraHang")
                {
                    trangthaitrahang = true;
                    textBoxTimHH.PlaceholderText = "Tìm hàng hóa trả";
                    maHD_TraHangDangChon = maHD; // Lưu lại mã hóa đơn đang trả
                    return;
                }
            }

            // Nếu không phải tab trả hàng
            trangthaitrahang = false;
            textBoxTimHH.PlaceholderText = "Tìm hàng hóa";
            maHD_TraHangDangChon = null;
        }

        private void buttonQuetMaVach_Click(object sender, EventArgs e)
        {

        }


    }

}




















