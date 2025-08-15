using System;
using System.Collections.Generic;
using System.Linq;
using QL_Nha_thuoc.model;

namespace QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay
{
    public class BaoCaoBanHang : BaoCao<ClassHoaDon>
    {
        public BaoCaoBanHang(List<ClassHoaDon> danhSach, DateTime ngayBaoCao)
            : base(danhSach,
                  "Báo cáo bán hàng cuối ngày",
                  new List<(string, Func<ClassHoaDon, string>, decimal?)>
                  {
                      ("Mã HĐ", hd => hd.MaHoaDon ?? "", 80m),
                      ("Ngày Lập", hd => hd.NgayLapHD?.ToString("dd/MM/yyyy") ?? "", 80m),
                        ("Khách Hàng", hd => hd.TenKhachHang ?? "", 150m),
                        ("Nhân Viên", hd => hd.TenNhanVien ?? "", 100m),
                        ("Tổng Số Lượng", hd => hd.ChiTietHoaDon?.Count.ToString() ?? "0", 80m),
                      ("Số lượng bán", hd => hd.ChiTietHoaDon?.Sum(ct => ct.SoLuong).ToString() ?? "0", 80m),
                      ("Tổng Tiền (VNĐ)", hd => hd.ThanhTien.HasValue ? hd.ThanhTien.Value.ToString("N0") : "", 100m),
                  },
                  ngayBaoCao)
        {
        }
    }
}
