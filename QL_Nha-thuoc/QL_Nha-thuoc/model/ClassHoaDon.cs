using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class ClassHoaDon
    {
        // Các thuộc tính đại diện cho thông tin hóa đơn
        public string MaHoaDon { get; set; }
        public string MaNV { get; set; }
        public string TenNhanVien { get; set; }
        public string MaKH { get; set; }
        public string MaBangGia { get; set; }
        public string MaHinhThucThanhToan { get; set; }
        public string MaTaiKhoanNganHang { get; set; }
        public DateTime? NgayLapHD { get; set; }
        public string LoaiHoaDon { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal? ThanhTien { get; set; }
        public string GhiChuHoaDon { get; set; }
        public decimal? KhachThanhToan {  get; set; }
        public decimal? TienTraKhach { get; set; }
        public string TrangThai {  get; set; }


        // Constructor khởi tạo đầy đủ thông tin hóa đơn
        public ClassHoaDon(string maHoaDon, string maNV,string tenNV, string maKH, string maBangGia, string maHTTT,string maTKNG,
                           DateTime? ngayLapHD, string loaiHoaDon, decimal? giamGia, decimal? thanhTien, string ghiChu, decimal khachThanhToa, decimal tienTraKhach,string trangThai)
        {
            MaHoaDon = maHoaDon;
            MaNV = maNV;
            TenNhanVien=tenNV;
            MaKH = maKH;
            MaBangGia = maBangGia;
            MaHinhThucThanhToan = maHTTT;
            MaTaiKhoanNganHang = maTKNG;
            NgayLapHD = ngayLapHD;
            LoaiHoaDon = loaiHoaDon;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
            GhiChuHoaDon = ghiChu;
            KhachThanhToan = khachThanhToa;
            TienTraKhach = tienTraKhach;
            TrangThai = trangThai;
        }
        public ClassHoaDon() { }



        // Lấy toàn bộ danh sách hóa đơn
        public static List<ClassHoaDon> LayDanhSachHoaDon()
        {
            List<ClassHoaDon> danhSach = new List<ClassHoaDon>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"SELECT HD.*, NV.HO_TEN_NV
                         FROM HOA_DON HD 
                         JOIN NHAN_VIEN NV ON HD.MA_NV = NV.MA_NV
                         ORDER BY NGAY_LAP_HD DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassHoaDon hd = new ClassHoaDon
                        {
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaNV = reader["MA_NV"].ToString(),
                            TenNhanVien = reader["HO_TEN_NV"].ToString(),
                            MaKH = reader["MA_KH"] != DBNull.Value ? reader["MA_KH"].ToString() : null,
                            MaBangGia = reader["MA_BANG_GIA"] != DBNull.Value ? reader["MA_BANG_GIA"].ToString() : null,
                            MaHinhThucThanhToan = reader["MA_HINH_THUC_THANH_TOAN"] != DBNull.Value ? reader["MA_HINH_THUC_THANH_TOAN"].ToString() : null,
                            MaTaiKhoanNganHang = reader["MA_TAI_KHOAN_NGAN_HANG"] != DBNull.Value ? reader["MA_TAI_KHOAN_NGAN_HANG"].ToString() : null,
                            NgayLapHD = reader["NGAY_LAP_HD"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["NGAY_LAP_HD"]) : null,
                            LoaiHoaDon = reader["LOAI_HOA_DON"] != DBNull.Value ? reader["LOAI_HOA_DON"].ToString() : null,
                            GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : (decimal?)null,
                            ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : (decimal?)null,
                            GhiChuHoaDon = reader["GHI_CHU_HOA_DON"] != DBNull.Value ? reader["GHI_CHU_HOA_DON"].ToString() : null,
                            KhachThanhToan = reader["KHACH_THANH_TOAN"] != DBNull.Value ? Convert.ToDecimal(reader["KHACH_THANH_TOAN"]) : (decimal?)null,
                            TienTraKhach = reader["TRA_LAI_KHACH"] != DBNull.Value ? Convert.ToDecimal(reader["TRA_LAI_KHACH"]) : (decimal?)null,
                            TrangThai = reader["TRANG_THAI"] != DBNull.Value ? reader["TRANG_THAI"].ToString() : null
                        };

                        danhSach.Add(hd);
                    }
                }
            }

            return danhSach;
        }


        public static ClassHoaDon LayHoaDonTheoMa(string maHD)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"SELECT HD.*, NV.HO_TEN_NV
                         FROM HOA_DON HD  
                         JOIN NHAN_VIEN NV ON HD.MA_NV = NV.MA_NV 
                         WHERE HD.MA_HOA_DON = @MA_HOA_DON";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", maHD);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new ClassHoaDon
                        {
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaNV = reader["MA_NV"].ToString(),
                            TenNhanVien = reader["HO_TEN_NV"].ToString(),
                            MaKH = reader["MA_KH"] != DBNull.Value ? reader["MA_KH"].ToString() : null,
                            MaBangGia = reader["MA_BANG_GIA"] != DBNull.Value ? reader["MA_BANG_GIA"].ToString() : null,
                            MaHinhThucThanhToan = reader["MA_HINH_THUC_THANH_TOAN"] != DBNull.Value ? reader["MA_HINH_THUC_THANH_TOAN"].ToString() : null,
                            MaTaiKhoanNganHang = reader["MA_TAI_KHOAN_NGAN_HANG"] != DBNull.Value ? reader["MA_TAI_KHOAN_NGAN_HANG"].ToString() : null,
                            NgayLapHD = reader["NGAY_LAP_HD"] != DBNull.Value ? (DateTime?)Convert.ToDateTime(reader["NGAY_LAP_HD"]) : null,
                            LoaiHoaDon = reader["LOAI_HOA_DON"] != DBNull.Value ? reader["LOAI_HOA_DON"].ToString() : null,
                            GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : (decimal?)null,
                            ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : (decimal?)null,
                            GhiChuHoaDon = reader["GHI_CHU_HOA_DON"] != DBNull.Value ? reader["GHI_CHU_HOA_DON"].ToString() : null,
                            KhachThanhToan = reader["KHACH_THANH_TOAN"] != DBNull.Value ? Convert.ToDecimal(reader["KHACH_THANH_TOAN"]) : (decimal?)null,
                            TienTraKhach = reader["TRA_LAI_KHACH"] != DBNull.Value ? Convert.ToDecimal(reader["TRA_LAI_KHACH"]) : (decimal?)null,
                            TrangThai = reader["TRANG_THAI"] != DBNull.Value ? reader["TRANG_THAI"].ToString() : null
                        };
                    }
                }
            }

            return null; // không tìm thấy hóa đơn
        }
        /// <summary>
        /// Tạo mã hóa đơn tự động (ví dụ: HD000001)
        /// </summary>
        public static string TaoMaHoaDonTuDong()
        {
            string maMoi = "HD000001";
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT TOP 1 MA_HOA_DON FROM HOA_DON ORDER BY MA_HOA_DON DESC";
                SqlCommand cmd = new SqlCommand(query, conn);
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    string maCu = result.ToString(); // VD: HD000123
                    int so = int.Parse(maCu.Substring(2)); // 123
                    maMoi = "HD" + (so + 1).ToString("D6"); // HD000124
                }
            }
            return maMoi;
        }

        /// <summary>
        /// Thêm hóa đơn mới
        public static bool ThemHoaDon(ClassHoaDon classHoaDon)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO HOA_DON 
                         (MA_HOA_DON, MA_NV, MA_KH, MA_BANG_GIA, MA_HINH_THUC_THANH_TOAN, MA_TAI_KHOAN_NGAN_HANG,
                          NGAY_LAP_HD, LOAI_HOA_DON, GIAM_GIA, THANH_TIEN, GHI_CHU_HOA_DON,
                          KHACH_THANH_TOAN, TRA_LAI_KHACH, TRANG_THAI)
                         VALUES 
                         (@MA_HOA_DON, @MA_NV, @MA_KH, @MA_BANG_GIA, @MA_HTTT, @MA_TKNH,
                          @NGAY_LAP, @LOAI_HD, @GIAM_GIA, @THANH_TIEN, @GHI_CHU,
                          @KHACH_THANH_TOAN, @TRA_LAI_KHACH, @TRANG_THAI)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", classHoaDon.MaHoaDon);
                cmd.Parameters.AddWithValue("@MA_NV", classHoaDon.MaNV);
                cmd.Parameters.AddWithValue("@MA_KH", classHoaDon.MaKH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_BANG_GIA", classHoaDon.MaBangGia ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_HTTT", classHoaDon.MaHinhThucThanhToan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_TKNH", classHoaDon.MaTaiKhoanNganHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NGAY_LAP", classHoaDon.NgayLapHD ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LOAI_HD", classHoaDon.LoaiHoaDon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GIAM_GIA", classHoaDon.GiamGia ?? 0);
                cmd.Parameters.AddWithValue("@THANH_TIEN", classHoaDon.ThanhTien ?? 0);
                cmd.Parameters.AddWithValue("@GHI_CHU", classHoaDon.GhiChuHoaDon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@KHACH_THANH_TOAN", classHoaDon.KhachThanhToan ?? 0m);
                cmd.Parameters.AddWithValue("@TRA_LAI_KHACH", classHoaDon.TienTraKhach ?? 0m);
                cmd.Parameters.AddWithValue("@TRANG_THAI", classHoaDon.TrangThai ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        /// <summary>
        /// Sửa hóa đơn (theo MA_HOA_DON)
        public bool CapNhatHoaDon(ClassHoaDon classHoaDon)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"UPDATE HOA_DON
                         SET MA_NV = @MA_NV, MA_KH = @MA_KH, MA_BANG_GIA = @MA_BANG_GIA,
                             MA_HINH_THUC_THANH_TOAN = @MA_HTTT, MA_TAI_KHOAN_NGAN_HANG = @MA_TKNH, 
                             NGAY_LAP_HD = @NGAY_LAP, LOAI_HOA_DON = @LOAI_HD, GIAM_GIA = @GIAM_GIA,
                             THANH_TIEN = @THANH_TIEN, GHI_CHU_HOA_DON = @GHI_CHU,
                             KHACH_THANH_TOAN = @KHACH_THANH_TOAN, TRA_LAI_KHACH = @TRA_LAI_KHACH,
                             TRANG_THAI = @TRANG_THAI
                         WHERE MA_HOA_DON = @MA_HOA_DON";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", classHoaDon.MaHoaDon);
                cmd.Parameters.AddWithValue("@MA_NV", classHoaDon.MaNV);
                cmd.Parameters.AddWithValue("@MA_KH", classHoaDon.MaKH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_BANG_GIA", classHoaDon.MaBangGia ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_HTTT", classHoaDon.MaHinhThucThanhToan ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MA_TKNH", classHoaDon.MaTaiKhoanNganHang ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@NGAY_LAP", classHoaDon.NgayLapHD ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@LOAI_HD", classHoaDon.LoaiHoaDon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@GIAM_GIA", classHoaDon.GiamGia ?? 0);
                cmd.Parameters.AddWithValue("@THANH_TIEN", classHoaDon.ThanhTien ?? 0);
                cmd.Parameters.AddWithValue("@GHI_CHU", classHoaDon.GhiChuHoaDon ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@KHACH_THANH_TOAN", classHoaDon.KhachThanhToan ?? 0m);
                cmd.Parameters.AddWithValue("@TRA_LAI_KHACH", classHoaDon.TienTraKhach ?? 0m);
                cmd.Parameters.AddWithValue("@TRANG_THAI", classHoaDon.TrangThai ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }


        /// <summary>
        /// Xóa hóa đơn theo mã (MA_HOA_DON)
        /// </summary>
        public bool XoaHoaDon(ClassHoaDon classHoaDon)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM HOA_DON WHERE MA_HOA_DON = @MA_HOA_DON";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MA_HOA_DON", classHoaDon.MaHoaDon);

                return cmd.ExecuteNonQuery() > 0;
            }
        }




    }
}
