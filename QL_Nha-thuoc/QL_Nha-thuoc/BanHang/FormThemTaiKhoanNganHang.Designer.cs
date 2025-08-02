namespace QL_Nha_thuoc.BanHang
{
    partial class FormThemTaiKhoanNganHang
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBoxSoTaiKhoan = new TextBox();
            textBoxChuTaiKhoan = new TextBox();
            textBoxGhiChu = new TextBox();
            comboBoxNganHang = new ComboBox();
            buttonLuu = new Button();
            buttonBoQua = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F);
            label1.Location = new Point(52, 33);
            label1.Name = "label1";
            label1.Size = new Size(186, 35);
            label1.TabIndex = 0;
            label1.Text = "Thêm tài khoản";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F);
            label2.Location = new Point(52, 84);
            label2.Name = "label2";
            label2.Size = new Size(181, 25);
            label2.TabIndex = 1;
            label2.Text = "Thông tin tài khoản ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(52, 135);
            label3.Name = "label3";
            label3.Size = new Size(95, 20);
            label3.TabIndex = 2;
            label3.Text = "Số tài khoản ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(52, 182);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 3;
            label4.Text = "Ngân hàng ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 236);
            label5.Name = "label5";
            label5.Size = new Size(103, 20);
            label5.TabIndex = 4;
            label5.Text = "Chủ tài khoản ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(52, 289);
            label6.Name = "label6";
            label6.Size = new Size(62, 20);
            label6.TabIndex = 5;
            label6.Text = "Ghi chú ";
            // 
            // textBoxSoTaiKhoan
            // 
            textBoxSoTaiKhoan.Location = new Point(173, 132);
            textBoxSoTaiKhoan.Name = "textBoxSoTaiKhoan";
            textBoxSoTaiKhoan.Size = new Size(353, 27);
            textBoxSoTaiKhoan.TabIndex = 6;
            // 
            // textBoxChuTaiKhoan
            // 
            textBoxChuTaiKhoan.Location = new Point(173, 229);
            textBoxChuTaiKhoan.Name = "textBoxChuTaiKhoan";
            textBoxChuTaiKhoan.Size = new Size(353, 27);
            textBoxChuTaiKhoan.TabIndex = 7;
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Location = new Point(173, 286);
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.Size = new Size(353, 27);
            textBoxGhiChu.TabIndex = 8;
            // 
            // comboBoxNganHang
            // 
            comboBoxNganHang.FormattingEnabled = true;
            comboBoxNganHang.Location = new Point(176, 179);
            comboBoxNganHang.Name = "comboBoxNganHang";
            comboBoxNganHang.Size = new Size(350, 28);
            comboBoxNganHang.TabIndex = 9;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(322, 366);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 55);
            buttonLuu.TabIndex = 10;
            buttonLuu.Text = "Luu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Location = new Point(442, 366);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(94, 55);
            buttonBoQua.TabIndex = 11;
            buttonBoQua.Text = "Bo Qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            // 
            // FormThemTaiKhoanNganHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 450);
            Controls.Add(buttonBoQua);
            Controls.Add(buttonLuu);
            Controls.Add(comboBoxNganHang);
            Controls.Add(textBoxGhiChu);
            Controls.Add(textBoxChuTaiKhoan);
            Controls.Add(textBoxSoTaiKhoan);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormThemTaiKhoanNganHang";
            Text = "FormTaiKhoanNganHang";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBoxSoTaiKhoan;
        private TextBox textBoxChuTaiKhoan;
        private TextBox textBoxGhiChu;
        private ComboBox comboBoxNganHang;
        private Button buttonLuu;
        private Button buttonBoQua;
    }
}