using Microsoft.Data.SqlClient;
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

namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    public partial class FormChiTietKiemKho : Form
    {
        private string maPhieuKiem;

        public FormChiTietKiemKho(string maPhieuKiem)
        {
            InitializeComponent();
            this.maPhieuKiem = maPhieuKiem;
        }
        //ham load du lieu
        private void LoadChiTietPhieuKiemKho()
        {
            // Load dữ liệu phiếu kiểm
            var thongTinPhieu = PhieuKiemKho.LayPhieuKiemKho(maPhieuKiem);

            if (thongTinPhieu != null)
            {
                // Gán dữ liệu vào TextBox
                textBoxMaKiemKho.Text = thongTinPhieu.MaPhieuKiemKho;
                textBoxNguoiTao.Text = thongTinPhieu.TenNhanVien;
                textBoxTrangThai.Text = thongTinPhieu.TrangThaiPhieuKiem;
                textBoxGhiChu.Text = thongTinPhieu.GhiChu;
                if (thongTinPhieu.NgayKiemKho.HasValue)
                {
                    textBoxThoiGianKiemKho.Text = thongTinPhieu.NgayKiemKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    textBoxThoiGianKiemKho.Text = "";
                }
                //thoi gian can bang kho 
                if (thongTinPhieu.ThoiGianCanBangKho.HasValue)
                {
                    textBoxThoiGianCanBang.Text = thongTinPhieu.ThoiGianCanBangKho.Value.ToString("dd/MM/yyyy HH:mm:ss");
                }
                else
                {
                    textBoxThoiGianCanBang.Text = "";
                }
            }

            // Load chi tiết phiếu vào DataGridView
            List<ChiTietPhieuKiemKho> chiTietList = ChiTietPhieuKiemKho.LayChiTietPhieuKiemKho(maPhieuKiem);

            var table = new DataTable();
            table.Columns.Add("Mã hàng hóa");
            table.Columns.Add("Số lượng hệ thống", typeof(int));
            table.Columns.Add("Tên hàng hóa", typeof(string));
            table.Columns.Add("Số lượng thực tế", typeof(int));
            table.Columns.Add("Chênh lệch", typeof(int));

            foreach (var ct in chiTietList)
            {
                int chenhLech = ct.SoLuongThucTe - ct.SoLuongHeThong;
                table.Rows.Add(ct.MaHangHoa, ct.SoLuongHeThong, ct.TenHangHoa, ct.SoLuongThucTe, chenhLech);
            }

            dataGridViewdsTTPhieuKiemKho.DataSource = table;
            dataGridViewdsTTPhieuKiemKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            //hien thi tong so luong thuc te, tong lech tang, tong lech giam, tong chenh lech
            int tongThucTe = 0;
            int tongLechTang = 0;
            int tongLechGiam = 0;
            int tongChenhLech = 0;

            foreach (var ct in chiTietList)
            {
                int chenhLech = ct.SoLuongThucTe - ct.SoLuongHeThong;
                tongThucTe += ct.SoLuongThucTe;
                tongChenhLech += Math.Abs(chenhLech);

                if (chenhLech > 0)
                    tongLechTang += chenhLech;
                else if (chenhLech < 0)
                    tongLechGiam += -chenhLech;
            }

            // Gán vào các TextBox (bạn cần tạo trước các TextBox này trong Designer)
            labelTongThucTe.Text = "Tong thuc te: " + tongThucTe.ToString();
            labelTongLechTang.Text = "Tong lech tang: " + tongLechTang.ToString();
            labelTongLechGiam.Text = "Tong lech giam: " + tongLechGiam.ToString();
            labelTongChenhLech.Text = "Tong chenh lech: " + tongChenhLech.ToString();

        }



        private void FormChiTietKiemKho_Load_1(object sender, EventArgs e)
        {
            LoadChiTietPhieuKiemKho();
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            //luu ghi chu  kiem kho
            string ghiChuMoi = textBoxGhiChu.Text.Trim();

            if (string.IsNullOrEmpty(maPhieuKiem))
            {
                MessageBox.Show("Không xác định được mã phiếu kiểm.");
                return;
            }

            using (SqlConnection conn = DBHelperPK.GetConnection())
            {
                try
                {
                    conn.Open();

                    string query = @"UPDATE PHIEU_KIEM_KHO 
                             SET GHI_CHU_KIEM_KHO = @GhiChu 
                             WHERE MA_KIEM_KHO = @MaPhieuKiem";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@GhiChu", ghiChuMoi);
                    cmd.Parameters.AddWithValue("@MaPhieuKiem", maPhieuKiem);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật ghi chú thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //cap nhat lai du lieu tren form
                        LoadChiTietPhieuKiemKho();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy phiếu kiểm để cập nhật.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật ghi chú: " + ex.Message);
                }
            }
        }

        public void buttonHuyBo_Click(object sender, EventArgs e)
        {
            //thong bao nguoi dung co muon huy bo khong
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ phiếu kiểm không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool xoachitiet = ClassChiTietPhieuKiemKho.XoaChiTietPhieuKiemKho(maPhieuKiem);
                //thong bao xoa thanh cong
                if (xoachitiet)
                {
                    MessageBox.Show("Đã hủy bỏ phiếu kiểm kho thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //load lai du lieu tren form
                    //LoadChiTietPhieuKiemKho();
                    //this.Close(); // Đóng form
                }
                else
                {
                    MessageBox.Show("Không thể hủy bỏ phiếu kiểm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //xoa phieu kiem kho
                bool xoaPhieuKiemKho = PhieuKiemKho.XoaPhieuKiemKho(maPhieuKiem);
                if (xoaPhieuKiemKho)
                {
                    MessageBox.Show("Phiếu kiểm kho đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadChiTietPhieuKiemKho();
                    this.Close(); // Đóng form
                }
                else
                {
                    MessageBox.Show("Không thể xóa phiếu kiểm kho.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                
            }
            else
            {
                //khong lam gi ca
            }
        }




    }
}
