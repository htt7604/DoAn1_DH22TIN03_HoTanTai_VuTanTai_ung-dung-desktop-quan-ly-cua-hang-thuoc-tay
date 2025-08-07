using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class ClassChiTietHoaDon
    {
        // Thuộc tính
        public string MaHoaDon { get; set; }
        public string MaHangHoa { get; set; }
        public int? SoLuong { get; set; }
        public decimal? DonGiaBan { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal? GiaBan { get; set; }
        public decimal? ThanhTien { get; set; }
        public string TenHangHoa { get; set; }


        // Constructor đầy đủ
        public ClassChiTietHoaDon(string maHD, string maHH, int? soLuong, decimal? donGia,
                                  decimal? giamGia, decimal? giaBan, decimal? thanhTien, string tenHH)
        {
            MaHoaDon = maHD;
            MaHangHoa = maHH;
            SoLuong = soLuong;
            DonGiaBan = donGia;
            GiamGia = giamGia;
            GiaBan = giaBan;
            ThanhTien = thanhTien;
            TenHangHoa = tenHH;
        }

        // Constructor rỗng
        public ClassChiTietHoaDon() { }

        // Thêm chi tiết hóa đơn
        public bool ThemChiTiet()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO CHI_TIET_HOA_DON (MA_HOA_DON, MA_HANG_HOA, SO_LUONG_HH, DON_GIA_BAN,
                                GIAM_GIA, GIA_BAN, THANH_TIEN, TEN_HANG_HOA)
                                 VALUES (@MA_HOA_DON, @MA_HANG_HOA, @SO_LUONG, @DON_GIA,
                                         @GIAM_GIA, @GIA_BAN, @THANH_TIEN, @TEN_HANG_HOA)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", MaHoaDon);
                cmd.Parameters.AddWithValue("@MA_HANG_HOA", MaHangHoa);
                cmd.Parameters.AddWithValue("@SO_LUONG", (object)SoLuong ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DON_GIA", (object)DonGiaBan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GIAM_GIA", (object)GiamGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GIA_BAN", (object)GiaBan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@THANH_TIEN", (object)ThanhTien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TEN_HANG_HOA", (object)TenHangHoa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cập nhật chi tiết hóa đơn
        public bool CapNhatChiTiet()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE CHI_TIET_HOA_DON
                                 SET SO_LUONG_HH = @SO_LUONG,
                                     DON_GIA_BAN = @DON_GIA,
                                     GIAM_GIA = @GIAM_GIA,
                                     GIA_BAN = @GIA_BAN,
                                     THANH_TIEN = @THANH_TIEN,
                                     TEN_HANG_HOA = @TEN_HANG_HOA
                                 WHERE MA_HOA_DON = @MA_HOA_DON AND MA_HANG_HOA = @MA_HANG_HOA";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", MaHoaDon);
                cmd.Parameters.AddWithValue("@MA_HANG_HOA", MaHangHoa);
                cmd.Parameters.AddWithValue("@SO_LUONG", (object)SoLuong ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@DON_GIA", (object)DonGiaBan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GIAM_GIA", (object)GiamGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@GIA_BAN", (object)GiaBan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@THANH_TIEN", (object)ThanhTien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TEN_HANG_HOA", (object)TenHangHoa ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Xóa toàn bộ chi tiết theo mã hóa đơn
        public static bool XoaChiTietTheoMaHD(string maHD)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM CHI_TIET_HOA_DON WHERE MA_HOA_DON = @MA_HOA_DON";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", maHD);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Lấy chi tiết hóa đơn theo mã
        public static List<ClassChiTietHoaDon> LayChiTietTheoMaHD(string maHD)
        {
            List<ClassChiTietHoaDon> danhSach = new List<ClassChiTietHoaDon>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM CHI_TIET_HOA_DON WHERE MA_HOA_DON = @MA_HOA_DON";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", maHD);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassChiTietHoaDon ct = new ClassChiTietHoaDon
                        {
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            SoLuong = reader["SO_LUONG_HH"] != DBNull.Value ? Convert.ToInt32(reader["SO_LUONG_HH"]) : (int?)null,
                            DonGiaBan = reader["DON_GIA_BAN"] != DBNull.Value ? Convert.ToDecimal(reader["DON_GIA_BAN"]) : (decimal?)null,
                            GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : (decimal?)null,
                            GiaBan = reader["GIA_BAN"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN"]) : (decimal?)null,
                            ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : (decimal?)null,
                            TenHangHoa = reader["TEN_HANG_HOA"]?.ToString()
                        };

                        danhSach.Add(ct);
                    }
                }
            }

            return danhSach;
        }


        // Lấy toàn bộ chi tiết hóa đơn
        public static List<ClassChiTietHoaDon> LayTatCaChiTiet()
        {
            List<ClassChiTietHoaDon> danhSach = new List<ClassChiTietHoaDon>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM CHI_TIET_HOA_DON ORDER BY MA_HOA_DON DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassChiTietHoaDon ct = new ClassChiTietHoaDon
                        {
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            SoLuong = reader["SO_LUONG_HH"] != DBNull.Value ? Convert.ToInt32(reader["SO_LUONG_HH"]) : (int?)null,
                            DonGiaBan = reader["DON_GIA_BAN"] != DBNull.Value ? Convert.ToDecimal(reader["DON_GIA_BAN"]) : (decimal?)null,
                            GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : (decimal?)null,
                            GiaBan = reader["GIA_BAN"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN"]) : (decimal?)null,
                            ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : (decimal?)null,
                            TenHangHoa = reader["TEN_HANG_HOA"]?.ToString()
                        };

                        danhSach.Add(ct);
                    }
                }
            }

            return danhSach;
        }





    }
}
