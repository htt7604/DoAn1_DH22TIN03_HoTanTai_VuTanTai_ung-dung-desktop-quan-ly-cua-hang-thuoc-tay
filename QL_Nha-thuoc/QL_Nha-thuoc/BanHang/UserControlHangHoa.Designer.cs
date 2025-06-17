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
            labelSTT = new Label();
            numericUpDown1 = new NumericUpDown();
            labelMaHangHoa = new Label();
            buttonXoa = new Button();
            textBoxGiaBan = new TextBox();
            textBoxTenHang = new TextBox();
            comboBoxDonVITinh = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 8;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.582521F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.62670851F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.3028393F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.2302837F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.88853836F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.46792841F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.4574137F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.240799F));
            tableLayoutPanel1.Controls.Add(labelSTT, 0, 0);
            tableLayoutPanel1.Controls.Add(numericUpDown1, 4, 0);
            tableLayoutPanel1.Controls.Add(labelMaHangHoa, 2, 0);
            tableLayoutPanel1.Controls.Add(buttonXoa, 1, 0);
            tableLayoutPanel1.Controls.Add(textBoxGiaBan, 6, 0);
            tableLayoutPanel1.Controls.Add(textBoxTenHang, 3, 0);
            tableLayoutPanel1.Controls.Add(comboBoxDonVITinh, 7, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(951, 42);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // labelSTT
            // 
            labelSTT.AutoSize = true;
            labelSTT.Dock = DockStyle.Fill;
            labelSTT.Location = new Point(3, 0);
            labelSTT.Name = "labelSTT";
            labelSTT.Size = new Size(28, 42);
            labelSTT.TabIndex = 3;
            labelSTT.Text = "STT";
            labelSTT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Dock = DockStyle.Fill;
            numericUpDown1.Font = new Font("Segoe UI", 12F);
            numericUpDown1.Location = new Point(495, 3);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(50, 34);
            numericUpDown1.TabIndex = 1;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.Dock = DockStyle.Fill;
            labelMaHangHoa.Location = new Point(81, 0);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(111, 42);
            labelMaHangHoa.TabIndex = 4;
            labelMaHangHoa.Text = "Ma hang";
            labelMaHangHoa.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonXoa
            // 
            buttonXoa.Dock = DockStyle.Fill;
            buttonXoa.Location = new Point(37, 3);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(38, 36);
            buttonXoa.TabIndex = 0;
            buttonXoa.Text = "x";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // textBoxGiaBan
            // 
            textBoxGiaBan.Font = new Font("Segoe UI", 12F);
            textBoxGiaBan.Location = new Point(603, 3);
            textBoxGiaBan.Name = "textBoxGiaBan";
            textBoxGiaBan.ReadOnly = true;
            textBoxGiaBan.Size = new Size(103, 34);
            textBoxGiaBan.TabIndex = 2;
            // 
            // textBoxTenHang
            // 
            textBoxTenHang.BackColor = SystemColors.Window;
            textBoxTenHang.BorderStyle = BorderStyle.None;
            textBoxTenHang.Dock = DockStyle.Fill;
            textBoxTenHang.Font = new Font("Segoe UI", 12F);
            textBoxTenHang.Location = new Point(198, 3);
            textBoxTenHang.Multiline = true;
            textBoxTenHang.Name = "textBoxTenHang";
            textBoxTenHang.ReadOnly = true;
            textBoxTenHang.Size = new Size(291, 36);
            textBoxTenHang.TabIndex = 6;
            textBoxTenHang.Text = "TenHang";
            // 
            // comboBoxDonVITinh
            // 
            comboBoxDonVITinh.Font = new Font("Segoe UI", 12F);
            comboBoxDonVITinh.FormattingEnabled = true;
            comboBoxDonVITinh.Location = new Point(750, 3);
            comboBoxDonVITinh.Name = "comboBoxDonVITinh";
            comboBoxDonVITinh.Size = new Size(151, 36);
            comboBoxDonVITinh.TabIndex = 7;
            comboBoxDonVITinh.SelectedIndexChanged += comboBoxDonVITinh_SelectedIndexChanged;
            // 
            // UserControlHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlHangHoa";
            Size = new Size(951, 42);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelSTT;
        private TextBox textBoxTenHang;
        private NumericUpDown numericUpDown1;
        private Button buttonXoa;
        private Label labelMaHangHoa;
        private TextBox textBoxGiaBan;
        private ComboBox comboBoxDonVITinh;
    }
}
