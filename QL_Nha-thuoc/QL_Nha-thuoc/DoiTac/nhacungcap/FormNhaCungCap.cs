using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QL_Nha_thuoc.DoiTac.nhacungcap;
using QL_Nha_thuoc.model; // Assuming this is the namespace where ClassNhaCungCap is defined

namespace QL_Nha_thuoc.DoiTac
{
    public partial class FormNhaCungCap : Form
    {
        public FormNhaCungCap()
        {
            InitializeComponent();
        }

        //load comboboxLoctheo
        private void comboBoxLocTheo_load()
        {
            comboBoxLocTheo.Items.Add("Mã NCC");
            comboBoxLocTheo.Items.Add("Tên NCC");
            comboBoxLocTheo.SelectedIndex = 0; // mặc định là "Mã KH"

        }
        //ham load danh sach nha cung cap
        private void LoadDanhSachNhaCungCap()
        {
            // Lấy danh sách nhà cung cấp từ cơ sở dữ liệu
            List<ClassNhaCungCap> danhSachNCC = ClassNhaCungCap.LayDanhSachNhaCungCap();
            // Xóa dữ liệu cũ trong DataGridView
            dataGridViewdsNCC.Rows.Clear();
            // Thêm từng nhà cung cấp vào DataGridView
            foreach (var ncc in danhSachNCC)
            {
                dataGridViewdsNCC.Rows.Add(false, ncc.MaNhaCungCap, ncc.TenNhaCungCap, ncc.DienThoai, ncc.Email, ncc.NoCanTraHienTai, ncc.TongMua);
            }
        }
        private void FormNhaCungCap_Load(object sender, EventArgs e)
        {
            comboBoxLocTheo_load();
            //load danh sach nha cung cap
            LoadDanhSachNhaCungCap();
            CapNhatSoLuongDaChon();
        }

        private void textBoxTimNCC_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxTimNCC.Text.Trim()))
            {
                // Nếu ô tìm kiếm trống, tải lại danh sách nhà cung cấp
                LoadDanhSachNhaCungCap();
                return;
            }
            string searchText = textBoxTimNCC.Text.Trim().ToLower();
            string locTheo = comboBoxLocTheo.SelectedItem?.ToString() ?? "Mã NCC"; // Lấy giá trị đã chọn trong ComboBox, mặc định là "Mã NCC"
            // Lấy danh sách nhà cung cấp từ cơ sở dữ liệu
            List<ClassNhaCungCap> danhSachNCC = ClassNhaCungCap.LayDanhSachNhaCungCapTheoLoai(locTheo, searchText);
            // Xóa dữ liệu cũ trong DataGridView
            dataGridViewdsNCC.Rows.Clear();
            // Thêm từng nhà cung cấp vào DataGridView
            foreach (var ncc in danhSachNCC)
            {
                dataGridViewdsNCC.Rows.Add(false, ncc.MaNhaCungCap, ncc.TenNhaCungCap, ncc.DienThoai, ncc.Email, ncc.NoCanTraHienTai, ncc.TongMua);
            }
        }

        private void buttonThemNCC_Click(object sender, EventArgs e)
        {
            FormThemNhaCungCap formThemNCC = new FormThemNhaCungCap();

            // Đăng ký sự kiện trước khi hiển thị form
            formThemNCC.FormClosed += (s, args) =>
            {
                LoadDanhSachNhaCungCap(); // Reload danh sách NCC sau khi đóng form
            };

            formThemNCC.ShowDialog();
        }


        private void CapNhatSoLuongDaChon()
        {
            int soLuongChon = 0;

            foreach (DataGridViewRow row in dataGridViewdsNCC.Rows)
            {
                if (Convert.ToBoolean(row.Cells[0].Value))
                {
                    soLuongChon++;
                }
            }

            if (soLuongChon > 0)
            {
                labelSoX.Text = $"Đã chọn {soLuongChon}";
                labelSoX.Visible = true;
                buttonXoa.Visible = true;
                buttonX.Visible = true;
            }
            else
            {
                labelSoX.Text = "";
                labelSoX.Visible = false;
                buttonXoa.Visible = false;
                buttonX.Visible = false;
            }
        }

        private void dataGridViewdsNCC_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewdsNCC.IsCurrentCellDirty)
            {
                dataGridViewdsNCC.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewdsNCC_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Cột checkbox
            {
                bool isChecked = Convert.ToBoolean(dataGridViewdsNCC.Rows[e.RowIndex].Cells[0].Value);
                string maNCC = dataGridViewdsNCC.Rows[e.RowIndex].Cells["ColumnMaNCC"].Value?.ToString();

                CapNhatSoLuongDaChon();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            int soDongCanXoa = 0;

            // Đếm số dòng được chọn để xác nhận trước khi xóa
            for (int i = 0; i < dataGridViewdsNCC.Rows.Count; i++)
            {
                bool isChecked = Convert.ToBoolean(dataGridViewdsNCC.Rows[i].Cells[0].Value);
                if (isChecked)
                {
                    soDongCanXoa++;
                }
            }

            // Xác nhận xóa
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa {soDongCanXoa} nhà cung cấp đã chọn?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                for (int i = dataGridViewdsNCC.Rows.Count - 1; i >= 0; i--)
                {
                    bool isChecked = Convert.ToBoolean(dataGridViewdsNCC.Rows[i].Cells[0].Value);
                    if (isChecked)
                    {
                        string maNCC = dataGridViewdsNCC.Rows[i].Cells["ColumnMaNCC"].Value.ToString();
                        bool xoaThanhCong = ClassNhaCungCap.XoaNhaCungCap(maNCC);

                        if (xoaThanhCong)
                        {
                            dataGridViewdsNCC.Rows.RemoveAt(i);
                            //thong báo xóa thành công
                            MessageBox.Show($"Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Không thể xóa nhà cung cấp có mã {maNCC}.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                // Cập nhật lại UI
                labelSoX.Visible = false;
                buttonXoa.Visible = false;
                buttonX.Visible = false;
            }
        }


        private void buttonX_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewdsNCC.Rows)
            {
                row.Cells[0].Value = false; // Bỏ tích checkbox ở cột đầu tiên
            }

            // Ẩn các thành phần liên quan đến việc chọn
            labelSoX.Text = "";
            labelSoX.Visible = false;
            buttonXoa.Visible = false;
            buttonX.Visible = false;
        }

        private void dataGridViewdsNCC_DoubleClick(object sender, EventArgs e)
        {
            //mo form chi tiết nhà cung cấp
            if (dataGridViewdsNCC.CurrentRow != null && dataGridViewdsNCC.CurrentRow.Index >= 0)
            {
                string maNCC = dataGridViewdsNCC.CurrentRow.Cells["ColumnMaNCC"].Value.ToString();
                FormChiTietNhaCungCap formChiTietNCC = new FormChiTietNhaCungCap(maNCC);
                // Đăng ký sự kiện trước khi hiển thị form
                formChiTietNCC.FormClosed += (s, args) =>
                {
                    LoadDanhSachNhaCungCap(); // Reload danh sách NCC sau khi đóng form
                };
                formChiTietNCC.ShowDialog();
            }

        }


    }
}
