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
namespace QL_Nha_thuoc
{
    public partial class DSNhanVien : Form
    {
        public DSNhanVien()
        {
            InitializeComponent();
            TaiChucvu(new CSDL().GetConnection()); // Initialize the ComboBox with positions

        }
        private void TaiChucvu(SqlConnection conn)
        {
            try
            {
                string query = "SELECT  TEN_CHUC_VU,MA_CHUC_VU FROM CHUC_VU";
                using (var cmd = new SqlCommand(query, conn))
                {

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    var table = new DataTable();
                    da.Fill(table);
                    comboBoxChucVu.DataSource = table;
                    comboBoxChucVu.DisplayMember = "TEN_CHUC_VU";
                    comboBoxChucVu.ValueMember = "MA_CHUC_VU";

                    comboBoxChucVu.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DSNhanVien_Load(object sender, EventArgs e)
        {
            // Câu lệnh truy vấn lấy toàn bộ dữ liệu từ bảng NhanVien
            string query = "SELECT * FROM NHAN_VIEN";

            // Tạo đối tượng kết nối
            CSDL csdl = new CSDL(); // Instantiate the CSDL class
            using (SqlConnection conn = csdl.GetConnection()) // Use the GetConnection method
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
            //thnhân viên mới

        }

        private void comboBoxChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxChucVu.Enabled = true;
            if (comboBoxChucVu.SelectedItem == null)
            {
                return;
            }
            var selectedRow = comboBoxChucVu.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string chucvu = selectedRow["MA_CHUC_VU"].ToString();
                CSDL csdl = new CSDL(); // Instantiate the CSDL class
                using (SqlConnection conn = csdl.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT MA_VI_TRI,TEN_VI_TRI FROM VI_TRI_NHAN_VIEN join CHUC_VU on CHUC_VU.MA_CHUC_VU = VI_TRI_NHAN_VIEN.MA_CHUC_VU where VI_TRI_NHAN_VIEN.MA_CHUC_VU= @chucvu";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@chucvu", chucvu);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        comboBoxViTri.DataSource = dt;
                        comboBoxViTri.DisplayMember = "TEN_VI_TRI";
                        comboBoxViTri.ValueMember = "MA_VI_TRI";

                        comboBoxViTri.SelectedIndex = -1;
                    }
                }
            }
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
