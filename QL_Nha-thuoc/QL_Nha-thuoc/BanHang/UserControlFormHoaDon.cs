using QL_Nha_thuoc.DoiTac.khachhang;
using QL_Nha_thuoc.model;
using System.ComponentModel;
using System.Reflection;
namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlFormHoaDon : UserControl
    {
        public UserControlFormHoaDon()
        {
            InitializeComponent();
            LoadTaiKhoan(); // Gọi hàm để load tài khoản khi khởi tạo
            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            radioButtonTienMat.Checked = true; // Mặc định chọn thanh toán bằng tiền mặt
            textBoxGiamGia.Text = "0 đ"; // Đặt giá trị mặc định là 0
            textBoxSoTienKhachThanhToan.Text = "0 đ"; // Đặt giá trị mặc định là 0
            textBoxKhachCanTra.Text = "0 đ"; // Đặt giá trị mặc định là 0
            textBoxTienTraLai.Text = "0 đ"; // Đặt giá trị mặc định là 0
            radioButtonTienMat.Checked = true;
            labelTongTienHang.Text = "0 đ";
        }

        //load comboxboxtaikhoan
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public UserControlFormHoaDon? FormHoaDonCha { get; set; }

        //ham load tai khoan vao comboboxTaiKhoan
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





        //ham cap nhat tong tien cho usercontrolHangHoa
        public void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoa item)
                {
                    decimal thanhtienHH = item.thanhTienHH;
                    tongTien = tongTien + thanhtienHH; // Cộng dồn thành tiền của từng hàng hóa
                }
            }

            labelTongTienHang.Text = tongTien.ToString("N0") + " đ";
        }









        private int CapNhatSTT()
        {
            int stt = 1;
            foreach (Control control in flowLayoutPanelTTHH.Controls)
            {
                if (control is UserControlHangHoa item)
                {
                    item.SetSTT(stt);
                    stt++;
                }
            }
            return stt - 1; // Trả về số lượng hàng hóa đã thêm
        }


        //hang them usercontrolHanghoa vao flowlayoutpanelTTHH
        public void ThemHang(ClassHangHoa hangHoa)
        {
            var item = new UserControlHangHoa();
            item.SetData(hangHoa);
            //item.TinhThanhTien(); // Tính thành tiền cho hàng mới thêm

            //// Gắn sự kiện thay đổi số lượng/gía
            //item.SoLuongHoacGiaThayDoi += (s, e) =>
            //{
            //    CapNhatTongTien();
            //};

            // Gắn sự kiện xóa hàng
            item.XoaHangHoaitem += (s, e) =>
            {
                flowLayoutPanelTTHH.Controls.Remove(item); // Xóa control khỏi danh sách
                CapNhatSTT(); // Cập nhật lại số thứ tự
                CapNhatTongTien(); // Cập nhật tổng tiền sau khi xóa
            };
            item.ThanhTienThayDoi += (s, e) =>
            {
                CapNhatTongTien();
            };
            item.Margin = new Padding(0, 5, 0, 0);
            flowLayoutPanelTTHH.Controls.Add(item);
            item.SetSTT(CapNhatSTT()); // Cập nhật số thứ tự cho hàng mới thêm
            item.TinhThanhTien(); // Tính thành tiền cho hàng mới thêm
            CapNhatTongTien();
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
            List<ClassKhachHang> danhSachKhachHang = ClassKhachHang.TimDanhSachKhachHangTheoTen(searchText);
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






        //bien luu giam tri giam gia 
        private decimal GiaTriGiamGia;
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

            // Gắn sự kiện khi thay đổi giảm giá thi hien thi ra trong textboxGiamGia
            formGiamGia.CoSuThayDoiGiamGia += (s, args) =>
            {
                // Gán giá trị giảm giá theo VND vào biến dùng chung
                GiaTriGiamGia = formGiamGia.TinhSoTienGiamGia();  // luôn là VND
                //neu la VND thi hien thi so tien giam
                if (formGiamGia.LoaiGiamGia == "VND")
                {
                    textBoxGiamGia.Text = GiaTriGiamGia.ToString("N0") + " đ";
                    labelPhanTramGiam.Text = "";
                }
                //neu la phan tram thi hien thi so tien giam theo VND va hien thi so % giam ra label
                else
                {
                    textBoxGiamGia.Text = GiaTriGiamGia.ToString("N0") + " đ";
                    labelPhanTramGiam.Text = "(" + formGiamGia.GiaTriNhapGiamGia.ToString("0.##") + " %)";
                }

                // Cập nhật số tiền cần trả sau khi so su thay doi giam gia 
                TinhSoTienCanTra();

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
            formGiamGia.tongTienHang = decimal.Parse(labelTongTienHang.Text.Replace(" đ", "").Replace(",", ""));
        }




























        private void TinhSoTienCanTra()
        {
            // Lấy và xử lý tổng tiền hàng
            decimal tongTien = 0;
            if (!decimal.TryParse(labelTongTienHang.Text.Replace(" đ", "").Replace(",", ""), out tongTien))
                tongTien = 0;

            // Lấy và xử lý giá trị giảm giá
            decimal giamGia = 0;
            if (!decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", "").Replace("%", ""), out giamGia))
                giamGia = 0;

            // Tính số tiền cần trả
            decimal soTienCanTra = tongTien - giamGia;
            if (soTienCanTra < 0) soTienCanTra = 0;

            textBoxKhachCanTra.Text = soTienCanTra.ToString("N0") + " đ";

            // GỌI UPDATE QR nếu đang ở chế độ chuyển khoản
            if (radioButtonChuyenKhoan.Checked)
            {
                // Kiểm tra xem panelThanhToanQR có chứa UserControl hay không
                foreach (Control control in panelThanhToanQR.Controls)
                {
                    if (control is UserControlThanhToanChuyenKhoan uc)
                    {
                        uc.CapNhatQRCode(soTienCanTra); // Truyền số tiền vào để update mã QR
                    }
                }
            }
        }



        //moi lan cap nhat tong tien la phai tinh lai so tien khach can tra
        private void labelTongTienHang_TextChanged(object sender, EventArgs e)
        {
            TinhSoTienCanTra();
        }

        private void radioButtonChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonChuyenKhoan.Checked)
            {
                // Ẩn các textbox/label liên quan đến tiền mặt
                labelTienThuaTraKhach.Visible = false;
                textBoxTienTraLai.Visible = false;
                labelKhachThanhToan.Visible = false;
                textBoxSoTienKhachThanhToan.Visible = false;

                // Hiện panel chuyển khoản
                panelThanhToanQR.Visible = true;

                // Xóa các control cũ nếu có
                panelThanhToanQR.Controls.Clear();

                // Thêm UserControl chuyển khoản
                var userControlThanhToanChuyenKhoan = new UserControlThanhToanChuyenKhoan();
                panelThanhToanQR.Controls.Add(userControlThanhToanChuyenKhoan);
                userControlThanhToanChuyenKhoan.Dock = DockStyle.Fill;
                TinhSoTienCanTra();
            }
        }


        private void radioButtonTienMat_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTienMat.Checked)
            {
                // Hiện các textbox/label liên quan đến tiền mặt
                labelTienThuaTraKhach.Visible = true;
                textBoxTienTraLai.Visible = true;
                labelKhachThanhToan.Visible = true;
                textBoxSoTienKhachThanhToan.Visible = true;

                // Ẩn panel chuyển khoản
                panelThanhToanQR.Visible = false;

                // Xóa control trong panel (nếu cần)
                panelThanhToanQR.Controls.Clear();
            }
        }

        private void textBoxSoTienKhachThanhToan_TextChanged(object sender, EventArgs e)
        {
            // Lấy số tiền khách thanh toán
            decimal tienKhachTra = 0;
            if (!decimal.TryParse(textBoxSoTienKhachThanhToan.Text.Replace(" đ", "").Replace(",", ""), out tienKhachTra))
            {
                tienKhachTra = 0;
            }

            // Lấy số tiền khách cần trả
            decimal soTienCanTra = 0;
            if (!decimal.TryParse(textBoxKhachCanTra.Text.Replace(" đ", "").Replace(",", ""), out soTienCanTra))
            {
                soTienCanTra = 0;
            }

            // Tính số tiền trả lại
            decimal tienTraLai = tienKhachTra - soTienCanTra;
            if (tienTraLai < 0) tienTraLai = 0;



            string text = textBoxSoTienKhachThanhToan.Text.Replace(",", "").Replace(" đ", "").Trim();

            if (decimal.TryParse(text, out decimal value))
            {
                // Gán lại text đã định dạng, không gắn đơn vị ở đây để tránh làm khó nhập
                textBoxSoTienKhachThanhToan.TextChanged -= textBoxSoTienKhachThanhToan_TextChanged; // Gỡ event để tránh lặp vô hạn
                textBoxSoTienKhachThanhToan.Text = value.ToString("N0");
                textBoxSoTienKhachThanhToan.SelectionStart = textBoxSoTienKhachThanhToan.Text.Length; // Đưa con trỏ về cuối
                textBoxSoTienKhachThanhToan.TextChanged += textBoxSoTienKhachThanhToan_TextChanged;
            }

            // Hiển thị ra TextBox
            textBoxTienTraLai.Text = tienTraLai.ToString("N0") + " đ";
        }

        private void textBoxSoTienKhachThanhToan_Leave(object sender, EventArgs e)
        {
            if (decimal.TryParse(textBoxSoTienKhachThanhToan.Text.Replace(" đ", "").Replace(",", ""), out decimal value))
            {
                textBoxSoTienKhachThanhToan.Text = value.ToString("N0") + " đ";
            }
        }

        private void textBoxSoTienKhachThanhToan_Enter(object sender, EventArgs e)
        {
            // Xóa định dạng tiền trước khi nhập
            textBoxSoTienKhachThanhToan.Text = textBoxSoTienKhachThanhToan.Text.Replace(" đ", "").Replace(",", "").Trim();

            // Chọn toàn bộ nội dung để người dùng gõ sẽ xóa hết
            textBoxSoTienKhachThanhToan.SelectAll();
        }
        private void textBoxSoTienKhachThanhToan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép số và phím điều khiển (Backspace, Delete...)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

    }
}