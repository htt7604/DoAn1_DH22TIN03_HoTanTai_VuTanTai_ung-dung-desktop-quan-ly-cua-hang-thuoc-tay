namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlHangHoa
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
            numericUpDownSoLuong = new NumericUpDown();
            textBoxDonGiaHH = new TextBox();
            textBoxThanhTien = new TextBox();
            labelGiamGia = new Label();
            labelTenHang = new Label();
            labelSTT = new Label();
            labelMaHangHoa = new Label();
            buttonXoa = new Button();
            labelDonViTinh = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.31579F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 6.47773266F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.7368422F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.3076925F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.340081F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.7894735F));
            tableLayoutPanel1.Controls.Add(numericUpDownSoLuong, 4, 0);
            tableLayoutPanel1.Controls.Add(textBoxDonGiaHH, 5, 0);
            tableLayoutPanel1.Controls.Add(textBoxThanhTien, 8, 0);
            tableLayoutPanel1.Controls.Add(labelGiamGia, 6, 0);
            tableLayoutPanel1.Controls.Add(labelTenHang, 3, 0);
            tableLayoutPanel1.Controls.Add(labelSTT, 0, 0);
            tableLayoutPanel1.Controls.Add(labelMaHangHoa, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonXoa, 1, 0);
            tableLayoutPanel1.Controls.Add(labelDonViTinh, 7, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1235, 42);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // numericUpDownSoLuong
            // 
            numericUpDownSoLuong.Dock = DockStyle.Fill;
            numericUpDownSoLuong.Font = new Font("Segoe UI", 12F);
            numericUpDownSoLuong.Location = new Point(524, 3);
            numericUpDownSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            numericUpDownSoLuong.Size = new Size(74, 34);
            numericUpDownSoLuong.TabIndex = 15;
            numericUpDownSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.ValueChanged += numericUpDownSoLuong_ValueChanged;
            // 
            // textBoxDonGiaHH
            // 
            textBoxDonGiaHH.BackColor = SystemColors.Window;
            textBoxDonGiaHH.Dock = DockStyle.Fill;
            textBoxDonGiaHH.Font = new Font("Segoe UI", 12F);
            textBoxDonGiaHH.Location = new Point(604, 3);
            textBoxDonGiaHH.Name = "textBoxDonGiaHH";
            textBoxDonGiaHH.ReadOnly = true;
            textBoxDonGiaHH.Size = new Size(176, 34);
            textBoxDonGiaHH.TabIndex = 14;
            textBoxDonGiaHH.TextAlign = HorizontalAlignment.Right;
            textBoxDonGiaHH.Click += textBoxDonGiaHH_Click;
            textBoxDonGiaHH.TextChanged += textBoxDonGiaHH_TextChanged;
            // 
            // textBoxThanhTien
            // 
            textBoxThanhTien.BackColor = SystemColors.Window;
            textBoxThanhTien.BorderStyle = BorderStyle.None;
            textBoxThanhTien.Dock = DockStyle.Fill;
            textBoxThanhTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxThanhTien.Location = new Point(1041, 3);
            textBoxThanhTien.Name = "textBoxThanhTien";
            textBoxThanhTien.ReadOnly = true;
            textBoxThanhTien.RightToLeft = RightToLeft.Yes;
            textBoxThanhTien.Size = new Size(191, 27);
            textBoxThanhTien.TabIndex = 11;
            textBoxThanhTien.TextAlign = HorizontalAlignment.Right;
            textBoxThanhTien.TextChanged += textBoxThanhTien_TextChanged;
            // 
            // labelGiamGia
            // 
            labelGiamGia.AutoSize = true;
            labelGiamGia.Dock = DockStyle.Fill;
            labelGiamGia.Font = new Font("Segoe UI", 12F);
            labelGiamGia.Location = new Point(786, 0);
            labelGiamGia.Name = "labelGiamGia";
            labelGiamGia.Size = new Size(146, 42);
            labelGiamGia.TabIndex = 10;
            labelGiamGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTenHang
            // 
            labelTenHang.AutoSize = true;
            labelTenHang.Dock = DockStyle.Fill;
            labelTenHang.Font = new Font("Segoe UI", 12F);
            labelTenHang.Location = new Point(199, 0);
            labelTenHang.Name = "labelTenHang";
            labelTenHang.Size = new Size(319, 42);
            labelTenHang.TabIndex = 9;
            labelTenHang.Text = "Ten hang";
            labelTenHang.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSTT
            // 
            labelSTT.AutoSize = true;
            labelSTT.Dock = DockStyle.Fill;
            labelSTT.Location = new Point(3, 0);
            labelSTT.Name = "labelSTT";
            labelSTT.Size = new Size(43, 42);
            labelSTT.TabIndex = 3;
            labelSTT.Text = "STT";
            labelSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.Dock = DockStyle.Fill;
            labelMaHangHoa.Location = new Point(101, 0);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(92, 42);
            labelMaHangHoa.TabIndex = 4;
            labelMaHangHoa.Text = "Ma hang";
            labelMaHangHoa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonXoa
            // 
            buttonXoa.Dock = DockStyle.Fill;
            buttonXoa.Location = new Point(52, 3);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(43, 36);
            buttonXoa.TabIndex = 0;
            buttonXoa.Text = "x";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.Dock = DockStyle.Fill;
            labelDonViTinh.Font = new Font("Segoe UI", 12F);
            labelDonViTinh.ForeColor = SystemColors.MenuHighlight;
            labelDonViTinh.Location = new Point(938, 0);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(97, 42);
            labelDonViTinh.TabIndex = 12;
            labelDonViTinh.Text = "DVT";
            labelDonViTinh.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlHangHoa";
            Size = new Size(1235, 42);
            Load += UserControlHangHoa_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSTT;
        private Button buttonXoa;
        private Label labelMaHangHoa;
        private Label labelTenHang;
        private Label labelGiamGia;
        private TextBox textBoxThanhTien;
        private Label labelDonViTinh;
        private TextBox textBoxDonGiaHH;
        private NumericUpDown numericUpDownSoLuong;
    }
}
