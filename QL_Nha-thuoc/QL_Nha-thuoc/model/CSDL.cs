using System;
using Microsoft.Data.SqlClient;

namespace QL_Nha_thuoc.model
{
    public class CSDL
    {
        private static readonly string connectionString = "Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";

        // Hàm trả về đối tượng SqlConnection
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Hàm thực thi SELECT và trả về SqlDataReader
        public static SqlDataReader GetDataReader(string query)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }

        // Hàm dùng cho combobox (SELECT)
        public static SqlDataReader GetForComboBox(string query)
        {
            return GetDataReader(query);
        }
    }
}
