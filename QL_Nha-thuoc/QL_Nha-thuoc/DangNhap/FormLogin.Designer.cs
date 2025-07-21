namespace QL_Nha_thuoc.DangNhap
{
    partial class FormLogin
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
            buttonQuanLy = new Button();
            label1 = new Label();
            textBoxTenDangNhap = new TextBox();
            textBoxMatKhau = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonBanHang = new Button();
            SuspendLayout();
            // 
            // buttonQuanLy
            // 
            buttonQuanLy.BackColor = Color.Lime;
            buttonQuanLy.Location = new Point(172, 295);
            buttonQuanLy.Name = "buttonQuanLy";
            buttonQuanLy.Size = new Size(94, 35);
            buttonQuanLy.TabIndex = 0;
            buttonQuanLy.Text = "Quản lý";
            buttonQuanLy.UseVisualStyleBackColor = false;
            buttonQuanLy.Click += buttonQuanLy_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(252, 50);
            label1.Name = "label1";
            label1.Size = new Size(168, 35);
            label1.TabIndex = 1;
            label1.Text = "ĐĂNG NHẬP";
            // 
            // textBoxTenDangNhap
            // 
            textBoxTenDangNhap.Location = new Point(222, 152);
            textBoxTenDangNhap.Name = "textBoxTenDangNhap";
            textBoxTenDangNhap.Size = new Size(296, 27);
            textBoxTenDangNhap.TabIndex = 2;
            // 
            // textBoxMatKhau
            // 
            textBoxMatKhau.Location = new Point(222, 213);
            textBoxMatKhau.Name = "textBoxMatKhau";
            textBoxMatKhau.Size = new Size(296, 27);
            textBoxMatKhau.TabIndex = 3;
            textBoxMatKhau.UseSystemPasswordChar = true;
            textBoxMatKhau.KeyDown += FormLogin_KeyDown;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 159);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 4;
            label2.Text = "Tên người dùng";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 220);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Mật khẩu";
            // 
            // buttonBanHang
            // 
            buttonBanHang.BackColor = SystemColors.Highlight;
            buttonBanHang.Location = new Point(388, 295);
            buttonBanHang.Name = "buttonBanHang";
            buttonBanHang.Size = new Size(94, 35);
            buttonBanHang.TabIndex = 6;
            buttonBanHang.Text = "Bán Hàng";
            buttonBanHang.UseVisualStyleBackColor = false;
            buttonBanHang.Click += buttonBanHang_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 385);
            Controls.Add(buttonBanHang);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxMatKhau);
            Controls.Add(textBoxTenDangNhap);
            Controls.Add(label1);
            Controls.Add(buttonQuanLy);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonQuanLy;
        private Label label1;
        private TextBox textBoxTenDangNhap;
        private TextBox textBoxMatKhau;
        private Label label2;
        private Label label3;
        private Button buttonBanHang;
    }
}