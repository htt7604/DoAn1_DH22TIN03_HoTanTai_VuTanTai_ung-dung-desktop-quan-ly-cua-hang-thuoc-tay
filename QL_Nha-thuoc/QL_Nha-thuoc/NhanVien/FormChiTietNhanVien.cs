using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.DangNhap;
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

namespace QL_Nha_thuoc.NhanVien
{
    public partial class FormSuaNhanVien : Form
    {
        public FormSuaNhanVien()
        {
            InitializeComponent();
        }
        public event EventHandler FormDaDong;



        public void Setdata(ClassNhanVien classNhanVien)
        {

            textBoxMaNhanVien.Text = classNhanVien.MaNhanVien;
            textBoxTenNhanVien.Text = classNhanVien.HoTenNhanVien;
            textBoxDiaChi.Text = classNhanVien.DiaChi;
            textBoxSoDienThoai.Text = classNhanVien.SoDienThoai;
            textBoxSoCCCD.Text = classNhanVien.SoCCCD;
            dateTimePickerNgaySinh.Value = classNhanVien.NgaySinh ?? DateTime.Now;
            textBoxEmail.Text = classNhanVien.Email;
            textBoxFacebook.Text = classNhanVien.Facebook;
            textBoxTenTaiKhoan.Text = ClassTaiKhoan.LayTaiKhoanTheoMaNV(classNhanVien.MaNhanVien)?.TenTaiKhoan ?? string.Empty;
            if (classNhanVien.GioiTinh == "Nam")
            {
                radioButtonNam.Checked = true;
                radioButtonNu.Checked = false;
            }
            else
            {
                radioButtonNam.Checked = false;
                radioButtonNu.Checked = true;
            }
            if (classNhanVien.TrangThai == "Đang làm việc")
            {
                buttonNgungLamViec.Text = "Ngừng làm việc";
            }
            else
            {
                buttonNgungLamViec.Text = "Đang làm việc";
            }
            dateTimePickerNgayBatDauLamViec.Value = classNhanVien.NgayBatDauLamViec ?? DateTime.Now;
            textBoxEmail.Text = classNhanVien.Email;
            textBoxFacebook.Text = classNhanVien.Facebook;
            // Hiển thị hình ảnh nếu có
            if (!string.IsNullOrEmpty(classNhanVien.HinhAnh))
            {
                pictureBoxHinhAnhNhanVien.ImageLocation = classNhanVien.HinhAnh;
                pictureBoxHinhAnhNhanVien.SizeMode = PictureBoxSizeMode.StretchImage; // Đặt chế độ hiển thị hình ảnh
            }
        }

        private string trangThaiHienTai = "Đang làm việc";

        private void buttonNgungLamViec_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
           "Bạn có chắc chắn muốn thay đổi trạng thái làm việc của nhân viên này không?",
           "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Đảo trạng thái
                if (trangThaiHienTai == "Đang làm việc")
                {
                    trangThaiHienTai = "Ngừng làm việc";
                    buttonNgungLamViec.Text = "Đang làm việc";
                }
                else
                {
                    trangThaiHienTai = "Đang làm việc";
                    buttonNgungLamViec.Text = "Ngừng làm việc";
                }

                // Cập nhật DB
                using (SqlConnection conn = CSDL.GetConnection())
                {
                    string query = "UPDATE NHAN_VIEN SET TRANG_THAI_NV = @TrangThai WHERE MA_NV = @MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TrangThai", trangThaiHienTai);
                    cmd.Parameters.AddWithValue("@MaNV", textBoxMaNhanVien.Text);

                    conn.Open();
                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Cập nhật trạng thái thành công!",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!",
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật trạng thái: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif",
                Title = "Chọn hình ảnh nhân viên"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Hiển thị ảnh trong PictureBox
                    pictureBoxHinhAnhNhanVien.Image = new Bitmap(openFileDialog.FileName);
                    pictureBoxHinhAnhNhanVien.SizeMode = PictureBoxSizeMode.StretchImage;

                    // Lưu đường dẫn ảnh vào DB
                    using (SqlConnection conn = CSDL.GetConnection())
                    {
                        string query = "UPDATE NHAN_VIEN SET HINH_ANH_NV = @HinhAnh WHERE MA_NV = @MaNV";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        cmd.Parameters.AddWithValue("@HinhAnh", openFileDialog.FileName);
                        cmd.Parameters.AddWithValue("@MaNV", textBoxMaNhanVien.Text);

                        conn.Open();
                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Cập nhật hình ảnh thành công!",
                                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên cần cập nhật!",
                                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể hiển thị hoặc lưu hình ảnh: " + ex.Message,
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            FormDaDong?.Invoke(this, EventArgs.Empty);

            this.Close();
        }

        private void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin tài khoản nhân viên từ DB
                string tenTaiKhoanDangNhap = textBoxTenTaiKhoan.Text; // Lấy từ biến session/login của bạn

                ClassTaiKhoan tk = ClassTaiKhoan.LayTaiKhoan(tenTaiKhoanDangNhap);
                if (tk == null)
                {
                    MessageBox.Show("Không tìm thấy tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Mở form xác thực email với trạng thái "quenmatkhau"
                FormXacThucEmail formXacThuc = new FormXacThucEmail(tk, "quenmatkhau");
                formXacThuc.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
