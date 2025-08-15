namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    partial class UserControlHangHoaTraHang
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
            labelDonViTinh = new Label();
            textBoxDonGiaHH = new TextBox();
            buttonXoa = new Button();
            labelMaHangHoa = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelGiamGia = new Label();
            panel1 = new Panel();
            labelSoLuongBan = new Label();
            numericUpDownSoLuong = new NumericUpDown();
            textBoxThanhTien = new TextBox();
            labelTenHang = new Label();
            labelSTT = new Label();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).BeginInit();
            SuspendLayout();
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.Dock = DockStyle.Fill;
            labelDonViTinh.Font = new Font("Segoe UI", 12F);
            labelDonViTinh.ForeColor = SystemColors.MenuHighlight;
            labelDonViTinh.Location = new Point(912, 0);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(104, 38);
            labelDonViTinh.TabIndex = 12;
            labelDonViTinh.Text = "DVT";
            labelDonViTinh.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxDonGiaHH
            // 
            textBoxDonGiaHH.BackColor = SystemColors.Window;
            textBoxDonGiaHH.Dock = DockStyle.Fill;
            textBoxDonGiaHH.Font = new Font("Segoe UI", 12F);
            textBoxDonGiaHH.Location = new Point(627, 3);
            textBoxDonGiaHH.Name = "textBoxDonGiaHH";
            textBoxDonGiaHH.ReadOnly = true;
            textBoxDonGiaHH.Size = new Size(149, 34);
            textBoxDonGiaHH.TabIndex = 2;
            textBoxDonGiaHH.TextAlign = HorizontalAlignment.Right;
            // 
            // buttonXoa
            // 
            buttonXoa.Dock = DockStyle.Fill;
            buttonXoa.Location = new Point(51, 3);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(42, 32);
            buttonXoa.TabIndex = 0;
            buttonXoa.Text = "x";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.Dock = DockStyle.Fill;
            labelMaHangHoa.Location = new Point(99, 0);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(91, 38);
            labelMaHangHoa.TabIndex = 4;
            labelMaHangHoa.Text = "Ma hang";
            labelMaHangHoa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Window;
            tableLayoutPanel1.ColumnCount = 9;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.8688526F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4590168F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.7049179F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.6557379F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.016394F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.2295074F));
            tableLayoutPanel1.Controls.Add(labelGiamGia, 6, 0);
            tableLayoutPanel1.Controls.Add(panel1, 4, 0);
            tableLayoutPanel1.Controls.Add(textBoxThanhTien, 8, 0);
            tableLayoutPanel1.Controls.Add(labelTenHang, 3, 0);
            tableLayoutPanel1.Controls.Add(labelSTT, 0, 0);
            tableLayoutPanel1.Controls.Add(labelMaHangHoa, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonXoa, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxDonGiaHH, 5, 0);
            tableLayoutPanel1.Controls.Add(labelDonViTinh, 7, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1220, 38);
            tableLayoutPanel1.TabIndex = 9;
            // 
            // labelGiamGia
            // 
            labelGiamGia.AutoSize = true;
            labelGiamGia.Dock = DockStyle.Fill;
            labelGiamGia.Font = new Font("Segoe UI", 12F);
            labelGiamGia.Location = new Point(782, 0);
            labelGiamGia.Name = "labelGiamGia";
            labelGiamGia.Size = new Size(124, 38);
            labelGiamGia.TabIndex = 15;
            labelGiamGia.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelSoLuongBan);
            panel1.Controls.Add(numericUpDownSoLuong);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(475, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(146, 32);
            panel1.TabIndex = 14;
            // 
            // labelSoLuongBan
            // 
            labelSoLuongBan.AutoSize = true;
            labelSoLuongBan.Dock = DockStyle.Left;
            labelSoLuongBan.Font = new Font("Segoe UI", 12F);
            labelSoLuongBan.Location = new Point(69, 0);
            labelSoLuongBan.Name = "labelSoLuongBan";
            labelSoLuongBan.Size = new Size(20, 28);
            labelSoLuongBan.TabIndex = 3;
            labelSoLuongBan.Text = "/";
            labelSoLuongBan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownSoLuong
            // 
            numericUpDownSoLuong.Dock = DockStyle.Left;
            numericUpDownSoLuong.Font = new Font("Segoe UI", 12F);
            numericUpDownSoLuong.Location = new Point(0, 0);
            numericUpDownSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.Name = "numericUpDownSoLuong";
            numericUpDownSoLuong.Size = new Size(69, 34);
            numericUpDownSoLuong.TabIndex = 2;
            numericUpDownSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownSoLuong.ValueChanged += numericUpDownSoLuong_ValueChanged;
            // 
            // textBoxThanhTien
            // 
            textBoxThanhTien.BackColor = SystemColors.Window;
            textBoxThanhTien.BorderStyle = BorderStyle.None;
            textBoxThanhTien.Dock = DockStyle.Fill;
            textBoxThanhTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            textBoxThanhTien.Location = new Point(1022, 3);
            textBoxThanhTien.Name = "textBoxThanhTien";
            textBoxThanhTien.ReadOnly = true;
            textBoxThanhTien.RightToLeft = RightToLeft.Yes;
            textBoxThanhTien.Size = new Size(195, 27);
            textBoxThanhTien.TabIndex = 11;
            textBoxThanhTien.TextAlign = HorizontalAlignment.Right;
            textBoxThanhTien.TextChanged += textBoxThanhTien_TextChanged;
            // 
            // labelTenHang
            // 
            labelTenHang.AutoSize = true;
            labelTenHang.Dock = DockStyle.Fill;
            labelTenHang.Font = new Font("Segoe UI", 12F);
            labelTenHang.Location = new Point(196, 0);
            labelTenHang.Name = "labelTenHang";
            labelTenHang.Size = new Size(273, 38);
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
            labelSTT.Size = new Size(42, 38);
            labelSTT.TabIndex = 3;
            labelSTT.Text = "STT";
            labelSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UserControlHangHoaTraHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlHangHoaTraHang";
            Size = new Size(1220, 38);
            Load += UserControlHangHoaTraHang_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSoLuong).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label labelDonViTinh;
        private TextBox textBoxDonGiaHH;
        private Button buttonXoa;
        private Label labelMaHangHoa;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBoxThanhTien;
        private Label labelGiamGia;
        private Label labelTenHang;
        private Label labelSTT;
        private Panel panel1;
        private Label labelSoLuongBan;
        private NumericUpDown numericUpDownSoLuong;
    }
}
