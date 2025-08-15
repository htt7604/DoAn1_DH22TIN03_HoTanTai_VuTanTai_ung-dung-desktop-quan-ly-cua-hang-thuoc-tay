using Microsoft.Data.SqlClient;
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
            FormBanHangMain formBanHangMain = new FormBanHangMain(formMain);
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











        private void LocHoaDon()
        {

            string maHTTT = null;
            if (radioButtonTienMat.Checked) maHTTT = "HTTT_TM";
            else if (radioButtonChuyenKhoan.Checked) maHTTT = "HTTT_CK";

            string maHD = textBoxTimHD.Text.Trim().ToLower();

            using (SqlConnection conn = CSDL.GetConnection())
            {
                var sb = new StringBuilder(@"
            SELECT 
                HD.MA_HOA_DON                         AS [Mã hóa đơn],
                HD.NGAY_LAP_HD                        AS [Ngày lập],
                NV.HO_TEN_NV                          AS [Nhân viên],
                ISNULL(HD.KHACH_THANH_TOAN, 0)        AS [Khách thanh toán],
                ISNULL(HD.THANH_TIEN, 0)              AS [Thành tiền],
                ISNULL(HD.GIAM_GIA, 0)                AS [Giảm giá],
                ISNULL(HD.TRA_LAI_KHACH, 0)           AS [Trả lại khách],
                HD.TRANG_THAI                         AS [Trạng thái]
            FROM HOA_DON HD
            JOIN NHAN_VIEN NV ON NV.MA_NV = HD.MA_NV
            WHERE HD.TRANG_THAI <> N'Đã hủy'

        ");

                if (!string.IsNullOrEmpty(maHD))
                    sb.Append(" AND LOWER(HD.MA_HOA_DON) LIKE @MaHD");

                if (!string.IsNullOrEmpty(maHTTT))
                    sb.Append(" AND HD.MA_HINH_THUC_THANH_TOAN = @MaHTTT");

                sb.Append(" ORDER BY HD.NGAY_LAP_HD DESC");

                using (SqlCommand cmd = new SqlCommand(sb.ToString(), conn))
                {

                    if (!string.IsNullOrEmpty(maHD))
                        cmd.Parameters.AddWithValue("@MaHD", "%" + maHD + "%");

                    if (!string.IsNullOrEmpty(maHTTT))
                        cmd.Parameters.AddWithValue("@MaHTTT", maHTTT);

                    var table = new DataTable();
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(table);

                    dataGridViewdsHoaDon.AutoGenerateColumns = true;
                    dataGridViewdsHoaDon.DataSource = table;

                    if (dataGridViewdsHoaDon.Columns.Contains("Ngày lập"))
                        dataGridViewdsHoaDon.Columns["Ngày lập"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
        }


        private void buttonTim_Click(object sender, EventArgs e)
        {
            LocHoaDon();
        }



        private void radioButtonTienMat_CheckedChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void radioButtonChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            LocHoaDon();
        }
    }
}
