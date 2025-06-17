using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.BanHang;
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
    public partial class FormThemKiemKho : Form
    {
        private string maPhieuKiemKho;

        public FormThemKiemKho(string maPhieu)
        {
            InitializeComponent();
            maPhieuKiemKho = maPhieu;

            // Khởi tạo user control và truyền mã kiểm kho vào
            var control = new UserControlFormKiemKho(maPhieuKiemKho);
            control.Dock = DockStyle.Fill;

            // Thêm control vào panel hoặc layout có sẵn
            tabPageTatCaPhieuKiem.Controls.Add(control); // panelMain là Panel chứa UC
        }
        List<Thuoc> TimThuocTuCSDL(string keyword)
        {
            var ketQua = new List<Thuoc>();

            CSDL cSDL = new CSDL();
            string connectionString = cSDL.GetConnection().ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
            SELECT 
                HH.MA_HANG_HOA, 
                HH.TEN_HANG_HOA, 
                GBHH.GIA_BAN_HH, 
                HH.HINH_ANH_HH,
                HH.TON_KHO
            FROM 
                HANG_HOA HH
            JOIN 
                GIA_HANG_HOA GBHH 
            ON 
                HH.MA_HANG_HOA = GBHH.MA_HANG_HOA
            WHERE TEN_HANG_HOA LIKE @keyword";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var t = new Thuoc
                            {
                                Ma = reader["MA_HANG_HOA"].ToString(),
                                Ten = reader["TEN_HANG_HOA"].ToString(),
                                Gia = Convert.ToUInt32(reader["GIA_BAN_HH"]),
                                hinhanhhh = reader["HINH_ANH_HH"].ToString(),
                                SoLuongTon = Convert.ToInt32(reader["TON_KHO"])
                            };

                            ketQua.Add(t);
                        }
                    }
                }
            }

            return ketQua;
        }


        private void ThemHangVaoTabHienTai(model.ClassHangHoa thongtin)
        {
            if (tabControlPhieuKiem.TabPages.Count > 0)
            {
                var currentTab = tabControlPhieuKiem.SelectedTab;

                // Tìm UserControlFormHoaDon trong TabPage hiện tại
                var ucFormKiemKho = currentTab.Controls.OfType<UserControlFormKiemKho>().FirstOrDefault();

                if (ucFormKiemKho != null)
                {
                    ucFormKiemKho.ThemHang(thongtin); // Gọi tới hàm đã định nghĩa trong UC
                    ucFormKiemKho.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ không gian của TabPage
                }

            }
        }
        private void textBoxTimHH_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            //hien kết quả tìm kiếm
            panelKetQuaTimKiem.Visible = true;
            string keyword = textBoxTimHH.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var ds = TimThuocTuCSDL(keyword);
            if (ds.Count == 0)
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            panelKetQuaTimKiem.Controls.Clear();
            int y = 0;

            foreach (var thuoc in ds)
            {
                var uc = new UC_ItemThuoc();
                uc.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia, thuoc.hinhanhhh, thuoc.SoLuongTon);
                uc.Location = new Point(0, y);
                uc.Dock = DockStyle.Top;
                y += uc.Height + 10;

                uc.Click += (s, e) =>
                {
                    // Khi người dùng click vào một hàng hóa trong kết quả tìm kiếm
                    model.ClassHangHoa thongtin = model.ClassHangHoa.LayThongTinMotHangHoa(thuoc.Ma);
                    ThemHangVaoTabHienTai(thongtin);
                    panelKetQuaTimKiem.Visible = false; // Ẩn panel kết quả tìm kiếm sau khi chọn
                    textBoxTimHH.Text = ""; // Xóa nội dung ô tìm kiếm
                };

                panelKetQuaTimKiem.Controls.Add(uc);
            }

        }

        private void FormThemKiemKho_Load(object sender, EventArgs e)
        {
            if (tabControlPhieuKiem.TabPages.Count > 0)
            {
                var currentTab = tabControlPhieuKiem.TabPages[0];

                var userControlKiemKho = new UserControlFormKiemKho(maPhieuKiemKho);
                userControlKiemKho.Dock = DockStyle.Fill;

                currentTab.Controls.Clear();
                currentTab.Controls.Add(userControlKiemKho);
                userControlKiemKho.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ không gian của TabPage
            }
        }

        private void tabControlPhieuKiem_SizeChanged(object sender, EventArgs e)
        {
            var currentTab = tabControlPhieuKiem.SelectedTab;
            if (currentTab == null) return;

            var ucForm = currentTab.Controls.OfType<UserControlFormKiemKho>().FirstOrDefault();
            if (ucForm == null) return;

            var flPanel = ucForm.Controls.Find("flowLayoutPanelKiemKho", true).FirstOrDefault() as FlowLayoutPanel;
            if (flPanel == null) return;

            int newWidth = flPanel.ClientSize.Width - flPanel.Padding.Horizontal - 5;

            foreach (var ctrl in flPanel.Controls.OfType<UserControlHangHoaKiemKho>())
            {
                ctrl.Width = newWidth;
            }
        }

        private void buttonTroLai_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn lưu lại thay đổi phiếu không?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Lưu lại phiếu với trạng thái "Phiếu tạm"
                var currentTab = tabControlPhieuKiem.SelectedTab;
                if (currentTab != null)
                {
                    var ucFormKiemKho = currentTab.Controls.OfType<UserControlFormKiemKho>().FirstOrDefault();
                    if (ucFormKiemKho != null)
                    {
                        ucFormKiemKho.CapNhatTongSoLuongThucTe(); // cập nhật tổng số lượng

                        var phieu = new PhieuKiemKho
                        {
                            MaPhieuKiemKho = ucFormKiemKho.MaKiemKho,
                            MaNhanVien = Session.TaiKhoanDangNhap.MaNhanVien,
                            TrangThaiPhieuKiem = "Phiếu tạm",
                            GhiChu = ucFormKiemKho.ghiChu,
                            NgayKiemKho = DateTime.Now
                        };

                        bool ketQua = PhieuKiemKho.CapNhatPhieuKiemKho(phieu);
                        if (ketQua)
                        {
                            MessageBox.Show("Đã lưu phiếu kiểm kho tạm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi lưu thành công
                        }
                        else
                            MessageBox.Show("Lưu không thành công.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else if (result == DialogResult.No)
            {
                // Hủy bỏ và xóa phiếu kiểm kho đang tạo
                var currentTab = tabControlPhieuKiem.SelectedTab;
                if (currentTab != null)
                {
                    var ucFormKiemKho = currentTab.Controls.OfType<UserControlFormKiemKho>().FirstOrDefault();
                    if (ucFormKiemKho != null)
                    {
                        string maPhieu = ucFormKiemKho.MaKiemKho;
                        bool xoachitiet =  ClassChiTietPhieuKiemKho.XoaChiTietPhieuKiemKho(maPhieu); // Xóa chi tiết phiếu kiểm kho
                        // Gọi hàm xóa phiếu kiểm kho trong database
                        bool xoaThanhCong = PhieuKiemKho.XoaPhieuKiemKho(maPhieu);

                        if (xoaThanhCong&&xoachitiet)
                        {
                            MessageBox.Show("Đã hủy và xóa phiếu kiểm kho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            tabControlPhieuKiem.TabPages.Remove(currentTab); // Xóa tab
                            this.Close(); // Đóng form
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa phiếu kiểm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void buttonThemHangHoa_Click(object sender, EventArgs e)
        {
            //mo form them hang hoa
            FormThemHanghoa formThemHangHoa = new FormThemHanghoa(maPhieuKiemKho);
            formThemHangHoa.FormClosed += (s, args) =>
            {
                // Khi form ThemHangHoa đóng, cập nhật lại danh sách hàng hóa trong tab hiện tại
                var currentTab = tabControlPhieuKiem.SelectedTab;
                if (currentTab != null)
                {
                    var ucFormKiemKho = currentTab.Controls.OfType<UserControlFormKiemKho>().FirstOrDefault();
                    if (ucFormKiemKho != null)
                    {
                        ucFormKiemKho.CapNhatTongSoLuongThucTe(); // Cập nhật tổng số lượng thực tế
                    }
                }
            };
            formThemHangHoa.ShowDialog(this); // Hiển thị form ThemHangHoa như một dialog
        }






    }

}
