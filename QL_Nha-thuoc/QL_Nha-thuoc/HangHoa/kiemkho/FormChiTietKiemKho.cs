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

namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    public partial class FormChiTietKiemKho : Form
    {
        private string maPhieuKiem;

        public FormChiTietKiemKho(string maPhieuKiem)
        {
            InitializeComponent();
            this.maPhieuKiem = maPhieuKiem;
        }
        //ham load du lieu
        private void LoadChiTietPhieuKiemKho()
        {
            // 1. Load dữ liệu phiếu kiểm
            var thongTinPhieu = ClassPhieuKiemKho.LayPhieuKiemKho(maPhieuKiem);

            if (thongTinPhieu != null)
            {
                // Gán dữ liệu vào TextBox
                textBoxMaKiemKho.Text = thongTinPhieu.MaPhieuKiem;
                textBoxNguoiTao.Text = thongTinPhieu.PhieuKiemKho.TenNhanVien;
                textBoxTrangThai.Text = thongTinPhieu.PhieuKiemKho.TrangThaiPhieuKiem;
                textBoxGhiChu.Text = thongTinPhieu.PhieuKiemKho.GhiChu;
                if (thongTinPhieu.PhieuKiemKho.NgayKiemKho.HasValue)
                {
                    textBoxThoiGianKiemKho.Text = thongTinPhieu.PhieuKiemKho.NgayKiemKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    textBoxThoiGianKiemKho.Text = "";
                }
                //thoi gian can bang kho 
                if (thongTinPhieu.PhieuKiemKho.ThoiGianCanBangKho.HasValue)
                {
                    textBoxThoiGianCanBang.Text = thongTinPhieu.PhieuKiemKho.ThoiGianCanBangKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    textBoxThoiGianCanBang.Text = "";
                }
            }

            // 2. Load chi tiết phiếu vào DataGridView
            List<ChiTietPhieuKiemKho> chiTietList = ChiTietPhieuKiemKho.LayChiTietPhieuKiemKho(maPhieuKiem);

            var table = new DataTable();
            table.Columns.Add("Mã hàng hóa");
            table.Columns.Add("Số lượng hệ thống", typeof(int));
            table.Columns.Add("Số lượng thực tế", typeof(int));
            table.Columns.Add("Chênh lệch", typeof(int));
            table.Columns.Add("Ghi chú");

            foreach (var ct in chiTietList)
            {
                int chenhLech = ct.SoLuongThucTe - ct.SoLuongHeThong;
                table.Rows.Add(ct.MaHangHoa, ct.SoLuongHeThong, ct.SoLuongThucTe, chenhLech, ct.GhiChu);
            }

            dataGridViewdsTTPhieuKiemKho.DataSource = table;
            dataGridViewdsTTPhieuKiemKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void FormChiTietKiemKho_Load_1(object sender, EventArgs e)
        {
            LoadChiTietPhieuKiemKho();
        }
    }
}
