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

namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    public partial class FormChonHDTraHang : Form
    {
        public FormChonHDTraHang()
        {
            InitializeComponent();
        }


        // trong class FormChonHDTraHang
        public event Action<ClassHoaDon>? ThemMoiTraHang;
        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridViewHoaDon.Columns[e.ColumnIndex].Name == "Chon")
            {
                string maHoaDon = dataGridViewHoaDon.Rows[e.RowIndex].Cells["MaHoaDon"].Value?.ToString();
                if (!string.IsNullOrEmpty(maHoaDon))
                {
                    var hoaDon = ClassHoaDon.LayHoaDonTheoMa(maHoaDon);
                    if (hoaDon != null)
                    {
                        // Gọi event để thông báo Form cha (FormBanHangMain)
                        ThemMoiTraHang?.Invoke(hoaDon);

                        // Đóng form sau khi chọn (bạn cũng đã có logic này, giữ lại)
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hóa đơn với mã: " + maHoaDon, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void FormChonHDTraHang_Load(object sender, EventArgs e)
        {
            var danhsachHD = ClassHoaDon.LayDanhSachHoaDon();
            //them dữ liệu vào DataGridView
            //tao cot dataGridView
            dataGridViewHoaDon.Columns.Add("MaHoaDon", "Mã Hóa Đơn");
            dataGridViewHoaDon.Columns.Add("Thoigian", "Thời gian");
            dataGridViewHoaDon.Columns.Add("NhanVien", "Nhân viên ");
            dataGridViewHoaDon.Columns.Add("KhachHang", "khách hàng ");
            dataGridViewHoaDon.Columns.Add("TongCong", "Tổng cộng");
            //thêm dữ liệu vào DataGridView
            foreach (var hd in danhsachHD)
            {
                dataGridViewHoaDon.Rows.Add(hd.MaHoaDon, hd.NgayLapHD, hd.TenNhanVien, hd.TenKhachHang, hd.ThanhTien);
            }
            DataGridViewButtonColumn btnChon = new DataGridViewButtonColumn();
            btnChon.Name = "Chon";
            btnChon.HeaderText = "";
            btnChon.Text = "Chọn";
            btnChon.UseColumnTextForButtonValue = true;

            // Style nổi bật
            btnChon.DefaultCellStyle.BackColor = Color.OrangeRed; // màu nền
            btnChon.DefaultCellStyle.ForeColor = Color.White;      // màu chữ
            btnChon.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);


            dataGridViewHoaDon.Columns.Add(btnChon);

            dataGridViewHoaDon.CellContentClick += dataGridViewHoaDon_CellContentClick;

            dateTimePickerTuNgay.Value = DateTime.Now.AddDays(-7);
        }

        private void buttonTImKiem_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các control
            string maHoaDon = textBoxMaHoaDon.Text.Trim().ToLower();
            DateTime tuNgay = dateTimePickerTuNgay.Value.Date;
            DateTime denNgay = dateTimePickerDenNgay.Value.Date;
            string maHangHoa = textBoxMaHangHoa.Text.Trim().ToLower();
            string tenKhachHang = textBoxKhachHang.Text.Trim().ToLower();

            // Lấy toàn bộ danh sách hóa đơn
            var danhSachHD = ClassHoaDon.LayDanhSachHoaDon();

            // Lọc theo điều kiện
            var ketQua = danhSachHD
                .Where(hd =>
                    (string.IsNullOrEmpty(maHoaDon) || hd.MaHoaDon.ToLower().Contains(maHoaDon)) &&
                    (hd.NgayLapHD.HasValue && hd.NgayLapHD.Value.Date >= tuNgay && hd.NgayLapHD.Value.Date <= denNgay) &&
                    (string.IsNullOrEmpty(tenKhachHang) || (!string.IsNullOrEmpty(hd.TenKhachHang) && hd.TenKhachHang.ToLower().Contains(tenKhachHang))) &&
                    (string.IsNullOrEmpty(maHangHoa) || hd.ChiTietHoaDon.Any(ct => ct.MaHangHoa.ToLower().Contains(maHangHoa)))
                )
                .ToList();

            // Hiển thị lại kết quả trong DataGridView
            dataGridViewHoaDon.Rows.Clear();
            foreach (var hd in ketQua)
            {
                dataGridViewHoaDon.Rows.Add(
                    hd.MaHoaDon,
                    hd.NgayLapHD?.ToString("dd/MM/yyyy HH:mm"),
                    hd.TenNhanVien,
                    hd.TenKhachHang,
                    hd.ThanhTien
                );
            }
        }

    }
}
