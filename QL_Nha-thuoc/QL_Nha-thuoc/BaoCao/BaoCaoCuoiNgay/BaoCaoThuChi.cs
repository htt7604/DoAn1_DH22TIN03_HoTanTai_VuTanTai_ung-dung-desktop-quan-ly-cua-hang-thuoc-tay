using System;
using System.Collections.Generic;
using QL_Nha_thuoc.model; // chứa ClassPhieuThuChi

namespace QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay
{
    public class BaoCaoThuChi : BaoCao<ClassPhieuThuChi>
    {
        public BaoCaoThuChi(List<ClassPhieuThuChi> danhSach, DateTime ngayBaoCao)
            : base(danhSach,
                  "Báo cáo thu chi cuối ngày",
                  new List<(string, Func<ClassPhieuThuChi, string>, decimal?)>
                  {
                      ("Mã Phiếu", pc => pc.MaPhieuThuChi ?? "", 80m),
                      ("Ngày", pc => pc.NgayLapPhieu?.ToString("dd/MM/yyyy") ?? "", 80m),
                      ("Loại", pc => pc.MaLoaiPhieu ?? "", 80m),
                      ("Số Tiền", pc => pc.SoTien.HasValue ? pc.SoTien.Value.ToString("N0") : "", 100m),
                  },
                  ngayBaoCao)
        {
        }
    }
}
