namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    partial class UserControlHangHoaitemNhapHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            labelSTT = new Label();
            buttonX = new Button();
            labelTenHang = new Label();
            textBoxThanhTien = new TextBox();
            textBoxGiamGia = new TextBox();
            textBoxDonGia = new TextBox();
            comboBoxDonViTinh = new ComboBox();
            numericUpDownSoLuong = new NumericUpDown();
            linkLabelMaHangHoa = new LinkLabel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.48717952F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.41025639F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1794872F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.23077F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel1.Controls.Add(labelSTT, 1, 0);
            tableLayoutPanel1.Controls.Add(buttonX, 0, 0);
            tableLayoutPanel1.Controls.Add(labelTenHang, 3, 0);
            tableLayoutPanel1.Controls.Add(textBoxThanhTien, 8, 0);
            tableLayoutPanel1.Controls.Add(textBoxGiamGia, 7, 0);
            tableLayoutPanel1.Controls.Add(textBoxDonGia, 6, 0);
            tableLayoutPanel1.Controls.Add(comboBoxDonViTinh, 4, 0);
            tableLayoutPanel1.Controls.Add(numericUpDownSoLuong, 5, 0);
            tableLayoutPanel1.Controls.Add(linkLabelMaHangHoa, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RightToLeft = RightToLeft.No;
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1397, 46);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // labelSTT
            // 
            labelSTT.AutoSize = true;
            labelSTT.Dock = DockStyle.Fill;
            labelSTT.Location = new Point(51, 0);
            labelSTT.Name = "labelSTT";
            labelSTT.Size = new Size(55, 46);
            labelSTT.TabIndex = 2;
            labelSTT.Text = "STT";
            labelSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonX
            // 
            buttonX.Dock = DockStyle.Fill;
            buttonX.Location = new Point(3, 3);
            buttonX.Name = "buttonX";
            buttonX.Size = new Size(42, 40);
            buttonX.TabIndex = 0;
            buttonX.Text = "X";
            buttonX.UseVisualStyleBackColor = true;
            // 
            // labelTenHang
            // 
            labelTenHang.AutoSize = true;
            labelTenHang.Dock = DockStyle.Fill;
            labelTenHang.Location = new Point(268, 0);
            labelTenHang.Name = "labelTenHang";
            labelTenHang.Size = new Size(346, 46);
            labelTenHang.TabIndex = 3;
            labelTenHang.Text = "label2";
            labelTenHang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxThanhTien
            // 
            textBoxThanhTien.Dock = DockStyle.Fill;
            textBoxThanhTien.Location = new Point(1240, 3);
            textBoxThanhTien.Name = "textBoxThanhTien";
            textBoxThanhTien.Size = new Size(154, 27);
            textBoxThanhTien.TabIndex = 4;
            // 
            // textBoxGiamGia
            // 
            textBoxGiamGia.Dock = DockStyle.Fill;
            textBoxGiamGia.Location = new Point(1085, 3);
            textBoxGiamGia.Name = "textBoxGiamGia";
            textBoxGiamGia.ReadOnly = true;
            textBoxGiamGia.Size = new Size(149, 27);
            textBoxGiamGia.TabIndex = 5;
            textBoxGiamGia.Click += textBoxGiamGia_Click;
            textBoxGiamGia.TextChanged += textBoxGiamGia_TextChanged;
            // 
            // textBoxDonGia
            // 
            textBoxDonGia.Dock = DockStyle.Fill;
            textBoxDonGia.Location = new Point(930, 3);
            textBoxDonGia.Name = "textBoxDonGia";
            textBoxDonGia.Size = new Size(149, 27);
            textBoxDonGia.TabIndex = 6;
            textBoxDonGia.TextChanged += textBoxDonGia_TextChanged;
            // 
            // comboBoxDonViTinh
            // 
            comboBoxDonViTinh.Dock = DockStyle.Fill;
            comboBoxDonViTinh.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDonViTinh.FormattingEnabled = true;
            comboBoxDonViTinh.Location = new Point(620, 3);
            comboBoxDonViTinh.Name = "comboBoxDonViTinh";
            comboBoxDonViTinh.Size = new Size(149, 28);
            comboBoxDonViTinh.TabIndex = 7;
            comboBoxDonViTinh.SelectedIndexChanged += comboBoxDonViTinh_SelectedIndexChanged;
            // 
            // numericUpDownSoLuong
            // 
            numericUpDownSoLuong.Dock = DockStyle.Fill;
            numericUpDownSoLuong.Location = new Point(775, 3);
            numericUpDownSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            numericUpDownSoLuong.Size = new Size(149, 27);
            numericUpDownSoLuong.TabIndex = 8;
            numericUpDownSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.ValueChanged += numericUpDownSoLuong_ValueChanged;
            // 
            // linkLabelMaHangHoa
            // 
            linkLabelMaHangHoa.AutoSize = true;
            linkLabelMaHangHoa.Dock = DockStyle.Fill;
            linkLabelMaHangHoa.Location = new Point(112, 0);
            linkLabelMaHangHoa.Name = "linkLabelMaHangHoa";
            linkLabelMaHangHoa.Size = new Size(150, 46);
            linkLabelMaHangHoa.TabIndex = 9;
            linkLabelMaHangHoa.TabStop = true;
            linkLabelMaHangHoa.Text = "Ma hang hoa";
            linkLabelMaHangHoa.TextAlign = ContentAlignment.MiddleCenter;
            linkLabelMaHangHoa.LinkClicked += linkLabelMaHangHoa_LinkClicked;
            // 
            // UserControlHangHoaitemNhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlHangHoaitemNhapHang";
            Size = new Size(1397, 46);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSTT;
        private Button buttonX;
        private Label labelTenHang;
        private TextBox textBoxThanhTien;
        private TextBox textBoxGiamGia;
        private TextBox textBoxDonGia;
        private ComboBox comboBoxDonViTinh;
        private NumericUpDown numericUpDownSoLuong;
        private LinkLabel linkLabelMaHangHoa;
    }
}
