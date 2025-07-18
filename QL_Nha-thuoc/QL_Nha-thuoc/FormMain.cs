using QL_Nha_thuoc;
using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.model;
using QL_Nha_thuoc.NhanVien;
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
using QL_Nha_thuoc.ThongKeTongquan;
using QL_Nha_thuoc.DoiTac;



namespace QL_Nha_thuoc
{
    public partial class FormMain : Form
    {

        public void LoadFormVaoPanel(Form formCon)
        {
            panelMain.Controls.Clear();                // Xóa control cũ nếu có
            formCon.TopLevel = false;                  // Bắt buộc khi đưa form vào panel
            formCon.FormBorderStyle = FormBorderStyle.None;
            formCon.Dock = DockStyle.Fill;

            panelMain.Controls.Add(formCon);
            formCon.Show();
        }



        public FormMain()
        {
            InitializeComponent();

            if (Session.TaiKhoanDangNhap != null)
            {
                toolStripTextBoxTaiKhoan.Text = Session.TaiKhoanDangNhap.TenTaiKhoan;
            }
            else
            {
                toolStripTextBoxTaiKhoan.Text = "Chưa đăng nhập";
            }
        }



        private void danhSáchNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DSNhanVien dsNhanVien = new DSNhanVien();
            dsNhanVien.TopLevel = false;
            dsNhanVien.FormBorderStyle = FormBorderStyle.None;
            dsNhanVien.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(dsNhanVien);
            dsNhanVien.Show();
        }

        private void thiếtLậpNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thietlap_NVcs thietlap_NVcs = new Thietlap_NVcs();
            thietlap_NVcs.TopLevel = false;
            thietlap_NVcs.FormBorderStyle = FormBorderStyle.None;
            thietlap_NVcs.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(thietlap_NVcs);
            thietlap_NVcs.Show();
        }

        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMuc danhMuc = new DanhMuc();
            danhMuc.TopLevel = false;
            danhMuc.FormBorderStyle = FormBorderStyle.None;
            danhMuc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(danhMuc);
            danhMuc.Show();
        }

        private void danhMụcThuốcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhMucThuoc danhMucThuoc = new DanhMucThuoc();
            danhMucThuoc.TopLevel = false;
            danhMucThuoc.FormBorderStyle = FormBorderStyle.None;
            danhMucThuoc.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(danhMucThuoc);
            danhMucThuoc.Show();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //tat form main 
            this.Hide();
            //mở form bán hàng
            FormBanHangMain formBanHangMain = new FormBanHangMain();
            formBanHangMain.ShowDialog();
            //hiện lại form main
            this.Show();
        }

        private void kiemKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mo form kiem kho
            KiemKho kiemKho = new KiemKho();
            kiemKho.TopLevel = false;
            kiemKho.FormBorderStyle = FormBorderStyle.None;
            kiemKho.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(kiemKho);
            kiemKho.Show();

            // Load form KiemKho vào panel chính
            KiemKho formKiemKho = new KiemKho(this);
            LoadFormVaoPanel(formKiemKho);
        }

        private void thiếtLậpGiáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mo form ThietLapGia
            FormThietLapGia formThietLapGia = new FormThietLapGia();
            formThietLapGia.TopLevel = false;
            formThietLapGia.FormBorderStyle = FormBorderStyle.None;
            formThietLapGia.Dock = DockStyle.Fill;

            panelMain.Controls.Clear();
            panelMain.Controls.Add(formThietLapGia);
            // Hiển thị form ThietLapGia
            //formThietLapGia.ShowDialog(); // Nếu bạn muốn mở dưới dạng dialog

            formThietLapGia.Show();

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //them form tong quan vao panel chính
            FormTongQuan formTongQuan = new FormTongQuan();
            formTongQuan.TopLevel = false; // Đặt TopLevel là false để có thể nhúng vào panel
            formTongQuan.FormBorderStyle = FormBorderStyle.None; // Không có viền cửa sổ
            formTongQuan.Dock = DockStyle.Top;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formTongQuan); // Thêm form vào panel
            formTongQuan.Show(); // Hiển thị form trong panel
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //them form hoa don vao panel chính
            HoaDon formHoaDon = new HoaDon();
            formHoaDon.TopLevel = false; // Đặt TopLevel là false để có thể nhúng vào panel
            formHoaDon.FormBorderStyle = FormBorderStyle.None; // Không có viền cửa sổ
            formHoaDon.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian panel
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formHoaDon); // Thêm form vào panel
            formHoaDon.Show();

        }

        private void trảHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraHang traHang = new TraHang();
            traHang.TopLevel = false;
            traHang.FormBorderStyle = FormBorderStyle.None;
            traHang.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(traHang);
            traHang.Show();

        }

        private void nhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NhapHang nhapHang = new NhapHang(this); // truyền chính FormMain
            nhapHang.TopLevel = false;
            nhapHang.FormBorderStyle = FormBorderStyle.None;
            nhapHang.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(nhapHang);
            nhapHang.Show();
        }

        private void trảNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TraNhapHang traNhapHang = new TraNhapHang();
            traNhapHang.TopLevel = false;
            traNhapHang.FormBorderStyle = FormBorderStyle.None;
            traNhapHang.Dock = DockStyle.Fill;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(traNhapHang);
            traNhapHang.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mo form KhachHang
            FormKhachHang formKhachHang = new FormKhachHang();
            formKhachHang.TopLevel = false; // Đặt TopLevel là false để có thể nhúng vào panel
            formKhachHang.FormBorderStyle = FormBorderStyle.None; // Không có viền cửa sổ
            formKhachHang.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian panel
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formKhachHang); // Thêm form vào panel
            formKhachHang.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //them form tong quan vao panel chính
            FormTongQuan formTongQuan = new FormTongQuan();
            formTongQuan.TopLevel = false; // Đặt TopLevel là false để có thể nhúng vào panel
            formTongQuan.FormBorderStyle = FormBorderStyle.None; // Không có viền cửa sổ
            formTongQuan.Dock = DockStyle.Top;
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formTongQuan); // Thêm form vào panel
            formTongQuan.Show(); // Hiển thị form trong panel
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mo form NhaCungCap
            FormNhaCungCap formNhaCungCap = new FormNhaCungCap();
            formNhaCungCap.TopLevel = false; // Đặt TopLevel là false để có thể nhúng vào panel
            formNhaCungCap.FormBorderStyle = FormBorderStyle.None; // Không có viền cửa sổ
            formNhaCungCap.Dock = DockStyle.Fill; // Đặt Dock để chiếm toàn bộ không gian panel
            panelMain.Controls.Clear();
            panelMain.Controls.Add(formNhaCungCap); // Thêm form vào panel
            formNhaCungCap.Show(); // Hiển thị form trong panel
        }
    }
}
