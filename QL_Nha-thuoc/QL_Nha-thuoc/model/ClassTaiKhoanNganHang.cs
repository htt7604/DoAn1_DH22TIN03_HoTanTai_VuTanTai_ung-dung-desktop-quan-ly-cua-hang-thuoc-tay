using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassTaiKhoanNganHang
    {
        public string TenChuTK { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenNganHang { get; set; }
        public string GhiChu { get; set; }
        public static ClassTaiKhoanNganHang? LayTaiKhoan()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = "SELECT TOP 1 * FROM TAI_KHOAN_NGAN_HANG"; // Lấy dòng đầu tiên
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new ClassTaiKhoanNganHang
                    {
                        TenChuTK = reader["TEN_CHU_TAI_KHOAN"].ToString() ?? "",
                        SoTaiKhoan = reader["SO_TAI_KHOAN"].ToString() ?? "",
                        TenNganHang = reader["TEN_NGAN_HANG"].ToString() ?? "",
                        GhiChu = reader["GHI_CHU"].ToString() ?? ""
                    };
                }
            }
            return null;
        }









        public static string TaoMaNganHangTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string sql = "SELECT MAX(MA_TAI_KHOAN_NGAN_HANG) FROM TAI_KHOAN_NGAN_HANG";
                SqlCommand cmd = new SqlCommand(sql, conn);
                var result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    string maxCode = result.ToString(); // Ví dụ: "NH015"
                    string numberPart = maxCode.Substring(2); // Lấy phần số: "015"
                    int nextNumber = int.Parse(numberPart) + 1;

                    return "NH" + nextNumber.ToString("D3"); // Format lại thành NH016
                }
                else
                {
                    // Nếu chưa có mã nào
                    return "NH001";
                }
            }
        }





        public bool ThemTaiKhoan()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string maNganHang = TaoMaNganHangTuDong();

                string sql = @"INSERT INTO TAI_KHOAN_NGAN_HANG 
                        (MA_TAI_KHOAN_NGAN_HANG, TEN_CHU_TAI_KHOAN, SO_TAI_KHOAN, TEN_NGAN_HANG, GHI_CHU)
                       VALUES (@MaNganHang, @TenChuTK, @SoTaiKhoan, @TenNganHang, @GhiChu)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@MaNganHang", maNganHang);
                    cmd.Parameters.AddWithValue("@TenChuTK", TenChuTK ?? "");
                    cmd.Parameters.AddWithValue("@SoTaiKhoan", SoTaiKhoan ?? "");
                    cmd.Parameters.AddWithValue("@TenNganHang", TenNganHang ?? "");
                    cmd.Parameters.AddWithValue("@GhiChu", GhiChu ?? "");

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


    }

}
