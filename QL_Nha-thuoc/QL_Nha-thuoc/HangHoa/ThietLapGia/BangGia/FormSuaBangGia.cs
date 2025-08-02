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
    public partial class FormSuaBangGia : Form
    {
        public FormSuaBangGia()
        {
            InitializeComponent();
        }
        private void loadcomboBoxLoaiGia()
        {
            var loaiGiaList = new List<string> { "Giá vốn", "Giá bán" };
            comboBoxLoaiGia.DataSource = loaiGiaList;
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public string phepTinh;
        private void buttonCong_Click(object sender, EventArgs e)
        {
            phepTinh = "+";
            buttonCong.Enabled = false;
            buttonCong.BackColor = Color.LightGreen;
            buttonTru.Enabled = true;
            buttonTru.BackColor = SystemColors.Control;
            textBoxSoNhap.Clear();

        }

        private void buttonTru_Click(object sender, EventArgs e)
        {
            phepTinh = "-";
            buttonCong.Enabled = true;
            buttonCong.BackColor = SystemColors.Control;
            buttonTru.Enabled = false;
            buttonTru.BackColor = Color.LightGreen;
            textBoxSoNhap.Clear();
        }

        public string donVi;
        private void buttonVND_Click(object sender, EventArgs e)
        {
            donVi = "VND";
            buttonVND.Enabled = false;
            buttonVND.BackColor = Color.LightGreen;
            buttonPhanTram.Enabled = true;
            buttonPhanTram.BackColor = SystemColors.Control;
            textBoxSoNhap.Clear();

        }

        private void buttonPhanTram_Click(object sender, EventArgs e)
        {
            donVi = "%";
            buttonVND.Enabled = true;
            buttonVND.BackColor = SystemColors.Control;
            buttonPhanTram.Enabled = false;
            buttonPhanTram.BackColor = Color.LightGreen;
            textBoxSoNhap.Clear();
        }
    }
}
