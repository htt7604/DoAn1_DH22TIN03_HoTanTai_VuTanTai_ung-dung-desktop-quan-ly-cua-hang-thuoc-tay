using QL_Nha_thuoc.BanHang.TRA_HANG;
using QL_Nha_thuoc.DoiTac.khachhang;
using QL_Nha_thuoc.model;
using QuestPDF.Fluent;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlFormHoaDon : UserControl
    {
        private string LoaiGiamGia = "VND"; // hoặc "%"
        public UserControlFormHoaDon(string maHoaDonMoi)
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
            
            maHoaDon = maHoaDonMoi;
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


        public void LoadHoaDonTraHang(ClassHoaDon hoaDon)
        {
            if (hoaDon == null) return;

            // Lưu mã
            this.maHoaDon = hoaDon.MaHoaDon;

            // Thời gian, khách hàng, nhân viên
            labelThoiGian.Text = hoaDon.NgayLapHD?.ToString("dd/MM/yyyy HH:mm:ss") ?? DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            if (!string.IsNullOrEmpty(hoaDon.TenKhachHang))
                textBoxTimKH.Text = $"{hoaDon.TenKhachHang} ({hoaDon.MaKH})";

            // Set khách hàng được chọn nếu có hàm lấy theo mã
            try
            {
                if (!string.IsNullOrEmpty(hoaDon.MaKH) && hoaDon.MaKH != "KH000")
                {
                    KhachHangDuocChon = ClassKhachHang.LayThongTinKhachHangTheoMa(hoaDon.MaKH); // bạn cần có phương thức này
                }
            }
            catch { /* nếu ko có hàm, bỏ qua */ }

            // Xóa hết items cũ
            XoaTatCaHangHoaTrongHoaDon();

            // Nạp chi tiết hóa đơn
            if (hoaDon.ChiTietHoaDon != null)
            {
                 var dschitietHD =ClassChiTietHoaDon.LayChiTietTheoHoaDon(hoaDon.MaHoaDon);
                foreach (var ct in dschitietHD)
                {
                    var hang = ClassHangHoa.LayThongTinHangHoa(ct.MaHangHoa);
                    var item = new UserControlHangHoa();
                    if (hang != null)
                    {
                        item.SetData(hang);
                    }
                    // Gán các thuộc tính từ chi tiết
                    item.SoLuong = ct.SoLuong ?? 0;
                    item.maDonViTinh = ct.MaDonViTinh ?? null; // sử dụng thuộc tính đúng     
                    item.GiaTriGiamGia = ct.GiamGia??0;
                    item.GiaSauGiam = ct.GiaBan ?? 0;                    // Tính lại và thêm
                    item.TinhThanhTien();
                    item.Margin = new Padding(0, 5, 0, 0);


                    flowLayoutPanelTTHH.Controls.Add(item);
                }

                // Cập nhật STT và tổng tiền
                CapNhatSTT();
                CapNhatTongTien();
            }

            // Cập nhật thông tin thanh toán (giảm giá, tổng, ...)
            labelTongTienHang.Text = (hoaDon.ThanhTien.HasValue ? hoaDon.ThanhTien.Value.ToString("N0") : "0") + " đ";
            textBoxGiamGia.Text = (hoaDon.GiamGia.HasValue ? hoaDon.GiamGia.Value.ToString("N0") : "0") + " đ";
            textBoxKhachCanTra.Text = hoaDon.ThanhTien.HasValue ? hoaDon.ThanhTien.Value.ToString("N0") + " đ" : "0 đ";
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
            if (LoaiGiamGia == "%")
            {
                if (decimal.TryParse(labelTongTienHang.Text.Replace(" đ", "").Replace(",", ""), out decimal tongTienHang))
                {
                    decimal soTienGiam = tongTienHang * GiaTriGiamGia / 100;
                    textBoxGiamGia.Text = soTienGiam.ToString("N0") + " đ";
                    labelPhanTramGiam.Text = $"({GiaTriGiamGia.ToString("0.##")}%)";
                }
            }

            TinhSoTienCanTra();
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string maHoaDon { get; set; }

        public string QRCodeUrl { get; private set; }

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

                // Tạo UserControl chuyển khoản
                // Truyền panelChonTaiKhoan của form vào UserControl
                var userControlThanhToanChuyenKhoan = new UserControlThanhToanChuyenKhoan(this.panelChonTaiKhoan,maHoaDon);
                panelThanhToanQR.Controls.Add(userControlThanhToanChuyenKhoan);

                // Đặt vị trí và kích thước ban đầu
                userControlThanhToanChuyenKhoan.Location = new Point(0, 0);
                userControlThanhToanChuyenKhoan.Size = panelThanhToanQR.ClientSize;

                // Gắn sự kiện Resize cho panel để điều chỉnh kích thước UserControl
                panelThanhToanQR.Resize += (s, e2) =>
                {
                    int padding = 10;
                    userControlThanhToanChuyenKhoan.Location = new Point(padding, padding);
                    userControlThanhToanChuyenKhoan.Size = new Size(
                        panelThanhToanQR.ClientSize.Width - 2 * padding,
                        panelThanhToanQR.ClientSize.Height - 2 * padding
                    );
                };
                userControlThanhToanChuyenKhoan.QRCodeUrlChanged += (qrUrl) =>
                {
                    // 👉 Lưu URL ra biến form, hoặc truyền vào class hóa đơn PDF
                    this.QRCodeUrl = qrUrl;
                };

                // Gọi tính toán số tiền
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












        //su kien thanh toan xong
        public event EventHandler ThanhToanThanhCong;


        //co bien luu khach hang r 
        private void buttonThanhToan_Click(object sender, EventArgs e)
        {

            if (flowLayoutPanelTTHH.Controls.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm nào trong hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (UserControlHangHoa item in flowLayoutPanelTTHH.Controls)
            {
                int soLuongBan = item.SoLuong;

                // Lấy hàng hóa từ CSDL
                ClassHangHoa hangHoa = ClassHangHoa.LayThongTinHangHoa(item.maHangHoa);

                if (hangHoa == null)
                {
                    MessageBox.Show($"Không tìm thấy thông tin hàng hóa có mã: {item.maHangHoa}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (soLuongBan > hangHoa.SoLuongTon)
                {
                    MessageBox.Show($"Số lượng bán của hàng hóa \"{hangHoa.TenHangHoa}\" vượt quá số lượng tồn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            // Tạo hóa đơn mới
            ClassHoaDon classHoaDon = new ClassHoaDon();

            // Gán mã hóa đơn tự động
            classHoaDon.MaHoaDon = maHoaDon;
            // Gán hình thức thanh toán
            if (radioButtonChuyenKhoan.Checked==true)
            {
                UserControlThanhToanChuyenKhoan _ucChuyenKhoan = new UserControlThanhToanChuyenKhoan(panelChonTaiKhoan, maHoaDon);
                classHoaDon.MaHinhThucThanhToan = "HTTT_CK";
                classHoaDon.MaTaiKhoanNganHang = _ucChuyenKhoan.MaTaiKhoanNganHangDangChon;
            }
            else if (radioButtonTienMat.Checked==true)
            {
               

                classHoaDon.MaHinhThucThanhToan = "HTTT_TM";

                decimal khachthanhtoan = 0;
                string khachthanhtoanText = textBoxSoTienKhachThanhToan.Text.Replace("đ", "").Replace(",", "").Trim();
                if (decimal.TryParse(khachthanhtoanText, out khachthanhtoan))
                    classHoaDon.KhachThanhToan = khachthanhtoan;
                else
                    classHoaDon.KhachThanhToan = 0;

                // Lấy tiền cần trả
                decimal tienCanTra = 0;
                string tienCanTraText = textBoxKhachCanTra.Text.Replace("đ", "").Replace(",", "").Trim();
                decimal.TryParse(tienCanTraText, out tienCanTra);

                decimal Tralaikhach = 0;
                string TralaikhachText = textBoxTienTraLai.Text.Replace("đ", "").Replace(",", "").Trim();
                if (decimal.TryParse(TralaikhachText, out Tralaikhach))
                    classHoaDon.TienTraKhach = Tralaikhach;
                else
                    classHoaDon.TienTraKhach = 0;



                // Kiểm tra nếu khách đưa < cần trả thì không cho thanh toán
                if (khachthanhtoan < tienCanTra)
                {
                    MessageBox.Show("Số tiền khách đưa không đủ để thanh toán!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Gán nhân viên đăng nhập hiện tại (đã lưu trong biến toàn cục)
            classHoaDon.MaNV = TaiKhoanNVThucHien?.MaNhanVien;

            // Gán mã khách hàng nếu có
            // Gán mã khách hàng nếu có, ngược lại dùng mã mặc định "KH000"
            classHoaDon.MaKH = KhachHangDuocChon?.MaKH ?? "KH000";

            // Gán ngày lập hóa đơn
            classHoaDon.NgayLapHD = DateTime.Now;

            // Gán mã bảng giá
            classHoaDon.MaBangGia =FormBanHangMain.BangGiaDuocChon?.MaBangGia;

            // Gán loại hóa đơn (cố định "BanHang" hoặc truyền biến tùy tình huống)
            classHoaDon.LoaiHoaDon = "BanHang";

            // Gán giảm giá toàn hóa đơn (nếu có)
            decimal giamGia = 0;
            string giamGiaText = textBoxGiamGia.Text.Replace("đ", "").Replace(",", "").Trim();
            if (decimal.TryParse(giamGiaText, out giamGia))
                classHoaDon.GiamGia = giamGia;
            else
                classHoaDon.GiamGia = 0;

            // Tính thành tiền tổng cộng (đã trừ giảm giá)
            decimal thanhTien = 0;
            string thanhTienText = textBoxKhachCanTra.Text.Replace("đ", "").Replace(",", "").Trim();
            if (decimal.TryParse(thanhTienText, out thanhTien))
                classHoaDon.ThanhTien = thanhTien;
            else
                classHoaDon.ThanhTien = 0;


            classHoaDon.TrangThai = "Hoàn thành";

            // Ghi chú (nếu có)
            classHoaDon.GhiChuHoaDon = textBoxGhiChu.Text.Trim();

            // Thêm vào CSDL
            bool thanhCong = ClassHoaDon.ThemHoaDon(classHoaDon);


            if (thanhCong) // Khi ThemHoaDon() trả về true
            {
                // Tạo danh sách chi tiết hóa đơn để in PDF
                List<ClassChiTietHoaDon> chiTietList = new List<ClassChiTietHoaDon>();

                decimal loiNhuan = 0;

                foreach (UserControlHangHoa item in flowLayoutPanelTTHH.Controls)
                {
                    ClassChiTietHoaDon ct = new ClassChiTietHoaDon
                    {
                        MaHoaDon = classHoaDon.MaHoaDon,
                        MaDonViTinh=item.maDonViTinh,
                        MaHangHoa = item.maHangHoa,
                        TenHangHoa = item._TenHangHoa,
                        SoLuong = item.SoLuong,
                        DonGiaBan = item.DonGiaGocHH,
                        GiamGia = item.GiaTriGiamGia,
                        GiaBan = item.GiaSauGiam,
                        ThanhTien = item.thanhTienHH,
                        SoLuongChuaTra=item.SoLuong, // Số lượng chưa trả (có thể là số lượng bán)

                    };

                    ct.ThemChiTiet(); // Thêm vào CSDL

                    chiTietList.Add(ct); // ➤ Thêm vào danh sách để in

                    ClassHangHoa.CapNhatSoLuongTon(item.maHangHoa, -item.SoLuong);

                    // Tính lợi nhuận
                    decimal giaVon = ClassHangHoa.LayThongTinTheoMaVaDonViTinh(item.maHangHoa, item.maDonViTinh).GiaVon;

                    // Lợi nhuận = (giá bán thực tế * số lượng) - (giá vốn * số lượng)
                    // Hoặc nếu bạn có trường giá bán và số lượng ở chi tiết, tính đúng theo đó
                    decimal loiNhuanMotMatHang = (item.thanhTienHH * item.SoLuong) - (giaVon * item.SoLuong);

                    loiNhuan += loiNhuanMotMatHang;
                }

                //tao phieu thu 
                // Tạo phiếu thu
                ClassPhieuThuChi phieuThu = new ClassPhieuThuChi();
                phieuThu.MaPhieuThuChi = ClassPhieuThuChi.TaoMaPhieuThu();  // Hàm bạn đã có
                phieuThu.MaLoaiPhieu = "THU";
                phieuThu.MaNhanVien = TaiKhoanNVThucHien?.MaNhanVien;
                phieuThu.MaHoaDon = classHoaDon.MaHoaDon;
                phieuThu.MaHinhThucThanhToan = classHoaDon.MaHinhThucThanhToan;
                phieuThu.NgayLapPhieu = DateTime.Now;
                phieuThu.NoiDung = $"Thu tiền từ hóa đơn {classHoaDon.MaHoaDon}";
                phieuThu.MaKhachHang = classHoaDon.MaKH;
                phieuThu.TrangThaiThanhToan = "Đã thu";
                phieuThu.LoiNhuan = loiNhuan;

                // Gán số tiền và thực thu
                if (classHoaDon.MaHinhThucThanhToan == "HTTT_TM")
                {
                    phieuThu.SoTien = classHoaDon.KhachThanhToan;
                    phieuThu.ThucThu = classHoaDon.KhachThanhToan;
                }
                else if (classHoaDon.MaHinhThucThanhToan == "HTTT_CK")
                {
                    phieuThu.SoTien = classHoaDon.ThanhTien;  // nếu CK, mặc định đủ
                    phieuThu.ThucThu = classHoaDon.ThanhTien;
                }

                // Lưu phiếu thu vào CSDL
                bool thuThanhCong = ClassPhieuThuChi.ThemPhieuThu(phieuThu);
                if (!thuThanhCong)
                {
                    MessageBox.Show("Lưu phiếu thu thất bại!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



                // Xóa giao diện sau khi xử lý xong

          


                MessageBox.Show("Thanh toán và lưu chi tiết thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ThanhToanThanhCong?.Invoke(this, EventArgs.Empty); // Gọi sự kiện thông báo đã trả hàng thành công
                // Sau khi thanh toán thành công -> In hóa đơn

                // Tạo tài liệu hóa đơn và in
                var doc = new HoaDonThanhToanDocument(classHoaDon, chiTietList, QRCodeUrl);
                doc.GeneratePdf("path.pdf");


                // Đường dẫn thư mục lưu file PDF
                string saveFolder = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-cua-hang-thuoc-tay\QL_Nha-thuoc\QL_Nha-thuoc\PHIEU_IN\HoaDonPDF";

                // Tạo tên file
                string fileName = $"HoaDon_{classHoaDon.MaHoaDon}.pdf";

                // Ghép đường dẫn đầy đủ
                string filePath = Path.Combine(saveFolder, fileName);
                try
                {
                    doc.GeneratePdf(filePath);
                    Process.Start("explorer", filePath); // Mở file PDF bằng Explorer
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



                flowLayoutPanelTTHH.Controls.Clear();

                labelTongTienHang.Text = "0 đ";
                textBoxGiamGia.Text = "0";
                textBoxKhachCanTra.Text = "0";
                textBoxSoTienKhachThanhToan.Text = "0";
                textBoxGhiChu.Clear();

            }


            else
            {
                MessageBox.Show("Lỗi khi lưu hóa đơn!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private ClassTaiKhoan TaiKhoanNVThucHien;
        private void comboBoxTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ép kiểu về ClassTaiKhoan nếu bạn gán dữ liệu trực tiếp là list<ClassTaiKhoan>
            TaiKhoanNVThucHien = comboBoxTaiKhoan.SelectedItem as ClassTaiKhoan;
        }
        public void XoaTatCaHangHoaTrongHoaDon()
        {
            flowLayoutPanelTTHH.Controls.Clear();
            CapNhatTongTien();
        }

    }
}