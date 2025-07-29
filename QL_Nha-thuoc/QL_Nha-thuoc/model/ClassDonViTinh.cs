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


    }
}
