namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlThanhToanChuyenKhoan
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
            splitContainer1 = new SplitContainer();
            pictureBoxQR = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            buttonChonTaiKhoanNH = new Button();
            labelSoTien = new Label();
            labelSoTaiKhoan = new Label();
            labelTenChuTaiKhoan = new Label();
            buttonHienQR = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(pictureBoxQR);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(buttonChonTaiKhoanNH);
            splitContainer1.Panel2.Controls.Add(labelSoTien);
            splitContainer1.Panel2.Controls.Add(labelSoTaiKhoan);
            splitContainer1.Panel2.Controls.Add(labelTenChuTaiKhoan);
            splitContainer1.Panel2.Controls.Add(buttonHienQR);
            splitContainer1.Size = new Size(688, 240);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 0;
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxQR.Dock = DockStyle.Fill;
            pictureBoxQR.Location = new Point(0, 0);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(229, 240);
            pictureBoxQR.TabIndex = 5;
            pictureBoxQR.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 125);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 14;
            label3.Text = "So tien";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(60, 72);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 13;
            label2.Text = "So TK";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 24);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 12;
            label1.Text = "Ten tai khoan";
            // 
            // buttonChonTaiKhoanNH
            // 
            buttonChonTaiKhoanNH.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonChonTaiKhoanNH.Location = new Point(377, 13);
            buttonChonTaiKhoanNH.Name = "buttonChonTaiKhoanNH";
            buttonChonTaiKhoanNH.Size = new Size(58, 40);
            buttonChonTaiKhoanNH.TabIndex = 11;
            buttonChonTaiKhoanNH.Text = "Chọn";
            buttonChonTaiKhoanNH.UseVisualStyleBackColor = true;
            buttonChonTaiKhoanNH.Click += buttonChonTaiKhoanNH_Click;
            // 
            // labelSoTien
            // 
            labelSoTien.AutoSize = true;
            labelSoTien.Location = new Point(162, 125);
            labelSoTien.Name = "labelSoTien";
            labelSoTien.Size = new Size(50, 20);
            labelSoTien.TabIndex = 10;
            labelSoTien.Text = "label3";
            // 
            // labelSoTaiKhoan
            // 
            labelSoTaiKhoan.AutoSize = true;
            labelSoTaiKhoan.Location = new Point(162, 72);
            labelSoTaiKhoan.Name = "labelSoTaiKhoan";
            labelSoTaiKhoan.Size = new Size(50, 20);
            labelSoTaiKhoan.TabIndex = 9;
            labelSoTaiKhoan.Text = "label2";
            // 
            // labelTenChuTaiKhoan
            // 
            labelTenChuTaiKhoan.AutoSize = true;
            labelTenChuTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTenChuTaiKhoan.Location = new Point(162, 22);
            labelTenChuTaiKhoan.Name = "labelTenChuTaiKhoan";
            labelTenChuTaiKhoan.Size = new Size(59, 23);
            labelTenChuTaiKhoan.TabIndex = 8;
            labelTenChuTaiKhoan.Text = "label1";
            // 
            // buttonHienQR
            // 
            buttonHienQR.Location = new Point(13, 186);
            buttonHienQR.Name = "buttonHienQR";
            buttonHienQR.Size = new Size(94, 40);
            buttonHienQR.TabIndex = 7;
            buttonHienQR.Text = "Hien QR";
            buttonHienQR.UseVisualStyleBackColor = true;
            buttonHienQR.Click += buttonHienQR_Click;
            // 
            // UserControlThanhToanChuyenKhoan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(splitContainer1);
            Name = "UserControlThanhToanChuyenKhoan";
            Size = new Size(688, 240);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBoxQR;
        private Button buttonHienQR;
        private Label labelSoTien;
        private Label labelSoTaiKhoan;
        private Label labelTenChuTaiKhoan;
        private Button buttonChonTaiKhoanNH;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
