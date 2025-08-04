using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using QL_Nha_thuoc.model;
namespace QL_Nha_thuoc.model
{
    // Đại diện chi tiết hàng hóa trong phiếu nhập (nếu có bảng CHI_TIET_PHIEU_NHAP)
    public class ClassChiTietPhieuNhap
    {
        public string MaPhieuNhap { get; set; }
        public string MaHangHoa { get; set; }
        public string TenHangHoa { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }

        public ClassChiTietPhieuNhap() { }

        public ClassChiTietPhieuNhap(string maPhieu, string maHH, string tenHH, int soLuong, decimal donGia, decimal giamGia, decimal thanhTien)
        {
            MaPhieuNhap = maPhieu;
            MaHangHoa = maHH;
            TenHangHoa = tenHH;
            SoLuong = soLuong;
            DonGia = donGia;
            GiamGia = giamGia;
            ThanhTien = thanhTien;
        }
        //ham lấy danh sách chi tiết phiếu nhập
        public static List<ClassChiTietPhieuNhap> LayChiTietPhieuNhap(string maPhieu)
        {
            List<ClassChiTietPhieuNhap> danhSach = new List<ClassChiTietPhieuNhap>();
            CSDL csdl = new CSDL();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                conn.Open();
                string query = @"
                   SELECT 
                 CT.MA_PHIEU_NHAP, 
                 CT.MA_HANG_HOA, 
                 HH.TEN_HANG_HOA, 
                 CT.SO_LUONG_HH, 
                 CT.DON_GIA, 
                 CT.GIAM_GIA, 
                 CT.THANH_TIEN
             FROM CHI_TIET_PHIEU_NHAP CT
             JOIN HANG_HOA HH ON CT.MA_HANG_HOA = HH.MA_HANG_HOA
             WHERE CT.MA_PHIEU_NHAP = @maPhieu";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maPhieu", maPhieu);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    danhSach.Add(new ClassChiTietPhieuNhap
                    {
                        MaPhieuNhap = reader["MA_PHIEU_NHAP"].ToString(),
                        MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                        TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                        SoLuong = Convert.ToInt32(reader["SO_LUONG_HH"]),
                        DonGia = Convert.ToDecimal(reader["DON_GIA"]),
                        GiamGia = Convert.ToDecimal(reader["GIAM_GIA"]),
                        ThanhTien = Convert.ToDecimal(reader["THANH_TIEN"])
                    });
                }
            }
            return danhSach;
        }






    }
}
