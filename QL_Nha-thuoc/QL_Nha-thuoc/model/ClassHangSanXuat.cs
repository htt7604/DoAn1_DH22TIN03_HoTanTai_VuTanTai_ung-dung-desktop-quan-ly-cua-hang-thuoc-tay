using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Ensure you have the correct using directive for SqlConnection, SqlCommand, etc.
namespace QL_Nha_thuoc.model
{
    public class ClassHangSanXuat
    {


        public int MaHangSX { get; set; }
        public string TenHangSX { get; set; }

        // Tìm hãng sản xuất theo tên (tương đối, không phân biệt hoa thường)
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
                                MaHangSX = reader.GetInt32(0),
                                TenHangSX = reader.GetString(1)
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
                                MaHangSX = reader.GetInt32(0),
                                TenHangSX = reader.GetString(1)
                            };
                            danhSach.Add(hsx);
                        }
                    }
                }
            }
            return danhSach;
        }

        // Thêm hãng sản xuất
        public static bool ThemHangSX(ClassHangSanXuat hangSX)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "INSERT INTO HANG_SAN_XUAT (TEN_HANG_SX) VALUES (@ten)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ten", hangSX.TenHangSX);
                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        // Xóa hãng sản xuất theo mã
        public static bool XoaHangSX(int maHangSX)
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
