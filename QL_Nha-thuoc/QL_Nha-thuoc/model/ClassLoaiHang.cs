using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class ClassLoaiHang
    {
        public static List<string> LayDanhSachLoaiHang()
        {
            List<string> loaiHangList = new List<string>();
            CSDL cSDL = new CSDL();
            SqlConnection conn = CSDL.GetConnection();
            string query = "SELECT TEN_LOAI_HH FROM LOAI_HANG";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    loaiHangList.Add(reader.GetString(0));
                }
            }
            return loaiHangList;
        }
    }



}
