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

namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    public partial class UserControlitemThietLapGia : UserControl
    {
        private string maHangHoa;
        private string maDonViTinh; // Biến để lưu mã đơn vị tính

        public UserControlitemThietLapGia()
        {
            InitializeComponent();

        }

        public void Setdata(ClassGiaBanHH hangHoa)
        {
            labelMaHangHoa.Text = hangHoa.MaHangHoa;
            labelTenHangHoa.Text = hangHoa.TenHangHoa;
            labelGiaVon.Text = hangHoa.GiaVon.ToString();
            textBoxGiaChung.Text = hangHoa.GiaBan.ToString(); // Hiển thị giá bán với định dạng số

            // Lưu mã hàng hóa từ đối tượng ClassGiaBanHH
            maDonViTinh = hangHoa.MaDonViTinh; // Lưu mã đơn vị tính từ đối tượng ClassGiaBanHH
        }

        private void textBoxGiaChung_Click(object sender, EventArgs e)
        {
            FormThietLapGia formThietLapGia = (FormThietLapGia)this.ParentForm; // Lấy form cha
            maHangHoa = labelMaHangHoa.Text;
            FormSuaGiaBanitem frm = new FormSuaGiaBanitem(maHangHoa, maDonViTinh, formThietLapGia); // Truyền chính UserControl này vào
            frm.ShowDialog(); // Mở form sửa
        }






    }
}
