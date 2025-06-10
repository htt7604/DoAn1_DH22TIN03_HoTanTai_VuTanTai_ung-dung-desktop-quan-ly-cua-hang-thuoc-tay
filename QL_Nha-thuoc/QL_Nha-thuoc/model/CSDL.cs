using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace QL_Nha_thuoc.model
{
    internal class CSDL
    {
        public SqlConnection GetConnection() //
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
            return conn;
        }

        internal SqlDataReader GetDataReader(string query) //
        {
            throw new NotImplementedException();
        }

        public SqlDataReader getForCombox(string query) //
        {
            // Kết nối SQL và thực thi query
            SqlConnection conn = new SqlConnection("Chuỗi_kết_nối");
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            return cmd.ExecuteReader(); // Trả về SqlDataReader
        }
    }
}
