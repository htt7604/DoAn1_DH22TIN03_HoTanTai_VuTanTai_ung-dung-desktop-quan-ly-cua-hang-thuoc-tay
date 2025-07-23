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
using QL_Nha_thuoc.model;

namespace QL_Nha_thuoc.DoiTac.nhacungcap
{
    public partial class FormChiTietNhaCungCap : Form
    {
        private string _maNCC;
        public FormChiTietNhaCungCap(string maNCC)
        {
            InitializeComponent();
            _maNCC = maNCC;
        }
        public void setdata(ClassNhaCungCap ncc)
        {
            label8.Text = "NHÀ CUNG CẤP " + ncc.MaNhaCungCap;
            textBoxMaNCC.Text = ncc.MaNhaCungCap;
            textBoxTenNCC.Text = ncc.TenNhaCungCap;
            textBoxDiaChi.Text = ncc.DiaChiNCC;
            textBoxSDT.Text = ncc.DienThoai;
            textBoxEmail.Text = ncc.Email;
            textBoxGhiChu.Text = ncc.GhiChu;
            textBoxTenCongTy.Text = ncc.TenCongTy;
            textBoxMaSoThue.Text = ncc.MaSoThue;
            //them vao data grid view lich su giao dich
            dataGridViewLichSu.Rows.Clear();
            List<PhieuNhapHang> dsPhieuNhapHang = PhieuNhapHang.TimPhieuNhapTheoMaNhaCungCap(ncc.MaNhaCungCap);
            foreach (var phieuNhap in dsPhieuNhapHang)
            {
                dataGridViewLichSu.Rows.Add(phieuNhap.MaPhieuNhap, phieuNhap.TenNhanVien, phieuNhap.NgayNhap.ToString(), phieuNhap.TongTienNhapHang, phieuNhap.TrangThai);
            }
        }

        private void FormChiTietNhaCungCap_Load(object sender, EventArgs e)
        {

            ClassNhaCungCap ncc = ClassNhaCungCap.LayDanhSachNhaCungCap()
               .Find(x => x.MaNhaCungCap == _maNCC);

            if (ncc != null)
            {
                setdata(ncc);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp có mã: " + _maNCC,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            //mo form chi tiết nhà cung cấp
            FormSuaNhaCungCap formSuaNCC = new FormSuaNhaCungCap(_maNCC);
            formSuaNCC.ShowDialog();
            // Sau khi đóng form sửa, cập nhật lại dữ liệu
            ClassNhaCungCap ncc = ClassNhaCungCap.LayDanhSachNhaCungCap()
                .Find(x => x.MaNhaCungCap == _maNCC);
            if (ncc != null)
            {
                setdata(ncc);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp có mã: " + _maNCC,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            //thong bao xoa nha cung cap
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này không?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Thực hiện xóa nhà cung cấp
                bool isDeleted = ClassNhaCungCap.XoaNhaCungCap(_maNCC);
                if (isDeleted)
                {
                    MessageBox.Show("Xóa nhà cung cấp thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK; // Đóng form và trả về kết quả OK
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể xóa nhà cung cấp này. Vui lòng kiểm tra lại.",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



































        //design datagridview
        private void SetupDataGridView(DataGridView dgv)
        {
            // Căn lề và font chữ chung
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            // Màu tiêu đề cột
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 248, 255); // Màu xanh nhạt
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // Kích thước dòng
            dgv.RowTemplate.Height = 35;

            // Không cho chỉnh sửa trực tiếp
            dgv.ReadOnly = true;

            // Tự động giãn cột
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Viền bảng
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LightGray;

            // Chọn cả dòng
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;

            // Màu dòng được chọn
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 122, 204);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Xóa viền bên ngoài nếu muốn nhìn hiện đại hơn
            dgv.BorderStyle = BorderStyle.None;
        }




        //design tab control
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush textBrush;

            // Lấy tab hiện tại
            TabPage tabPage = tabControl1.TabPages[e.Index];
            Rectangle tabBounds = tabControl1.GetTabRect(e.Index);

            // Màu nền và chữ
            if (e.State == DrawItemState.Selected)
            {
                g.FillRectangle(Brushes.LightBlue, tabBounds); // Màu tab đang chọn
                textBrush = Brushes.Black;
            }
            else
            {
                g.FillRectangle(Brushes.LightGray, tabBounds); // Màu tab chưa chọn
                textBrush = Brushes.Black;
            }

            // Tăng khoảng cách giữa các tab bằng cách dịch vị trí text
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            g.DrawString(tabPage.Text, this.Font, textBrush, tabBounds, sf);
        }

        private void dataGridViewLichSu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra có phải là LinkColumn không
            if (e.RowIndex >= 0 && dataGridViewLichSu.Columns[e.ColumnIndex] is DataGridViewLinkColumn)
            {
                // Lấy giá trị ô được click
                string maPhieu = dataGridViewLichSu.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                // Gọi hành động mong muốn (ví dụ mở form chi tiết)
                MessageBox.Show("Bạn đã click vào phiếu: " + maPhieu);

                // Hoặc: mở form mới
                // FormChiTietPhieu frm = new FormChiTietPhieu(maPhieu);
                // frm.ShowDialog();
            }
        }
    }

}