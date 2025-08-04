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
    public partial class UserControlitemHangHoaTimKiem : UserControl
    {
        // Sự kiện cho phép form ngoài xử lý khi người dùng click vào UserControl
        public event EventHandler ClickVaoHangHoa;

        public UserControlitemHangHoaTimKiem()
        {
            InitializeComponent();
            // Hover màu nền
            this.MouseEnter += (s, e) => this.BackColor = Color.LightBlue;
            this.MouseLeave += (s, e) => this.BackColor = SystemColors.Control;

            // Hover + Click cho các control con
            foreach (Control ctl in this.Controls)
            {
                ctl.MouseEnter += (s, e) => this.BackColor = Color.LightBlue;
                ctl.MouseLeave += (s, e) => this.BackColor = SystemColors.Control;
                ctl.Click += UserControlitemHangHoa_Click;
            }
        }

        // Thuộc tính công khai (đọc) để lấy mã hàng hóa
        public string MaHangHoa { get; private set; }
        public int SoLuongTon { get; private set; }

        private ClassHangHoa _data;
        /// <summary>
        /// Thiết lập dữ liệu hiển thị cho UserControl
        /// </summary>
        public void SetData(ClassHangHoa hangHoa)
        {
            labelTenHangHoa.Text = hangHoa.TenHangHoa;
            labelMaHangHoa.Text = hangHoa.MaHangHoa;
            labelDonViTinh.Text=hangHoa.TenDonViTinh;
            SoLuongTon = SoLuongTon;// Lưu số lượng tồn kho

            _data = hangHoa;
        }
        public ClassHangHoa LayDuLieu()
        {
            return _data;
        }





        private void UserControlitemHangHoa_Click(object sender, EventArgs e)
        {
            ClickVaoHangHoa?.Invoke(this, EventArgs.Empty); // Gọi sự kiện nếu có người đăng ký
        }

    }
}
