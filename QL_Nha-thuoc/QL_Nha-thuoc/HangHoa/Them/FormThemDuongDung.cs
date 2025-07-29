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

namespace QL_Nha_thuoc.HangHoa.Them
{
    public partial class FormThemDuongDung : Form
    {
        public FormThemDuongDung()
        {
            InitializeComponent();
        }

        public string MaDuongDungMoi { get; private set; }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxduongDungThuoc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên đường dùng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo đối tượng
            ClassDuongDungThuoc classDuongDungThuoc = new ClassDuongDungThuoc
            {
                TenDuongDung = textBoxduongDungThuoc.Text.Trim(),
                GhiChuCachDung = "Không có"
            };

            // Gọi hàm thêm
            if (ClassDuongDungThuoc.ThemDuongDungThuoc(classDuongDungThuoc))
            {
                // Lưu lại mã mới để form cha có thể chọn
                this.MaDuongDungMoi = classDuongDungThuoc.MaDuongDung;

                // Gọi sự kiện thông báo thay đổi
                DuLieuDaThayDoi?.Invoke(this, EventArgs.Empty);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        public event EventHandler DuLieuDaThayDoi;
        private void buttonHuy_Click(object sender, EventArgs e)
        {
            // Đóng form khi nhấn nút Hủy
            DuLieuDaThayDoi?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
    }
}
