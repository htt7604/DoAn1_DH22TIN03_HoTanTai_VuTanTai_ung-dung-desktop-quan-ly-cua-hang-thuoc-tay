using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Nha_thuoc.model; // Assuming this is the namespace where DBHelperNCC and ClassNhaCungCap are defined

namespace QL_Nha_thuoc.DoiTac.nhacungcap
{
    public partial class FormThemNhaCungCap : Form
    {
        public string maNCC = ClassNhaCungCap.MaNhaCungCapTuDong(); // Property to hold the MaNhaCungCap if needed
        public FormThemNhaCungCap()
        {
            InitializeComponent();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra bắt buộc nhập
            if (string.IsNullOrWhiteSpace(textBoxTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTenNCC.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSDT.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxDiaChi.Focus();
                return;
            }

            // Thêm nhà cung cấp
            try
            {
                ClassNhaCungCap ncc = new ClassNhaCungCap()
                {
                    MaNhaCungCap = maNCC, // Giả định bạn đã gọi hàm tự động sinh mã trước đó
                    TenNhaCungCap = textBoxTenNCC.Text.Trim(),
                    DiaChiNCC = textBoxDiaChi.Text.Trim(),
                    DienThoai = textBoxSDT.Text.Trim(),
                    Email = textBoxEmail.Text.Trim(),
                    NoCanTraHienTai = 0,
                    TongMua = 0,
                    GhiChu = textBoxGhiChu.Text.Trim(),
                    TenCongTy = textBoxTenCongTy.Text.Trim(),
                    MaSoThue = textBoxMaSoThue.Text.Trim()
                };

                ClassNhaCungCap.ThemNhaCungCap(ncc); // Gọi class DB xử lý, không phải class model
                MessageBox.Show("Thêm nhà cung cấp thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FormThemNhaCungCap_Load(object sender, EventArgs e)
        {
            textBoxMaNCC.Text = maNCC; // Hiển thị mã nhà cung cấp tự động
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            //dong form mà không lưu
            this.Close(); // Đóng form mà không lưu dữ liệu
        }

    }
}
