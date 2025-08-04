using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Nha_thuoc.model;

namespace QL_Nha_thuoc.BanHang
{
    public partial class FormThemTaiKhoanNganHang : Form
    {
        public FormThemTaiKhoanNganHang()
        {
            InitializeComponent();
            _ = LoadDanhSachNganHangAsync(); // Gọi bất đồng bộ không cần chờ
        }

        private async Task LoadDanhSachNganHangAsync()
        {
            string apiUrl = "https://api.vietqr.io/v2/banks";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();

                    var content = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(content))
                    {
                        var banks = doc.RootElement.GetProperty("data");
                        var danhSach = new List<ClassBankInfo>();

                        foreach (var bank in banks.EnumerateArray())
                        {
                            var code = bank.GetProperty("code").GetString();
                            var shortName = bank.GetProperty("shortName").GetString();

                            danhSach.Add(new ClassBankInfo { Code = code, ShortName = shortName });
                        }

                        comboBoxNganHang.DataSource = danhSach;
                        comboBoxNganHang.DisplayMember = nameof(ClassBankInfo.ToString); // ToString sẽ được dùng
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tải ngân hàng: " + ex.Message);
                }
            }
        }
        private void buttonLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(textBoxChuTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên chủ tài khoản!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxChuTaiKhoan.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSoTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSoTaiKhoan.Focus();
                return;
            }

            if (!(comboBoxNganHang.SelectedItem is ClassBankInfo selectedBank))
            {
                MessageBox.Show("Vui lòng chọn ngân hàng!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxNganHang.Focus();
                return;
            }

            var taiKhoan = new ClassTaiKhoanNganHang
            {
                TenChuTK = textBoxChuTaiKhoan.Text.Trim(),
                SoTaiKhoan = textBoxSoTaiKhoan.Text.Trim(),
                TenNganHang = selectedBank.ShortName,
                GhiChu = textBoxGhiChu.Text.Trim()
            };

            bool ketQua = taiKhoan.ThemTaiKhoan();

            if (ketQua)
            {
                MessageBox.Show("Thêm tài khoản ngân hàng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // hoặc ResetForm();
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }
}
