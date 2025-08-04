using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class ClassKhachHang
    {
        // ====== THUỘC TÍNH ======
        public string MaKH { get; set; }
        public string MaNhomKH { get; set; }
        public string TenKH { get; set; }
        public string? SDT { get; set; }
        public string DiaChiKH { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayTaoKH { get; set; }
        public string TrangThaiKH { get; set; }
        public string SoCCCD_CMND { get; set; }
        public string Email { get; set; } // Thêm thuộc tính Email nếu cần
        public string HinhAnhKh{ get; set; }
        public string MaNV { get; set; } // Mã nhân viên tạo khách hàng
        public string TenNhomKH { get; set; }
        public string TenCongTy {  get; set; }
        public string GhiChu { get; set; }
        public string nguoiTao { get; set; }
        public string MaSoThue { get; set; }
        public string ThongTinDayDu => $"{TenKH} ( {DiaChiKH} )";

        // ====== CHUỖI KẾT NỐI ======
        //ham tao ma khach hang tu dong
        public static string TaoMaKhachHangTuDong()
        {
            string maMoi = "KH001"; // Mặc định nếu không có khách hàng nào
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT TOP 1 MA_KH FROM KHACH_HANG WHERE ISNUMERIC(SUBSTRING(MA_KH, 3, LEN(MA_KH))) = 1 ORDER BY CAST(SUBSTRING(MA_KH, 3, LEN(MA_KH)) AS INT) DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string maCu = result.ToString(); // Ví dụ: KH025
                    int soCu = int.Parse(maCu.Substring(2)); // Lấy phần số: 25
                    int soMoi = soCu + 1;
                    maMoi = "KH" + soMoi.ToString("D3"); // => KH026
                }
            }
            return maMoi;
        }



        // ====== LẤY TOÀN BỘ KHÁCH HÀNG ======
        public static List<ClassKhachHang> LayDanhSachKhachHang()
        {
            List<ClassKhachHang> danhSach = new List<ClassKhachHang>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM KHACH_HANG KH join NHOM_KH NKH on NKH.MA_NHOM_KH=KH.MA_NHOM_KH join NHAN_VIEN NV on NV.MA_NV=KH.MA_NV ";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassKhachHang kh = new ClassKhachHang
                    {
                        MaKH = reader["MA_KH"].ToString(),
                        MaNhomKH = reader["MA_NHOM_KH"]?.ToString(),
                        TenKH = reader["TEN_KH"]?.ToString(),
                        SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : null,
                        DiaChiKH = reader["DIA_CHI_KH"]?.ToString(),
                        GioiTinh = reader["GIOI_TINH"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_SINH"]) : (DateTime?)null,
                        NgayTaoKH = reader["NGAY_TAO_KH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_TAO_KH"]) : (DateTime?)null,
                        TrangThaiKH = reader["TRANG_THAI_KH"]?.ToString(),
                        SoCCCD_CMND = reader["SO_CCCD"]?.ToString(),
                        TenNhomKH = reader["TEN_NHOM_KH"]?.ToString(),// Lấy tên nhóm khách hàng nếu cần
                        HinhAnhKh = reader["HINH_ANH_KH"]?.ToString(), // Lấy hình ảnh khách hàng nếu cần
                        GhiChu = reader["GHI_CHU_KH"]?.ToString(), // Lấy ghi chú nếu có
                        nguoiTao = reader["HO_TEN_NV"]?.ToString(), // Lấy tên người tạo nếu có
                        MaSoThue = reader["MA_SO_THUE"]?.ToString(), // Lấy mã số thuế nếu có
                        Email = reader["EMAIL"]?.ToString(), // Lấy email nếu có
                        TenCongTy = reader["TEN_CONG_TY"]?.ToString()
                    };

                    danhSach.Add(kh);
                }
                reader.Close();
            }

            return danhSach;
        }


        //danh sach theo ten
        public static List<ClassKhachHang> TimDanhSachKhachHangTheoTen(string tenKH)
        {
            List<ClassKhachHang> danhSach = new List<ClassKhachHang>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM KHACH_HANG KH join NHOM_KH NKH on NKH.MA_NHOM_KH=KH.MA_NHOM_KH join NHAN_VIEN NV on KH.MA_NV=NV.MA_NV WHERE TEN_KH COLLATE SQL_Latin1_General_CP1_CI_AS LIKE '%' + @tenKH + '%'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenKH", tenKH);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassKhachHang kh = new ClassKhachHang
                    {
                        MaKH = reader["MA_KH"].ToString(),
                        MaNhomKH = reader["MA_NHOM_KH"]?.ToString(),
                        TenKH = reader["TEN_KH"]?.ToString(),
                        SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : null,
                        DiaChiKH = reader["DIA_CHI_KH"]?.ToString(),
                        GioiTinh = reader["GIOI_TINH"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_SINH"]) : (DateTime?)null,
                        NgayTaoKH = reader["NGAY_TAO_KH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_TAO_KH"]) : (DateTime?)null,
                        TrangThaiKH = reader["TRANG_THAI_KH"]?.ToString(),
                        SoCCCD_CMND = reader["SO_CCCD"]?.ToString(),
                        TenNhomKH = reader["TEN_NHOM_KH"]?.ToString(),// Lấy tên nhóm khách hàng nếu cần
                        HinhAnhKh = reader["HINH_ANH_KH"]?.ToString(), // Lấy hình ảnh khách hàng nếu cần
                        GhiChu = reader["GHI_CHU_KH"]?.ToString(), // Lấy ghi chú nếu có
                        nguoiTao = reader["HO_TEN_NV"]?.ToString(), // Lấy tên người tạo nếu có
                        MaSoThue = reader["MA_SO_THUE"]?.ToString(), // Lấy mã số thuế nếu có
                        Email = reader["EMAIL"]?.ToString(), // Lấy email nếu có
                        TenCongTy = reader["TEN_CONG_TY"]?.ToString(),
                    };

                    danhSach.Add(kh);
                }

                reader.Close();
            }

            return danhSach;
        }





        //tim theo loai tim kiem
        public static List<ClassKhachHang> TimKhachHang(string loaiTimKiem, string tuKhoa)
        {
            List<ClassKhachHang> danhSach = new List<ClassKhachHang>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "";

                if (loaiTimKiem == "Mã KH")
                {
                    query = @"
                SELECT * FROM KHACH_HANG KH join NHOM_KH NKH on NKH.MA_NHOM_KH=KH.MA_NHOM_KH join NHAN_VIEN NV on NV.MA_NV=KH.MA_NV
                WHERE CONVERT(varchar, MA_KH) LIKE @tuKhoa COLLATE SQL_Latin1_General_CP1_CI_AS";
                }
                else if (loaiTimKiem == "Tên KH")
                {
                    query = @"
                SELECT * FROM KHACH_HANG KH join NHOM_KH NKH on NKH.MA_NHOM_KH=KH.MA_NHOM_KH join NHAN_VIEN NV on NV.MA_NV=KH.MA_NV
                WHERE TEN_KH LIKE @tuKhoa COLLATE SQL_Latin1_General_CP1_CI_AS";
                }

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ClassKhachHang kh = new ClassKhachHang
                    {
                        MaKH = reader["MA_KH"].ToString(),
                        MaNhomKH = reader["MA_NHOM_KH"]?.ToString(),
                        TenKH = reader["TEN_KH"]?.ToString(),
                        SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : null,
                        DiaChiKH = reader["DIA_CHI_KH"]?.ToString(),
                        GioiTinh = reader["GIOI_TINH"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_SINH"]) : (DateTime?)null,
                        NgayTaoKH = reader["NGAY_TAO_KH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_TAO_KH"]) : (DateTime?)null,
                        TrangThaiKH = reader["TRANG_THAI_KH"]?.ToString(),
                        SoCCCD_CMND = reader["SO_CCCD"]?.ToString(),
                        TenNhomKH = reader["TEN_NHOM_KH"]?.ToString(),// Lấy tên nhóm khách hàng nếu cần
                        HinhAnhKh = reader["HINH_ANH_KH"]?.ToString(), // Lấy hình ảnh khách hàng nếu cần
                        GhiChu = reader["GHI_CHU_KH"]?.ToString(), // Lấy ghi chú nếu có
                        nguoiTao = reader["HO_TEN_NV"]?.ToString(), // Lấy tên người tạo nếu có
                        MaSoThue = reader["MA_SO_THUE"]?.ToString(), // Lấy mã số thuế nếu có
                        Email = reader["EMAIL"]?.ToString(), // Lấy email nếu có
                        TenCongTy = reader["TEN_CONG_TY"]?.ToString()
                    };
                    danhSach.Add(kh);
                }
                reader.Close();
            }

            return danhSach;
        }

        // ====== LẤY THÔNG TIN KHÁCH HÀNG THEO MÃ ======
        public static ClassKhachHang LayThongTinKhachHangTheoMa(string maKH)
        {
            ClassKhachHang kh = null;
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM KHACH_HANG KH join NHOM_KH NKH on NKH.MA_NHOM_KH=KH.MA_NHOM_KH join NHAN_VIEN NV on NV.MA_NV=KH.MA_NV WHERE KH.MA_KH = @maKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    kh = new ClassKhachHang

                    {
                        MaKH = reader["MA_KH"].ToString(),
                        MaNhomKH = reader["MA_NHOM_KH"]?.ToString(),
                        TenKH = reader["TEN_KH"]?.ToString(),
                        SDT = reader["SDT"] != DBNull.Value ? reader["SDT"].ToString() : null,
                        DiaChiKH = reader["DIA_CHI_KH"]?.ToString(),
                        GioiTinh = reader["GIOI_TINH"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_SINH"]) : (DateTime?)null,
                        NgayTaoKH = reader["NGAY_TAO_KH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_TAO_KH"]) : (DateTime?)null,
                        TrangThaiKH = reader["TRANG_THAI_KH"]?.ToString(),
                        SoCCCD_CMND = reader["SO_CCCD"]?.ToString(),
                        TenNhomKH = reader["TEN_NHOM_KH"]?.ToString(),// Lấy tên nhóm khách hàng nếu cần
                        HinhAnhKh = reader["HINH_ANH_KH"]?.ToString(), // Lấy hình ảnh khách hàng nếu cần
                        GhiChu = reader["GHI_CHU_KH"]?.ToString(), // Lấy ghi chú nếu có
                        nguoiTao = reader["HO_TEN_NV"]?.ToString(), // Lấy tên người tạo nếu có
                        MaSoThue = reader["MA_SO_THUE"]?.ToString(), // Lấy mã số thuế nếu có
                        Email = reader["EMAIL"]?.ToString(), // Lấy email nếu có
                        TenCongTy = reader["TEN_CONG_TY"]?.ToString()
                    };
                }
                reader.Close();
            }
            return kh;

        }

        // ====== LƯU THÔNG TIN KHÁCH HÀNG ======
        public static bool ThemKhachHang(ClassKhachHang khachHang)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
        INSERT INTO KHACH_HANG 
        (MA_KH, MA_NHOM_KH, TEN_KH, SDT, DIA_CHI_KH, GIOI_TINH, NGAY_SINH, NGAY_TAO_KH, TRANG_THAI_KH, 
         SO_CCCD, MA_SO_THUE, GHI_CHU_KH, HINH_ANH_KH, EMAIL, MA_NV,TEN_CONG_TY)
        VALUES
        (@MaKH, @MaNhomKH, @TenKH, @SDT, @DiaChiKH, @GioiTinh, @NgaySinh, @NgayTaoKH, @TrangThaiKH,
         @SoCCCD_CMND, @MaSoThue, @GhiChu, @HinhAnhKh, @Email, @MaNV,@TenCongTy)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);
                cmd.Parameters.AddWithValue("@MaNhomKH", (object?)khachHang.MaNhomKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TenKH", (object?)khachHang.TenKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object?)khachHang.SDT ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DiaChiKH", (object?)khachHang.DiaChiKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", (object?)khachHang.GioiTinh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgaySinh", (object?)khachHang.NgaySinh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayTaoKH", (object?)khachHang.NgayTaoKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThaiKH", (object?)khachHang.TrangThaiKH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SoCCCD_CMND", (object?)khachHang.SoCCCD_CMND ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaSoThue", (object?)khachHang.MaSoThue ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", (object?)khachHang.GhiChu ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HinhAnhKh", (object?)khachHang.HinhAnhKh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email",(object)khachHang.Email ?? DBNull.Value); 
                cmd.Parameters.AddWithValue("@MaNV", (object?)khachHang.MaNV ?? DBNull.Value);
                cmd.Parameters.AddWithValue("TenCongTy", (object)khachHang.TenCongTy ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====== CẬP NHẬT THÔNG TIN KHÁCH HÀNG ======
        public static bool CapNhatThongTinKhachHang(ClassKhachHang khachHang)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
UPDATE KHACH_HANG
SET 
    MA_NHOM_KH = @MaNhomKH,
    TEN_KH = @TenKH,
    SDT = @SDT,
    DIA_CHI_KH = @DiaChiKH,
    GIOI_TINH = @GioiTinh,
    NGAY_SINH = @NgaySinh,
    NGAY_TAO_KH = @NgayTaoKH,
    TRANG_THAI_KH = @TrangThaiKH,
    SO_CCCD = @SoCCCD_CMND,
    GHI_CHU_KH = @GhiChu,
    HINH_ANH_KH = @HinhAnhKh,
    EMAIL = @Email,
    TEN_CONG_TY = @TenCongTy
WHERE MA_KH = @MaKH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhomKH", (object?)khachHang.MaNhomKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenKH", (object?)khachHang.TenKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SDT", (object?)khachHang.SDT ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DiaChiKH", (object?)khachHang.DiaChiKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GioiTinh", (object?)khachHang.GioiTinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgaySinh", (object?)khachHang.NgaySinh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NgayTaoKH", (object?)khachHang.NgayTaoKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TrangThaiKH", (object?)khachHang.TrangThaiKH ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@SoCCCD_CMND", (object?)khachHang.SoCCCD_CMND ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@GhiChu", (object?)khachHang.GhiChu ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@HinhAnhKh", (object?)khachHang.HinhAnhKh ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object?)khachHang.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TenCongTy", (object?)khachHang.TenCongTy ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@MaKH", khachHang.MaKH);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        // ====== XÓA KHÁCH HÀNG ======
        public static bool XoaKhachHang(int maKH)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "DELETE FROM KHACH_HANG WHERE MA_KH = @maKH";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maKH", maKH);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        



        }
}


