using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace QL_Nha_thuoc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Add("NT00038", "Anaferon Tăng Sức Đề Kháng Nga Siro", 0, 0, 464, 0, "---", "---");
            dataGridView1.Rows.Add("NT00037", "Antimos Soft 2 Chai 50ml Chong Muoi Dot", 0, 0, 0, 0, "31/05/2025 20:07", "---");
            dataGridView1.Rows.Add("NT00036", "Abo Mặt Nạ Phục Hồi Tinh Theo Miếng", 0, 0, 92, 0, "31/05/2025 20:07", "---");
            dataGridView1.Rows.Add("NT00035", "Alsiful Sr 10mg H/3 Vỉ * 10 Viên", 0, 0, 92, 0, "31/05/2025 20:07", "---");
            dataGridView1.Rows.Add("NT00034", "An Cung Hộp Gỗ 60v Hàn Quốc", 0, 0, 0, 0, "31/05/2025 20:07", "---");
            dataGridView1.Rows.Add("NT00033", "Decorte Sun Shelter Spf50", 0, 0, 0, 0, "31/05/2025 20:07", "---");
            dataGridView1.Rows.Add("NT00032", "Alorax Hộp 10 Vi X 10 Viên", 0, 0, 0, 0, "31/05/2025 20:07", "---");
        }
    }
}
