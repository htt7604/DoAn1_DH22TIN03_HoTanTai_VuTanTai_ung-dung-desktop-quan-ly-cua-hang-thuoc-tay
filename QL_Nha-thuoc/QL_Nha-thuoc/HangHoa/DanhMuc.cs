using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace QL_Nha_thuoc
{
    public partial class DanhMuc : Form
    {
        public DanhMuc()
        {
            InitializeComponent();
        }
        // Hàm lấy dữ liệu từ SQL
        List<string> LayDanhSachLoaiHang()
        {
            List<string> loaiHangList = new List<string>();

            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection(); // Lấy chuỗi kết nối từ lớp CSDL
            string query = "SELECT TEN_LOAI_HH FROM LOAI_HANG";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    loaiHangList.Add(reader.GetString(0));
                }
            }

            return loaiHangList;
        }





        void LoadCheckBoxTuSQL()
        {
            List<string> dsLoaiHang = LayDanhSachLoaiHang();

            panelLoaiHang.Controls.Clear(); // xóa cũ

            for (int i = 0; i < dsLoaiHang.Count; i++)
            {
                CheckBox cb = new CheckBox();
                cb.Text = dsLoaiHang[i];
                cb.AutoSize = true;
                cb.Location = new Point(10, i * 25 + 5);
                cb.CheckedChanged += CheckBox_CheckedChanged; // Thêm event
                panelLoaiHang.Controls.Add(cb);
            }
        }



        //ham load form
        private void DanhMuc_Load(object sender, EventArgs e)
        {
            LoadCheckBoxTuSQL();
            radioButtonTatCa.Checked = true; // Mặc định chọn "Tất cả"
            panelLoaiHang.Visible = false; // ẩn panel loại hàng khi load form
            panelThemHH.Visible = false; // ẩn panel thêm hàng hóa khi load form
            panelThemHH.BringToFront();
            panelKetQuaTimKiem.Visible = false; // ẩn panel kết quả tìm kiếm khi load form

        }

        bool isDropDownOpen = false;
        private void buttonLoaiHang_Click(object sender, EventArgs e)
        {
            isDropDownOpen = !isDropDownOpen;
            panelLoaiHang.Visible = isDropDownOpen;
        }


        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {

            List<string> loaiHangDuocChon = new List<string>();

            foreach (Control ctl in panelLoaiHang.Controls)
            {
                if (ctl is CheckBox cb && cb.Checked)
                {
                    loaiHangDuocChon.Add(cb.Text);
                }
            }

            // Cập nhật DataGridView theo loại hàng
            //HienThiHangHoaTheoLoai(loaiHangDuocChon);
            Getthongtinhanghoa();

            // Cập nhật ComboBox nhóm hàng theo loại hàng đã chọn
            loadcombobox_nhomhh(loaiHangDuocChon);
        }



        //load loai hàng vào comboboxNhomHang
        private void loadcombobox_nhomhh(List<string> loaiHangDuocChon)
        {

            if (loaiHangDuocChon.Count == 0)
            {
                comboBoxNhomHH.DataSource = null;
                return;
            }

            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();

            string inClause = string.Join(",", loaiHangDuocChon.Select((s, i) => $"@loai{i}"));
            string query = $@"
        SELECT DISTINCT NHOM_HANG.MA_NHOM_HH, NHOM_HANG.TEN_NHOM
        FROM NHOM_HANG
        JOIN LOAI_HANG ON NHOM_HANG.MA_LOAI_HH = LOAI_HANG.MA_LOAI_HH
        WHERE LOAI_HANG.TEN_LOAI_HH IN ({inClause}) ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                for (int i = 0; i < loaiHangDuocChon.Count; i++)
                {
                    cmd.Parameters.AddWithValue($"@loai{i}", loaiHangDuocChon[i]);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                comboBoxNhomHH.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    comboBoxNhomHH.DisplayMember = "TEN_NHOM";
                    comboBoxNhomHH.ValueMember = "MA_NHOM_HH";
                    comboBoxNhomHH.SelectedIndex = -1;
                }
                else
                {
                    comboBoxNhomHH.DataSource = null;
                }

            }

        }

        private void comboBoxNhomHH_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cập nhật DataGridView với dữ liệu mới
            Getthongtinhanghoa();
        }






        //ham lay tt 
        private (List<string> loaiHangDuocChon, string nhomHang, string trangThai) LayThongTinLoc()
        {
            List<string> loaiHangDuocChon = new List<string>();
            string nhomHang = null;
            string trangThai = null;

            // Lấy loại hàng từ checkbox
            foreach (Control ctl in panelLoaiHang.Controls)
            {
                if (ctl is CheckBox cb && cb.Checked)
                {
                    loaiHangDuocChon.Add(cb.Text);
                }
            }

            // Lấy nhóm hàng
            if (comboBoxNhomHH.SelectedValue != null)
            {
                nhomHang = comboBoxNhomHH.SelectedValue.ToString();
            }

            // Lấy trạng thái nếu có
            if (radioButtonDangKinhDoanh.Checked)
            {
                trangThai = radioButtonDangKinhDoanh.Text;
            }
            else if (radioButtonNgungKinhDoanh.Checked)
            {
                trangThai = radioButtonNgungKinhDoanh.Text;
            }
            else if (radioButtonTatCa.Checked)
            {
                trangThai = null;  // Tức là không lọc theo trạng thái, hiện tất cả
            }
            else
            {
                trangThai = null;
            }

            return (loaiHangDuocChon, nhomHang, trangThai);
        }





        //cau sql
        private string TaoCauTruyVanLoc(List<string> loaiHangDuocChon, string nhomHang, string trangThai, out Dictionary<string, object> parameters)
        {
            StringBuilder query = new StringBuilder(@"
        SELECT * FROM HANG_HOA 
        JOIN NHOM_HANG ON NHOM_HANG.MA_NHOM_HH = HANG_HOA.MA_NHOM_HH 
        JOIN LOAI_HANG ON LOAI_HANG.MA_LOAI_HH = NHOM_HANG.MA_LOAI_HH 
        JOIN GIA_HANG_HOA ON HANG_HOA.MA_HANG_HOA = GIA_HANG_HOA.MA_HANG_HOA
        WHERE 1=1 ");

            parameters = new Dictionary<string, object>();

            if (loaiHangDuocChon != null && loaiHangDuocChon.Count > 0)
            {
                List<string> placeholders = new List<string>();
                for (int i = 0; i < loaiHangDuocChon.Count; i++)
                {
                    string paramName = "@loaiHang" + i;
                    placeholders.Add(paramName);
                    parameters.Add(paramName, loaiHangDuocChon[i]);
                }
                query.Append($" AND LOAI_HANG.TEN_LOAI_HH IN ({string.Join(", ", placeholders)}) ");
            }

            if (!string.IsNullOrEmpty(nhomHang))
            {
                query.Append(" AND NHOM_HANG.MA_NHOM_HH = @nhomHang ");
                parameters.Add("@nhomHang", nhomHang);
            }

            // Chỉ thêm điều kiện trạng thái khi khác null
            if (!string.IsNullOrEmpty(trangThai))
            {
                query.Append(" AND HANG_HOA.TINH_TRANG_HH = @trangThai ");
                parameters.Add("@trangThai", trangThai);
            }

            return query.ToString();
        }




        private void AddParametersToCommand(SqlCommand cmd, Dictionary<string, object> parameters)
        {
            foreach (var param in parameters)
            {
                cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
            }
        }



        //lay thong tin hang hoa dua vao datagridview 
        private void Getthongtinhanghoa()
        {
            var (loaiHangDuocChon, nhomHang, trangThai) = LayThongTinLoc();

            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();

            Dictionary<string, object> parameters;
            string query = TaoCauTruyVanLoc(loaiHangDuocChon, nhomHang, trangThai, out parameters);

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                try
                {
                    conn.Open();
                    AddParametersToCommand(cmd, parameters);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dataGridViewdsDMHH.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void radioButtonDangKinhDoanh_CheckedChanged(object sender, EventArgs e)
        {
            //gọi hàm lấy thông tin hàng hóa khi trạng thái kinh doanh thay đổi
            Getthongtinhanghoa();
        }

        private void radioButtonNgungKinhDoanh_CheckedChanged(object sender, EventArgs e)
        {
            // Gọi hàm lấy thông tin hàng hóa khi trạng thái kinh doanh thay đổi
            Getthongtinhanghoa();
        }

        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            // Gọi hàm lấy thông tin hàng hóa khi trạng thái kinh doanh thay đổi
            Getthongtinhanghoa();
        }


        private void dataGridViewdsDMHH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra chỉ click vào dòng hợp lệ (không phải tiêu đề)
            if (e.RowIndex >= 0)
            {
                // Lấy dòng vừa click
                DataGridViewRow selectedRow = dataGridViewdsDMHH.Rows[e.RowIndex];

                // Lấy giá trị MA_LOAI_HH từ dòng
                string maLoaiHH = selectedRow.Cells["MA_LOAI_HH"].Value?.ToString();
                if (maLoaiHH == "HH") // Nếu là hàng hóa
                {
                    string maHH = selectedRow.Cells["MA_HANG_HOA"].Value?.ToString();
                    string maDVT = selectedRow.Cells["MA_DON_VI_TINH"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maHH))
                    {
                        //// Mở form chi tiết hàng hóa                      
                        // Truyền tham chiếu this vào form chi tiết
                        var formChiTiet = new ChitietHangHoa(maHH,maDVT);
                        formChiTiet.FormClosed += (s, args) => Getthongtinhanghoa(); // Load lại danh sách khi form chi tiết đóng
                        formChiTiet.ShowDialog();
                    }
                }
                else
                {
                    string maHH = selectedRow.Cells["MA_HANG_HOA"].Value?.ToString();
                    string maDVT = selectedRow.Cells["MA_DON_VI_TINH"].Value?.ToString();

                    if (!string.IsNullOrEmpty(maHH))
                    {
                        // Mở form chi tiết hàng hóa
                        FormChiTietThuoc formChiTietthuoc = new FormChiTietThuoc(maHH,maDVT);
                        formChiTietthuoc.FormClosed += (s, args) => Getthongtinhanghoa(); // Load lại danh sách khi form chi tiết đóng
                        formChiTietthuoc.ShowDialog(); // Mở modal                  
                    }
                }
            }
        }










        List<string> LayDanhSachLoaiHangThem()
        {
            List<string> loaiHangList = new List<string>();

            CSDL cSDL = new CSDL();
            SqlConnection conn = cSDL.GetConnection();
            string query = "SELECT TEN_LOAI_HH FROM LOAI_HANG";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    loaiHangList.Add(reader.GetString(0));
                }
            }

            return loaiHangList;
        }

        void LoadThemTuSQL()
        {
            List<string> dsLoaiHang = LayDanhSachLoaiHangThem();

            panelThemHH.Controls.Clear(); // Xóa các controls cũ

            int y = 5;
            foreach (string tenLoai in dsLoaiHang)
            {
                Button btn = new Button();
                btn.Text = tenLoai;
                btn.Size = new Size(150, 30);
                btn.Location = new Point(10, y);
                btn.Click += (s, e) => ButtonThemLoaiHang_Click(tenLoai); // Gọi sự kiện khi nhấn button
                panelThemHH.Controls.Add(btn);
                y += 35;
            }
        }







        private string ConvertTenLoaiToTenForm(string tenLoai)
        {
            string formName = RemoveDiacritics(tenLoai); // bỏ dấu tiếng Việt
            formName = formName.Replace(" ", "");         // bỏ khoảng trắng
            return "HangHoa.FormThem" + formName;
        }

        // Bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        // Sự kiện xử lý khi người dùng nhấn vào button loại hàng
        private void ButtonThemLoaiHang_Click(string tenLoai)
        {
            // Hoặc thực hiện hành động thêm hàng hóa ứng với loại này
            panelThemHH.Visible = false;
            isDropDownOpenHH = false;

            string tenForm = ConvertTenLoaiToTenForm(tenLoai);
            string namespaceName = this.GetType().Namespace; // Lấy namespace hiện tại
            string fullTypeName = namespaceName + "." + tenForm;

            Type formType = Type.GetType(fullTypeName);

            if (formType != null)
            {
                Form f = (Form)Activator.CreateInstance(formType, tenLoai);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this); // Mở modal, chặn thao tác form cha
            }
            else
            {
                MessageBox.Show("Không tìm thấy form có tên: " + tenForm);
            }

        }

        bool isDropDownOpenHH = false;

        private void buttonThemHH_Click(object sender, EventArgs e)
        {
            LoadThemTuSQL(); // Tải lại danh sách loại hàng
            isDropDownOpenHH = !isDropDownOpenHH;
            panelThemHH.Visible = isDropDownOpenHH;
        }



        public class Thuoc
        {
            public string Ma { get; set; }
            public string Ten { get; set; }
            public float Gia { get; set; }
            public string hinhanhhh { get; set; }
            public int SoLuongTon { get; set; }  // Thêm dòng này
        }


        //tim thuoc
        List<Thuoc> TimThuocTuCSDL(string keyword)
        {
            var ketQua = new List<Thuoc>();

            CSDL cSDL = new CSDL();
            string connectionString = cSDL.GetConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GBHH.GIA_BAN_HH, HH.HINH_ANH_HH, HH.TON_KHO FROM HANG_HOA HH JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA  WHERE TEN_HANG_HOA LIKE @keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var t = new Thuoc
                            {
                                Ma = reader["MA_HANG_HOA"].ToString(),
                                Ten = reader["TEN_HANG_HOA"].ToString(),
                                Gia = Convert.ToInt32(reader["GIA_BAN_HH"]),
                                hinhanhhh = reader["HINH_ANH_HH"].ToString(),
                                SoLuongTon = Convert.ToInt32(reader["TON_KHO"])
                            };
                            ketQua.Add(t);
                        }
                    }
                }
            }

            return ketQua;
        }


        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            //hien kết quả tìm kiếm
            panelKetQuaTimKiem.Visible = true;
            string keyword = textBoxTimHH.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var ds = TimThuocTuCSDL(keyword);

            panelKetQuaTimKiem.Controls.Clear();
            int y = 0;

            //foreach (var thuoc in ds)
            //{
            //    var uc = new UC_ItemThuoc(); // UserControl như mình hướng dẫn ở trên
            //    uc.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia,thuoc.hinhanhhh);
            //    uc.Width = panelKetQuaTimKiem.Width;
            //    uc.Location = new Point(0, y);
            //    y += uc.Height + 10;
            //    panelKetQuaTimKiem.Controls.Add(uc);
            //}

            //panelKetQuaTimKiem.Visible = ds.Count > 0;


            foreach (var thuoc in ds)
            {
                var uc = new UC_ItemThuoc();
                uc.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia, thuoc.hinhanhhh,thuoc.SoLuongTon);
                uc.Width = panelKetQuaTimKiem.Width;
                uc.Location = new Point(0, y);
                y += uc.Height + 10;

                // Gắn sự kiện Click mở form chi tiết
                uc.Click += (s, e) =>
                {
                    var clickedUC = (UC_ItemThuoc)s;
                    string maHH = clickedUC.MaHangHoa;

                    // Mở form chi tiết thuốc
                    ChitietHangHoa formChiTiet = new ChitietHangHoa(maHH);
                    formChiTiet.ShowDialog();
                };

                panelKetQuaTimKiem.Controls.Add(uc);
            }

        }
    }
}
