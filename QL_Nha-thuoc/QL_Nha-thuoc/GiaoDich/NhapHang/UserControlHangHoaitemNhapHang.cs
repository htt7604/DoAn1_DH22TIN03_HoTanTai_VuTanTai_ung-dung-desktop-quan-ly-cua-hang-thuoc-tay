using QL_Nha_thuoc.HangHoa;
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
    public partial class UserControlHangHoaitemNhapHang : UserControl
    {
        public decimal DonGia => (Decimal)textBoxDonGia.DataContext;
        public int SoLuong => (int)numericUpDownSoLuong.Value;
        public decimal giaBanHienTai = 0;
        public event EventHandler ThayDoiSoLuongHoacDonGia;
        ToolTip toolTip = new ToolTip();


        public Button buttonXoa => this.buttonX;
        public decimal ThanhTien
        {
            get
            {
                if (decimal.TryParse(textBoxThanhTien.Text, out decimal thanhTien))
                {
                    return thanhTien;
                }
                return 0; // Trả về 0 nếu không thể chuyển đổi
            }
        }
        public UserControlHangHoaitemNhapHang()
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            textBoxDonGia.MouseHover += TextBoxDonGia_MouseHover;

            // Ngăn người dùng gõ vào ô giảm giá
            textBoxGiamGia.ReadOnly = true;
        }


        //thong bao 
        private void TextBoxDonGia_MouseHover(object sender, EventArgs e)
        {
            if (giaBanHienTai != 0 && decimal.TryParse(textBoxDonGia.Text, out decimal donGia))
            {
                if (donGia > giaBanHienTai)
                {
                    toolTip.ToolTipTitle = "Cảnh báo";
                    toolTip.Show("Cao hơn giá bán: " + giaBanHienTai, textBoxDonGia, textBoxDonGia.Width / 2, textBoxDonGia.Height, 3000);
                }
                else
                {
                    toolTip.Hide(textBoxDonGia);
                }
            }
        }


        public void setData(ClassHangHoa hangHoa)
        {
            linkLabelMaHangHoa.Text = hangHoa.MaHangHoa;
            labelTenHang.Text = hangHoa.TenHangHoa;
            textBoxDonGia.Text = "0"; // Hiển thị giá bán với định dạng số nguyên
            textBoxGiamGia.Text = "0"; // Mặc định giảm giá là 0
            textBoxThanhTien.Text = "0"; // Mặc định thành tiền là 0

            // Lấy đơn vị tính
            List<ClassDonViTinh> danhSachDonViTinh = ClassGiaBanHH.LayDanhSachDonViTinhTheoMaHangHoa(hangHoa.MaHangHoa);

            comboBoxDonViTinh.DataSource = null;
            comboBoxDonViTinh.Items.Clear(); // Xoá dữ liệu cũ nếu có
            comboBoxDonViTinh.DisplayMember = "TenDonViTinh";   // Hiển thị tên
            comboBoxDonViTinh.ValueMember = "MaDonViTinh";      // Lưu giá trị là mã
            comboBoxDonViTinh.DataSource = danhSachDonViTinh;   // Gán dữ liệu

            if (comboBoxDonViTinh.Items.Count > 0)
                comboBoxDonViTinh.SelectedIndex = 0;
        }

        public void SetSTT(int stt)
        {
            labelSTT.Text = stt.ToString();
        }

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            if (this.Parent is FlowLayoutPanel parentPanel)
            {
                this.Width = parentPanel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        //ham tinh thanh tien
        public decimal TinhThanhTienCuaHangHoa()
        {
            string maHangHoa = linkLabelMaHangHoa.Text;
            string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString() ?? string.Empty;
            int soLuong = ((int)numericUpDownSoLuong.Value);

            if (!decimal.TryParse(textBoxDonGia.Text, out decimal donGia))
                donGia = 0;

            if (!decimal.TryParse(textBoxGiamGia.Text, out decimal giamGia))
                giamGia = 0;
            if(loaiGiam == "%")
            {
                // Chuyển đổi giảm giá từ phần trăm sang giá trị tiền
                giamGia = donGia * giamGia / 100;
            }else if (loaiGiam == "VND")
            {
                // Giảm giá đã là giá trị tiền
                giamGia = giamGia;
            }else
            {
                giamGia = 0; // Nếu không xác định loại giảm giá, đặt về 0
            }
            decimal thanhTien = Math.Max(0, (donGia - giamGia) * soLuong);
            textBoxThanhTien.Text = thanhTien.ToString("N0");
            return thanhTien = ThanhTien;
        }



        private void textBoxDonGia_TextChanged(object sender, EventArgs e)
        {
            //lay gia nhap hien tai cua textBoxDonGia
            if (giaBanHienTai != 0 && decimal.TryParse(textBoxDonGia.Text, out decimal donGia))
            {
                if (donGia > giaBanHienTai)
                {
                    textBoxDonGia.BackColor = Color.Red; // Đổi màu nền thành đỏ nếu giá nhập nhỏ hơn giá bán
                }
                else
                {
                    textBoxDonGia.BackColor = Color.White; // Đổi màu nền về trắng nếu giá nhập hợp lệ
                }
            }

            //tinh thanh tien
            TinhThanhTienCuaHangHoa();
            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
        }

        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            TinhThanhTienCuaHangHoa();
            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty);
        }

        //xem thong tin chi tiết hàng hóa khi click vào mã hàng hóa theo don vi tính
        private void linkLabelMaHangHoa_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string maHangHoa = linkLabelMaHangHoa.Text;
            string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString() ?? string.Empty;

            ClassHangHoa hangHoa = ClassHangHoa.LayThongTinMotHangHoa(maHangHoa);
            if (hangHoa.MaLoaiHangHoa == "T")
            {
                FormChiTietThuoc formChiTietThuoc = new FormChiTietThuoc(maHangHoa, maDonViTinh);
                formChiTietThuoc.ShowDialog();
            }
            else if (hangHoa.MaLoaiHangHoa == "HH")
            {
                ChitietHangHoa formChiTietHangHoa = new ChitietHangHoa(maHangHoa);
                formChiTietHangHoa.ShowDialog();
            }
            else
            {
                MessageBox.Show("Chưa có thông tin chi tiết cho loại hàng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        //cập nhật giá bán  hien tai khi chọn đơn vị tính
        private void comboBoxDonViTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set =0
            textBoxDonGia.Text = "0";
            //capp nhat lai giaBanhientai
            string maHangHoa = linkLabelMaHangHoa.Text;
            string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString() ?? string.Empty;
            ClassGiaBanHH hanghoa = ClassGiaBanHH.LayGiaBanTheoMavamaDVT(maHangHoa, maDonViTinh);
            if (hanghoa != null)
            {
                giaBanHienTai = hanghoa.GiaBan;
            }
            else
            {
                textBoxDonGia.Text = "0"; // Nếu không tìm thấy, đặt giá bán về 0
            }
            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
        }





        //xu ly khi an nut giam gia 
        private void CapNhatGiamGiaVaTinhTien()
        {
            decimal donGia = 0, giaTriGiam = 0;
            int soLuong = (int)numericUpDownSoLuong.Value;

            decimal.TryParse(textBoxDonGia.Text, out donGia);

            decimal giamTrenMotSp = 0;

            if (loaiGiam == "%")
            {
                giamTrenMotSp = donGia * giaTriGiam / 100;
            }
            else
            {
                giamTrenMotSp = giaTriGiam;
            }

            // Không để giảm giá vượt quá đơn giá
            if (giamTrenMotSp > donGia)
                giamTrenMotSp = donGia;

            decimal thanhTien = (donGia - giamTrenMotSp) * soLuong;

            // Cập nhật các TextBox liên quan
            textBoxGiamGia.Text = giamTrenMotSp.ToString("N0");
            textBoxThanhTien.Text = thanhTien.ToString("N0");

            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty);


        }










        private string loaiGiam = "VND"; // hoặc "%"


        private void textBoxGiamGia_Click(object sender, EventArgs e)
        {
            decimal donGia = Convert.ToDecimal(textBoxDonGia.Text);
            FormGiamGiaPopup popup = new FormGiamGiaPopup(donGia, "0"); // dùng txtGiaTriGiamGia thay vì textBoxGiamGia

            // Gắn sự kiện để nhận dữ liệu khi người dùng thay đổi giảm giá
            popup.GiamGiaDaChon += (s, args) =>
            {
                // Cập nhật loại và giá trị giảm giá
                loaiGiam = args.LoaiGiam;
                textBoxGiamGia.Text = args.GiaTri.ToString(); // dùng để tính toán nội bo
                ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty);
            };

            // Hiển thị đúng vị trí phía dưới textbox giảm giá
            Point viTriPopup = textBoxGiamGia.PointToScreen(Point.Empty);
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(viTriPopup.X, viTriPopup.Y + textBoxGiamGia.Height);
            popup.Show();
        }

        private void textBoxGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTienCuaHangHoa();
            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty);
        }
    }




}
