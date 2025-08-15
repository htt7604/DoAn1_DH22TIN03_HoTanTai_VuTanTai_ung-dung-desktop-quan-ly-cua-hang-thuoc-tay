using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient

namespace QL_Nha_thuoc.model
{
    public class ClassDonViTinh
    {
        public string MaDonViTinh { get; set; }
        public string TenDonViTinh { get; set; }


        // ✅ Hàm lấy danh sách đơn vị tính, có thể truyền từ khóa tìm kiếm
        public static List<ClassDonViTinh> TimDanhSachDonViTinh(string tuKhoa = "")
        {
            List<ClassDonViTinh> danhSach = new List<ClassDonViTinh>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = "SELECT MA_DON_VI_TINH, TEN_DON_VI_TINH FROM DON_VI_TINH";

                // Nếu có từ khóa thì lọc theo tên hoặc mã
                if (!string.IsNullOrEmpty(tuKhoa))
                {
                    sql += " WHERE MA_DON_VI_TINH LIKE @tuKhoa OR TEN_DON_VI_TINH LIKE @tuKhoa";
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    if (!string.IsNullOrEmpty(tuKhoa))
                    {
                        cmd.Parameters.AddWithValue("@tuKhoa", "%" + tuKhoa + "%");
                    }

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ClassDonViTinh dvt = new ClassDonViTinh
                        {
                            MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"].ToString()
                        };
                        danhSach.Add(dvt);
                    }
                }
            }

            return danhSach;
        }

        public static ClassDonViTinh LayDonViTinhTheoMa(string maDVT)
        {
            if (string.IsNullOrEmpty(maDVT))
                return null;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT MA_DON_VI_TINH, TEN_DON_VI_TINH 
            FROM DON_VI_TINH 
            WHERE MA_DON_VI_TINH = @maDVT";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maDVT", maDVT);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassDonViTinh
                            {
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                TenDonViTinh = reader["TEN_DON_VI_TINH"].ToString()
                            };
                        }
                    }
                }
            }

            return null;
        }


        public static string TaoMaDonViTinhMoi()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = @"
            SELECT MAX(MA_DON_VI_TINH) 
            FROM DON_VI_TINH 
            WHERE MA_DON_VI_TINH LIKE 'DVT%'";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result == DBNull.Value || result == null)
                    {
                        return "DVT001"; // Mã đầu tiên nếu chưa có mã nào
                    }

                    string maxMa = result.ToString(); // Ví dụ "DVT015"

                    // Lấy phần số cuối mã, bỏ phần "DVT"
                    string soStr = maxMa.Substring(3); // "015"
                    if (int.TryParse(soStr, out int so))
                    {
                        so++; // Tăng lên 1
                        return "DVT" + so.ToString("D3"); // Định dạng 3 số, ví dụ "DVT016"
                    }
                    else
                    {
                        // Trường hợp không parse được thì trả mã mặc định
                        return "DVT001";
                    }
                }
            }
        }





    }
}
