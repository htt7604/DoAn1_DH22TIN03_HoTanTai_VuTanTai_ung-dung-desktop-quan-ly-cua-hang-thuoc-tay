using QL_Nha_thuoc.BanHang;
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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MaDonViTinh { get; set; }
        public decimal DonGia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxDonGia?.Text))
                    return 0m;

                return Convert.ToDecimal(textBoxDonGia.Text.Replace(",", "").Replace(" đ", ""));
            }
        }

        public decimal GiamGia
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBoxGiamGia?.Text))
                    return 0m;

                string giamGiaText = textBoxGiamGia.Text
                    .Replace(" đ", "")
                    .Replace("%", "")
                    .Replace(",", "");

                return Convert.ToDecimal(giamGiaText);
            }
        }

        //luu ma hang hoa dang co 
        public string MaHangHoa { get; private set; }
        //public int SoLuong => (int)numericUpDownSoLuong.Value;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal SoLuong
        {
            get => numericUpDownSoLuong.Value;
            set => numericUpDownSoLuong.Value = value;
        }

        public string TenHangHoa
        {
            get 
            { 
                return labelTenHang.Text ;
            }
        }


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

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string _maPhieu { get; set; } // Biến lưu mã phiếu nhập
        public UserControlHangHoaitemNhapHang(string maPhieu)
        {
            InitializeComponent();
            this.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.AutoSize = false;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            textBoxDonGia.MouseHover += TextBoxDonGia_MouseHover;

            // Ngăn người dùng gõ vào ô giảm giá
            textBoxGiamGia.ReadOnly = true;
            _maPhieu = maPhieu; // Lưu mã phiếu nhập vào biến
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

        public void setDataChiTietPhieuNhap(ClassChiTietPhieuNhap hangHoa)
        {
            linkLabelMaHangHoa.Text = hangHoa.MaHangHoa;
            labelTenHang.Text = hangHoa.TenHangHoa;
            textBoxDonGia.Text = hangHoa.DonGia.ToString(); // Hiển thị giá bán với định dạng số nguyên
            textBoxGiamGia.Text = hangHoa.GiamGia.ToString(); // Mặc định giảm giá là 0
            textBoxThanhTien.Text = hangHoa.ThanhTien.ToString(); // Mặc định thành tiền là 0

            comboBoxDonViTinh.SelectedValue = hangHoa.MaDonViTinh; // Chọn đơn vị tính tương ứng
            //luu ma hang hoa hien tai 
            this.MaHangHoa = hangHoa.MaHangHoa;
        }
        public void setData(ClassHangHoa hangHoa)
        {
            //ClassChiTietPhieuNhap ct = ClassChiTietPhieuNhap.LayChiTietPhieuNhaptheomaHH_DVT_maPhieu(_maPhieu,hangHoa.MaHangHoa,hangHoa.MaDonViTinh);
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

            //luu ma hang hoa hien tai 
            this.MaHangHoa = hangHoa.MaHangHoa;
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
            //string maHangHoa = linkLabelMaHangHoa.Text;
            //string maDonViTinh = comboBoxDonViTinh.SelectedValue?.ToString() ?? string.Empty;
            int soLuong = ((int)numericUpDownSoLuong.Value);

            //lay don gia
            decimal donGia = 0;
            if (!decimal.TryParse(textBoxDonGia.Text.Replace(" đ", "").Replace(",", ""), out donGia))
                donGia = 0;


            //lay giam gia
            decimal giamGia = 0;
            if (!decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", "").Replace("%", ""), out giamGia))
                giamGia = 0;

            decimal thanhTien = Math.Max(0, (donGia - giamGia) * soLuong);
            textBoxThanhTien.Text = thanhTien.ToString("N0");
            return thanhTien = ThanhTien;
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
            //ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty); // Gọi sự kiện
            MaDonViTinh= maDonViTinh; // Cập nhật mã đơn vị tính
        }



        private string loaiGiam = "VND"; // hoặc "%"
                                         //bien luu giam tri giam gia 
        private decimal GiaTriGiamGia;

        private void textBoxGiamGia_Click(object sender, EventArgs e)
        {
            FormGiamGia formGiamGia = new FormGiamGia();

            // Cấu hình form popup: chỉ hiện nút X
            formGiamGia.FormBorderStyle = FormBorderStyle.FixedSingle;
            formGiamGia.MaximizeBox = false;
            formGiamGia.MinimizeBox = false;
            formGiamGia.ControlBox = true;
            formGiamGia.ShowIcon = false;
            formGiamGia.ShowInTaskbar = false;


            formGiamGia.CoSuThayDoiGiamGia += (s, args) =>
            {
                loaiGiam = formGiamGia.LoaiGiamGia;
                GiaTriGiamGia = formGiamGia.GiaTriNhapGiamGia;

                decimal soTienGiam = formGiamGia.TinhSoTienGiamGia();
                textBoxGiamGia.Text = soTienGiam.ToString("N0") + " đ";

                TinhThanhTienCuaHangHoa(); // cập nhật lại số tiền cần trả
            };


            // Tính tọa độ màn hình của TextBox
            Point viTriManHinh = textBoxGiamGia.PointToScreen(Point.Empty);
            int formX = viTriManHinh.X;
            int formY = viTriManHinh.Y + textBoxGiamGia.Height;

            // Kích thước popup
            int popupWidth = formGiamGia.Width;
            int popupHeight = formGiamGia.Height;

            // Giới hạn hiển thị trong màn hình
            Rectangle screenBounds = Screen.GetWorkingArea(this);

            // Nếu tràn ngang, đẩy về bên trái
            if (formX + popupWidth > screenBounds.Right)
                formX = screenBounds.Right - popupWidth;

            // Nếu tràn dọc, hiển thị lên trên textbox
            if (formY + popupHeight > screenBounds.Bottom)
                formY = viTriManHinh.Y - popupHeight;

            // Gán vị trí và hiển thị form
            formGiamGia.StartPosition = FormStartPosition.Manual;
            formGiamGia.Location = new Point(formX, formY);
            formGiamGia.Show();

            //truyen gia tri cu truoc do 
            if (decimal.TryParse(textBoxGiamGia.Text.Replace(" đ", "").Replace(",", ""), out decimal giamGia))
            {
                formGiamGia.GiaTriNhapGiamGia = giamGia; // Truyền giá trị giảm giá vào formGiamGia
            }
            else
            {
                formGiamGia.GiaTriNhapGiamGia = 0; // Nếu không parse được, đặt giá trị giảm giá là 0
            }

            //truyen tong tien hang vao formGiamGia
            formGiamGia.tongTienHang = decimal.Parse(textBoxDonGia.Text.Replace(" đ", "").Replace(",", ""));
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
        private void textBoxGiamGia_TextChanged(object sender, EventArgs e)
        {
            TinhThanhTienCuaHangHoa();
        }

        private void textBoxThanhTien_TextChanged(object sender, EventArgs e)
        {
            ThayDoiSoLuongHoacDonGia?.Invoke(this, EventArgs.Empty);
        }





    }




}
