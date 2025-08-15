using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassChiTietPhieuTraHang
    {
        public string MaPhieuTraHang { get; set; }
        public string MaHangHoa { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuongTra { get; set; }
        public decimal GiaTraHang { get; set; }
        public decimal ThanhTien { get; set; }

        public ClassChiTietPhieuTraHang() { }

        public ClassChiTietPhieuTraHang(string maPhieuTraHang, string maHangHoa, string maDonViTinh,
                                        string tenHangHoa, int soLuongTra, decimal giaTraHang)
        {
            MaPhieuTraHang = maPhieuTraHang;
            MaHangHoa = maHangHoa;
            MaDonViTinh = maDonViTinh;
            TenHangHoa = tenHangHoa;
            SoLuongTra = soLuongTra;
            GiaTraHang = giaTraHang;
            ThanhTien = soLuongTra * giaTraHang;
        }
        /// <summary>
        /// Lấy danh sách chi tiết phiếu trả hàng theo mã phiếu
        /// </summary>
        public static List<ClassChiTietPhieuTraHang> LayChiTietTheoMaPhieu(string maPhieuTraHang)
        {
            List<ClassChiTietPhieuTraHang> danhSach = new List<ClassChiTietPhieuTraHang>();
            string query = @"SELECT MA_PHIEU_TRA_HANG, MA_HANG_HOA, MA_DON_VI_TINH, TEN_HANG_HOA, 
                            SO_LUONG_TRA, GIA_TRA_HANG, THANH_TIEN
                     FROM [CHI_TIET-PHIEU_TRA_HANG_HD]
                     WHERE MA_PHIEU_TRA_HANG = @MaPhieuTraHang";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", maPhieuTraHang ?? (object)DBNull.Value);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var chiTiet = new ClassChiTietPhieuTraHang
                        {
                            MaPhieuTraHang = reader["MA_PHIEU_TRA_HANG"].ToString(),
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            SoLuongTra = reader["SO_LUONG_TRA"] != DBNull.Value ? Convert.ToInt32(reader["SO_LUONG_TRA"]) : 0,
                            GiaTraHang = reader["GIA_TRA_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRA_HANG"]) : 0,
                            ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : 0
                        };
                        danhSach.Add(chiTiet);
                    }
                }
            }
            return danhSach;
        }




        /// <summary>
        /// Thêm chi tiết phiếu trả hàng
        /// </summary>
        public static bool ThemChiTietTraHang (ClassChiTietPhieuTraHang chiTietPhieuTraHang)
        {
            string query = @"INSERT INTO [CHI_TIET-PHIEU_TRA_HANG_HD]
                            (MA_PHIEU_TRA_HANG, MA_HANG_HOA, MA_DON_VI_TINH, TEN_HANG_HOA, SO_LUONG_TRA, GIA_TRA_HANG, THANH_TIEN)
                            VALUES (@MaPhieuTraHang, @MaHangHoa, @MaDonViTinh, @TenHangHoa, @SoLuongTra, @GiaTraHang, @ThanhTien)";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", chiTietPhieuTraHang. MaPhieuTraHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaHangHoa", chiTietPhieuTraHang. MaHangHoa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaDonViTinh", chiTietPhieuTraHang. MaDonViTinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenHangHoa", chiTietPhieuTraHang. TenHangHoa ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@SoLuongTra", chiTietPhieuTraHang.SoLuongTra);
                cmd.Parameters.AddWithValue("@GiaTraHang", chiTietPhieuTraHang.GiaTraHang);
                cmd.Parameters.AddWithValue("@ThanhTien", chiTietPhieuTraHang.ThanhTien);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Xóa chi tiết phiếu trả hàng theo mã phiếu và mã hàng
        /// </summary>
        public static bool XoaChiTietTraHang (ClassChiTietPhieuTraHang chiTietPhieuTraHang)
        {
            string query = @"DELETE FROM [CHI_TIET-PHIEU_TRA_HANG_HD]
                             WHERE MA_PHIEU_TRA_HANG = @MaPhieuTraHang
                               AND MA_HANG_HOA = @MaHangHoa";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", chiTietPhieuTraHang. MaPhieuTraHang);
                cmd.Parameters.AddWithValue("@MaHangHoa", chiTietPhieuTraHang.MaHangHoa);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
