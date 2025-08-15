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
            string query = "SELECT TK.TEN_TAI_KHOAN, TK.MA_NV, NV.HO_TEN_NV, VT.TEN_VAI_TRO, TK.DA_XAC_THUC_EMAIL,TK.LAN_DAU_DANG_NHAP\r\n                FROM TAI_KHOAN TK \r\n                JOIN NHAN_VIEN NV ON TK.MA_NV = NV.MA_NV \r\n                JOIN VAI_TRO VT ON TK.MA_VAI_TRO = VT.MA_VAI_TRO\r\n                WHERE TK.MA_VAI_TRO <> 'QL'";

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

        private void dataGridViewdsNV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn hàng nào chưa
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Lấy dữ liệu từ hàng đã chọn
                DataGridViewRow selectedRow = dataGridViewdsNV.Rows[e.RowIndex];
                string maNhanVien = selectedRow.Cells["MA_NV"].Value.ToString();
                // Tạo một instance của ClassNhanVien để lấy thông tin nhân viên
                ClassNhanVien classNhanVien = ClassNhanVien.LayNhanVienTheoMa(maNhanVien);
                // Mở form sửa nhân viên và truyền dữ liệu
                FormSuaNhanVien formSuaNhanVien = new FormSuaNhanVien();
                formSuaNhanVien.Setdata(classNhanVien);
                //su kien form dong 
                formSuaNhanVien.FormDaDong += (s, args) =>
                {
                    // Khi form sửa nhân viên đóng, tải lại danh sách nhân viên
                    DSNhanVien_Load(sender, e);
                };
                formSuaNhanVien.ShowDialog();

            }
        }



        public static List<ClassNhanVien> TimNhanVien(string tuKhoa, string trangThai)
        {
            List<ClassNhanVien> danhSach = new List<ClassNhanVien>();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT * FROM NHAN_VIEN WHERE 1=1";

                if (!string.IsNullOrEmpty(tuKhoa))
                    query += " AND HO_TEN_NV LIKE @TuKhoa";

                if (!string.IsNullOrEmpty(trangThai))
                    query += " AND TRANG_THAI_NV = @TrangThai";

                SqlCommand cmd = new SqlCommand(query, conn);

                if (!string.IsNullOrEmpty(tuKhoa))
                    cmd.Parameters.AddWithValue("@TuKhoa", "%" + tuKhoa + "%");

                if (!string.IsNullOrEmpty(trangThai))
                    cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    danhSach.Add(new ClassNhanVien
                    {
                        MaNhanVien = reader["MA_NV"].ToString(),
                        HinhAnh = reader["HINH_ANH_NV"]?.ToString(),
                        HoTenNhanVien = reader["HO_TEN_NV"]?.ToString(),
                        DiaChi = reader["DIA_CHI_NV"]?.ToString(),
                        SoDienThoai = reader["SDT_NV"]?.ToString(),
                        SoCCCD = reader["SO_CCCD/CMND_NV"]?.ToString(),
                        NgaySinh = reader["NGAY_SINH_NV"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_SINH_NV"]),
                        GioiTinh = reader["GIOI_TINH_NV"]?.ToString(),
                        TrangThai = reader["TRANG_THAI_NV"]?.ToString(),
                        NgayBatDauLamViec = reader["NGAY_BAT_DAU_LAM_VIEC"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["NGAY_BAT_DAU_LAM_VIEC"]),
                        Email = reader["EMAIL"]?.ToString(),
                        Facebook = reader["FACEBOOK"]?.ToString()
                    });
                }

                reader.Close();
            }

            return danhSach;
        }

        private void textBoxTimNV_TextChanged(object sender, EventArgs e)
        {
            LocNhanVien();
        }

        private void radioButtonDangLV_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDangLV.Checked)
                LocNhanVien();
        }

        private void radioButtonDaNghi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDaNghi.Checked)
                LocNhanVien();
        }

        private void LocNhanVien()
        {
            string tuKhoa = textBoxTimNV.Text.Trim();
            string trangThai = "";

            if (radioButtonDangLV.Checked)
                trangThai = "Đang làm việc"; // giá trị này phải trùng với cột TRANG_THAI_NV trong DB
            else if (radioButtonDaNghi.Checked)
                trangThai = "Đã nghỉ";

            var ds = ClassNhanVien.TimNhanVien(tuKhoa, trangThai);
            dataGridViewdsNV.DataSource = ds;
        }

    }
}
