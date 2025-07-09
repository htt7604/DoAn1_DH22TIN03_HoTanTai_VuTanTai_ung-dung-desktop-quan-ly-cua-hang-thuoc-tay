using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace QL_Nha_thuoc.model
{
    public class DBHelperPN
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

    // Đại diện cho bảng PHIEU_NHAP_HANG
    public class PhieuNhapHang
    {
        public string MaPhieuNhap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime? NgayNhap { get; set; }
        public string TrangThai { get; set; }
        public string GhiChuPhieuNhap { get; set; }
        public decimal? TongTienNhapHang { get; set; }
        public decimal? SoTienDaThanhToan { get; set; }
        public DateTime? NgayThanhToanHangNhap { get; set; }
        public string TenNhaCungCap { get; set; }
        public  decimal SoTienConNo {  get; set; }



        public PhieuNhapHang() { }

        public PhieuNhapHang(string maPhieuNhap, string maNCC, string maNV, DateTime? ngayNhap,
            string trangThai, string ghiChu, decimal? tongTien, decimal? daThanhToan,decimal soTienConNo, DateTime? ngayThanhToan)
        {
            MaPhieuNhap = maPhieuNhap;
            MaNhaCungCap = maNCC;
            MaNhanVien = maNV;
            NgayNhap = ngayNhap;
            TrangThai = trangThai;
            GhiChuPhieuNhap = ghiChu;
            TongTienNhapHang = tongTien;
            SoTienDaThanhToan = daThanhToan;
            SoTienConNo=soTienConNo;
            NgayThanhToanHangNhap = ngayThanhToan;
        }
    }

    // Đại diện chi tiết hàng hóa trong phiếu nhập (nếu có bảng CHI_TIET_PHIEU_NHAP)
    public class ChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ChiTietPhieuNhap() { }

        public ChiTietPhieuNhap(string maPhieu, string maHH, string tenHH, int soLuong, decimal donGia, decimal giamGia, decimal thanhTien)
        {
            MaPhieuNhap = maPhieu;
            MaHangHoa = maHH;
            TenHangHoa = tenHH;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
        }

        public static PhieuNhapHang TimPhieuNhapTheoMa(string maPhieuNhap)
        {
            using (SqlConnection conn = DBHelperPN.GetConnection())
            {
                string query = @"
        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
               NCC.TEN_NHA_CUNG_CAP, PN.TRANG_THAI,
               PN.TONG_TIEN_NHAP_HANG, PN.SO_TIEN_DA_THANH_TOAN,
               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_THANH_TOAN, 0)) AS SO_TIEN_CON_NO
        FROM PHIEU_NHAP_HANG PN
        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
        WHERE PN.MA_PHIEU_NHAP = @MaPhieuNhap";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhieuNhap", maPhieuNhap);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new PhieuNhapHang
                    {
                        MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                        NgayNhap = reader["NGAY_NHAP"] as DateTime?,
                        TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                        TrangThai = reader["TRANG_THAI"]?.ToString(),
                        TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_NHAP_HANG"]) : null,
                        SoTienDaThanhToan = reader["SO_TIEN_DA_THANH_TOAN"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_DA_THANH_TOAN"]) : null,
                        SoTienConNo = reader["SO_TIEN_CON_NO"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_CON_NO"]) : 0
                    };
                }
            }

            return null;
        }


        public static List<PhieuNhapHang> TimPhieuNhapTheoMaNhaCungCap(string maNhaCungCap)
        {
            List<PhieuNhapHang> danhSach = new List<PhieuNhapHang>();

            using (SqlConnection conn = DBHelperPN.GetConnection())
            {
                string query = @"
        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
               NCC.TEN_NHA_CUNG_CAP, PN.TRANG_THAI,
               PN.TONG_TIEN_NHAP_HANG, PN.SO_TIEN_DA_THANH_TOAN,
               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_THANH_TOAN, 0)) AS SO_TIEN_CON_NO
        FROM PHIEU_NHAP_HANG PN
        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
        WHERE PN.MA_NHA_CUNG_CAP = @MaNCC
        ORDER BY PN.NGAY_NHAP DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNCC", maNhaCungCap);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhieuNhapHang pn = new PhieuNhapHang
                    {
                        MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                        NgayNhap = reader["NGAY_NHAP"] as DateTime?,
                        TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                        TrangThai = reader["TRANG_THAI"]?.ToString(),
                        TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_NHAP_HANG"]) : null,
                        SoTienDaThanhToan = reader["SO_TIEN_DA_THANH_TOAN"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_DA_THANH_TOAN"]) : null,
                        SoTienConNo = reader["SO_TIEN_CON_NO"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_CON_NO"]) :0
                    };

                    danhSach.Add(pn);
                }
            }

            return danhSach;
        }


        public static List<PhieuNhapHang> TimPhieuNhapTheoTenNhaCungCap(string tenNhaCungCap)
        {
            List<PhieuNhapHang> danhSach = new List<PhieuNhapHang>();

            using (SqlConnection conn = DBHelperPN.GetConnection())
            {
                string query = @"
        SELECT PN.MA_PHIEU_NHAP, PN.NGAY_NHAP, 
               NCC.TEN_NHA_CUNG_CAP, PN.TRANG_THAI,
               PN.TONG_TIEN_NHAP_HANG, PN.SO_TIEN_DA_THANH_TOAN,
               (ISNULL(PN.TONG_TIEN_NHAP_HANG, 0) - ISNULL(PN.SO_TIEN_DA_THANH_TOAN, 0)) AS SO_TIEN_CON_NO
        FROM PHIEU_NHAP_HANG PN
        JOIN NHA_CUNG_CAP NCC ON PN.MA_NHA_CUNG_CAP = NCC.MA_NHA_CUNG_CAP
        WHERE NCC.TEN_NHA_CUNG_CAP LIKE @TenNCC
        ORDER BY PN.NGAY_NHAP DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenNCC", "%" + tenNhaCungCap + "%");

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PhieuNhapHang pn = new PhieuNhapHang
                    {
                        MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                        NgayNhap = reader["NGAY_NHAP"] as DateTime?,
                        TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"].ToString(),
                        TrangThai = reader["TRANG_THAI"]?.ToString(),
                        TongTienNhapHang = reader["TONG_TIEN_NHAP_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_NHAP_HANG"]) : null,
                        SoTienDaThanhToan = reader["SO_TIEN_DA_THANH_TOAN"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_DA_THANH_TOAN"]) : null,
                        SoTienConNo = reader["SO_TIEN_CON_NO"] != DBNull.Value ? Convert.ToDecimal(reader["SO_TIEN_CON_NO"]) :0
                    };

                    danhSach.Add(pn);
                }
            }

            return danhSach;
        }


        //tao ma phieu nhap 
        public static string TaoMaPhieuNhapTuDong()
        {
            using (SqlConnection connection = DBHelperPN.GetConnection())
            {
                try
                {
                    connection.Open();
                    string ngayHienTai = DateTime.Now.ToString("yyyyMMdd");

                    string query = @"
                SELECT COUNT(*) 
                FROM PHIEU_NHAP_HANG 
                WHERE CONVERT(VARCHAR, NGAY_NHAP, 112) = @Ngay";

                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Ngay", ngayHienTai);

                    int soLuongTrongNgay = (int)cmd.ExecuteScalar();
                    int soTiepTheo = soLuongTrongNgay + 1;

                    // Tạo mã với tiền tố PN + ngày + số thứ tự có 3 chữ số
                    string maPhieu = $"PN{ngayHienTai}{soTiepTheo.ToString("D3")}";

                    return maPhieu;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tạo mã phiếu nhập: " + ex.Message);
                    return null;
                }
            }
        }




    }
}
