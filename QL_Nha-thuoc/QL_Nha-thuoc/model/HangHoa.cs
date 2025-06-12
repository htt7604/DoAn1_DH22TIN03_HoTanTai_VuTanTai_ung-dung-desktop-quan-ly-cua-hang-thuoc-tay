using Microsoft.Data.SqlClient;
using System;

namespace QL_Nha_thuoc.model
{
    public class DBHelperHH
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }

    public class HangHoa
    {
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public string DonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public int SoLuongTon { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public string NhaCungCap { get; set; }
        public string MaNhaCungCap { get; set; }
        public string NoiSanXuat { get; set; }
        public DateTime? HanSuDung { get; set; }
        public string MaLoaiHangHoa { get; set; }
        public string TenLoaiHangHoa { get; set; }
        public string MaLo { get; set; }
        public string MaVach { get; set; }
        public string GhiChu { get; set; }
        public string HinhAnh { get; set; }

        // Constructor đầy đủ
        public HangHoa(string maHangHoa, string tenHangHoa, string donViTinh, int soLuongTon, decimal giaNhap, decimal giaBan,
                          string nhaCungCap, string noiSanXuat, DateTime? hanSuDung, string maLoai, string tenLoai, string maLo,
                          string maVach, string ghiChu, string hinhAnh)
        {
            MaHangHoa = maHangHoa;
            TenHangHoa = tenHangHoa;
            DonViTinh = donViTinh;
            SoLuongTon = soLuongTon;
            GiaNhap = giaNhap;
            GiaBan = giaBan;
            NhaCungCap = nhaCungCap;
            NoiSanXuat = noiSanXuat;
            HanSuDung = hanSuDung;
            MaLoaiHangHoa = maLoai;
            TenLoaiHangHoa = tenLoai;
            MaLo = maLo;
            MaVach = maVach;
            GhiChu = ghiChu;
            HinhAnh = hinhAnh;
        }

        // Constructor rỗng
        public HangHoa() { }

         public static List<HangHoa> LayThongTinHH(string maHH)
         {
            var danhSach = new List<HangHoa>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                string query = @"
                SELECT 
                HH.MA_HANG_HOA,
                HH.TEN_HANG_HOA,
                DVT.MA_DON_VI_TINH,
                DVT.TEN_DON_VI_TINH,
                HH.TON_KHO,
                GBHH.GIA_VON_HH,
                GBHH.GIA_BAN_HH,
                NCC.MA_NHA_CUNG_CAP,
                NCC.TEN_NHA_CUNG_CAP,
                HH.NGAY_HET_HAN_HH,
                LHH.MA_LOAI_HH,
                LHH.TEN_LOAI_HH,
                HH.MA_VACH,
                HH.GHI_CHU_HH,
                HH.HINH_ANH_HH
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
			 LEFT JOIN PHIEU_NHAP_HANG PNH on HH.MA_HANG_HOA=PNH.MA_HANG_HOA
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP=NCC.MA_NHA_CUNG_CAP
			left join NHOM_HANG NH on HH.MA_NHOM_HH=NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            WHERE HH.MA_HANG_HOA = @maHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", "%" + maHH + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var hh = new HangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaNhap = reader["GIA_NHAP"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_NHAP"]) :0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            MaNhaCungCap = reader["MA_NCC"]?.ToString(),
                            NhaCungCap = reader["TEN_NCC"]?.ToString(),
                            NoiSanXuat = reader["NOI_SAN_XUAT"]?.ToString(),
                            HanSuDung = reader["HAN_SU_DUNG"] != DBNull.Value ? Convert.ToDateTime(reader["HAN_SU_DUNG"]) : (DateTime?)null,
                            MaLoaiHangHoa = reader["MA_LOAI_HANG_HOA"]?.ToString(),
                            TenLoaiHangHoa = reader["TEN_LOAI_HANG_HOA"]?.ToString(),
                            MaLo = reader["MA_LO"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString()
                        };

                        danhSach.Add(hh);
                    }
                }
            }

            return danhSach;
        }




        public static HangHoa LayThongTinMotHangHoa(string maHH)
        {
            HangHoa hh = null;

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                string query = @"
                           SELECT 
                HH.MA_HANG_HOA,
                HH.TEN_HANG_HOA,
                DVT.MA_DON_VI_TINH,
                DVT.TEN_DON_VI_TINH,
                HH.TON_KHO,
                GBHH.GIA_VON_HH,
                GBHH.GIA_BAN_HH,
                NCC.MA_NHA_CUNG_CAP,
                NCC.TEN_NHA_CUNG_CAP,
                HH.NGAY_HET_HAN_HH,
                LHH.MA_LOAI_HH,
                LHH.TEN_LOAI_HH,
                HH.MA_VACH,
                HH.GHI_CHU_HH,
                HH.HINH_ANH_HH
            FROM HANG_HOA HH
            LEFT JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GBHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
			 LEFT JOIN PHIEU_NHAP_HANG PNH on HH.MA_HANG_HOA=PNH.MA_HANG_HOA
            LEFT JOIN NHA_CUNG_CAP NCC ON PNH.MA_NHA_CUNG_CAP=NCC.MA_NHA_CUNG_CAP
			left join NHOM_HANG NH on HH.MA_NHOM_HH=NH.MA_NHOM_HH
            LEFT JOIN LOAI_HANG LHH ON NH.MA_LOAI_HH = LHH.MA_LOAI_HH
            WHERE HH.MA_HANG_HOA = @maHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHH);
                //cmd.Parameters.AddWithValue("@ten", "%" + keyword + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        hh = new HangHoa
                        {
                            MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                            TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                            DonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            SoLuongTon = reader["TON_KHO"] != DBNull.Value ? Convert.ToInt32(reader["TON_KHO"]) : 0,
                            GiaNhap = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            NhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString()
                        };
                    }
                }
            }

            return hh;
        }


        //ham tao ma hang hoa tu dong
        public static string TaoMaHangHoaTuDong()
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                string query = @"
            SELECT TOP 1 MA_HANG_HOA
            FROM HANG_HOA
            WHERE MA_HANG_HOA LIKE 'HH%'
            ORDER BY 
                TRY_CAST(SUBSTRING(MA_HANG_HOA, 3, LEN(MA_HANG_HOA)) AS INT) DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                object result = cmd.ExecuteScalar();

                int soThuTu = 1; // Mặc định nếu chưa có mã nào

                if (result != null)
                {
                    string maCu = result.ToString(); // VD: "HH0025"
                    if (maCu.Length > 2 && int.TryParse(maCu.Substring(2), out int so))
                    {
                        soThuTu = so + 1;
                    }
                }

                return "HH" + soThuTu.ToString("D4"); // VD: HH0026
            }
        }

        public static bool ThemThuocMoi(HangHoa thuoc)
        {
            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // bắt đầu transaction

                try
                {
                    // 1. Thêm vào bảng HANG_HOA
                    string insertHH = @"
                INSERT INTO HANG_HOA (MA_HANG_HOA, TEN_HANG_HOA, TON_KHO, NGAY_HET_HAN_HH, MA_VACH, GHI_CHU_HH, HINH_ANH_HH, MA_NHOM_HH)
                VALUES (@maHH, @tenHH, @tonKho, @hanSD, @maVach, @ghiChu, @hinhAnh, NULL)";

                    SqlCommand cmd1 = new SqlCommand(insertHH, conn, transaction);
                    cmd1.Parameters.AddWithValue("@maHH", thuoc.MaHangHoa);
                    cmd1.Parameters.AddWithValue("@tenHH", thuoc.TenHangHoa);
                    cmd1.Parameters.AddWithValue("@tonKho", thuoc.SoLuongTon);
                    cmd1.Parameters.AddWithValue("@hanSD", (object)thuoc.HanSuDung ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@maVach", (object)thuoc.MaVach ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@ghiChu", (object)thuoc.GhiChu ?? DBNull.Value);
                    cmd1.Parameters.AddWithValue("@hinhAnh", (object)thuoc.HinhAnh ?? DBNull.Value);
                    cmd1.ExecuteNonQuery();

                    // 2. Thêm vào bảng GIA_HANG_HOA (nếu có đơn vị tính)
                    if (!string.IsNullOrEmpty(thuoc.MaDonViTinh))
                    {
                        string insertGia = @"
                    INSERT INTO GIA_HANG_HOA (MA_HANG_HOA, MA_DON_VI_TINH, GIA_VON_HH, GIA_BAN_HH)
                    VALUES (@maHH, @maDVT, @giaNhap, @giaBan)";

                        SqlCommand cmd2 = new SqlCommand(insertGia, conn, transaction);
                        cmd2.Parameters.AddWithValue("@maHH", thuoc.MaHangHoa);
                        cmd2.Parameters.AddWithValue("@maDVT", thuoc.MaDonViTinh);
                        cmd2.Parameters.AddWithValue("@giaNhap", thuoc.GiaNhap);
                        cmd2.Parameters.AddWithValue("@giaBan", thuoc.GiaBan);
                        cmd2.ExecuteNonQuery();
                    }

                    // 3. Có thể thêm vào PHIEU_NHAP_HANG hoặc các bảng khác nếu cần

                    transaction.Commit(); // hoàn tất
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // hoàn tác nếu lỗi
                    Console.WriteLine("Lỗi khi thêm thuốc: " + ex.Message);
                    return false;
                }
            }
        }





    }




}
