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
        public string TenHangHoa => labelTenHangHoa.Text.Trim();
        public string DonViTinh => labelDonViTinh.Text.Trim();
        public int SoLuongHeThong => int.Parse(labelTonKho.Text.Trim());
        public void SetData(model.ClassHangHoa thongtin)
        {
            MaHangHoa = thongtin.MaHangHoa;

            labelMaHangHoa.Text = thongtin.MaHangHoa;
            labelTenHangHoa.Text = thongtin.TenHangHoa;
            labelTonKho.Text = thongtin.SoLuongTon.ToString();

            labelDonViTinh.Text = $"ĐVT: {thongtin.DonViTinh}";
        }
        public void SetSTT(int stt)
        {
            labelSTT.Text = stt.ToString();
        }

        public int SoLuongThucTe { get; private set; }

        // ✅ Sự kiện thông báo khi số lượng thay đổi
        public event EventHandler OnSoLuongThucTeThayDoi;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            SoLuongThucTe = (int)numericUpDown1.Value;

            int soLuongHeThong = int.Parse(labelTonKho.Text);
            int soLuongLech = SoLuongThucTe - soLuongHeThong; // Thực tế - Hệ thống (có thể âm)

            if (soLuongLech > 0)
            {
                labelLech.Text = $"{soLuongLech} (Thừa)";
                labelLech.ForeColor = Color.Green;
            }
            else if (soLuongLech < 0)
            {
                labelLech.Text = $"{soLuongLech} (Thiếu)"; // giữ số âm
                labelLech.ForeColor = Color.Red;
            }
            else
            {
                labelLech.Text = "0 (Đủ)";
                labelLech.ForeColor = Color.Black;
            }

            OnSoLuongThucTeThayDoi?.Invoke(this, EventArgs.Empty);
        }






        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (this.Parent is FlowLayoutPanel panel)
            {
                // Xóa chính UserControl này khỏi FlowLayoutPanel
                panel.Controls.Remove(this);

                // Duyệt lại toàn bộ các UserControl còn lại để cập nhật STT
                int stt = 1;
                foreach (Control ctrl in panel.Controls)
                {
                    if (ctrl is UserControlHangHoaKiemKho item)
                    {
                        item.SetSTT(stt);
                        stt++;
                    }
                }
            }
        }







    }
}
