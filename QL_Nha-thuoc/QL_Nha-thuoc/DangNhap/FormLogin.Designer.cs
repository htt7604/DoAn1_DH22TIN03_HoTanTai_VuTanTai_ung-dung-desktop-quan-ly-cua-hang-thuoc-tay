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
            buttonDangNhap = new Button();
            label1 = new Label();
            textBoxTenDangNhap = new TextBox();
            textBoxMatKhau = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonDangNhap
            // 
            buttonDangNhap.Location = new Point(301, 292);
            buttonDangNhap.Name = "buttonDangNhap";
            buttonDangNhap.Size = new Size(94, 29);
            buttonDangNhap.TabIndex = 0;
            buttonDangNhap.Text = "Dang nhap";
            buttonDangNhap.UseVisualStyleBackColor = true;
            buttonDangNhap.Click += buttonDangNhap_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(291, 51);
            label1.Name = "label1";
            label1.Size = new Size(147, 35);
            label1.TabIndex = 1;
            label1.Text = "Dang Nhap";
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
            label2.Size = new Size(112, 20);
            label2.TabIndex = 4;
            label2.Text = "Ten nguoi dung";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(82, 220);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 5;
            label3.Text = "Mat khau";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 385);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxMatKhau);
            Controls.Add(textBoxTenDangNhap);
            Controls.Add(label1);
            Controls.Add(buttonDangNhap);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormLogin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDangNhap;
        private Label label1;
        private TextBox textBoxTenDangNhap;
        private TextBox textBoxMatKhau;
        private Label label2;
        private Label label3;
    }
}