namespace QL_Nha_thuoc.BaoCao.BaoCaoCuoiNgay
{
    partial class FormBCCuoiNgay
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnInBaoCao;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            btnInBaoCao = new Button();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            radioButtonThuChi = new RadioButton();
            radioButtonHangHoa = new RadioButton();
            radioButtonBanHang = new RadioButton();
            label1 = new Label();
            dgvHoaDon = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).BeginInit();
            SuspendLayout();
            // 
            // btnInBaoCao
            // 
            btnInBaoCao.Anchor = AnchorStyles.Bottom;
            btnInBaoCao.Location = new Point(45, 378);
            btnInBaoCao.Name = "btnInBaoCao";
            btnInBaoCao.Size = new Size(100, 30);
            btnInBaoCao.TabIndex = 1;
            btnInBaoCao.Text = "In Báo Cáo";
            btnInBaoCao.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(btnInBaoCao);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dgvHoaDon);
            splitContainer1.Size = new Size(1497, 761);
            splitContainer1.SplitterDistance = 218;
            splitContainer1.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonThuChi);
            groupBox1.Controls.Add(radioButtonHangHoa);
            groupBox1.Controls.Add(radioButtonBanHang);
            groupBox1.Location = new Point(23, 73);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(150, 237);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mối quan tâm";
            // 
            // radioButtonThuChi
            // 
            radioButtonThuChi.AutoSize = true;
            radioButtonThuChi.Location = new Point(22, 106);
            radioButtonThuChi.Name = "radioButtonThuChi";
            radioButtonThuChi.Size = new Size(77, 24);
            radioButtonThuChi.TabIndex = 2;
            radioButtonThuChi.TabStop = true;
            radioButtonThuChi.Text = "Thu chi";
            radioButtonThuChi.UseVisualStyleBackColor = true;
            radioButtonThuChi.CheckedChanged += radioButtonThuChi_CheckedChanged;
            // 
            // radioButtonHangHoa
            // 
            radioButtonHangHoa.AutoSize = true;
            radioButtonHangHoa.Location = new Point(22, 155);
            radioButtonHangHoa.Name = "radioButtonHangHoa";
            radioButtonHangHoa.Size = new Size(95, 24);
            radioButtonHangHoa.TabIndex = 1;
            radioButtonHangHoa.TabStop = true;
            radioButtonHangHoa.Text = "Hàng hóa";
            radioButtonHangHoa.UseVisualStyleBackColor = true;
            radioButtonHangHoa.Visible = false;
            radioButtonHangHoa.CheckedChanged += radioButtonHangHoa_CheckedChanged;
            // 
            // radioButtonBanHang
            // 
            radioButtonBanHang.AutoSize = true;
            radioButtonBanHang.Location = new Point(22, 59);
            radioButtonBanHang.Name = "radioButtonBanHang";
            radioButtonBanHang.Size = new Size(92, 24);
            radioButtonBanHang.TabIndex = 0;
            radioButtonBanHang.TabStop = true;
            radioButtonBanHang.Text = "Bán hàng";
            radioButtonBanHang.UseVisualStyleBackColor = true;
            radioButtonBanHang.CheckedChanged += radioButtonBanHang_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            label1.Location = new Point(9, 9);
            label1.Name = "label1";
            label1.Size = new Size(200, 30);
            label1.TabIndex = 2;
            label1.Text = "Báo cáo cuối ngày";
            // 
            // dgvHoaDon
            // 
            dgvHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHoaDon.Dock = DockStyle.Fill;
            dgvHoaDon.Location = new Point(0, 0);
            dgvHoaDon.Name = "dgvHoaDon";
            dgvHoaDon.RowHeadersWidth = 51;
            dgvHoaDon.Size = new Size(1275, 761);
            dgvHoaDon.TabIndex = 1;
            // 
            // FormBCCuoiNgay
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1497, 761);
            Controls.Add(splitContainer1);
            Name = "FormBCCuoiNgay";
            Text = "Báo Cáo Cuối Ngày";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHoaDon).EndInit();
            ResumeLayout(false);
        }
        private SplitContainer splitContainer1;
        private DataGridView dgvHoaDon;
        private Label label1;
        private GroupBox groupBox1;
        private RadioButton radioButtonThuChi;
        private RadioButton radioButtonHangHoa;
        private RadioButton radioButtonBanHang;
    }
}
