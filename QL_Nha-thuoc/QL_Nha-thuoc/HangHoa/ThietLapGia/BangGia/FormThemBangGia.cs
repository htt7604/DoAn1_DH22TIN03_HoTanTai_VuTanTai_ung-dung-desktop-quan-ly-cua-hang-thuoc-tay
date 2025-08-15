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
    public partial class FormThemBangGia : Form
    {
        public FormThemBangGia()
        {
            InitializeComponent();
            loadcomboBoxLoaiGia();
            //2 datetime mac dinh 1 nam 
            dateTimePickerTuNgay.Value = DateTime.Now;
            dateTimePickerDenNgay.Value = DateTime.Now.AddYears(1);
        }
        // Sự kiện cho biết form đã đóng (ví dụ: để form cha cập nhật lại danh sách bảng giá)
        public event EventHandler? FormThemBangGiaClosed;


        private void loadcomboBoxLoaiGia()
        {
            var loaiGiaList = new List<string> { "Giá vốn", "Giá bán" };
            comboBoxLoaiGia.DataSource = loaiGiaList;
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void FormThemBangGia_Load(object sender, EventArgs e)
        {
            radioButtonApDung.Checked = true;
            radioButtonChonPhep.Checked = true;

            //buttn VND
            donVi = "VND";
            buttonVND.Enabled = false;
            buttonVND.BackColor = Color.LightGreen;
            buttonPhanTram.Enabled = true;
            buttonPhanTram.BackColor = SystemColors.Control;


            //btt +
            phepTinh = "+";
            buttonCong.Enabled = false;
            buttonCong.BackColor = Color.LightGreen;
            buttonTru.Enabled = true;
            buttonTru.BackColor = SystemColors.Control;
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

        //load comboBoxLoaiGia



        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            FormThemBangGiaClosed?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ClassBangGia classBangGia = new ClassBangGia();

                if (string.IsNullOrWhiteSpace(textBoxTenBangGia.Text))
                {
                    MessageBox.Show("Tên bảng giá không được để trống.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    classBangGia.TenBangGia = textBoxTenBangGia.Text;
                }

                // Tạo mã tự động
                classBangGia.MaBangGia = ClassBangGia.TaoMaBangGiaTuDong();

                classBangGia.TuNgay = dateTimePickerTuNgay.Value;
                classBangGia.DenNgay = dateTimePickerDenNgay.Value;

                classBangGia.TangGiam = (phepTinh == "+");
                classBangGia.LaPhanTram = (donVi == "%");

                classBangGia.ChoChonNgoaiBangGia = radioButtonChonPhep.Checked;

                decimal giaTriTangGiam;
                if (decimal.TryParse(textBoxSoNhap.Text, out giaTriTangGiam))
                {
                    classBangGia.GiaTriTangGiam = giaTriTangGiam;
                }
                else
                {
                    classBangGia.GiaTriTangGiam = 0;
                }

                if (radioButtonApDung.Checked)
                {
                    classBangGia.TrangThai = "Đang áp dụng";
                }
                else if (radioButtonChuaApDung.Checked)
                {
                    classBangGia.TrangThai = "Chưa áp dụng";
                }


                if (comboBoxLoaiGia.SelectedItem != null && comboBoxLoaiGia.SelectedItem.ToString() == "Giá vốn")
                {
                    classBangGia.DungGiaVon = true;
                }
                else
                {
                    classBangGia.DungGiaVon = false;
                }


                //classBangGia.CoApDungTinhGiaTuDong = checkBoxTinhGiaTuDong.Checked;

                bool result = ClassBangGia.ThemBangGia(classBangGia);
                if (result)
                {
                    MessageBox.Show("Thêm bảng giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormThemBangGiaClosed?.Invoke(this, EventArgs.Empty);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể thêm bảng giá. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBoxSoNhap_TextChanged(object sender, EventArgs e)
        {
            if (donVi == "%")
            {
                if (decimal.TryParse(textBoxSoNhap.Text, out decimal value))
                {
                    if (value > 100)
                    {
                        MessageBox.Show("Không được nhập quá 100%.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoNhap.Text = "100";
                        textBoxSoNhap.SelectionStart = textBoxSoNhap.Text.Length; // đưa con trỏ về cuối
                    }
                    else if (value < 0)
                    {
                        MessageBox.Show("Không được nhập giá trị âm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textBoxSoNhap.Text = "0";
                        textBoxSoNhap.SelectionStart = textBoxSoNhap.Text.Length;
                    }
                }
            }
        }

        private void dateTimePickerDenNgay_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimePickerDenNgay.Value < dateTimePickerTuNgay.Value)
            {
                MessageBox.Show("Đến ngày không được nhỏ hơn Từ ngày.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePickerDenNgay.Value = dateTimePickerTuNgay.Value;
            }
        }


    }
}
