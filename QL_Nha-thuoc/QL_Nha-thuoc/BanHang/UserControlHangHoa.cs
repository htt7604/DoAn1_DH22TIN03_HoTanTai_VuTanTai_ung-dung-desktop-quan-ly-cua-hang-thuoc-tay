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

namespace QL_Nha_thuoc.BanHang
{
    public partial class UserControlHangHoa : UserControl
    {
        public UserControlHangHoa()
        {
            InitializeComponent();

        }

        public event EventHandler? SoLuongHoacGiaThayDoi;
        public event EventHandler? XoaYeuCau;
        public event EventHandler? DonViThayDoi;

        public NumericUpDown SoLuongControl => numericUpDown1;
        public decimal SoLuongTon { get; set; }

        public string maHangHoa;

        //set du lieu cho control
        public void SetData(string tenThuoc, string mah, float giaBan)
        {
            textBoxTenHang.Text = tenThuoc;
            labelMaHangHoa.Text = mah;

            maHangHoa= mah;//luu lai mahh
            List<ClassDonViTinh> danhSachDonViTinh = ClassGiaBanHH.LayDanhSachDonViTinhTheoMaHangHoa(mah);

            comboBoxDonVITinh.Items.Clear(); // Xoá dữ liệu cũ nếu có
            comboBoxDonVITinh.DisplayMember = "TenDonViTinh";   // Hiển thị tên
            comboBoxDonVITinh.ValueMember = "MaDonViTinh";      // Lưu giá trị là mã
            comboBoxDonVITinh.DataSource = danhSachDonViTinh;   // Gán dữ liệu

            // Nếu muốn chọn mặc định dòng đầu tiên:
            if (comboBoxDonVITinh.Items.Count > 0)
                comboBoxDonVITinh.SelectedIndex = 0;


        }





        //thay doi so luong va gia ban
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SoLuongHoacGiaThayDoi?.Invoke(this, EventArgs.Empty);
        }
        private void textBoxGiaBan_TextChanged(object sender, EventArgs e)
        {
            SoLuongHoacGiaThayDoi?.Invoke(this, EventArgs.Empty);
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            XoaYeuCau?.Invoke(this, EventArgs.Empty); // Gửi yêu cầu xóa đến control cha
        }

        private void comboBoxDonVITinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxDonVITinh.SelectedValue != null)
            {
                string dvt = comboBoxDonVITinh.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(dvt))
                {
                    ClassGiaBanHH giaBan = ClassGiaBanHH.LayGiaBanTheoMavamaDVT(maHangHoa, dvt);
                    textBoxGiaBan.Text = giaBan.GiaBan.ToString("N0"); // Hiển thị có phân cách hàng nghìn
                }
            }
            DonViThayDoi?.Invoke(this,EventArgs.Empty);
        }




        //truyen gia tri 
        public decimal GiaBan
        {
            get
            {
                decimal.TryParse(textBoxGiaBan.Text.Replace(",", ""), out decimal giaBan);
                return giaBan;
            }
            set
            {
                textBoxGiaBan.Text = value.ToString("N0");
            }
        }


        public int SoLuong
        {
            get => (int)numericUpDown1.Value;
            set => numericUpDown1.Value = value;
        }




    }
}
