using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    // Đại diện chi tiết hàng hóa trong phiếu nhập (nếu có bảng CHI_TIET_PHIEU_NHAP)
    public class ChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietPhieuNhap() { }

        public ChiTietPhieuNhap(string maPhieu, string maHH, string tenHH, int soLuong, decimal donGia, decimal giamGia, decimal thanhTien)
        {
            MaPhieuNhap = maPhieu;
            MaHangHoa = maHH;
            TenHangHoa = tenHH;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
        }






    }
}
