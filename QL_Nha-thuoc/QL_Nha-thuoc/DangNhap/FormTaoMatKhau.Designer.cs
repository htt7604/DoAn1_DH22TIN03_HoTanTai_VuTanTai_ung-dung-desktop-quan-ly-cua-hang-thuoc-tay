namespace QL_Nha_thuoc.DangNhap
{
    partial class FormTaoMatKhau
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
            textBoxMatKhauMoi = new TextBox();
            textBoxNhapLai = new TextBox();
            label2 = new Label();
            label3 = new Label();
            buttonBoQua = new Button();
            buttonXacNhan = new Button();
            checkBoxHienThi = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(227, 50);
            label1.Name = "label1";
            label1.Size = new Size(209, 35);
            label1.TabIndex = 2;
            label1.Text = "TẠO MẬT KHẨU";
            // 
            // textBoxMatKhauMoi
            // 
            textBoxMatKhauMoi.Location = new Point(153, 129);
            textBoxMatKhauMoi.Name = "textBoxMatKhauMoi";
            textBoxMatKhauMoi.Size = new Size(347, 27);
            textBoxMatKhauMoi.TabIndex = 3;
            // 
            // textBoxNhapLai
            // 
            textBoxNhapLai.Location = new Point(153, 192);
            textBoxNhapLai.Name = "textBoxNhapLai";
            textBoxNhapLai.Size = new Size(347, 27);
            textBoxNhapLai.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 132);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 5;
            label2.Text = "Mật khẩu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 199);
            label3.Name = "label3";
            label3.Size = new Size(133, 20);
            label3.TabIndex = 6;
            label3.Text = "Nhập lại mật khẩu:";
            // 
            // buttonBoQua
            // 
            buttonBoQua.BackColor = SystemColors.Highlight;
            buttonBoQua.Location = new Point(363, 278);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(137, 47);
            buttonBoQua.TabIndex = 9;
            buttonBoQua.Text = "Quay lại";
            buttonBoQua.UseVisualStyleBackColor = false;
            // 
            // buttonXacNhan
            // 
            buttonXacNhan.BackColor = Color.Lime;
            buttonXacNhan.Location = new Point(153, 278);
            buttonXacNhan.Name = "buttonXacNhan";
            buttonXacNhan.Size = new Size(137, 47);
            buttonXacNhan.TabIndex = 7;
            buttonXacNhan.Text = "Xác nhận";
            buttonXacNhan.UseVisualStyleBackColor = false;
            buttonXacNhan.Click += buttonXacNhan_Click;
            // 
            // checkBoxHienThi
            // 
            checkBoxHienThi.AutoSize = true;
            checkBoxHienThi.Location = new Point(153, 238);
            checkBoxHienThi.Name = "checkBoxHienThi";
            checkBoxHienThi.Size = new Size(148, 24);
            checkBoxHienThi.TabIndex = 10;
            checkBoxHienThi.Text = "Hiển thị mật khẩu";
            checkBoxHienThi.UseVisualStyleBackColor = true;
            checkBoxHienThi.CheckedChanged += checkBoxHienThi_CheckedChanged;
            // 
            // FormTaoMatKhau
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(682, 385);
            Controls.Add(checkBoxHienThi);
            Controls.Add(buttonBoQua);
            Controls.Add(buttonXacNhan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxNhapLai);
            Controls.Add(textBoxMatKhauMoi);
            Controls.Add(label1);
            Name = "FormTaoMatKhau";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormTaoMatKhau";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxMatKhauMoi;
        private TextBox textBoxNhapLai;
        private Label label2;
        private Label label3;
        private Button buttonBoQua;
        private Button buttonXacNhan;
        private CheckBox checkBoxHienThi;
    }
}