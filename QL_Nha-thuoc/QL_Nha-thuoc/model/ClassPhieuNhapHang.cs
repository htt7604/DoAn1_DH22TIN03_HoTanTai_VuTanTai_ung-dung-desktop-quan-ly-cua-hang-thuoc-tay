using QL_Nha_thuoc.model;
using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

public class ClassPhieuNhapHang
{
    // ===== 1. Thuộc tính =====
    public string MaPhieuNhap { get; set; }
    public DateTime? NgayTaoPhieu { get; set; }
    public string MaNhaCungCap { get; set; }
    public string MaNhanVien { get; set; }
    public decimal? TongTienNhapHang { get; set; }
    public decimal? GiamGia { get; set; }
    public decimal? SoTienPhaiTra { get; set; }
    public decimal? SoTienDaTra { get; set; }
    public string GhiChuPhieuNhap { get; set; }
    public string TrangThai { get; set; }
    public DateTime? NgayNhap { get; set; }
    public string TenNhaCungCap { get; set; }
    public string TenNhanVien { get; set; } // Tên nhân viên tạo phiếu nhập

    // ===== 2. Constructor =====
    public ClassPhieuNhapHang() { }

    public ClassPhieuNhapHang(string maPhieu, DateTime? ngayTao, string maNCC, string maNV,
                              decimal? tongTien, decimal? giamGia, decimal? phaiTra, decimal? daTra,
                              string ghiChu, string trangThai, DateTime? ngayNhap, string tenNhaCungCap, string tenNhanVien)
    {
        MaPhieuNhap = maPhieu;
        NgayTaoPhieu = ngayTao;
        MaNhaCungCap = maNCC;
        MaNhanVien = maNV;
        TongTienNhapHang = tongTien;
        GiamGia = giamGia;
        SoTienPhaiTra = phaiTra;
        SoTienDaTra = daTra;
        GhiChuPhieuNhap = ghiChu;
        TrangThai = trangThai;
        NgayNhap = ngayNhap;
        TenNhaCungCap = tenNhaCungCap;
        TenNhanVien = tenNhanVien;
    }





    // ===== 4. Tạo mã phiếu nhập tự động =====
    public static string TaoMaPhieuNhap()
    {
        string prefix = "PN" + DateTime.Now.ToString("yyyyMMdd");
        int stt = 1;

        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string query = "SELECT MAX(MA_PHIEU_NHAP) FROM PHIEU_NHAP_HANG WHERE MA_PHIEU_NHAP LIKE @prefix + '%'";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@prefix", prefix);
            object result = cmd.ExecuteScalar();

            if (result != DBNull.Value && result != null)
            {
                string maxCode = result.ToString();
                int.TryParse(maxCode.Substring(prefix.Length), out stt);
                stt++;
            }
        }
        return prefix + stt.ToString("D3");
    }

    // ===== 5. Thêm phiếu nhập =====
    public static bool ThemPhieuNhap(ClassPhieuNhapHang classPhieuNhapHang)
    {
        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = @"INSERT INTO PHIEU_NHAP_HANG
                          (MA_PHIEU_NHAP, NGAY_TAO_PHIEU, MA_NHA_CUNG_CAP, MA_NV,
                           TONG_TIEN_NHAP_HANG, GIAM_GIA, SO_TIEN_PHAI_TRA, SO_TIEN_DA_TRA,
                           GHI_CHU_PHIEU_NHAP, TRANG_THAI, NGAY_NHAP)
                           VALUES (@MaPhieu, @NgayTao, @MaNCC, @MaNV, 
                                   @TongTien, @GiamGia, @PhaiTra, @DaTra, 
                                   @GhiChu, @TrangThai, @NgayNhap)";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhieu", classPhieuNhapHang. MaPhieuNhap);
            cmd.Parameters.AddWithValue("@NgayTao", (object)classPhieuNhapHang.NgayTaoPhieu ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@MaNCC", classPhieuNhapHang. MaNhaCungCap);
            cmd.Parameters.AddWithValue("@MaNV", classPhieuNhapHang.MaNhanVien);
            cmd.Parameters.AddWithValue("@TongTien", (object)classPhieuNhapHang.TongTienNhapHang ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GiamGia", (object)classPhieuNhapHang.GiamGia ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@PhaiTra", (object)classPhieuNhapHang.SoTienPhaiTra ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DaTra", (object)classPhieuNhapHang.SoTienDaTra ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@GhiChu", (object)classPhieuNhapHang.GhiChuPhieuNhap ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@TrangThai", (object)classPhieuNhapHang.TrangThai ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@NgayNhap", (object)classPhieuNhapHang.NgayNhap ?? DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }
    }












    // ClassPhieuNhapHang
    // ClassPhieuNhapHang
    public static bool KiemTraTonTai(string maPhieuNhap)
    {
        string query = "SELECT COUNT(*) FROM PHIEU_NHAP_HANG WHERE MA_PHIEU_NHAP = @ma";
        using (SqlConnection conn = CSDL.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@ma", maPhieuNhap);
            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }

    public static bool CapNhatPhieuNhap(ClassPhieuNhapHang phieu)
    {
        string query = @"UPDATE PHIEU_NHAP_HANG
                     SET NGAY_TAO_PHIEU = @ngayTao,
                         MA_NHA_CUNG_CAP = @ncc,
                         MA_NV = @nv,
                         TONG_TIEN_NHAP_HANG = @tongTien,
                         GIAM_GIA = @giamGia,
                         SO_TIEN_PHAI_TRA = @canTra,
                         SO_TIEN_DA_TRA = @daTra,
                         GHI_CHU_PHIEU_NHAP = @ghiChu,
                         NGAY_NHAP = @ngayNhap,
                         TRANG_THAI = @trangThai
                     WHERE MA_PHIEU_NHAP = @ma";

        using (SqlConnection conn = CSDL.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@ngayTao", phieu.NgayTaoPhieu);
            cmd.Parameters.AddWithValue("@ncc", phieu.MaNhaCungCap);
            cmd.Parameters.AddWithValue("@nv", phieu.MaNhanVien);
            cmd.Parameters.AddWithValue("@tongTien", phieu.TongTienNhapHang);
            cmd.Parameters.AddWithValue("@giamGia", phieu.GiamGia);
            cmd.Parameters.AddWithValue("@canTra", phieu.SoTienPhaiTra);
            cmd.Parameters.AddWithValue("@daTra", phieu.SoTienDaTra);
            cmd.Parameters.AddWithValue("@ghiChu", phieu.GhiChuPhieuNhap);
            cmd.Parameters.AddWithValue("@ngayNhap", phieu.NgayNhap);
            cmd.Parameters.AddWithValue("@trangThai", phieu.TrangThai);
            cmd.Parameters.AddWithValue("@ma", phieu.MaPhieuNhap);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

    public static bool CapNhatGhiChuPhieuNhap(ClassPhieuNhapHang phieu)
    {
        string query = @"UPDATE PHIEU_NHAP_HANG
                     SET 
                         GHI_CHU_PHIEU_NHAP = @ghiChu
                     WHERE MA_PHIEU_NHAP = @ma";

        using (SqlConnection conn = CSDL.GetConnection())
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@ghiChu", phieu.GhiChuPhieuNhap);
            cmd.Parameters.AddWithValue("@ma", phieu.MaPhieuNhap);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }










    // ===== 6. "Xóa" phiếu nhập bằng cách đổi trạng thái =====
    public static bool XoaPhieuNhap(string maPhieu)
    {
        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = "UPDATE PHIEU_NHAP_HANG SET TRANG_THAI = N'Đã xóa' WHERE MA_PHIEU_NHAP = @MaPhieu";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
            return cmd.ExecuteNonQuery() > 0;
        }

    }

    // ===== 7. Lấy danh sách phiếu nhập =====
    public static DataTable LayDanhSachPhieuNhap()
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = "SELECT * FROM PHIEU_NHAP_HANG WHERE TRANG_THAI IS NULL OR TRANG_THAI <> N'Đã xóa' ORDER BY NGAY_TAO_PHIEU DESC";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(dt);
        }
        return dt;
    }














    // ===== 8. Lấy danh sách phiếu nhập theo Mã Nhà Cung Cấp (trả về List) =====
    public static List<ClassPhieuNhapHang> TimTheoMaNhaCungCap(string maNCC)
    {
        List<ClassPhieuNhapHang> list = new List<ClassPhieuNhapHang>();

        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = @"SELECT * 
                       FROM PHIEU_NHAP_HANG
                       WHERE MA_NHA_CUNG_CAP = @MaNCC
                         AND (TRANG_THAI IS NULL OR TRANG_THAI <> N'Đã xóa')
                       ORDER BY NGAY_TAO_PHIEU DESC";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phieu = new ClassPhieuNhapHang
                        {
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                            NgayTaoPhieu = reader["NGAY_TAO_PHIEU"] as DateTime?,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"].ToString(),
                            MaNhanVien = reader["MA_NV"].ToString(),
                            TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] as decimal?,
                            GiamGia = reader["GIAM_GIA"] as decimal?,
                            SoTienPhaiTra = reader["SO_TIEN_PHAI_TRA"] as decimal?,
                            SoTienDaTra = reader["SO_TIEN_DA_TRA"] as decimal?,
                            GhiChuPhieuNhap = reader["GHI_CHU_PHIEU_NHAP"]?.ToString(),
                            TrangThai = reader["TRANG_THAI"]?.ToString(),
                            NgayNhap = reader["NGAY_NHAP"] as DateTime?
                        };
                        list.Add(phieu);
                    }
                }
            }
        }

        return list;
    }







    // ===== 9. Tìm phiếu nhập theo Mã Phiếu Nhập (trả về 1 object) =====
    public static ClassPhieuNhapHang TimTheoMaPhieuNhap(string maPhieu)
    {
        ClassPhieuNhapHang phieu = null;

        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = @"SELECT *  FROM PHIEU_NHAP_HANG PNH JOIN NHAN_VIEN NV ON NV.MA_NV=PNH.MA_NV
									JOIN NHA_CUNG_CAP NCC ON NCC.MA_NHA_CUNG_CAP=PNH.MA_NHA_CUNG_CAP
											WHERE MA_PHIEU_NHAP = @MaPhieu AND (PNH.TRANG_THAI IS NULL OR PNH.TRANG_THAI <> 'Đã xóa')";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        phieu = new ClassPhieuNhapHang
                        {
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                            NgayTaoPhieu = reader["NGAY_TAO_PHIEU"] as DateTime?,
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"].ToString(),
                            MaNhanVien = reader["MA_NV"].ToString(),
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            TenNhanVien = reader["HO_TEN_NV"]?.ToString(),
                            TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] as decimal?,
                            GiamGia = reader["GIAM_GIA"] as decimal?,
                            SoTienPhaiTra = reader["SO_TIEN_PHAI_TRA"] as decimal?,
                            SoTienDaTra = reader["SO_TIEN_DA_TRA"] as decimal?,
                            GhiChuPhieuNhap = reader["GHI_CHU_PHIEU_NHAP"]?.ToString(),
                            TrangThai = reader["TRANG_THAI"]?.ToString(),
                            NgayNhap = reader["NGAY_NHAP"] as DateTime?
                        };
                    }
                }
            }
        }

        return phieu;
    }

    //public static List<ClassPhieuNhapHang> GetDanhSachPhieuNhapHang()
    //{
    //    List<ClassPhieuNhapHang> danhSachPhieu = new List<ClassPhieuNhapHang>();

    //    using (SqlConnection conn = CSDL.GetConnection())
    //    {
    //        conn.Open();
    //        string query = @"
    //        SELECT 
    //         PN.MA_PHIEU_NHAP, 
    //         PN.NGAY_TAO_PHIEU,
    //         PN.NGAY_NHAP,
    //         PN.MA_NHA_CUNG_CAP,
    //         NCC.TEN_NHA_CUNG_CAP,
    //         PN.MA_NV,
    //         NV.HO_TEN_NV,
    //         PN.TONG_TIEN_NHAP_HANG,
    //         PN.GIAM_GIA,
    //         PN.SO_TIEN_PHAI_TRA,
    //         PN.SO_TIEN_DA_TRA,
    //         PN.GHI_CHU_PHIEU_NHAP,
    //         PN.TRANG_THAI
    //     FROM PHIEU_NHAP_HANG PN
    //     JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
    //     JOIN NHAN_VIEN NV ON PN.MA_NV = NV.MA_NV
    //     ORDER BY PN.NGAY_NHAP DESC";

    //        SqlCommand cmd = new SqlCommand(query, conn);
    //        SqlDataReader reader = cmd.ExecuteReader();

    //        while (reader.Read())
    //        {
    //            danhSachPhieu.Add(new ClassPhieuNhapHang
    //            {
    //                MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
    //                NgayTaoPhieu = reader["NGAY_TAO_PHIEU"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_TAO_PHIEU"]) : (DateTime?)null,
    //                NgayNhap = reader["NGAY_NHAP"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_NHAP"]) : (DateTime?)null,
    //                MaNhaCungCap = reader["MA_NHA_CUNG_CAP"].ToString(),
    //                TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
    //                MaNhanVien = reader["MA_NV"].ToString(),
    //                TenNhanVien = reader["HO_TEN_NV"].ToString(),
    //                TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_NHAP_HANG"]) : 0,
    //                GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : 0,
    //                SoTienPhaiTra = reader["SO_TIEN_PHAI_TRA"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_PHAI_TRA"]) : 0,
    //                SoTienDaTra = reader["SO_TIEN_DA_TRA"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_DA_TRA"]) : 0,
    //                GhiChuPhieuNhap = reader["GHI_CHU_PHIEU_NHAP"].ToString(),
    //                TrangThai = reader["TRANG_THAI"]?.ToString()
    //            });
    //        }
    //    }

    //    return danhSachPhieu;
    //}

    public static List<ClassPhieuNhapHang> GetDanhSachPhieuNhapHang()
    {
        List<ClassPhieuNhapHang> danhSachPhieu = new List<ClassPhieuNhapHang>();

        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string query = @"
            SELECT 
                PN.MA_PHIEU_NHAP, 
                PN.NGAY_NHAP,
                NCC.TEN_NHA_CUNG_CAP,
                PN.SO_TIEN_DA_TRA,
                PN.TRANG_THAI
            FROM PHIEU_NHAP_HANG PN
            JOIN NHA_CUNG_CAP NCC 
                ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
            ORDER BY PN.NGAY_NHAP DESC";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                danhSachPhieu.Add(new ClassPhieuNhapHang
                {
                    MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                    NgayNhap = reader["NGAY_NHAP"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_NHAP"]) : (DateTime?)null,
                    TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                    SoTienDaTra = reader["SO_TIEN_DA_TRA"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_DA_TRA"]) : 0,
                    TrangThai = reader["TRANG_THAI"]?.ToString()
                });
            }
        }

        return danhSachPhieu;
    }


    public static string LayTrangThaiPhieuNhap(string maPhieuNhap)
    {
        using (SqlConnection conn = CSDL.GetConnection())
        {
            conn.Open();
            string sql = "SELECT TRANG_THAI FROM PHIEU_NHAP_HANG WHERE MA_PHIEU_NHAP = @maPhieu";

            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@maPhieu", maPhieuNhap);
                object result = cmd.ExecuteScalar();
                return result?.ToString();
            }
        }

    }




}
