using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    public partial class FormSuaGiaBanitem : Form
    {
        //dung de hien thi 
        private decimal giaCu;
        //dung de cap nhat gia moi
        private decimal giaMoi;

        //dung de luu ma hang hoa va ma don vi tinh
        private string _maHangHoa;
        private string _maDonViTinh;
        private ClassGiaBanHH hanghoa;
        private Form formCha;
        private FormThietLapGia formThietLapGia;


        private string phepTinh = "+";
        private string donVi = "VND";
        public FormSuaGiaBanitem(string maHangHoa, string maDonViTinh, FormThietLapGia ucGoc)
        {
            InitializeComponent();
            _maHangHoa = maHangHoa;
            _maDonViTinh = maDonViTinh;
            hanghoa = ClassGiaBanHH.LayGiaBanTheoMavamaDVT(_maHangHoa, _maDonViTinh);
            giaCu = hanghoa?.GiaBan ?? 0;
            formThietLapGia = ucGoc;
            this.formThietLapGia = formThietLapGia;
        }

        private void FormSuaGiaBanitem_Load(object sender, EventArgs e)
        {
            buttonCong.Enabled = false;
            buttonCong.BackColor = Color.LightGreen;
            buttonTru.Enabled = true;
            buttonTru.BackColor = SystemColors.Control;
            buttonVND.Enabled = false;
            buttonVND.BackColor = Color.LightGreen;
            buttonPhanTram.Enabled = true;
            buttonPhanTram.BackColor = SystemColors.Control;

            labelHienThi.Text = $"Giá mới {giaCu:N0} {donVi}";
            loadcomboBoxLoaiGia();
        }

        private void loadcomboBoxLoaiGia()
        {
            var loaiGiaList = new List<string> { "Giá vốn", "Giá bán" };
            comboBoxLoaiGia.DataSource = loaiGiaList;
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void textBoxSoNhap_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }




        private void btnCong_Click(object sender, EventArgs e)
        {
            phepTinh = "+";
            buttonCong.Enabled = false;
            buttonCong.BackColor = Color.LightGreen;
            buttonTru.Enabled = true;
            buttonTru.BackColor = SystemColors.Control;
            textBoxSoNhap.Clear();
        }

        private void btnTru_Click(object sender, EventArgs e)
        {
            phepTinh = "-";
            buttonCong.Enabled = true;
            buttonCong.BackColor = SystemColors.Control;
            buttonTru.Enabled = false;
            buttonTru.BackColor = Color.LightGreen;
            textBoxSoNhap.Clear();
        }

        private void btnVND_Click(object sender, EventArgs e)
        {
            donVi = "VND";
            buttonVND.Enabled = false;
            buttonVND.BackColor = Color.LightGreen;
            buttonPhanTram.Enabled = true;
            buttonPhanTram.BackColor = SystemColors.Control;
            textBoxSoNhap.Clear();
        }

        private void btnPhanTram_Click(object sender, EventArgs e)
        {
            donVi = "%";
            buttonVND.Enabled = true;
            buttonVND.BackColor = SystemColors.Control;
            buttonPhanTram.Enabled = false;
            buttonPhanTram.BackColor = Color.LightGreen;
            textBoxSoNhap.Clear();
        }

        private void textBoxSoNhap_TextChanged(object sender, EventArgs e)
        {

            if (!decimal.TryParse(textBoxSoNhap.Text, out decimal soNhap))
            {
                labelHienThi.Text = $"Giá mới {giaCu:N0} {donVi}";
                return;
            }

            if (donVi == "%" && soNhap > 100)
            {
                textBoxSoNhap.Text = "100";
                textBoxSoNhap.SelectionStart = textBoxSoNhap.Text.Length;
                return;
            }

            if (phepTinh == "-" && donVi == "VND" && soNhap > giaCu)
            {
                textBoxSoNhap.Text = giaCu.ToString();
                textBoxSoNhap.SelectionStart = textBoxSoNhap.Text.Length;
                return;
            }

            if (phepTinh == "-" && donVi == "%" && soNhap > 100)
            {
                textBoxSoNhap.Text = "100";
                textBoxSoNhap.SelectionStart = textBoxSoNhap.Text.Length;
                return;
            }
            TinhGiaMoi();
        }

        private void comboBoxLoaiGia_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxSoNhap.Clear();
            TinhGiaMoi();
        }

        private void FormSuaGiaBanitem_Click(object sender, EventArgs e)
        {
            textBoxSoNhap.Clear();
        }



        private void TinhGiaMoi()
        {
            if (!decimal.TryParse(textBoxSoNhap.Text, out decimal soThayDoiGia))
            {
                soThayDoiGia = 0;
            }

            // Xác định loại giá được chọn: GIA_HIEN_TAI hay Gia von
            string cachtinh = comboBoxLoaiGia.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(cachtinh)) return;

            // Chọn giá gốc (giaCu) tương ứng
            decimal giadetinh = cachtinh == "Giá vốn" ? hanghoa.GiaVon : hanghoa.GiaBan;

            // Tính giá mới
            giaMoi = phepTinh == "+"
                ? giadetinh + (donVi == "VND" ? soThayDoiGia : giadetinh * soThayDoiGia / 100)
                : giadetinh - (donVi == "VND" ? soThayDoiGia : giadetinh * soThayDoiGia / 100);

            labelHienThi.Text = $"Giá mới [{giaMoi:N0}] =";
        }


        private void buttonDongY_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBoxSoNhap.Text, out decimal soThayDoiGia) || soThayDoiGia <= 0)
            {
                MessageBox.Show("Giá trị thay đổi không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string cachtinh = comboBoxLoaiGia.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(cachtinh))
            {
                MessageBox.Show("Vui lòng chọn loại giá cần thay đổi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Áp dụng toàn bộ
            if (checkBoxApDungAll.Checked)
            {
                var danhSach = formThietLapGia.danhMucLoc;
                int soThanhCong = 0;

                foreach (var hh in danhSach)
                {
                    decimal giaGoc = cachtinh == "Giá vốn" ? hh.GiaVon : hh.GiaBan;

                    decimal giaMoiHH = phepTinh == "+"
                        ? giaGoc + (donVi == "VND" ? soThayDoiGia : giaGoc * soThayDoiGia / 100)
                        : giaGoc - (donVi == "VND" ? soThayDoiGia : giaGoc * soThayDoiGia / 100);

                    hh.GiaBan = giaMoiHH;
                    hh.MaBangGia = "BG001"; // giả sử có mã bảng giá mặc định

                    // Gán thông tin tăng/giảm
                    hh.LaPhanTram = donVi == "%";
                    hh.TangGiam = phepTinh == "+";
                    hh.GiaTriTangGiam = soThayDoiGia;

                    if (ClassGiaBanHH.CapNhatGiaBan(hh))
                        soThanhCong++;
                }

                MessageBox.Show($"Đã cập nhật giá cho {soThanhCong} sản phẩm!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                formThietLapGia.FormThietLapGia_Load(sender, e); // refresh lại
                this.Close();
                return;
            }

            // Cập nhật cho 1 sản phẩm
            decimal giaHienTai = cachtinh == "Giá vốn" ? hanghoa.GiaVon : hanghoa.GiaBan;
            decimal giaMoi = phepTinh == "+"
                ? giaHienTai + (donVi == "VND" ? soThayDoiGia : giaHienTai * soThayDoiGia / 100)
                : giaHienTai - (donVi == "VND" ? soThayDoiGia : giaHienTai * soThayDoiGia / 100);

            hanghoa.GiaBan = giaMoi;
            hanghoa.MaHangHoa = _maHangHoa;

            // Gán lại các thuộc tính mới
            hanghoa.LaPhanTram = donVi == "%";
            hanghoa.TangGiam = phepTinh == "+";
            hanghoa.GiaTriTangGiam = soThayDoiGia;

            bool kq = ClassGiaBanHH.CapNhatGiaBan(hanghoa);
            if (kq)
            {
                MessageBox.Show("Cập nhật giá thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var giaBanMoi = ClassGiaBanHH.LayGiaBanTheoMavamaDVT(_maHangHoa, _maDonViTinh);
                if (giaBanMoi != null)
                {
                    formThietLapGia.FormThietLapGia_Load(sender, e);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Cập nhật giá thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            //dong form 
            this.Close();
            //load lai danh sach gia ban
            formThietLapGia.FormThietLapGia_Load(sender, e);
        }
    }
}
