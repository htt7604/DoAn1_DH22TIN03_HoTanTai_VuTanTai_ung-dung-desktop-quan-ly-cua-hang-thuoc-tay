using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassBangGia
    {
        public string MaBangGia { get; set; }
        public string TenBangGia { get; set; } 

        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TrangThai { get; set; }
        public bool ChoChonNgoaiBangGia { get; set; }

        public bool LaPhanTram { get; set; }
        public bool TangGiam { get; set; }
        public decimal GiaTriTangGiam { get; set; }
        public bool DungGiaVon { get; set; }

        public static List<ClassBangGia> LayTatCaBangGia()
        {
            List<ClassBangGia> list = new List<ClassBangGia>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM BANG_GIA_HH WHERE TRANG_THAI != N'Đã xóa'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ClassBangGia
                        {
                            MaBangGia = reader["MA_BANG_GIA"].ToString(),
                            TenBangGia = reader["TEN_BANG_GIA"].ToString(),

                            TuNgay = reader["TU_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["TU_NGAY"]) : DateTime.MinValue,
                            DenNgay = reader["DEN_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["DEN_NGAY"]) : DateTime.MaxValue,
                            TrangThai = reader["TRANG_THAI"].ToString(),

                            ChoChonNgoaiBangGia = reader["CHO_CHON_NGOAI_BANG_GIA"] != DBNull.Value && Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                            LaPhanTram = reader["LA_PHAN_TRAM"] != DBNull.Value && Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                            TangGiam = reader["TANG_GIAM"] != DBNull.Value && Convert.ToBoolean(reader["TANG_GIAM"]),
                            GiaTriTangGiam = reader["GIA_TRI_TANG_GIAM"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]) : 0,
                            DungGiaVon = reader["DUNG_GIA_VON"] != DBNull.Value && Convert.ToBoolean(reader["DUNG_GIA_VON"])
                        });
                    }
                }
            }
            return list;
        }

        //LayTatCaBangGiaDangApDUng
        public static List <ClassBangGia> LayTatCaBangGiaDangApDUng()
        {
            List<ClassBangGia> list = new List<ClassBangGia>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM BANG_GIA_HH WHERE TRANG_THAI != N'Đã xóa' AND TRANG_THAI=N'Đang áp dụng' ";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ClassBangGia
                        {
                            MaBangGia = reader["MA_BANG_GIA"].ToString(),
                            TenBangGia = reader["TEN_BANG_GIA"].ToString(),

                            TuNgay = reader["TU_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["TU_NGAY"]) : DateTime.MinValue,
                            DenNgay = reader["DEN_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["DEN_NGAY"]) : DateTime.MaxValue,
                            TrangThai = reader["TRANG_THAI"].ToString(),

                            ChoChonNgoaiBangGia = reader["CHO_CHON_NGOAI_BANG_GIA"] != DBNull.Value && Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                            LaPhanTram = reader["LA_PHAN_TRAM"] != DBNull.Value && Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                            TangGiam = reader["TANG_GIAM"] != DBNull.Value && Convert.ToBoolean(reader["TANG_GIAM"]),
                            GiaTriTangGiam = reader["GIA_TRI_TANG_GIAM"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]) : 0,
                            DungGiaVon = reader["DUNG_GIA_VON"] != DBNull.Value && Convert.ToBoolean(reader["DUNG_GIA_VON"])
                        });
                    }
                }
            }
            return list;
        }


        public static string TaoMaBangGiaTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT MAX(MA_BANG_GIA) FROM BANG_GIA_HH WHERE MA_BANG_GIA LIKE 'BG%'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string maxMa = result.ToString(); // Ví dụ: BG0021
                        int so = int.Parse(maxMa.Substring(2)); // Lấy phần số sau "BG"
                        return "BG" + (so + 1).ToString("D4"); // Tăng lên và format 4 chữ số
                    }
                    else
                    {
                        return "BG0001"; // Nếu chưa có mã nào
                    }
                }
            }
        }




        public static bool ThemBangGia(ClassBangGia bg)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                INSERT INTO BANG_GIA_HH 
                (MA_BANG_GIA,TEN_BANG_GIA, TU_NGAY, DEN_NGAY, TRANG_THAI, CHO_CHON_NGOAI_BANG_GIA, LA_PHAN_TRAM, TANG_GIAM, GIA_TRI_TANG_GIAM, DUNG_GIA_VON)
                VALUES (@ma,@tenbanggia, @tu, @den, @trangthai, @chonngoai, @phantram, @tanggiam, @giatri, @dunggiavon)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ClassBangGia.TaoMaBangGiaTuDong());
                    cmd.Parameters.AddWithValue("@tenbanggia", bg.TenBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@dunggiavon", bg.DungGiaVon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool SuaBangGia(ClassBangGia bg)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE BANG_GIA_HH 
                SET TEN_BANG_GIA=@tenbanggia, TU_NGAY = @tu, DEN_NGAY = @den, TRANG_THAI = @trangthai, 
                    CHO_CHON_NGOAI_BANG_GIA = @chonngoai,
                    LA_PHAN_TRAM = @phantram, TANG_GIAM = @tanggiam, 
                    GIA_TRI_TANG_GIAM = @giatri, DUNG_GIA_VON = @tudong
                WHERE MA_BANG_GIA = @ma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", bg.MaBangGia);
                    cmd.Parameters.AddWithValue("@tenbanggia", bg.TenBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@dunggiavon", bg.DungGiaVon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool XoaBangGia(string maBangGia)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "UPDATE BANG_GIA_HH SET TRANG_THAI = N'Đã xóa' WHERE MA_BANG_GIA = @ma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maBangGia);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static ClassBangGia LayBangGiaTheoMa(string maBangGia)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM BANG_GIA_HH WHERE MA_BANG_GIA = @ma";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maBangGia);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassBangGia
                            {
                                MaBangGia = maBangGia,
                                TuNgay = Convert.ToDateTime(reader["TU_NGAY"]),
                                DenNgay = Convert.ToDateTime(reader["DEN_NGAY"]),
                                TrangThai = reader["TRANG_THAI"].ToString(),
                                ChoChonNgoaiBangGia = Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                                LaPhanTram = Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                                TangGiam = Convert.ToBoolean(reader["TANG_GIAM"]),
                                GiaTriTangGiam = Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]),
                                DungGiaVon = Convert.ToBoolean(reader["DUNG_GIA_VON"])
                            };
                        }
                    }
                }
            }
            return null;
        }












    }
}
