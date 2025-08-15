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
        public string MaTaiKhoanNH { get; set; }
        public string TenChuTK { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenNganHang { get; set; }
        public string GhiChu { get; set; }





        public static ClassTaiKhoanNganHang? LayTaiKhoanTheoSTK(string soTaiKhoan)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM TAI_KHOAN_NGAN_HANG WHERE SO_TAI_KHOAN = @stk";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@stk", soTaiKhoan);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassTaiKhoanNganHang
                            {
                                MaTaiKhoanNH = reader["MA_TAI_KHOAN_NGAN_HANG"].ToString(),
                                TenChuTK = reader["TEN_CHU_TAI_KHOAN"].ToString() ?? "",
                                SoTaiKhoan = reader["SO_TAI_KHOAN"].ToString() ?? "",
                                TenNganHang = reader["TEN_NGAN_HANG"].ToString() ?? "",
                                GhiChu = reader["GHI_CHU"].ToString() ?? ""
                            };
                        }
                    }
                }
            }

            return null; // Nếu không tìm thấy
        }



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
                        MaTaiKhoanNH = reader["MA_TAI_KHOAN_NGAN_HANG"].ToString(),
                        TenChuTK = reader["TEN_CHU_TAI_KHOAN"].ToString() ?? "",
                        SoTaiKhoan = reader["SO_TAI_KHOAN"].ToString() ?? "",
                        TenNganHang = reader["TEN_NGAN_HANG"].ToString() ?? "",
                        GhiChu = reader["GHI_CHU"].ToString() ?? ""
                    };
                }
            }
            return null;
        }



        //lay toan bo tai khoan 
        public static List<ClassTaiKhoanNganHang> LayDanhSachTaiKhoan()
        {
            var danhSach = new List<ClassTaiKhoanNganHang>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string sql = "SELECT * FROM TAI_KHOAN_NGAN_HANG";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(new ClassTaiKhoanNganHang
                        {
                            TenChuTK = reader["TEN_CHU_TAI_KHOAN"].ToString() ?? "",
                            SoTaiKhoan = reader["SO_TAI_KHOAN"].ToString() ?? "",
                            TenNganHang = reader["TEN_NGAN_HANG"].ToString() ?? "",
                            GhiChu = reader["GHI_CHU"].ToString() ?? ""
                        });
                    }
                }
            }

            return danhSach;
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


        public static bool KiemTraTrungTaiKhoan(string soTaiKhoan, string tenChuTK)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM TAI_KHOAN_NGAN_HANG WHERE SO_TAI_KHOAN = @stk AND TEN_CHU_TK = @tentk";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@stk", soTaiKhoan);
                cmd.Parameters.AddWithValue("@tentk", tenChuTK);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
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
