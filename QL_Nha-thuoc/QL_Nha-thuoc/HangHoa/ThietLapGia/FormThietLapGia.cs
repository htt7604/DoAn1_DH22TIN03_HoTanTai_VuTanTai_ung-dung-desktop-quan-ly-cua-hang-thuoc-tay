//using Microsoft.Data.SqlClient;
//using QL_Nha_thuoc.HangHoa.kiemkho;
//using QL_Nha_thuoc.HangHoa.ThietLapGia;
//using QL_Nha_thuoc.model;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace QL_Nha_thuoc.HangHoa
//{
//    public partial class FormThietLapGia : Form
//    {
//        public FormThietLapGia()
//        {
//            InitializeComponent();
//        }
//        //load du lieu vao 2 comboBoxLoc va comboBoxLoaiGia
//        private void loadComboBoxLocVaLoaiGia()
//        {
//            comboBoxLoaiGia.Items.Add("--Gia so sanh---");
//            comboBoxLoaiGia.Items.Add("Gia von");
//            comboBoxLoaiGia.SelectedItem = "Gia von"; // hoặc "Gia so sanh"
//            //comboBoxLoaiGia.Items.Add("Giá ban");
//            comboBoxLoc.Items.Add("-");
//            comboBoxLoc.Items.Add("<");
//            comboBoxLoc.Items.Add(">");
//            comboBoxLoc.Items.Add("=");
//            comboBoxLoc.Items.Add("<=");
//            comboBoxLoc.Items.Add(">=");
//            comboBoxLoc.SelectedItem = ">"; // chọn mặc định là >

//        }
//        //load comboBoxnhomhanghoa
//        private void loadcombobox_nhomhh()
//        {
//            CSDL cSDL = new CSDL();
//            SqlConnection conn = cSDL.GetConnection();

//            string query = @"
//        SELECT DISTINCT NHOM_HANG.MA_NHOM_HH, NHOM_HANG.TEN_NHOM
//        FROM NHOM_HANG
//        JOIN LOAI_HANG ON NHOM_HANG.MA_LOAI_HH = LOAI_HANG.MA_LOAI_HH";

//            using (SqlCommand cmd = new SqlCommand(query, conn))
//            {
//                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
//                DataTable dt = new DataTable();
//                adapter.Fill(dt);

//                // ✅ Thêm dòng "Tất cả nhóm hàng hóa"
//                DataRow row = dt.NewRow();
//                row["MA_NHOM_HH"] = "ALL";             // Giá trị đặc biệt
//                row["TEN_NHOM"] = "Tất cả";
//                dt.Rows.InsertAt(row, 0);              // Thêm vào đầu

//                comboBoxNhomHang.DataSource = dt;
//                comboBoxNhomHang.DisplayMember = "TEN_NHOM";
//                comboBoxNhomHang.ValueMember = "MA_NHOM_HH";
//                comboBoxNhomHang.SelectedIndex = 0;    // Chọn dòng "Tất cả" mặc định
//            }
//        }




//        private void CapNhatKichThuocUserControl()
//        {
//            int newWidth = flowLayoutPanelThietLapGia.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 10;
//            int y = 0; // Biến để theo dõi vị trí Y của các control

//            foreach (Control ctrl in flowLayoutPanelThietLapGia.Controls)
//            {
//                ctrl.Width = newWidth;
//            }
//        }

//        private void flowLayoutPanelThietLapGia_SizeChanged(object sender, EventArgs e)
//        {
//            CapNhatKichThuocUserControl();

//        }
//        //load form

//        //khai bao bien luu danh sach dang hien thi 
//        public List<ClassGiaBanHH> danhSachGiaBan = new List<ClassGiaBanHH>();

//        public void FormThietLapGia_Load(object sender, EventArgs e)
//        {
//            loadcombobox_nhomhh(); // Gọi hàm để load dữ liệu vào ComboBox nhóm hàng hóa
//            loadComboBoxLocVaLoaiGia(); // Gọi hàm để load dữ liệu vào ComboBox lọc và loại giá

//            // Lấy danh sách toàn bộ giá bán từ CSDL
//            danhSachGiaBan = ClassGiaBanHH.LayDanhSachToanboGiaBan();

//            // Xóa các control cũ nếu có
//            flowLayoutPanelThietLapGia.Controls.Clear();

//            // Thêm header nếu cần (nếu là tiêu đề)
//            UserControlTTGia userControlTTGia = new UserControlTTGia();
//            flowLayoutPanelThietLapGia.Controls.Add(userControlTTGia);

//            // Duyệt danh sách và thêm từng UserControl vào FlowLayoutPanel
//            foreach (var giaBan in danhSachGiaBan)
//            {
//                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
//                item.Setdata(giaBan); // Gán dữ liệu vào UserControl
//                flowLayoutPanelThietLapGia.Controls.Add(item);
//            }

//            // Cập nhật lại kích thước các UserControl ngay khi load
//            CapNhatKichThuocUserControl();
//        }



//        public List<ClassGiaBanHH> danhSachGiaBanLocNhom = new List<ClassGiaBanHH>();
//        private void comboBoxNhomHang_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            string maNhomHangHoa = comboBoxNhomHang.SelectedValue?.ToString() ?? string.Empty;
//            List<ClassGiaBanHH> danhSach = (maNhomHangHoa == "ALL")
//                ? danhSachGiaBan
//                : danhSachGiaBanLocNhom = ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom(maNhomHangHoa);
//            // Xóa các control cũ nếu có
//            flowLayoutPanelThietLapGia.Controls.Clear();

//            // Thêm header nếu cần (nếu là tiêu đề)
//            UserControlTTGia userControlTTGia = new UserControlTTGia();
//            flowLayoutPanelThietLapGia.Controls.Add(userControlTTGia);

//            // Duyệt danh sách và thêm từng UserControl vào FlowLayoutPanel
//            foreach (var giaBan in danhSachGiaBanLocNhom)
//            {
//                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
//                item.Setdata(giaBan); // Gán dữ liệu vào UserControl
//                flowLayoutPanelThietLapGia.Controls.Add(item);
//            }

//            // Cập nhật lại kích thước các UserControl ngay khi load
//            CapNhatKichThuocUserControl();
//        }



//        //hien thi cac UserControl theo loai gia va loc
//        private void loctheogia()
//        {
//            string loaiGia = comboBoxLoaiGia.SelectedItem?.ToString() ?? string.Empty;
//            string loc = comboBoxLoc.SelectedItem?.ToString() ?? string.Empty;
//            string maNhomHangHoa = comboBoxNhomHang.SelectedValue?.ToString() ?? string.Empty;
//            List<ClassGiaBanHH> danhSach = (maNhomHangHoa == "ALL")
//                ? danhSachGiaBanLocNhom
//                : ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom(maNhomHangHoa);

//            // Không truyền giá, vì sẽ so sánh hai loại giá
//            List<ClassGiaBanHH> danhSachGiaBanLoc = ClassGiaBanHH.LocGiaBanTheoKhoangGia(danhSach, loc, loaiGia);

//            flowLayoutPanelThietLapGia.Controls.Clear();
//            flowLayoutPanelThietLapGia.Controls.Add(new UserControlTTGia());
//            foreach (var giaBan in danhSachGiaBanLoc)
//            {
//                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
//                item.Setdata(giaBan);
//                flowLayoutPanelThietLapGia.Controls.Add(item);
//            }
//            CapNhatKichThuocUserControl();
//        }


//        private void comboBoxLoaiGia_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            loctheogia();
//        }

//        private void comboBoxLoc_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            loctheogia();
//        }



//    }
//}



using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa.kiemkho;
using QL_Nha_thuoc.HangHoa.ThietLapGia;
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

        private void loadComboBoxLocVaLoaiGia()
        {
            comboBoxLoaiGia.Items.Add("--Gia so sanh---");
            comboBoxLoaiGia.Items.Add("Gia von");
            comboBoxLoaiGia.SelectedItem = "Gia von";
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
            SqlConnection conn = cSDL.GetConnection();

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

            comboBoxLoc.SelectedItem = "-"; // Chọn mặc định là "-"
            comboBoxLoaiGia.SelectedItem = "---Gia so sanh---"; // Chọn mặc định là "Gia von"

            danhSachGiaBan = ClassGiaBanHH.LayDanhSachToanboGiaBan();

            flowLayoutPanelThietLapGia.Controls.Clear();
            flowLayoutPanelThietLapGia.Controls.Add(new UserControlTTGia());

            foreach (var giaBan in danhSachGiaBan)
            {
                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
                item.Setdata(giaBan);
                flowLayoutPanelThietLapGia.Controls.Add(item);
            }

            CapNhatKichThuocUserControl();
        }

        private void comboBoxNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }

        private void loctheogia()
        {
            string loaiGia = comboBoxLoaiGia.SelectedItem?.ToString() ?? string.Empty;
            string loc = comboBoxLoc.SelectedItem?.ToString() ?? string.Empty;
            string maNhomHangHoa = comboBoxNhomHang.SelectedValue?.ToString() ?? string.Empty;

            bool isDefaultGia = string.IsNullOrWhiteSpace(loaiGia) || loaiGia.Contains("so sanh");
            bool isDefaultLoc = string.IsNullOrWhiteSpace(loc) || loc == "-";

            List<ClassGiaBanHH> danhSach = new List<ClassGiaBanHH>();

            if (maNhomHangHoa != "ALL")
            {
                if (isDefaultGia || isDefaultLoc)
                {
                    danhSach = ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom(maNhomHangHoa);
                }
                else
                {
                    var danhSachNhom = ClassGiaBanHH.LayDanhSachGiaBanTheoMaNhom(maNhomHangHoa);
                    danhSach = ClassGiaBanHH.LocGiaBanTheoKhoangGia(danhSachNhom, loc, loaiGia);
                }
            }
            else
            {
                if (isDefaultGia || isDefaultLoc)
                {
                    danhSach = danhSachGiaBan;
                }
                else
                {
                    danhSach = ClassGiaBanHH.LocGiaBanTheoKhoangGia(danhSachGiaBan, loc, loaiGia);
                }
            }

            // ✅ Gán danh sách hiển thị vào biến lưu trữ
            danhMucLoc = danhSach;

            flowLayoutPanelThietLapGia.Controls.Clear();
            flowLayoutPanelThietLapGia.Controls.Add(new UserControlTTGia());

            foreach (var giaBan in danhSach)
            {
                UserControlitemThietLapGia item = new UserControlitemThietLapGia();
                item.Setdata(giaBan);
                flowLayoutPanelThietLapGia.Controls.Add(item);
            }

            CapNhatKichThuocUserControl();
        }


        private void comboBoxLoaiGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }

        private void comboBoxLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loctheogia();
        }
    }
}
