using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.HangHoa;
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
                string query = "SELECT HH.MA_HANG_HOA, HH.TEN_HANG_HOA, GBHH.GIA_BAN_HH, HH.HINH_ANH_HH FROM HANG_HOA HH JOIN GIA_HANG_HOA GBHH ON HH.MA_HANG_HOA = GBHH.MA_HANG_HOA  WHERE TEN_HANG_HOA LIKE @keyword";
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
                                Gia = Convert.ToInt32(reader["GIA_BAN_HH"]),
                                hinhanhhh = reader["HINH_ANH_HH"].ToString()
                            };
                            ketQua.Add(t);
                        }
                    }
                }
            }

            return ketQua;
        }



        private void ThemHangVaoTabHienTai(string ten, string mah)
        {
            if (tabControlHoaDon.TabPages.Count > 0)
            {
                var currentTab = tabControlHoaDon.SelectedTab;

                // Tìm UserControlFormHoaDon trong TabPage hiện tại
                var ucFormHoaDon = currentTab.Controls.OfType<UserControlFormHoaDon>().FirstOrDefault();

                if (ucFormHoaDon != null)
                {
                    ucFormHoaDon.ThemHang(ten, mah); // Gọi tới hàm đã định nghĩa trong UC
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

            var ds = TimThuocTuCSDL(keyword);

            panelKetQuaTimKiem.Controls.Clear();
            int y = 0;

            foreach (var thuoc in ds)
            {
                var uc = new UC_ItemThuoc();
                uc.SetData(thuoc.Ten, thuoc.Ma, thuoc.Gia, thuoc.hinhanhhh);
                uc.Width = panelKetQuaTimKiem.Width;
                uc.Location = new Point(0, y);
                y += uc.Height + 10;

                // Gắn sự kiện Click để thêm vào tab hiện tại
                uc.Click += (s, e) =>
                {
                    ThemHangVaoTabHienTai(thuoc.Ten, thuoc.Ma);

                    panelKetQuaTimKiem.Visible = false;
                    textBoxTimHH.Clear();
                };


                panelKetQuaTimKiem.Controls.Add(uc);
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
    }
}
