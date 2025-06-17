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

namespace QL_Nha_thuoc.DoiTac.khachhang
{
    public partial class FormSuaKhachHang : Form
    {
        public ClassKhachHang luukhachhang;
        public FormSuaKhachHang()
        {
            InitializeComponent();
        }
        //sua khach hang 
        public void SetDatavaoSua(ClassKhachHang khachHang)
        {
            luukhachhang = khachHang;
            if (khachHang == null)
            {
                labelMaKH.Text = "Chưa có khách hàng";
                textBoxTenKH.Text = string.Empty;
                return;
            }
            textBoxCHinh.Text = "SUA KHACH HANG";
            textBoxMaKH.Text = khachHang.MaKH.ToString();
            textBoxTenKH.Text = khachHang.TenKH;
            textBoxDiaChi.Text = khachHang.DiaChiKH;
            textBoxDienThoai.Text = khachHang.SDT?.ToString() ?? "Chưa có SĐT";
            textBoxEmail.Text = khachHang.Email?.ToString() ?? "Chua co Email";
            textBoxCCCD.Text = khachHang.SoCCCD_CMND ?? "Chưa có CMND/CCCD";
            textBoxGhiChu.Text = khachHang.GhiChu ?? "Chưa có ghi chú";
            textBoxMaSoThue.Text = string.IsNullOrEmpty(khachHang.MaSoThue)
                    ? "Chưa có mã số thuế"
                    : khachHang.MaSoThue;
            if (khachHang.GioiTinh == "Nam")
            {
                radioButtonNam.Checked = true;
            }
            else
            {
                radioButtonNu.Checked = true;
            }

            if (khachHang.MaNhomKH == "CN")
            {
                radioButtonCaNhan.Checked = true;
            }
            else
            {
                radioButtonCongTy.Checked = true;
                textBoxTenCongTy.ReadOnly = false;
                textBoxTenCongTy.Enabled = true;
                textBoxTenCongTy.Text = khachHang.TenCongTy ?? "";
            }

            // Xử lý ảnh
            //string tenHinh = reader["HINH_ANH_HH"]?.ToString().Trim();
            string tenHinh = khachHang.HinhAnhKh?.Trim() ?? string.Empty;
            if (!string.IsNullOrEmpty(tenHinh))
            {
                string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa\";
                string duongDan = Path.Combine(thuMucAnh, tenHinh);

                if (File.Exists(duongDan))
                {
                    using (FileStream fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                    using (MemoryStream ms = new MemoryStream())
                    {
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        pictureBoxKhachHang.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    pictureBoxKhachHang.Image = Properties.Resources._default;
                }
            }
            else
            {
                pictureBoxKhachHang.Image = Properties.Resources._default;
            }
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; // Đặt kết quả của hộp thoại là Cancel
        }

        private void textBoxDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép phím số và phím điều khiển (backspace, delete,...)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }
        }

        private string hinhAnhKhachHang = ""; // Biến lưu chuỗi đường dẫn ảnh

        private void buttonThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Chọn ảnh khách hàng";
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                try
                {
                    using (var originalImage = Image.FromFile(path))
                    {
                        // Resize ảnh vừa khung pictureBox
                        Image resized = new Bitmap(originalImage, pictureBoxKhachHang.Width, pictureBoxKhachHang.Height);
                        pictureBoxKhachHang.Image = resized;
                        pictureBoxKhachHang.SizeMode = PictureBoxSizeMode.Zoom;

                        // Gán chuỗi đường dẫn
                        hinhAnhKhachHang = path;
                        textBoxCHinh.Text = Path.GetFileName(path);
                    }
                }
                catch (OutOfMemoryException)
                {
                    MessageBox.Show("Tệp không phải ảnh hợp lệ hoặc quá lớn.", "Lỗi bộ nhớ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormSuaKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            luukhachhang.MaKH =textBoxMaKH.Text.Trim();
            luukhachhang.TenKH = textBoxTenKH.Text.Trim();
            luukhachhang.SDT = textBoxDienThoai.Text.Trim();
            luukhachhang.DiaChiKH = textBoxDiaChi.Text.Trim();
            luukhachhang.Email = textBoxEmail.Text.Trim();
            luukhachhang.GhiChu = textBoxGhiChu.Text.Trim();
            luukhachhang.NgayTaoKH = DateTime.Now; // Ngày tạo mặc định là ngày hiện tại
            luukhachhang.nguoiTao = Session.TaiKhoanDangNhap.TenNhanVien; // Người tạo là người đăng nhập hiện tại
            luukhachhang.MaNV = Session.TaiKhoanDangNhap.MaNhanVien; // Mã nhân viên là mã của người đăng nhập hiện tại
            luukhachhang.TrangThaiKH = "Đang hoạt động";
            luukhachhang.HinhAnhKh = hinhAnhKhachHang; // Lưu đường dẫn ảnh nếu có
            luukhachhang.SoCCCD_CMND = textBoxCCCD.Text.Trim();
            luukhachhang.NgaySinh = dateTimePicker1.Checked ? dateTimePicker1.Value : (DateTime?)null;
            if (radioButtonCaNhan.Checked)
            {
                luukhachhang.MaNhomKH = "CN";
                luukhachhang.TenCongTy = null;
            }
            else if (radioButtonCongTy.Checked)
            {
                luukhachhang.TenCongTy = textBoxTenCongTy.Text.Trim();
                luukhachhang.MaNhomKH = "TC";
            }
            if (radioButtonNam.Checked)
            {
                luukhachhang.GioiTinh = "Nam";
            }
            else if (radioButtonNu.Checked)
            {
                luukhachhang.GioiTinh = "Nữ";
            }

            bool luukh = ClassKhachHang.CapNhatThongTinKhachHang(luukhachhang);
            if (luukh)
            {
                MessageBox.Show("Lưu thông tin khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK; // Đặt kết quả của hộp thoại là OK
                this.Close(); // Đóng hộp thoại
            }
            else
            {
                MessageBox.Show("Lưu thông tin khách hàng thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //dong form va cap nhat lai danh sach khach hang
            this.DialogResult = DialogResult.OK; // Đặt kết quả của hộp thoại là OK
            this.Close(); // Đóng hộp thoại

        }

        private void radioButtonCongTy_CheckedChanged(object sender, EventArgs e)
        {
            textBoxTenCongTy.Enabled = radioButtonCongTy.Checked;
        }
    }
}
