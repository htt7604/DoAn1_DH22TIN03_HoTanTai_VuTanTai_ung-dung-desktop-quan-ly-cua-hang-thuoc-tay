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
    public partial class FormChiTietKhachHang : Form
    {
        public  ClassKhachHang khachHang = new ClassKhachHang(); // Biến lưu thông tin khách hàng
        public FormChiTietKhachHang()
        {
            InitializeComponent();
        }
        public void SetData(ClassKhachHang khachHang)
        {
            this.khachHang = khachHang; // Gán thông tin khách hàng vào biến toàn cục
            if (khachHang == null)
            {
                labelMaKH.Text = "Chưa có khách hàng";
                textBoxTenKH.Text = string.Empty;
                return;
            }
            else
            {
                if (khachHang.TrangThaiKH == "Ngừng hoạt động")
                {
                    buttonNgungHoatDong.Text = "Cho phep hoạt động";
                }
                else
                {
                    buttonNgungHoatDong.Text = "Ngừng hoạt động";
                }

                textBoxMaKH.Text = khachHang.MaKH.ToString();
                textBoxTenKH.Text = khachHang.TenKH;
                textBoxDiaChi.Text = khachHang.DiaChiKH;
                textBoxDienThoai.Text = khachHang.SDT?.ToString() ?? "Chưa có SĐT";
                textBoxGioiTinh.Text = khachHang.GioiTinh ?? "Chưa xác định";
                textBoxNgaySinh.Text = khachHang.NgaySinh?.ToString("dd/MM/yyyy") ?? "Chưa có ngày sinh";
                textBoxNgayTao.Text = khachHang.NgayTaoKH?.ToString("dd/MM/yyyy") ?? "Chưa có ngày tạo";
                textBoxCCCD.Text = khachHang.SoCCCD_CMND ?? "Chưa có CMND/CCCD";
                textBoxGhiChu.Text = khachHang.GhiChu ?? "Chưa có ghi chú";
                textBoxEmail.Text = khachHang.Email;
                textBoxMaSoThue.Text = string.IsNullOrEmpty(khachHang.MaSoThue)
                    ? "Chưa có mã số thuế"
                    : khachHang.MaSoThue;
                textBoxNhomKH.Text = string.IsNullOrEmpty(khachHang.TenNhomKH)
                    ? "Chưa có nhóm khách hàng"
                    : khachHang.TenNhomKH;
                textBoxNguoiTao.Text = string.IsNullOrEmpty(khachHang.nguoiTao)
                    ? "Chưa có người tạo"
                    : khachHang.nguoiTao;
                if (khachHang.GioiTinh == "Nam")
                {
                    
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
        }

        private void buttonNgungHoatDong_Click(object sender, EventArgs e)
        {
            // Xử lý ngừng hoạt động khách hàng
            //cap nhat trang thai khach hang
            //thong báo xác nhận ngừng hoạt động
            string maKhachHang = textBoxMaKH.Text.Trim(); // Lấy chuỗi và loại bỏ khoảng trắng
            if (maKhachHang!=null)
            {
                ClassKhachHang khachHang = ClassKhachHang.LayThongTinKhachHangTheoMa(maKhachHang);
                string trangThaiHienTai = khachHang.TrangThaiKH;
                if (trangThaiHienTai == "Ngừng hoạt động")
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn cho phep khách hàng này hoạt động tro lai không? ", "Xác nhận ngừng hoạt động", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return; // Nếu người dùng không xác nhận, thoát khỏi hàm
                    }
                    khachHang.TrangThaiKH = "Đang hoạt động";
                    bool capnhat = ClassKhachHang.CapNhatThongTinKhachHang(khachHang);
                    if (capnhat)
                    {
                        MessageBox.Show("Đã cap nhat thanh cong", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form chi tiết khách hàng
                    }
                    else
                    {
                        MessageBox.Show("Không thể cap nhat khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn ngung hoạt động khách hàng này không?. Thong tin ve khach hang se duoc giu lai ", "Xác nhận ngừng hoạt động", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return; // Nếu người dùng không xác nhận, thoát khỏi hàm
                    }
                    khachHang.TrangThaiKH = "Ngừng hoạt động";
                    bool capnhat = ClassKhachHang.CapNhatThongTinKhachHang(khachHang);
                    if (capnhat)
                    {
                        MessageBox.Show("Đã ngừng hoạt động khách hàng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form chi tiết khách hàng
                    }
                    else
                    {
                        MessageBox.Show("Không thể ngừng hoạt động khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Mã khách hàng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            //thong báo xác nhận xóa khách hàng
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Xử lý xóa khách hàng
                if (int.TryParse(textBoxMaKH.Text, out int maKhachHang))
                {
                    bool isDeleted = ClassKhachHang.XoaKhachHang(maKhachHang);
                    if (isDeleted)
                    {
                        MessageBox.Show("Đã xóa khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // Đóng form chi tiết khách hàng
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Mã khách hàng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void buttonCapNhat_Click(object sender, EventArgs e)
        {
            // Mở form sửa khách hàng
            FormSuaKhachHang formSuaKH = new FormSuaKhachHang();

            // Truyền dữ liệu vào form sửa
            formSuaKH.SetDatavaoSua(this.khachHang);

            // Hiển thị form và đợi người dùng thao tác
            DialogResult result = formSuaKH.ShowDialog();

            // Nếu người dùng nhấn Lưu (bên formSuaKH đặt DialogResult = OK sau khi lưu)
            if (result == DialogResult.OK)
            {
                // Cập nhật lại dữ liệu khách hàng sau khi sửa
                //this.khachHang = formSuaKH.khachHang;

                // Cập nhật lại dữ liệu trên form hiện tại (nếu cần)
                SetData(this.khachHang);

                MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Đóng form chi tiết (nếu bạn muốn)
                this.Close();
            }
        }








    }
}
