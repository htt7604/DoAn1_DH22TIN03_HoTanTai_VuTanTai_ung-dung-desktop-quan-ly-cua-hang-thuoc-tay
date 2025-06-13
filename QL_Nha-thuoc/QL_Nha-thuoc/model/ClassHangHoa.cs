using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
namespace QL_Nha_thuoc.model
{
    public class DBHelperHH
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

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
        public string DonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public string NhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string NoiSanXuat { get; set; }
        public DateTime? HanSuDung { get; set; }


        //thong tin neu la thuoc
        public string MaThuoc { get; set; }
        public string GhiChu { get; set; }
        public string HoatChatChinh { get; set; }
        public string HamLuong { get; set; }
        public string SoDangKy { get; set; }
        public string QuyCachDongGoi { get; set; }

        public string MaHangSX { get; set; }
        public string TenHangSanXuat { get; set; }


        // Constructor đầy đủ
        public ClassHangHoa(string maHangHoa,string maThuoc, string tenHangHoa, string donViTinh, int soLuongTon, decimal giaNhap, decimal giaBan,
                          string nhaCungCap, string noiSanXuat, DateTime? hanSuDung, string maLoai, string tenLoai,
                          string maVach, string ghiChu, string hinhAnh,string maHangSX)
        {
            MaHangHoa = maHangHoa;
            MaThuoc = maThuoc;
            TenHangHoa = tenHangHoa;
            DonViTinh = donViTinh;
            SoLuongTon = soLuongTon;
            GiaNhap = giaNhap;
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
        }

        // Constructor rỗng
        public ClassHangHoa() { }

         public static List<ClassHangHoa> LayThongTinHH(string maHH)
         {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
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
                HH.HOAT_CHAT_CHINH,
                HH.HAM_LUONG,
                HH.SO_DANG_KY,
                HH.QUY_CACH_DONG_GOI,
                HH.TEN_HANG_SAN_XUAT
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
			 LEFT JOIN PHIEU_NHAP_HANG PNH on HH.MA_HANG_HOA=PNH.MA_HANG_HOA
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP=NCC.MA_NHA_CUNG_CAP
			left join NHOM_HANG NH on HH.MA_NHOM_HH=NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            WHERE HH.MA_HANG_HOA = @maHH";

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
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaNhap = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"]?.ToString(),
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            NoiSanXuat = reader["NOI_SAN_XUAT"]?.ToString(),
                            HanSuDung = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : (DateTime?)null,
                            MaLoaiHangHoa = reader["MA_LOAI_HANG_HOA"]?.ToString(),
                            TenLoaiHangHoa = reader["TEN_LOAI_HANG_HOA"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT_CHINH"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SAN_XUAT"]?.ToString(),

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

            using (SqlConnection conn = DBHelperHH.GetConnection())
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
                HH.QUY_CACH_DONG_GOI,
                HH.MA_HANG_SX,
                HSX.TEN_HANG_SX

            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
             LEFT JOIN PHIEU_NHAP_HANG PNH on HH.MA_HANG_HOA=PNH.MA_HANG_HOA
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP=NCC.MA_NHA_CUNG_CAP
            left join NHOM_HANG NH on HH.MA_NHOM_HH=NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            left join HANG_SAN_XUAT HSX on HH.MA_HANG_SX=HSX.MA_HANG_SX
            WHERE HH.MA_HANG_HOA = @maHH";

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
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaNhap = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString(),

                        };
                    }
                }
            }

            return hh;
        }


        //ham tao ma hang hoa tu dong
        public static string TaoMaHangHoaTuDong()
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
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

        public static bool ThemThuocMoi(ClassHangHoa thuoc)
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // bắt đầu transaction

                try
                {
                    // 1. Thêm vào bảng HANG_HOA
                    string insertHH = @"
                INSERT INTO HANG_HOA (
                    MA_HANG_HOA, MA_THUOC, TEN_HANG_HOA, TON_KHO, NGAY_HET_HAN_HH, MA_VACH, 
                    GHI_CHU_HH, HINH_ANH_HH, MA_NHOM_HH, HOAT_CHAT, HAM_LUONG, 
                    SO_DANG_KY_THUOC, QUY_CACH_DONG_GOI, MA_HANG_SX
                )
                VALUES (
                    @maHH, @maThuoc, @tenHH, @tonKho, @hanSD, @maVach, 
                    @ghiChu, @hinhAnh, @maNhom, @hoatChat, @hamLuong, 
                    @soDK, @quyCach, @maHangSX
                )";

                    SqlCommand cmd1 = new SqlCommand(insertHH, conn, transaction);
                    cmd1.Parameters.Add("@maHH", SqlDbType.VarChar).Value = thuoc.MaHangHoa;
                    cmd1.Parameters.Add("@maThuoc", SqlDbType.VarChar).Value = (object)thuoc.MaThuoc ?? DBNull.Value;
                    cmd1.Parameters.Add("@tenHH", SqlDbType.NVarChar).Value = thuoc.TenHangHoa;
                    cmd1.Parameters.Add("@tonKho", SqlDbType.Int).Value = thuoc.SoLuongTon;
                    cmd1.Parameters.Add("@hanSD", SqlDbType.DateTime).Value = (object)thuoc.HanSuDung ?? DBNull.Value;
                    cmd1.Parameters.Add("@maVach", SqlDbType.VarChar).Value = (object)thuoc.MaVach ?? DBNull.Value;
                    cmd1.Parameters.Add("@ghiChu", SqlDbType.NVarChar).Value = (object)thuoc.GhiChu ?? DBNull.Value;
                    cmd1.Parameters.Add("@hinhAnh", SqlDbType.VarChar).Value = (object)thuoc.HinhAnh ?? DBNull.Value;
                    cmd1.Parameters.Add("@maNhom", SqlDbType.VarChar).Value = (object)thuoc.MaNhomHang ?? DBNull.Value;
                    cmd1.Parameters.Add("@hoatChat", SqlDbType.NVarChar).Value = (object)thuoc.HoatChatChinh ?? DBNull.Value;
                    cmd1.Parameters.Add("@hamLuong", SqlDbType.NVarChar).Value = (object)thuoc.HamLuong ?? DBNull.Value;
                    cmd1.Parameters.Add("@soDK", SqlDbType.VarChar).Value = (object)thuoc.SoDangKy ?? DBNull.Value;
                    cmd1.Parameters.Add("@quyCach", SqlDbType.NVarChar).Value = (object)thuoc.QuyCachDongGoi ?? DBNull.Value;
                    cmd1.Parameters.Add("@maHangSX", SqlDbType.VarChar).Value = (object)thuoc.MaHangSX ?? DBNull.Value;

                    cmd1.ExecuteNonQuery();


                    // TODO: Có thể thêm tiếp vào bảng PHIEU_NHAP_HANG nếu cần ở đây...

                    transaction.Commit(); // xác nhận transaction
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // hoàn tác nếu có lỗi
                    Console.WriteLine("Lỗi khi thêm thuốc: " + ex.Message);
                    Console.WriteLine("StackTrace: " + ex.StackTrace);
                    return false;
                }
            }
        }






    }




}
