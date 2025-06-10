using Microsoft.Data.SqlClient;
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

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormBanHangMain : Form
    {
        public FormBanHangMain()
        {
            InitializeComponent();
        }
        //tim thuoc
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
            WHERE 
                TEN_HANG_HOA LIKE @keyword";

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




        private void ThemHangVaoTabHienTai(string ten, string mah, float giaBan)
        {
            if (tabControlHoaDon.TabPages.Count > 0)
            {
                var currentTab = tabControlHoaDon.SelectedTab;

                // Tìm UserControlFormHoaDon trong TabPage hiện tại
                var ucFormHoaDon = currentTab.Controls.OfType<UserControlFormHoaDon>().FirstOrDefault();

                if (ucFormHoaDon != null)
                {
                    ucFormHoaDon.ThemHang(ten, mah, giaBan); // Gọi tới hàm đã định nghĩa trong UC
                }
            }
        }
        private void ThemTabHoaDonMoi()
        {
            var newTab = new TabPage("Hóa đơn " + (tabControlHoaDon.TabCount + 1));
            var userControlHoaDon = new UserControlFormHoaDon();
            userControlHoaDon.Dock = DockStyle.Fill;

            newTab.Controls.Add(userControlHoaDon);
            tabControlHoaDon.TabPages.Add(newTab);
            tabControlHoaDon.SelectedTab = newTab;
        }




        private void textBoxTimHH_TextChanged_1(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            string keyword = textBoxTimHH.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                panelKetQuaTimKiem.Visible = false;
                return;
            }

            var danhSachThuoc = TimThuocTuCSDL(keyword);
            panelKetQuaTimKiem.Controls.Clear();

            foreach (var thuoc in danhSachThuoc)
            {
                UC_ItemThuoc item = new UC_ItemThuoc();
                item.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia, thuoc.hinhanhhh, thuoc.SoLuongTon);
                item.Dock = DockStyle.Top;

                item.Click += (s, ev) =>
                {
                    ThemHangVaoTabHienTai(thuoc.Ten, thuoc.Ma, thuoc.Gia);
                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Clear();
                };

                panelKetQuaTimKiem.Controls.Add(item);
            }
        }



        private void FormBanHangMain_Load(object sender, EventArgs e)
        {
            if (tabControlHoaDon.TabPages.Count > 0)
            {
                var currentTab = tabControlHoaDon.TabPages[0];

                var userControlHoaDon = new UserControlFormHoaDon();
                userControlHoaDon.Dock = DockStyle.Fill;

                currentTab.Controls.Clear();
                currentTab.Controls.Add(userControlHoaDon);
                userControlHoaDon.Dock = DockStyle.Fill; // Đảm bảo UserControl chiếm toàn bộ không gian của TabPage
            }
        }

        private void buttonThemHoaDon_Click(object sender, EventArgs e)
        {
            ThemTabHoaDonMoi();
        }

        private void buttonXoaHoaDon_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có tab nào không
            if (tabControlHoaDon.TabPages.Count > 1)
            {
                //thong báo người dùng co muon xóa không
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa hóa đơn hiện tại không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //neu người dùng đồng ý xóa
                if (result == DialogResult.Yes)
                {
                    // Xóa tab hiện tại
                    var currentTab = tabControlHoaDon.SelectedTab;
                    if (currentTab != null)
                    {
                        tabControlHoaDon.TabPages.Remove(currentTab);
                    }
                }
            }
        }

        private void tabControlHoaDon_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            TabPage currentTab = tabControl.TabPages[e.Index];

            // Kiểm tra nếu là tab được chọn
            bool isSelected = (e.Index == tabControl.SelectedIndex);

            // Chọn màu nền và chữ
            Color backColor = isSelected ? Color.Blue : SystemColors.Control;
            Color textColor = isSelected ? Color.White : Color.Black;

            using (SolidBrush bgBrush = new SolidBrush(backColor))
            using (SolidBrush textBrush = new SolidBrush(textColor))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                // Vẽ nền tab
                e.Graphics.FillRectangle(bgBrush, e.Bounds);

                // Vẽ chữ tiêu đề tab
                e.Graphics.DrawString(currentTab.Text, this.Font, textBrush, e.Bounds, sf);
            }
        }
    }
}
