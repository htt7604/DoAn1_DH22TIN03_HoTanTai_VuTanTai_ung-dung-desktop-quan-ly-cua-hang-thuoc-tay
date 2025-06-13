using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient
namespace QL_Nha_thuoc.model
{
    internal class ClassGiaBanHH
    {
        public string MaHangHoa { get; set; }
        public string MaDonViTinh { get; set; }
        public decimal GiaVon { get; set; }
        public decimal GiaBan { get; set; }

        // Constructor tùy chọn
        public ClassGiaBanHH() { }

        public ClassGiaBanHH(string maHH, string maDVT, decimal giaVon, decimal giaBan)
        {
            MaHangHoa = maHH;
            MaDonViTinh = maDVT;
            GiaVon = giaVon;
            GiaBan = giaBan;
        }

        /// <summary>
        /// Lấy danh sách giá bán hàng hóa từ CSDL
        /// </summary>
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
        public static bool ThemGiaBan(ClassGiaBanHH gia)
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();

                decimal? tiLeLoi = null;

                // Tính tỷ lệ lời nếu đủ dữ liệu
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

                SqlCommand cmd = new SqlCommand(query, conn);
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
                    SET GIA_VON_HH = @giaVon, GIA_BAN_HH = @giaBan
                    WHERE MA_HANG_HOA = @maHH AND MA_DON_VI_TINH = @maDVT";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", gia.MaHangHoa);
                cmd.Parameters.AddWithValue("@maDVT", gia.MaDonViTinh);
                cmd.Parameters.AddWithValue("@giaVon", gia.GiaVon);
                cmd.Parameters.AddWithValue("@giaBan", gia.GiaBan);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}

