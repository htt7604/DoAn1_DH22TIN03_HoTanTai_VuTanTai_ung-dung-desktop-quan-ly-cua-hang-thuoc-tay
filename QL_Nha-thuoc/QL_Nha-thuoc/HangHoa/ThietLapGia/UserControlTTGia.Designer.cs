namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class UserControlTTGia
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
            label1 = new Label();
            label4 = new Label();
            labelGiaVon = new Label();
            labelTenHangHoa = new Label();
            labelMaHangHoa = new Label();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.InactiveCaption;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.578207F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.40949F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 9.226713F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.8084354F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.4112482F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.4780312F));
            tableLayoutPanel1.Controls.Add(label1, 4, 0);
            tableLayoutPanel1.Controls.Add(label4, 3, 0);
            tableLayoutPanel1.Controls.Add(labelGiaVon, 2, 0);
            tableLayoutPanel1.Controls.Add(labelTenHangHoa, 1, 0);
            tableLayoutPanel1.Controls.Add(labelMaHangHoa, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1147, 46);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.Location = new Point(839, 0);
            label1.Name = "label1";
            label1.Size = new Size(159, 46);
            label1.TabIndex = 4;
            label1.Text = "Bang gia chung ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Dock = DockStyle.Fill;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(715, 0);
            label4.Name = "label4";
            label4.Size = new Size(118, 46);
            label4.TabIndex = 3;
            label4.Text = "label4";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelGiaVon
            // 
            labelGiaVon.AutoSize = true;
            labelGiaVon.Dock = DockStyle.Fill;
            labelGiaVon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelGiaVon.Location = new Point(610, 0);
            labelGiaVon.Name = "labelGiaVon";
            labelGiaVon.Size = new Size(99, 46);
            labelGiaVon.TabIndex = 2;
            labelGiaVon.Text = "Gia Von";
            labelGiaVon.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelTenHangHoa
            // 
            labelTenHangHoa.AutoSize = true;
            labelTenHangHoa.Dock = DockStyle.Fill;
            labelTenHangHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelTenHangHoa.Location = new Point(112, 0);
            labelTenHangHoa.Name = "labelTenHangHoa";
            labelTenHangHoa.Size = new Size(492, 46);
            labelTenHangHoa.TabIndex = 1;
            labelTenHangHoa.Text = "Ten hang hoa";
            labelTenHangHoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.AutoSize = true;
            labelMaHangHoa.Dock = DockStyle.Fill;
            labelMaHangHoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelMaHangHoa.Location = new Point(3, 0);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(103, 46);
            labelMaHangHoa.TabIndex = 0;
            labelMaHangHoa.Text = "Ma hang hoa";
            labelMaHangHoa.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UserControlTTGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlTTGia";
            Size = new Size(1147, 46);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label4;
        private Label labelGiaVon;
        private Label labelTenHangHoa;
        private Label labelMaHangHoa;
    }
}
