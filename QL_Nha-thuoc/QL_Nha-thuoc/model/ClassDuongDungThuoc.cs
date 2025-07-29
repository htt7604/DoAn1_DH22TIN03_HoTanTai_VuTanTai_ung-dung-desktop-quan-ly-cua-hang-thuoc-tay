using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassDuongDungThuoc
    {
        public string MaDuongDung { get; set; }
        public string TenDuongDung { get; set; }
        public string GhiChuCachDung { get; set; }


        public ClassDuongDungThuoc(string maDuongDung, string tenDuongDung, string ghiChuCachDung)
        {
            MaDuongDung = maDuongDung;
            TenDuongDung = tenDuongDung;
            GhiChuCachDung = ghiChuCachDung;
        }
        public ClassDuongDungThuoc() { }

        public static ClassDuongDungThuoc LayDuongDungTheoMa(string maDuongDung)
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MA_DUONG_DUNG, TEN_DUONG_DUNG, GHI_CHU_CACH_DUNG FROM DUONG_DUNG_THUOC WHERE MA_DUONG_DUNG = @ma";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maDuongDung);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ClassDuongDungThuoc
                                {
                                    MaDuongDung = reader["MA_DUONG_DUNG"].ToString(),
                                    TenDuongDung = reader["TEN_DUONG_DUNG"].ToString(),
                                    GhiChuCachDung = reader["GHI_CHU_CACH_DUNG"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đường dùng: " + ex.Message);
            }

            return null;
        }


        public static DataTable LayDanhSachDuongDung()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MA_DUONG_DUNG, TEN_DUONG_DUNG, GHI_CHU_CACH_DUNG FROM DUONG_DUNG_THUOC";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(table);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đường dùng: " + ex.Message);
            }
            return table;
        }


        public static string TaoMaDuongDungTuDong()
        {
            string prefix = "DD";
            int so = 1;

            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    // Lấy mã lớn nhất hiện có
                    string query = "SELECT MAX(MA_DUONG_DUNG) FROM DUONG_DUNG_THUOC WHERE MA_DUONG_DUNG LIKE 'DD%'";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        object result = cmd.ExecuteScalar();
                        if (result != DBNull.Value && result != null)
                        {
                            string maMax = result.ToString(); // Ví dụ: "DD012"
                            string soStr = maMax.Substring(2); // Lấy "012"
                            if (int.TryParse(soStr, out int soCuoi))
                            {
                                so = soCuoi + 1;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mã đường dùng tự động: " + ex.Message);
            }

            return prefix + so.ToString("D3"); // => "DD001", "DD002"...
        }

        //them duong dung thuoc
        public static bool ThemDuongDungThuoc(ClassDuongDungThuoc duongDung)
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    // Tạo mã mới
                    string maMoi = TaoMaDuongDungTuDong();
                    duongDung.MaDuongDung = maMoi; // Gán lại cho đối tượng

                    string query = "INSERT INTO DUONG_DUNG_THUOC (MA_DUONG_DUNG, TEN_DUONG_DUNG, GHI_CHU_CACH_DUNG) VALUES (@ma, @ten, @ghiChu)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ma", maMoi);
                        cmd.Parameters.AddWithValue("@ten", duongDung.TenDuongDung);
                        cmd.Parameters.AddWithValue("@ghiChu", duongDung.GhiChuCachDung);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đường dùng: " + ex.Message);
                return false;
            }
        }



    }
}
