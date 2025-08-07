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
using QL_Nha_thuoc.NhanVien;
using QL_Nha_thuoc.model;
namespace QL_Nha_thuoc
{
    public partial class DSNhanVien : Form
    {
        public DSNhanVien()
        {
            InitializeComponent();
        }

        private void DSNhanVien_Load(object sender, EventArgs e)
        {
            // Câu lệnh truy vấn lấy toàn bộ dữ liệu từ bảng NhanVien
            string query = "SELECT * FROM NHAN_VIEN";

            // Tạo đối tượng kết nối
            CSDL csdl = new CSDL(); // Instantiate the CSDL class
            using (SqlConnection conn = CSDL.GetConnection()) // Use the GetConnection method
            {
                try
                {
                    // Mở kết nối
                    conn.Open();

                    // Tạo SqlDataAdapter để lấy dữ liệu
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu vào DataTable
                    adapter.Fill(dt);

                    // Gán DataTable vào DataGridView để hiển thị
                    dataGridViewdsNV.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void buttonThemNV_Click(object sender, EventArgs e)
        {
            FormThemNhanVien formThemNhanVien = new FormThemNhanVien();
            formThemNhanVien.ShowDialog();
        }



        private void buttonThemNV_Click_1(object sender, EventArgs e)
        {
            //an toan bo form
            // Tạo một instance của UserControl
            UserControl myUserControl = new UserControl();

            // Thêm UserControl vào Form
            this.Controls.Add(myUserControl);
            myUserControl.Dock = DockStyle.Fill; // Hiển thị toàn bộ Form

            // Ẩn các điều khiển khác trên Form
            foreach (Control control in this.Controls)
            {
                if (control != myUserControl)
                {
                    control.Visible = false;
                }
            }

        }


    }
}
