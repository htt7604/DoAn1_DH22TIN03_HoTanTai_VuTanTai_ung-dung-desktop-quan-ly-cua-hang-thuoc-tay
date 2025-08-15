using System;
using System.Collections.Generic;
using QL_Nha_thuoc.model; // chứa ClassHangHoa

namespace QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay
{
    public class BaoCaoHangHoa : BaoCao<ClassHangHoa>
    {
        public BaoCaoHangHoa(List<ClassHangHoa> danhSach, DateTime ngayBaoCao)
            : base(danhSach,
                  "Báo cáo tồn kho hàng hóa",
                  new List<(string, Func<ClassHangHoa, string>, decimal?)>
                  {
                      ("Mã Hàng", hh => hh.MaHangHoa ?? "", 80m),
                      ("Tên Hàng", hh => hh.TenHangHoa ?? "", 150m),
                      ("Số Lượng Tồn", hh => hh.SoLuongTon.ToString(), 80m),
                      ("Giá Bán", hh => hh.GiaBan.ToString("N0"), 100m),
                  },
                  ngayBaoCao)
        {
        }
    }
}
