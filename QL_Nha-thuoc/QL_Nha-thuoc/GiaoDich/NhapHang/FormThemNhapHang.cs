using Microsoft.Data.SqlClient;
using QL_Nha_thuoc.DoiTac;
using QL_Nha_thuoc.DoiTac.nhacungcap;
using QL_Nha_thuoc.GiaoDich.NhapHang;
using QL_Nha_thuoc.HangHoa;
using QL_Nha_thuoc.HangHoa.Them;
using QL_Nha_thuoc.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static QL_Nha_thuoc.model.ICoTheReload;
namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    public partial class FormThemNhapHang : Form, ICoTheReload
    {
        public FormThemNhapHang()
        {
            InitializeComponent();
            setData();
        }
        //ham setdata cho form them nhap hang
        public void LoadTaiKhoan()
        {
          
            //chon tai khoan dang dang nhap
            ClassTaiKhoan taiKhoan = Session.TaiKhoanDangNhap;
            var taiKhoanDangNhap = ClassTaiKhoan.LayTaiKhoan(taiKhoan.TenTaiKhoan);
            if (taiKhoanDangNhap != null)
            {
                comboBoxTaiKhoan.SelectedValue = taiKhoanDangNhap.TenTaiKhoan;
            }
            else
            {
                MessageBox.Show("Không tìm thấy tài khoản đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void setData()
        {
            var danhSachTaiKhoan = ClassTaiKhoan.LayDanhSachTaiKhoan();
            comboBoxTaiKhoan.DataSource = danhSachTaiKhoan;
            comboBoxTaiKhoan.DisplayMember = "TenHienThi"; // sử dụng thuộc tính mới
            comboBoxTaiKhoan.ValueMember = "TenTaiKhoan";
            comboBoxTaiKhoan.SelectedIndex = 0; // Đặt không có lựa chọn nào được chọn

            textBoxMaPhieuNhap.Text = PhieuNhapHang.TaoMaPhieuNhapTuDong(); // Tự động sinh mã phiếu nhập
            textBoxTongTien.Text = "0"; // Hiển thị số tiền cần trả ban đầu là 0
            textBoxGiamGia.Text = "0"; // Hiển thị tổng tiền ban đầu là 0
            textBoxCanTra.Text = "0"; // Hiển thị giảm giá ban đầu là 0
            labelTrangThai.Text = "Phiếu tạm"; // Hiển thị trạng thái ban đầu là chưa thanh toán

            labelThoiGian.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            LoadTaiKhoan(); // Gọi hàm để nạp danh sách tài khoản khi khởi tạo form
        }
        public void ReloadSauKhiThayDoi()
        {
            // logic cập nhật lại sau khi thêm thành công
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm hàng hóa
            panelThemHH.Visible = false; // Ẩn panel thêm hàng hóa
        }

        private void buttonThemNCC_Click(object sender, EventArgs e)
        {
            if (buttonThemNCC.Text == "-")
            {
                //nếu đang hiển thị nhà cung cấp thì xóa lựa chọn
                textBoxTimNCC.Text = "";
                flowLayoutPanelDSNCC.Visible = false;
                buttonThemNCC.Text = "+";
                textBoxTimNCC.ReadOnly = false; // Cho phép người dùng nhập lại
                return;
            }
            //mo form them nha cung cap
            FormThemNhaCungCap formThemNhaCungCap = new FormThemNhaCungCap();
            formThemNhaCungCap.ShowDialog();
            //sau khi them nha cung cap, cap nhat lai danh sach nha cung cap
        }


        string maNCCdachon = ""; // Biến để lưu mã nhà cung cấp đã chọn
        private void textBoxTimNCC_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBoxTimNCC.Text.Trim();

            if (!string.IsNullOrEmpty(searchText)) // CHỈ tìm khi có nội dung
            {
                List<ClassNhaCungCap> danhSachNCC = ClassNhaCungCap.LayDanhSachNhaCungCapTheoTen(searchText);

                flowLayoutPanelDSNCC.Controls.Clear();

                foreach (ClassNhaCungCap ncc in danhSachNCC)
                {
                    UserControlNhaCungCap userControlNhaCungCap = new UserControlNhaCungCap();
                    userControlNhaCungCap.setdata(ncc);
                    userControlNhaCungCap.Click += (s, args) =>
                    {
                        // Khi chọn nhà cung cấp
                        textBoxTimNCC.Text = ncc.TenNhaCungCap;
                        flowLayoutPanelDSNCC.Visible = false;
                        //thay doi nut them nha cung cap thanh nut loai bo su lua chon nha cung cap
                        buttonThemNCC.Text = "-";
                        //khong cho sua textboxtimNCC
                        textBoxTimNCC.ReadOnly = true;
                        maNCCdachon = ncc.MaNhaCungCap; // Lưu mã nhà cung cấp đã chọn

                    };
                    flowLayoutPanelDSNCC.Controls.Add(userControlNhaCungCap);
                }

                flowLayoutPanelDSNCC.Visible = danhSachNCC.Count > 0;
            }
            else
            {
                flowLayoutPanelDSNCC.Controls.Clear();
                flowLayoutPanelDSNCC.Visible = false;
            }
        }


        private void buttonThemHangHoa_Click(object sender, EventArgs e)
        {

        }


        //stt
        private  int CapNhatSTT()
        {
            int stt = 1;
            foreach (Control control in flowLayoutPanelNhapHang.Controls)
            {
                if (control is UserControlHangHoaitemNhapHang item)
                {
                    item.SetSTT(stt);
                    stt++;
                }
            }
            return stt -1; // Trả về số lượng hàng hóa đã thêm
        }


        private void textBoxTimHangHoa_TextChanged(object sender, EventArgs e)
        {
            panelKetQuaTimKiem.BringToFront();
            panelKetQuaTimKiem.Visible = true;

            string searchText = textBoxTimHangHoa.Text.Trim();

            // Tìm kiếm khi có ký tự nhập vào
            if (!string.IsNullOrEmpty(searchText) && searchText.Length >= 1)
            {
                // Lấy danh sách hàng hóa phù hợp
                List<ClassHangHoa> danhSachHangHoa = ClassHangHoa.TimKiemHangHoaTheoTuKhoa(searchText);

                // Xóa kết quả cũ
                panelKetQuaTimKiem.Controls.Clear();

                foreach (ClassHangHoa hh in danhSachHangHoa)
                {
                    var userControlHangHoa = new UC_ItemThuoc();
                    userControlHangHoa.SetData(hh);
                    userControlHangHoa.Dock=DockStyle.Top; // Đặt dock để tự động điều chỉnh chiều rộng
                    // Gắn sự kiện Click để thêm vào danh sách nhập hàng
                    userControlHangHoa.Click += (s, args) =>
                    {

                        var itemHangHoaNhapHang = new UserControlHangHoaitemNhapHang();
                        itemHangHoaNhapHang.setData(hh);

                        // Đặt chiều rộng chính xác khi thêm
                        itemHangHoaNhapHang.Width = flowLayoutPanelNhapHang.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
                        itemHangHoaNhapHang.Anchor = AnchorStyles.Left | AnchorStyles.Right;

                        flowLayoutPanelNhapHang.Controls.Add(itemHangHoaNhapHang);

                        labelSoLuongHH.Text= CapNhatSTT().ToString();

                        TinhTongTien();


                        textBoxTimHangHoa.Clear();
                        panelKetQuaTimKiem.Visible = false;

                        //gan su kien click cho buttonX_Click trong itemhangHoaNhapHang
                        itemHangHoaNhapHang.buttonXoa.Click += (s2, args2) =>
                        {
                            flowLayoutPanelNhapHang.Controls.Remove(itemHangHoaNhapHang);

                            labelSoLuongHH.Text = CapNhatSTT().ToString();

                            TinhTongTien();
                        };

                        itemHangHoaNhapHang.ThayDoiSoLuongHoacDonGia += (s3, e3) =>
                        {
                            TinhTongTien();
                        };


                    };
                    //gan su kien khi click vao nut xoa hang hoa tren tung hang hoa

                    panelKetQuaTimKiem.Controls.Add(userControlHangHoa);
                }

                panelKetQuaTimKiem.Visible = danhSachHangHoa.Any();
            }
            else
            {
                panelKetQuaTimKiem.Controls.Clear();
                panelKetQuaTimKiem.Visible = false;
            }
        }


        private void FormThemNhapHang_Load(object sender, EventArgs e)
        {
            //add usecontrolNhapHang vao 
            UserControlNhapHang userControlNhapHang = new UserControlNhapHang();
            userControlNhapHang.Width = flowLayoutPanelNhapHang.Width - 25; // Trừ khoảng cuộn nếu có
            userControlNhapHang.Height = 60; // hoặc theo nhu cầu

            // Nếu muốn auto size chiều cao theo nội dung:
            userControlNhapHang.AutoSize = false;
            userControlNhapHang.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            flowLayoutPanelNhapHang.Controls.Add(userControlNhapHang);


            flowLayoutPanelNhapHang.Resize += flowLayoutPanelNhapHang_Resize;
        }


        public string loaithem = ""; // Biến để lưu loại thêm hàng hóa (nếu cần)
        private void buttonThemHangHoa_Click_1(object sender, EventArgs e)
        {
            panelThemHH.Visible = true;
        }




        private void buttonHangHoa_Click(object sender, EventArgs e)
        {
            loaithem = "hanghoa"; // Đặt loại thêm hàng hóa
            //mo form them hang hoa
            var formThemHangHoa = new FormThemHanghoa(loaithem, this);
            formThemHangHoa.ShowDialog();
            // Sau khi thêm hàng hóa, cập nhật lại danh sách hàng hóa
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm thuốc

        }


        private void buttonThuoc_Click(object sender, EventArgs e)
        {
            loaithem = "T"; // Đặt loại thêm thuốc
            // Mở form thêm thuốc
            FormThemThuoc formThemThuoc = new FormThemThuoc(loaithem,this);
            formThemThuoc.ShowDialog();
            // Sau khi thêm thuốc, cập nhật lại danh sách thuốc
            textBoxTimHangHoa.Text = ""; // Xóa ô tìm kiếm thuốc

        }

        private void flowLayoutPanelNhapHang_Resize(object sender, EventArgs e)
        {
            foreach (Control ctrl in flowLayoutPanelNhapHang.Controls)
            {
                ctrl.Width = flowLayoutPanelNhapHang.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            }
        }

        private void comboBoxTaiKhoan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi người dùng chọn tài khoản, cập nhật thông tin hiển thị
            if (comboBoxTaiKhoan.SelectedItem is ClassTaiKhoan taiKhoan)
            {
                comboBoxTaiKhoan.Text = taiKhoan.TenHienThi; // Hiển thị tên hiển thị của tài khoản
            }
            else
            {
                comboBoxTaiKhoan.Text = "Chưa chọn tài khoản";
            }
        }




        //tinh tien 
        private void TinhTongTien()
        {
            decimal tongTien = 0;
            foreach (Control control in flowLayoutPanelNhapHang.Controls)
            {
                if (control is UserControlHangHoaitemNhapHang item)
                {
                    tongTien += item.ThanhTien;
                }
            }

            textBoxTongTien.Text = tongTien.ToString("N0");

            // Tính tiền cần trả
            decimal giamGia = 0;
            decimal.TryParse(textBoxGiamGia.Text, out giamGia);

            decimal canTra = tongTien - giamGia;
            if (canTra < 0) canTra = 0;

            textBoxCanTra.Text = canTra.ToString("N0");
        }



    }
}
