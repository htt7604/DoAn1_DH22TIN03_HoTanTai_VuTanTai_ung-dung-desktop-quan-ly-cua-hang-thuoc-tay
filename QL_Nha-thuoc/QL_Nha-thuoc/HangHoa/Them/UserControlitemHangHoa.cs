using QL_Nha_thuoc.model;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa.Them
{
    public partial class UserControlitemHangHoa : UserControl
    {
        private ClassHangHoa _HangHoa;

        // Sự kiện để báo cho form cha biết thuốc/hàng hóa được chọn
        public event EventHandler<ClassHangHoa> HangHoaDuocChon;

        public UserControlitemHangHoa()
        {
            InitializeComponent();
            // Gắn sự kiện click cho toàn bộ control và các control con
            GanSuKienClick(this);
        }

        /// <summary>
        /// Gắn sự kiện click cho control và các control con của nó bằng đệ quy
        /// </summary>
        private void GanSuKienClick(Control control)
        {
            control.Click += UserControlItemHangHoa_Click;
            foreach (Control child in control.Controls)
            {
                GanSuKienClick(child); // đệ quy
            }
        }

        /// <summary>
        /// Load dữ liệu từ ClassHangHoa vào control
        /// </summary>
        public void SetData(ClassHangHoa hangHoa)
        {
            _HangHoa = hangHoa;
            labelTenHangHoa.Text = hangHoa.TenHangHoa;
            labelMaVach.Text = hangHoa.MaVach;

            string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa";

            if (!string.IsNullOrWhiteSpace(hangHoa.HinhAnh))
            {
                string duongDan = Path.Combine(thuMucAnh, hangHoa.HinhAnh);
                try
                {
                    if (File.Exists(duongDan))
                    {
                        using (var fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;
                            pictureBoxAnhHangHoa.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxAnhHangHoa.Image = Properties.Resources._default;
                    }
                }
                catch (Exception ex)
                {
                    pictureBoxAnhHangHoa.Image = Properties.Resources._default;
                    Debug.WriteLine("Lỗi khi tải ảnh: " + ex.Message);
                }
            }
            else
            {
                pictureBoxAnhHangHoa.Image = Properties.Resources._default;
            }
        }

        /// <summary>
        /// Khi control hoặc control con bị click
        /// </summary>
        private void UserControlItemHangHoa_Click(object sender, EventArgs e)
        {
            HangHoaDuocChon?.Invoke(this, _HangHoa);
        }
    }
}
