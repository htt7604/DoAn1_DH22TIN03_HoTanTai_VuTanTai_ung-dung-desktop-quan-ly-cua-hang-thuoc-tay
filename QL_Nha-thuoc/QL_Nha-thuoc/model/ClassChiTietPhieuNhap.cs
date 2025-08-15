using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    // Đại diện chi tiết hàng hóa trong phiếu nhập
    public class ClassChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaHangHoa { get; set; }
        public string MaDonViTinh { get; set; }
        public string TenHangHoa { get; set; }
        public string TenDonViTinh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ClassChiTietPhieuNhap() { }

        public ClassChiTietPhieuNhap(string maPhieu, string maHH, string maDVT, string tenHH, string tenDVT, int soLuong, decimal donGia, decimal giamGia, decimal thanhTien)
        {
            MaPhieuNhap = maPhieu;
            MaHangHoa = maHH;
            MaDonViTinh = maDVT;
            TenHangHoa = tenHH;
            TenDonViTinh = tenDVT;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
        }

        // Lấy danh sách chi tiết phiếu nhập
        public static List<ClassChiTietPhieuNhap> LayDanhSachChiTietPhieuNhap(string maPhieu)
        {
            List<ClassChiTietPhieuNhap> danhSach = new List<ClassChiTietPhieuNhap>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT 
                        CT.MA_PHIEU_NHAP, 
                        CT.MA_HANG_HOA, 
                        CT.MA_DON_VI_TINH,
                        HH.TEN_HANG_HOA, 
                        DVT.TEN_DON_VI_TINH,
                        CT.SO_LUONG_HH, 
                        CT.DON_GIA, 
                        CT.GIAM_GIA, 
                        CT.THANH_TIEN
                    FROM CHI_TIET_PHIEU_NHAP CT
                    LEFT JOIN HANG_HOA HH ON CT.MA_HANG_HOA = HH.MA_HANG_HOA
                    LEFT JOIN DON_VI_TINH DVT ON CT.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
                    WHERE CT.MA_PHIEU_NHAP = @maPhieu";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhieu", maPhieu);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            danhSach.Add(new ClassChiTietPhieuNhap
                            {
                                MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                                MaHangHoa = reader["MA_HANG_HOA"]?.ToString(),
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                TenHangHoa = reader["TEN_HANG_HOA"]?.ToString(),
                                TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                                SoLuong = reader["SO_LUONG_HH"] != DBNull.Value ? Convert.ToInt32(reader["SO_LUONG_HH"]) : 0,
                                DonGia = reader["DON_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["DON_GIA"]) : 0,
                                GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : 0,
                                ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : 0
                            });
                        }
                    }
                }
            }

            return danhSach;
        }
        public static ClassChiTietPhieuNhap LayChiTietPhieuNhaptheomaHH_DVT_maPhieu(string maPhieu, string maHangHoa, string maDonViTinh)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT 
                CT.MA_PHIEU_NHAP, 
                CT.MA_HANG_HOA, 
                CT.MA_DON_VI_TINH,
                HH.TEN_HANG_HOA, 
                DVT.TEN_DON_VI_TINH,
                CT.SO_LUONG_HH, 
                CT.DON_GIA, 
                CT.GIAM_GIA, 
                CT.THANH_TIEN
            FROM CHI_TIET_PHIEU_NHAP CT
            LEFT JOIN HANG_HOA HH ON CT.MA_HANG_HOA = HH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON CT.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            WHERE CT.MA_PHIEU_NHAP = @maPhieu 
              AND CT.MA_HANG_HOA = @maHangHoa
              AND CT.MA_DON_VI_TINH = @maDonViTinh";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maPhieu", maPhieu);
                    cmd.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    cmd.Parameters.AddWithValue("@maDonViTinh", maDonViTinh);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassChiTietPhieuNhap
                            {
                                MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                                MaHangHoa = reader["MA_HANG_HOA"]?.ToString(),
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                TenHangHoa = reader["TEN_HANG_HOA"]?.ToString(),
                                TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                                SoLuong = reader["SO_LUONG_HH"] != DBNull.Value ? Convert.ToInt32(reader["SO_LUONG_HH"]) : 0,
                                DonGia = reader["DON_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["DON_GIA"]) : 0,
                                GiamGia = reader["GIAM_GIA"] != DBNull.Value ? Convert.ToDecimal(reader["GIAM_GIA"]) : 0,
                                ThanhTien = reader["THANH_TIEN"] != DBNull.Value ? Convert.ToDecimal(reader["THANH_TIEN"]) : 0
                            };
                        }
                    }
                }
            }
            return null;
        }



        // Thêm chi tiết phiếu nhập
        public static bool ThemChiTietPhieuNhap(ClassChiTietPhieuNhap ct)
        {
            string query = @"
        INSERT INTO CHI_TIET_PHIEU_NHAP
        (MA_PHIEU_NHAP, MA_HANG_HOA, MA_DON_VI_TINH,TEN_HANG_HOA, SO_LUONG_HH, DON_GIA, GIAM_GIA, THANH_TIEN)
        VALUES
        (@MaPhieu, @MaHH, @MaDVT,@TenHangHoa, @SoLuong, @DonGia, @GiamGia, @ThanhTien)";

            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@MaPhieu", System.Data.SqlDbType.VarChar, 50).Value = ct.MaPhieuNhap;
                cmd.Parameters.Add("@MaHH", System.Data.SqlDbType.VarChar, 50).Value = ct.MaHangHoa;
                cmd.Parameters.Add("@MaDVT", System.Data.SqlDbType.VarChar).Value = (object)ct.MaDonViTinh;
                cmd.Parameters.Add("@TenHangHoa", System.Data.SqlDbType.NVarChar, 100).Value = ct.TenHangHoa ?? (object)DBNull.Value;
                cmd.Parameters.Add("@SoLuong", System.Data.SqlDbType.Int).Value = ct.SoLuong;
                cmd.Parameters.Add("@DonGia", System.Data.SqlDbType.Decimal).Value = ct.DonGia;
                cmd.Parameters.Add("@GiamGia", System.Data.SqlDbType.Decimal).Value = ct.GiamGia;
                cmd.Parameters.Add("@ThanhTien", System.Data.SqlDbType.Decimal).Value = ct.ThanhTien;

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // ClassChiTietPhieuNhap
        public static void XoaChiTietPhieuNhap(string maPhieuNhap)
        {
            string query = "DELETE FROM CHI_TIET_PHIEU_NHAP WHERE MA_PHIEU_NHAP = @ma";
            using (SqlConnection conn = CSDL.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ma", maPhieuNhap);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



    }
}
