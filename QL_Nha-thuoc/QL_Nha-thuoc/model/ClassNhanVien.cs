using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class ClassNhanVien
    {
        public string MaNhanVien { get; set; }
        public string HinhAnh { get; set; }
        public string HoTenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCCCD { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string TrangThai { get; set; }
        public DateTime? NgayBatDauLamViec { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }

        // ====== Lấy tất cả nhân viên ======
        public static List<ClassNhanVien> LayTatCaNhanVien()
        {
            List<ClassNhanVien> danhSach = new List<ClassNhanVien>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM NHAN_VIEN";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassNhanVien nv = new ClassNhanVien
                    {
                        MaNhanVien = reader["MA_NV"].ToString(),
                        HinhAnh = reader["HINH_ANH_NV"]?.ToString(),
                        HoTenNhanVien = reader["HO_TEN_NV"]?.ToString(),
                        DiaChi = reader["DIA_CHI_NV"]?.ToString(),
                        SoDienThoai = reader["SDT_NV"]?.ToString(),
                        SoCCCD = reader["SO_CCCD/CMND_NV"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH_NV"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_SINH_NV"]),
                        GioiTinh = reader["GIOI_TINH_NV"]?.ToString(),
                        TrangThai = reader["TRANG_THAI_NV"]?.ToString(),
                        NgayBatDauLamViec = reader["NGAY_BAT_DAU_LAM_VIEC"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_BAT_DAU_LAM_VIEC"]),
                        Email = reader["EMAIL"]?.ToString(),
                        Facebook = reader["FACEBOOK"]?.ToString()
                    };
                    danhSach.Add(nv);
                }

                reader.Close();
            }

            return danhSach;
        }
        // ====== Tìm nhân viên theo từ khóa và trạng thái ======
        public static List<ClassNhanVien> TimNhanVien(string tuKhoa, string trangThai)
        {
            List<ClassNhanVien> danhSach = new List<ClassNhanVien>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM NHAN_VIEN WHERE 1=1";

                if (!string.IsNullOrEmpty(tuKhoa))
                    query += " AND HO_TEN_NV LIKE @TuKhoa";

                if (!string.IsNullOrEmpty(trangThai))
                    query += " AND TRANG_THAI_NV = @TrangThai";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(tuKhoa))
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                if (!string.IsNullOrEmpty(trangThai))
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    danhSach.Add(new ClassNhanVien
                    {
                        MaNhanVien = reader["MA_NV"].ToString(),
                        HinhAnh = reader["HINH_ANH_NV"]?.ToString(),
                        HoTenNhanVien = reader["HO_TEN_NV"]?.ToString(),
                        DiaChi = reader["DIA_CHI_NV"]?.ToString(),
                        SoDienThoai = reader["SDT_NV"]?.ToString(),
                        SoCCCD = reader["SO_CCCD/CMND_NV"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH_NV"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_SINH_NV"]),
                        GioiTinh = reader["GIOI_TINH_NV"]?.ToString(),
                        TrangThai = reader["TRANG_THAI_NV"]?.ToString(),
                        NgayBatDauLamViec = reader["NGAY_BAT_DAU_LAM_VIEC"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_BAT_DAU_LAM_VIEC"]),
                        Email = reader["EMAIL"]?.ToString(),
                        Facebook = reader["FACEBOOK"]?.ToString()
                    });
                }

                reader.Close();
            }

            return danhSach;
        }

        // ====== Lấy nhân viên theo mã ======
        public static ClassNhanVien LayNhanVienTheoMa(string maNhanVien)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM NHAN_VIEN WHERE MA_NV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNhanVien);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    var nv = new ClassNhanVien
                    {
                        MaNhanVien = reader["MA_NV"].ToString(),
                        HinhAnh = reader["HINH_ANH_NV"]?.ToString(),
                        HoTenNhanVien = reader["HO_TEN_NV"]?.ToString(),
                        DiaChi = reader["DIA_CHI_NV"]?.ToString(),
                        SoDienThoai = reader["SDT_NV"]?.ToString(),
                        SoCCCD = reader["SO_CCCD/CMND_NV"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH_NV"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_SINH_NV"]),
                        GioiTinh = reader["GIOI_TINH_NV"]?.ToString(),
                        TrangThai = reader["TRANG_THAI_NV"]?.ToString(),
                        NgayBatDauLamViec = reader["NGAY_BAT_DAU_LAM_VIEC"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_BAT_DAU_LAM_VIEC"]),
                        Email = reader["EMAIL"]?.ToString(),
                        Facebook = reader["FACEBOOK"]?.ToString()
                    };
                    reader.Close();
                    return nv;
                }

                reader.Close();
                return null;
            }
        }

        // ====== Tạo mã nhân viên tự động ======
        public static string TaoMaNhanVienTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT TOP 1 MA_NV FROM NHAN_VIEN ORDER BY MA_NV DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                var result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string maCuoi = result.ToString(); // VD: NV005
                    if (maCuoi.Length <= 2)
                        return "NV001";

                    if (!int.TryParse(maCuoi.Substring(2), out int so))
                        return "NV001";

                    so++;
                    return "NV" + so.ToString("D3");
                }
                else
                {
                    return "NV001";
                }
            }
        }

        // ====== Thêm nhân viên ======
        public static bool ThemNhanVien(ClassNhanVien nv)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"INSERT INTO NHAN_VIEN 
                    (MA_NV, HINH_ANH_NV, HO_TEN_NV, DIA_CHI_NV, SDT_NV, [SO_CCCD/CMND_NV], NGAY_SINH_NV, GIOI_TINH_NV, TRANG_THAI_NV, NGAY_BAT_DAU_LAM_VIEC, EMAIL, FACEBOOK)
                    VALUES (@MaNV, @Hinhanh, @HoTen, @DiaChi, @SDT, @CCCD, @NgaySinh, @GioiTinh, @TrangThai, @NgayLamViec, @Email, @Facebook)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
                cmd.Parameters.AddWithValue("@Hinhanh", (object)nv.HinhAnh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTenNhanVien);
                cmd.Parameters.AddWithValue("@DiaChi", (object)nv.DiaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)nv.SoDienThoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CCCD", (object)nv.SoCCCD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", (object)nv.TrangThai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayLamViec", nv.NgayBatDauLamViec ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)nv.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Facebook", (object)nv.Facebook ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====== Sửa nhân viên ======
        public static bool SuaNhanVien(ClassNhanVien nv)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"UPDATE NHAN_VIEN SET 
                    HINH_ANH_NV = @Hinhanh,
                    HO_TEN_NV = @HoTen, 
                    DIA_CHI_NV = @DiaChi, 
                    SDT_NV = @SDT, 
                    [SO_CCCD/CMND_NV] = @CCCD, 
                    NGAY_SINH_NV = @NgaySinh, 
                    GIOI_TINH_NV = @GioiTinh, 
                    TRANG_THAI_NV = @TrangThai,
                    NGAY_BAT_DAU_LAM_VIEC = @NgayLamViec,
                    EMAIL = @Email,
                    FACEBOOK = @Facebook
                    WHERE MA_NV = @MaNV";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", nv.MaNhanVien);
                cmd.Parameters.AddWithValue("@Hinhanh", (object)nv.HinhAnh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@HoTen", nv.HoTenNhanVien);
                cmd.Parameters.AddWithValue("@DiaChi", (object)nv.DiaChi ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@SDT", (object)nv.SoDienThoai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CCCD", (object)nv.SoCCCD ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgaySinh", nv.NgaySinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GioiTinh", (object)nv.GioiTinh ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThai", (object)nv.TrangThai ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayLamViec", nv.NgayBatDauLamViec ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object)nv.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Facebook", (object)nv.Facebook ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // ====== Xóa nhân viên ======
        public static bool XoaNhanVien(string maNhanVien)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "DELETE FROM NHAN_VIEN WHERE MA_NV = @MaNV";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNhanVien);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
