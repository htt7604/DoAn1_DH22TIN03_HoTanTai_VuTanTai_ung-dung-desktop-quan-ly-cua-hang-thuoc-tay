using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient
namespace QL_Nha_thuoc.model
{

    public class ClassPhieuKiemKho
    {
        // 🔹 Các thuộc tính dữ liệu
        public string MaPhieuKiemKho { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgayKiemKho { get; set; }
        public DateTime? ThoiGianCanBangKho { get; set; }
        public int TongThucTe { get; set; } // Tổng số lượng thực tế
        public int TongChechLech { get; set; } // Tổng số lượng chênh lệch
        public int SoLuongLechGiam { get; set; } // Số lượng giảm
        public int SoLuongLechTang { get; set; } // Số lượng tăng
        public string TrangThaiPhieuKiem { get; set; }
        public string GhiChu { get; set; }

        // 🔹 Constructors
        public ClassPhieuKiemKho() { }

        public ClassPhieuKiemKho(string maPhieu, string tenNV, DateTime? ngayKiem, DateTime? ngayCanBang,int tongThucTe,int tongChechLech,int soLuongLechGiam,int soLuongLechTang, string ghiChu, string trangThai)
        {
            MaPhieuKiemKho = maPhieu;
            TenNhanVien = tenNV;
            NgayKiemKho = ngayKiem;
            ThoiGianCanBangKho = ngayCanBang;
            TongThucTe = tongThucTe;
            TongChechLech = tongChechLech;
            SoLuongLechGiam = soLuongLechGiam;
            SoLuongLechTang = soLuongLechTang;
            TrangThaiPhieuKiem = trangThai;
            GhiChu = ghiChu;
        }

        // 🔹 Lấy phiếu kiểm kho từ DB
        public static ClassPhieuKiemKho LayPhieuKiemKho(string maPhieuKiem)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"SELECT PKK.MA_KIEM_KHO,PKK.NGAY_KIEM_KHO,PKK.NGAY_CAN_BANG_KHO,PKK.TONG_THUC_TE,
                               PKK.TONG_CHECH_LECH,PKK.SO_LUONG_LECH_TANG,PKK.SO_LUONG_LECH_GIAM,pkk.GHI_CHU_KIEM_KHO,pkk.TRANG_THAI_PHIEU_KIEM,
                              NV.HO_TEN_NV,PKK.MA_NV
                       FROM PHIEU_KIEM_KHO PKK 
                       JOIN NHAN_VIEN NV ON NV.MA_NV = PKK.MA_NV
                       WHERE MA_KIEM_KHO = @MaPhieuKiem";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuKiem", maPhieuKiem);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string maNV = reader["MA_NV"].ToString();
                    string hoTenNV = reader["HO_TEN_NV"].ToString();
                    string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();
                    DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
                    DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
                    string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? "" : reader["GHI_CHU_KIEM_KHO"].ToString();
                    int tongThucTe =reader["TONG_THUC_TE"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_THUC_TE"]);
                    int tongChechLech = reader["TONG_CHECH_LECH"] == DBNull.Value ? 0 : Convert.ToInt32(reader["TONG_CHECH_LECH"]);
                    int soLuongLechGiam = reader["SO_LUONG_LECH_GIAM"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_GIAM"]);
                    int soLuongLechTang = reader["SO_LUONG_LECH_TANG"] == DBNull.Value ? 0 : Convert.ToInt32(reader["SO_LUONG_LECH_TANG"]);
                    return new ClassPhieuKiemKho(maPhieuKiem, hoTenNV, ngayKiem, ngayCanBang,tongThucTe,tongChechLech,soLuongLechGiam,soLuongLechTang,ghiChu, trangThai)
                    {
                        MaNhanVien = maNV
                    };
                }

                return null;
            }
        }

        // 🔹 Sinh mã mới
        public static string SinhMaPhieuMoi()
        {
            string maMoi = "PKK00001";
            string query = "SELECT TOP 1 MA_KIEM_KHO FROM PHIEU_KIEM_KHO ORDER BY MA_KIEM_KHO DESC";

            using (SqlConnection conn = CSDL.GetConnection())
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string maCu = result.ToString();
                    if (maCu.StartsWith("PKK") && int.TryParse(maCu.Substring(3), out int so))
                    {
                        so++;
                        maMoi = "PKK" + so.ToString("D5");
                    }
                }
            }

            return maMoi;
        }
        //them tu dong 
        public static string ThemPhieuKiemKhoMoi(string maNV, string maKho = "1")
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string maPhieu = SinhMaPhieuMoi();

                string query = @"INSERT INTO PHIEU_KIEM_KHO (MA_KIEM_KHO, MA_KHO, MA_NV, NGAY_KIEM_KHO, TRANG_THAI_PHIEU_KIEM)
                             VALUES (@MaPhieu, @MaKho, @MaNV, @NgayKiem, N'Phiếu tạm')";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmd.Parameters.AddWithValue("@MaKho", maKho);
                cmd.Parameters.AddWithValue("@MaNV", maNV);
                cmd.Parameters.AddWithValue("@NgayKiem", DateTime.Now);

                cmd.ExecuteNonQuery();

                return maPhieu;
            }
        }

        //them phiếu kiểm kho mới
        public static bool ThemPhieuKiemKho(ClassPhieuKiemKho phieu)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            INSERT INTO PHIEU_KIEM_KHO (
                MA_KIEM_KHO,
                MA_KHO,
                MA_NV,
                NGAY_KIEM_KHO,
                NGAY_CAN_BANG_KHO,
                TRANG_THAI_PHIEU_KIEM,
                GHI_CHU_KIEM_KHO
            ) VALUES (
                @MaKiemKho,
                '1',
                @MaNV,
                @NgayKiemKho,
                @NgayCanBangKho,
                @TrangThaiPhieuKiem,
                @GhiChu
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKiemKho", phieu.MaPhieuKiemKho);
                cmd.Parameters.AddWithValue("@MaNV", phieu.MaNhanVien);
                cmd.Parameters.AddWithValue("@NgayKiemKho", phieu.NgayKiemKho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayCanBangKho", phieu.ThoiGianCanBangKho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThaiPhieuKiem", phieu.TrangThaiPhieuKiem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", phieu.GhiChu ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        //cap nhat ghi chu 
        public static void CapNhatGhiChu(string maPhieu, string ghiChu)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "UPDATE PHIEU_KIEM_KHO SET GHI_CHU_KIEM_KHO = @GhiChu WHERE MA_KIEM_KHO = @MaPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GhiChu", ghiChu);
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        // 🔹 Lưu phiếu kiểm kho mới vào DB
        public static bool CapNhatPhieuKiemKho(ClassPhieuKiemKho phieu)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            UPDATE PHIEU_KIEM_KHO
            SET 
                MA_NV = @MaNV,
                NGAY_KIEM_KHO = @NgayKiemKho,
                NGAY_CAN_BANG_KHO = @NgayCanBangKho,
                TRANG_THAI_PHIEU_KIEM = @TrangThaiPhieuKiem,
                GHI_CHU_KIEM_KHO = @GhiChu
            WHERE MA_KIEM_KHO = @MaKiemKho";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Thêm tham số
                cmd.Parameters.AddWithValue("@MaKiemKho", phieu.MaPhieuKiemKho);
                cmd.Parameters.AddWithValue("@MaNV", phieu.MaNhanVien);
                cmd.Parameters.AddWithValue("@NgayKiemKho", phieu.NgayKiemKho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NgayCanBangKho", phieu.ThoiGianCanBangKho ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThaiPhieuKiem", phieu.TrangThaiPhieuKiem ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GhiChu", phieu.GhiChu ?? (object)DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


        //ham xoa phiếu kiểm kho
        public static bool XoaPhieuKiemKho(string maPhieuKiemKho)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "DELETE FROM PHIEU_KIEM_KHO WHERE MA_KIEM_KHO = @MaKiemKho";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKiemKho", maPhieuKiemKho);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }



    }




}


