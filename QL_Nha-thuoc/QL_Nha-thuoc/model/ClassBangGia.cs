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
        public bool CoApDungTinhGiaTuDong { get; set; }

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
                            CoApDungTinhGiaTuDong = reader["CO_AP_DUNG_TINH_GIA_TU_DONG"] != DBNull.Value && Convert.ToBoolean(reader["CO_AP_DUNG_TINH_GIA_TU_DONG"])
                        });
                    }
                }
            }
            return list;
        }


        public static bool ThemBangGia(ClassBangGia bg)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
INSERT INTO BANG_GIA 
(MA_BANG_GIA, TU_NGAY, DEN_NGAY, TRANG_THAI, CHO_CHON_NGOAI_BANG_GIA, LA_PHAN_TRAM, TANG_GIAM, GIA_TRI_TANG_GIAM, CO_AP_DUNG_TINH_GIA_TU_DONG)
VALUES (@ma, @tu, @den, @trangthai, @chonngoai, @phantram, @tanggiam, @giatri, @tudong)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", bg.MaBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@tudong", bg.CoApDungTinhGiaTuDong);

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
UPDATE BANG_GIA 
SET TU_NGAY = @tu, DEN_NGAY = @den, TRANG_THAI = @trangthai, 
    CHO_CHON_NGOAI_BANG_GIA = @chonngoai,
    LA_PHAN_TRAM = @phantram, TANG_GIAM = @tanggiam, 
    GIA_TRI_TANG_GIAM = @giatri, CO_AP_DUNG_TINH_GIA_TU_DONG = @tudong
WHERE MA_BANG_GIA = @ma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", bg.MaBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@tudong", bg.CoApDungTinhGiaTuDong);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool XoaBangGia(string maBangGia)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "UPDATE BANG_GIA SET TRANG_THAI = N'Đã xóa' WHERE MA_BANG_GIA = @ma";

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
                string query = "SELECT * FROM BANG_GIA WHERE MA_BANG_GIA = @ma";
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
                                CoApDungTinhGiaTuDong = Convert.ToBoolean(reader["CO_AP_DUNG_TINH_GIA_TU_DONG"])
                            };
                        }
                    }
                }
            }
            return null;
        }












    }
}
