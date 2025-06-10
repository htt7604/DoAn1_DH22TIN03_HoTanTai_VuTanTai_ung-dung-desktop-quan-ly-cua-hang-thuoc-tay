using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class DBHelper
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
    public class ClassTaiKhoan
    {
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaNhanVien { get; set; }
        public NhanVien NhanVien { get; set; }

        public ClassTaiKhoan(string tenTK, string matKhau, string maNV, NhanVien nv)
        {
            TenTaiKhoan = tenTK;
            MatKhau = matKhau;
            MaNhanVien = maNV;
            NhanVien = nv;
        }

        // ✅ Method để lấy thông tin tài khoản từ DB theo tên tài khoản
        public static ClassTaiKhoan LayTaiKhoan(string tenTK)
        {
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                string query = @"
            SELECT TK.TEN_TAI_KHOAN, TK.MAT_KHAU, TK.MA_NV, NV.HO_TEN_NV
            FROM TAI_KHOAN TK
            JOIN NHAN_VIEN NV ON TK.MA_NV = NV.MA_NV
            WHERE TK.TEN_TAI_KHOAN = @TenTaiKhoan"; // ✅ thêm WHERE đúng cú pháp

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTK);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string matKhau = reader["MAT_KHAU"].ToString();
                    string maNV = reader["MA_NV"].ToString();
                    string tenNV = reader["HO_TEN_NV"].ToString(); // ✅ đúng tên cột

                    var nhanVien = new NhanVien(maNV, tenNV);
                    return new ClassTaiKhoan(tenTK, matKhau, maNV, nhanVien);
                }
                else
                {
                    return null; // Không tìm thấy
                }
            }
        }
    }

    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }

        public NhanVien(string maNV, string tenNV)
        {
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
        }
    }

}
