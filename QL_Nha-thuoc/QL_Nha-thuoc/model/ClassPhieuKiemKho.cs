using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient
namespace QL_Nha_thuoc.model
{

    public class DBHelperPK
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

    public class ChiTietPhieuKiemKho
    {
        public string MaKiemKho { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuongThucTe { get; set; }
        public int SoLuongHeThong { get; set; }
        public string DonViTinh { get; set; }
        public string GhiChu { get; set; }

        // Constructor đầy đủ
        public ChiTietPhieuKiemKho(string maKiemKho, string maHangHoa, string tenHangHoa, int soLuongThucTe, int soLuongHeThong, string ghiChu,string donViTinh)
        {
            MaKiemKho = maKiemKho;
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            SoLuongThucTe = soLuongThucTe;
            SoLuongHeThong = soLuongHeThong;
            GhiChu = ghiChu;
            DonViTinh = donViTinh; // Thêm thuộc tính đơn vị tính
        }

        // Constructor rút gọn khi chưa có mã kiểm kho và ghi chú
        public ChiTietPhieuKiemKho(string maHangHoa, string tenHangHoa, int soLuongHeThong, string donViTinh)
        {
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            SoLuongHeThong = soLuongHeThong;
            SoLuongThucTe = soLuongHeThong; // mặc định ban đầu = số lượng hệ thống
            DonViTinh = donViTinh;
            GhiChu = "";
        }

        // Constructor rỗng (bắt buộc nếu cần dùng trong deserialization hoặc EF)
        public ChiTietPhieuKiemKho() { }

        // Lấy danh sách chi tiết kiểm kho từ mã kiểm kho
        public static List<ChiTietPhieuKiemKho> LayChiTietPhieuKiemKho(string maKiemKho)
        {
            List<ChiTietPhieuKiemKho> danhSachChiTiet = new List<ChiTietPhieuKiemKho>();

            using (SqlConnection conn = DBHelperPK.GetConnection())
            {
                string query = @"
                SELECT CTPKK.MA_KIEM_KHO, CTPKK.MA_HANG_HOA, HH.TEN_HANG_HOA, 
                CTPKK.SO_LUONG_THUC_TE, CTPKK.SO_LUONG_HE_THONG, CTPKK.GHI_CHU,DVT.TEN_DON_VI_TINH
                FROM CHI_TIET_PHIEU_KIEM_KHO CTPKK
                JOIN HANG_HOA HH ON CTPKK.MA_HANG_HOA = HH.MA_HANG_HOA
                JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
                JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
                WHERE CTPKK.MA_KIEM_KHO = @MaKiemKho";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKiemKho", maKiemKho);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string maPhieu = reader["MA_KIEM_KHO"].ToString();
                    string maHH = reader["MA_HANG_HOA"].ToString();
                    string tenHH = reader["TEN_HANG_HOA"]?.ToString() ?? "";
                    int slThucTe = Convert.ToInt32(reader["SO_LUONG_THUC_TE"]);
                    int slHeThong = Convert.ToInt32(reader["SO_LUONG_HE_THONG"]);
                    string ghiChu = reader["GHI_CHU"]?.ToString() ?? "";
                    string donViTinh = reader["TEN_DON_VI_TINH"]?.ToString() ?? ""; // Lấy tên đơn vị tính nếu có

                    var chiTiet = new ChiTietPhieuKiemKho(maPhieu, maHH, tenHH, slThucTe, slHeThong, ghiChu, donViTinh);
                    danhSachChiTiet.Add(chiTiet);
                }
            }

            return danhSachChiTiet;
        }
    }
















    //public class PhieuKiemKho
    //{
    //    public string MaPhieuKiemKho { get; set; }
    //    public string TenNhanVien { get; set; }
    //    public DateTime? NgayKiemKho { get; set; }
    //    public DateTime? ThoiGianCanBangKho { get; set; }
    //    public string TrangThaiPhieuKiem { get; set; }  // 👈 Thêm thuộc tính mới

    //    public string GhiChu { get; set; } // 👈 Thêm thuộc tính ghi chú

    //    public PhieuKiemKho(string maPhieuKiemKho, string tenNV)
    //    {
    //        MaPhieuKiemKho = maPhieuKiemKho;
    //        TenNhanVien = tenNV;
    //    }

    //    public PhieuKiemKho(string maPhieuKiemKho, string tenNV, DateTime ngayKiem, DateTime ngayCanBang, string trangThai,string ghiChu)
    //    {
    //        MaPhieuKiemKho = maPhieuKiemKho;
    //        TenNhanVien = tenNV;
    //        NgayKiemKho = ngayKiem;
    //        ThoiGianCanBangKho = ngayCanBang;
    //        TrangThaiPhieuKiem = trangThai;
    //        GhiChu = ghiChu; // Khởi tạo ghi chú rỗng
    //    }
    //}
    //public class ClassPhieuKiemKho
    //{
    //    public string MaPhieuKiem { get; set; }
    //    public string MaNhanVien { get; set; }
    //    public PhieuKiemKho PhieuKiemKho { get; set; }

    //    public ClassPhieuKiemKho(string maPhieuKiem, string maNV, PhieuKiemKho phieuKiemKho)
    //    {
    //        MaPhieuKiem = maPhieuKiem;
    //        MaNhanVien = maNV;
    //        PhieuKiemKho = phieuKiemKho;
    //    }

    //    // ✅ Method để lấy thông tin phiếu kiểm kho từ DB theo mã phiếu kiểm
    //    public static ClassPhieuKiemKho LayPhieuKiemKho(string maPhieuKiem)
    //    {
    //        using (SqlConnection conn = DBHelperPK.GetConnection())
    //        {
    //            string query = @"SELECT PKK.MA_KIEM_KHO, PKK.MA_NV, PKK.MA_KHO, PKK.NGAY_KIEM_KHO,PKK.GHI_CHU_KIEM_KHO, 
    //                            PKK.NGAY_CAN_BANG_KHO, PKK.TRANG_THAI_PHIEU_KIEM,
    //                            NV.HO_TEN_NV
    //                     FROM PHIEU_KIEM_KHO PKK 
    //                     JOIN NHAN_VIEN NV ON NV.MA_NV = PKK.MA_NV
    //                     WHERE MA_KIEM_KHO = @MaPhieuKiem";

    //            SqlCommand cmd = new SqlCommand(query, conn);
    //            cmd.Parameters.AddWithValue("@MaPhieuKiem", maPhieuKiem);

    //            conn.Open();
    //            SqlDataReader reader = cmd.ExecuteReader();

    //            if (reader.Read())
    //            {
    //                string maNV = reader["MA_NV"].ToString();
    //                string hoTenNV = reader["HO_TEN_NV"].ToString();
    //                string trangThai = reader["TRANG_THAI_PHIEU_KIEM"].ToString();

    //                DateTime ngayKiem = reader["NGAY_KIEM_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_KIEM_KHO"]);
    //                DateTime ngayCanBang = reader["NGAY_CAN_BANG_KHO"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(reader["NGAY_CAN_BANG_KHO"]);
    //                string ghiChu = reader["GHI_CHU_KIEM_KHO"] == DBNull.Value ? "" : reader["GHI_CHU_KIEM_KHO"].ToString();

    //                var phieuKiemKho = new PhieuKiemKho(maPhieuKiem, hoTenNV, ngayKiem, ngayCanBang, trangThai, ghiChu);
    //                return new ClassPhieuKiemKho(maPhieuKiem, maNV, phieuKiemKho);
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //    }
    //    public static string SinhMaPhieuMoi(SqlConnection connection)
    //    {
    //        string maMoi = "PKK00001";
    //        string query = "SELECT TOP 1 MA_KIEM_KHO FROM PHIEU_KIEM_KHO ORDER BY MA_KIEM_KHO DESC";

    //        using (SqlCommand cmd = new SqlCommand(query, connection))
    //        {
    //            object result = cmd.ExecuteScalar();
    //            if (result != null)
    //            {
    //                string maCu = result.ToString(); // VD: PKK00015
    //                if (maCu.StartsWith("PKK") && int.TryParse(maCu.Substring(3), out int so))
    //                {
    //                    so++; // Tăng lên 1
    //                    maMoi = "PKK" + so.ToString("D5"); // VD: PKK00016
    //                }
    //            }
    //        }

    //        return maMoi;
    //    }




    public class PhieuKiemKho
    {
        // 🔹 Các thuộc tính dữ liệu
        public string MaPhieuKiemKho { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgayKiemKho { get; set; }
        public DateTime? ThoiGianCanBangKho { get; set; }
        public string TrangThaiPhieuKiem { get; set; }
        public string GhiChu { get; set; }

        // 🔹 Constructors
        public PhieuKiemKho() { }

        public PhieuKiemKho(string maPhieu, string tenNV, DateTime? ngayKiem, DateTime? ngayCanBang, string trangThai, string ghiChu)
        {
            MaPhieuKiemKho = maPhieu;
            TenNhanVien = tenNV;
            NgayKiemKho = ngayKiem;
            ThoiGianCanBangKho = ngayCanBang;
            TrangThaiPhieuKiem = trangThai;
            GhiChu = ghiChu;
        }

        // 🔹 Lấy phiếu kiểm kho từ DB
        public static PhieuKiemKho LayPhieuKiemKho(string maPhieuKiem)
        {
            using (SqlConnection conn = DBHelperPK.GetConnection())
            {
                string query = @"SELECT PKK.MA_KIEM_KHO, PKK.MA_NV, PKK.MA_KHO, PKK.NGAY_KIEM_KHO,PKK.GHI_CHU_KIEM_KHO, 
                              PKK.NGAY_CAN_BANG_KHO, PKK.TRANG_THAI_PHIEU_KIEM,
                              NV.HO_TEN_NV
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
                    
                    return new PhieuKiemKho(maPhieuKiem, hoTenNV, ngayKiem, ngayCanBang, trangThai, ghiChu)
                    {
                        MaNhanVien = maNV
                    };
                }

                return null;
            }
        }

        // 🔹 Sinh mã mới
        public static string SinhMaPhieuMoi(SqlConnection connection)
        {
            string maMoi = "PKK00001";
            string query = "SELECT TOP 1 MA_KIEM_KHO FROM PHIEU_KIEM_KHO ORDER BY MA_KIEM_KHO DESC";

            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
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

        //them
        public static bool ThemPhieuKiemKho(PhieuKiemKho phieu)
        {
            using (SqlConnection conn = DBHelperPK.GetConnection())
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

        // 🔹 Lưu phiếu kiểm kho mới vào DB
        public static bool CapNhatPhieuKiemKho(PhieuKiemKho phieu)
        {
            using (SqlConnection conn = DBHelperPK.GetConnection())
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
            using (SqlConnection conn = DBHelperPK.GetConnection())
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


