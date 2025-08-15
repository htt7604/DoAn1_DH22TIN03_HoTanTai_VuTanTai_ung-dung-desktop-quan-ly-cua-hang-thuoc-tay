using QL_Nha_thuoc.model;
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

namespace QL_Nha_thuoc.GiaoDich.TraHang
{
    public partial class FormChiTietPhieuTra : Form
    {
        public FormChiTietPhieuTra()
        {
            InitializeComponent();
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]


        public void SetData(ClassPhieuTraHang classPhieuTraHang)
        {
            // Hiển thị thông tin phiếu trả
            labelMaPhieuTra.Text = classPhieuTraHang.MaPhieuTraHang;
            labelThoiGian.Text = classPhieuTraHang.NgayLapPhieuTra.ToString("dd/MM/yyyy HH:mm");
            labelKhachHang.Text = ClassKhachHang.LayThongTinKhachHangTheoMa(classPhieuTraHang.MaKhachHang).TenKH;
            labelBangGia.Text = classPhieuTraHang.MaBangGia;
            labelmaHoaDon.Text = classPhieuTraHang.MaHoaDon;
            labelTrangThai.Text = classPhieuTraHang.TrangThaiPhieuTra;
            labelTenNguoiNhanTra.Text = ClassNhanVien.LayNhanVienTheoMa(classPhieuTraHang.MaNhanVien).HoTenNhanVien.ToString() ?? "";
            labelMaPhieuChi.Text = ClassPhieuThuChi.LayDanhSachPhieuThuChi()
                .FirstOrDefault(p => p.MaPhieuTraHang == classPhieuTraHang.MaPhieuTraHang)?.MaPhieuThuChi ?? "Chưa có";
            labelNguoiTao.Text = ClassNhanVien.LayNhanVienTheoMa(classPhieuTraHang.MaNhanVien).HoTenNhanVien.ToString() ?? "Chưa có";
            textBoxGhiChu.Text = classPhieuTraHang.GhiChuPhieuTra ?? string.Empty;



            //tao cot cho bang chi tite 
            dataGridViewChiTietPhieuTra.Columns.Clear();
            dataGridViewChiTietPhieuTra.Columns.Add("MaSanPham", "Mã hàng hóa");
            dataGridViewChiTietPhieuTra.Columns.Add("TenSanPham", "Tên sản phẩm");
            dataGridViewChiTietPhieuTra.Columns.Add("SoLuong", "Số lượng");
            dataGridViewChiTietPhieuTra.Columns.Add("GiaTraHang", "Giá nhập lại");
            dataGridViewChiTietPhieuTra.Columns.Add("ThanhTien", "Thành tiền");



            // Hiển thị danh sách sản phẩm trong phiếu trả
            List<ClassChiTietPhieuTraHang> chiTietList = ClassChiTietPhieuTraHang.LayChiTietTheoMaPhieu(classPhieuTraHang.MaPhieuTraHang);
            foreach (var item in chiTietList)
            {
                dataGridViewChiTietPhieuTra.Rows.Add(item.MaHangHoa, item.TenHangHoa, item.SoLuongTra, item.GiaTraHang, item.ThanhTien);
            }

        }
        // Pseudocode:
        // 1. Define a public event in FormChiTietPhieuTra, e.g., public event EventHandler PhieuTraHangClosed;
        // 2. In the Form's FormClosed event handler, raise the PhieuTraHangClosed event.
        // 3. In the parent form (TraHang), subscribe to this event when opening FormChiTietPhieuTra.
        // 4. In the event handler in TraHang, reload the DataGridView (dataGridViewPhieuTraHang).

        // Step 1: Add event declaration
        public event EventHandler PhieuTraHangClosed;
        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            // Xác nhận hủy phiếu trả hàng
            var result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ phiếu trả hàng này không?", "Xác nhận hủy bỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes)
                return;

            // Lấy mã phiếu trả hàng hiện tại
            string maPhieuTra = labelMaPhieuTra.Text;
            var phieuTra = ClassPhieuTraHang.LayPhieuTraHangTheoMa(maPhieuTra);
            if (phieuTra == null)
            {
                MessageBox.Show("Không tìm thấy phiếu trả hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Đổi trạng thái phiếu trả hàng thành "Đã hủy"
            phieuTra.TrangThaiPhieuTra = "Đã hủy";
            if (!phieuTra.SuaPhieuTraHang(phieuTra))
            {
                MessageBox.Show("Không thể cập nhật trạng thái phiếu trả hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //var result2 = MessageBox.Show("Bạn có muốn hủy bỏ phiếu chi liên quan không?", "Xác nhận hủy bỏ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result2 != DialogResult.Yes)
            //    return;
            // Tìm các phiếu chi liên quan
            var danhSachPhieuChi = ClassPhieuThuChi.LayDanhSachPhieuThuChi()
                .Where(p => p.MaPhieuTraHang == maPhieuTra)
                .ToList();

            if (danhSachPhieuChi.Any())
            {
                var resChi = MessageBox.Show("Phiếu trả hàng này có các phiếu chi liên quan. Bạn có muốn hủy các phiếu chi này không?", "Hủy phiếu chi liên quan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resChi == DialogResult.Yes)
                {
                    foreach (var phieuChi in danhSachPhieuChi)
                    {
                        ClassPhieuThuChi.HuyPhieuThuChi(phieuChi.MaPhieuThuChi);
                    }
                }
            }

            MessageBox.Show("Đã hủy phiếu trả hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Step 2: Override OnFormClosed to raise the event
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            PhieuTraHangClosed?.Invoke(this, EventArgs.Empty);
        }




    }
}
