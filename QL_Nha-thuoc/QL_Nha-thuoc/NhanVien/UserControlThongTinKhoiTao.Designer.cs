namespace QL_Nha_thuoc.NhanVien
{
    partial class UserControlThongTinKhoiTao
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
            buttonThemHinhAnh = new Button();
            pictureBox1 = new PictureBox();
            buttonHienThiThem = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBoxMaNhanVien = new TextBox();
            textBoxSoDienThoai = new TextBox();
            textBoxTenNhanVien = new TextBox();
            panel3 = new Panel();
            textBoxEmail = new TextBox();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // buttonThemHinhAnh
            // 
            buttonThemHinhAnh.Location = new Point(50, 177);
            buttonThemHinhAnh.Name = "buttonThemHinhAnh";
            buttonThemHinhAnh.Size = new Size(94, 29);
            buttonThemHinhAnh.TabIndex = 4;
            buttonThemHinhAnh.Text = "button1";
            buttonThemHinhAnh.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Location = new Point(26, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(145, 124);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // buttonHienThiThem
            // 
            buttonHienThiThem.Location = new Point(222, 233);
            buttonHienThiThem.Name = "buttonHienThiThem";
            buttonHienThiThem.Size = new Size(151, 29);
            buttonHienThiThem.TabIndex = 6;
            buttonHienThiThem.Text = "Hien Thi Them";
            buttonHienThiThem.UseVisualStyleBackColor = true;
            buttonHienThiThem.Click += buttonHienThiThem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 16);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 0;
            label2.Text = "Thong tin khoi tao";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 66);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 1;
            label3.Text = "Ma nhan vien ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 120);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 2;
            label4.Text = "So dien thoai";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(451, 66);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 3;
            label5.Text = "Ten nhan vien";
            // 
            // textBoxMaNhanVien
            // 
            textBoxMaNhanVien.Location = new Point(199, 63);
            textBoxMaNhanVien.Name = "textBoxMaNhanVien";
            textBoxMaNhanVien.ReadOnly = true;
            textBoxMaNhanVien.Size = new Size(181, 27);
            textBoxMaNhanVien.TabIndex = 4;
            // 
            // textBoxSoDienThoai
            // 
            textBoxSoDienThoai.Location = new Point(199, 117);
            textBoxSoDienThoai.Name = "textBoxSoDienThoai";
            textBoxSoDienThoai.Size = new Size(181, 27);
            textBoxSoDienThoai.TabIndex = 5;
            // 
            // textBoxTenNhanVien
            // 
            textBoxTenNhanVien.Location = new Point(598, 63);
            textBoxTenNhanVien.Name = "textBoxTenNhanVien";
            textBoxTenNhanVien.Size = new Size(244, 27);
            textBoxTenNhanVien.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(textBoxEmail);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(textBoxTenNhanVien);
            panel3.Controls.Add(textBoxSoDienThoai);
            panel3.Controls.Add(textBoxMaNhanVien);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(222, 31);
            panel3.Name = "panel3";
            panel3.Size = new Size(957, 184);
            panel3.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(598, 120);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(244, 27);
            textBoxEmail.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(451, 123);
            label10.Name = "label10";
            label10.Size = new Size(46, 20);
            label10.TabIndex = 7;
            label10.Text = "Email";
            // 
            // UserControlThongTinKhoiTao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonHienThiThem);
            Controls.Add(panel3);
            Controls.Add(buttonThemHinhAnh);
            Controls.Add(pictureBox1);
            Name = "UserControlThongTinKhoiTao";
            Size = new Size(1194, 267);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button buttonThemHinhAnh;
        private PictureBox pictureBox1;
        private Button buttonHienThiThem;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBoxMaNhanVien;
        private TextBox textBoxSoDienThoai;
        private TextBox textBoxTenNhanVien;
        private Panel panel3;
        private TextBox textBoxEmail;
        private Label label10;
    }
}
