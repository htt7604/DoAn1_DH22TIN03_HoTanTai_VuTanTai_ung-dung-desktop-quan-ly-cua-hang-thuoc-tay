namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    partial class FormThemNhapHang
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
            splitContainer1 = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel = new Panel();
            flowLayoutPanelDanhSachKhachHang = new FlowLayoutPanel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimKH = new TextBox();
            buttonThemKhachHang = new Button();
            labelThoiGian = new Label();
            comboBoxTaiKhoan = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBox1);
            splitContainer1.Panel2.Controls.Add(label6);
            splitContainer1.Panel2.Controls.Add(label5);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(panel);
            splitContainer1.Panel2.Controls.Add(labelThoiGian);
            splitContainer1.Panel2.Controls.Add(comboBoxTaiKhoan);
            splitContainer1.Size = new Size(1271, 658);
            splitContainer1.SplitterDistance = 786;
            splitContainer1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(105, 27);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(436, 158);
            flowLayoutPanel1.TabIndex = 61;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel1.WrapContents = false;
            // 
            // panel
            // 
            panel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel.BackColor = SystemColors.Control;
            panel.Controls.Add(flowLayoutPanelDanhSachKhachHang);
            panel.Controls.Add(tableLayoutPanel5);
            panel.Controls.Add(buttonThemKhachHang);
            panel.Location = new Point(16, 70);
            panel.Name = "panel";
            panel.Size = new Size(436, 42);
            panel.TabIndex = 64;
            // 
            // flowLayoutPanelDanhSachKhachHang
            // 
            flowLayoutPanelDanhSachKhachHang.AutoScroll = true;
            flowLayoutPanelDanhSachKhachHang.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelDanhSachKhachHang.Location = new Point(3, 42);
            flowLayoutPanelDanhSachKhachHang.Name = "flowLayoutPanelDanhSachKhachHang";
            flowLayoutPanelDanhSachKhachHang.Size = new Size(436, 287);
            flowLayoutPanelDanhSachKhachHang.TabIndex = 60;
            flowLayoutPanelDanhSachKhachHang.Visible = false;
            flowLayoutPanelDanhSachKhachHang.WrapContents = false;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Control;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimKH, 1, 0);
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(370, 36);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Control;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(44, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimKH
            // 
            textBoxTimKH.BackColor = SystemColors.Control;
            textBoxTimKH.BorderStyle = BorderStyle.None;
            textBoxTimKH.Dock = DockStyle.Fill;
            textBoxTimKH.Font = new Font("Segoe UI", 11F);
            textBoxTimKH.Location = new Point(53, 3);
            textBoxTimKH.Multiline = true;
            textBoxTimKH.Name = "textBoxTimKH";
            textBoxTimKH.PlaceholderText = "Tìm theo mã, tên nha cung cap";
            textBoxTimKH.Size = new Size(314, 30);
            textBoxTimKH.TabIndex = 5;
            textBoxTimKH.Tag = "";
            // 
            // buttonThemKhachHang
            // 
            buttonThemKhachHang.Dock = DockStyle.Right;
            buttonThemKhachHang.Location = new Point(395, 0);
            buttonThemKhachHang.Name = "buttonThemKhachHang";
            buttonThemKhachHang.Size = new Size(41, 42);
            buttonThemKhachHang.TabIndex = 39;
            buttonThemKhachHang.Text = "+";
            buttonThemKhachHang.UseVisualStyleBackColor = true;
            // 
            // labelThoiGian
            // 
            labelThoiGian.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelThoiGian.AutoSize = true;
            labelThoiGian.Location = new Point(320, 15);
            labelThoiGian.Name = "labelThoiGian";
            labelThoiGian.Size = new Size(39, 20);
            labelThoiGian.TabIndex = 63;
            labelThoiGian.Text = "time";
            // 
            // comboBoxTaiKhoan
            // 
            comboBoxTaiKhoan.FormattingEnabled = true;
            comboBoxTaiKhoan.Location = new Point(3, 12);
            comboBoxTaiKhoan.Name = "comboBoxTaiKhoan";
            comboBoxTaiKhoan.Size = new Size(243, 28);
            comboBoxTaiKhoan.TabIndex = 62;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 142);
            label1.Name = "label1";
            label1.Size = new Size(108, 20);
            label1.TabIndex = 65;
            label1.Text = "Ma phieu nhap";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 188);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 66;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 240);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 67;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(33, 292);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 68;
            label4.Text = "label4";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 345);
            label5.Name = "label5";
            label5.Size = new Size(50, 20);
            label5.TabIndex = 69;
            label5.Text = "label5";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(33, 392);
            label6.Name = "label6";
            label6.Size = new Size(50, 20);
            label6.TabIndex = 70;
            label6.Text = "label6";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(63, 445);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(389, 137);
            textBox1.TabIndex = 71;
            // 
            // FormThemNhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 658);
            Controls.Add(splitContainer1);
            Name = "FormThemNhapHang";
            Text = "FormThemNhapHang";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private ComboBox comboBoxTaiKhoan;
        private Label labelThoiGian;
        private Panel panel;
        private FlowLayoutPanel flowLayoutPanelDanhSachKhachHang;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimKH;
        private Button buttonThemKhachHang;
        private FlowLayoutPanel flowLayoutPanel1;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}