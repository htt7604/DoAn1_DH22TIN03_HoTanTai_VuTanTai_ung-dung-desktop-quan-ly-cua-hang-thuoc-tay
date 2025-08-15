using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace QL_Nha_thuoc.model
{
    public class ClassThuoc
    {
        // Thuộc tính thuốc
        public string MaHangHoa { get; set; }
        public string MaThuoc { get; set; }
        public string MaNhomHang { get; set; }

        public string TenHangHoa
        {
            get { return TenThuoc; } // Trả về tên thuốc
            set { TenThuoc = value; } // Cập nhật tên thuốc
        }
        public string TenThuoc { get; set; }
        public string TenVietTat { get; set; }
        public string TrongLuong { get; set; }
        public string SoDangKy { get; set; }
        public string HamLuong { get; set; }
        public string HoatChatChinh { get; set; }
        public string QuyCachDongGoi { get; set; }
        public string TenDuongDung { get; set; }
        public string MaDuongDung { get; set; }
        public decimal GiaBan { get; set; }
        public decimal GiaVon { get; set; }
        public string TenHangSanXuat { get; set; }
        public string MaHangSanXuat { get; set; }
        public string TenDonViTinh { get; set; }
        public string MaDonViTinh { get; set; }
        public string HinhAnh { get; set; }
        public string MaVach { get; set; }
        public string GhiChu { get; set; }
        public string TenNhaCungCap { get; set; }
        public string TenLoaiHang { get; set; }
        public string TenNhomHang { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string TinhTrang { get; set; }

        public int SoLuongTon { get; set; } // Số lượng tồn kho
        public DateTime? ThoiGianTao { get; set; } // Thời gian tạo hàng hóa
        public DateTime? HanSuDung { get; set; } // Hạn sử dụng của thuốc
        public ClassThuoc() { }

        public ClassThuoc(string maThuoc, string tenThuoc, string soDangKy, string hoatChatChinh,
                          string hamLuong, string quyCachDongGoi, string tenHangSanXuat,
                          string maDonViTinh, string tenDonViTinh, string maHangSanXuat)
        {
            MaThuoc = maThuoc;
            TenThuoc = tenThuoc;
            SoDangKy = soDangKy;
            HoatChatChinh = hoatChatChinh;
            HamLuong = hamLuong;
            QuyCachDongGoi = quyCachDongGoi;
            TenHangSanXuat = tenHangSanXuat;
            MaDonViTinh = maDonViTinh;
            TenDonViTinh = tenDonViTinh;
            MaHangSanXuat = maHangSanXuat;
        }

        // ✅ Lấy chi tiết thuốc theo mã hàng hóa
        public static ClassThuoc LayChiTietThuocTheoMaHH(string maHangHoa)
        {
            ClassThuoc thuoc = null;

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                    SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, HH.TEN_VIET_TAT, HH.TRONG_LUONG_HH,
                   HH.SO_DANG_KY_THUOC, HH.MA_THUOC, HH.HAM_LUONG, HH.HOAT_CHAT, HH.QUY_CACH_DONG_GOI,
                   GHH.GIA_BAN_HH, GHH.GIA_VON_HH, DDT.MA_DUONG_DUNG,DDT.TEN_DUONG_DUNG,
                   HSX.MA_HANG_SX, HSX.TEN_HANG_SX,
                   DVT.TEN_DON_VI_TINH, GHH.MA_DON_VI_TINH,
                   HH.HINH_ANH_HH, HH.MA_VACH, HH.GHI_CHU_HH,
                   NCC.TEN_NHA_CUNG_CAP,
                   LH.TEN_LOAI_HH, NH.TEN_NHOM,
                   HH.NGAY_HET_HAN_HH, HH.TINH_TRANG_HH
            FROM HANG_HOA HH
            JOIN NHOM_HANG NH ON HH.MA_NHOM_HH = NH.MA_NHOM_HH
            JOIN LOAI_HANG LH ON NH.MA_LOAI_HH = LH.MA_LOAI_HH
            LEFT JOIN DUONG_DUNG_THUOC DDT ON HH.MA_DUONG_DUNG=DDT.MA_DUONG_DUNG
            LEFT JOIN HANG_SAN_XUAT HSX ON HH.MA_HANG_SX = HSX.MA_HANG_SX
            LEFT JOIN GIA_HANG_HOA GHH ON GHH.MA_HANG_HOA = HH.MA_HANG_HOA
            LEFT JOIN DON_VI_TINH DVT ON GHH.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
            LEFT JOIN CHI_TIET_PHIEU_NHAP CTPN ON CTPN.MA_HANG_HOA = HH.MA_HANG_HOA
            LEFT JOIN PHIEU_NHAP_HANG PN ON PN.MA_PHIEU_NHAP = CTPN.MA_PHIEU_NHAP
            LEFT JOIN NHA_CUNG_CAP NCC ON NCC.MA_NHA_CUNG_CAP = PN.MA_NHA_CUNG_CAP
            WHERE HH.MA_HANG_HOA = @maHH";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHH", maHangHoa);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        thuoc = new ClassThuoc
                        {
                            MaHangHoa = reader["MA_HANG_HOA"]?.ToString(),
                            TenThuoc = reader["TEN_HANG_HOA"]?.ToString(),
                            TenVietTat = reader["TEN_VIET_TAT"]?.ToString(),
                            TrongLuong = reader["TRONG_LUONG_HH"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY_THUOC"]?.ToString(),
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            MaDuongDung = reader["MA_DUONG_DUNG"]?.ToString(),
                            TenDuongDung = reader["TEN_DUONG_DUNG"]?.ToString(),
                            GiaBan = reader["GIA_BAN_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_BAN_HH"]) : 0,
                            GiaVon = reader["GIA_VON_HH"] != DBNull.Value ? Convert.ToDecimal(reader["GIA_VON_HH"]) : 0,
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString(),
                            MaHangSanXuat = reader["MA_HANG_SX"]?.ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            HinhAnh = reader["HINH_ANH_HH"]?.ToString(),
                            MaVach = reader["MA_VACH"]?.ToString(),
                            GhiChu = reader["GHI_CHU_HH"]?.ToString(),
                            TenNhaCungCap = reader["TEN_NHA_CUNG_CAP"]?.ToString(),
                            TenLoaiHang = reader["TEN_LOAI_HH"]?.ToString(),
                            TenNhomHang = reader["TEN_NHOM"]?.ToString(),
                            NgayHetHan = reader["NGAY_HET_HAN_HH"] != DBNull.Value ? Convert.ToDateTime(reader["NGAY_HET_HAN_HH"]) : (DateTime?)null,
                            TinhTrang = reader["TINH_TRANG_HH"]?.ToString()
                        };
                    }
                }
            }

            return thuoc;
        }

        // ✅ Lấy danh sách thuốc theo từ khóa trong danh muc thuoc 
        public static List<ClassThuoc> LayDanhSachThuoc(string keyword = "")
        {
            var danhSach = new List<ClassThuoc>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                SELECT DMT.MA_THUOC, DMT.TEN_THUOC, DMT.SO_DANG_KY, DMT.HOAT_CHAT_CHINH, DMT.HAM_LUONG, 
                       DMT.QUY_CACH_DONG_GOI, HSX.TEN_HANG_SX, DVT.MA_DON_VI_TINH, DVT.TEN_DON_VI_TINH, HSX.MA_HANG_SX
                FROM DANH_MUC_THUOC DMT
                LEFT JOIN HANG_SAN_XUAT HSX ON DMT.MA_HANG_SX = HSX.MA_HANG_SX
                LEFT JOIN DON_VI_TINH DVT ON DMT.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH
                WHERE DMT.TEN_THUOC LIKE @keyword ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var thuoc = new ClassThuoc
                        {
                            MaThuoc = reader["MA_THUOC"]?.ToString(),
                            TenThuoc = reader["TEN_THUOC"]?.ToString(),
                            SoDangKy = reader["SO_DANG_KY"]?.ToString(),
                            HoatChatChinh = reader["HOAT_CHAT_CHINH"]?.ToString(),
                            HamLuong = reader["HAM_LUONG"]?.ToString(),
                            QuyCachDongGoi = reader["QUY_CACH_DONG_GOI"]?.ToString(),
                            TenHangSanXuat = reader["TEN_HANG_SX"]?.ToString(),
                            MaDonViTinh = reader["MA_DON_VI_TINH"]?.ToString(),
                            TenDonViTinh = reader["TEN_DON_VI_TINH"]?.ToString(),
                            MaHangSanXuat = reader["MA_HANG_SX"]?.ToString()
                        };

                        danhSach.Add(thuoc);
                    }
                }
            }

            return danhSach;
        }

        public static bool MaVachDaTonTai(string maVach)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM HANG_HOA WHERE MA_VACH = @maVach";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@maVach", maVach);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public static string TaoMaVachMoi()
        {
            Random rnd = new Random();
            string maVach;
            int maxThu = 1000; // Giới hạn số lần thử để tránh vòng lặp vô hạn

            do
            {
                maVach = "";
                for (int i = 0; i < 13; i++)
                {
                    maVach += rnd.Next(0, 10).ToString();
                }
                maxThu--;
                if (maxThu <= 0)
                    throw new Exception("Không thể tạo mã vạch không trùng sau nhiều lần thử.");
            }
            while (MaVachDaTonTai(maVach));

            return maVach;
        }







        //ham them thuoc Moi
        public static bool ThemThuocMoiVoiTenHangHoa(ClassThuoc thuoc)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            INSERT INTO HANG_HOA (
                MA_HANG_HOA,MA_NHOM_HH, TEN_HANG_HOA, TEN_VIET_TAT, TRONG_LUONG_HH, 
                SO_DANG_KY_THUOC, MA_THUOC, HAM_LUONG, HOAT_CHAT, 
                QUY_CACH_DONG_GOI, MA_DUONG_DUNG, 
                MA_HANG_SX, HINH_ANH_HH, 
                MA_VACH, GHI_CHU_HH, TINH_TRANG_HH
            )
            VALUES (
                @maHangHoa,@maNhomHH ,@tenThuoc, @tenVietTat, @trongLuong,
                @soDangKyThuoc, @maThuoc, @hamLuong, @hoatChat,
                @quyCachDongGoi, @maduongdung,
                @maHangSanXuat, @hinhAnh,
                @maVach, @ghiChu, 'Còn hàng'
            )";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maHangHoa", thuoc.MaHangHoa);
                cmd.Parameters.AddWithValue("@maNhomHH", thuoc.MaNhomHang);
                cmd.Parameters.AddWithValue("@tenThuoc", thuoc.TenThuoc); // Làm tên hàng hóa
                cmd.Parameters.AddWithValue("@tenVietTat", thuoc.TenVietTat ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@trongLuong", thuoc.TrongLuong ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@soDangKyThuoc", thuoc.SoDangKy ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@maThuoc", thuoc.MaThuoc);
                cmd.Parameters.AddWithValue("@hamLuong", thuoc.HamLuong ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hoatChat", thuoc.HoatChatChinh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@quyCachDongGoi", thuoc.QuyCachDongGoi ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@maduongdung", thuoc.MaDuongDung ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@maHangSanXuat", thuoc.MaHangSanXuat ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hinhAnh", thuoc.HinhAnh ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@maVach", thuoc.MaVach ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@ghiChu", thuoc.GhiChu ?? (object)DBNull.Value);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }



        //ham tao ma hang hoa tu dong
        public static string TaoMaHangHoaTuDong()
        {
            using (SqlConnection conn = CSDL.GetConnection())
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

        public static bool ThemThuocMoi(ClassThuoc thuoc)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // 1. Thêm vào bảng HANG_HOA
                    string insertHH = @"
                INSERT INTO HANG_HOA (
                    MA_HANG_HOA, MA_THUOC, TEN_HANG_HOA, TON_KHO, NGAY_HET_HAN_HH, MA_VACH, 
                    GHI_CHU_HH, HINH_ANH_HH, MA_NHOM_HH, HOAT_CHAT, HAM_LUONG, 
                    SO_DANG_KY_THUOC, QUY_CACH_DONG_GOI, MA_HANG_SX, TINH_TRANG_HH, THOI_GIAN_TAO,MA_DUONG_DUNG
                ) VALUES (
                    @maHH, @maThuoc, @tenHH, @tonKho, @hanSD, @maVach, 
                    @ghiChu, @hinhAnh, @maNhom, @hoatChat, @hamLuong, 
                    @soDK, @quyCach, @maHangSX, @tinhTrang, @thoigiantao,@maDuongDung
                )";

                    using (SqlCommand cmd1 = new SqlCommand(insertHH, conn, transaction))
                    {
                        cmd1.Parameters.AddWithValue("@maHH", thuoc.MaHangHoa);
                        cmd1.Parameters.AddWithValue("@maThuoc", (object)thuoc.MaThuoc ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@tenHH", thuoc.TenHangHoa);
                        cmd1.Parameters.AddWithValue("@tonKho", thuoc.SoLuongTon);
                        cmd1.Parameters.AddWithValue("@hanSD", (object)thuoc.HanSuDung ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@maVach", (object)thuoc.MaVach ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@ghiChu", (object)thuoc.GhiChu ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@hinhAnh", (object)thuoc.HinhAnh ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@maNhom", (object)thuoc.MaNhomHang ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@hoatChat", (object)thuoc.HoatChatChinh ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@hamLuong", (object)thuoc.HamLuong ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@soDK", (object)thuoc.SoDangKy ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@quyCach", (object)thuoc.QuyCachDongGoi ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@maHangSX", (object)thuoc.MaHangSanXuat ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@tinhTrang", (object)thuoc.TinhTrang ?? DBNull.Value);
                        cmd1.Parameters.AddWithValue("@thoigiantao", thuoc.ThoiGianTao ?? DateTime.Now);
                        cmd1.Parameters.AddWithValue("@maDuongDung", (object)thuoc.MaDuongDung ?? DBNull.Value);

                        cmd1.ExecuteNonQuery();
                    }
                    // 2. Thêm giá bán

                    ClassGiaBanHH giaBan = new ClassGiaBanHH
                    {
                        MaHangHoa = thuoc.MaHangHoa,
                        MaBangGia = "BG001", // Giả sử bạn có một bảng giá mặc định
                        GiaVon = thuoc.GiaVon,
                        GiaBan = thuoc.GiaBan,
                        MaDonViTinh = thuoc.MaDonViTinh
                    };

                    // ✅ TRUYỀN conn và transaction vào hàm thêm giá
                    if (!ClassGiaBanHH.ThemGiaBan(giaBan, conn, transaction))
                    {
                        throw new Exception("Lỗi khi thêm giá hàng hóa.");
                    }

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi khi thêm thuốc: " + ex.Message);
                    Console.WriteLine("StackTrace: " + ex.StackTrace);
                    return false;
                }
            }
        }


    }


}
