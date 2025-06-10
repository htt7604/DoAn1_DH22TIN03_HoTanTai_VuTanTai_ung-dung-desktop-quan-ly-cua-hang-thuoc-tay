using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Nha_thuoc.model;
namespace QL_Nha_thuoc.HangHoa
{
    public partial class FormThemHangSX : Form
    {
        public FormThemHangSX()
        {
            InitializeComponent();
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        public event EventHandler DuLieuDaThayDoi;
        public string TenHangSXMoi { get; private set; }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // thêm dữ liệu như đã làm trước
                using (var conn = new CSDL().GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO HANG_SAN_XUAT (TEN_HANG_SX) VALUES (@tenhangSX)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@tenhangSX", textBoxTenHangSX.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Gửi sự kiện và tên hãng mới
                TenHangSXMoi = textBoxTenHangSX.Text;
                DuLieuDaThayDoi?.Invoke(this, EventArgs.Empty);

                MessageBox.Show("Thêm hãng sản xuất thành công!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }





    }
}
