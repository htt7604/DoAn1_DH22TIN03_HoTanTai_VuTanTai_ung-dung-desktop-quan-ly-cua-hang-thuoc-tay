namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class UserControlitemThietLapGia
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
            labelDonViTinh = new Label();
            labelGiaVon = new Label();
            labelTenHangHoa = new Label();
            labelMaHangHoa = new Label();
            textBoxGiaChung = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Window;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.929701F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.67311F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.226713F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.8084354F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.4112482F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4780312F));
            tableLayoutPanel1.Controls.Add(labelDonViTinh, 3, 0);
            tableLayoutPanel1.Controls.Add(labelGiaVon, 2, 0);
            tableLayoutPanel1.Controls.Add(labelTenHangHoa, 1, 0);
            tableLayoutPanel1.Controls.Add(labelMaHangHoa, 0, 0);
            tableLayoutPanel1.Controls.Add(textBoxGiaChung, 4, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1144, 44);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.Dock = DockStyle.Fill;
            labelDonViTinh.Location = new Point(718, 0);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(117, 44);
            labelDonViTinh.TabIndex = 3;
            labelDonViTinh.Text = "label4";
            labelDonViTinh.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelGiaVon
            // 
            labelGiaVon.AutoSize = true;
            labelGiaVon.Dock = DockStyle.Fill;
            labelGiaVon.Location = new Point(613, 0);
            labelGiaVon.Name = "labelGiaVon";
            labelGiaVon.Size = new Size(99, 44);
            labelGiaVon.TabIndex = 2;
            labelGiaVon.Text = "label3";
            labelGiaVon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTenHangHoa
            // 
            labelTenHangHoa.AutoSize = true;
            labelTenHangHoa.Dock = DockStyle.Fill;
            labelTenHangHoa.Location = new Point(116, 0);
            labelTenHangHoa.Name = "labelTenHangHoa";
            labelTenHangHoa.Size = new Size(491, 44);
            labelTenHangHoa.TabIndex = 1;
            labelTenHangHoa.Text = "label2";
            labelTenHangHoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.AutoSize = true;
            labelMaHangHoa.Dock = DockStyle.Fill;
            labelMaHangHoa.Location = new Point(3, 0);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(107, 44);
            labelMaHangHoa.TabIndex = 0;
            labelMaHangHoa.Text = "label1";
            labelMaHangHoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxGiaChung
            // 
            textBoxGiaChung.Dock = DockStyle.Fill;
            textBoxGiaChung.Location = new Point(841, 3);
            textBoxGiaChung.Multiline = true;
            textBoxGiaChung.Name = "textBoxGiaChung";
            textBoxGiaChung.ReadOnly = true;
            textBoxGiaChung.Size = new Size(158, 38);
            textBoxGiaChung.TabIndex = 4;
            textBoxGiaChung.Click += textBoxGiaChung_Click;
            // 
            // UserControlitemThietLapGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlitemThietLapGia";
            Size = new Size(1144, 44);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label labelDonViTinh;
        private Label labelGiaVon;
        private Label labelTenHangHoa;
        private Label labelMaHangHoa;
        private TextBox textBoxGiaChung;
    }
}
