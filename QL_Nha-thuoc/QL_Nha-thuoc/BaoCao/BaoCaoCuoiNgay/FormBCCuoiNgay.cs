using QL_Nha_thuoc.model;
using QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay
{
    public partial class FormBCCuoiNgay : Form
    {
        private enum LoaiBaoCao
        {
            BanHang,
            HangHoa,
            ThuChi
        }

        private LoaiBaoCao loaiHienTai = LoaiBaoCao.BanHang;

        private List<ClassHoaDon> danhSachBanHang;
        private List<ClassHangHoa> danhSachHangHoa;
        private List<ClassPhieuThuChi> danhSachThuChi;

        public FormBCCuoiNgay()
        {
            InitializeComponent();

            // Mặc định chọn radioButtonBanHang
            radioButtonBanHang.Checked = true;

            // Gán sự kiện
            btnInBaoCao.Click += BtnInBaoCao_Click;
            radioButtonBanHang.CheckedChanged += radioButtonBanHang_CheckedChanged;
            radioButtonHangHoa.CheckedChanged += radioButtonHangHoa_CheckedChanged;
            radioButtonThuChi.CheckedChanged += radioButtonThuChi_CheckedChanged;
        }

        private void LoadDataBanHang()
        {
            DateTime ngayBaoCao = DateTime.Today;
            danhSachBanHang = ClassHoaDon.LayDanhSachHoaDon().FindAll(hd => hd.NgayLapHD.HasValue && hd.NgayLapHD.Value.Date == ngayBaoCao);

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaHoaDon",
                HeaderText = "Mã HĐ",
                Width = 80
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgayLapHD",
                HeaderText = "Ngày Lập",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ThanhTien",
                HeaderText = "Tổng Tiền (VNĐ)",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvHoaDon.DataSource = danhSachBanHang;
            // 🚀 Dòng này giúp cột tự động giãn theo chiều rộng DataGridView
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDataHangHoa()
        {
            danhSachHangHoa = ClassHangHoa.LayToanBoHH();

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaHangHoa",
                HeaderText = "Mã Hàng Hóa",
                Width = 100
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenHangHoa",
                HeaderText = "Tên Hàng Hóa",
                Width = 200
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "GiaBan",
                HeaderText = "Giá Bán",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvHoaDon.DataSource = danhSachHangHoa;
            // 🚀 Dòng này giúp cột tự động giãn theo chiều rộng DataGridView
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void LoadDataThuChi()
        {
            danhSachThuChi = ClassPhieuThuChi.LayDanhSachPhieuThuChi();

            dgvHoaDon.DataSource = null;
            dgvHoaDon.Columns.Clear();
            dgvHoaDon.AutoGenerateColumns = false;

            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaPhieuThuChi",
                HeaderText = "Mã Phiếu Thu Chi",
                Width = 120
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "NgayLapPhieu",
                HeaderText = "Ngày",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaLoaiPhieu",
                HeaderText = "Loại",
                Width = 80
            });
            dgvHoaDon.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "SoTien",
                HeaderText = "Số Tiền",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N0" }
            });

            dgvHoaDon.DataSource = danhSachThuChi;
            // 🚀 Dòng này giúp cột tự động giãn theo chiều rộng DataGridView
            dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void radioButtonBanHang_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBanHang.Checked)
            {
                loaiHienTai = LoaiBaoCao.BanHang;
                LoadDataBanHang();
            }
        }

        private void radioButtonHangHoa_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHangHoa.Checked)
            {
                loaiHienTai = LoaiBaoCao.HangHoa;
                LoadDataHangHoa();
            }
        }

        private void radioButtonThuChi_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonThuChi.Checked)
            {
                loaiHienTai = LoaiBaoCao.ThuChi;
                LoadDataThuChi();
            }
        }

        private void BtnInBaoCao_Click(object sender, EventArgs e)
        {
            string folderPath = @"C:\Users\hotan\OneDrive\Tài liệu\GitHub\DoAn1_DH22TIN03_HoTanTai_VuTanTai_ung-dung-desktop-quan-ly-cua-hang-thuoc-tay\QL_Nha-thuoc\QL_Nha-thuoc\PHIEU_IN\BaoCao";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            DateTime ngayBaoCao = DateTime.Today;

            try
            {
                switch (loaiHienTai)
                {
                    case LoaiBaoCao.BanHang:
                        if (danhSachBanHang == null || danhSachBanHang.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu bán hàng để in báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        var baoCaoBanHang = new BaoCaoCuoiNgay.BaoCaoBanHang(danhSachBanHang, ngayBaoCao);
                        string pdfPathBanHang = Path.Combine(folderPath, $"BaoCaoBanHang_{ngayBaoCao:yyyyMMdd}.pdf");
                        baoCaoBanHang.GeneratePdf(pdfPathBanHang);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = pdfPathBanHang,
                            UseShellExecute = true
                        });
                        break;

                    case LoaiBaoCao.HangHoa:
                        if (danhSachHangHoa == null || danhSachHangHoa.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu hàng hóa để in báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        var baoCaoHangHoa = new BaoCaoCuoiNgay.BaoCaoHangHoa(danhSachHangHoa, ngayBaoCao);
                        string pdfPathHangHoa = Path.Combine(folderPath, $"BaoCaoHangHoa_{ngayBaoCao:yyyyMMdd}.pdf");
                        baoCaoHangHoa.GeneratePdf(pdfPathHangHoa);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = pdfPathHangHoa,
                            UseShellExecute = true
                        });
                        break;

                    case LoaiBaoCao.ThuChi:
                        if (danhSachThuChi == null || danhSachThuChi.Count == 0)
                        {
                            MessageBox.Show("Không có dữ liệu thu chi để in báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        var baoCaoThuChi = new BaoCaoThuChi(danhSachThuChi, ngayBaoCao); // Bạn cần tự tạo lớp này
                        string pdfPathThuChi = Path.Combine(folderPath, $"BaoCaoThuChi_{ngayBaoCao:yyyyMMdd}.pdf");
                        baoCaoThuChi.GeneratePdf(pdfPathThuChi);
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo()
                        {
                            FileName = pdfPathThuChi,
                            UseShellExecute = true
                        });
                        break;
                }

                MessageBox.Show("Đã tạo báo cáo PDF thành công.", "Hoàn thành", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo báo cáo:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
