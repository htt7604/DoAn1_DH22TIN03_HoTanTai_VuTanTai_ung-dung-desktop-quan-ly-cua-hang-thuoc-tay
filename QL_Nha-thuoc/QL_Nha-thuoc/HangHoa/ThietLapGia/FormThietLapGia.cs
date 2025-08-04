
using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc.HangHoa.ThietLapGia;
using QL_Nha_thuoc.HangHoa.ThietLapGia.BangGia;
using QL_Nha_thuoc.HangHoa.ThietLapGia.BangGia.Sua;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QL_Nha_thuoc.HangHoa.ThietLapGia.BangGia.Sua.UserControlitemTLSuaBG;

namespace QL_Nha_thuoc.HangHoa
{
    public partial class FormThietLapGia : Form
    {
        // Lưu danh sách hiển thị sau khi lọc
        public List<ClassGiaBanHH> danhMucLoc = new List<ClassGiaBanHH>();
        public FormThietLapGia()
        {
            InitializeComponent();
            loadComboBoxLocVaLoaiGia();

        }
        //load comboBoxBangGia
        private void LoadComboBoxBangGia()
        {
            // Xóa sạch dữ liệu cũ
            comboBoxBangGia.DataSource = null;
            comboBoxBangGia.Items.Clear(); // (nên có thêm dòng này nếu bạn từng thêm item thủ công)

            // Lấy danh sách bảng giá mới
            var danhSachBangGia = ClassBangGia.LayTatCaBangGia();

            // Gán lại nguồn dữ liệu
            comboBoxBangGia.DataSource = danhSachBangGia;
            comboBoxBangGia.DisplayMember = "TenBangGia";
            comboBoxBangGia.ValueMember = "MaBangGia";
        }


        private void loadComboBoxLocVaLoaiGia()
        {
            comboBoxLoaiGia.Items.Add("--Giá so sánh---");
            comboBoxLoaiGia.Items.Add("Giá vốn");
            comboBoxLoaiGia.SelectedItem = "Giá vốn";
            comboBoxLoc.Items.Add("-");
            comboBoxLoc.Items.Add("<");
            comboBoxLoc.Items.Add(">");
            comboBoxLoc.Items.Add("=");
            comboBoxLoc.Items.Add("<=");
            comboBoxLoc.Items.Add(">=");
            comboBoxLoc.SelectedItem = ">";
        }

        private void loadcombobox_nhomhh()
        {
            CSDL cSDL = new CSDL();
            SqlConnection conn = CSDL.GetConnection();

            string query = @"
        SELECT DISTINCT NHOM_HANG.MA_NHOM_HH, NHOM_HANG.TEN_NHOM
        FROM NHOM_HANG
        JOIN LOAI_HANG ON NHOM_HANG.MA_LOAI_HH = LOAI_HANG.MA_LOAI_HH";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                DataRow row = dt.NewRow();
                row["MA_NHOM_HH"] = "ALL";
                row["TEN_NHOM"] = "Tất cả";
                dt.Rows.InsertAt(row, 0);

                comboBoxNhomHang.DataSource = dt;
                comboBoxNhomHang.DisplayMember = "TEN_NHOM";
                comboBoxNhomHang.ValueMember = "MA_NHOM_HH";
                comboBoxNhomHang.SelectedIndex = 0;
            }
        }
        //load don vi tinh
        private void LoadComboBoxDonViTinh()
        {
            using (SqlConnection conn = CSDL.GetConnection())
            {
                string query = "SELECT MA_DON_VI_TINH, TEN_DON_VI_TINH FROM DON_VI_TINH";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable rawTable = new DataTable();
                    adapter.Fill(rawTable);

                    // 👉 Tạo bảng mới với MA_DON_VI_TINH là string
                    DataTable dt = new DataTable();
                    dt.Columns.Add("MA_DON_VI_TINH", typeof(string));
                    dt.Columns.Add("TEN_DON_VI_TINH", typeof(string));

                    // ✅ Thêm dòng "Tất cả"
                    DataRow rowAll = dt.NewRow();
                    rowAll["MA_DON_VI_TINH"] = "ALL";
                    rowAll["TEN_DON_VI_TINH"] = "Tất cả";
                    dt.Rows.Add(rowAll);

                    // ✅ Copy dữ liệu từ rawTable sang dt (ép kiểu MA_DON_VI_TINH về string)
                    foreach (DataRow row in rawTable.Rows)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["MA_DON_VI_TINH"] = row["MA_DON_VI_TINH"].ToString();
                        newRow["TEN_DON_VI_TINH"] = row["TEN_DON_VI_TINH"].ToString();
                        dt.Rows.Add(newRow);
                    }

                    // ✅ Gán vào ComboBox
                    comboBoxDonViTinh.DataSource = dt;
                    comboBoxDonViTinh.DisplayMember = "TEN_DON_VI_TINH";
                    comboBoxDonViTinh.ValueMember = "MA_DON_VI_TINH";
                    comboBoxDonViTinh.SelectedIndex = 0;
                }
            }
        }


        private void CapNhatKichThuocUserControl()
        {
            int newWidth = flowLayoutPanelThietLapGia.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
            foreach (Control ctrl in flowLayoutPanelThietLapGia.Controls)
            {
                ctrl.Width = newWidth;
            }
        }

        private void flowLayoutPanelThietLapGia_SizeChanged(object sender, EventArgs e)
        {
            CapNhatKichThuocUserControl();
        }

        public List<ClassGiaBanHH> danhSachGiaBan = new List<ClassGiaBanHH>();



        public void FormThietLapGia_Load(object sender, EventArgs e)
        {
            loadcombobox_nhomhh();
            LoadComboBoxBangGia();
            LoadComboBoxDonViTinh();

            tableLayoutPanelTimKiem.Visible = false;
            panelKetQuaTimKiem.Visible = false;
            comboBoxDonViTinh.Visible = false;
            labelDVT.Visible = false;

            // Đặt giá trị mặc định cho các ComboBox
            comboBoxLoc.SelectedItem = "-";
            comboBoxLoaiGia.SelectedItem = "---Giá so sánh---";

            loctheogia();
            //danhSachGiaBan = ClassGiaBanHH.LayDanhSachToanboGiaBan();
            //danhMucLoc = danhSachGiaBan; // ✅ GÁN VÀO ĐÂY

            //flowLayoutPanelThietLapGia.Controls.Clear();
            //flowLayoutPanelThietLapGia.Controls.Add(new UserControlTTGia());

            //foreach (var giaBan in danhSachGiaBan)
            //{
            //    UserControlitemThietLapGia item = new UserControlitemThietLapGia();
            //    item.Setdata(giaBan);
            //    flowLayoutPanelThietLapGia.Controls.Add(item);
            //}

            //CapNhatKichThuocUserControl();
        }



        private void loctheogia()
        {
            string loaiGia = comboBoxLoaiGia.SelectedItem?.ToString() ?? string.Empty;
            string loc = comboBoxLoc.SelectedItem?.ToString() ?? string.Empty;
            string maNhomHangHoa = comboBoxNhomHang.SelectedValue?.ToString() ?? string.Empty;

            string maBangGia = comboBoxBangGia.SelectedValue?.ToString() ?? "BG0001";
            string tenBangGia = comboBoxBangGia.Text?.Trim().ToLower() ?? "";

            bool laBangGiaChung = tenBangGia.Contains("bảng giá chung") || maBangGia == "BG0001";

            bool isDefaultGia = string.IsNullOrWhiteSpace(loaiGia) || loaiGia.Contains("so sanh");
            bool isDefaultLoc = string.IsNullOrWhiteSpace(loc) || loc == "-";

            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            // ===== XỬ LÝ BẢNG GIÁ CHUNG =====
            if (laBangGiaChung)
            {
                // Luôn dùng BG0001
                danhSach = isDefaultGia || isDefaultLoc
                    ? ClassGiaBanHH.LayDanhSachGiaBanTheoBangGia("BG001")
                    : ClassGiaBanHH.LocGiaBanTheoKhoangGia(
                        ClassGiaBanHH.LayDanhSachGiaBanTheoBangGia("BG001"),
                        loc, loaiGia
                      );

                danhMucLoc = danhSach;

                flowLayoutPanelThietLapGia.Controls.Clear();
                flowLayoutPanelThietLapGia.Controls.Add(new UserControlTTGia());

                foreach (var giaBan in danhSach)
                {
                    var item = new UserControlitemThietLapGia();
                    item.Setdata(giaBan);
                    flowLayoutPanelThietLapGia.Controls.Add(item);
                }

                CapNhatKichThuocUserControl();
                return;
            }

            // ===== XỬ LÝ BẢNG GIÁ KHÁC =====
            if (maNhomHangHoa != "ALL")
            {
                danhSach = isDefaultGia || isDefaultLoc
                    ? ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom_BangGia(maNhomHangHoa, maBangGia)
                    : ClassGiaBanHH.LocGiaBanTheoKhoangGia(
                        ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom_BangGia(maNhomHangHoa, maBangGia),
                        loc, loaiGia
                      );
            }
            else
            {
                danhSach = isDefaultGia || isDefaultLoc
                    ? ClassGiaBanHH.LayDanhSachGiaBanTheoBangGia(maBangGia)
                    : ClassGiaBanHH.LocGiaBanTheoKhoangGia(
                        ClassGiaBanHH.LayDanhSachGiaBanTheoBangGia(maBangGia),
                        loc, loaiGia
                      );
            }

            danhMucLoc = danhSach;

            flowLayoutPanelThietLapGia.Controls.Clear();
            var userControlTTSuaGia = new UserControlTTSuaGia();
            userControlTTSuaGia.Setdata(tenBangGia);
            flowLayoutPanelThietLapGia.Controls.Add(userControlTTSuaGia);

            foreach (var giaBan in danhSach)
            {
                var item = new UserControlitemTLSuaBG();
                item.Setdata(giaBan);
                flowLayoutPanelThietLapGia.Controls.Add(item);

                item.ClickXoa += (s, e) =>
                {
                    if (e is XoaGiaBanEventArgs args)
                    {
                        ClassGiaBanHH.XoaGiaBanTheoMaHHVaBangGia(args.MaHangHoa, args.MaBangGia);
                        loctheogia(); // reload sau khi xoá
                    }
                };
            }

            CapNhatKichThuocUserControl();
        }








        private void comboBoxNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }





        private void comboBoxLoaiGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }

        private void comboBoxLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }


















        private void buttonThemBangGia_Click(object sender, EventArgs e)
        {
            //mo form them bang gia
            FormThemBangGia formThemBangGia = new FormThemBangGia();
            formThemBangGia.ShowDialog();
            formThemBangGia.FormThemBangGiaClosed += (s, args) =>
            {
                LoadComboBoxBangGia();
            };
        }

        private void comboBoxBangGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxBangGia.SelectedItem is ClassBangGia bangGia)
            {
                bool laBangGiaChung = (bangGia?.TenBangGia?.Trim() ?? "")
                    .Equals("Bảng giá chung", StringComparison.OrdinalIgnoreCase);

                // Ẩn/hiện các control theo loại bảng giá
                buttonSuaBangGia.Visible = !laBangGiaChung;
                tableLayoutPanelTimKiem.Visible = !laBangGiaChung;
                comboBoxDonViTinh.Visible = !laBangGiaChung;
                labelDVT.Visible = !laBangGiaChung;

                // Luôn ẩn kết quả tìm kiếm khi đổi bảng giá
                panelKetQuaTimKiem.Visible = false;

                // Gọi lọc dữ liệu
                loctheogia();
            }
        }



        private void buttonSuaBangGia_Click(object sender, EventArgs e)
        {
            if (comboBoxBangGia.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một bảng giá.");
                return;
            }

            ClassBangGia bangGiaDuocChon = comboBoxBangGia.SelectedItem as ClassBangGia;

            if (bangGiaDuocChon == null)
            {
                MessageBox.Show("Lỗi: không thể đọc thông tin bảng giá.");
                return;
            }

            if (bangGiaDuocChon.TenBangGia == "Bảng giá chung")
            {
                MessageBox.Show("Không thể sửa Bảng giá chung.");
                return;
            }

            // Lấy thông tin bảng giá đầy đủ từ CSDL nếu cần (nếu chưa đầy đủ)
            ClassBangGia classBangGia = ClassBangGia.LayBangGiaTheoMa(bangGiaDuocChon.MaBangGia);

            if (classBangGia == null)
            {
                MessageBox.Show("Không tìm thấy thông tin bảng giá.");
                return;
            }

            // Mở form sửa bảng giá và truyền dữ liệu
            FormSuaBangGia formSuaBangGia = new FormSuaBangGia();
            formSuaBangGia.Setdata(classBangGia);
            formSuaBangGia.FormSuaBangGiaClosed += (s, args) =>
            {
                LoadComboBoxBangGia();
            };

            formSuaBangGia.ShowDialog();
        }

























        private void ThucHienTimKiem()
        {
            //luu maBangGia dang chon 
            string maBangGia = comboBoxBangGia.SelectedValue?.ToString();

            string keyword = textBoxTimHH.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            // Lấy bảng giá
            var selectedBangGia = comboBoxBangGia.SelectedItem as ClassBangGia;
            //string maBangGia = selectedBangGia?.MaBangGia ?? "BG0001";

            // Lấy mã đơn vị tính đang chọn
            string maDonViTinh = donViTinhChon;

            // Gọi tìm kiếm
            var ds = ClassHangHoa.TimKiemHangHoa(keyword, maDonViTinh);

            // Hiển thị kết quả
            panelKetQuaTimKiem.Controls.Clear();
            int y = 0;
            foreach (var hangHoa in ds)
            {
                var ucHH = new UserControlitemHangHoaTimKiem();
                ucHH.SetData(hangHoa);
                ucHH.Width = panelKetQuaTimKiem.Width;
                ucHH.Location = new Point(0, y);
                y += ucHH.Height + 10;


                ucHH.ClickVaoHangHoa += (s, e) =>
                {
                    var item = s as UserControlitemHangHoaTimKiem;
                    var data = item.LayDuLieu(); // ClassHangHoa

                    // Tạo đối tượng giá bán
                    var giaBan = new ClassGiaBanHH
                    {
                        MaBangGia = maBangGia,
                        MaHangHoa = data.MaHangHoa,
                        GiaBan = data.GiaBan,
                        GiaVon = data.GiaVon,
                        MaDonViTinh = data.MaDonViTinh,
                        TenDonViTinh=data.TenDonViTinh,
                        LaPhanTram = false,
                        TangGiam = false,
                        GiaTriTangGiam = 0
                    };
                    using (SqlConnection conn = CSDL.GetConnection())
                    {
                        conn.Open();
                        using (SqlTransaction tran = conn.BeginTransaction())
                        {
                            bool daCo = ClassGiaBanHH.DaTonTai(maBangGia, data.MaHangHoa, conn, tran);

                            if (daCo)
                            {
                                tran.Rollback();
                                MessageBox.Show("Hàng hóa này đã có trong bảng giá!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                var kq = ClassGiaBanHH.ThemGiaBan(giaBan, conn, tran);
                                if (kq)
                                {
                                    tran.Commit();
                                    loctheogia();
                                    

                                }
                                else
                                {
                                    tran.Rollback();
                                    MessageBox.Show("Thêm giá bán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    panelKetQuaTimKiem.Visible = false;

                    loctheogia();
                    panelKetQuaTimKiem.Visible = false;
                };






                panelKetQuaTimKiem.Controls.Add(ucHH);
            }
        }

        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            ThucHienTimKiem();
        }



        private string donViTinhChon = "ALL"; // Biến lưu mã đơn vị tính đã chọn

        private void comboBoxDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDonViTinh.SelectedItem is DataRowView drv)
            {
                donViTinhChon = drv["MA_DON_VI_TINH"].ToString();
                ThucHienTimKiem(); // Gọi lại tìm kiếm khi đổi DVT
            }
        }


    }
}
