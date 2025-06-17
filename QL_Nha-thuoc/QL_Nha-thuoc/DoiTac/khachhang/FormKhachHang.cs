using QL_Nha_thuoc.BanHang;
using QL_Nha_thuoc.DoiTac.khachhang;
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

namespace QL_Nha_thuoc.DoiTac
{
    public partial class FormKhachHang : Form
    {
        public FormKhachHang()
        {
            InitializeComponent();
            comboBoxLocTheo_load();
        }

        private void textBoxTimKH_TextChanged(object sender, EventArgs e)
        {

            // Đảm bảo DataGridView có cột
            if (dataGridViewdsDMKH.Columns.Count == 0)
            {
                dataGridViewdsDMKH.Columns.Add("MaKH", "Mã KH");
                dataGridViewdsDMKH.Columns.Add("TenKH", "Tên KH");
                dataGridViewdsDMKH.Columns.Add("DiaChiKH", "Địa chỉ");
                dataGridViewdsDMKH.Columns.Add("SDT", "SĐT");
                dataGridViewdsDMKH.Columns.Add("GioiTinh", "Giới tính");
                dataGridViewdsDMKH.Columns.Add("NgaySinh", "Ngày sinh");
                dataGridViewdsDMKH.Columns.Add("NgayTaoKH", "Ngày tạo");
                dataGridViewdsDMKH.Columns.Add("TrangThaiKH", "Trạng thái");
                dataGridViewdsDMKH.Columns.Add("SoCCCD_CMND", "CMND/CCCD");
            }

            // Xóa dòng cũ và thêm mới
            dataGridViewdsDMKH.Rows.Clear();
            string loaiTim = comboBoxLocTheo.SelectedItem?.ToString();
            string tuKhoa = textBoxTimKH.Text.Trim();

            if (string.IsNullOrWhiteSpace(loaiTim)) return;

            var danhSach = ClassKhachHang.TimKhachHang(loaiTim, tuKhoa);

            dataGridViewdsDMKH.Rows.Clear();

            foreach (var kh in danhSach)
            {
                dataGridViewdsDMKH.Rows.Add(
                    kh.MaKH,
                    kh.TenKH,
                    kh.DiaChiKH,
                    kh.SDT,
                    kh.GioiTinh,
                    kh.NgaySinh?.ToString("dd/MM/yyyy"),
                    kh.NgayTaoKH?.ToString("dd/MM/yyyy"),
                    kh.TrangThaiKH,
                    kh.SoCCCD_CMND
                );
            }
        }

        //load comboboxLoctheo
        private void comboBoxLocTheo_load()
        {
            comboBoxLocTheo.Items.Add("Mã KH");
            comboBoxLocTheo.Items.Add("Tên KH");
            comboBoxLocTheo.SelectedIndex = 0; // mặc định là "Mã KH"

        }

        private void comboBoxLocTheo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //moi lan chon se load lai du lieu
            textBoxTimKH_TextChanged(sender, e);
        }


        private void dataGridViewdsDMKH_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy mã khách hàng từ dòng được click
                string maKH = dataGridViewdsDMKH.Rows[e.RowIndex].Cells["MaKH"].Value.ToString();

                // Lấy thông tin khách hàng từ database
                ClassKhachHang khachHang = ClassKhachHang.LayThongTinKhachHangTheoMa(maKH);

                if (khachHang != null)
                {
                    // Mở form chi tiết khách hàng
                    FormChiTietKhachHang formChiTiet = new FormChiTietKhachHang();
                    formChiTiet.SetData(khachHang); // Truyền dữ liệu vào form

                    // Hiển thị form và chờ kết quả
                    DialogResult result = formChiTiet.ShowDialog();

                    // Nếu người dùng nhấn Cập nhật thành công
                    if (result == DialogResult.OK)
                    {
                        // Gọi lại tìm kiếm theo nội dung hiện tại để làm mới danh sách
                        textBoxTimKH_TextChanged(null, null);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin khách hàng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void buttonThemKH_Click(object sender, EventArgs e)
        {
            //mo h form thêm/sửa khách hàng
            FormThem_Suakhachhang formThemSua = new FormThem_Suakhachhang();
            formThemSua.ShowDialog(); // Hiển thị form thêm/sửa khách hàng
            formThemSua.FormClosed += (s, args) =>
            {
                // Khi form thêm/sửa đóng lại, làm mới danh sách khách hàng
                textBoxTimKH_TextChanged(null, null);
            };
        }


    }
}
