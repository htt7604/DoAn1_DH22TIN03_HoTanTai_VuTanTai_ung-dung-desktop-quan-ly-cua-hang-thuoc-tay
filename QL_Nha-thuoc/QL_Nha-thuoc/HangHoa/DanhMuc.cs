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
            SqlConnection conn = CSDL.GetConnection(); // Lấy chuỗi kết nối từ lớp CSDL
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
            // Tạo cột checkbox đầu tiên
            DataGridViewCheckBoxColumn colCheck = new DataGridViewCheckBoxColumn();
            colCheck.Name = "";
            colCheck.Width = 50;

            // Custom header có checkbox
            var header = new DatagridViewCheckBoxHeaderCell();
            colCheck.HeaderCell = header;

            dataGridViewdsDMHH.Columns.Insert(0, colCheck);

            // Gắn sự kiện khi click vào header checkbox
            header.OnCheckAllChanged += (isChecked) =>
            {
                dataGridViewdsDMHH.EndEdit(); // <<== Dừng edit dòng hiện tại (có thể đang chọn)

                foreach (DataGridViewRow row in dataGridViewdsDMHH.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        row.Cells[""].Value = isChecked;
                    }
                }
            };

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
            SqlConnection conn = CSDL.GetConnection();

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
         SELECT HH.MA_HANG_HOA,HH.TEN_HANG_HOA ,HH.TEN_VIET_TAT,GHH.GIA_BAN_HH,GHH.GIA_VON_HH,HH.TON_KHO,HH.THOI_GIAN_TAO FROM HANG_HOA HH
         JOIN NHOM_HANG NH  ON NH.MA_NHOM_HH = HH.MA_NHOM_HH 
         JOIN LOAI_HANG LH ON LH.MA_LOAI_HH = NH.MA_LOAI_HH 
         JOIN GIA_HANG_HOA GHH ON HH.MA_HANG_HOA = GHH.MA_HANG_HOA
         WHERE  HH.MA_HANG_HOA NOT LIKE '%_DELETED'  ");

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
                query.Append($" AND LH.TEN_LOAI_HH IN ({string.Join(", ", placeholders)}) ");
            }

            if (!string.IsNullOrEmpty(nhomHang))
            {
                query.Append(" AND NH.MA_NHOM_HH = @nhomHang ");
                parameters.Add("@nhomHang", nhomHang);
            }

            // Chỉ thêm điều kiện trạng thái khi khác null
            if (!string.IsNullOrEmpty(trangThai))
            {
                query.Append(" AND HH.TINH_TRANG_HH = @trangThai ");
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
            SqlConnection conn = CSDL.GetConnection();

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

                    dataGridViewdsDMHH.Columns["MA_HANG_HOA"].HeaderText = "Mã hàng hóa";
                    dataGridViewdsDMHH.Columns["TEN_HANG_HOA"].HeaderText = "Tên hàng hóa";
                    dataGridViewdsDMHH.Columns["TEN_VIET_TAT"].HeaderText = "Tên viết tắt";
                    dataGridViewdsDMHH.Columns["GIA_BAN_HH"].HeaderText = "Giá bán";
                    dataGridViewdsDMHH.Columns["GIA_VON_HH"].HeaderText = "Giá vốn";
                    dataGridViewdsDMHH.Columns["TON_KHO"].HeaderText = "Tồn kho";
                    dataGridViewdsDMHH.Columns["THOI_GIAN_TAO"].HeaderText = "Ngày tạo";

                    //them su kien click vao checkbox cua datagitview

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
                string maHH = selectedRow.Cells["MA_HANG_HOA"].Value?.ToString();

                // Lấy giá trị MA_LOAI_HH từ dòng
                //string maLoaiHH = selectedRow.Cells["MA_LOAI_HH"].Value?.ToString();
                ClassHangHoa hanghoa = ClassHangHoa.LayThongTinMotHangHoa(maHH);
                string maLoaiHH = hanghoa.MaLoaiHangHoa; // Lấy mã loại hàng từ đối tượng ClassHangHoa
                if (maLoaiHH == "HH") // Nếu là hàng hóa
                {
                    //string maDVT = selectedRow.Cells["MA_DON_VI_TINH"].Value?.ToString();
                    string maDVT = hanghoa.MaDonViTinh; // Lấy mã đơn vị tính từ đối tượng ClassHangHoa
                    if (!string.IsNullOrEmpty(maHH))
                    {
                        //// Mở form chi tiết hàng hóa                      
                        // Truyền tham chiếu this vào form chi tiết
                        var formChiTiet = new ChitietHangHoa(maHH, maDVT);
                        formChiTiet.FormClosed += (s, args) => Getthongtinhanghoa(); // Load lại danh sách khi form chi tiết đóng
                        formChiTiet.ShowDialog();
                    }
                }
                else
                {
                    //string maDVT = selectedRow.Cells["MA_DON_VI_TINH"].Value?.ToString();
                    string maDVT = hanghoa.MaDonViTinh; // Lấy mã đơn vị tính từ đối tượng ClassHangHoa

                    if (!string.IsNullOrEmpty(maHH))
                    {
                        // Mở form chi tiết hàng hóa
                        FormChiTietThuoc formChiTietthuoc = new FormChiTietThuoc(maHH, maDVT);
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
            SqlConnection conn = CSDL.GetConnection();
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

        private void LoadThemTuSQL()
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
            panelThemHH.Visible = false;
            isDropDownOpenHH = false;

            string tenForm = ConvertTenLoaiToTenForm(tenLoai);
            string namespaceName = this.GetType().Namespace;
            string fullTypeName = namespaceName + "." + tenForm;

            Type formType = Type.GetType(fullTypeName);

            if (formType != null)
            {
                // Tạo callback reload lại danh sách sau khi form đóng
                Action onReload = () =>
                {
                    Getthongtinhanghoa(); // hoặc bất kỳ hàm nào bạn muốn gọi lại
                };

                // Khởi tạo form với 2 tham số: string, Action
                Form f = (Form)Activator.CreateInstance(formType, tenLoai, onReload);
                f.StartPosition = FormStartPosition.CenterParent;
                f.ShowDialog(this);
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
            string connectionString = CSDL.GetConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GBHH.GIA_BAN_HH, HH.HINH_ANH_HH, HH.TON_KHO FROM HANG_HOA HH JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA  WHERE HH.MA_HANG_HOA NOT LIKE '%_DELETED' AND  HH.TEN_HANG_HOA LIKE @keyword";
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
            foreach (var thuoc in ds)
            {
                var uc = new UC_ItemThuoc();
                uc.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia, thuoc.hinhanhhh, thuoc.SoLuongTon);
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

        private void buttonTuyChon_Click(object sender, EventArgs e)
        {
            panelTuyChon.Visible = !panelTuyChon.Visible; // Hiển thị hoặc ẩn panel tùy chọn
        }


        private void CapNhatSoLuongDaChon()
        {
            int soLuongChon = 0;

            foreach (DataGridViewRow row in dataGridViewdsDMHH.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    soLuongChon++;
                }
            }

            if (soLuongChon > 0)
            {
                labelSoX.Text = $"Đã chọn {soLuongChon}";
                labelSoX.Visible = true;
                buttonXoa.Visible = true;
                buttonX.Visible = true;
                buttonTuyChon.Visible = true; // Hiển thị nút tùy chọn
            }
            else
            {
                labelSoX.Text = "";
                labelSoX.Visible = false;
                buttonXoa.Visible = false;
                buttonX.Visible = false;
                buttonTuyChon.Visible = false; // Ẩn nút tùy chọn
                panelTuyChon.Visible = false; // Ẩn panel tùy chọn
            }
        }
        private void dataGridViewdsDMHH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Cột checkbox
            {
                bool isChecked = Convert.ToBoolean(dataGridViewdsDMHH.Rows[e.RowIndex].Cells[0].Value);
                //string maHH = dataGridViewdsDMHH.Rows[e.RowIndex].Cells["Mã hàng hóa"].Value?.ToString();

                CapNhatSoLuongDaChon();
            }
        }

        private void dataGridViewdsDMHH_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewdsDMHH.IsCurrentCellDirty)
            {
                dataGridViewdsDMHH.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewdsDMHH.Rows)
            {
                row.Cells[0].Value = false; // Bỏ tích checkbox ở cột đầu tiên
            }

            // Ẩn các thành phần liên quan đến việc chọn
            labelSoX.Text = "";
            labelSoX.Visible = false;
            buttonXoa.Visible = false;
            buttonX.Visible = false;
            buttonTuyChon.Visible = false; // Ẩn nút tùy chọn
            panelTuyChon.Visible = false; // Ẩn panel tùy chọn
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            bool coDongDuocChon = false;

            // Kiểm tra xem có hàng nào được chọn (checkbox) không
            foreach (DataGridViewRow row in dataGridViewdsDMHH.Rows)
            {
                if (Convert.ToBoolean(row.Cells[""].Value) == true)
                {
                    coDongDuocChon = true;
                    break;
                }
            }

            if (!coDongDuocChon)
            {
                MessageBox.Show("Vui lòng chọn ít nhất một hàng để xóa.");
                return;
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa các hàng đã chọn không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                // Duyệt ngược để tránh lỗi khi xóa dòng trong DataGridView
                for (int i = dataGridViewdsDMHH.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = dataGridViewdsDMHH.Rows[i];

                    if (Convert.ToBoolean(row.Cells[""].Value) == true)
                    {
                        string maHangHoa = row.Cells["MA_HANG_HOA"].Value?.ToString();
                        if (!string.IsNullOrEmpty(maHangHoa))
                        {
                            ClassHangHoa.XoaHangHoa(maHangHoa, Session.TaiKhoanDangNhap.MaNhanVien); // Xóa trong DB
                        }

                        dataGridViewdsDMHH.Rows.RemoveAt(i); // Xóa trong giao diện
                    }
                }

                // Cập nhật lại danh sách hàng hóa
                Getthongtinhanghoa();
                labelSoX.Text = "";
                labelSoX.Visible = false;
                buttonXoa.Visible = false;
                buttonX.Visible = false;
                buttonTuyChon.Visible = false; // Ẩn nút tùy chọn
                panelTuyChon.Visible = false; // Ẩn panel tùy chọn
            }
            else
            {
                panelTuyChon.Visible = false; // Ẩn panel tùy chọn nếu không xóa
            }
            }

        private void buttonNhapHang_Click(object sender, EventArgs e)
        {

        }


    }
}
