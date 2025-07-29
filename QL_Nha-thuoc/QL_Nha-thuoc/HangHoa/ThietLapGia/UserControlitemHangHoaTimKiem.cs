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

        /// <summary>
        /// Thiết lập dữ liệu hiển thị cho UserControl
        /// </summary>
        public void SetData(ClassHangHoa hangHoa)
        {
            labelTenHangHoa.Text = hangHoa.TenHangHoa;
            labelMaHangHoa.Text = hangHoa.MaHangHoa;
            SoLuongTon = SoLuongTon;// Lưu số lượng tồn kho
            // Đường dẫn thư mục ảnh
        }



 

        private void UserControlitemHangHoa_Click(object sender, EventArgs e)
        {
            //this.OnClick(e); // Gọi lại sự kiện Click để form ngoài xử lý
        }
    }
}
