using QL_Nha_thuoc.model;
using System;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    public partial class UserControlHangHoaKiemKho : UserControl
    {

        public UserControlHangHoaKiemKho(string maHH)
        {
            InitializeComponent();
        }
        public string MaHangHoa { get; private set; }
        public void SetData(model.HangHoa thongtin)
        {
            MaHangHoa = thongtin.MaHangHoa;

            labelMaHangHoa.Text = thongtin.MaHangHoa;
            textBoxTenHang.Text = thongtin.TenHangHoa;
            labelTonKho.Text = thongtin.SoLuongTon.ToString();

            labelDonViTinh.Text = $"ĐVT: {thongtin.DonViTinh}";
        }

        public int SoLuongThucTe { get; private set; }

        // ✅ Sự kiện thông báo khi số lượng thay đổi
        public event EventHandler OnSoLuongThucTeThayDoi;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SoLuongThucTe = (int)numericUpDown1.Value;

            // Tính lệch như bạn đã làm
            int soluongLech = int.Parse(labelTonKho.Text) - SoLuongThucTe;
            if (soluongLech < 0)
            {
                labelLech.Text = $"{Math.Abs(soluongLech)} (Thiếu)";
                labelLech.ForeColor = Color.Red;
            }
            else if (soluongLech > 0)
            {
                labelLech.Text = $"{soluongLech} (Thừa)";
                labelLech.ForeColor = Color.Green;
            }
            else
            {
                labelLech.Text = "0 (Đủ)";
                labelLech.ForeColor = Color.Black;
            }

            // Gọi sự kiện báo về cha
            OnSoLuongThucTeThayDoi?.Invoke(this, EventArgs.Empty);
        }





        private void buttonXoa_Click(object sender, EventArgs e)
        {
            // Xóa UserControl này khỏi danh sách kiểm kho
            if (this.Parent != null)
            {
                this.Parent.Controls.Remove(this);
            }

        }
    }
}
