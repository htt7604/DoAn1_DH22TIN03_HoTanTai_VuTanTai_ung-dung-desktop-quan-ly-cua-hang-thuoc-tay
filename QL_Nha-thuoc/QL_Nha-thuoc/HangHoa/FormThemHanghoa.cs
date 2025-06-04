using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa
{
    public partial class FormThemHanghoa : Form
    {
        public FormThemHanghoa(string loai)
        {
            InitializeComponent();
            this.Text = "Thêm " + loai;
        }

        // Load dữ liệu vào combobox Loại hàng
        private void LoadDataToComboBoxLoaiHanghoa()
        {
            try
            {
                using (SqlConnection conn = new CSDL().GetConnection())
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
                        comboBoxLoaiHang.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load loại hàng: " + ex.Message);
            }
        }

        // Load nhóm hàng theo loại hàng được chọn
        private void LoadDataToComboBoxNhomHanghoa()
        {
            if (comboBoxLoaiHang.SelectedItem is DataRowView selectedRow)
            {
                string maLoai = selectedRow["MA_LOAI_HH"].ToString();

                using (SqlConnection conn = new CSDL().GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT MA_NHOM_HH, TEN_NHOM 
                                     FROM NHOM_HANG 
                                     WHERE MA_LOAI_HH = @loaihang";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@loaihang", maLoai);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            comboBoxNhomHang.DataSource = dt;
                            comboBoxNhomHang.DisplayMember = "TEN_NHOM";
                            comboBoxNhomHang.ValueMember = "MA_NHOM_HH";
                            comboBoxNhomHang.SelectedIndex = -1;
                        }
                    }
                }
            }
        }

        private void comboBoxLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataToComboBoxNhomHanghoa();
        }

        // Load dữ liệu hãng sản xuất vào combobox
        private void LoadDataToComboboxHangSX()
        {
            try
            {
                using (SqlConnection conn = new CSDL().GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TEN_HANG_SX, MA_HANG_SX FROM HANG_SAN_XUAT";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataTable table = new DataTable();
                        da.Fill(table);
                        comboBoxHangSX.DataSource = table;
                        comboBoxHangSX.DisplayMember = "TEN_HANG_SX";
                        comboBoxHangSX.ValueMember = "MA_HANG_SX";
                        comboBoxHangSX.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load hãng sản xuất: " + ex.Message);
            }
        }

        // Load dữ liệu khi form khởi tạo
        private void FormThemHanghoa_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxLoaiHanghoa();
            LoadDataToComboboxHangSX();
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonThemHangSX_Click(object sender, EventArgs e)
        {
            var formThem = new FormThemHangSX();
            formThem.StartPosition = FormStartPosition.CenterParent;

            formThem.DuLieuDaThayDoi += (s, ev) =>
            {
                // Load lại danh sách hãng SX
                LoadDataToComboboxHangSX();

                // Tìm tên hãng vừa thêm và chọn nó
                string tenMoi = formThem.TenHangSXMoi;
                if (!string.IsNullOrEmpty(tenMoi))
                {
                    int index = comboBoxHangSX.FindStringExact(tenMoi);
                    if (index >= 0)
                    {
                        comboBoxHangSX.SelectedIndex = index;
                    }
                }
            };

            formThem.ShowDialog();
        }
    }
}
