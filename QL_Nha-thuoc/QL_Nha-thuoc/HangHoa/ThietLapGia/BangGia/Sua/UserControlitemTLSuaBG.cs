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

namespace QL_Nha_thuoc.HangHoa.ThietLapGia.BangGia.Sua
{
    public partial class UserControlitemTLSuaBG : UserControl
    {
        public UserControlitemTLSuaBG()
        {
            InitializeComponent();
        }
        public event EventHandler<XoaGiaBanEventArgs>? ClickXoa;

        public class XoaGiaBanEventArgs : EventArgs
        {
            public string MaHangHoa { get; set; }
            public string MaBangGia { get; set; }

            public XoaGiaBanEventArgs(string maHH, string maBangGia)
            {
                MaHangHoa = maHH;
                MaBangGia = maBangGia;
            }
        }

        public string maHH;
        public string maBangGia;
        public string maDVT;


        public void Setdata(ClassGiaBanHH classGiaBanHH)
        {
            labelMaHangHoa.Text = classGiaBanHH.MaHangHoa;
            labelTenHangHoa.Text = classGiaBanHH.TenHangHoa;
            labelGiaVon.Text = classGiaBanHH.GiaVon.ToString();
            textBoxGiaChung.Text = ClassGiaBanHH.LayGiaBanTheoMaHH_DVT_BangGia(classGiaBanHH.MaHangHoa, classGiaBanHH.MaDonViTinh, "BG001").GiaBan.ToString();
            textBoxGiaBangGia.Text = classGiaBanHH.GiaBan.ToString(); // Hiển thị giá bán với định dạng số
            labelDonViTinh.Text =classGiaBanHH.TenDonViTinh ; // Hiển thị tên đơn vị tính
            ClassGiaBanHH.LayGiaBanTheoMaHangVaBangGia(classGiaBanHH.MaHangHoa, classGiaBanHH.MaBangGia);
            // Lưu mã hàng hóa từ đối tượng ClassGiaBanHH
            // Gán mã để dùng khi xóa
            maHH = classGiaBanHH.MaHangHoa;
            maBangGia = classGiaBanHH.MaBangGia;
            maDVT = classGiaBanHH.MaDonViTinh;
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (ClickXoa != null)
            {
                var args = new XoaGiaBanEventArgs(maHH, maBangGia);
                ClickXoa.Invoke(this, args);
            }
        }

        private void textBoxGiaBangGia_Click(object sender, EventArgs e)
        {
            FormThietLapGia formThietLapGia = (FormThietLapGia)this.ParentForm; // Lấy form cha
            FormSuaGiaBanitem frm = new FormSuaGiaBanitem(maHH, maDVT,maBangGia, formThietLapGia); // Truyền chính UserControl này vào
            frm.ShowDialog(); // Mở form sửa
        }


    }
}
