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

namespace QL_Nha_thuoc.HangHoa.Them
{
    public partial class FormThemNhomHangHoa : Form
    {
        public FormThemNhomHangHoa()
        {
            InitializeComponent();
            LoadDataToComboBoxLoaiHanghoa();
        }
        // Load dữ liệu vào combobox Loại hàng
        private void LoadDataToComboBoxLoaiHanghoa()
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_LOAI_HH, MA_LOAI_HH FROM LOAI_HANG";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxLoaiHang.DataSource = table;
                        comboBoxLoaiHang.DisplayMember = "TEN_LOAI_HH";
                        comboBoxLoaiHang.ValueMember = "MA_LOAI_HH";
                        //comboBoxLoaiHang.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load loại hàng: " + ex.Message);
            }
        }

        //ham them nhom hang dua va loai hang 
        private void ThemNhomHang(string tenNhom, string maLoai)
        {
            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    // Tạo mã nhóm hàng tự động nếu cần (ở đây dùng GUID làm ví dụ)
                    string maNhom = Guid.NewGuid().ToString("N").Substring(0, 8); // 8 ký tự đầu

                    string insertQuery = @"
                INSERT INTO NHOM_HANG (MA_NHOM_HH, TEN_NHOM_HH, MA_LOAI_HH)
                VALUES (@maNhom, @tenNhom, @maLoai)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhom", maNhom);
                        cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Đã thêm nhóm hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm nhóm hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhóm hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string TenNhomMoi { get; set; } // Thuộc tính trả về tên nhóm mới cho form cha

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            string tenNhom = textBoxTenNhom.Text.Trim();
            string maLoai = comboBoxLoaiHang.SelectedValue?.ToString();

            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(tenNhom))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(maLoai))
            {
                MessageBox.Show("Vui lòng chọn loại hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    conn.Open();

                    // Kiểm tra tên nhóm đã tồn tại chưa trong loại hàng
                    string checkQuery = "SELECT COUNT(*) FROM NHOM_HANG WHERE TEN_NHOM = @tenNhom AND MA_LOAI_HH = @maLoai";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                        checkCmd.Parameters.AddWithValue("@maLoai", maLoai);

                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Tên nhóm hàng đã tồn tại trong loại hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Sinh mã nhóm tự động
                    string maNhom = Guid.NewGuid().ToString("N").Substring(0, 8);

                    // Thêm dữ liệu vào CSDL
                    string insertQuery = "INSERT INTO NHOM_HANG (MA_NHOM_HH, TEN_NHOM, MA_LOAI_HH) VALUES (@maNhom, @tenNhom, @maLoai)";
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@maNhom", maNhom);
                        cmd.Parameters.AddWithValue("@tenNhom", tenNhom);
                        cmd.Parameters.AddWithValue("@maLoai", maLoai);

                        cmd.ExecuteNonQuery();
                    }

                    // Trả về tên nhóm mới cho form cha
                    this.TenNhomMoi = tenNhom;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu nhóm hàng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            //dong form
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
