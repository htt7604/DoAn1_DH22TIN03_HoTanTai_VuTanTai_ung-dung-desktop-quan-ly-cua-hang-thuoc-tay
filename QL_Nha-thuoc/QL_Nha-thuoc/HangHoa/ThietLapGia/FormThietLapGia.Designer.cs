namespace QL_Nha_thuoc.HangHoa
{
    partial class FormThietLapGia
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
            groupBox3 = new GroupBox();
            buttonThemBangGia = new Button();
            comboBoxBangGia = new ComboBox();
            groupBox2 = new GroupBox();
            comboBoxNhomHang = new ComboBox();
            groupBox1 = new GroupBox();
            comboBoxLoc = new ComboBox();
            comboBoxLoaiGia = new ComboBox();
            label1 = new Label();
            panelKetQuaTimKiem = new Panel();
            flowLayoutPanelThietLapGia = new FlowLayoutPanel();
            panel = new Panel();
            labelDVT = new Label();
            comboBoxDonViTinh = new ComboBox();
            tableLayoutPanelTimKiem = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanelTimKiem.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(panelKetQuaTimKiem);
            splitContainer1.Panel2.Controls.Add(flowLayoutPanelThietLapGia);
            splitContainer1.Panel2.Controls.Add(panel);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 234;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(buttonThemBangGia);
            groupBox3.Controls.Add(comboBoxBangGia);
            groupBox3.Location = new Point(12, 91);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(204, 125);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Bảng giá";
            // 
            // buttonThemBangGia
            // 
            buttonThemBangGia.Location = new Point(158, 16);
            buttonThemBangGia.Name = "buttonThemBangGia";
            buttonThemBangGia.Size = new Size(40, 29);
            buttonThemBangGia.TabIndex = 3;
            buttonThemBangGia.Text = "+";
            buttonThemBangGia.UseVisualStyleBackColor = true;
            buttonThemBangGia.Click += buttonThemBangGia_Click;
            // 
            // comboBoxBangGia
            // 
            comboBoxBangGia.BackColor = SystemColors.Menu;
            comboBoxBangGia.FormattingEnabled = true;
            comboBoxBangGia.Location = new Point(6, 64);
            comboBoxBangGia.Name = "comboBoxBangGia";
            comboBoxBangGia.Size = new Size(151, 28);
            comboBoxBangGia.TabIndex = 2;
            comboBoxBangGia.SelectedIndexChanged += comboBoxBangGia_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Window;
            groupBox2.Controls.Add(comboBoxNhomHang);
            groupBox2.Location = new Point(17, 316);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(199, 125);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nhóm hàng ";
            // 
            // comboBoxNhomHang
            // 
            comboBoxNhomHang.BackColor = SystemColors.Menu;
            comboBoxNhomHang.FormattingEnabled = true;
            comboBoxNhomHang.Location = new Point(22, 53);
            comboBoxNhomHang.Name = "comboBoxNhomHang";
            comboBoxNhomHang.Size = new Size(151, 28);
            comboBoxNhomHang.TabIndex = 1;
            comboBoxNhomHang.SelectedIndexChanged += comboBoxNhomHang_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Window;
            groupBox1.Controls.Add(comboBoxLoc);
            groupBox1.Controls.Add(comboBoxLoaiGia);
            groupBox1.Location = new Point(12, 475);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 86);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá Bán";
            // 
            // comboBoxLoc
            // 
            comboBoxLoc.BackColor = SystemColors.Menu;
            comboBoxLoc.FormattingEnabled = true;
            comboBoxLoc.Location = new Point(5, 41);
            comboBoxLoc.Name = "comboBoxLoc";
            comboBoxLoc.Size = new Size(41, 28);
            comboBoxLoc.TabIndex = 2;
            comboBoxLoc.SelectedIndexChanged += comboBoxLoc_SelectedIndexChanged;
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.BackColor = SystemColors.Menu;
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(62, 41);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(136, 28);
            comboBoxLoaiGia.TabIndex = 3;
            comboBoxLoaiGia.SelectedIndexChanged += comboBoxLoaiGia_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(47, 32);
            label1.Name = "label1";
            label1.Size = new Size(131, 28);
            label1.TabIndex = 0;
            label1.Text = "Thiết lập giá";
            // 
            // panelKetQuaTimKiem
            // 
            panelKetQuaTimKiem.AutoScroll = true;
            panelKetQuaTimKiem.BackColor = SystemColors.Control;
            panelKetQuaTimKiem.Location = new Point(28, 52);
            panelKetQuaTimKiem.Name = "panelKetQuaTimKiem";
            panelKetQuaTimKiem.Size = new Size(463, 221);
            panelKetQuaTimKiem.TabIndex = 41;
            // 
            // flowLayoutPanelThietLapGia
            // 
            flowLayoutPanelThietLapGia.BackColor = SystemColors.ActiveCaption;
            flowLayoutPanelThietLapGia.Dock = DockStyle.Fill;
            flowLayoutPanelThietLapGia.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelThietLapGia.Location = new Point(0, 50);
            flowLayoutPanelThietLapGia.Name = "flowLayoutPanelThietLapGia";
            flowLayoutPanelThietLapGia.Size = new Size(1144, 602);
            flowLayoutPanelThietLapGia.TabIndex = 39;
            flowLayoutPanelThietLapGia.SizeChanged += flowLayoutPanelThietLapGia_SizeChanged;
            // 
            // panel
            // 
            panel.Controls.Add(labelDVT);
            panel.Controls.Add(comboBoxDonViTinh);
            panel.Controls.Add(tableLayoutPanelTimKiem);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Name = "panel";
            panel.Size = new Size(1144, 50);
            panel.TabIndex = 38;
            // 
            // labelDVT
            // 
            labelDVT.AutoSize = true;
            labelDVT.Location = new Point(516, 15);
            labelDVT.Name = "labelDVT";
            labelDVT.Size = new Size(81, 20);
            labelDVT.TabIndex = 10;
            labelDVT.Text = "Đơn vị tính";
            // 
            // comboBoxDonViTinh
            // 
            comboBoxDonViTinh.FormattingEnabled = true;
            comboBoxDonViTinh.Location = new Point(603, 12);
            comboBoxDonViTinh.Name = "comboBoxDonViTinh";
            comboBoxDonViTinh.Size = new Size(151, 28);
            comboBoxDonViTinh.TabIndex = 9;
            comboBoxDonViTinh.SelectedIndexChanged += comboBoxDonViTinh_SelectedIndexChanged;
            // 
            // tableLayoutPanelTimKiem
            // 
            tableLayoutPanelTimKiem.BackColor = SystemColors.Window;
            tableLayoutPanelTimKiem.ColumnCount = 2;
            tableLayoutPanelTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanelTimKiem.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanelTimKiem.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanelTimKiem.Controls.Add(textBoxTimHH, 1, 0);
            tableLayoutPanelTimKiem.Location = new Point(28, 3);
            tableLayoutPanelTimKiem.Name = "tableLayoutPanelTimKiem";
            tableLayoutPanelTimKiem.RowCount = 1;
            tableLayoutPanelTimKiem.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanelTimKiem.Size = new Size(425, 42);
            tableLayoutPanelTimKiem.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimHH
            // 
            textBoxTimHH.BorderStyle = BorderStyle.None;
            textBoxTimHH.Font = new Font("Segoe UI", 11F);
            textBoxTimHH.Location = new Point(61, 3);
            textBoxTimHH.Multiline = true;
            textBoxTimHH.Name = "textBoxTimHH";
            textBoxTimHH.PlaceholderText = "Tìm theo mã, tên hàng hóa";
            textBoxTimHH.Size = new Size(325, 36);
            textBoxTimHH.TabIndex = 5;
            textBoxTimHH.Tag = "";
            textBoxTimHH.TextChanged += textBoxTimHH_TextChanged;
            // 
            // FormThietLapGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            Name = "FormThietLapGia";
            Text = "Thiết Lập Giá";
            Load += FormThietLapGia_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            panel.ResumeLayout(false);
            panel.PerformLayout();
            tableLayoutPanelTimKiem.ResumeLayout(false);
            tableLayoutPanelTimKiem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private ComboBox comboBoxNhomHang;
        private GroupBox groupBox1;
        private ComboBox comboBoxLoc;
        private ComboBox comboBoxLoaiGia;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button buttonThemBangGia;
        private ComboBox comboBoxBangGia;
        private FlowLayoutPanel flowLayoutPanelThietLapGia;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanelTimKiem;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
        private Panel panelKetQuaTimKiem;
        private Label labelDVT;
        private ComboBox comboBoxDonViTinh;
    }
}