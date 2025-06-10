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
        public int SoLuongThucTe { get; set; }
        public int SoLuongHeThong { get; set; }
        public string GhiChu { get; set; }

        public ChiTietPhieuKiemKho(string maKiemKho, string maHangHoa, int soLuongThucTe, int soLuongHeThong, string ghiChu)
        {
            MaKiemKho = maKiemKho;
            MaHangHoa = maHangHoa;
            SoLuongThucTe = soLuongThucTe;
            SoLuongHeThong = soLuongHeThong;
            GhiChu = ghiChu;
        }


        public static List<ChiTietPhieuKiemKho> LayChiTietPhieuKiemKho(string maKiemKho)
        {
            List<ChiTietPhieuKiemKho> danhSachChiTiet = new List<ChiTietPhieuKiemKho>();

            using (SqlConnection conn = DBHelperPK.GetConnection())
            {
                string query = @"SELECT CTPKK.MA_KIEM_KHO, CTPKK.MA_HANG_HOA, HH.TEN_HANG_HOA, 
                CTPKK.SO_LUONG_THUC_TE, CTPKK.SO_LUONG_HE_THONG, CTPKK.GHI_CHU
                FROM CHI_TIET_PHIEU_KIEM_KHO CTPKK
                JOIN HANG_HOA HH ON CTPKK.MA_HANG_HOA = HH.MA_HANG_HOA
                WHERE CTPKK.MA_KIEM_KHO = @MaKiemKho";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaKiemKho", maKiemKho);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string maPhieu = reader["MA_KIEM_KHO"].ToString();
                    string maHH = reader["MA_HANG_HOA"].ToString();
                    int slThucTe = Convert.ToInt32(reader["SO_LUONG_THUC_TE"]);
                    int slHeThong = Convert.ToInt32(reader["SO_LUONG_HE_THONG"]);
                    string ghiChu = reader["GHI_CHU"] == DBNull.Value ? "" : reader["GHI_CHU"].ToString();
                    var chiTiet = new ChiTietPhieuKiemKho(maPhieu, maHH, slThucTe, slHeThong, ghiChu);
                    danhSachChiTiet.Add(chiTiet);
                }
            }

            return danhSachChiTiet;
        }

    }
















    public class PhieuKiemKho
    {
        public string MaPhieuKiemKho { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? NgayKiemKho { get; set; }
        public DateTime? ThoiGianCanBangKho { get; set; }
        public string TrangThaiPhieuKiem { get; set; }  // 👈 Thêm thuộc tính mới

        public string GhiChu { get; set; } // 👈 Thêm thuộc tính ghi chú

        public PhieuKiemKho(string maPhieuKiemKho, string tenNV)
        {
            MaPhieuKiemKho = maPhieuKiemKho;
            TenNhanVien = tenNV;
        }

        public PhieuKiemKho(string maPhieuKiemKho, string tenNV, DateTime ngayKiem, DateTime ngayCanBang, string trangThai,string ghiChu)
        {
            MaPhieuKiemKho = maPhieuKiemKho;
            TenNhanVien = tenNV;
            NgayKiemKho = ngayKiem;
            ThoiGianCanBangKho = ngayCanBang;
            TrangThaiPhieuKiem = trangThai;
            GhiChu = ghiChu; // Khởi tạo ghi chú rỗng
        }
    }
    public class ClassPhieuKiemKho
    {
        public string MaPhieuKiem { get; set; }
        public string MaNhanVien { get; set; }
        public PhieuKiemKho PhieuKiemKho { get; set; }

        public ClassPhieuKiemKho(string maPhieuKiem, string maNV, PhieuKiemKho phieuKiemKho)
        {
            MaPhieuKiem = maPhieuKiem;
            MaNhanVien = maNV;
            PhieuKiemKho = phieuKiemKho;
        }

        // ✅ Method để lấy thông tin phiếu kiểm kho từ DB theo mã phiếu kiểm
        public static ClassPhieuKiemKho LayPhieuKiemKho(string maPhieuKiem)
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

                    var phieuKiemKho = new PhieuKiemKho(maPhieuKiem, hoTenNV, ngayKiem, ngayCanBang, trangThai, ghiChu);
                    return new ClassPhieuKiemKho(maPhieuKiem, maNV, phieuKiemKho);
                }
                else
                {
                    return null;
                }
            }
        }

    }
}


