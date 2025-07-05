using Microsoft.VisualBasic.Devices;
using QL_Nha_thuoc.DoiTac;
using QL_Nha_thuoc.HangHoa;
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
using QL_Nha_thuoc.DoiTac.khachhang;
namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlFormHoaDon : UserControl
    {
        public UserControlFormHoaDon()
        {
            InitializeComponent();
        }
        //load comboxboxtaikhoan
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UserControlFormHoaDon? FormHoaDonCha { get; set; }

        public void LoadTaiKhoan()
        {
            var danhSachTaiKhoan = ClassTaiKhoan.LayDanhSachTaiKhoan();
            comboBoxTaiKhoan.DataSource = danhSachTaiKhoan;
            comboBoxTaiKhoan.DisplayMember = "TenHienThi"; // sử dụng thuộc tính mới
            comboBoxTaiKhoan.ValueMember = "TenTaiKhoan";
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



        public void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoa item)
                {
                    decimal giaBan = item.GiaBan;
                    decimal soLuongMua = item.SoLuong;
                    decimal soLuongTon = item.SoLuongTon;

                    if (soLuongMua <= 10)
                    {
                        item.SoLuongControl.BackColor = Color.White; // Màu hợp lệ
                        tongTien += giaBan * soLuongMua;
                    }
                    else
                    {
                        item.SoLuongControl.BackColor = Color.LightCoral; // Màu cảnh báo
                    }
                }
            }

            textBoxSoTienCanTra.Text = tongTien.ToString("N0") + " đ";
        }



        public void ThemHang(string ten, string mah, float giaBan)
        {
            var item = new UserControlHangHoa();
            item.SetData(ten, mah, giaBan);

            // Gắn sự kiện thay đổi số lượng/gía
            item.SoLuongHoacGiaThayDoi += (s, e) =>
            {
                CapNhatTongTien();
            };

            // Gắn sự kiện xóa hàng
            item.XoaYeuCau += (s, e) =>
            {
                flowLayoutPanelTTHH.Controls.Remove(item); // Xóa control khỏi danh sách
                CapNhatTongTien(); // Cập nhật lại tổng tiền
            };
            item.DonViThayDoi += (s, e) =>
            {
                CapNhatTongTien();
            };

            item.Margin = new Padding(0, 5, 0, 0);
            flowLayoutPanelTTHH.Controls.Add(item);

            CapNhatTongTien();
        }



        private void flowLayoutPanelTTHH_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                ctrl.Width = flowLayoutPanelTTHH.ClientSize.Width - flowLayoutPanelTTHH.Padding.Horizontal - 5;
            }
        }


        public decimal TongTiencantra;




        public decimal TinhTongTien()
        {
            decimal tongTien = 0;

            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoa item)
                {
                    decimal giaBan = item.GiaBan;
                    decimal soLuongMua = item.SoLuong;
                    decimal soLuongTon = item.SoLuongTon;

                    if (soLuongMua <= 10)
                    {
                        tongTien += giaBan * soLuongMua;
                    }
                    else
                    {
                        // Có thể báo lỗi, hoặc đánh dấu màu
                        item.BackColor = Color.LightCoral;
                    }
                }
            }

            return tongTien;
        }
        private void textBoxGiamGia_Click(object sender, EventArgs e)
        {
            //hien panel
            if (panelGiamGia != null)
                panelGiamGia.Visible = !panelGiamGia.Visible;
            radioButtonVND.Checked = true; // Mặc định chọn VND
            //cap nhat tong tien khi click vao textbox giam gia
            //cap nhat tien khach can tra
            textBoxGiamGia.Text = textBoxNhapGiamGia.Text; // Đặt giá trị mặc định là 0
            textBoxSoTienCanTra.Text = giacuoicung.ToString(); // Hiển thị tiền khách cần trả
            //cap nhat textbox giam gia
        }


        decimal giacuoicung;
        private void textBoxNhapGiamGia_TextChanged(object sender, EventArgs e)
        {
            decimal tongTien = TinhTongTien();
            //neu chon VND thi tinh giam gia theo VND
            if (radioButtonVND.Checked)
            {
                if (decimal.TryParse(textBoxNhapGiamGia.Text, out decimal giamGiaVND))
                {
                    decimal tongTienSauGiamGia = tongTien - giamGiaVND;
                    //neu tongTienSauGiamGia < 0 thi khong tinh giam gia
                    if (tongTienSauGiamGia < 0)
                    {
                        MessageBox.Show("Số tiền giảm giá không thể lớn hơn tổng tiền hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoTienCanTra.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                        return;
                    }
                    else if (tongTienSauGiamGia >= 0)
                    {
                        //neu tongTienSauGiamGia >= 0 thi tinh giam gia
                        //labelTongTienHang.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền trước giảm giá
                        textBoxSoTienCanTra.Text = tongTienSauGiamGia.ToString("N0") + " đ"; // Hiển thị tiền khách cần trả sau giảm giá
                    }
                    else if (giamGiaVND < 0)
                    {
                        MessageBox.Show("Số tiền giảm giá không thể nhỏ hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoTienCanTra.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                        return;
                    }
                    //truyen tien giam gia vao textbox
                    textBoxGiamGia.Text = giamGiaVND.ToString("N0"); // Hiển thị với định dạng tiền tệ
                }
                else
                {
                    //labelTongTienHang.Text = TinhTongTien().ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                }
                //truyen so tien can tra vao bien giacuoicung
                decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", ""), out decimal giamGia);
                giacuoicung = tongTien - giamGia;
           }
            else if (radioButtonPhanTram.Checked)
            {
                if (decimal.TryParse(textBoxNhapGiamGia.Text, out decimal giamGiaPhanTram))
                {
                    decimal giamGiaVND = tongTien * (giamGiaPhanTram / 100);
                    decimal tongTienSauGiamGia = tongTien - giamGiaVND;
                    //neu tongTienSauGiamGia < 0 thi khong tinh giam gia
                    if (tongTienSauGiamGia < 0)
                    {
                        MessageBox.Show("Số tiền giảm giá không thể lớn hơn tổng tiền hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoTienCanTra.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                        return;
                    }
                    else if (tongTienSauGiamGia >= 0)
                    {
                        //neu tongTienSauGiamGia >= 0 thi tinh giam gia
                        //labelTongTienHang.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền trước giảm giá
                        textBoxSoTienCanTra.Text = tongTienSauGiamGia.ToString("N0") + " đ"; // Hiển thị tiền khách cần trả sau giảm giá
                    }
                    else if (giamGiaPhanTram < 0)
                    {
                        MessageBox.Show("Số tiền giảm giá không thể nhỏ hơn 0.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoTienCanTra.Text = tongTien.ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                        return;
                    }

                    //truyen tien giam gia vao textbox
                    textBoxGiamGia.Text = giamGiaVND.ToString("N0"); // Hiển thị với định dạng tiền tệ

                }
                else
                {
                    labelTongTienHang.Text = TinhTongTien().ToString("N0") + " đ"; // Hiển thị tổng tiền nếu không hợp lệ
                }
                decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", ""), out decimal giamGia);
                giacuoicung = tongTien - giamGia;
            }
            //tienh tien khach hang can tra
        }

        private void radioButtonPhanTram_Click(object sender, EventArgs e)
        {
            //neu kich thi quy doi textBoxNhapGiamGia sang phan tram
            if (radioButtonPhanTram.Checked)
            {
                if (decimal.TryParse(textBoxNhapGiamGia.Text, out decimal giamGiaVND))
                {
                    decimal tongTien = TinhTongTien();
                    if (tongTien != 0)
                    {
                    decimal giamGiaPhanTram = (giamGiaVND / tongTien) * 100;
                    textBoxNhapGiamGia.Text = giamGiaPhanTram.ToString("N2"); // Hiển thị với 2 chữ số thập phân
                    }

                }
            }
        }

        private void radioButtonVND_Click(object sender, EventArgs e)
        {
            //thi quy doi textBoxNhapGiamGia sang VND
            if (radioButtonVND.Checked)
            {
                if (decimal.TryParse(textBoxNhapGiamGia.Text, out decimal giamGiaPhanTram))
                {
                    decimal tongTien = TinhTongTien();
                    decimal giamGiaVND = tongTien * (giamGiaPhanTram / 100);
                    textBoxNhapGiamGia.Text = giamGiaVND.ToString("N0"); // Hiển thị với định dạng tiền tệ
                }
            }
        }




        //load du lieu len form
        private void UserControlFormHoaDon_Load(object sender, EventArgs e)
        {
            // Thiết lập kích thước cho các control trong flowLayoutPanelTTHH
            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                ctrl.Width = flowLayoutPanelTTHH.ClientSize.Width - flowLayoutPanelTTHH.Padding.Horizontal - 5;
            }
            // Thiết lập sự kiện cho các control trong flowLayoutPanelTTHH
            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoa item)
                {
                    item.SoLuongHoacGiaThayDoi += (s, e) => CapNhatTongTien();
                    item.XoaYeuCau += (s, e) =>
                    {
                        flowLayoutPanelTTHH.Controls.Remove(item);
                        CapNhatTongTien();
                    };
                }
            }
            // Cập nhật tổng tiền ban đầu
            labelTongTienHang.Text = TinhTongTien().ToString("N0") + " đ"; // Hiển thị tổng tiền ban đầu
            textBoxSoTienCanTra.Text = TinhTongTien().ToString("N0") + " đ"; // Hiển thị tiền khách cần trả ban đầu
            textBoxGiamGia.Text = "0 đ"; // Đặt giá trị mặc định là 0
            textBoxNhapGiamGia.Text = "0"; // Đặt giá trị mặc định là 0
            textBoxSoTienKhachDua.Text = "0"; // Đặt giá trị mặc định là 0
            textBoxTienTraLai.Text = "0 đ"; // Đặt giá trị mặc định là 0
            radioButtonVND.Checked = true; // Mặc định chọn VND
            panelGiamGia.Visible = false; // Ẩn panel giam gia ban đầu
            //load thoi gian hien tai
            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void textBoxSoTienKhachDua_TextChanged(object sender, EventArgs e)
        {
            //tinh tien trả lại cho khách hàng
            if (decimal.TryParse(textBoxSoTienKhachDua.Text, out decimal soTienKhachDua) && decimal.TryParse(textBoxSoTienCanTra.Text.Replace(" đ", "").Replace(",", ""), out decimal soTienCanTra))
            {
                if (soTienKhachDua >= soTienCanTra)
                {
                    decimal tienTraLai = soTienKhachDua - soTienCanTra;
                    textBoxTienTraLai.Text = tienTraLai.ToString("N0") + " đ"; // Hiển thị tiền trả lại với định dạng tiền tệ
                }
                else
                {
                    textBoxTienTraLai.Text = "0 đ"; // Nếu tiền khách đưa không đủ, hiển thị 0
                }
            }
            else
            {
                textBoxTienTraLai.Text = "0 đ"; // Nếu không thể chuyển đổi, hiển thị 0
            }
        }


        // Biến để lưu khách hàng đã chọn
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ClassKhachHang? KhachHangDuocChon { get; set; }
        private void textBoxTimKH_TextChanged(object sender, EventArgs e)
        {
            //khi nhap vao hien thi 
            flowLayoutPanelDanhSachKhachHang.BringToFront(); // Đưa flowLayoutPanelDanhSachKhachHang lên trên cùng
            flowLayoutPanelDanhSachKhachHang.Controls.Clear(); // Xóa tất cả các control hiện tại trong flowLayoutPanelDanhSachKhachHang
            // Lấy giá trị tìm kiếm từ textBoxTimKH
            string searchText = textBoxTimKH.Text.Trim().ToLower(); // Lấy giá trị tìm kiếm và chuyển về chữ thường
            // Kiểm tra nếu không có giá trị tìm kiếm thì hiển thị tất cả khách hàng
            if (string.IsNullOrWhiteSpace(searchText))
            {
                flowLayoutPanelDanhSachKhachHang.Visible = false; // Ẩn flowLayoutPanelDanhSachKhachHang nếu không có giá trị tìm kiếm
                return;
            }
            flowLayoutPanelDanhSachKhachHang.Visible = true; // Hiển thị flowLayoutPanelDanhSachKhachHang
            //them usecontrolkhachhangitem vao flowlayoutpanelkhachhang
            List<ClassKhachHang> danhSachKhachHang = ClassKhachHang.LayDanhSachKhachHang();
            // Nếu không có giá trị tìm kiếm, hiển thị tất cả các mặt hàng
            foreach (var item in danhSachKhachHang)
            {
                UserControlKhachHangitem khachHangItem = new UserControlKhachHangitem();
                khachHangItem.Setdata(item);
                // Sự kiện click: gán tên vào textbox và lưu mã khách hàng
                khachHangItem.Click += (s, e2) =>
                {
                    textBoxTimKH.Text = $"{item.TenKH} ({item.MaKH})";
                    KhachHangDuocChon = item;
                    flowLayoutPanelDanhSachKhachHang.Visible = false;
                };
                flowLayoutPanelDanhSachKhachHang.Controls.Add(khachHangItem);

            }
        }

        private void buttonThemKhachHang_Click(object sender, EventArgs e)
        {
            // Open the form to add a customer
            FormThem_Suakhachhang formThemKhachHang = new FormThem_Suakhachhang();
            formThemKhachHang.FormClosed += (s, args) =>
            {
                // After the form is closed, update the customer list
                textBoxTimKH_TextChanged(null, null);
            };
            formThemKhachHang.Show(); // Ensure the form is displayed
        }

    }
}
