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

namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class FormChiTietPhieuNhap : Form
    {
        public event Action FormDong;
        public FormMain _formMain;
        public FormChiTietPhieuNhap(FormMain formMain)
        {
            InitializeComponent();
            //this.FormClosed += (s, e) =>
            //{
            //    // Khi form đóng thì gọi event nếu có người đăng ký
            //    FormDong?.Invoke();
            //};
            _formMain = formMain;

        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string maPhieuNhap { get; set; }
        public void SetData(ClassPhieuNhapHang phieuNhapHang)
        {
            maPhieuNhap= phieuNhapHang.MaPhieuNhap;
            // Hiển thị thông tin phiếu nhập
            labelMaNhapHang.Text = phieuNhapHang.MaPhieuNhap;
            labelThoiGian.Text = phieuNhapHang.NgayNhap.HasValue ? phieuNhapHang.NgayNhap.Value.ToString("dd/MM/yyyy HH:mm:ss") : "Chưa có";
            labelTenNhaCungCap.Text = phieuNhapHang.TenNhaCungCap;
            labelTrangThai.Text = phieuNhapHang.TrangThai;
            labelTenNguoiTao.Text = phieuNhapHang.TenNhanVien ?? "Chưa có";
            labelNguoiNhap.Text = phieuNhapHang.TenNhanVien ?? "Chưa có";
            textBoxGhiChu.Text = phieuNhapHang.GhiChuPhieuNhap ?? string.Empty;
            // Load chi tiết phiếu vào DataGridView

            var table = new DataTable();
            table.Columns.Add("Mã hàng hóa");
            table.Columns.Add("Tên hàng hóa", typeof(string));
            table.Columns.Add("Số lượng ", typeof(int));
            table.Columns.Add("Đơn giá", typeof(decimal));
            table.Columns.Add("Giảm giá", typeof(decimal));
            table.Columns.Add("Giá nhập", typeof(decimal));
            table.Columns.Add("Thành tiền", typeof(decimal));


            List<ClassChiTietPhieuNhap> chiTietList = ClassChiTietPhieuNhap.LayDanhSachChiTietPhieuNhap(phieuNhapHang.MaPhieuNhap);
            foreach (var ct in chiTietList)
            {
                table.Rows.Add(ct.MaHangHoa, ct.TenHangHoa, ct.SoLuong, ct.DonGia, ct.GiamGia, ct.DonGia, ct.ThanhTien);
            }

            dataGridViewChiTietPhieuNhap.DataSource = table;
            dataGridViewChiTietPhieuNhap.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if(phieuNhapHang.TrangThai == "Đã nhập")
            {
                buttonMoPhieu.Visible = false;

                buttonLuu.Visible = true;
                buttonHuyBo.Visible = true;
            }
            else
            
            if (phieuNhapHang.TrangThai == "Lưu tạm")
            {
                buttonLuu.Visible = true;
                buttonHuyBo.Visible = true;
                buttonMoPhieu.Visible = true;

            }
            else
            if (phieuNhapHang.TrangThai == "Đã xóa")
            {
                buttonMoPhieu.Visible = false;
                buttonLuu.Visible = false;
                buttonHuyBo.Visible = false;

            }
            else
            {

            }

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string ghichu = textBoxGhiChu.Text.Trim();
                string maPhieu = labelMaNhapHang.Text.Trim();
                // Lấy dữ liệu từ form để cập nhật phiếu nhập
                ClassPhieuNhapHang phieu = new ClassPhieuNhapHang
                {
                    MaPhieuNhap = maPhieu,
                    GhiChuPhieuNhap = ghichu // Có thể lấy từ textbox nếu có

                };

                if (ClassPhieuNhapHang.CapNhatGhiChuPhieuNhap(phieu))
                {
                    MessageBox.Show("Cập nhật phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormDong?.Invoke(); // reload lại danh sách bên ngoài
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật phiếu nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu phiếu nhập: " + ex.Message);
            }
        }

        private void buttonHuyBo_Click(object sender, EventArgs e)
        {
            //thong bao nguoi dung co muon huy bo khong
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ phiếu nhập không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool xoaphieunhap = ClassPhieuNhapHang.XoaPhieuNhap(maPhieuNhap);
                //thong bao xoa thanh cong
                if (xoaphieunhap)
                {
                    MessageBox.Show("Đã hủy bỏ phiếu kiểm kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //load lai du lieu tren form
                    this.Close(); // Đóng form
                }
                else
                {
                    MessageBox.Show("Không thể hủy bỏ phiếu kiểm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            
            }
            else
            {
                //khong lam gi ca
            }
        }

        private void buttonMoPhieu_Click(object sender, EventArgs e)
        {
            string trangThai = ClassPhieuNhapHang.LayTrangThaiPhieuNhap(maPhieuNhap);

            if (trangThai == "Lưu tạm")
            {
                FormThemNhapHang formThemNhapHang = new FormThemNhapHang(maPhieuNhap);
                _formMain.LoadFormVaoPanel(formThemNhapHang);
                formThemNhapHang.LoadPhieuNhapHang(maPhieuNhap);
                formThemNhapHang.FormThemNhapDong += () =>
                {
                    // Khi form ThemNhapHang đóng, gọi lại sự kiện FormDong để reload danh sách
                    FormDong?.Invoke();
                };
                this.Close(); // Ẩn form ChiTietPhieuNhap
            }
            else
            {
                MessageBox.Show("Phiếu này đã được xác nhận. Không thể chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Hàm tính tổng tiền từ DataGridView
        private decimal TinhTongTienTuGrid()
        {
            decimal tong = 0;
            foreach (DataGridViewRow row in dataGridViewChiTietPhieuNhap.Rows)
            {
                if (row.Cells["Thành tiền"].Value != null)
                {
                    decimal val;
                    if (decimal.TryParse(row.Cells["Thành tiền"].Value.ToString(), out val))
                    {
                        tong += val;
                    }
                }
            }
            return tong;
        }

    }
}
