using QL_Nha_thuoc.model;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    public partial class UserControlFormTraHang : UserControl
    {
        private string _maHoaDonTra; // Biến lưu mã hóa đơn
        ClassHoaDon HoaDonTra;
        public UserControlFormTraHang(string maHoaDonTra)
        {
            InitializeComponent();
            _maHoaDonTra = maHoaDonTra;
            LoadTaiKhoan(); // Gọi hàm để load tài khoản khi khởi tạo
            LoadPhieuTraHang(); // Gọi hàm để load phiếu trả hàng khi khởi tạo
            HoaDonTra = ClassHoaDon.LayHoaDonTheoMa(maHoaDonTra);
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
        public void LoadPhieuTraHang()
        {

            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            labelMaHoaDon.Text = _maHoaDonTra;
            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            labelGiaGocHangTra.Text = "0 đ";
            labelTongTienHangTra.Text = "0 đ";
            var hoadon = ClassHoaDon.LayHoaDonTheoMa(_maHoaDonTra);
            if (hoadon != null)
            {
                textBoxKhachHang.Text = hoadon.TenKhachHang ?? "Khách lẻ";
                //labelGiaGocHangTra.Text=hoadon.ThanhTien.ToString() + " VNĐ";
            }
            else
            {
                MessageBox.Show("Không tìm thấy hóa đơn với mã: " + _maHoaDonTra, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int CapNhatSTT()
        {
            int stt = 1;
            foreach (Control control in flowLayoutPanelTTHH.Controls)
            {
                if (control is UserControlHangHoaTraHang item)
                {
                    item.SetSTT(stt);
                    stt++;
                }
            }
            return stt - 1; // Trả về số lượng hàng hóa đã thêm
        }
        //ham cap nhat tong tien cho usercontrolHangHoa
        public void CapNhatTongTien()
        {
            decimal tongTien = 0;

            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoaTraHang item)
                {
                    decimal thanhtienHH = item.thanhTienHH;
                    tongTien = tongTien + thanhtienHH; // Cộng dồn thành tiền của từng hàng hóa
                }
            }

            labelGiaGocHangTra.Text = tongTien.ToString("N0") + " đ";
            labelTongTienHangTra.Text = tongTien.ToString("N0") + " đ"; // Cập nhật tổng tiền
        }

        //hang them usercontrolHanghoa vao flowlayoutpanelTTHH
        public void ThemHangTraHang(ClassHangHoa hangHoa)
        {
            // 1. Kiểm tra xem hàng hóa đã tồn tại chưa
            foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
            {
                if (ctrl is UserControlHangHoaTraHang existingItem)
                {
                    if (existingItem.maHangHoa == hangHoa.MaHangHoa)
                    {
                        // Kiểm tra số lượng trả hiện tại
                        if (existingItem.SoLuong < existingItem.SoLuongBan)
                        {
                            existingItem.SoLuong += 1;
                            existingItem.TinhThanhTien();
                            CapNhatTongTien();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Số lượng trả không được vượt quá số lượng đã bán (" + existingItem.SoLuongBan + ")",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning
                            );
                        }
                        return; // Không thêm mới nữa
                    }
                }
            }

            // 2. Nếu chưa tồn tại → thêm mới
            var item = new UserControlHangHoaTraHang();
            item.SetData(hangHoa, _maHoaDonTra);
            // SetData phải gán luôn SoLuongBan dựa vào thông tin hóa đơn gốc
            item.TinhThanhTien();

            item.XoaHangHoaitem += (s, e) =>
            {
                flowLayoutPanelTTHH.Controls.Remove(item);
                CapNhatSTT();
                CapNhatTongTien();
            };

            item.ThanhTienThayDoi += (s, e) =>
            {
                CapNhatTongTien();
            };

            item.Margin = new Padding(0, 5, 0, 0);
            flowLayoutPanelTTHH.Controls.Add(item);
            item.SetSTT(CapNhatSTT());
            CapNhatTongTien();
        }

        private void textBoxPhiTraHang_TextChanged(object sender, EventArgs e)
        {
            // Lấy vị trí con trỏ trước khi format
            int selectionStart = textBoxPhiTraHang.SelectionStart;
            int lengthBefore = textBoxPhiTraHang.Text.Length;

            // Lấy tổng tiền hàng
            decimal tongTienTraHang = 0;
            if (decimal.TryParse(labelTongTienHangTra.Text.Replace(" đ", "").Replace(",", ""), out tongTienTraHang))
            {
                decimal phiTraHang = 0;
                if (decimal.TryParse(textBoxPhiTraHang.Text.Replace(" đ", "").Replace(",", ""), out phiTraHang))
                {
                    // Giới hạn phí ≤ 50% tổng tiền hàng
                    decimal phiToiDa = tongTienTraHang * 0.5m;
                    if (phiTraHang > phiToiDa)
                    {
                        MessageBox.Show(
                            $"Phí trả hàng không được vượt quá 50% tổng tiền hàng ({phiToiDa:N0} đ).",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                        phiTraHang = phiToiDa;
                    }

                    // Format lại với dấu phẩy
                    textBoxPhiTraHang.Text = phiTraHang.ToString("N0");

                    // Tính tiền trả khách
                    decimal tienTraKhach = tongTienTraHang - phiTraHang;
                    textBoxCanTraKhach.Text = tienTraKhach.ToString("N0") + " đ";
                }
                else
                {
                    textBoxCanTraKhach.Text = "0 đ";
                }
            }
            else
            {
                textBoxCanTraKhach.Text = "0 đ";
            }

            // Giữ lại vị trí con trỏ
            int lengthAfter = textBoxPhiTraHang.Text.Length;
            selectionStart += lengthAfter - lengthBefore;
            if (selectionStart < 0) selectionStart = 0;
            textBoxPhiTraHang.SelectionStart = selectionStart;
        }


        //tao sự kiện thông báo đã trả hàng xong 
        public event EventHandler TraHangThanhCong;
        public void buttonTraHang_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kiểm tra danh sách hàng trả
                if (flowLayoutPanelTTHH.Controls.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn ít nhất một hàng hóa để trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Lấy thông tin từ giao diện
                string maHoaDon = _maHoaDonTra;
                string maNhanVien = comboBoxTaiKhoan.SelectedValue?.ToString() ?? "";
                decimal tongTienHang = 0;
                decimal phiTraHang = 0;
                decimal tienTraKhach = 0;

                decimal.TryParse(labelTongTienHangTra.Text.Replace(" đ", "").Replace(",", ""), out tongTienHang);
                decimal.TryParse(textBoxPhiTraHang.Text.Replace(" đ", "").Replace(",", ""), out phiTraHang);
                decimal.TryParse(textBoxCanTraKhach.Text.Replace(" đ", "").Replace(",", ""), out tienTraKhach);

                // 3. Tạo đối tượng phiếu trả
                ClassPhieuTraHang phieuTra = new ClassPhieuTraHang
                {
                    MaPhieuTraHang = null, // Để null để tự sinh mã
                    MaNhanVien = TaiKhoanNVThucHien.MaNhanVien,
                    MaKhachHang = HoaDonTra.MaKH, // Có thể lấy từ hóa đơn gốc
                    MaHoaDon = maHoaDon,
                    MaHinhThucThanhToan = HoaDonTra.MaHinhThucThanhToan, // Có thể lấy từ combobox nếu có
                    MaBangGia = HoaDonTra.MaBangGia, // Có thể lấy từ hóa đơn gốc
                    TongGiaGocHangMua = tongTienHang,
                    TongTienTraHang = tongTienHang,
                    PhiTraHang = phiTraHang,
                    TienTraKhach = tienTraKhach,
                    NgayLapPhieuTra = DateTime.Now,
                    GhiChuPhieuTra = textBoxGhiCHuPhieu.Text , // Nếu có textbox ghi chú thì lấy
                    TrangThaiPhieuTra = "Đã hoàn thành" // Mặc định là chưa thanh toán
                };

                // 4. Lưu phiếu trả hàng vào DB
                bool themThanhCong = phieuTra.ThemPhieuTraHang(phieuTra);
                if (!themThanhCong)
                {
                    MessageBox.Show("Không thể tạo phiếu trả hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 5. Lấy mã phiếu trả vừa tạo
                string maPhieuTra = phieuTra.MaPhieuTraHang;

                // 6. Thêm chi tiết phiếu trả
                foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
                {
                    if (ctrl is UserControlHangHoaTraHang item)
                    {
                        // Giả sử bạn có ClassPhieuTraHangChiTiet để thêm vào DB
                        ClassChiTietPhieuTraHang chiTiet = new ClassChiTietPhieuTraHang
                        {
                            MaPhieuTraHang = maPhieuTra,
                            MaHangHoa = item.maHangHoa,
                            TenHangHoa = item._TenHangHoa,
                            MaDonViTinh = item.maDonViTinh,
                            SoLuongTra = item.SoLuong,
                            GiaTraHang = item.DonGiaGocHH,
                            ThanhTien = item.thanhTienHH
                        };
                        ClassChiTietPhieuTraHang.ThemChiTietTraHang(chiTiet);
                        ClassHangHoa.CapNhatSoLuongTon(item.maHangHoa, item.SoLuong);
                        // Cập nhật số lượng chưa trả trong hóa đơn gốc
                        if (item.SoLuong < item.SoLuongBan)
                        {
                            // Cập nhật số lượng chưa trả trong chi tiết hóa đơn
                            ClassChiTietHoaDon chiTietHoaDon = ClassChiTietHoaDon.LayChiTietTheoMaHDVaMaHH(maHoaDon, item.maHangHoa);
                            if (chiTietHoaDon != null)
                            {
                                chiTietHoaDon.SoLuongChuaTra -= item.SoLuong;
                                ClassChiTietHoaDon.CapNhatChiTiet(chiTietHoaDon);
                            }
                        }
                    }
                }

                //tao phieu thu chi 
                ClassPhieuThuChi classPhieuThuChi = new ClassPhieuThuChi
                {
                    MaPhieuThuChi = ClassPhieuThuChi.TaoMaPhieuChi(), // Để tự sinh mã
                    MaNhanVien = TaiKhoanNVThucHien.MaNhanVien,
                    MaPhieuTraHang = maPhieuTra,
                    NgayLapPhieu = DateTime.Now,
                    SoTien = tienTraKhach,
                    MaLoaiPhieu = "CHI",
                    MaHinhThucThanhToan = "HTTT_TM"
                };
                //classPhieuThuChi.MaPhieuNhap = maPhieuTra; // <-- thêm dòng này
                ClassPhieuThuChi.ThemPhieuChi(classPhieuThuChi);

                // 7. Thông báo thành công
                MessageBox.Show($"Đã tạo phiếu trả hàng thành công.\nMã phiếu trả: {maPhieuTra}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ====== TẠO HÓA ĐƠN TRẢ HÀNG PDF ======
                var model = new HoaDonTraHangModel
                {
                    NgayBan = DateTime.Now,
                    KhachHang = "Khách lẻ", // hoặc lấy từ form nếu có
                    DiaChi = "",            // lấy từ form nếu có
                    KhuVuc = "",
                    NguoiBan = TaiKhoanNVThucHien.TenNhanVien,
                    Items = new List<HoaDonItem>(),
                    TongTien = tongTienHang,
                    TienTraKhach = tienTraKhach,
                    FooterUrl = $"https://link_xem_online_cua_ban?Code={maPhieuTra}"
                };

                // Thêm sản phẩm từ flowLayoutPanelTTHH vào model
                foreach (Control ctrl in flowLayoutPanelTTHH.Controls)
                {
                    if (ctrl is UserControlHangHoaTraHang item)
                    {
                        model.Items.Add(new HoaDonItem
                        {
                            Ten = item._TenHangHoa,
                            DonGia = item.DonGiaGocHH,
                            SoLuong = item.SoLuong
                        });
                    }
                }

                // Xuất file PDF
                var hoaDonPdf = new HoaDonTraHangDocument(model);
                string folderPath = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-cua-hang-thuoc-tay\QL_Nha-thuoc\QL_Nha-thuoc\PHIEU_IN\trahang\";
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string filePath = Path.Combine(folderPath, $"TRA_{maPhieuTra}.pdf");
                hoaDonPdf.GeneratePdf(filePath);
                try
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = filePath,
                        UseShellExecute = true // Quan trọng để Windows tự mở bằng ứng dụng mặc định
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể mở phiếu trả hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // ====== LÀM MỚI FORM ======
                flowLayoutPanelTTHH.Controls.Clear();
                CapNhatTongTien();
                textBoxPhiTraHang.Text = "";
                textBoxCanTraKhach.Text = "";

                TraHangThanhCong?.Invoke(this, EventArgs.Empty); // Gọi sự kiện thông báo đã trả hàng thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi trả hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private ClassTaiKhoan TaiKhoanNVThucHien;
        private void comboBoxTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Ép kiểu về ClassTaiKhoan nếu bạn gán dữ liệu trực tiếp là list<ClassTaiKhoan>
            TaiKhoanNVThucHien = comboBoxTaiKhoan.SelectedItem as ClassTaiKhoan;
        }
    }
}