using System;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
namespace QL_Nha_thuoc.model
{
    public class ClassPhieuTraHang
    {
        public string MaPhieuTraHang { get; set; }
        public string MaNhanVien { get; set; }
        public string MaHoaDon { get; set; }
        public string MaHinhThucThanhToan { get; set; }
        public string MaBangGia { get; set; }
        public decimal TongGiaGocHangMua { get; set; }
        public decimal TongTienTraHang { get; set; }
        public decimal PhiTraHang { get; set; }
        public decimal TienTraKhach { get; set; }
        public DateTime NgayLapPhieuTra { get; set; }
        public string GhiChuPhieuTra { get; set; }
        public string TrangThaiPhieuTra { get; set; } // Mặc định là chưa thanh toán

        public string MaKhachHang { get; set; } // Thêm thuộc tính MaKhachHang nếu cần


        public List<ClassChiTietPhieuTraHang> DsChiTietPhieuTra { get; set; } = new List<ClassChiTietPhieuTraHang>();
        public ClassPhieuTraHang() { }

        public ClassPhieuTraHang(string maPhieu, string maNV, string maHD, string maHTTT, string maBG,
                                 decimal tongGiaGoc, decimal tongTienTra, decimal phiTra,
                                 decimal tienTraKhach, DateTime ngayLap, string ghiChu, string trangThaiPhieuTra, string maKhachHang)
        {
            MaPhieuTraHang = maPhieu;
            MaNhanVien = maNV;
            MaHoaDon = maHD;
            MaHinhThucThanhToan = maHTTT;
            MaBangGia = maBG;
            TongGiaGocHangMua = tongGiaGoc;
            TongTienTraHang = tongTienTra;
            PhiTraHang = phiTra;
            TienTraKhach = tienTraKhach;
            NgayLapPhieuTra = ngayLap;
            GhiChuPhieuTra = ghiChu;
            TrangThaiPhieuTra = trangThaiPhieuTra;
            MaKhachHang = maKhachHang;
        }

        /// <summary>
        /// Lấy phiếu trả hàng theo mã
        /// </summary>
        public static ClassPhieuTraHang LayPhieuTraHangTheoMa(string maPhieuTra)
        {
            ClassPhieuTraHang phieu = null;
            string query = @"SELECT MA_PHIEU_TRA_HANG, MA_NV, MA_HOA_DON, MA_HINH_THUC_THANH_TOAN, MA_BANG_GIA,
                            TONG_GIA_GOC_HANG_MUA, TONG_TIEN_TRA_HANG, PHI_TRA_HANG, TIEN_TRA_KHACH,
                            NGAY_LAP_PHIEU_TRA, GHI_CHU_PHIEU_TRA, TRANG_THAI_PHIEU_TRA, MA_KH
                     FROM PHIEU_TRA_HANG_HD
                     WHERE MA_PHIEU_TRA_HANG = @MaPhieu";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieu", maPhieuTra);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        phieu = new ClassPhieuTraHang
                        {
                            MaPhieuTraHang = reader["MA_PHIEU_TRA_HANG"].ToString(),
                            MaNhanVien = reader["MA_NV"].ToString(),
                            MaKhachHang = reader["MA_KH"] != DBNull.Value ? reader["MA_KH"].ToString() : null,
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaHinhThucThanhToan = reader["MA_HINH_THUC_THANH_TOAN"].ToString(),
                            MaBangGia = reader["MA_BANG_GIA"].ToString(),
                            TongGiaGocHangMua = reader["TONG_GIA_GOC_HANG_MUA"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_GIA_GOC_HANG_MUA"]) : 0,
                            TongTienTraHang = reader["TONG_TIEN_TRA_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_TRA_HANG"]) : 0,
                            PhiTraHang = reader["PHI_TRA_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["PHI_TRA_HANG"]) : 0,
                            TienTraKhach = reader["TIEN_TRA_KHACH"] != DBNull.Value ? Convert.ToDecimal(reader["TIEN_TRA_KHACH"]) : 0,
                            NgayLapPhieuTra = reader["NGAY_LAP_PHIEU_TRA"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_LAP_PHIEU_TRA"]) : DateTime.MinValue,
                            GhiChuPhieuTra = reader["GHI_CHU_PHIEU_TRA"].ToString(),
                            TrangThaiPhieuTra = reader["TRANG_THAI_PHIEU_TRA"].ToString()
                        };
                    }
                }
            }

            if (phieu != null)
            {
                // Lấy chi tiết phiếu trả hàng
                phieu.DsChiTietPhieuTra = ClassChiTietPhieuTraHang.LayChiTietTheoMaPhieu(phieu.MaPhieuTraHang);
            }

            return phieu;
        }



        //lay toàn bộ phiếu trả hàng có trạng thái khác đã xóa 


        public static List<ClassPhieuTraHang> LayTatCaPhieuTraHangKhacDaXoa()
        {
            List<ClassPhieuTraHang> list = new List<ClassPhieuTraHang>();
            string query = @"SELECT MA_PHIEU_TRA_HANG, MA_NV, MA_HOA_DON, MA_HINH_THUC_THANH_TOAN, MA_BANG_GIA,
                            TONG_GIA_GOC_HANG_MUA, TONG_TIEN_TRA_HANG, PHI_TRA_HANG, TIEN_TRA_KHACH,
                            NGAY_LAP_PHIEU_TRA, GHI_CHU_PHIEU_TRA, TRANG_THAI_PHIEU_TRA,MA_KH
                     FROM PHIEU_TRA_HANG_HD
                     WHERE TRANG_THAI_PHIEU_TRA <> 'Đã xóa'
                     ORDER BY NGAY_LAP_PHIEU_TRA DESC";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClassPhieuTraHang phieu = new ClassPhieuTraHang
                        {
                            MaPhieuTraHang = reader["MA_PHIEU_TRA_HANG"].ToString(),
                            MaNhanVien = reader["MA_NV"].ToString(),
                            MaKhachHang= reader["MA_KH"] != DBNull.Value ? reader["MA_KH"].ToString() : null,
                            MaHoaDon = reader["MA_HOA_DON"].ToString(),
                            MaHinhThucThanhToan = reader["MA_HINH_THUC_THANH_TOAN"].ToString(),
                            MaBangGia = reader["MA_BANG_GIA"].ToString(),
                            TongGiaGocHangMua = reader["TONG_GIA_GOC_HANG_MUA"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_GIA_GOC_HANG_MUA"]) : 0,
                            TongTienTraHang = reader["TONG_TIEN_TRA_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["TONG_TIEN_TRA_HANG"]) : 0,
                            PhiTraHang = reader["PHI_TRA_HANG"] != DBNull.Value ? Convert.ToDecimal(reader["PHI_TRA_HANG"]) : 0,
                            TienTraKhach = reader["TIEN_TRA_KHACH"] != DBNull.Value ? Convert.ToDecimal(reader["TIEN_TRA_KHACH"]) : 0,
                            NgayLapPhieuTra = reader["NGAY_LAP_PHIEU_TRA"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_LAP_PHIEU_TRA"]) : DateTime.MinValue,
                            GhiChuPhieuTra = reader["GHI_CHU_PHIEU_TRA"].ToString(),
                            TrangThaiPhieuTra = reader["TRANG_THAI_PHIEU_TRA"].ToString()
                        };
                        list.Add(phieu);
                    }
                }
            }
            // Lấy chi tiết phiếu trả hàng cho từng phiếu
            foreach (var phieu in list)
            {
                phieu.DsChiTietPhieuTra = ClassChiTietPhieuTraHang.LayChiTietTheoMaPhieu(phieu.MaPhieuTraHang);
            }

            return list;
        }







        public static string TaoMaPhieuTraHangTuDong()
        {
            string maMoi = "PTH0001";

            string query = @"SELECT TOP 1 MA_PHIEU_TRA_HANG 
                             FROM PHIEU_TRA_HANG_HD
                             ORDER BY MA_PHIEU_TRA_HANG DESC";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                var result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    string maCu = result.ToString();
                    if (maCu.Length > 3 && int.TryParse(maCu.Substring(3), out int so))
                    {
                        so++;
                        maMoi = "PTH" + so.ToString("D4");
                    }
                }
            }
            return maMoi;
        }

        /// <summary>
        /// Thêm phiếu trả hàng
        /// </summary>
        public bool ThemPhieuTraHang(ClassPhieuTraHang phieu)
        {
            if (string.IsNullOrWhiteSpace(phieu.MaPhieuTraHang))
                phieu.MaPhieuTraHang = TaoMaPhieuTraHangTuDong();

            string query = @"INSERT INTO PHIEU_TRA_HANG_HD
                            (MA_PHIEU_TRA_HANG, MA_NV, MA_HOA_DON, MA_HINH_THUC_THANH_TOAN, MA_BANG_GIA, 
                             TONG_GIA_GOC_HANG_MUA, TONG_TIEN_TRA_HANG, PHI_TRA_HANG, TIEN_TRA_KHACH, 
                             NGAY_LAP_PHIEU_TRA, GHI_CHU_PHIEU_TRA,TRANG_THAI_PHIEU_TRA,MA_KH)
                            VALUES 
                            (@MaPhieuTraHang, @MaNV, @MaHoaDon, @MaHTTT, @MaBangGia,
                             @TongGiaGoc, @TongTienTra, @PhiTra, @TienTraKhach,
                             @NgayLap, @GhiChu,@TrangThaiPhieuTra,@MaKH)";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", phieu.MaPhieuTraHang);
                cmd.Parameters.AddWithValue("@MaNV", (object)phieu.MaNhanVien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaHoaDon", (object)phieu.MaHoaDon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaHTTT", (object)phieu.MaHinhThucThanhToan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaBangGia", (object)phieu.MaBangGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TongGiaGoc", phieu.TongGiaGocHangMua);
                cmd.Parameters.AddWithValue("@TongTienTra", phieu.TongTienTraHang);
                cmd.Parameters.AddWithValue("@PhiTra", phieu.PhiTraHang);
                cmd.Parameters.AddWithValue("@TienTraKhach", phieu.TienTraKhach);
                cmd.Parameters.AddWithValue("@NgayLap", phieu.NgayLapPhieuTra);
                cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChuPhieuTra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThaiPhieuTra", phieu.TrangThaiPhieuTra ?? "Chưa thanh toán");
                cmd.Parameters.AddWithValue("@MaKH", (object)phieu.MaKhachHang ?? DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Sửa phiếu trả hàng
        /// </summary>
        public bool SuaPhieuTraHang(ClassPhieuTraHang phieu)
        {
            string query = @"UPDATE PHIEU_TRA_HANG_HD SET
                                MA_NV = @MaNV,
                                MA_HOA_DON = @MaHoaDon,
                                MA_HINH_THUC_THANH_TOAN = @MaHTTT,
                                MA_BANG_GIA = @MaBangGia,
                                TONG_GIA_GOC_HANG_MUA = @TongGiaGoc,
                                TONG_TIEN_TRA_HANG = @TongTienTra,
                                PHI_TRA_HANG = @PhiTra,
                                TIEN_TRA_KHACH = @TienTraKhach,
                                NGAY_LAP_PHIEU_TRA = @NgayLap,
                                GHI_CHU_PHIEU_TRA = @GhiChu,
                                TRANG_THAI_PHIEU_TRA = @TrangThaiPhieuTra,
                                MA_KH = @MaKH
                              WHERE MA_PHIEU_TRA_HANG = @MaPhieuTraHang";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", phieu.MaPhieuTraHang);
                cmd.Parameters.AddWithValue("@MaNV", (object)phieu.MaNhanVien ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaHoaDon", (object)phieu.MaHoaDon ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaHTTT", (object)phieu.MaHinhThucThanhToan ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@MaBangGia", (object)phieu.MaBangGia ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TongGiaGoc", phieu.TongGiaGocHangMua);
                cmd.Parameters.AddWithValue("@TongTienTra", phieu.TongTienTraHang);
                cmd.Parameters.AddWithValue("@PhiTra", phieu.PhiTraHang);
                cmd.Parameters.AddWithValue("@TienTraKhach", phieu.TienTraKhach);
                cmd.Parameters.AddWithValue("@NgayLap", phieu.NgayLapPhieuTra);
                cmd.Parameters.AddWithValue("@GhiChu", (object)phieu.GhiChuPhieuTra ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@TrangThaiPhieuTra", phieu.TrangThaiPhieuTra ?? "Chưa thanh toán");
                cmd.Parameters.AddWithValue("@MaKH", (object)phieu.MaKhachHang ?? DBNull.Value);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        /// <summary>
        /// Xóa phiếu trả hàng
        /// </summary>
        public bool XoaPhieuTraHang(ClassPhieuTraHang phieu)
        {
            string query = @"DELETE FROM PHIEU_TRA_HANG_HD 
                             WHERE MA_PHIEU_TRA_HANG = @MaPhieuTraHang";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaPhieuTraHang", phieu.MaPhieuTraHang);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
