using Microsoft.Data.SqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using static QL_Nha_thuoc.DanhMuc;
using static QL_Nha_thuoc.model.ClassHangSanXuat;
namespace QL_Nha_thuoc.model
{

    public class ClassHangHoa
    {
        public string MaHangHoa { get; set; }
        public string HinhAnh { get; set; }
        public string TenHangHoa { get; set; }
        public string MaVach { get; set; }
        public string MaLoaiHangHoa { get; set; }
        public string TenLoaiHangHoa { get; set; }
        public string MaNhomHang { get; set; }
        public string TenNhomHangHoa { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaVon { get; set; }
        public decimal GiaBan { get; set; }
        public string NhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string NoiSanXuat { get; set; }
        public DateTime? HanSuDung { get; set; }

        public string TinhTrang { get; set; } // Tình trạng hàng hóa (có thể là "Còn hàng", "Hết hàng", v.v.)
        //thong tin neu la thuoc
        public string MaThuoc { get; set; }
        public string GhiChu { get; set; }
        public string HoatChatChinh { get; set; }
        public string HamLuong { get; set; }
        public string SoDangKy { get; set; }
        public string QuyCachDongGoi { get; set; }

        public string MaHangSX { get; set; }
        public string TenHangSanXuat { get; set; }

        public DateTime? ThoiGianTao { get; set; }

        // Constructor đầy đủ
        public ClassHangHoa(string maHangHoa, string maThuoc, string tenHangHoa, string donViTinh, int soLuongTon, decimal giaNhap, decimal giaBan,
                          string nhaCungCap, string noiSanXuat, DateTime? hanSuDung, string maLoai, string tenLoai,
                          string maVach, string ghiChu, string hinhAnh, string maHangSX, string tinhTrang, DateTime? thoiGianTao)
        {
            MaHangHoa = maHangHoa;
            MaThuoc = maThuoc;
            TenHangHoa = tenHangHoa;
            MaDonViTinh = donViTinh;
            SoLuongTon = soLuongTon;
            GiaVon = giaNhap;
            GiaBan = giaBan;
            NhaCungCap = nhaCungCap;
            NoiSanXuat = noiSanXuat;
            HanSuDung = hanSuDung;
            MaLoaiHangHoa = maLoai;
            TenLoaiHangHoa = tenLoai;
            MaVach = maVach;
            GhiChu = ghiChu;
            HinhAnh = hinhAnh;
            MaHangSX = maHangSX;
            TinhTrang = tinhTrang;
            ThoiGianTao = thoiGianTao;
            // Thêm thuộc tính Tình trạng hàng hóa
        }

        // Constructor rỗng
        public ClassHangHoa() { }

        //ham lay toan bộ thông tin hàng hóa từ cơ sở dữ liệu

        public static List<ClassHangHoa> LayToanBoHH()
        {
            var ketQua = new List<ClassHangHoa>();

            CSDL cSDL = new CSDL();
            string connectionString = CSDL.GetConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GBHH.GIA_BAN_HH, HH.HINH_ANH_HH, HH.TON_KHO FROM HANG_HOA HH JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA  WHERE HH.MA_HANG_HOA NOT LIKE '%_DELETED'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
               

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var t = new ClassHangHoa
                            {
                                MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                                TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            };
                            ketQua.Add(t);
                        }
                    }
                }
            }

            return ketQua;
        }


        public static List<ClassHangHoa> TimKiemHangHoa(string keyword, string maDonViTinh)
        {
            List<ClassHangHoa> danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, DVT.MA_DON_VI_TINH, DVT.TEN_DON_VI_TINH, GB.GIA_BAN_HH
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GB ON HH.MA_HANG_HOA = GB.MA_HANG_HOA AND GB.MA_BANG_GIA = @maBangGia
            LEFT JOIN DON_VI_TINH DVT ON GB.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            WHERE (HH.MA_HANG_HOA LIKE @keyword OR HH.TEN_HANG_HOA LIKE @keyword)";

                if (maDonViTinh != "ALL")
                {
                    query += " AND DVT.MA_DON_VI_TINH = @maDonViTinh";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    cmd.Parameters.AddWithValue("@maBangGia","BG001");

                    if (maDonViTinh != "ALL")
                        cmd.Parameters.AddWithValue("@maDonViTinh", maDonViTinh);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var hh = new ClassHangHoa
                            {
                                MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                                TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                TenDonViTinh = reader["TEN_DON_VI_TINH"].ToString(),
                                GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0
                            };

                            danhSach.Add(hh);
                        }
                    }
                }
            }

            return danhSach;
        }




        public static List<ClassHangHoa> LayThongTinHH(string maHH)
        {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                SELECT 
                HH.MA_HANG_HOA,
                HH.MA_THUOC,
                HH.TEN_HANG_HOA,
                DVT.MA_DON_VI_TINH,
                DVT.TEN_DON_VI_TINH,
                HH.TON_KHO,
                GBHH.GIA_VON_HH,
                GBHH.GIA_BAN_HH,
                NCC.MA_NHA_CUNG_CAP,
                NCC.TEN_NHA_CUNG_CAP,
                HH.NGAY_HET_HAN_HH,
                LHH.MA_LOAI_HH,
                LHH.TEN_LOAI_HH,
                HH.MA_VACH,
                HH.GHI_CHU_HH,
                HH.HINH_ANH_HH,
                HH.HOAT_CHAT,
                HH.HAM_LUONG,
                HH.SO_DANG_KY_THUOC,
                HH.TINH_TRANG_HH,
                HH.QUY_CACH_DONG_GOI,
                HSX.TEN_HANG_SX,
                HSX.MA_HANG_SX,
                HH.TINH_TRANG_HH,
	            NH.TEN_NHOM,
	            LHH.TEN_LOAI_HH,
	            HH.NGAY_HET_HAN_HH
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON HH.MA_HANG_HOA=CTPN.MA_HANG_HOA
            LEFT JOIN PHIEU_NHAP_HANG PNH on PNH.MA_PHIEU_NHAP=CTPN.MA_PHIEU_NHAP
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP=NCC.MA_NHA_CUNG_CAP
            left join NHOM_HANG NH on HH.MA_NHOM_HH=NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            left join HANG_SAN_XUAT HSX on HH.MA_HANG_SX=HSX.MA_HANG_SX
            WHERE HH.MA_HANG_HOA = @maHH
            AND HH.MA_HANG_HOA NOT LIKE '%_DELETED'
              ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", "%" + maHH + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hh = new ClassHangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            TenNhomHangHoa = reader["TEN_NHOM"]?.ToString(),                           
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"]?.ToString(),
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            NoiSanXuat = reader["NOI_SAN_XUAT"]?.ToString(),
                            HanSuDung = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : (DateTime?)null,
                            MaLoaiHangHoa = reader["MA_LOAI_HANG_HOA"]?.ToString(),
                            TenLoaiHangHoa = reader["TEN_LOAI_HANG_HOA"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SAN_XUAT"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TinhTrang = reader["TINH_TRANG_HH"]?.ToString() // Thêm thuộc tính Tình trạng hàng hóa

                        };

                        danhSach.Add(hh);
                    }
                }
            }

            return danhSach;
        }




        public static ClassHangHoa LayThongTinMotHangHoa(string maHH)
        {
            ClassHangHoa hh = null;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                   SELECT 
               HH.MA_HANG_HOA,
               HH.MA_THUOC,
               HH.TEN_HANG_HOA,
               NH.TEN_NHOM,
			   HH.MA_NHOM_HH,
               DVT.MA_DON_VI_TINH,
               DVT.TEN_DON_VI_TINH,
               HH.TON_KHO,
               GHH.GIA_VON_HH,
               GHH.GIA_BAN_HH,
               NCC.MA_NHA_CUNG_CAP,
               NCC.TEN_NHA_CUNG_CAP,
               HH.NGAY_HET_HAN_HH,
               NH.MA_LOAI_HH,
               LH.TEN_LOAI_HH,
               HH.MA_VACH,
               HH.GHI_CHU_HH,
               HH.HINH_ANH_HH,
               HH.HOAT_CHAT,
               HH.HAM_LUONG,
               HH.SO_DANG_KY_THUOC,
               HH.QUY_CACH_DONG_GOI,
               HH.MA_HANG_SX,
               HH.TINH_TRANG_HH,
               HSX.TEN_HANG_SX
       FROM HANG_HOA HH
        JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
        JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
        LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX
        LEFT JOIN GIA_HANG_HOA GHH ON GHH.MA_HANG_HOA = HH.MA_HANG_HOA
        LEFT JOIN DON_VI_TINH DVT ON GHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
        LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON CTPN.MA_HANG_HOA=HH.MA_HANG_HOA
        LEFT JOIN PHIEU_NHAP_HANG PN ON PN.MA_PHIEU_NHAP=CTPN.MA_PHIEU_NHAP
        LEFT JOIN NHA_CUNG_CAP NCC ON NCC.MA_NHA_CUNG_CAP=PN.MA_NHA_CUNG_CAP
        WHERE HH.MA_HANG_HOA = @maHH
           AND HH.MA_HANG_HOA NOT LIKE '%_DELETED' ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHH);
                //cmd.Parameters.AddWithValue("@ten", "%" + keyword + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hh = new ClassHangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            MaLoaiHangHoa = reader["MA_LOAI_HH"]?.ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            TenLoaiHangHoa= reader["TEN_LOAI_HH"]?.ToString(),
                            TenNhomHangHoa= reader["TEN_NHOM"]?.ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString(),
                            TinhTrang = reader["TINH_TRANG_HH"]?.ToString(), // Thêm thuộc tính Tình trạng hàng hóa
                            GhiChu=reader["GHI_CHU_HH"]?.ToString(),
                            MaVach= reader["MA_VACH"]?.ToString()
                            
                        };
                    }
                }
            }

            return hh;
        }
        public static List<ClassHangHoa> TimKiemHangHoaTheoTuKhoa(string tuKhoa)
        {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
        WITH HangHoaCTE AS (
            SELECT 
                HH.MA_HANG_HOA,
                HH.MA_THUOC,
                HH.TEN_HANG_HOA,
                DVT.MA_DON_VI_TINH,
                DVT.TEN_DON_VI_TINH,
                HH.TON_KHO,
                GBHH.GIA_VON_HH,
                GBHH.GIA_BAN_HH,
                NCC.MA_NHA_CUNG_CAP,
                NCC.TEN_NHA_CUNG_CAP,
                HH.NGAY_HET_HAN_HH,
                LHH.MA_LOAI_HH,
                LHH.TEN_LOAI_HH,
                HH.MA_VACH,
                HH.GHI_CHU_HH,
                HH.HINH_ANH_HH,
                HH.HOAT_CHAT,
                HH.HAM_LUONG,
                HH.SO_DANG_KY_THUOC,
                HH.QUY_CACH_DONG_GOI,
                HH.TINH_TRANG_HH,
                HSX.MA_HANG_SX,
                HSX.TEN_HANG_SX,
                ROW_NUMBER() OVER (PARTITION BY HH.MA_HANG_HOA ORDER BY PNH.NGAY_NHAP DESC) AS RN
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON HH.MA_HANG_HOA = CTPN.MA_HANG_HOA
            LEFT JOIN PHIEU_NHAP_HANG PNH ON CTPN.MA_PHIEU_NHAP = PNH.MA_PHIEU_NHAP
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
            LEFT JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX
            WHERE 
    (HH.MA_HANG_HOA LIKE @tuKhoa OR HH.TEN_HANG_HOA LIKE @tuKhoa)
    AND HH.MA_HANG_HOA NOT LIKE '%_DELETED'

        )
        SELECT * FROM HangHoaCTE WHERE RN = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hh = new ClassHangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"]?.ToString(),
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            HanSuDung = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : (DateTime?)null,
                            MaLoaiHangHoa = reader["MA_LOAI_HH"]?.ToString(),
                            TenLoaiHangHoa = reader["TEN_LOAI_HH"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU_HH"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TinhTrang = reader["TINH_TRANG_HH"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString()
                        };

                        danhSach.Add(hh);
                    }
                }
            }

            return danhSach;
        }

        public static ClassHangHoa LayThongTinTheoMaVaDonViTinh(string maHH, string maDVT)
        {
            ClassHangHoa hh = null;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
        SELECT 
            HH.MA_HANG_HOA,
            HH.MA_THUOC,
            HH.TEN_HANG_HOA,
            DVT.MA_DON_VI_TINH,
            DVT.TEN_DON_VI_TINH,
            HH.TON_KHO,
            GBHH.GIA_VON_HH,
            GBHH.GIA_BAN_HH,
            NCC.MA_NHA_CUNG_CAP,
            NCC.TEN_NHA_CUNG_CAP,
            HH.NGAY_HET_HAN_HH,
            LH.MA_LOAI_HH,
            LH.TEN_LOAI_HH,
            HH.MA_VACH,
            HH.GHI_CHU_HH,
            HH.HINH_ANH_HH,
            HH.HOAT_CHAT,
            HH.HAM_LUONG,
            HH.SO_DANG_KY_THUOC,
            HH.QUY_CACH_DONG_GOI,
            HH.TINH_TRANG_HH,
            HSX.MA_HANG_SX,
            HSX.TEN_HANG_SX
        FROM HANG_HOA HH
        LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
        LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
        LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON HH.MA_HANG_HOA = CTPN.MA_HANG_HOA
        LEFT JOIN PHIEU_NHAP_HANG PNH ON CTPN.MA_PHIEU_NHAP = PNH.MA_PHIEU_NHAP
        LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
        LEFT JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
        LEFT JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
        LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX

        WHERE HH.MA_HANG_HOA = @maHH 
          AND DVT.MA_DON_VI_TINH = @maDVT
          AND HH.MA_HANG_HOA NOT LIKE '%_DELETED'";


                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHH);
                cmd.Parameters.AddWithValue("@maDVT", maDVT);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hh = new ClassHangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"]?.ToString(),
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            HanSuDung = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : (DateTime?)null,
                            MaLoaiHangHoa = reader["MA_LOAI_HH"]?.ToString(),
                            TenLoaiHangHoa = reader["TEN_LOAI_HH"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU_HH"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TinhTrang = reader["TINH_TRANG_HH"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString()
                        };
                    }
                }
            }

            return hh;
        }


      
      



        //ham lay thong tin cua danh sahc hang hoa trong dnah muc hang hoa 
        public static List<ClassHangHoa> LayThongTinHHfromDanhMuc(string tenHH)
        {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                select DMHH.TEN_HANG_HOA, DMHH.MA_VACH_HANG_HOA,DMHH.HINH_ANH_HANG_HOA  from DANH_MUC_HANG_HOA DMHH
                WHERE  TEN_HANG_HOA LIKE @teHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@teHH", "%" + tenHH + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hh = new ClassHangHoa
                        {
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            MaVach = reader["MA_VACH_HANG_HOA"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HANG_HOA"]?.ToString() // Nếu có cột HINH_ANH_HH trong bảng DANH_MUC_HANG_HOA

                        };

                        danhSach.Add(hh);
                    }
                }
            }

            return danhSach;
        }



        //ham tao ma hang hoa tu dong
        public static string TaoMaHangHoaTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            SELECT TOP 1 MA_HANG_HOA
            FROM HANG_HOA
            WHERE MA_HANG_HOA LIKE 'HH%'
            ORDER BY 
                TRY_CAST(SUBSTRING(MA_HANG_HOA, 3, LEN(MA_HANG_HOA)) AS INT) DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();

                int soThuTu = 1; // Mặc định nếu chưa có mã nào

                if (result != null)
                {
                    string maCu = result.ToString(); // VD: "HH0025"
                    if (maCu.Length > 2 && int.TryParse(maCu.Substring(2), out int so))
                    {
                        soThuTu = so + 1;
                    }
                }

                return "HH" + soThuTu.ToString("D4"); // VD: HH0026
            }
        }

        //ham them hang hoa 
        public static bool ThemHangHoaMoi(ClassHangHoa hangHoa)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    string query = @"
                INSERT INTO HANG_HOA (
                    MA_HANG_HOA, HINH_ANH_HH, TEN_HANG_HOA, MA_VACH, QUY_CACH_DONG_GOI, 
                    GHI_CHU_HH,
                    HOAT_CHAT, HAM_LUONG, NGAY_HET_HAN_HH, 
                    SO_DANG_KY_THUOC, TON_KHO, MA_NHOM_HH, MA_HANG_SX, TINH_TRANG_HH, THOI_GIAN_TAO
                )
                VALUES (
                    @maHH, @hinhAnh, @tenHH, @maVach, @quyCach, 
                    @ghiChu,
                    @hoatChat, @hamLuong, @hanSD,
                    @soDK, @tonKho, @maNhom, @maHangSX, @tinhTrang, @thoigiantao
                )";

                    int rowsAffected = 0;

                    using (SqlCommand cmd = new SqlCommand(query, conn, transaction)) // gán transaction
                    {
                        cmd.Parameters.AddWithValue("@maHH", hangHoa.MaHangHoa);
                        cmd.Parameters.AddWithValue("@hinhAnh", (object)hangHoa.HinhAnh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@tenHH", hangHoa.TenHangHoa);
                        cmd.Parameters.AddWithValue("@maVach", (object)hangHoa.MaVach ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quyCach", (object)hangHoa.QuyCachDongGoi ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ghiChu", (object)hangHoa.GhiChu ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hoatChat", (object)hangHoa.HoatChatChinh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hamLuong", (object)hangHoa.HamLuong ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hanSD", (object)hangHoa.HanSuDung ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@soDK", (object)hangHoa.SoDangKy ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@tonKho", hangHoa.SoLuongTon);
                        cmd.Parameters.AddWithValue("@maNhom", (object)hangHoa.MaNhomHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@maHangSX", hangHoa.MaHangSX);
                        cmd.Parameters.AddWithValue("@tinhTrang", (object)hangHoa.TinhTrang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@thoigiantao", DateTime.Now);

                        // Thực hiện lệnh và lấy số dòng ảnh hưởng
                        rowsAffected = cmd.ExecuteNonQuery();
                    }

                    // Nếu thêm hàng hóa thành công thì mới thêm giá bán
                    if (rowsAffected > 0)
                    {

                        ClassGiaBanHH giaBan = new ClassGiaBanHH
                        {
                            MaHangHoa = hangHoa.MaHangHoa,
                            MaBangGia="BG001", // Giả sử bạn có một bảng giá mặc định
                            GiaVon = hangHoa.GiaVon,
                            GiaBan = hangHoa.GiaBan,
                            MaDonViTinh = hangHoa.MaDonViTinh
                        };

                        // ✅ Gọi đúng với đủ tham số:
                        if (!ClassGiaBanHH.ThemGiaBan(giaBan, conn, transaction))
                            throw new Exception("Lỗi khi thêm giá bán hàng hóa.");
                    }
                    else
                    {
                        throw new Exception("Không thêm được hàng hóa vào cơ sở dữ liệu.");
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Lỗi khi thêm hàng hóa: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public static void CapNhatTonKho(string maHangHoa, int soLuongMoi)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "UPDATE HANG_HOA SET TON_KHO = @SoLuong WHERE MA_HANG_HOA = @MaHangHoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoLuong", soLuongMoi);
                cmd.Parameters.AddWithValue("@MaHangHoa", maHangHoa);
                cmd.ExecuteNonQuery();
            }
        }

  


        public static bool XoaHangHoa(string maHH, string maNN)
        {
            bool daCapNhat = false;
                // Lấy thông tin hàng hóa trước khi bị xóa
                var thongTinHang = ClassHangHoa.LayThongTinMotHangHoa(maHH);
                if (thongTinHang == null)
                    return false;

                // Tạo mã phiếu kiểm kho mới
                string maPhieuKiem = ClassPhieuKiemKho.SinhMaPhieuMoi();

            // Thêm phiếu kiểm kho
            ClassPhieuKiemKho phieuKiemKho = new ClassPhieuKiemKho
            {
                    MaPhieuKiemKho = maPhieuKiem,
                    NgayKiemKho = DateTime.Now,
                    MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien,
                    GhiChu = $"Tự động cân bằng do xóa hàng hóa: {thongTinHang.TenHangHoa}",
                    TrangThaiPhieuKiem = "Đã cân bằng kho"
                };

                bool themPhieu = ClassPhieuKiemKho.ThemPhieuKiemKho(phieuKiemKho);

                if (themPhieu)
                {
                    ClassChiTietPhieuKiemKho chiTiet = new ClassChiTietPhieuKiemKho
                    {
                        MaPhieuKiemKho = maPhieuKiem,
                        MaHangHoa = maHH,
                        TenHangHoa = thongTinHang.TenHangHoa,
                        SoLuongHeThong = thongTinHang.SoLuongTon,
                        SoLuongThucTe = 0
                    };

                    bool themChiTiet = ClassChiTietPhieuKiemKho.ThemChiTietPhieuKiemKho(chiTiet);

                    if (themChiTiet)
                    {
                        MessageBox.Show("Đã tạo phiếu kiểm kho để ghi nhận việc xóa hàng hóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "UPDATE HANG_HOA SET MA_HANG_HOA = MA_HANG_HOA + '_DELETED' WHERE MA_HANG_HOA = @maHH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHH);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                daCapNhat = rowsAffected > 0;
            }
            return daCapNhat;
        }




    }

}
