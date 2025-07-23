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

namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class FormChiTietPhieuNhap : Form
    {
        public FormChiTietPhieuNhap()
        {
            InitializeComponent();
        }
        public void SetData(PhieuNhapHang phieuNhapHang)
        {
            labelMaNhapHang.Text = phieuNhapHang.MaPhieuNhap;
            labelThoiGian.Text = phieuNhapHang.NgayNhap.HasValue ? phieuNhapHang.NgayNhap.Value.ToString("dd/MM/yyyy HH:mm:ss") : "Chưa có";
            labelTenNhaCungCap.Text= phieuNhapHang.TenNhaCungCap;
            labelTrangThai.Text = phieuNhapHang.TrangThai;
            labelTenNguoiTao.Text = phieuNhapHang.TenNhanVien ?? "Chưa có";
            labelNguoiNhap.Text=phieuNhapHang.TenNhanVien ?? "Chưa có";
            // Load chi tiết phiếu vào DataGridView

            var table = new DataTable();
            table.Columns.Add("Mã hàng hóa");
            table.Columns.Add("Tên hàng hóa", typeof(string));
            table.Columns.Add("Số lượng ", typeof(int));
            table.Columns.Add("Đơn giá", typeof(decimal));
            table.Columns.Add("Giảm giá", typeof(decimal));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Thành tiền", typeof(decimal));


            List<ClassChiTietPhieuNhap> chiTietList = ClassChiTietPhieuNhap.LayChiTietPhieuNhap(phieuNhapHang.MaPhieuNhap);
            foreach (var ct in chiTietList)
            {
                table.Rows.Add(ct.MaHangHoa,ct.TenHangHoa,ct.SoLuong,ct.DonGia,ct.GiamGia,ct.DonGia,ct.ThanhTien);
            }

            dataGridViewChiTietPhieuNhap.DataSource = table;
            dataGridViewChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }





    }
}
