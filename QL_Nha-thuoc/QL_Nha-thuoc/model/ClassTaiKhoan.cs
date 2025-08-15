using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{

    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string VaiTro { get; set; }


        public NhanVien(string maNV, string tenNV, string vaiTro = "")
        {
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
            VaiTro = vaiTro;
        }
    }

    public class ClassTaiKhoan
    {
        public string TenHienThi
        {
            get
            {
                return $"{TenNhanVien} ({VaiTro})";
            }
        }

        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien => NhanVien?.TenNhanVien;
        public string VaiTro { get; set; }
        public bool DaXacThucEmail { get; set; }
        public bool LanDauDangNhap { get; set; }


        public NhanVien NhanVien { get; set; }

        public ClassTaiKhoan(string tenTK, string matKhau, string maNV, string vaiTro, NhanVien nv, bool daXacThucEmail, bool lanDauDangNhap)
        {
            TenTaiKhoan = tenTK;
            MatKhau = matKhau;
            MaNhanVien = maNV;
            VaiTro = vaiTro;
            NhanVien = nv;
            DaXacThucEmail = daXacThucEmail;
            LanDauDangNhap = lanDauDangNhap;
        }
        public ClassTaiKhoan() { }

        public static List<ClassNhanVien> LayDanhSachNhanVienCoTaiKhoan()
        {
            List<ClassNhanVien> danhSach = new List<ClassNhanVien>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            SELECT DISTINCT NV.MA_NV, NV.HO_TEN_NV
            FROM NHAN_VIEN NV
            JOIN TAI_KHOAN TK ON NV.MA_NV = TK.MA_NV "; // Loại bỏ Admin

                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        danhSach.Add(new ClassNhanVien
                        {
                            MaNhanVien = reader["MA_NV"].ToString(),
                            HoTenNhanVien = reader["HO_TEN_NV"].ToString()
                        });
                    }
                }
            }

            return danhSach;
        }



        // ✅ Lấy tài khoản từ DB theo tên tài khoản
        public static ClassTaiKhoan LayTaiKhoan(string tenTK)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                SELECT TK.TEN_TAI_KHOAN, TK.MAT_KHAU, TK.MA_NV, NV.HO_TEN_NV, VT.TEN_VAI_TRO,TK.DA_XAC_THUC_EMAIL,TK.LAN_DAU_DANG_NHAP
                FROM TAI_KHOAN TK 
                join NHAN_VIEN NV on TK.MA_NV=NV.MA_NV JOIN VAI_TRO VT ON TK.MA_VAI_TRO=VT.MA_VAI_TRO
                WHERE  TK.TEN_TAI_KHOAN = @TenTaiKhoan";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tenTK);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string matKhau = reader["MAT_KHAU"].ToString();
                        string maNV = reader["MA_NV"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();
                        string vaiTro = reader["TEN_VAI_TRO"].ToString();
                        bool daXacThucEmail = reader["DA_XAC_THUC_EMAIL"] != DBNull.Value && Convert.ToBoolean(reader["DA_XAC_THUC_EMAIL"]);
                        bool lanDauDangNhap = reader["LAN_DAU_DANG_NHAP"] != DBNull.Value && Convert.ToBoolean(reader["LAN_DAU_DANG_NHAP"]);
                        var nhanVien = new NhanVien(maNV, tenNV, vaiTro);
                        return new ClassTaiKhoan(tenTK, matKhau, maNV, vaiTro, nhanVien, daXacThucEmail, lanDauDangNhap);
                    }
                }
            }

            return null;
        }
        // ✅ Lấy tài khoản từ DB theo mã nhân viên
        public static ClassTaiKhoan LayTaiKhoanTheoMaNV(string maNV)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            SELECT TK.TEN_TAI_KHOAN, TK.MAT_KHAU, TK.MA_NV, NV.HO_TEN_NV, VT.TEN_VAI_TRO, 
                   TK.DA_XAC_THUC_EMAIL, TK.LAN_DAU_DANG_NHAP
            FROM TAI_KHOAN TK
            JOIN NHAN_VIEN NV ON TK.MA_NV = NV.MA_NV
            JOIN VAI_TRO VT ON TK.MA_VAI_TRO = VT.MA_VAI_TRO
            WHERE TK.MA_NV = @MaNV";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaNV", maNV);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string tenTK = reader["TEN_TAI_KHOAN"].ToString();
                        string matKhau = reader["MAT_KHAU"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();
                        string vaiTro = reader["TEN_VAI_TRO"].ToString();
                        bool daXacThucEmail = reader["DA_XAC_THUC_EMAIL"] != DBNull.Value && Convert.ToBoolean(reader["DA_XAC_THUC_EMAIL"]);
                        bool lanDauDangNhap = reader["LAN_DAU_DANG_NHAP"] != DBNull.Value && Convert.ToBoolean(reader["LAN_DAU_DANG_NHAP"]);

                        var nhanVien = new NhanVien(maNV, tenNV, vaiTro);
                        return new ClassTaiKhoan(tenTK, matKhau, maNV, vaiTro, nhanVien, daXacThucEmail, lanDauDangNhap);
                    }
                }
            }

            return null;
        }

        //ham lay danh sach tai khoan
        public static List<ClassTaiKhoan> LayDanhSachTaiKhoan()
        {
            List<ClassTaiKhoan> danhSachTaiKhoan = new List<ClassTaiKhoan>();
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
                SELECT TK.TEN_TAI_KHOAN, TK.MAT_KHAU, TK.MA_NV, NV.HO_TEN_NV, VT.TEN_VAI_TRO, TK.DA_XAC_THUC_EMAIL,TK.LAN_DAU_DANG_NHAP
                FROM TAI_KHOAN TK 
                JOIN NHAN_VIEN NV ON TK.MA_NV = NV.MA_NV 
                JOIN VAI_TRO VT ON TK.MA_VAI_TRO = VT.MA_VAI_TRO ";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string tenTK = reader["TEN_TAI_KHOAN"].ToString();
                        string matKhau = reader["MAT_KHAU"].ToString();
                        string maNV = reader["MA_NV"].ToString();
                        string tenNV = reader["HO_TEN_NV"].ToString();
                        string vaiTro = reader["TEN_VAI_TRO"].ToString();
                        bool daXacThucEmail = reader["DA_XAC_THUC_EMAIL"] != DBNull.Value && Convert.ToBoolean(reader["DA_XAC_THUC_EMAIL"]);
                        bool lanDauDangNhap = reader["LAN_DAU_DANG_NHAP"] != DBNull.Value && Convert.ToBoolean(reader["LAN_DAU_DANG_NHAP"]);
                        var nhanVien = new NhanVien(maNV, tenNV, vaiTro);
                        var taiKhoan = new ClassTaiKhoan(tenTK, matKhau, maNV, vaiTro, nhanVien, daXacThucEmail, lanDauDangNhap);
                        danhSachTaiKhoan.Add(taiKhoan);
                    }
                }
            }
            return danhSachTaiKhoan;
        }

        public static bool ThemTaiKhoan(ClassTaiKhoan tk)
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = @"
            INSERT INTO TAI_KHOAN 
            (TEN_TAI_KHOAN, MAT_KHAU, MA_NV, MA_VAI_TRO, DA_XAC_THUC_EMAIL, LAN_DAU_DANG_NHAP) 
            VALUES 
            (@TenTaiKhoan, @MatKhau, @MaNV, 
             @VaiTro,
             @DaXacThucEmail, @LanDauDangNhap)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TenTaiKhoan", tk.TenTaiKhoan);
                cmd.Parameters.AddWithValue("@MatKhau", tk.MatKhau);
                cmd.Parameters.AddWithValue("@MaNV", tk.MaNhanVien);
                cmd.Parameters.AddWithValue("@VaiTro", tk.VaiTro);
                cmd.Parameters.AddWithValue("@DaXacThucEmail", tk.DaXacThucEmail);
                cmd.Parameters.AddWithValue("@LanDauDangNhap", tk.LanDauDangNhap);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }


    }
}