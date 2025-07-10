using System;
using System.Windows.Forms;
using QL_Nha_thuoc.model;

namespace QL_Nha_thuoc.DoiTac.nhacungcap
{
    public partial class FormSuaNhaCungCap : Form
    {
        private string _maNCC;

        public FormSuaNhaCungCap(string maNCC)
        {
            InitializeComponent();
            _maNCC = maNCC;
            this.Load += FormSuaNhaCungCap_Load;
        }

        private void FormSuaNhaCungCap_Load(object sender, EventArgs e)
        {
            ClassNhaCungCap ncc = ClassNhaCungCap.LayDanhSachNhaCungCap()
                .Find(x => x.MaNhaCungCap == _maNCC);

            if (ncc != null)
            {
                setdata(ncc);
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhà cung cấp có mã: " + _maNCC,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public void setdata(ClassNhaCungCap ncc)
        {
            label8.Text = "NHÀ CUNG CẤP " + ncc.MaNhaCungCap;
            textBoxMaNCC.Text = ncc.MaNhaCungCap;
            textBoxTenNCC.Text = ncc.TenNhaCungCap;
            textBoxDiaChi.Text = ncc.DiaChiNCC;
            textBoxSDT.Text = ncc.DienThoai;
            textBoxEmail.Text = ncc.Email;
            textBoxGhiChu.Text = ncc.GhiChu;
            textBoxTenCongTy.Text = ncc.TenCongTy;
            textBoxMaSoThue.Text = ncc.MaSoThue;
        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {
            try
            {
                ClassNhaCungCap ncc = new ClassNhaCungCap()
                {
                    MaNhaCungCap = textBoxMaNCC.Text,
                    TenNhaCungCap = textBoxTenNCC.Text,
                    DiaChiNCC = textBoxDiaChi.Text,
                    DienThoai = textBoxSDT.Text,
                    Email = textBoxEmail.Text,
                    GhiChu = textBoxGhiChu.Text,
                    TenCongTy = textBoxTenCongTy.Text,
                    MaSoThue = textBoxMaSoThue.Text
                };

                ClassNhaCungCap.SuaNhaCungCap(ncc);

                MessageBox.Show("Cập nhật thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonBoQua_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
