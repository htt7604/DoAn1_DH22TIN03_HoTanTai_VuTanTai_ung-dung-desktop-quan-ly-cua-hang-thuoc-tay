namespace QL_Nha_thuoc.DangNhap
{
    partial class FormXacThucEmail
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
            buttonTroLai = new Button();
            buttonXacNhan = new Button();
            textBoxMaXacThuc = new TextBox();
            label1 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            labelTenTaiKhoan = new Label();
            labelThongTin = new Label();
            labelHieuLuc = new LinkLabel();
            SuspendLayout();
            // 
            // buttonTroLai
            // 
            buttonTroLai.BackColor = SystemColors.Highlight;
            buttonTroLai.Location = new Point(341, 231);
            buttonTroLai.Name = "buttonTroLai";
            buttonTroLai.Size = new Size(129, 47);
            buttonTroLai.TabIndex = 11;
            buttonTroLai.Text = "Trở lại";
            buttonTroLai.UseVisualStyleBackColor = false;
            // 
            // buttonXacNhan
            // 
            buttonXacNhan.BackColor = Color.Lime;
            buttonXacNhan.Location = new Point(174, 231);
            buttonXacNhan.Name = "buttonXacNhan";
            buttonXacNhan.Size = new Size(127, 47);
            buttonXacNhan.TabIndex = 10;
            buttonXacNhan.Text = "Xác nhập";
            buttonXacNhan.UseVisualStyleBackColor = false;
            buttonXacNhan.Click += buttonXacNhan_Click;
            // 
            // textBoxMaXacThuc
            // 
            textBoxMaXacThuc.Font = new Font("Segoe UI", 10F);
            textBoxMaXacThuc.Location = new Point(174, 184);
            textBoxMaXacThuc.Name = "textBoxMaXacThuc";
            textBoxMaXacThuc.PlaceholderText = "Nhập mã xác thực ";
            textBoxMaXacThuc.Size = new Size(296, 30);
            textBoxMaXacThuc.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(224, 43);
            label1.Name = "label1";
            label1.Size = new Size(225, 35);
            label1.TabIndex = 8;
            label1.Text = "XÁC THỰC EMAIL";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // labelTenTaiKhoan
            // 
            labelTenTaiKhoan.AutoSize = true;
            labelTenTaiKhoan.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelTenTaiKhoan.ForeColor = SystemColors.Highlight;
            labelTenTaiKhoan.Location = new Point(553, 18);
            labelTenTaiKhoan.Name = "labelTenTaiKhoan";
            labelTenTaiKhoan.RightToLeft = RightToLeft.Yes;
            labelTenTaiKhoan.Size = new Size(117, 23);
            labelTenTaiKhoan.TabIndex = 13;
            labelTenTaiKhoan.Text = "Tên tài khoản";
            labelTenTaiKhoan.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelThongTin
            // 
            labelThongTin.AutoSize = true;
            labelThongTin.Location = new Point(174, 126);
            labelThongTin.Name = "labelThongTin";
            labelThongTin.Size = new Size(209, 20);
            labelThongTin.TabIndex = 14;
            labelThongTin.Text = "Chúng tối gửi mã xác thực tới ";
            // 
            // labelHieuLuc
            // 
            labelHieuLuc.AutoSize = true;
            labelHieuLuc.Location = new Point(283, 298);
            labelHieuLuc.Name = "labelHieuLuc";
            labelHieuLuc.Size = new Size(76, 20);
            labelHieuLuc.TabIndex = 15;
            labelHieuLuc.TabStop = true;
            labelHieuLuc.Text = "linkLabel1";
            labelHieuLuc.TextAlign = ContentAlignment.MiddleCenter;
            labelHieuLuc.LinkClicked += labelHieuLuc_LinkClicked;
            // 
            // FormXacThucEmail
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 385);
            Controls.Add(labelHieuLuc);
            Controls.Add(labelThongTin);
            Controls.Add(labelTenTaiKhoan);
            Controls.Add(buttonTroLai);
            Controls.Add(buttonXacNhan);
            Controls.Add(textBoxMaXacThuc);
            Controls.Add(label1);
            Name = "FormXacThucEmail";
            Text = "FormXacThucEmail";
            Load += FormXacThucEmail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonTroLai;
        private Button buttonXacNhan;
        private TextBox textBoxMaXacThuc;
        private Label label1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Label labelTenTaiKhoan;
        private Label labelThongTin;
        private LinkLabel labelHieuLuc;
    }
}