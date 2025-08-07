using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.HangHoa;
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
using static QL_Nha_thuoc.DanhMuc;

namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    public partial class FormThemKiemKho : Form, ICoTheReload
    {
        private string maPhieuKiemKho;
        public event Action FormDaDong;

        public FormThemKiemKho(string maPhieu)
        {
            InitializeComponent();
            maPhieuKiemKho = maPhieu;
        }

        private void FormThemKiemKho_Load(object sender, EventArgs e)
        {
            var userControlKiemKho = new UserControlFormKiemKho(maPhieuKiemKho);
            userControlKiemKho.Name = "userControlFormKiemKho";
            userControlKiemKho.Dock = DockStyle.Fill;
            panelKiemKho.Controls.Add(userControlKiemKho);

            // Gọi hàm để load danh sách hàng hóa của phiếu
            LoadPhieuKiemKho(maPhieuKiemKho);
        }

        private void LoadPhieuKiemKho(string maPhieu)
        {
            var ucFormKiemKho = this.Controls.Find("userControlFormKiemKho", true).FirstOrDefault() as UserControlFormKiemKho;
            if (ucFormKiemKho == null) return;

            var danhSachHang = ClassChiTietPhieuKiemKho.LayDanhSachChiTietPhieuKiemKho(maPhieu);
            foreach (var hang in danhSachHang)
            {
                // Lấy đầy đủ thông tin hàng hóa để dùng SetData
                var thongtin = ClassHangHoa.LayThongTinMotHangHoa(hang.MaHangHoa);
                thongtin.SoLuongTon = hang.SoLuongHeThong;
                thongtin.TenDonViTinh = hang.TenDonViTinh;

                var item = new UserControlHangHoaKiemKho(hang.MaHangHoa);
                item.SetdataChiTietKiemKho(hang);

                item.Margin = new Padding(0, 5, 0, 0);
                item.Width = ucFormKiemKho.Width - 20;

                item.OnSoLuongThucTeThayDoi += (s, e) =>
                {
                    ucFormKiemKho.CapNhatTongSoLuongThucTe();
                };


                var flPanel = ucFormKiemKho.Controls.Find("flowLayoutPanelKiemKho", true).FirstOrDefault() as FlowLayoutPanel;
                if (flPanel != null)
                    flPanel.Controls.Add(item);
            }

            ucFormKiemKho.CapNhatSTT();
            ucFormKiemKho.CapNhatTongSoLuongThucTe();
        }




        List<ClassHangHoa> TimThuocTuCSDL(string keyword)
        {
            var ketQua = new List<ClassHangHoa>();
            string connectionString = CSDL.GetConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GBHH.GIA_BAN_HH, HH.HINH_ANH_HH, HH.TON_KHO FROM HANG_HOA HH JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA WHERE GBHH.MA_BANG_GIA='BG001' AND TEN_HANG_HOA LIKE @keyword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ketQua.Add(new ClassHangHoa
                            {
                                MaHangHoa = reader["MA_HANG_HOA"].ToString(),
                                TenHangHoa = reader["TEN_HANG_HOA"].ToString(),
                                GiaBan = Convert.ToUInt32(reader["GIA_BAN_HH"]),
                                HinhAnh = reader["HINH_ANH_HH"].ToString(),
                                SoLuongTon = Convert.ToInt32(reader["TON_KHO"])
                            });
                        }
                    }
                }
            }
            return ketQua;
        }

        private void ThemHangVaoFlowLayout(ClassHangHoa thongtin)
        {
            var ucKiemKho = this.Controls.Find("userControlFormKiemKho", true).FirstOrDefault() as UserControlFormKiemKho;
            if (ucKiemKho != null)
            {
                ucKiemKho.ThemHang(thongtin);
                ucKiemKho.CapNhatSTT();
                ucKiemKho.DaXong += () => { FormDaDong?.Invoke(); this.Close(); };
            }
        }

        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;
            string keyword = textBoxTimHH.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var dsHangHoa = TimThuocTuCSDL(keyword);
            if (dsHangHoa.Count == 0)
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            panelKetQuaTimKiem.Controls.Clear();
            int y = 0;

            foreach (var hangHoa in dsHangHoa)
            {
                var uc = new UC_ItemThuoc();
                uc.SetData(hangHoa);
                uc.Dock = DockStyle.Top;
                y += uc.Height + 10;

                uc.Click += (s, e2) =>
                {
                    var thongtin = ClassHangHoa.LayThongTinMotHangHoa(hangHoa.MaHangHoa);
                    ThemHangVaoFlowLayout(thongtin);
                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Text = "";
                };

                panelKetQuaTimKiem.Controls.Add(uc);
            }
        }

        private void buttonTroLai_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu lại thay đổi phiếu không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            var ucFormKiemKho = this.Controls.Find("userControlFormKiemKho", true).FirstOrDefault() as UserControlFormKiemKho;
            if (ucFormKiemKho == null) return;

            if (result == DialogResult.Yes)
            {
                ucFormKiemKho.CapNhatTongSoLuongThucTe();

                var phieu = new ClassPhieuKiemKho
                {
                    MaPhieuKiemKho = ucFormKiemKho.MaKiemKho,
                    MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien,
                    TrangThaiPhieuKiem = "Phiếu tạm",
                    GhiChu = ucFormKiemKho.ghiChu,
                    NgayKiemKho = DateTime.Now
                };

                if (ClassPhieuKiemKho.CapNhatPhieuKiemKho(phieu))
                {
                    MessageBox.Show("Đã lưu phiếu kiểm kho tạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormDaDong?.Invoke();
                    this.Close();
                }
                else MessageBox.Show("Lưu không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (result == DialogResult.No)
            {
                string maPhieu = ucFormKiemKho.MaKiemKho;
                bool xoachitiet = ClassChiTietPhieuKiemKho.XoaChiTietPhieuKiemKho(maPhieu);
                bool xoaThanhCong = ClassPhieuKiemKho.XoaPhieuKiemKho(maPhieu);

                if (xoachitiet && xoaThanhCong)
                {
                    MessageBox.Show("Đã hủy và xóa phiếu kiểm kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormDaDong?.Invoke();
                    this.Close();
                }
                else MessageBox.Show("Không thể xóa phiếu kiểm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonThemHangHoa_Click(object sender, EventArgs e)
        {
            var formThemHangHoa = new FormThemHanghoa(maPhieuKiemKho, this);
            formThemHangHoa.FormClosed += (s, args) =>
            {
                var ucFormKiemKho = this.Controls.Find("userControlFormKiemKho", true).FirstOrDefault() as UserControlFormKiemKho;
                if (ucFormKiemKho != null)
                {
                    ucFormKiemKho.CapNhatTongSoLuongThucTe();
                }
            };
            formThemHangHoa.ShowDialog(this);
        }

        public void ReloadSauKhiThayDoi()
        {
            // load lại dữ liệu nếu cần
        }
    }
}
