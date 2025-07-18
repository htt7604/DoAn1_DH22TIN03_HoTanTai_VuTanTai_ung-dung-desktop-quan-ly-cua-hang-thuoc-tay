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
        public decimal GiaVon { get; set; }
        public decimal GiaBan { get; set; }
        public string NhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
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


        // Constructor đầy đủ
        public ClassHangHoa(string maHangHoa,string maThuoc, string tenHangHoa, string donViTinh, int soLuongTon, decimal giaNhap, decimal giaBan,
                          string nhaCungCap, string noiSanXuat, DateTime? hanSuDung, string maLoai, string tenLoai,
                          string maVach, string ghiChu, string hinhAnh,string maHangSX,string tinhTrang)
        {
            MaHangHoa = maHangHoa;
            MaThuoc = maThuoc;
            TenHangHoa = tenHangHoa;
            DonViTinh = donViTinh;
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
            TinhTrang = tinhTrang; // Thêm thuộc tính Tình trạng hàng hóa
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
                HH.HOAT_CHAT,
                HH.HAM_LUONG,
                HH.SO_DANG_KY_THUOC,
                HH.TINH_TRANG_HH,
                HH.QUY_CACH_DONG_GOI,
                HSX.TEN_HANG_SX,
                HSX.MA_HANG_SX
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
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
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
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SAN_XUAT"]?.ToString(),
                            MaHangSX = reader["MA_HANG_SX"]?.ToString(),
                            TinhTrang= reader["TINH_TRANG_HH"]?.ToString() // Thêm thuộc tính Tình trạng hàng hóa

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
                HH.TINH_TRANG_HH,
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
                            TinhTrang= reader["TINH_TRANG_HH"]?.ToString(), // Thêm thuộc tính Tình trạng hàng hóa

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
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Thêm vào bảng HANG_HOA
                    string insertHH = @"
                INSERT INTO HANG_HOA (
                    MA_HANG_HOA, MA_THUOC, TEN_HANG_HOA, TON_KHO, NGAY_HET_HAN_HH, MA_VACH, 
                    GHI_CHU_HH, HINH_ANH_HH, MA_NHOM_HH, HOAT_CHAT, HAM_LUONG, 
                    SO_DANG_KY_THUOC, QUY_CACH_DONG_GOI, MA_HANG_SX,TINH_TRANG_HH
                )
                VALUES (
                    @maHH, @maThuoc, @tenHH, @tonKho, @hanSD, @maVach, 
                    @ghiChu, @hinhAnh, @maNhom, @hoatChat, @hamLuong, 
                    @soDK, @quyCach, @maHangSX, @tinhTrang
                )";

                    using (SqlCommand cmd1 = new SqlCommand(insertHH, conn, transaction))
                    {
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
                        cmd1.Parameters.Add("@tinhTrang", SqlDbType.NVarChar).Value = (object)thuoc.TinhTrang ?? DBNull.Value; // Thêm tham số Tình trạng hàng hóa

                        cmd1.ExecuteNonQuery();
                    }

                    // 2. Thêm giá bán
                    decimal tiLeLoi = 0;
                    if (thuoc.GiaVon > 0 && thuoc.GiaBan > 0)
                    {
                        tiLeLoi = ((thuoc.GiaBan - thuoc.GiaVon) / thuoc.GiaVon) * 100;
                    }

                    ClassGiaBanHH giaBan = new ClassGiaBanHH
                    {
                        MaHangHoa = thuoc.MaHangHoa,
                        GiaVon = thuoc.GiaVon,
                        GiaBan = thuoc.GiaBan,
                        MaDonViTinh = thuoc.MaDonViTinh,
                        TiLeLoi = tiLeLoi
                    };

                    if (!ClassGiaBanHH.ThemGiaBan(giaBan, conn, transaction))
                    {
                        throw new Exception("Lỗi khi thêm giá hàng hóa.");
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi khi thêm thuốc: " + ex.Message);
                    Console.WriteLine("StackTrace: " + ex.StackTrace);
                    return false;
                }
            }
        }



        //ham lay thong tin cua danh sahc hang hoa trong dnah muc hang hoa 
        public static List<ClassHangHoa> LayThongTinHHfromDanhMuc(string tenHH)
        {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
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



        //ham them hang hoa 
        public static bool ThemHangHoaMoi(ClassHangHoa hangHoa)
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    //    string insertHH = @"
                    //INSERT INTO HANG_HOA (
                    //    MA_HANG_HOA, HINH_ANH_HH, TEN_HANG_HOA, MA_VACH, QUY_CACH_DONG_GOI, 
                    //    TRONG_LUONG_HH, NGAY_SX_HH, GHI_CHU_HH, MA_THUOC, TEN_VIET_TAT, 
                    //    HOAT_CHAT, HAM_LUONG, DUONG_DUNG_CHO_THUOC, NGAY_HET_HAN_HH, 
                    //    SO_DANG_KY_THUOC, TINH_TRANG_HH, TON_KHO, MA_NHOM_HH, MA_HANG_SX
                    //)
                    //VALUES (
                    //    @maHH, @hinhAnh, @tenHH, @maVach, @quyCach, 
                    //    @trongLuong, @ngaySX, @ghiChu, @maThuoc, @tenVietTat,
                    //    @hoatChat, @hamLuong, @duongDung, @hanSD,
                    //    @soDK, @tinhTrang, @tonKho, @maNhom, @maHangSX
                    //)";

                    string insertHH = @"
                    INSERT INTO HANG_HOA (
                        MA_HANG_HOA, HINH_ANH_HH, TEN_HANG_HOA, MA_VACH, QUY_CACH_DONG_GOI, 
                        GHI_CHU_HH, MA_THUOC,
                        HOAT_CHAT, HAM_LUONG, NGAY_HET_HAN_HH, 
                        SO_DANG_KY_THUOC, TON_KHO, MA_NHOM_HH, MA_HANG_SX, TINH_TRANG_HH
                    )
                    VALUES (
                        @maHH, @hinhAnh, @tenHH, @maVach, @quyCach, 
                        @ghiChu, @maThuoc,
                        @hoatChat, @hamLuong, @hanSD,
                        @soDK, @tonKho, @maNhom, @maHangSX, @tinhTrang
                    )";

                    using (SqlCommand cmd = new SqlCommand(insertHH, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@maHH", hangHoa.MaHangHoa);
                        cmd.Parameters.AddWithValue("@hinhAnh", (object)hangHoa.HinhAnh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@tenHH", hangHoa.TenHangHoa);
                        cmd.Parameters.AddWithValue("@maVach", (object)hangHoa.MaVach ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@quyCach", (object)hangHoa.QuyCachDongGoi ?? DBNull.Value);
                        //cmd.Parameters.AddWithValue("@trongLuong", (object)hangHoa.TrongLuong ?? DBNull.Value);
                        //cmd.Parameters.AddWithValue("@ngaySX", (object)hangHoa.NgaySanXuat ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@ghiChu", (object)hangHoa.GhiChu ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@maThuoc", (object)hangHoa.MaThuoc ?? DBNull.Value);
                        //cmd.Parameters.AddWithValue("@tenVietTat", (object)hangHoa.TenVietTat ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hoatChat", (object)hangHoa.HoatChatChinh ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hamLuong", (object)hangHoa.HamLuong ?? DBNull.Value);
                        //cmd.Parameters.AddWithValue("@duongDung", (object)hangHoa.DuongDung ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@hanSD", (object)hangHoa.HanSuDung ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@soDK", (object)hangHoa.SoDangKy ?? DBNull.Value);
                        //cmd.Parameters.AddWithValue("@tinhTrang", (object)hangHoa.TinhTrang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@tonKho", hangHoa.SoLuongTon);
                        cmd.Parameters.AddWithValue("@maNhom", (object)hangHoa.MaNhomHang ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@maHangSX", hangHoa.MaHangSX);
                        cmd.Parameters.AddWithValue("@tinhTrang", (object)hangHoa.TinhTrang ?? DBNull.Value); // Thêm tham số Tình trạng hàng hóa
                        cmd.ExecuteNonQuery();
                    }

                    // Tính tỷ lệ lợi nhuận
                    decimal tiLeLoi = 0;
                    if (hangHoa.GiaVon > 0 && hangHoa.GiaBan > 0)
                        tiLeLoi = ((hangHoa.GiaBan - hangHoa.GiaVon) / hangHoa.GiaVon) * 100;

                    // Lưu giá bán
                    ClassGiaBanHH giaBan = new ClassGiaBanHH
                    {
                        MaHangHoa = hangHoa.MaHangHoa,
                        GiaVon = hangHoa.GiaVon,
                        GiaBan = hangHoa.GiaBan,
                        MaDonViTinh = hangHoa.MaDonViTinh,
                        TiLeLoi = tiLeLoi
                    };

                    if (!ClassGiaBanHH.ThemGiaBan(giaBan, conn, transaction))
                        throw new Exception("Lỗi khi thêm giá bán hàng hóa.");

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

        public static List<ClassHangHoa> TimKiemHangHoa(string tuKhoa)
        {
            var danhSach = new List<ClassHangHoa>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
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
                HH.MA_HANG_HOA LIKE @tuKhoa OR
                HH.TEN_HANG_HOA LIKE @tuKhoa
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
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
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
        LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
        LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX
        WHERE HH.MA_HANG_HOA = @maHH AND DVT.MA_DON_VI_TINH = @maDVT";

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
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
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




    }




}
