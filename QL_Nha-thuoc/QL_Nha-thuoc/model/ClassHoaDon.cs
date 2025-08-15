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
        public string TenKhachHang { get; set; } // Thêm thuộc tính này nếu cần
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




        public List<ClassChiTietHoaDon> ChiTietHoaDon { get; set; } = new List<ClassChiTietHoaDon>();

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
                string query = @"	   
                SELECT HD.*, NV.HO_TEN_NV, KH.TEN_KH
                 FROM HOA_DON HD 
                 JOIN NHAN_VIEN NV ON HD.MA_NV = NV.MA_NV
                JOIN KHACH_HANG KH ON HD.MA_KH = KH.MA_KH
                 WHERE HD.TRANG_THAI <> N'Đã hủy'
                 ORDER BY NGAY_LAP_HD DESC
";

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
                            TenKhachHang = reader["TEN_KH"] != DBNull.Value ? reader["TEN_KH"].ToString() : null,
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

            // Lấy chi tiết hóa đơn cho từng hóa đơn
            foreach (var hd in danhSach)
            {
                hd.ChiTietHoaDon = ClassChiTietHoaDon.LayChiTietTheoHoaDon(hd.MaHoaDon);
            }

            return danhSach;
        }



        public static ClassHoaDon LayHoaDonTheoMa(string maHD)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"SELECT HD.*, NV.HO_TEN_NV,KH.TEN_KH
                         FROM HOA_DON HD  
                         JOIN NHAN_VIEN NV ON HD.MA_NV = NV.MA_NV
						 Join KHACH_HANG KH ON HD.MA_KH=KH.MA_KH 
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
                            TenKhachHang = reader["TEN_KH"] != DBNull.Value ? reader["TEN_KH"].ToString() : null,
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
            return "HD" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
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
        public static bool CapNhatHoaDon(ClassHoaDon classHoaDon)
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





        public static void HuyHoaDon(string maHoaDon)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    // 1. Cập nhật trạng thái hóa đơn
                    string sqlUpdateHD = "UPDATE HOA_DON SET TRANG_THAI = N'Đã hủy' WHERE MA_HOA_DON = @MaHD";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdateHD, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Lấy danh sách chi tiết hóa đơn
                    string sqlCTHD = "SELECT MA_HANG_HOA, SO_LUONG_HH FROM CHI_TIET_HOA_DON WHERE MA_HOA_DON = @MaHD";
                    List<(string MaHH, int SoLuong)> danhSachChiTiet = new List<(string, int)>();

                    using (SqlCommand cmd = new SqlCommand(sqlCTHD, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string maHH = reader["MA_HANG_HOA"].ToString();
                                int soLuong = Convert.ToInt32(reader["SO_LUONG_HH"]);
                                danhSachChiTiet.Add((maHH, soLuong));
                            }
                        }
                    }

                    // 3. Cập nhật lại tồn kho
                    foreach (var item in danhSachChiTiet)
                    {
                        ClassHangHoa.CapNhatSoLuongTon(item.MaHH,item.SoLuong);
                    }

                    // 4. Hủy phiếu thu/chi liên quan nếu có
                    string sqlUpdatePTC = "UPDATE PHIEU_THU_CHI SET TRANG_THAI_THANH_TOAN = N'Đã hủy' WHERE MA_HOA_DON = @MaHD";
                    using (SqlCommand cmd = new SqlCommand(sqlUpdatePTC, conn, tran))
                    {
                        cmd.Parameters.AddWithValue("@MaHD", maHoaDon);
                        cmd.ExecuteNonQuery();
                    }

                    // 5. Hoàn tất giao dịch
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw new Exception("Hủy hóa đơn thất bại: " + ex.Message);
                }
            }
        }



        // Lấy top 10 hàng hóa bán theo tổng giá trị
        public static List<(string MaHangHoa, string TenHangHoa, int TongSoLuong, decimal TongGiaTri)> LayTop10HangHoaTheoTongGiaTri(DateTime tuNgay, DateTime denNgay)
        {
            var ketQua = new List<(string, string, int, decimal)>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT TOP 10 
                CTHD.MA_HANG_HOA, 
                HH.TEN_HANG_HOA, 
                SUM(CTHD.SO_LUONG_HH) AS TongSoLuong, 
                SUM(ISNULL(CTHD.THANH_TIEN, 0)) AS TongGiaTri
            FROM CHI_TIET_HOA_DON CTHD
            JOIN HOA_DON HD ON CTHD.MA_HOA_DON = HD.MA_HOA_DON
            JOIN HANG_HOA HH ON CTHD.MA_HANG_HOA = HH.MA_HANG_HOA
            WHERE HD.TRANG_THAI <> N'Đã hủy'
                AND HD.NGAY_LAP_HD >= @TuNgay
                AND HD.NGAY_LAP_HD <= @DenNgay
            GROUP BY CTHD.MA_HANG_HOA, HH.TEN_HANG_HOA
            ORDER BY TongGiaTri DESC"; // Sắp xếp theo tổng giá trị giảm dần
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                    cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string maHH = reader["MA_HANG_HOA"].ToString();
                            string tenHH = reader["TEN_HANG_HOA"].ToString();
                            int tongSoLuong = reader["TongSoLuong"] != DBNull.Value ? Convert.ToInt32(reader["TongSoLuong"]) : 0;
                            decimal tongGiaTri = reader["TongGiaTri"] != DBNull.Value ? Convert.ToDecimal(reader["TongGiaTri"]) : 0m;
                            ketQua.Add((maHH, tenHH, tongSoLuong, tongGiaTri));
                        }
                    }
                }
            }
            return ketQua;
        }


        public static  DataTable LayDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
        {
            DataTable dt = new DataTable();
            string query = @"
        SELECT 
            CONVERT(date, hd.NgayLap) AS Ngay,
            SUM(ct.SoLuong * ct.DonGia) AS DoanhThu
        FROM HOADON hd
        INNER JOIN CHITIETHOADON ct ON hd.MaHoaDon = ct.MaHoaDon
        WHERE hd.NgayLap BETWEEN @TuNgay AND @DenNgay
        GROUP BY CONVERT(date, hd.NgayLap)
        ORDER BY Ngay ASC";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@DenNgay", denNgay);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }
        public class DoanhThuNgaySanPham
        {
            public DateTime Ngay { get; set; }
            public string TenSanPham { get; set; }
            public decimal DoanhThu { get; set; }
        }

        public static List<DoanhThuNgaySanPham> LayDoanhThuTheoNgayVaSanPham(DateTime tuNgay, DateTime denNgay)
        {
            var result = new List<DoanhThuNgaySanPham>();

            string query = @"
SELECT CAST(hd.NGAY_LAP_HD AS DATE) AS Ngay,
               hh.TEN_HANG_HOA,
               SUM(ct.SO_LUONG_HH * ct.DON_GIA_BAN) AS DoanhThu
        FROM HOA_DON hd
        JOIN CHI_TIET_HOA_DON ct ON hd.MA_HOA_DON = ct.MA_HOA_DON
        JOIN HANG_HOA hh ON ct.MA_HANG_HOA = hh.MA_HANG_HOA
        WHERE hd.NGAY_LAP_HD >= @tuNgay AND hd.NGAY_LAP_HD <= @denNgay
        GROUP BY CAST(hd.NGAY_LAP_HD AS DATE), hh.TEN_HANG_HOA
        ORDER BY Ngay
    ";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@tuNgay", tuNgay);
                cmd.Parameters.AddWithValue("@denNgay", denNgay);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new DoanhThuNgaySanPham
                        {
                            Ngay = reader.GetDateTime(0),
                            TenSanPham = reader.GetString(1),
                            DoanhThu = reader.GetDecimal(2)
                        });
                    }
                }
            }

            return result;
        }














    }
}
