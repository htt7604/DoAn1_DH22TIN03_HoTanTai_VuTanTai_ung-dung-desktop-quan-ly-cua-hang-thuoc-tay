using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_Nha_thuoc.model
{
    public class DBHelperNCC
    {
        private static string connectionString = @"Data Source=WIN_BYTAI;Initial Catalog=QL_NhaThuoc;Integrated Security=True;Trust Server Certificate=True";
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public class NhaCungCap
        {
            public string MaNhaCungCap { get; set; }
            public string TenNhaCungCap { get; set; }
            public string DienThoai { get; set; }
            public string Email { get; set; }
            public decimal NoCanTraHienTai { get; set; }
            public decimal TongMua { get; set; }
        }


    }
}
