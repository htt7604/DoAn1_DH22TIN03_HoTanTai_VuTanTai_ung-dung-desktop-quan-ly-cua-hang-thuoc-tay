using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    public partial class FormSuaBangGia : Form
    {
        public string maBangGia;
        public FormSuaBangGia()
        {
            InitializeComponent();
            loadcomboBoxLoaiGia();
        }
        // Đổi tên để không trùng với sự kiện mặc định
        public event EventHandler FormSuaBangGiaClosed;

        public string phepTinh;

        public string donVi;
        private void loadcomboBoxLoaiGia()
        {
            var loaiGiaList = new List<string> { "Giá vốn", "Giá bán" };
            comboBoxLoaiGia.DataSource = loaiGiaList;
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public void Setdata(ClassBangGia classBangGia)
        {
            maBangGia = classBangGia.MaBangGia;//luu de xoa 
            textBoxTenBangGia.Text = classBangGia.TenBangGia;


            dateTimePickerDenNgay.MinDate = DateTimePicker.MinimumDateTime;
            dateTimePickerDenNgay.MaxDate = DateTimePicker.MaximumDateTime;

            DateTime denNgay = classBangGia.DenNgay;
            if (denNgay < dateTimePickerDenNgay.MinDate)
                denNgay = dateTimePickerDenNgay.MinDate;
            else if (denNgay > dateTimePickerDenNgay.MaxDate)
                denNgay = dateTimePickerDenNgay.MaxDate;

            dateTimePickerDenNgay.Value = denNgay;





            if (classBangGia.TrangThai == "Đang áp dụng")
            {
                radioButtonApDung.Checked = true;
            }
            else if (classBangGia.TrangThai == "Chưa áp dụng")
            {
                radioButtonChuaApDung.Checked = true;
            }



            if (classBangGia.DungGiaVon == true)
            {
                comboBoxLoaiGia.SelectedItem = "Giá vốn";
            }
            else if (classBangGia.DungGiaVon == false)
            {
                comboBoxLoaiGia.SelectedItem = "Giá bán";
            }


            if (classBangGia.TangGiam == true)
            {
                phepTinh = "+";
                buttonCong.Enabled = false;
                buttonCong.BackColor = Color.LightGreen;
                buttonTru.Enabled = true;
                buttonTru.BackColor = SystemColors.Control;

            }
            else if (classBangGia.TangGiam == false)
            {
                phepTinh = "-";
                buttonCong.Enabled = true;
                buttonCong.BackColor = SystemColors.Control;
                buttonTru.Enabled = false;
                buttonTru.BackColor = Color.LightGreen;
            }



            if (classBangGia.LaPhanTram == true)
            {
                donVi = "%";
                buttonVND.Enabled = true;
                buttonVND.BackColor = SystemColors.Control;
                buttonPhanTram.Enabled = false;
                buttonPhanTram.BackColor = Color.LightGreen;
            }
            else if (classBangGia.LaPhanTram == false)
            {
                donVi = "VND";
                buttonVND.Enabled = false;
                buttonVND.BackColor = Color.LightGreen;
                buttonPhanTram.Enabled = true;
                buttonPhanTram.BackColor = SystemColors.Control;
            }

            if (classBangGia.ChoChonNgoaiBangGia == true)
            {
                radioButtonChonPhep.Checked = true;
            }
            else if (classBangGia.ChoChonNgoaiBangGia == false)
            {
                radioButtonKhongChoPhep.Checked = true;
            }


            textBoxSoNhap.Text = classBangGia.GiaTriTangGiam.ToString();
        }




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

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa bảng giá này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                bool thanhCong = ClassBangGia.XoaBangGia(maBangGia);
                if (thanhCong)
                {
                    MessageBox.Show("Đã xóa bảng giá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormSuaBangGiaClosed?.Invoke(this, EventArgs.Empty);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Xóa bảng giá thất bại. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
                classBangGia.MaBangGia = maBangGia;

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

                bool result = ClassBangGia.SuaBangGia(classBangGia);
                if (result)
                {
                    MessageBox.Show("Chỉnh sửa bảng giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FormSuaBangGiaClosed?.Invoke(this, EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể chỉnh sửa bảng giá. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }








    }
}
