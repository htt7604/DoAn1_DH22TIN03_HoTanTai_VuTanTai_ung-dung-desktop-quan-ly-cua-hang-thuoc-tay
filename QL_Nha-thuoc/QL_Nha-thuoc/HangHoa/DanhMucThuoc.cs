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
    public partial class DanhMucThuoc : Form
    {
        public DanhMucThuoc()
        {
            InitializeComponent();
        }


        //ham load danh sách thuốc từ cơ sở dữ liệu
        private void LoadDanhSachThuoc()
        {
            CSDL csdl = new CSDL();
            string connectionString = csdl.GetConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM HANG_HOA join NHOM_HANG on NHOM_HANG.MA_NHOM_HH=HANG_HOA.MA_NHOM_HH join LOAI_HANG on LOAI_HANG.MA_LOAI_HH=NHOM_HANG.MA_LOAI_HH where LOAI_HANG.MA_LOAI_HH='T'  "; // Thay đổi tên bảng nếu cần
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewdsThuoc.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách thuốc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void DanhMucThuoc_Load(object sender, EventArgs e)
        {
            //load danh sách thuốc từ cơ sở dữ liệu 
            LoadThuocTinhComboBox();
            LoadDanhSachThuoc(); // Gọi hàm để tải danh sách thuốc
        }
       

        public class ThuocTinhHienThi
        {
            public string GiaTri { get; set; }    // Tên cột trong CSDL
            public string HienThi { get; set; }   // Tên hiển thị trong ComboBox

            public override string ToString()
            {
                return HienThi;  // ComboBox sẽ hiển thị giá trị này
            }
        }


        private void LoadThuocTinhComboBox()
        {
            // Danh sách giá trị và tên hiển thị được truyền sẵn
            List<ThuocTinhHienThi> danhSachThuocTinh = new List<ThuocTinhHienThi>
            {
                //new ThuocTinhHienThi { GiaTri = "MA_HANG_HOA", HienThi = "Mã hàng hóa" },
                new ThuocTinhHienThi { GiaTri = "TEN_HANG_HOA", HienThi = "Tên hàng hóa" },
                new ThuocTinhHienThi { GiaTri = "MA_THUOC", HienThi = "Mã thuốc" },
                new ThuocTinhHienThi { GiaTri = "SO_DANG_KY_THUOC", HienThi = "Số đăng ký" },
                new ThuocTinhHienThi { GiaTri = "LOAI_THUOC", HienThi = "Loại thuốc" },
                // Thêm nếu cần
            };

            comboBoxLoaiTimKiem.Items.Clear();
            comboBoxLoaiTimKiem.Items.AddRange(danhSachThuocTinh.ToArray());

            if (comboBoxLoaiTimKiem.Items.Count > 0)
                comboBoxLoaiTimKiem.SelectedIndex = 0;
        }



        private string LayCotTimKiem()
        {
            if (comboBoxLoaiTimKiem.SelectedItem is ThuocTinhHienThi thuocTinh)
            {
                return thuocTinh.GiaTri;  // Ví dụ: "MA_HANG_HOA"
            }

            return null;
        }

        private void comboBoxLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxTimThuoc.PlaceholderText = "Tim kiem theo " + comboBoxLoaiTimKiem.SelectedItem.ToString();
        }


        //hàm thực hiện tìm kiếm thuốc trong cơ sở dữ liệu
        private void TimKiemThuoc(string cotTimKiem, string giaTriTimKiem)
        {
            CSDL csdl = new CSDL();
            string connectionString = csdl.GetConnection().ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = $"SELECT * FROM HANG_HOA join NHOM_HANG on NHOM_HANG.MA_NHOM_HH=HANG_HOA.MA_NHOM_HH join LOAI_HANG on LOAI_HANG.MA_LOAI_HH=NHOM_HANG.MA_LOAI_HH where LOAI_HANG.MA_LOAI_HH='T' and {cotTimKiem} LIKE @GiaTriTimKiem";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@GiaTriTimKiem", "%" + giaTriTimKiem + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        // Hiển thị kết quả tìm kiếm trong DataGridView hoặc xử lý theo nhu cầu
                        dataGridViewdsThuoc.DataSource = dataTable;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //ham tim kiem theo trang thai tim kiem va gia tri nhap vao textBoxTimThuoc
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            string cotTimKiem = LayCotTimKiem();
            string giaTriTimKiem = textBoxTimThuoc.Text.Trim();
            if (string.IsNullOrEmpty(cotTimKiem) || string.IsNullOrEmpty(giaTriTimKiem))
            {
                //MessageBox.Show("Vui lòng chọn loại tìm kiếm và nhập giá trị cần tìm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoadDanhSachThuoc(); // Nếu không có giá trị tìm kiếm, tải lại danh sách thuốc
                return;
            }
            // Thực hiện tìm kiếm trong cơ sở dữ liệu
            TimKiemThuoc(cotTimKiem, giaTriTimKiem);
        }









    }
}
