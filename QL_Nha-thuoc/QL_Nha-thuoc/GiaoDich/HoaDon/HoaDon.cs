using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.GiaoDich.HoaDon;
using QL_Nha_thuoc.HangHoa.kiemkho;
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

namespace QL_Nha_thuoc
{
    public partial class HoaDon : Form
    {
        private FormMain formMain;
        public HoaDon(FormMain main)
        {
            InitializeComponent();
            formMain = main;
        }

        private void LoadHoaDon()
        {
            List<ClassHoaDon> danhSach = ClassHoaDon.LayDanhSachHoaDon();

            // Tạo bảng DataTable để bind vào DataGridView
            DataTable table = new DataTable();
            table.Columns.Add("Mã hóa đơn");
            table.Columns.Add("Ngày lập");
            table.Columns.Add("Nhân viên");
            table.Columns.Add("Khách thanh toán", typeof(decimal));
            table.Columns.Add("Thành tiền", typeof(decimal));
            table.Columns.Add("Giảm giá", typeof(decimal));
            table.Columns.Add("Trả lại khách", typeof(decimal));
            table.Columns.Add("Trạng thái");

            foreach (var hd in danhSach)
            {
                table.Rows.Add(
                    hd.MaHoaDon,
                    hd.NgayLapHD?.ToString("dd/MM/yyyy HH:mm"),
                    hd.TenNhanVien,
                    hd.KhachThanhToan ?? 0,
                    hd.ThanhTien ?? 0,
                    hd.GiamGia ?? 0,
                    hd.TienTraKhach ?? 0,
                    hd.TrangThai
                );
            }

            dataGridViewdsHoaDon.DataSource = table;
        }

        private void buttonThemHoaDon_Click(object sender, EventArgs e)
        {
            //tat form main 
            this.Hide();
            //mở form bán hàng
            FormBanHangMain formBanHangMain = new FormBanHangMain();
            formBanHangMain.ShowDialog();
            //hiện lại form main
            this.Show();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {

            LoadHoaDon();
        }

        private void dataGridViewdsHoaDon_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewdsHoaDon.Rows.Count)
            {
                DataGridViewRow row = dataGridViewdsHoaDon.Rows[e.RowIndex];
                string maHoaDon = row.Cells["Mã hóa đơn"].Value.ToString();

                FormChiTietHoaDon chiTietForm = new FormChiTietHoaDon(maHoaDon, formMain);
                // GÁN SỰ KIỆN TRƯỚC KHI SHOW
                chiTietForm.FormDong += () =>
                {
                    //LoadDanhSachPhieuKiemKho(); // Cập nhật lại danh sách phiếu
                };

                chiTietForm.ShowDialog(); // Gọi sau khi gán sự kiện
            }
        }
    }
}
