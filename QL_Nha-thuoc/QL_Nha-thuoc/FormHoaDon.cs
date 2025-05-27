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

namespace QL_Nha_thuoc
{
    public partial class FormHoaDon : Form
    {
        public FormHoaDon()
        {
            InitializeComponent();
        }
        private void FormHoaDon_Load(object sender, EventArgs e)
        {
            // Câu lệnh truy vấn lấy toàn bộ dữ liệu từ bảng HANG_HOA
            string query = "SELECT * FROM HANG_HOA";

            // Tạo đối tượng kết nối
            CSDL csdl = new CSDL(); // Instantiate the CSDL class
            using (SqlConnection conn = csdl.GetConnection()) // Use the GetConnection method
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Panel productPanel = new Panel();
                    productPanel.Size = new Size(250, 100);
                    productPanel.BorderStyle = BorderStyle.FixedSingle;

                    Label lblName = new Label();
                    lblName.Text = row["TEN_HANG_HOA"].ToString();
                    lblName.Location = new Point(10, 10);

                    Label lblPrice = new Label();
                    lblPrice.Text = $"Giá: {row["GIA_BAN_HH"]} VNĐ";
                    lblPrice.Location = new Point(10, 40);

                    PictureBox picProduct = new PictureBox();
                    picProduct.Size = new Size(40, 40);
                    picProduct.Location = new Point(10, 10);
                    picProduct.SizeMode = PictureBoxSizeMode.Zoom;

                    string imagePath = row["HINH_ANH_HH"].ToString();
                    if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                    {
                        picProduct.Image = Image.FromFile(imagePath);
                    }

                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(lblPrice);
                    productPanel.Controls.Add(picProduct);

                    flowLayoutPanelHH.Controls.Add(productPanel);
                }
            }
        }
    }
}
