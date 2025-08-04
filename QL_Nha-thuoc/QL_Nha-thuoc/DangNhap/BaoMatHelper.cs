using System.Security.Cryptography;
using System.Text;

public static class BaoMatHelper
{
    public static string BamMatKhau(string matKhau)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] bytes = Encoding.UTF8.GetBytes(matKhau);
            byte[] hash = sha256.ComputeHash(bytes);

            StringBuilder builder = new StringBuilder();
            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2")); // chuyển sang dạng hex
            }
            return builder.ToString();
        }
    }
}
