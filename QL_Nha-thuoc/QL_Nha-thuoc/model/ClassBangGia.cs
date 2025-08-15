using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassBangGia
    {
        public string MaBangGia { get; set; }
        public string TenBangGia { get; set; } 

        public DateTime TuNgay { get; set; }
        public DateTime DenNgay { get; set; }
        public string TrangThai { get; set; }
        public bool ChoChonNgoaiBangGia { get; set; }

        public bool LaPhanTram { get; set; }
        public bool TangGiam { get; set; }
        public decimal GiaTriTangGiam { get; set; }
        public bool DungGiaVon { get; set; }

        public static List<ClassBangGia> LayTatCaBangGia()
        {
            List<ClassBangGia> list = new List<ClassBangGia>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM BANG_GIA_HH WHERE TRANG_THAI != N'Đã xóa'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ClassBangGia
                        {
                            MaBangGia = reader["MA_BANG_GIA"].ToString(),
                            TenBangGia = reader["TEN_BANG_GIA"].ToString(),

                            TuNgay = reader["TU_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["TU_NGAY"]) : DateTime.MinValue,
                            DenNgay = reader["DEN_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["DEN_NGAY"]) : DateTime.MaxValue,
                            TrangThai = reader["TRANG_THAI"].ToString(),

                            ChoChonNgoaiBangGia = reader["CHO_CHON_NGOAI_BANG_GIA"] != DBNull.Value && Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                            LaPhanTram = reader["LA_PHAN_TRAM"] != DBNull.Value && Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                            TangGiam = reader["TANG_GIAM"] != DBNull.Value && Convert.ToBoolean(reader["TANG_GIAM"]),
                            GiaTriTangGiam = reader["GIA_TRI_TANG_GIAM"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]) : 0,
                            DungGiaVon = reader["DUNG_GIA_VON"] != DBNull.Value && Convert.ToBoolean(reader["DUNG_GIA_VON"])
                        });
                    }
                }
            }
            return list;
        }

        public static List<ClassBangGia> LayTatCaBangGiaDangApDung()
        {
            List<ClassBangGia> list = new List<ClassBangGia>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT * 
            FROM BANG_GIA_HH 
            WHERE TRANG_THAI != N'Đã xóa' 
              AND TRANG_THAI = N'Đang áp dụng'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    DateTime now = DateTime.Now;
                    while (reader.Read())
                    {
                        DateTime tuNgay = reader["TU_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["TU_NGAY"]) : DateTime.MinValue;
                        DateTime denNgay = reader["DEN_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["DEN_NGAY"]) : DateTime.MaxValue;

                        // Chỉ thêm nếu thời gian hiện tại nằm trong khoảng TU_NGAY - DEN_NGAY
                        if (now >= tuNgay && now <= denNgay)
                        {
                            list.Add(new ClassBangGia
                            {
                                MaBangGia = reader["MA_BANG_GIA"].ToString(),
                                TenBangGia = reader["TEN_BANG_GIA"].ToString(),
                                TuNgay = tuNgay,
                                DenNgay = denNgay,
                                TrangThai = reader["TRANG_THAI"].ToString(),
                                ChoChonNgoaiBangGia = reader["CHO_CHON_NGOAI_BANG_GIA"] != DBNull.Value && Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                                LaPhanTram = reader["LA_PHAN_TRAM"] != DBNull.Value && Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                                TangGiam = reader["TANG_GIAM"] != DBNull.Value && Convert.ToBoolean(reader["TANG_GIAM"]),
                                GiaTriTangGiam = reader["GIA_TRI_TANG_GIAM"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]) : 0,
                                DungGiaVon = reader["DUNG_GIA_VON"] != DBNull.Value && Convert.ToBoolean(reader["DUNG_GIA_VON"])
                            });
                        }
                    }
                }
            }
            return list;
        }






        public static string TaoMaBangGiaTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT MAX(MA_BANG_GIA) FROM BANG_GIA_HH WHERE MA_BANG_GIA LIKE 'BG%'";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        string maxMa = result.ToString(); // Ví dụ: BG0021
                        int so = int.Parse(maxMa.Substring(2)); // Lấy phần số sau "BG"
                        return "BG" + (so + 1).ToString("D3"); // Tăng lên và format 4 chữ số
                    }
                    else
                    {
                        return "BG001"; // Nếu chưa có mã nào
                    }
                }
            }
        }




        public static bool ThemBangGia(ClassBangGia bg)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                INSERT INTO BANG_GIA_HH 
                (MA_BANG_GIA,TEN_BANG_GIA, TU_NGAY, DEN_NGAY, TRANG_THAI, CHO_CHON_NGOAI_BANG_GIA, LA_PHAN_TRAM, TANG_GIAM, GIA_TRI_TANG_GIAM, DUNG_GIA_VON)
                VALUES (@ma,@tenbanggia, @tu, @den, @trangthai, @chonngoai, @phantram, @tanggiam, @giatri, @dunggiavon)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", ClassBangGia.TaoMaBangGiaTuDong());
                    cmd.Parameters.AddWithValue("@tenbanggia", bg.TenBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@dunggiavon", bg.DungGiaVon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static bool SuaBangGia(ClassBangGia bg)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                UPDATE BANG_GIA_HH 
                SET TEN_BANG_GIA=@tenbanggia, TU_NGAY = @tu, DEN_NGAY = @den, TRANG_THAI = @trangthai, 
                    CHO_CHON_NGOAI_BANG_GIA = @chonngoai,
                    LA_PHAN_TRAM = @phantram, TANG_GIAM = @tanggiam, 
                    GIA_TRI_TANG_GIAM = @giatri, DUNG_GIA_VON = @dunggiavon
                WHERE MA_BANG_GIA = @ma";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", bg.MaBangGia);
                    cmd.Parameters.AddWithValue("@tenbanggia", bg.TenBangGia);
                    cmd.Parameters.AddWithValue("@tu", bg.TuNgay);
                    cmd.Parameters.AddWithValue("@den", bg.DenNgay);
                    cmd.Parameters.AddWithValue("@trangthai", bg.TrangThai);
                    cmd.Parameters.AddWithValue("@chonngoai", bg.ChoChonNgoaiBangGia);
                    cmd.Parameters.AddWithValue("@phantram", bg.LaPhanTram);
                    cmd.Parameters.AddWithValue("@tanggiam", bg.TangGiam);
                    cmd.Parameters.AddWithValue("@giatri", bg.GiaTriTangGiam);
                    cmd.Parameters.AddWithValue("@dunggiavon", bg.DungGiaVon);

                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


        public static bool CapNhatGiaBanHangHoaTheoBangGia(string maBangGia)
        {
            try
            {
                // 1. Lấy danh sách tất cả chi tiết bảng giá (ClassGiaBanHH) theo mã bảng giá
                var danhSachChiTiet = ClassGiaBanHH.LayDanhSachGiaBanTheoBangGia(maBangGia);

                // 2. Lặp qua từng chi tiết, tính lại giá bán mới dựa trên bảng giá vừa sửa
                foreach (var chiTiet in danhSachChiTiet)
                {
                    // Lấy thông tin hàng hóa (để lấy giá gốc)
                    var hangHoa = ClassHangHoa.LayThongTinMotHangHoa(chiTiet.MaHangHoa);
                    if (hangHoa == null) continue;

                    // Tính lại giá bán theo bảng giá hiện tại (hàm bạn đã có)
                    decimal giaBanMoi = ClassBangGia.TinhGiaBanTheoMaBangGia(maBangGia, hangHoa.GiaBan);

                    // Cập nhật giá bán mới vào chi tiết bảng giá
                    chiTiet.GiaBan = giaBanMoi;

                    // Ghi lại vào database
                    ClassGiaBanHH.CapNhatGiaBan(chiTiet);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool XoaBangGia(string maBangGia)
        {
            ClassGiaBanHH.XoaGiaBanHHTheoMaBangGia(maBangGia);
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM BANG_GIA_HH WHERE MA_BANG_GIA = @ma";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maBangGia);
                    int rows = cmd.ExecuteNonQuery();
                    return rows > 0;
                }
            }
        }

        public static ClassBangGia LayBangGiaTheoMa(string maBangGia)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM BANG_GIA_HH WHERE MA_BANG_GIA = @ma";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ma", maBangGia);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ClassBangGia
                            {
                                MaBangGia = maBangGia,
                                TenBangGia = reader["TEN_BANG_GIA"]?.ToString(),
                                TuNgay = reader["TU_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["TU_NGAY"]) : DateTime.MinValue,
                                DenNgay = reader["DEN_NGAY"] != DBNull.Value ? Convert.ToDateTime(reader["DEN_NGAY"]) : DateTime.MaxValue,
                                TrangThai = reader["TRANG_THAI"]?.ToString(),
                                ChoChonNgoaiBangGia = reader["CHO_CHON_NGOAI_BANG_GIA"] != DBNull.Value && Convert.ToBoolean(reader["CHO_CHON_NGOAI_BANG_GIA"]),
                                LaPhanTram = reader["LA_PHAN_TRAM"] != DBNull.Value && Convert.ToBoolean(reader["LA_PHAN_TRAM"]),
                                TangGiam = reader["TANG_GIAM"] != DBNull.Value && Convert.ToBoolean(reader["TANG_GIAM"]),
                                GiaTriTangGiam = reader["GIA_TRI_TANG_GIAM"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_TRI_TANG_GIAM"]) : 0,
                                DungGiaVon = reader["DUNG_GIA_VON"] != DBNull.Value && Convert.ToBoolean(reader["DUNG_GIA_VON"])
                            };
                        }
                    }
                }
            }
            return null;
        }




        /// <summary>
        /// </summary>
        /// <param name="maBangGia"></param>
        /// <param name="giaBanGoc"></param>
        /// <returns></returns>
        public static decimal TinhGiaBanTheoMaBangGia(string maBangGia, decimal giaBanGoc)
        {
            // Lấy thông tin bảng giá theo mã
            ClassBangGia bangGia = LayBangGiaTheoMa(maBangGia);
            if (bangGia == null)
            {
                // Nếu không tìm thấy bảng giá thì trả về giá gốc luôn
                return giaBanGoc;
            }

            decimal giaBanTinh = giaBanGoc;

            // Tính giá bán theo thông tin bảng giá
            if (bangGia.TangGiam)
            {
                if (bangGia.LaPhanTram)
                {
                    giaBanTinh = giaBanGoc + (giaBanGoc * bangGia.GiaTriTangGiam / 100m);
                }
                else
                {
                    giaBanTinh = giaBanGoc + bangGia.GiaTriTangGiam;
                }
            }
            else
            {
                if (bangGia.LaPhanTram)
                {
                    giaBanTinh = giaBanGoc - (giaBanGoc * bangGia.GiaTriTangGiam / 100m);
                }
                else
                {
                    giaBanTinh = giaBanGoc - bangGia.GiaTriTangGiam;
                }
            }

            if (giaBanTinh < 0) giaBanTinh = 0;

            return giaBanTinh;
        }








    }
}
