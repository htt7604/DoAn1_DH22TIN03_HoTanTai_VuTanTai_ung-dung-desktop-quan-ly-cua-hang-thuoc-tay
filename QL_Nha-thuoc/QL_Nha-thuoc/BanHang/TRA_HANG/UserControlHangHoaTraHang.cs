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

namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    public partial class UserControlHangHoaTraHang : UserControl
    {

        public UserControlHangHoaTraHang()
        {
            InitializeComponent();
        }
        //sự kiện

        //public event EventHandler? SoLuongHoacGiaThayDoi;
        public event EventHandler? XoaHangHoaitem;
        //public event EventHandler? DonViThayDoi;
        public event EventHandler? ThanhTienThayDoi;

        //truyen gia tri 
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal DonGiaHH
        {
            get
            {
                decimal.TryParse(textBoxDonGiaHH.Text.Replace(",", ""), out decimal giaBan);
                return giaBan;
            }
            set
            {
                textBoxDonGiaHH.Text = value.ToString("N0");
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoLuong
        {
            get => (int)numericUpDownSoLuong.Value;
            set => numericUpDownSoLuong.Value = value;
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int SoLuongBan { get; set; } // số lượng đã bán trong hóa đơn gốc

        public NumericUpDown SoLuongControl => numericUpDownSoLuong;


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string _TenHangHoa
        {
            get { return labelTenHang.Text; }  // hoặc tên Label chứa tên hàng hóa trong giao diện
            set { labelTenHang.Text = value; }
        }




        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]



        //khai bao bien 
        public decimal SoLuongTon { get; set; }

        public string maHangHoa;

        public decimal DonGiaGocHH;



        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public decimal thanhTienHH
        {
            get
            {
                decimal.TryParse(textBoxThanhTien.Text.Replace(",", ""), out decimal thanhTien);
                return thanhTien;
            }
            set
            {
                textBoxThanhTien.Text = value.ToString("N0");
            }
        }
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        public string maDonViTinh
        {
            get { return hh.MaDonViTinh; } // hoặc tên Label chứa đơn vị tính trong giao diện
            set { }
        }
        public ClassHangHoa hh;

        //set du lieu cho control
        public void SetData(ClassHangHoa hangHoa,string maHD)
        {
            //lay chi tiep hoa don co mahd va mahh
            var ct= ClassChiTietHoaDon.LayChiTietTheoMaHDVaMaHH(maHD,hangHoa.MaHangHoa);
            labelTenHang.Text = hangHoa.TenHangHoa.ToString();
            labelMaHangHoa.Text = hangHoa.MaHangHoa.ToString();        
            labelDonViTinh.Text = ClassDonViTinh.LayDonViTinhTheoMa(ct.MaDonViTinh).TenDonViTinh.ToString()??"";
            labelGiamGia.Text=ct.GiamGia.ToString()??"0"; // Hiển thị có phân cách hàng nghìn
            textBoxDonGiaHH.Text = ct.DonGiaBan.ToString(); // Hiển thị có phân cách hàng nghìn
            labelSoLuongBan.Text = "/ " + ct.SoLuongChuaTra.ToString();

            numericUpDownSoLuong.Maximum = (int)ct.SoLuongChuaTra;

            maDonViTinh = hangHoa.MaDonViTinh;
            maHangHoa = hangHoa.MaHangHoa;//luu lai mahh
            DonGiaGocHH = ct.DonGiaBan ?? 0; // Lưu giá gốc để tính giảm giá nếu cầns
            SoLuongBan=(int)ct.SoLuong; // Lưu số lượng đã bán trong hóa đơn gốc
            hh = hangHoa; // Lưu lại thông tin hàng hóa để sử dụng sau này
        }
        //ham setSTT
        public void SetSTT(int stt)
        {
            labelSTT.Text = stt.ToString();
        }


        //thao tac tren control
        private void numericUpDownSoLuong_ValueChanged(object sender, EventArgs e)
        {
            //string maHH = labelMaHangHoa.Text;
            //var ct = ClassChiTietHoaDon.LayChiTietTheoMaHDVaMaHH(maHD, hangHoa.MaHangHoa);
            //int soluonghh = (int)numericUpDownSoLuong.Value;
            //if (soluonghh > ct.SoLuongTon)
            //{
            //    numericUpDownSoLuong.BackColor = Color.LightCoral; // hoặc Color.Red
            //}
            //else
            //{
            //    numericUpDownSoLuong.BackColor = Color.White; // trở lại màu bình thường
            //}

            // (tuỳ chọn) Gửi sự kiện thay đổi thành tiền nếu cần
            ThanhTienThayDoi?.Invoke(this, EventArgs.Empty);


            TinhThanhTien(); // Tính lại thành tiền khi số lượng thay đổi
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            XoaHangHoaitem?.Invoke(this, EventArgs.Empty); // Gửi yêu cầu xóa đến control cha
        }




        private void textBoxThanhTien_TextChanged(object sender, EventArgs e)
        {
            //goi su kien thay doi 
            ThanhTienThayDoi?.Invoke(this, EventArgs.Empty);
        }

        //ham tinh thanh tien cho tung hang hoa 
        public void TinhThanhTien()
        {
            // Lấy giá bán từ textBoxGiaBan
            if (decimal.TryParse(textBoxDonGiaHH.Text.Replace(",", ""), out decimal giaBan))
            {
                // Lấy số lượng từ numericUpDownSoLuong
                int soLuong = (int)numericUpDownSoLuong.Value;
                // Tính thành tiền
                textBoxThanhTien.Text = (giaBan * soLuong).ToString("N0"); // Hiển thị có phân cách hàng nghìn
            }
        }


        private void textBoxDonGiaHH_TextChanged(object sender, EventArgs e)
        {
            //goi ham tinh thanh tien
            TinhThanhTien();
        }




        //du lieu  de luu gia tri sau khi tinh toan

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? LoaiGiamGiaDaChon { get; set; } = "VND"; // Mặc định là VND
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal GiaTriGiamGia { get; set; } = 0m;
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public decimal GiaSauGiam { get; set; } = 0m;

        private void textBoxDonGiaHH_Click(object sender, EventArgs e)
        {
            FormGiamGiaHHHoaDonPopup popup = new FormGiamGiaHHHoaDonPopup();

            // Gán giá trị từ lần trước (nếu có)
            popup.DonGia = DonGiaGocHH;
            popup.loaiDangChon = LoaiGiamGiaDaChon ?? "VND";
            popup.GiaTriGiamGia = GiaTriGiamGia;
            popup.GiaBan = GiaSauGiam;

            // Sự kiện cập nhật giá khi thay đổi
            popup.CoSuThayDoiGiaBan += (s, args) =>
            {
                textBoxDonGiaHH.Text = popup.GiaBan.ToString("N0");
            };

            // Gán vị trí popup
            Point viTriPopup = textBoxDonGiaHH.PointToScreen(Point.Empty);
            popup.StartPosition = FormStartPosition.Manual;
            popup.Location = new Point(viTriPopup.X, viTriPopup.Y + textBoxDonGiaHH.Height);

            // Sự kiện khi đóng để lưu lại giá trị
            popup.FormClosed += (s, args) =>
            {
                labelGiamGia.Text = popup.chuoihienthi;
                labelGiamGia.ForeColor = Color.Red;

                // ✅ Lưu lại dữ liệu giảm giá đã nhập
                LoaiGiamGiaDaChon = popup.loaiDangChon;
                GiaTriGiamGia = popup.GiaTriGiamGia;
                GiaSauGiam = popup.GiaBan;
            };

            popup.Show();
        }

        private void UserControlHangHoaTraHang_Load(object sender, EventArgs e)
        {
            string maHH = labelMaHangHoa.Text;

            ClassHangHoa hangHoa = ClassHangHoa.LayThongTinMotHangHoa(maHH);
            int soluonghh = (int)numericUpDownSoLuong.Value;
            if (soluonghh > hangHoa.SoLuongTon)
            {
                numericUpDownSoLuong.BackColor = Color.LightCoral; // hoặc Color.Red
            }
            else
            {
                numericUpDownSoLuong.BackColor = Color.White; // trở lại màu bình thường
            }

            // (tuỳ chọn) Gửi sự kiện thay đổi thành tiền nếu cần
            ThanhTienThayDoi?.Invoke(this, EventArgs.Empty);

            TinhThanhTien(); // Tính lại thành tiền khi số lượng thay đổi
        }


    }
}
