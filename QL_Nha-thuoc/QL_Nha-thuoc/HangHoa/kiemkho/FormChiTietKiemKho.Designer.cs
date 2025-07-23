namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    partial class FormChiTietKiemKho
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelTongChenhLech = new Label();
            labelTongLechTang = new Label();
            labelTongLechGiam = new Label();
            labelTongThucTe = new Label();
            buttonHuyBo = new Button();
            buttonLuu = new Button();
            panel1 = new Panel();
            textBoxTrangThai = new TextBox();
            textBoxThoiGianKiemKho = new TextBox();
            textBoxThoiGianCanBang = new TextBox();
            textBoxNguoiTao = new TextBox();
            textBoxGhiChu = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxMaKiemKho = new TextBox();
            label1 = new Label();
            dataGridViewdsTTPhieuKiemKho = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsTTPhieuKiemKho).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridViewdsTTPhieuKiemKho, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.1024265F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.0566025F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.840971F));
            tableLayoutPanel1.Size = new Size(1114, 796);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Controls.Add(buttonHuyBo);
            panel3.Controls.Add(buttonLuu);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 568);
            panel3.Name = "panel3";
            panel3.Size = new Size(1108, 225);
            panel3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(labelTongChenhLech, 0, 3);
            tableLayoutPanel2.Controls.Add(labelTongLechTang, 0, 1);
            tableLayoutPanel2.Controls.Add(labelTongLechGiam, 0, 2);
            tableLayoutPanel2.Controls.Add(labelTongThucTe, 0, 0);
            tableLayoutPanel2.Location = new Point(862, 16);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(237, 165);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // labelTongChenhLech
            // 
            labelTongChenhLech.AutoSize = true;
            labelTongChenhLech.Location = new Point(118, 123);
            labelTongChenhLech.Name = "labelTongChenhLech";
            labelTongChenhLech.Size = new Size(116, 20);
            labelTongChenhLech.TabIndex = 6;
            labelTongChenhLech.Text = "Tổng chêch lệch";
            // 
            // labelTongLechTang
            // 
            labelTongLechTang.AutoSize = true;
            labelTongLechTang.Location = new Point(126, 41);
            labelTongLechTang.Name = "labelTongLechTang";
            labelTongLechTang.Size = new Size(108, 20);
            labelTongLechTang.TabIndex = 4;
            labelTongLechTang.Text = "Tổng lệch tăng";
            // 
            // labelTongLechGiam
            // 
            labelTongLechGiam.AutoSize = true;
            labelTongLechGiam.Location = new Point(122, 82);
            labelTongLechGiam.Name = "labelTongLechGiam";
            labelTongLechGiam.Size = new Size(112, 20);
            labelTongLechGiam.TabIndex = 5;
            labelTongLechGiam.Text = "Tổng lệch giảm";
            // 
            // labelTongThucTe
            // 
            labelTongThucTe.AutoSize = true;
            labelTongThucTe.Location = new Point(141, 0);
            labelTongThucTe.Name = "labelTongThucTe";
            labelTongThucTe.Size = new Size(93, 20);
            labelTongThucTe.TabIndex = 3;
            labelTongThucTe.Text = "Tổng thực tế";
            // 
            // buttonHuyBo
            // 
            buttonHuyBo.Location = new Point(986, 187);
            buttonHuyBo.Name = "buttonHuyBo";
            buttonHuyBo.Size = new Size(94, 29);
            buttonHuyBo.TabIndex = 1;
            buttonHuyBo.Text = "Hủy bỏ";
            buttonHuyBo.UseVisualStyleBackColor = true;
            buttonHuyBo.Click += buttonHuyBo_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(834, 187);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 29);
            buttonLuu.TabIndex = 0;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(textBoxTrangThai);
            panel1.Controls.Add(textBoxThoiGianKiemKho);
            panel1.Controls.Add(textBoxThoiGianCanBang);
            panel1.Controls.Add(textBoxNguoiTao);
            panel1.Controls.Add(textBoxGhiChu);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBoxMaKiemKho);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1108, 169);
            panel1.TabIndex = 0;
            // 
            // textBoxTrangThai
            // 
            textBoxTrangThai.Enabled = false;
            textBoxTrangThai.Location = new Point(461, 9);
            textBoxTrangThai.Name = "textBoxTrangThai";
            textBoxTrangThai.ReadOnly = true;
            textBoxTrangThai.Size = new Size(163, 27);
            textBoxTrangThai.TabIndex = 10;
            // 
            // textBoxThoiGianKiemKho
            // 
            textBoxThoiGianKiemKho.Enabled = false;
            textBoxThoiGianKiemKho.Location = new Point(121, 66);
            textBoxThoiGianKiemKho.Name = "textBoxThoiGianKiemKho";
            textBoxThoiGianKiemKho.ReadOnly = true;
            textBoxThoiGianKiemKho.Size = new Size(174, 27);
            textBoxThoiGianKiemKho.TabIndex = 9;
            // 
            // textBoxThoiGianCanBang
            // 
            textBoxThoiGianCanBang.Enabled = false;
            textBoxThoiGianCanBang.Location = new Point(121, 116);
            textBoxThoiGianCanBang.Name = "textBoxThoiGianCanBang";
            textBoxThoiGianCanBang.ReadOnly = true;
            textBoxThoiGianCanBang.Size = new Size(174, 27);
            textBoxThoiGianCanBang.TabIndex = 8;
            // 
            // textBoxNguoiTao
            // 
            textBoxNguoiTao.Enabled = false;
            textBoxNguoiTao.Location = new Point(461, 70);
            textBoxNguoiTao.Name = "textBoxNguoiTao";
            textBoxNguoiTao.ReadOnly = true;
            textBoxNguoiTao.Size = new Size(163, 27);
            textBoxNguoiTao.TabIndex = 7;
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Location = new Point(710, 9);
            textBoxGhiChu.Multiline = true;
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.Size = new Size(284, 134);
            textBoxGhiChu.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 73);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 5;
            label5.Text = "Thời gian:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 123);
            label4.Name = "label4";
            label4.Size = new Size(112, 20);
            label4.TabIndex = 4;
            label4.Text = "Ngày cân bằng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(352, 16);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 3;
            label3.Text = "Trạng thái:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(351, 73);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 2;
            label2.Text = "Người tạo:";
            // 
            // textBoxMaKiemKho
            // 
            textBoxMaKiemKho.Enabled = false;
            textBoxMaKiemKho.Location = new Point(121, 9);
            textBoxMaKiemKho.Name = "textBoxMaKiemKho";
            textBoxMaKiemKho.ReadOnly = true;
            textBoxMaKiemKho.Size = new Size(174, 27);
            textBoxMaKiemKho.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 16);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã kiểm kho:";
            // 
            // dataGridViewdsTTPhieuKiemKho
            // 
            dataGridViewdsTTPhieuKiemKho.BackgroundColor = SystemColors.Window;
            dataGridViewdsTTPhieuKiemKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsTTPhieuKiemKho.Dock = DockStyle.Fill;
            dataGridViewdsTTPhieuKiemKho.Location = new Point(3, 178);
            dataGridViewdsTTPhieuKiemKho.Name = "dataGridViewdsTTPhieuKiemKho";
            dataGridViewdsTTPhieuKiemKho.RowHeadersWidth = 51;
            dataGridViewdsTTPhieuKiemKho.Size = new Size(1108, 384);
            dataGridViewdsTTPhieuKiemKho.TabIndex = 3;
            // 
            // FormChiTietKiemKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 796);
            Controls.Add(tableLayoutPanel1);
            Name = "FormChiTietKiemKho";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chi tiết phiếu kiểm";
            Load += FormChiTietKiemKho_Load_1;
            tableLayoutPanel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsTTPhieuKiemKho).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel3;
        private Panel panel1;
        private TextBox textBoxTrangThai;
        private TextBox textBoxThoiGianKiemKho;
        private TextBox textBoxThoiGianCanBang;
        private TextBox textBoxNguoiTao;
        private TextBox textBoxGhiChu;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxMaKiemKho;
        private Label label1;
        private Button buttonHuyBo;
        private Button buttonLuu;
        private Label labelTongChenhLech;
        private Label labelTongLechGiam;
        private Label labelTongLechTang;
        private Label labelTongThucTe;
        private DataGridView dataGridViewdsTTPhieuKiemKho;
        private TableLayoutPanel tableLayoutPanel2;
    }
}