using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace QL_Nha_thuoc.model
{
    public class ClassThuoc
    {
        // Thuộc tính chính
        public string MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string SoDangKy { get; set; }
        public string HoatChatChinh { get; set; }
        public string HamLuong { get; set; }
        public string QuyCachDongGoi { get; set; }

        public string TenDonViTinh { get; set; } // Tên đơn vị tính, từ bảng DON_VI_TINH

        // Thông tin liên kết
        public string MaHangSanXuat { get; set; } // Mã nhà sản xuất, từ bảng HANG_SAN_XUAT
        public string TenHangSanXuat { get; set; } // từ bảng HANG_SAN_XUAT
        public string MaDonViTinh { get; set; }    // từ bảng DON_VI_TINH

        public ClassThuoc() { }

        public ClassThuoc(string maThuoc, string tenThuoc, string soDangKy, string hoatChatChinh,
                          string hamLuong, string quyCachDongGoi, string tenHangSanXuat, string maDonViTinh, string tenDonViTinh, string maHangSanXuat)
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

        // ✅ Hàm lấy danh sách thuốc từ cơ sở dữ liệu
        public static List<ClassThuoc> LayDanhSachThuoc(string keyword = "")
        {
            var danhSach = new List<ClassThuoc>();

            using (SqlConnection conn = DBHelperHH.GetConnection())
            {
                string query = @"
                SELECT 
                T.MA_THUOC,
                T.TEN_THUOC,
                T.SO_DANG_KY,
                T.HOAT_CHAT_CHINH,
                T.HAM_LUONG,
                T.QUY_CACH_DONG_GOI,
                HSX.TEN_HANG_SX,
                T.MA_DON_VI_TINH,
                T.MA_HANG_SX,
                DVT.TEN_DON_VI_TINH
                FROM DANH_MUC_THUOC T
                LEFT JOIN HANG_SAN_XUAT HSX ON T.MA_HANG_SX = HSX.MA_HANG_SX
                LEFT JOIN DON_VI_TINH DVT ON T.MA_DON_VI_TINH = DVT.MA_DON_VI_TINH  
                WHERE T.TEN_THUOC LIKE @keyword";

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
    }
}

