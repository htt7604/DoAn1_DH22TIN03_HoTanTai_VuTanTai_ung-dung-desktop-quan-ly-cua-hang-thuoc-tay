using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.DoiTac;
using QL_Nha_thuoc.DoiTac.nhacungcap;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc.HangHoa.Them;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QL_Nha_thuoc.model.ICoTheReload;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class FormThemNhapHang : Form, ICoTheReload
    {
        public event Action FormThemNhapDong;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string _maPhieuNhap { get; set; } // Biến để lưu mã phiếu nhập
        public FormThemNhapHang(string maPhieuNhap)
        {
            InitializeComponent();
            this.FormClosed += (s, e) =>
            {
                // Khi form đóng thì gọi event nếu có người đăng ký
                FormThemNhapDong?.Invoke();
            };
            _maPhieuNhap = maPhieuNhap; // Gán giá trị mã phiếu nhập
        }
        //ham setdata cho form them nhap hang
        public void LoadTaiKhoan()
        {

            //chon tai khoan dang dang nhap
            ClassTaiKhoan taiKhoan = Session.TaiKhoanDangNhap;
            var taiKhoanDangNhap = ClassTaiKhoan.LayTaiKhoan(taiKhoan.TenTaiKhoan);
            if (taiKhoanDangNhap != null)
            {
                comboBoxTaiKhoan.SelectedValue = taiKhoanDangNhap.TenTaiKhoan;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void setData()
        {
            var danhSachTaiKhoan = ClassTaiKhoan.LayDanhSachTaiKhoan();
            comboBoxTaiKhoan.DataSource = danhSachTaiKhoan;
            comboBoxTaiKhoan.DisplayMember = "TenHienThi"; // sử dụng thuộc tính mới
            comboBoxTaiKhoan.ValueMember = "TenTaiKhoan";
            comboBoxTaiKhoan.SelectedIndex = 0; // Đặt không có lựa chọn nào được chọn

            textBoxMaPhieuNhap.Text = ClassPhieuNhapHang.TaoMaPhieuNhap(); // Tự động sinh mã phiếu nhập

            textBoxTongTien.Text = "0"; // Hiển thị số tiền cần trả ban đầu là 0
            textBoxGiamGia.Text = "0"; // Hiển thị tổng tiền ban đầu là 0
            textBoxCanTra.Text = "0"; // Hiển thị giảm giá ban đầu là 0
            labelTrangThai.Text = "Phiếu tạm"; // Hiển thị trạng thái ban đầu là chưa thanh toán

            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            LoadTaiKhoan(); // Gọi hàm để nạp danh sách tài khoản khi khởi tạo form
        }

        public void LoadPhieuNhapHang(string maPhieu)
        {
            var phieunhap= ClassPhieuNhapHang.TimTheoMaPhieuNhap(maPhieu);
            setData();
            //comboBoxTaiKhoan.SelectedValue = phieunhap.MaNhanVien;


            textBoxMaPhieuNhap.Text = phieunhap.MaPhieuNhap;
            textBoxGhiChu.Text = phieunhap.GhiChuPhieuNhap;
            textBoxTongTien.Text = phieunhap.TongTienNhapHang.HasValue? phieunhap.TongTienNhapHang.Value.ToString("N0") + " đ": "0 đ"; 
            textBoxGiamGia.Text = phieunhap.GiamGia.HasValue ? phieunhap.GiamGia.Value.ToString("N0") + " đ" : "0 đ"; // Hiển thị giảm giá
            textBoxCanTra.Text = phieunhap.SoTienPhaiTra.HasValue ? phieunhap.SoTienPhaiTra.Value.ToString("N0") + " đ" : "0 đ"; // Hiển thị số tiền cần trả
            textBoxSoTienTraNCC.Text = phieunhap.SoTienDaTra.HasValue ? phieunhap.SoTienDaTra.Value.ToString("N0") + " đ" : "0 đ"; // Hiển thị số tiền đã trả cho nhà cung cấp
            labelTrangThai.Text = phieunhap.TrangThai; // Hiển thị trạng thái phiếu nhập
            textBoxTimNCC.Text = phieunhap.TenNhaCungCap; // Hiển thị tên nhà cung
            maNCCdachon = phieunhap.MaNhaCungCap; // Lưu mã nhà cung cấp đã chọn

            

            var danhSachHang = ClassChiTietPhieuNhap.LayDanhSachChiTietPhieuNhap(maPhieu);
            foreach (var hang in danhSachHang)
            {
                 //var chitiet= ClassChiTietPhieuNhap.LayChiTietPhieuNhaptheomaHH_DVT_maPhieu(hang.MaPhieuNhap, hang.MaHangHoa, hang.MaDonViTinh);
                // Lấy đầy đủ thông tin hàng hóa để dùng SetData
                var thongtin = ClassHangHoa.LayThongTinMotHangHoa(hang.MaHangHoa);
                thongtin.SoLuongTon = hang.SoLuong;
                thongtin.TenDonViTinh = hang.TenDonViTinh;

                var item = new UserControlHangHoaitemNhapHang(_maPhieuNhap);
                item.setDataChiTietPhieuNhap(hang);
                flowLayoutPanelNhapHang.Controls.Add(item);
 


            }
        }





        public void ReloadSauKhiThayDoi()
        {
            // logic cập nhật lại sau khi thêm thành công
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm hàng hóa
            panelThemHH.Visible = false; // Ẩn panel thêm hàng hóa
        }

        private void buttonThemNCC_Click(object sender, EventArgs e)
        {
            if (buttonThemNCC.Text == "-")
            {
                //nếu đang hiển thị nhà cung cấp thì xóa lựa chọn
                textBoxTimNCC.Text = "";
                flowLayoutPanelDSNCC.Visible = false;
                buttonThemNCC.Text = "+";
                textBoxTimNCC.ReadOnly = false; // Cho phép người dùng nhập lại
                return;
            }
            //mo form them nha cung cap
            FormThemNhaCungCap formThemNhaCungCap = new FormThemNhaCungCap();
            formThemNhaCungCap.ShowDialog();
            //sau khi them nha cung cap, cap nhat lai danh sach nha cung cap
        }


        string maNCCdachon = ""; // Biến để lưu mã nhà cung cấp đã chọn
        private void textBoxTimNCC_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxTimNCC.Text.Trim();

            if (!string.IsNullOrEmpty(searchText)) // CHỈ tìm khi có nội dung
            {
                List<ClassNhaCungCap> danhSachNCC = ClassNhaCungCap.LayDanhSachNhaCungCapTheoTen(searchText);

                flowLayoutPanelDSNCC.Controls.Clear();

                foreach (ClassNhaCungCap ncc in danhSachNCC)
                {
                    UserControlNhaCungCap userControlNhaCungCap = new UserControlNhaCungCap();
                    userControlNhaCungCap.setdata(ncc);
                    userControlNhaCungCap.Click += (s, args) =>
                    {
                        // Khi chọn nhà cung cấp
                        textBoxTimNCC.Text = ncc.TenNhaCungCap;
                        flowLayoutPanelDSNCC.Visible = false;
                        //thay doi nut them nha cung cap thanh nut loai bo su lua chon nha cung cap
                        buttonThemNCC.Text = "-";
                        //khong cho sua textboxtimNCC
                        textBoxTimNCC.ReadOnly = true;
                        maNCCdachon = ncc.MaNhaCungCap; // Lưu mã nhà cung cấp đã chọn

                    };
                    flowLayoutPanelDSNCC.Controls.Add(userControlNhaCungCap);
                }

                flowLayoutPanelDSNCC.Visible = danhSachNCC.Count > 0;
            }
            else
            {
                flowLayoutPanelDSNCC.Controls.Clear();
                flowLayoutPanelDSNCC.Visible = false;
            }
        }


        private void buttonThemHangHoa_Click(object sender, EventArgs e)
        {

        }


        //stt
        private int CapNhatSTT()
        {
            int stt = 1;
            foreach (Control control in flowLayoutPanelNhapHang.Controls)
            {
                if (control is UserControlHangHoaitemNhapHang item)
                {
                    item.SetSTT(stt);
                    stt++;
                }
            }
            return stt - 1; // Trả về số lượng hàng hóa đã thêm
        }


        private void textBoxTimHangHoa_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            string searchText = textBoxTimHangHoa.Text.Trim();

            // Tìm kiếm khi có ký tự nhập vào
            if (!string.IsNullOrEmpty(searchText) && searchText.Length >= 1)
            {
                // Lấy danh sách hàng hóa phù hợp
                List<ClassHangHoa> danhSachHangHoa = ClassHangHoa.TimKiemHangHoaTheoTuKhoa(searchText);

                // Xóa kết quả cũ
                panelKetQuaTimKiem.Controls.Clear();

                foreach (ClassHangHoa hh in danhSachHangHoa)
                {

                    var userControlHangHoa = new UC_ItemThuoc();
                    userControlHangHoa.SetData(hh);
                    userControlHangHoa.Dock = DockStyle.Top; // Đặt dock để tự động điều chỉnh chiều rộng
                    // Gắn sự kiện Click để thêm vào danh sách nhập hàng
                    userControlHangHoa.Click += (s, args) =>
                    {
                        // Kiểm tra mã hàng hóa đã tồn tại chưa
                        var hangHoaDaCo = flowLayoutPanelNhapHang.Controls
                            .OfType<UserControlHangHoaitemNhapHang>()
                            .FirstOrDefault(x => x.MaHangHoa == hh.MaHangHoa);

                        if (hangHoaDaCo != null)
                        {
                            // Nếu đã có, tăng số lượng lên 1
                            hangHoaDaCo.SoLuong += 1;
                            TinhTongTien();
                            textBoxTimHangHoa.Clear();
                            panelKetQuaTimKiem.Visible = false;
                            return;
                        }
                        var itemHangHoaNhapHang = new UserControlHangHoaitemNhapHang(_maPhieuNhap);
                        itemHangHoaNhapHang.setData(hh);

                        // Đặt chiều rộng chính xác khi thêm
                        itemHangHoaNhapHang.Width = flowLayoutPanelNhapHang.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                        itemHangHoaNhapHang.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                        flowLayoutPanelNhapHang.Controls.Add(itemHangHoaNhapHang);

                        labelSoLuongHH.Text = CapNhatSTT().ToString();

                        TinhTongTien();


                        textBoxTimHangHoa.Clear();
                        panelKetQuaTimKiem.Visible = false;

                        //gan su kien click cho buttonX_Click trong itemhangHoaNhapHang
                        itemHangHoaNhapHang.buttonXoa.Click += (s2, args2) =>
                        {
                            flowLayoutPanelNhapHang.Controls.Remove(itemHangHoaNhapHang);

                            labelSoLuongHH.Text = CapNhatSTT().ToString();

                            TinhTongTien();
                        };

                        itemHangHoaNhapHang.ThayDoiSoLuongHoacDonGia += (s3, e3) =>
                        {
                            TinhTongTien();
                        };


                    };
                    //gan su kien khi click vao nut xoa hang hoa tren tung hang hoa

                    panelKetQuaTimKiem.Controls.Add(userControlHangHoa);
                }

                panelKetQuaTimKiem.Visible = danhSachHangHoa.Any();
            }
            else
            {
                panelKetQuaTimKiem.Controls.Clear();
                panelKetQuaTimKiem.Visible = false;
            }
        }


        private void FormThemNhapHang_Load(object sender, EventArgs e)
        {
            //add usecontrolNhapHang vao 
            UserControlNhapHang userControlNhapHang = new UserControlNhapHang();
            userControlNhapHang.Width = flowLayoutPanelNhapHang.Width - 25; // Trừ khoảng cuộn nếu có
            userControlNhapHang.Height = 60; // hoặc theo nhu cầu

            // Nếu muốn auto size chiều cao theo nội dung:
            userControlNhapHang.AutoSize = false;
            userControlNhapHang.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            flowLayoutPanelNhapHang.Controls.Add(userControlNhapHang);


            flowLayoutPanelNhapHang.Resize += flowLayoutPanelNhapHang_Resize;
        }


        public string loaithem = ""; // Biến để lưu loại thêm hàng hóa (nếu cần)
        private void buttonThemHangHoa_Click_1(object sender, EventArgs e)
        {
            panelThemHH.Visible = true;
        }




        private void buttonHangHoa_Click(object sender, EventArgs e)
        {
            loaithem = "hanghoa"; // Đặt loại thêm hàng hóa
            //mo form them hang hoa
            var formThemHangHoa = new FormThemHanghoa(loaithem, this);
            formThemHangHoa.ShowDialog();
            // Sau khi thêm hàng hóa, cập nhật lại danh sách hàng hóa
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm thuốc

        }


        private void buttonThuoc_Click(object sender, EventArgs e)
        {
            loaithem = "T"; // Đặt loại thêm thuốc
            // Mở form thêm thuốc
            FormThemThuoc formThemThuoc = new FormThemThuoc(loaithem, this);
            formThemThuoc.ShowDialog();
            // Sau khi thêm thuốc, cập nhật lại danh sách thuốc
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm thuốc

        }

        private void flowLayoutPanelNhapHang_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelNhapHang.Controls)
            {
                ctrl.Width = flowLayoutPanelNhapHang.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void comboBoxTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi người dùng chọn tài khoản, cập nhật thông tin hiển thị
            if (comboBoxTaiKhoan.SelectedItem is ClassTaiKhoan taiKhoan)
            {
                comboBoxTaiKhoan.Text = taiKhoan.TenHienThi; // Hiển thị tên hiển thị của tài khoản
            }
            else
            {
                comboBoxTaiKhoan.Text = "Chưa chọn tài khoản";
            }
        }




        //tinh tien 
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (Control control in flowLayoutPanelNhapHang.Controls)
            {
                if (control is UserControlHangHoaitemNhapHang item)
                {
                    tongTien += item.ThanhTien;
                }
            }

            textBoxTongTien.Text = tongTien.ToString("N0");
        }






        private void TinhSoTienCanTra()
        {
            // Lấy và xử lý tổng tiền hàng
            decimal tongTien = 0;
            if (!decimal.TryParse(textBoxTongTien.Text.Replace(" đ", "").Replace(",", ""), out tongTien))
                tongTien = 0;

            // Lấy và xử lý giá trị giảm giá
            decimal giamGia = 0;

            if (!decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", "").Replace("%", ""), out giamGia))
                giamGia = 0;

            // Tính số tiền cần trả
            decimal soTienCanTra = tongTien - giamGia;
            if (soTienCanTra < 0) soTienCanTra = 0;

            textBoxCanTra.Text = soTienCanTra.ToString("N0") + " đ";

        }



        //bien luu giam tri giam gia 
        private decimal GiaTriGiamGia;
        private string LoaiGiamGia = "VND"; // hoặc "%"
        private void textBoxGiamGia_Click(object sender, EventArgs e)
        {
            FormGiamGia formGiamGia = new FormGiamGia();

            // Cấu hình form popup: chỉ hiện nút X
            formGiamGia.FormBorderStyle = FormBorderStyle.FixedSingle;
            formGiamGia.MaximizeBox = false;
            formGiamGia.MinimizeBox = false;
            formGiamGia.ControlBox = true;
            formGiamGia.ShowIcon = false;
            formGiamGia.ShowInTaskbar = false;


            formGiamGia.CoSuThayDoiGiamGia += (s, args) =>
            {
                LoaiGiamGia = formGiamGia.LoaiGiamGia;
                GiaTriGiamGia = formGiamGia.GiaTriNhapGiamGia;

                decimal soTienGiam = formGiamGia.TinhSoTienGiamGia();
                textBoxGiamGia.Text = soTienGiam.ToString("N0") + " đ";

                if (LoaiGiamGia == "%")
                    labelPhanTramGiam.Text = $"({GiaTriGiamGia.ToString("0.##")}%)";
                else
                    labelPhanTramGiam.Text = "";

                TinhSoTienCanTra(); // cập nhật lại số tiền cần trả
            };


            // Tính tọa độ màn hình của TextBox
            Point viTriManHinh = textBoxGiamGia.PointToScreen(Point.Empty);
            int formX = viTriManHinh.X;
            int formY = viTriManHinh.Y + textBoxGiamGia.Height;

            // Kích thước popup
            int popupWidth = formGiamGia.Width;
            int popupHeight = formGiamGia.Height;

            // Giới hạn hiển thị trong màn hình
            Rectangle screenBounds = Screen.GetWorkingArea(this);

            // Nếu tràn ngang, đẩy về bên trái
            if (formX + popupWidth > screenBounds.Right)
                formX = screenBounds.Right - popupWidth;

            // Nếu tràn dọc, hiển thị lên trên textbox
            if (formY + popupHeight > screenBounds.Bottom)
                formY = viTriManHinh.Y - popupHeight;

            // Gán vị trí và hiển thị form
            formGiamGia.StartPosition = FormStartPosition.Manual;
            formGiamGia.Location = new Point(formX, formY);
            formGiamGia.Show();

            //truyen gia tri cu truoc do 
            if (decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", ""), out decimal giamGia))
            {
                formGiamGia.GiaTriNhapGiamGia = giamGia; // Truyền giá trị giảm giá vào formGiamGia
            }
            else
            {
                formGiamGia.GiaTriNhapGiamGia = 0; // Nếu không parse được, đặt giá trị giảm giá là 0
            }

            //truyen tong tien hang vao formGiamGia
            formGiamGia.tongTienHang = decimal.Parse(textBoxTongTien.Text.Replace(" đ", "").Replace(",", ""));
        }

        private void textBoxTongTien_TextChanged(object sender, EventArgs e)
        {
            TinhSoTienCanTra();
        }


        private void LuuPhieuNhap(string trangThai, bool capNhatTonKho, bool taoPhieuChi)
        {
            var danhSachHangHoa = flowLayoutPanelNhapHang.Controls.OfType<UserControlHangHoaitemNhapHang>().ToList();
            if (danhSachHangHoa.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một hàng hóa vào phiếu nhập!",
                    "Thiếu hàng hóa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //kiem tra chon tai khoan hay chua 

            if (comboBoxTaiKhoan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản trước khi lưu phiếu nhập!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = 0;
            decimal.TryParse(textBoxTongTien.Text.Replace(" đ", "").Replace(",", "").Trim(), out tongTien);

            decimal soTienTraNCC = 0;
            decimal.TryParse(textBoxSoTienTraNCC.Text.Replace(" đ", "").Replace(",", "").Trim(), out soTienTraNCC);

            string maPhieuNhap = textBoxMaPhieuNhap.Text.Trim();

            string tentaikhoan = comboBoxTaiKhoan.SelectedValue?.ToString();
            string maNhanVien = ClassTaiKhoan.LayTaiKhoan(tentaikhoan).MaNhanVien;

            DateTime ngayTao = DateTime.Now;
            DateTime ngayNhapHang = DateTime.Now;

            decimal soTienGiam = LoaiGiamGia == "%" ? (tongTien * (GiaTriGiamGia / 100)) : GiaTriGiamGia;
            decimal soTienCanTra = tongTien - soTienGiam;
            if (soTienCanTra < 0) soTienCanTra = 0;

            string ghiChu = textBoxGhiChu.Text.Trim();

            var phieuNhap = new ClassPhieuNhapHang
            {
                MaPhieuNhap = maPhieuNhap,
                NgayTaoPhieu = ngayTao,
                MaNhaCungCap = maNCCdachon,
                MaNhanVien = maNhanVien,
                TongTienNhapHang = tongTien,
                GiamGia = GiaTriGiamGia,
                SoTienPhaiTra = soTienCanTra,
                SoTienDaTra = soTienTraNCC,
                GhiChuPhieuNhap = ghiChu,
                NgayNhap = ngayNhapHang,
                TrangThai = trangThai
            };

            bool phieuDaTonTai = ClassPhieuNhapHang.KiemTraTonTai(maPhieuNhap);
            if (phieuDaTonTai)
            {
                ClassPhieuNhapHang.CapNhatPhieuNhap(phieuNhap);
                ClassChiTietPhieuNhap.XoaChiTietPhieuNhap(maPhieuNhap);
            }
            else
            {
                if (!ClassPhieuNhapHang.ThemPhieuNhap(phieuNhap))
                {
                    MessageBox.Show("Lưu phiếu nhập thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            foreach (var item in danhSachHangHoa)
            {
                var chiTiet = new ClassChiTietPhieuNhap
                {
                    MaPhieuNhap = maPhieuNhap,
                    MaHangHoa = item.MaHangHoa,
                    MaDonViTinh = item.MaDonViTinh,
                    GiamGia = item.GiamGia,
                    TenHangHoa = item.TenHangHoa,
                    SoLuong = (int)item.SoLuong,
                    DonGia = item.DonGia,
                    ThanhTien = item.ThanhTien
                };
                ClassChiTietPhieuNhap.ThemChiTietPhieuNhap(chiTiet);
            }

            if (capNhatTonKho)
            {
                foreach (var hh in danhSachHangHoa)
                {
                    ClassHangHoa.CapNhatSoLuongTon(hh.MaHangHoa, (int)hh.SoLuong);
                }
            }

            if (taoPhieuChi)
            {
                ClassPhieuThuChi classPhieuThuChi = new ClassPhieuThuChi
                {
                    MaPhieuThuChi = ClassPhieuThuChi.TaoMaPhieuChi(),
                    MaLoaiPhieu = "CHI",
                    MaHinhThucThanhToan = "HTTT_TM",
                    MaPhieuNhap = maPhieuNhap,
                    MaNhaCungCap = maNCCdachon,
                    MaNhanVien = maNhanVien,
                    SoTien = soTienTraNCC,
                    NgayLapPhieu = DateTime.Now,
                    NoiDung = "Thanh toán phiếu nhập hàng " + maPhieuNhap,
                    TrangThaiThanhToan = "Đã chi"
                };
                ClassPhieuThuChi.ThemPhieuChi(classPhieuThuChi);
            }

            labelTrangThai.Text = trangThai;
            MessageBox.Show($"Phiếu nhập đã được {trangThai.ToLower()}!",
                "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }



        private void buttonLuuTam_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNCCdachon))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp trước khi hoàn tất phiếu nhập!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal tongTien = 0;
            decimal.TryParse(textBoxTongTien.Text.Replace(" đ", "").Replace(",", "").Trim(), out tongTien);

            decimal soTienTraNCC = 0;
            decimal.TryParse(textBoxSoTienTraNCC.Text.Replace(" đ", "").Replace(",", "").Trim(), out soTienTraNCC);
            if (soTienTraNCC < tongTien)
            {
                MessageBox.Show("Vui lòng thanh toán phiếu nhập!");
                return;
            }

            LuuPhieuNhap("Lưu tạm", capNhatTonKho: false, taoPhieuChi: false);
        }



        private void buttonHoanThanh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(maNCCdachon))
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp trước khi hoàn tất phiếu nhập!",
                    "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = 0;
            decimal.TryParse(textBoxTongTien.Text.Replace(" đ", "").Replace(",", "").Trim(), out tongTien);

            decimal soTienTraNCC = 0;
            decimal.TryParse(textBoxSoTienTraNCC.Text.Replace(" đ", "").Replace(",", "").Trim(), out soTienTraNCC);

            if (soTienTraNCC < tongTien)
            {
                MessageBox.Show("Vui lòng thanh toán phiếu nhập!");
                return;
            }

            LuuPhieuNhap("Đã nhập hàng", capNhatTonKho: true, taoPhieuChi: true);
        }



    }
}
