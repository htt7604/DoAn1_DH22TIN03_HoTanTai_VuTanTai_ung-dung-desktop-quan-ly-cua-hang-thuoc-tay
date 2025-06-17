using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; // Ensure you have the correct using directive for SqlConnection and SqlCommand

namespace QL_Nha_thuoc.model
{
    internal class ClassNhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoTenNhanVien { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string SoCCCD { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string TrangThai { get; set; }
        public decimal Luong { get; set; }

        public static List<ClassNhanVien> LayTatCaNhanVien()
        {
            List<ClassNhanVien> danhSach = new List<ClassNhanVien>();

            using (SqlConnection conn = DBHelperPK.GetConnection())
            {
                string query = "SELECT * FROM NHAN_VIEN";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ClassNhanVien nv = new ClassNhanVien
                    {
                        MaNhanVien = reader["MA_NV"].ToString(),
                        HoTenNhanVien = reader["HO_TEN_NV"].ToString(),
                        DiaChi = reader["DIA_CHI_NV"]?.ToString(),
                        SoDienThoai = reader["SDT_NV"]?.ToString(),
                        SoCCCD = reader["SO_CCCD/CMND_NV"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH_NV"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_SINH_NV"]),
                        GioiTinh = reader["GIOI_TINH_NV"]?.ToString(),
                        TrangThai = reader["TRANG_THAI_NV"]?.ToString(),
                        Luong = reader["LUONG_NV"] == DBNull.Value ? 0 : Convert.ToDecimal(reader["LUONG_NV"])
                    };
                    danhSach.Add(nv);
                }

                reader.Close();
            }

            return danhSach;
        }
    }
}

