using QL_Nha_thuoc.model;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa
{
    public partial class UC_ItemThuoc : UserControl
    {
        // Thuộc tính công khai (đọc) để lấy mã hàng hóa
        public string MaHangHoa { get; private set; }
        public int SoLuongTon { get; private set; }
        public UC_ItemThuoc()
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
                ctl.Click += UC_ItemThuoc_Click;
            }

            //// Bắt sự kiện click cho chính UserControl
            //this.Click += UC_ItemThuoc_Click;
        }

        /// <summary>
        /// Thiết lập dữ liệu hiển thị cho UserControl
        /// </summary>
        public void SetData(ClassHangHoa HangHoa)
        {
            labelTenHH.Text = HangHoa.TenHangHoa;
            labelMaHH.Text = HangHoa.MaHangHoa;
            labelGiaBanHH.Text = $"Giá bán: {HangHoa.GiaBan:N0}";
            MaHangHoa = HangHoa.MaHangHoa;
            labelTonHH.Text = "Ton: "+HangHoa.SoLuongTon.ToString();
            SoLuongTon = HangHoa.SoLuongTon;// Lưu số lượng tồn kho
            // Đường dẫn thư mục ảnh
            string thuMucAnh = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-nha-thuoc-Long-Chau\QL_Nha-thuoc\QL_Nha-thuoc\Hinh_anh_hang_hoa";
            string tenHinhAnh = HangHoa.HinhAnh;
            // Nếu có tên hình ảnh
            if (!string.IsNullOrWhiteSpace(tenHinhAnh))
            {
                string duongDan = Path.Combine(thuMucAnh, tenHinhAnh);
                try
                {
                    if (File.Exists(duongDan))
                    {
                        using (var fs = new FileStream(duongDan, FileMode.Open, FileAccess.Read))
                        using (var ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            ms.Position = 0;
                            pictureBoxHinhAnhHH.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        pictureBoxHinhAnhHH.Image = Properties.Resources._default;
                    }
                }
                catch
                {
                    pictureBoxHinhAnhHH.Image = Properties.Resources._default;
                }
            }
            else
            {
                pictureBoxHinhAnhHH.Image = Properties.Resources._default;
            }
        }

        /// <summary>
        /// Khi người dùng click vào toàn bộ control hoặc control con
        /// </summary>
        private void UC_ItemThuoc_Click(object sender, EventArgs e)
        {
            this.OnClick(e); // Gọi lại sự kiện Click để form ngoài xử lý
            //dau so luong ton

        }

        private void UC_ItemThuoc_Load(object sender, EventArgs e)
        {
            // Không cần xử lý gì ở đây
        }
    }
}
