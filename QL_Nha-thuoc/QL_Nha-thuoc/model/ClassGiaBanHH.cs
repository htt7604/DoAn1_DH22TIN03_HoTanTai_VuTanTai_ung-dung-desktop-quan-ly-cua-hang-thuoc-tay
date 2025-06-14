using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient
namespace QL_Nha_thuoc.model
{
    public class DBHelperGiaBanHH
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
    public class ClassGiaBanHH
    {
        public string MaHangHoa { get; set; }
        public string MaDonViTinh { get; set; }
        public decimal GiaVon { get; set; }
        public decimal GiaBan { get; set; }
        public decimal TiLeLoi { get; set; }
        public string TenHangHoa { get; set; } // Thuộc tính mới để lưu tên hàng hóa
        public string TenDonViTinh { get; set; } // Thuộc tính mới để lưu tên đơn vị tính

        // Constructor tùy chọn
        public ClassGiaBanHH() { }

        public ClassGiaBanHH(string maHH, string maDVT, decimal giaVon, decimal giaBan, decimal tiLeLoi)
        {
            MaHangHoa = maHH;
            MaDonViTinh = maDVT;
            GiaVon = giaVon;
            GiaBan = giaBan;
            TiLeLoi = tiLeLoi;
        }

        /// Lấy danh sách giá bán hàng hóa từ CSDL

        //ham lay toan bo danh sach gia ban hang hoa
        public static List<ClassGiaBanHH> LayDanhSachToanboGiaBan()
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                string query = "SELECT GHH.MA_HANG_HOA, GHH.MA_DON_VI_TINH, GHH.GIA_VON_HH, GHH.GIA_BAN_HH, HH.TEN_HANG_HOA " +
                               "FROM GIA_HANG_HOA GHH " +
                               "JOIN HANG_HOA HH ON HH.MA_HANG_HOA = GHH.MA_HANG_HOA " +
                               "JOIN DON_VI_TINH DVT ON DVT.MA_DON_VI_TINH = GHH.MA_DON_VI_TINH";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var gia = new ClassGiaBanHH
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                            GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                            GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"]),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                        };
                        danhSach.Add(gia);
                    }
                }
            }

            return danhSach;
        }


        //lay 1
        public static ClassGiaBanHH LayGiaBanTheoMavamaDVT(string maHangHoa,string maDVT)
        {
            if (string.IsNullOrEmpty(maHangHoa))
                return null;

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                string query = "SELECT MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH and MA_DON_VI_TINH = @maDVT";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHangHoa);
                cmd.Parameters.AddWithValue("@maDVT", maDVT);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ClassGiaBanHH
                    {
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                        GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                        GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"])
                    };
                }
            }

            return null;
        }


        public static List<ClassGiaBanHH> LayDanhSachGiaBan(string maHangHoa = null)
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                string query = "SELECT MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH FROM GIA_HANG_HOA";

                if (!string.IsNullOrEmpty(maHangHoa))
                    query += " WHERE MA_HANG_HOA = @maHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(maHangHoa))
                    cmd.Parameters.AddWithValue("@maHH", maHangHoa);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gia = new ClassGiaBanHH
                    {
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                        GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                        GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"])
                    };
                    danhSach.Add(gia);
                }
            }

            return danhSach;
        }

        /// <summary>
        /// Thêm giá bán mới cho hàng hóa
        /// </summary>
        public static bool ThemGiaBan(ClassGiaBanHH gia, SqlConnection conn, SqlTransaction transaction)
        {
            decimal? tiLeLoi = null;

            if (gia.GiaVon > 0 && gia.GiaBan > 0)
            {
                tiLeLoi = ((gia.GiaBan - gia.GiaVon) / gia.GiaVon) * 100;
            }

            string query = @"
        INSERT INTO GIA_HANG_HOA (
            MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH, TI_LE_LOI
        )
        VALUES (
            @maHH, @maDVT, @giaVon, @giaBan, @tiLeLoi
        )";

            using (SqlCommand cmd = new SqlCommand(query, conn, transaction))
            {
                cmd.Parameters.AddWithValue("@maHH", gia.MaHangHoa);
                cmd.Parameters.AddWithValue("@maDVT", gia.MaDonViTinh);
                cmd.Parameters.AddWithValue("@giaVon", gia.GiaVon);
                cmd.Parameters.AddWithValue("@giaBan", gia.GiaBan);
                cmd.Parameters.AddWithValue("@tiLeLoi", (object)tiLeLoi ?? DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        /// <summary>
        /// Cập nhật giá bán cho hàng hóa (theo mã hàng và đơn vị tính)
        /// </summary>
        public static bool CapNhatGiaBan(ClassGiaBanHH gia)
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE GIA_HANG_HOA 
                    SET GIA_VON_HH = @giaVon, GIA_BAN_HH = @giaBan, TI_LE_LOI = @tiLeLoi
                    WHERE MA_HANG_HOA = @maHH AND MA_DON_VI_TINH = @maDVT";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHH", gia.MaHangHoa);
                    cmd.Parameters.AddWithValue("@maDVT", gia.MaDonViTinh);
                    cmd.Parameters.AddWithValue("@giaVon", gia.GiaVon);
                    cmd.Parameters.AddWithValue("@giaBan", gia.GiaBan);
                    cmd.Parameters.AddWithValue("@tiLeLoi",(gia.GiaBan-gia.GiaVon)/100);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool XoaGiaBanTheoMaHangHoa(string maHH,string maDVT)
        {
            if (string.IsNullOrEmpty(maHH))
                return false;

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH  and MA_DON_VI_TINH= @maDVT";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHH);
                cmd.Parameters.AddWithValue("@maDVT", maDVT);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

