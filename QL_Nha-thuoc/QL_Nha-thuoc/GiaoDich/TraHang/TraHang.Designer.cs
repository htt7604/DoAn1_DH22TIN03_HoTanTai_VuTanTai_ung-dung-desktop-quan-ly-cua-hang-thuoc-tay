namespace QL_Nha_thuoc
{
    partial class TraHang
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
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            label1 = new Label();
            splitContainer1 = new SplitContainer();
            groupBox1 = new GroupBox();
            radioButtonTatCa = new RadioButton();
            dataGridViewdsPhieuTraHang = new DataGridView();
            panel1 = new Panel();
            buttonTimKiem = new Button();
            buttonChiTietPhieuTra = new Button();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimPhieuTra = new TextBox();
            buttonThemPhieuTra = new Button();
            radioButtonDaHoanThanh = new RadioButton();
            radioButtonDaHuy = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsPhieuTraHang).BeginInit();
            panel1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(142, 25);
            label1.TabIndex = 3;
            label1.Text = "Phiếu trả hàng";
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
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsPhieuTraHang);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1241, 1054);
            splitContainer1.SplitterDistance = 196;
            splitContainer1.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonDaHuy);
            groupBox1.Controls.Add(radioButtonDaHoanThanh);
            groupBox1.Controls.Add(radioButtonTatCa);
            groupBox1.Location = new Point(12, 80);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(167, 198);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trạng thái ";
            // 
            // radioButtonTatCa
            // 
            radioButtonTatCa.AutoSize = true;
            radioButtonTatCa.Location = new Point(25, 56);
            radioButtonTatCa.Name = "radioButtonTatCa";
            radioButtonTatCa.Size = new Size(70, 24);
            radioButtonTatCa.TabIndex = 0;
            radioButtonTatCa.TabStop = true;
            radioButtonTatCa.Text = "Tất cả";
            radioButtonTatCa.UseVisualStyleBackColor = true;
            radioButtonTatCa.CheckedChanged += radioButtonTatCa_CheckedChanged;
            // 
            // dataGridViewdsPhieuTraHang
            // 
            dataGridViewdsPhieuTraHang.AllowUserToAddRows = false;
            dataGridViewdsPhieuTraHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsPhieuTraHang.BackgroundColor = SystemColors.Window;
            dataGridViewdsPhieuTraHang.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Control;
            dataGridViewCellStyle7.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle7.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridViewdsPhieuTraHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewdsPhieuTraHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle8.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dataGridViewdsPhieuTraHang.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewdsPhieuTraHang.Dock = DockStyle.Fill;
            dataGridViewdsPhieuTraHang.Location = new Point(0, 60);
            dataGridViewdsPhieuTraHang.MultiSelect = false;
            dataGridViewdsPhieuTraHang.Name = "dataGridViewdsPhieuTraHang";
            dataGridViewdsPhieuTraHang.RowHeadersWidth = 51;
            dataGridViewdsPhieuTraHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsPhieuTraHang.Size = new Size(1041, 994);
            dataGridViewdsPhieuTraHang.TabIndex = 48;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonTimKiem);
            panel1.Controls.Add(buttonChiTietPhieuTra);
            panel1.Controls.Add(panel);
            panel1.Controls.Add(buttonThemPhieuTra);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1041, 60);
            panel1.TabIndex = 45;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(530, 14);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(85, 34);
            buttonTimKiem.TabIndex = 41;
            buttonTimKiem.Text = "Tìm kiếm";
            buttonTimKiem.UseVisualStyleBackColor = true;
            buttonTimKiem.Click += buttonTimKiem_Click;
            // 
            // buttonChiTietPhieuTra
            // 
            buttonChiTietPhieuTra.Location = new Point(752, 9);
            buttonChiTietPhieuTra.Name = "buttonChiTietPhieuTra";
            buttonChiTietPhieuTra.Size = new Size(94, 44);
            buttonChiTietPhieuTra.TabIndex = 40;
            buttonChiTietPhieuTra.Text = "Chi Tiết";
            buttonChiTietPhieuTra.UseVisualStyleBackColor = true;
            buttonChiTietPhieuTra.Click += buttonChiTietPhieuTra_Click;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(9, 7);
            panel.Name = "panel";
            panel.Size = new Size(491, 46);
            panel.TabIndex = 38;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Window;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimPhieuTra, 1, 0);
            tableLayoutPanel5.Location = new Point(28, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(383, 40);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimPhieuTra
            // 
            textBoxTimPhieuTra.BorderStyle = BorderStyle.None;
            textBoxTimPhieuTra.Font = new Font("Segoe UI", 11F);
            textBoxTimPhieuTra.Location = new Point(55, 3);
            textBoxTimPhieuTra.Multiline = true;
            textBoxTimPhieuTra.Name = "textBoxTimPhieuTra";
            textBoxTimPhieuTra.PlaceholderText = "Tìm theo mã phiếu trả";
            textBoxTimPhieuTra.Size = new Size(325, 31);
            textBoxTimPhieuTra.TabIndex = 5;
            textBoxTimPhieuTra.Tag = "";
            // 
            // buttonThemPhieuTra
            // 
            buttonThemPhieuTra.BackColor = Color.LimeGreen;
            buttonThemPhieuTra.Location = new Point(957, 10);
            buttonThemPhieuTra.Name = "buttonThemPhieuTra";
            buttonThemPhieuTra.Size = new Size(108, 40);
            buttonThemPhieuTra.TabIndex = 39;
            buttonThemPhieuTra.Text = "+ Thêm mới";
            buttonThemPhieuTra.UseVisualStyleBackColor = false;
            buttonThemPhieuTra.Click += buttonThemPhieuTra_Click;
            // 
            // radioButtonDaHoanThanh
            // 
            radioButtonDaHoanThanh.AutoSize = true;
            radioButtonDaHoanThanh.Location = new Point(25, 101);
            radioButtonDaHoanThanh.Name = "radioButtonDaHoanThanh";
            radioButtonDaHoanThanh.Size = new Size(127, 24);
            radioButtonDaHoanThanh.TabIndex = 1;
            radioButtonDaHoanThanh.TabStop = true;
            radioButtonDaHoanThanh.Text = "Đã hoàn thành";
            radioButtonDaHoanThanh.UseVisualStyleBackColor = true;
            radioButtonDaHoanThanh.CheckedChanged += radioButtonDaHoanThanh_CheckedChanged;
            // 
            // radioButtonDaHuy
            // 
            radioButtonDaHuy.AutoSize = true;
            radioButtonDaHuy.Location = new Point(25, 151);
            radioButtonDaHuy.Name = "radioButtonDaHuy";
            radioButtonDaHuy.Size = new Size(76, 24);
            radioButtonDaHuy.TabIndex = 2;
            radioButtonDaHuy.TabStop = true;
            radioButtonDaHuy.Text = "Đã hủy";
            radioButtonDaHuy.UseVisualStyleBackColor = true;
            radioButtonDaHuy.CheckedChanged += radioButtonDaHuy_CheckedChanged;
            // 
            // TraHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1241, 1054);
            Controls.Add(splitContainer1);
            Name = "TraHang";
            Text = "TraHang";
            Load += TraHang_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsPhieuTraHang).EndInit();
            panel1.ResumeLayout(false);
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private SplitContainer splitContainer1;
        private Panel panel1;
        private DataGridView dataGridViewdsPhieuTraHang;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimPhieuTra;
        private Button buttonThemPhieuTra;
        private Button buttonChiTietPhieuTra;
        private Button buttonTimKiem;
        private GroupBox groupBox1;
        private RadioButton radioButtonTatCa;
        private RadioButton radioButtonDaHuy;
        private RadioButton radioButtonDaHoanThanh;
    }
}