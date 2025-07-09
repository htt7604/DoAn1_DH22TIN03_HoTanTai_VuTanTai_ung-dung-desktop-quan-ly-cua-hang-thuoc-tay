using Microsoft.Data.SqlClient;
using System;

namespace QL_Nha_thuoc.model
{
    public class ClassNhaCungCap
    {
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChiNCC { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
        public decimal NoCanTraHienTai { get; set; }
        public decimal TongMua { get; set; }
        public string GhiChu { get; set; }

        public string TenCongTy { get;set; }
        public string MaSoThue { get; set; }
        public string TrangThai { get; set; }

        // Chuỗi kết nối đến cơ sở dữ liệu
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static List<ClassNhaCungCap> LayDanhSachNhaCungCap()
        {
            List<ClassNhaCungCap> danhSach = new List<ClassNhaCungCap>();

            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT * 
            FROM NHA_CUNG_CAP 
            WHERE TRANG_THAI IS NULL OR TRANG_THAI <> N'Đã xóa'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassNhaCungCap ncc = new ClassNhaCungCap()
                            {
                                MaNhaCungCap = reader["MA_NHA_CUNG_CAP"].ToString(),
                                TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                                DiaChiNCC = reader["DIA_CHI_NHA_CUNG_CAP"].ToString(),
                                DienThoai = reader["SDT_NHA_CUNG_CAP"].ToString(),
                                Email = reader["EMAIL_NHA_CUNG_CAP"].ToString(),
                                NoCanTraHienTai = reader["NO_CAN_TRA"] != DBNull.Value ? Convert.ToDecimal(reader["NO_CAN_TRA"]) : 0,
                                TongMua = reader["TONG_MUA"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_MUA"]) : 0,
                                GhiChu = reader["GHI_CHU"].ToString(),
                                TenCongTy = reader["TEN_CONG_TY"].ToString(),
                                MaSoThue = reader["MA_SO_THUE"].ToString(),
                                TrangThai = reader["TRANG_THAI"].ToString()
                            };
                            danhSach.Add(ncc);
                        }
                    }
                }
            }

            return danhSach;
        }

        public static List<ClassNhaCungCap> LayDanhSachNhaCungCapTheoLoai(string loaiTimKiem, string giaTriTimKiem)
        {
            List<ClassNhaCungCap> danhSach = new List<ClassNhaCungCap>();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT * 
            FROM NHA_CUNG_CAP 
            WHERE (TRANG_THAI IS NULL OR TRANG_THAI <> N'Đã xóa')";

                if (loaiTimKiem == "Mã NCC")
                {
                    query += " AND MA_NHA_CUNG_CAP LIKE @GiaTri";
                }
                else if (loaiTimKiem == "Tên nhà cung cấp")
                {
                    query += " AND TEN_NHA_CUNG_CAP LIKE @GiaTri";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@GiaTri", "%" + giaTriTimKiem + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassNhaCungCap ncc = new ClassNhaCungCap()
                            {
                                MaNhaCungCap = reader["MA_NHA_CUNG_CAP"].ToString(),
                                TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                                DiaChiNCC = reader["DIA_CHI_NHA_CUNG_CAP"].ToString(),
                                DienThoai = reader["SDT_NHA_CUNG_CAP"].ToString(),
                                Email = reader["EMAIL_NHA_CUNG_CAP"].ToString(),
                                NoCanTraHienTai = reader["NO_CAN_TRA"] != DBNull.Value ? Convert.ToDecimal(reader["NO_CAN_TRA"]) : 0,
                                TongMua = reader["TONG_MUA"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_MUA"]) : 0,
                                GhiChu = reader["GHI_CHU"].ToString(),
                                TenCongTy = reader["TEN_CONG_TY"].ToString(),
                                MaSoThue = reader["MA_SO_THUE"].ToString(),
                                TrangThai = reader["TRANG_THAI"].ToString()
                            };
                            danhSach.Add(ncc);
                        }
                    }
                }
            }

            return danhSach;
        }







        // Mã nhà cung cấp tự động
        public static string MaNhaCungCapTuDong()
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 MA_NHA_CUNG_CAP 
                    FROM NHA_CUNG_CAP 
                    WHERE MA_NHA_CUNG_CAP LIKE 'NCC%' 
                    ORDER BY CAST(SUBSTRING(MA_NHA_CUNG_CAP, 4, LEN(MA_NHA_CUNG_CAP)) AS INT) DESC";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null && !string.IsNullOrEmpty(result.ToString()))
                    {
                        string lastMa = result.ToString(); // VD: NCC009
                        int so = int.Parse(lastMa.Substring(3)); // Lấy 009 => 9
                        so++; // => 10
                        return "NCC" + so.ToString("D3"); // => NCC010
                    }
                    else
                    {
                        return "NCC001"; // Trường hợp chưa có mã nào
                    }
                }
            }
        }

        // Thêm nhà cung cấp
        public static void ThemNhaCungCap(ClassNhaCungCap ncc)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO NHA_CUNG_CAP 
                    (MA_NHA_CUNG_CAP, TEN_NHA_CUNG_CAP, DIA_CHI_NHA_CUNG_CAP, SDT_NHA_CUNG_CAP, EMAIL_NHA_CUNG_CAP, NO_CAN_TRA, TONG_MUA, GHI_CHU, TEN_CONG_TY, MA_SO_THUE, TRANG_THAI) 
                    VALUES 
                    (@MaNhaCungCap, @TenNhaCungCap, @DiaChiNCC, @DienThoai, @Email, @NoCanTraHienTai, @TongMua, @GhiChu, @TenCongTy, @MaSoThue,@TrangThai)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNhaCungCap", ncc.MaNhaCungCap);
                    cmd.Parameters.AddWithValue("@TenNhaCungCap", ncc.TenNhaCungCap);
                    cmd.Parameters.AddWithValue("@DiaChiNCC", ncc.DiaChiNCC);
                    cmd.Parameters.AddWithValue("@DienThoai", ncc.DienThoai);
                    cmd.Parameters.AddWithValue("@Email", ncc.Email);
                    cmd.Parameters.AddWithValue("@NoCanTraHienTai", ncc.NoCanTraHienTai);
                    cmd.Parameters.AddWithValue("@TongMua", ncc.TongMua);
                    cmd.Parameters.AddWithValue("@GhiChu", ncc.GhiChu);
                    cmd.Parameters.AddWithValue("@TenCongTy", ncc.TenCongTy ?? (object)DBNull.Value); // Nullable
                    cmd.Parameters.AddWithValue("@MaSoThue", ncc.MaSoThue ?? (object)DBNull.Value); // Nullable
                    cmd.Parameters.AddWithValue("@TrangThai", "Đang hoạt động");
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void XoaNhaCungCap(string maNCC)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "UPDATE NHA_CUNG_CAP SET TRANG_THAI = N'Đã xóa' WHERE MA_NHA_CUNG_CAP = @MaNCC";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNCC", maNCC);
                    cmd.ExecuteNonQuery();
                }
            }
        }






    }

}
