using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.BanHang.TRA_HANG;
using QL_Nha_thuoc.GiaoDich.TraHang;
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
    public partial class TraHang : Form
    {
        private FormMain _formMain;
        public TraHang(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;
        }

        private void TraHang_Load(object sender, EventArgs e)
        {
            LoadDataGridViewTraHang();
        }

        private void LoadDataGridViewTraHang()
        {
            // Xóa dữ liệu cũ
            dataGridViewdsPhieuTraHang.Rows.Clear();
            dataGridViewdsPhieuTraHang.Columns.Clear();

            // Tạo các cột
            dataGridViewdsPhieuTraHang.Columns.Add("MaPhieuTraHang", "Mã phiếu trả");
            dataGridViewdsPhieuTraHang.Columns.Add("ThoiGian", "Thời gian");
            dataGridViewdsPhieuTraHang.Columns.Add("TenNhanVien", "Tên nhân viên");
            dataGridViewdsPhieuTraHang.Columns.Add("TenKhachHang", "Tên khách hàng");
            dataGridViewdsPhieuTraHang.Columns.Add("CanTra", "Cần trả");
            dataGridViewdsPhieuTraHang.Columns.Add("TrangThai", "Trạng thái");

            // Lấy danh sách phiếu trả hàng chưa xóa
            var listPhieuTra = ClassPhieuTraHang.LayTatCaPhieuTraHangKhacDaXoa();

            foreach (var phieu in listPhieuTra)
            {
                // Giả sử bạn có thể lấy tên NV và tên KH từ ID
                string tenNV = ClassNhanVien.LayNhanVienTheoMa(phieu.MaNhanVien).HoTenNhanVien;
                string tenKH = ClassKhachHang.LayThongTinKhachHangTheoMa(phieu.MaKhachHang).TenKH;

                dataGridViewdsPhieuTraHang.Rows.Add(
                    phieu.MaPhieuTraHang,
                    phieu.NgayLapPhieuTra.ToString("dd/MM/yyyy HH:mm"),
                    tenNV,
                    tenKH,
                    phieu.TienTraKhach,
                    phieu.TrangThaiPhieuTra
                );
            }
        }

        private FormBanHangMain formBanHangMain;
        private void buttonThemPhieuTra_Click(object sender, EventArgs e)
        {
            // Mở form thêm phiếu trả hàng
            if (formBanHangMain == null || formBanHangMain.IsDisposed)
            {
                formBanHangMain = new FormBanHangMain(_formMain);

                formBanHangMain.FormHidden += (s, args) =>
                {
                    this.Show();
                };
            }

            this.Hide();
            formBanHangMain.Show();
            formBanHangMain.BringToFront();
        }

        private void buttonChiTietPhieuTra_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có dòng nào được chọn không
            if (dataGridViewdsPhieuTraHang.SelectedRows.Count > 0)
            {
                // Lấy mã phiếu trả từ dòng được chọn
                string maPhieuTra = dataGridViewdsPhieuTraHang.SelectedRows[0].Cells["MaPhieuTraHang"].Value.ToString();
                // Tạo và hiển thị form chi tiết phiếu trả
                FormChiTietPhieuTra formChiTiet = new FormChiTietPhieuTra();
                ClassPhieuTraHang phieuTra = ClassPhieuTraHang.LayPhieuTraHangTheoMa(maPhieuTra);
                formChiTiet.SetData(phieuTra);
                formChiTiet.ShowDialog();
                // Sau khi đóng form chi tiết, tải lại dữ liệu
                formChiTiet.PhieuTraHangClosed += (s, args) =>
                {
                    LoadDataGridViewTraHang();
                };
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một phiếu trả để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LocPhieuTraHang()
        {

            string maPTNhap = textBoxTimPhieuTra .Text.Trim().ToLower();
            string trangThai = "";

            if (radioButtonDaHoanThanh.Checked) trangThai = "Đã hoàn thành";
            else if (radioButtonDaHuy.Checked) trangThai = "Đã hủy";
            // radioButtonTatCa => không lọc trạng thái

            // Lấy dữ liệu từ DB (hoặc từ ClassPhieuTraHang)
            var danhSach = ClassPhieuTraHang.LayTatCaPhieuTraHangKhacDaXoa();

            var ketQua = danhSach.AsEnumerable();

            // Lọc theo mã phiếu
            if (!string.IsNullOrEmpty(maPTNhap))
            {
                ketQua = ketQua.Where(pt => pt.MaPhieuTraHang.ToLower().Contains(maPTNhap));
            }


            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(trangThai))
            {
                ketQua = ketQua.Where(pt => pt.TrangThaiPhieuTra == trangThai);
            }

            // Xóa dữ liệu cũ
            dataGridViewdsPhieuTraHang.Rows.Clear();

            // Thêm lại dữ liệu mới
            foreach (var phieu in ketQua)
            {
                string tenNV = ClassNhanVien.LayNhanVienTheoMa(phieu.MaNhanVien).HoTenNhanVien;
                string tenKH = ClassKhachHang.LayThongTinKhachHangTheoMa(phieu.MaKhachHang).TenKH;

                dataGridViewdsPhieuTraHang.Rows.Add(
                    phieu.MaPhieuTraHang,
                    phieu.NgayLapPhieuTra.ToString("dd/MM/yyyy HH:mm"),
                    tenNV,
                    tenKH,
                    phieu.TienTraKhach,
                    phieu.TrangThaiPhieuTra
                );
            }
        }
        private void buttonTimKiem_Click(object sender, EventArgs e)
        {
            LocPhieuTraHang();
        }

        private void radioButtonTatCa_CheckedChanged(object sender, EventArgs e)
        {
            LocPhieuTraHang();
        }

        private void radioButtonDaHoanThanh_CheckedChanged(object sender, EventArgs e)
        {
            LocPhieuTraHang();
        }

        private void radioButtonDaHuy_CheckedChanged(object sender, EventArgs e)
        {
            LocPhieuTraHang();
        }


    }
}
