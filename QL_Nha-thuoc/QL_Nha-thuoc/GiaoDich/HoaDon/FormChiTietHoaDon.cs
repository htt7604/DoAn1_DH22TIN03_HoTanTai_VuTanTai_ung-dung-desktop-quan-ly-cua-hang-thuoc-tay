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

namespace QL_Nha_thuoc.GiaoDich.HoaDon
{
    public partial class FormChiTietHoaDon : Form
    {
        private string maHoaDon;

        //khai bao su kien form dong 
        public event Action FormDong;

        private FormMain formMain;

        public FormChiTietHoaDon(string maHoaDon, FormMain main)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            this.formMain = main;
            LoadChiTietHoaDon();
        }
        private void LoadChiTietHoaDon()
        {
            // Load dữ liệu phiếu kiểm
            var thongTinHoaDon = ClassHoaDon.LayHoaDonTheoMa(maHoaDon);

            if (thongTinHoaDon != null)
            {
                // Gán dữ liệu vào TextBox
                labelMaHoaDon.Text = thongTinHoaDon.MaBangGia;
                labelTenNguoiTao.Text = thongTinHoaDon.TenNhanVien;
                labelTrangThai.Text = thongTinHoaDon.TrangThai;
                labelTenKhachHang.Text = ClassKhachHang.LayThongTinKhachHangTheoMa(thongTinHoaDon.MaKH).TenKH;
                labelBangGia.Text = ClassBangGia.LayBangGiaTheoMa(thongTinHoaDon.MaBangGia).TenBangGia;
                textBoxGhiChu.Text = thongTinHoaDon.GhiChuHoaDon;
                //if (thongTinHoaDon.TrangThai == "Hoàn thành")
                //{
                //    buttonMoPhieu.Visible = true;
                //}
                //else if (thongTinHoaDon.TrangThai == "Đã cân bằng kho")
                //{
                //    buttonMoPhieu.Visible = false;

                //}

                textBoxGhiChu.Text = thongTinHoaDon.GhiChuHoaDon;
                if (thongTinHoaDon.NgayLapHD.HasValue)
                {
                    labelThoiGian.Text = thongTinHoaDon.NgayLapHD.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    labelThoiGian.Text = "";
                }
             
            }

            List<ClassChiTietHoaDon> dschitiethoadon = ClassChiTietHoaDon.LayChiTietTheoMaHD(maHoaDon);
            var table = new DataTable();
            table.Columns.Add("Mã hàng hóa");
            table.Columns.Add("Tên hàng", typeof(string));
            table.Columns.Add("Sô lượng", typeof(int));
            table.Columns.Add("Đơn giá", typeof(decimal));
            table.Columns.Add("Giảm giá  ", typeof(decimal));
            table.Columns.Add("Gia bán", typeof(decimal));
            table.Columns.Add("Thành tiền", typeof(decimal));


            foreach (var cthd in dschitiethoadon)
            {
                table.Rows.Add(cthd.MaHangHoa, cthd.TenHangHoa, cthd.SoLuong, cthd.DonGiaBan, cthd.GiamGia, cthd.GiaBan, cthd.ThanhTien);
            }

            dataGridViewdsHoaDon.DataSource = table;
            dataGridViewdsHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            //hien thi tong so luong thuc te, tong lech tang, tong lech giam, tong chenh lech
            //hien thi tong so luong thuc te, tong lech tang, tong lech giam, tong chenh lech
            int tongSoLuong = 0;
            int tongTienHang = 0;
            int giamgiahoadon = 0;
            int khachDaTra = 0;

            foreach (var cthd in dschitiethoadon)
            {
                tongSoLuong = tongSoLuong + (cthd.SoLuong ?? 0);
                tongTienHang = tongTienHang += (int)(cthd.ThanhTien ?? 0);
                giamgiahoadon = (int)(thongTinHoaDon.GiamGia ?? 0);
                khachDaTra = (int)(thongTinHoaDon.ThanhTien ?? 0);
            }

            // Gán vào các TextBox (bạn cần tạo trước các TextBox này trong Designer)
            labelTongSoLuong.Text = "Tổng số lượng: " + tongSoLuong.ToString();
            labelTongTienHang.Text = "Tổng tiền hàng: " + tongTienHang.ToString() + " VND";
            labelGiamGiaHoaDon.Text = "Giảm giá hóa đơn: " + giamgiahoadon.ToString() + " VND" ;
            labelKhachTra.Text = "Khách đã trả: " + khachDaTra.ToString() + " VND";






        }
    }
}
