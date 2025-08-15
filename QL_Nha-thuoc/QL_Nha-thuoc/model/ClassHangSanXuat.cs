using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class ClassHangSanXuat
    {
        public string MaHangSX { get; set; }
        public string TenHangSX { get; set; }

        // Tìm hãng sản xuất theo tên (LIKE, không phân biệt hoa thường)
        public static List<ClassHangSanXuat> TimHangSXTheoTen(string tenHSX)
        {
            List<ClassHangSanXuat> danhSach = new List<ClassHangSanXuat>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                    SELECT MA_HANG_SX, TEN_HANG_SX
                    FROM HANG_SAN_XUAT
                    WHERE TEN_HANG_SX LIKE @ten";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", "%" + tenHSX + "%");
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassHangSanXuat hsx = new ClassHangSanXuat
                            {
                                MaHangSX = reader.GetString(0),
                                TenHangSX = reader.IsDBNull(1) ? "" : reader.GetString(1)
                            };
                            danhSach.Add(hsx);
                        }
                    }
                }
            }

            return danhSach;
        }

        // Lấy danh sách tất cả hãng sản xuất
        public static List<ClassHangSanXuat> LayTatCaHangSX()
        {
            List<ClassHangSanXuat> danhSach = new List<ClassHangSanXuat>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT MA_HANG_SX, TEN_HANG_SX FROM HANG_SAN_XUAT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassHangSanXuat hsx = new ClassHangSanXuat
                            {
                                MaHangSX = reader.GetString(0),
                                TenHangSX = reader.IsDBNull(1) ? "" : reader.GetString(1)
                            };
                            danhSach.Add(hsx);
                        }
                    }
                }
            }

            return danhSach;
        }

        // Tạo mã hãng sản xuất mới tự động: HSX001, HSX002,...
        public static string TaoMaHangSXMoi()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string sql = "SELECT MAX(MA_HANG_SX) FROM HANG_SAN_XUAT WHERE MA_HANG_SX LIKE 'HSX%'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();

                    if (result == DBNull.Value || result == null)
                    {
                        return "HSX001"; // Mã đầu tiên nếu chưa có mã nào
                    }

                    string maxMa = result.ToString(); // Ví dụ "HSX015"

                    // Lấy phần số sau "HSX"
                    string soStr = maxMa.Substring(3);

                    if (int.TryParse(soStr, out int so))
                    {
                        so++; // Tăng lên 1
                        return "HSX" + so.ToString("D3"); // Ví dụ HSX016
                    }
                    else
                    {
                        return "HSX001";
                    }
                }
            }
        }

        // Thêm hãng sản xuất mới, tự động tạo mã
        public static bool ThemHangSX(ClassHangSanXuat hangSX)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                hangSX.MaHangSX = TaoMaHangSXMoi();

                string query = "INSERT INTO HANG_SAN_XUAT (MA_HANG_SX, TEN_HANG_SX) VALUES (@ma, @ten)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", hangSX.MaHangSX);
                    cmd.Parameters.AddWithValue("@ten", hangSX.TenHangSX ?? "");
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
        }

        // Xóa hãng sản xuất theo mã (string)
        public static bool XoaHangSX(string maHangSX)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "DELETE FROM HANG_SAN_XUAT WHERE MA_HANG_SX = @ma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maHangSX);
                    conn.Open();

                    int rows = cmd.ExecuteNonQuery();

                    return rows > 0;
                }
            }
        }
    }
}
