using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace QL_Nha_thuoc.model
{
    public class ClassChiTietPhieuKiemKho
    {
        public string MaPhieuKiemKho { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuongHeThong { get; set; }
        public int SoLuongThucTe { get; set; }
        public string TenDonViTinh {  get; set; }
        public string GhiChu { get; set; }

        public int ChenhLech => SoLuongThucTe - SoLuongHeThong;

        // Lấy danh sách chi tiết phiếu kiểm kho theo mã
        public static List<ClassChiTietPhieuKiemKho> LayDanhSachChiTietPhieuKiemKho(string maPhieu)
        {
            List<ClassChiTietPhieuKiemKho> danhSach = new List<ClassChiTietPhieuKiemKho>();
            CSDL csdl = new CSDL();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        CT.MA_KIEM_KHO, 
                        CT.MA_HANG_HOA, 
                        HH.TEN_HANG_HOA, 
                        CT.SO_LUONG_HE_THONG, 
                        CT.SO_LUONG_THUC_TE, 
                        CT.GHI_CHU
                    FROM CHI_TIET_PHIEU_KIEM_KHO CT
                    JOIN HANG_HOA HH ON CT.MA_HANG_HOA = HH.MA_HANG_HOA
                    WHERE CT.MA_KIEM_KHO = @maPhieu";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maPhieu", maPhieu);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(new ClassChiTietPhieuKiemKho
                    {
                        MaPhieuKiemKho = reader["MA_KIEM_KHO"].ToString(),
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                        SoLuongHeThong = Convert.ToInt32(reader["SO_LUONG_HE_THONG"]),
                        SoLuongThucTe = Convert.ToInt32(reader["SO_LUONG_THUC_TE"]),
                        GhiChu = reader["GHI_CHU"].ToString()
                    });
                }
                reader.Close();
            }
            return danhSach;
        }

        // Thêm 1 chi tiết phiếu kiểm kho
        public static bool ThemChiTietPhieuKiemKho(ClassChiTietPhieuKiemKho chiTiet)
        {
            CSDL csdl = new CSDL();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO CHI_TIET_PHIEU_KIEM_KHO 
                        (MA_KIEM_KHO, MA_HANG_HOA, SO_LUONG_HE_THONG, SO_LUONG_THUC_TE, GHI_CHU)
                    VALUES 
                        (@MaPhieuKiemKho, @MaHangHoa, @SoLuongHeThong, @SoLuongThucTe, @GhiChu)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuKiemKho", chiTiet.MaPhieuKiemKho);
                cmd.Parameters.AddWithValue("@MaHangHoa", chiTiet.MaHangHoa);
                cmd.Parameters.AddWithValue("@SoLuongHeThong", chiTiet.SoLuongHeThong);
                cmd.Parameters.AddWithValue("@SoLuongThucTe", chiTiet.SoLuongThucTe);
                cmd.Parameters.AddWithValue("@GhiChu", chiTiet.GhiChu ?? "");
                int rowsAffected = cmd.ExecuteNonQuery();
                 return rowsAffected > 0;
            }
        }

        // Cập nhật 1 chi tiết phiếu kiểm kho
        public static void CapNhatChiTietPhieuKiemKho(ClassChiTietPhieuKiemKho chiTiet)
        {
            CSDL csdl = new CSDL();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    UPDATE CHI_TIET_PHIEU_KIEM_KHO
                    SET 
                        SO_LUONG_HE_THONG = @SoLuongHeThong,
                        SO_LUONG_THUC_TE = @SoLuongThucTe,
                        GHI_CHU = @GhiChu
                    WHERE 
                        MA_KIEM_KHO = @MaPhieuKiemKho AND 
                        MA_HANG_HOA = @MaHangHoa";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@SoLuongHeThong", chiTiet.SoLuongHeThong);
                cmd.Parameters.AddWithValue("@SoLuongThucTe", chiTiet.SoLuongThucTe);
                cmd.Parameters.AddWithValue("@GhiChu", chiTiet.GhiChu ?? "");
                cmd.Parameters.AddWithValue("@MaPhieuKiemKho", chiTiet.MaPhieuKiemKho);
                cmd.Parameters.AddWithValue("@MaHangHoa", chiTiet.MaHangHoa);
                cmd.ExecuteNonQuery();
            }
        }

        // Xóa 1 chi tiết phiếu kiểm kho
        public static bool XoaChiTietPhieuKiemKho(string maPhieu)
        {
            try
            {
                CSDL csdl = new CSDL();
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        DELETE FROM CHI_TIET_PHIEU_KIEM_KHO
                        WHERE MA_KIEM_KHO = @MaPhieuKiemKho";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhieuKiemKho", maPhieu);
                    cmd.ExecuteNonQuery();
                }
                return true; // Trả về true nếu xóa thành công
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                Console.WriteLine("Lỗi khi xóa chi tiết phiếu kiểm kho: " + ex.Message);
                return false;
            }
        }




    }
}

