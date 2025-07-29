using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient; // Sử dụng Microsoft.Data.SqlClient thay vì System.Data.SqlClient
namespace QL_Nha_thuoc.model
{
    public class ClassGiaBanHH
    {
        public string MaGiaHH { get; set; }
        public string MaHangHoa { get; set; }
        public string MaBangGia { get; set; }
        public decimal GiaVon { get; set; }
        public decimal GiaBan { get; set; }

        public bool LaPhanTram { get; set; }  // <-- kiểu bool
        public bool TangGiam { get; set; }    // <-- kiểu bool
        public decimal GiaTriTangGiam { get; set; } // Tỷ lệ lợi nhuận, có thể là phần trăm hoặc giá trị tuyệt đối

        public string TenHangHoa { get; set; }
        public string TenDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }

        // Constructor đầy đủ
        public ClassGiaBanHH(string maGiaHH, string maHH, string maBangGia, string maDVT,
                             decimal giaVon, decimal giaBan, bool laPhanTram,
                             bool tangGiam, decimal giaTriTangGiam,
                             string tenHH, string tenDVT, DateTime tuNgay, DateTime denNgay)
        {
            MaGiaHH = maGiaHH;
            MaHangHoa = maHH;
            MaBangGia = maBangGia;
            MaDonViTinh = maDVT;
            GiaVon = giaVon;
            GiaBan = giaBan;
            LaPhanTram = laPhanTram;
            TangGiam = tangGiam;
            GiaTriTangGiam = giaTriTangGiam;
            TenHangHoa = tenHH;
            TenDonViTinh = tenDVT;
        }

        // Constructor rút gọn (nếu cần tạo nhanh chỉ với thông tin chính)
        public ClassGiaBanHH(string maHH, string maDVT, decimal giaVon, decimal giaBan, decimal giaTriTangGiam)
        {
            MaHangHoa = maHH;
            MaDonViTinh = maDVT;
            GiaVon = giaVon;
            GiaBan = giaBan;
            GiaTriTangGiam = giaTriTangGiam;
        }

        public ClassGiaBanHH() { } // Constructor rỗng
        /// Lấy danh sách giá bán hàng hóa từ CSDL

        //ham lay toan bo danh sach gia ban hang hoa
        public static List<ClassGiaBanHH> LayDanhSachToanboGiaBan()
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT GHH.MA_HANG_HOA, GHH.MA_DON_VI_TINH, GHH.GIA_VON_HH, GHH.GIA_BAN_HH, HH.TEN_HANG_HOA,DVT.TEN_DON_VI_TINH " +
                               "FROM GIA_HANG_HOA GHH " +
                               "JOIN HANG_HOA HH ON HH.MA_HANG_HOA = GHH.MA_HANG_HOA " +
                               "JOIN DON_VI_TINH DVT ON DVT.MA_DON_VI_TINH = GHH.MA_DON_VI_TINH"+
                               " WHERE HH.MA_HANG_HOA NOT LIKE '%_DELETED' AND MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var gia = new ClassGiaBanHH
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                            TenDonViTinh = reader[ "TEN_DON_VI_TINH" ].ToString(),
                            GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                            GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"]),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString()
                        };
                        danhSach.Add(gia);
                    }
                }
            }

            return danhSach;
        }


        //lay 1
        public static ClassGiaBanHH LayGiaBanTheoMavamaDVT(string maHangHoa,string maDVT)
        {
            if (string.IsNullOrEmpty(maHangHoa))
                return null;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH FROM GIA_HANG_HOA WHERE MA_HANG_HOA = @maHH and MA_DON_VI_TINH = @maDVT AND MA_HANG_HOA NOT LIKE '%_DELETED' AND MA_GIA_HH NOT LIKE '%_DELETED' ";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHangHoa);
                cmd.Parameters.AddWithValue("@maDVT", maDVT);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new ClassGiaBanHH
                    {
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                        GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                        GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"])
                    };
                }
            }

            return null;
        }


        public static List<ClassGiaBanHH> LayDanhSachGiaBan(string maHangHoa = null)
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH FROM GIA_HANG_HOA AND MA_HANG_HOA NOT LIKE '%_DELETED' AND MA_GIA_HH NOT LIKE '%_DELETED' ";

                if (!string.IsNullOrEmpty(maHangHoa))
                    query += " WHERE MA_HANG_HOA = @maHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (!string.IsNullOrEmpty(maHangHoa))
                    cmd.Parameters.AddWithValue("@maHH", maHangHoa);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var gia = new ClassGiaBanHH
                    {
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                        GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                        GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"])
                    };
                    danhSach.Add(gia);
                }
            }

            return danhSach;
        }

        //lay theo manhom hang hoa
        public static List<ClassGiaBanHH> LayDanhSachGiaBanTheoMaNhom_BangGia(string maNhomHangHoa, string maBangGia)
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            SELECT GHH.MA_HANG_HOA, GHH.MA_DON_VI_TINH, GHH.GIA_VON_HH, GHH.GIA_BAN_HH, HH.TEN_HANG_HOA
            FROM GIA_HANG_HOA GHH 
            JOIN HANG_HOA HH ON HH.MA_HANG_HOA = GHH.MA_HANG_HOA 
            WHERE HH.MA_NHOM_HH = @maNhomHangHoa
              AND GHH.MA_BANG_GIA = @maBangGia
              AND GHH.MA_HANG_HOA NOT LIKE '%_DELETED'
              AND GHH.MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maNhomHangHoa", maNhomHangHoa);
                    cmd.Parameters.AddWithValue("@maBangGia", maBangGia);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var gia = new ClassGiaBanHH
                            {
                                MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                                GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"]),
                                TenHangHoa = reader["TEN_HANG_HOA"].ToString()
                            };
                            danhSach.Add(gia);
                        }
                    }
                }
            }

            return danhSach;
        }


        public static List<ClassGiaBanHH> LayDanhSachGiaBanTheoBangGia(string maBangGia)
        {
            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT GHH.MA_HANG_HOA, GHH.MA_DON_VI_TINH, GHH.GIA_VON_HH, GHH.GIA_BAN_HH, HH.TEN_HANG_HOA
            FROM GIA_HANG_HOA GHH 
            JOIN HANG_HOA HH ON HH.MA_HANG_HOA = GHH.MA_HANG_HOA 
            WHERE GHH.MA_BANG_GIA = @maBangGia
              AND GHH.MA_HANG_HOA NOT LIKE '%_DELETED'
              AND GHH.MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maBangGia", maBangGia);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var gia = new ClassGiaBanHH
                            {
                                MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                GiaVon = Convert.ToDecimal(reader["GIA_VON_HH"]),
                                GiaBan = Convert.ToDecimal(reader["GIA_BAN_HH"]),
                                TenHangHoa = reader["TEN_HANG_HOA"].ToString()
                            };
                            danhSach.Add(gia);
                        }
                    }
                }
            }
            return danhSach;
        }



        //ham loc theo gia 
        public static List<ClassGiaBanHH> LocGiaBanTheoKhoangGia(List<ClassGiaBanHH> danhSach, string loc, string loaiGia)
        {
            return danhSach.Where(item =>
            {
                decimal giaBan = item.GiaBan;
                decimal giaSoSanh = loaiGia == "Gia von" ? item.GiaVon : 0;

                return loc switch
                {
                    "<" => giaBan < giaSoSanh,
                    ">" => giaBan > giaSoSanh,
                    "=" => giaBan == giaSoSanh,
                    "<=" => giaBan <= giaSoSanh,
                    ">=" => giaBan >= giaSoSanh,
                    _ => true
                };
            }).ToList();
        }



        public static string TaoMaGiaBanTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
        SELECT TOP 1 MA_GIA_HH
        FROM GIA_HANG_HOA
        WHERE MA_GIA_HH LIKE 'GB%' AND MA_GIA_HH NOT LIKE '%_DELETED'
        ORDER BY 
            TRY_CAST(SUBSTRING(MA_GIA_HH, 3, LEN(MA_GIA_HH)) AS INT) DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();
                int soThuTu = 1;

                if (result != null)
                {
                    string maCu = result.ToString(); // VD: GB0015
                    if (maCu.Length > 2 && int.TryParse(maCu.Substring(2), out int so))
                    {
                        soThuTu = so + 1;
                    }
                }

                return "GB" + soThuTu.ToString("D5"); // VD: GB0016
            }
        }


        /// <summary>
        /// Thêm giá bán mới cho hàng hóa
        /// </summary>
        public static bool ThemGiaBan(ClassGiaBanHH giaBan, SqlConnection conn, SqlTransaction tran)
        {
            string query = @"
        INSERT INTO GIA_HANG_HOA 
        (MA_GIA_HH, MA_BANG_GIA, MA_HANG_HOA, GIA_BAN_HH, GIA_VON_HH, MA_DON_VI_TINH, LA_PHAN_TRAM, TANG_GIAM, GIA_TRI_TANG_GIAM)
        VALUES 
        (@maGiaHH, @maBangGia, @mahh, @giaban, @giavon, @madvt, @laphantram, @tanggiam, @giatri)";

            using (SqlCommand cmd = new SqlCommand(query, conn, tran))
            {
                cmd.Parameters.AddWithValue("@maGiaHH", TaoMaGiaBanTuDong());
                cmd.Parameters.AddWithValue("@maBangGia", giaBan.MaBangGia ?? "BG001");
                cmd.Parameters.AddWithValue("@mahh", giaBan.MaHangHoa);
                cmd.Parameters.AddWithValue("@giaban", giaBan.GiaBan);
                cmd.Parameters.AddWithValue("@giavon", giaBan.GiaVon);
                cmd.Parameters.AddWithValue("@madvt", giaBan.MaDonViTinh);
                cmd.Parameters.AddWithValue("@laphantram", giaBan.LaPhanTram);
                cmd.Parameters.AddWithValue("@tanggiam", giaBan.TangGiam);
                cmd.Parameters.AddWithValue("@giatri", giaBan.GiaTriTangGiam);

                return cmd.ExecuteNonQuery() > 0;
            }
        }






        /// <summary>
        /// Cập nhật giá bán cho hàng hóa (theo mã hàng và đơn vị tính)
        /// </summary>
        public static bool CapNhatGiaBan(ClassGiaBanHH gia)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            UPDATE GIA_HANG_HOA 
            SET 
                GIA_VON_HH = @giaVon, 
                GIA_BAN_HH = @giaBan, 
                LA_PHAN_TRAM = @laPhanTram,
                TANG_GIAM = @tangGiam,
                GIA_TRI_TANG_GIAM = @giaTriTangGiam
            WHERE 
                MA_HANG_HOA = @maHH 
                AND MA_DON_VI_TINH = @maDVT AND MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHH", gia.MaHangHoa);
                    cmd.Parameters.AddWithValue("@maDVT", gia.MaDonViTinh);
                    cmd.Parameters.AddWithValue("@giaVon", gia.GiaVon);
                    cmd.Parameters.AddWithValue("@giaBan", gia.GiaBan);
                    cmd.Parameters.AddWithValue("@laPhanTram", gia.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tangGiam", gia.TangGiam);
                    cmd.Parameters.AddWithValue("@giaTriTangGiam", gia.GiaTriTangGiam);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public static bool XoaGiaBanTheoMaHangHoaVaDVT(string maHH, string maDVT)
        {
            if (string.IsNullOrEmpty(maHH) || string.IsNullOrEmpty(maDVT))
                return false;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE GIA_HANG_HOA
            SET MA_GIA_HH = MA_GIA_HH + '_DELETED'
            WHERE MA_HANG_HOA = @maHH AND MA_DON_VI_TINH = @maDVT 
              AND MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHH", maHH);
                    cmd.Parameters.AddWithValue("@maDVT", maDVT);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public static bool XoaGiaBanTheoMaHangHoa(string maHH)
        {
            if (string.IsNullOrEmpty(maHH))
                return false;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();

                string query = @"
            UPDATE GIA_HANG_HOA
            SET MA_GIA_HH = MA_GIA_HH + '_DELETED'
            WHERE MA_HANG_HOA = @maHH 
              AND MA_GIA_HH NOT LIKE '%_DELETED'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maHH", maHH);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }



        //lay danh sach don vi tinh cua ma hang hoa
        public static List<ClassDonViTinh> LayDanhSachDonViTinhTheoMaHangHoa(string maHangHoa)
        {
            List<ClassDonViTinh> danhSachMaDonViTinh = new List<ClassDonViTinh>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string sql = @"
            SELECT DISTINCT GHH.MA_DON_VI_TINH, DVT.TEN_DON_VI_TINH
            FROM GIA_HANG_HOA GHH
            JOIN DON_VI_TINH DVT ON GHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            WHERE  MA_GIA_HH NOT LIKE '%_DELETED' AND GHH.MA_HANG_HOA = @maHangHoa ";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@maHangHoa", maHangHoa);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClassDonViTinh dvt = new ClassDonViTinh
                            {
                                MaDonViTinh = reader["MA_DON_VI_TINH"].ToString(),
                                TenDonViTinh = reader["TEN_DON_VI_TINH"].ToString()
                            };
                            danhSachMaDonViTinh.Add(dvt);
                        }
                    }
                }
            }

            return danhSachMaDonViTinh;
        }




    }
}

