using Microsoft.Data.SqlClient;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassPhieuThuChi
    {
        public string MaPhieuThuChi { get; set; }
        public string MaLoaiPhieu { get; set; }           // THU / CHI
        public string MaNhanVien { get; set; }
        public string MaHoaDon { get; set; }
        public string MaPhieuNhap { get; set; }
        public string MaHinhThucThanhToan { get; set; }
        public DateTime? NgayLapPhieu { get; set; }
        public decimal? SoTien { get; set; }
        public string NoiDung { get; set; }
        public decimal? ThucThu { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhaCungCap { get; set; }
        public string TrangThaiThanhToan { get; set; }
        public decimal? LoiNhuan { get; set; }
        public string MaPhieuTraHang { get; set; } // Thêm trường MaPhieuTraHang nếu cần

        // Optionally: constructor
        public ClassPhieuThuChi() { }

        public ClassPhieuThuChi(
            string maPhieuThuChi,
            string maLoaiPhieu,
            string maNhanVien,
            string maHoaDon,
            string maPhieuNhap,
            string maHinhThucThanhToan,
            DateTime? ngayLapPhieu,
            decimal? soTien,
            string noiDung,
            decimal? thucThu,
            string maKhachHang,
            string maNhaCungCap,
            string trangThaiThanhToan
,
            decimal? loiNhuan
            ,
            string maPhieuTraHang

        )
        {
            MaPhieuThuChi = maPhieuThuChi;
            MaLoaiPhieu = maLoaiPhieu;
            MaNhanVien = maNhanVien;
            MaHoaDon = maHoaDon;
            MaPhieuNhap = maPhieuNhap;
            MaHinhThucThanhToan = maHinhThucThanhToan;
            NgayLapPhieu = ngayLapPhieu;
            SoTien = soTien;
            NoiDung = noiDung;
            ThucThu = thucThu;
            MaKhachHang = maKhachHang;
            MaNhaCungCap = maNhaCungCap;
            TrangThaiThanhToan = trangThaiThanhToan;
            LoiNhuan = loiNhuan;
            MaPhieuTraHang = maPhieuTraHang;
        }

        public static List<ClassPhieuThuChi> LayDanhSachPhieuThuChi(DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            List<ClassPhieuThuChi> danhSach = new List<ClassPhieuThuChi>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                // Câu truy vấn có thể thêm điều kiện lọc theo khoảng ngày nếu được truyền vào
                string query = @"
            SELECT MA_PHIEU_THU_CHI, MA_LOAI_PHIEU, MA_NV, MA_HOA_DON, MA_PHIEU_NHAP,MA_PHIEU_TRA_HANG,
                   MA_HINH_THUC_THANH_TOAN, NGAY_LAP_PHIEU, SO_TIEN, NOI_DUNG,
                   THUC_THU, MA_KH, MA_NHA_CUNG_CAP, TRANG_THAI_THANH_TOAN,LOI_NHUAN    
            FROM PHIEU_THU_CHI
            WHERE 1=1
        ";

                if (ngayBatDau.HasValue)
                    query += " AND NGAY_LAP_PHIEU >= @NgayBatDau";
                if (ngayKetThuc.HasValue)
                    query += " AND NGAY_LAP_PHIEU <= @NgayKetThuc";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (ngayBatDau.HasValue)
                    cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Value.Date);
                if (ngayKetThuc.HasValue)
                    cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Value.Date);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var phieu = new ClassPhieuThuChi
                        {
                            MaPhieuThuChi = reader["MA_PHIEU_THU_CHI"].ToString(),
                            MaLoaiPhieu = reader["MA_LOAI_PHIEU"].ToString(),
                            MaNhanVien = reader["MA_NV"].ToString(),
                            MaHoaDon = reader["MA_HOA_DON"] == DBNull.Value ? null : reader["MA_HOA_DON"].ToString(),
                            MaPhieuNhap = reader["MA_PHIEU_NHAP"] == DBNull.Value ? null : reader["MA_PHIEU_NHAP"].ToString(),
                            MaHinhThucThanhToan = reader["MA_HINH_THUC_THANH_TOAN"].ToString(),
                            NgayLapPhieu = reader["NGAY_LAP_PHIEU"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["NGAY_LAP_PHIEU"]),
                            SoTien = reader["SO_TIEN"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["SO_TIEN"]),
                            NoiDung = reader["NOI_DUNG"] == DBNull.Value ? null : reader["NOI_DUNG"].ToString(),
                            ThucThu = reader["THUC_THU"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["THUC_THU"]),
                            MaKhachHang = reader["MA_KH"] == DBNull.Value ? null : reader["MA_KH"].ToString(),
                            MaNhaCungCap = reader["MA_NHA_CUNG_CAP"] == DBNull.Value ? null : reader["MA_NHA_CUNG_CAP"].ToString(),
                            TrangThaiThanhToan = reader["TRANG_THAI_THANH_TOAN"].ToString(),
                            LoiNhuan= reader["LOI_NHUAN"] == DBNull.Value ? (decimal?)null : Convert.ToDecimal(reader["LOI_NHUAN"]),
                            MaPhieuTraHang = reader["MA_PHIEU_TRA_HANG"] == DBNull.Value ? null : reader["MA_PHIEU_TRA_HANG"].ToString()
                        };
                        danhSach.Add(phieu);
                    }
                }
            }

            return danhSach;
        }









        public static string TaoMaPhieuThu()
        {
            string prefix = "PTH" + DateTime.Now.ToString("yyyyMMdd");
            return TaoMaPhieu(prefix, "THU");
        }

        public static string TaoMaPhieuChi()
        {
            string prefix = "PCI" + DateTime.Now.ToString("yyyyMMdd");
            return TaoMaPhieu(prefix, "CHI");
        }

        private static string TaoMaPhieu(string prefix, string loaiPhieu)
        {
            string maMoi = prefix + "001";
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT TOP 1 MA_PHIEU_THU_CHI 
                    FROM PHIEU_THU_CHI 
                    WHERE MA_PHIEU_THU_CHI LIKE @prefix + '%' AND MA_LOAI_PHIEU = @loaiPhieu
                    ORDER BY MA_PHIEU_THU_CHI DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@prefix", prefix);
                cmd.Parameters.AddWithValue("@loaiPhieu", loaiPhieu);

                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string maCu = result.ToString();
                    int so = int.Parse(maCu.Substring(prefix.Length)) + 1;
                    maMoi = prefix + so.ToString("D3");
                }
            }
            return maMoi;
        }


        public static bool ThemPhieuThu(ClassPhieuThuChi classPhieuThuChi)
        {

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    INSERT INTO PHIEU_THU_CHI (
                        MA_PHIEU_THU_CHI, MA_LOAI_PHIEU, MA_NV, MA_HOA_DON,
                        MA_HINH_THUC_THANH_TOAN, NGAY_LAP_PHIEU, SO_TIEN, NOI_DUNG, 
                        THUC_THU, MA_KH, TRANG_THAI_THANH_TOAN,LOI_NHUAN
                    )
                    VALUES (
                        @MA_PHIEU_THU_CHI, @MA_LOAI_PHIEU, @MA_NV, @MA_HOA_DON,
                        @MA_HTTT, @NGAY, @SO_TIEN, @NOI_DUNG , 
                        @THUC_THU, @MA_KH, @TRANG_THAI,@LOI_NHUAN
                    )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_PHIEU_THU_CHI", classPhieuThuChi.MaPhieuThuChi);
                cmd.Parameters.AddWithValue("@MA_LOAI_PHIEU", classPhieuThuChi.MaLoaiPhieu);
                cmd.Parameters.AddWithValue("@MA_NV", classPhieuThuChi.MaNhanVien);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", classPhieuThuChi.MaHoaDon);
                cmd.Parameters.AddWithValue("@MA_HTTT", classPhieuThuChi.MaHinhThucThanhToan);
                cmd.Parameters.AddWithValue("@NGAY", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@SO_TIEN", classPhieuThuChi.SoTien);
                cmd.Parameters.AddWithValue("@NOI_DUNG", classPhieuThuChi.NoiDung ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@THUC_THU", classPhieuThuChi.ThucThu);
                cmd.Parameters.AddWithValue("@MA_KH", classPhieuThuChi.MaKhachHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TRANG_THAI", "Đã thu");
                cmd.Parameters.AddWithValue("@LOI_NHUAN", classPhieuThuChi.LoiNhuan ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool ThemPhieuChi(ClassPhieuThuChi classPhieuThuChi)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            INSERT INTO PHIEU_THU_CHI (
                MA_PHIEU_THU_CHI, MA_LOAI_PHIEU, MA_NV, MA_PHIEU_NHAP,
                MA_HINH_THUC_THANH_TOAN, NGAY_LAP_PHIEU, SO_TIEN, NOI_DUNG, 
                MA_NHA_CUNG_CAP, TRANG_THAI_THANH_TOAN, LOI_NHUAN, MA_PHIEU_TRA_HANG
            )
            VALUES (
                @MA_PHIEU_THU_CHI, @MA_LOAI_PHIEU, @MA_NV, @MA_PHIEU_NHAP,
                @MA_HTTT, @NGAY, @SO_TIEN, @NOI_DUNG, 
                @MA_NCC, @TRANG_THAI, @LOI_NHUAN, @MA_PHIEU_TRA_HANG
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_PHIEU_THU_CHI", classPhieuThuChi.MaPhieuThuChi);
                cmd.Parameters.AddWithValue("@MA_LOAI_PHIEU", classPhieuThuChi.MaLoaiPhieu);
                cmd.Parameters.AddWithValue("@MA_NV", classPhieuThuChi.MaNhanVien);
                cmd.Parameters.AddWithValue("@MA_PHIEU_NHAP", classPhieuThuChi.MaPhieuNhap ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_HTTT", classPhieuThuChi.MaHinhThucThanhToan);
                cmd.Parameters.AddWithValue("@NGAY", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@SO_TIEN", classPhieuThuChi.SoTien);
                cmd.Parameters.AddWithValue("@NOI_DUNG", classPhieuThuChi.NoiDung ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_NCC", classPhieuThuChi.MaNhaCungCap ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TRANG_THAI", classPhieuThuChi.TrangThaiThanhToan ?? "Đã chi");
                cmd.Parameters.AddWithValue("@LOI_NHUAN", classPhieuThuChi.LoiNhuan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_PHIEU_TRA_HANG", classPhieuThuChi.MaPhieuTraHang ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }





        public static void HuyPhieuThuChi(string maPhieu)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "UPDATE PHIEU_THU_CHI SET TRANG_THAI_THANH_TOAN = N'Đã hủy' WHERE MA_PHIEU_THU_CHI = @MaPhieu";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đã hủy phiếu thu/chi thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu thu/chi để hủy!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        public static void HuyPhieuTheoHoaDon(string maHoaDon, SqlConnection conn, SqlTransaction tran)
        {
            string sql = "UPDATE PHIEU_THU_CHI SET TRANG_THAI_THANH_TOAN = N'Đã hủy' WHERE MA_HOA_DON = @MaHD";
            using (SqlCommand cmd = new SqlCommand(sql, conn, tran))
            {
                cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmd.ExecuteNonQuery();
            }
        }
































        public static decimal LayTongDoanhThu(DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            decimal tongDoanhThu = 0;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT SUM(LOI_NHUAN) 
            FROM PHIEU_THU_CHI 
            WHERE MA_LOAI_PHIEU = 'THU' AND TRANG_THAI_THANH_TOAN = N'Đã thu'";

                if (ngayBatDau.HasValue)
                    query += " AND NGAY_LAP_PHIEU >= @NgayBatDau";
                if (ngayKetThuc.HasValue)
                    query += " AND NGAY_LAP_PHIEU <= @NgayKetThuc";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (ngayBatDau.HasValue)
                        cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Value.Date);
                    if (ngayKetThuc.HasValue)
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Value.Date);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        tongDoanhThu = Convert.ToDecimal(result);
                }
            }

            return tongDoanhThu;
        }

        public static int DemSoPhieuThu(DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            int soPhieu = 0;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM PHIEU_THU_CHI WHERE MA_LOAI_PHIEU = 'THU' AND TRANG_THAI_THANH_TOAN = N'Đã thu'";

                if (ngayBatDau.HasValue)
                    query += " AND NGAY_LAP_PHIEU >= @NgayBatDau";
                if (ngayKetThuc.HasValue)
                    query += " AND NGAY_LAP_PHIEU <= @NgayKetThuc";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (ngayBatDau.HasValue)
                        cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Value.Date);
                    if (ngayKetThuc.HasValue)
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Value.Date);

                    soPhieu = (int)cmd.ExecuteScalar();
                }
            }

            return soPhieu;
        }
        public static decimal LayTongLoiNhuan(DateTime? ngayBatDau = null, DateTime? ngayKetThuc = null)
        {
            decimal tongLoiNhuan = 0;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT SUM(LOI_NHUAN) 
            FROM PHIEU_THU_CHI 
            WHERE MA_LOAI_PHIEU = 'THU' AND TRANG_THAI_THANH_TOAN = N'Đã thu'";

                if (ngayBatDau.HasValue)
                    query += " AND NGAY_LAP_PHIEU >= @NgayBatDau";
                if (ngayKetThuc.HasValue)
                    query += " AND NGAY_LAP_PHIEU <= @NgayKetThuc";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (ngayBatDau.HasValue)
                        cmd.Parameters.AddWithValue("@NgayBatDau", ngayBatDau.Value.Date);
                    if (ngayKetThuc.HasValue)
                        cmd.Parameters.AddWithValue("@NgayKetThuc", ngayKetThuc.Value.Date);

                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                        tongLoiNhuan = Convert.ToDecimal(result);
                }
            }

            return tongLoiNhuan;
        }



        public static decimal TongTienDaChi()
        {
            decimal tongTien = 0;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT SUM(SO_TIEN) 
            FROM PHIEU_THU_CHI 
            WHERE MA_LOAI_PHIEU = 'CHI' AND TRANG_THAI_THANH_TOAN='Đã chi'";

                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                    tongTien = Convert.ToDecimal(result);
            }

            return tongTien;
        }


    }
}

