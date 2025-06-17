namespace QL_Nha_thuoc.DoiTac.khachhang
{
    partial class FormSuaKhachHang
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
            groupBox2 = new GroupBox();
            radioButtonCongTy = new RadioButton();
            radioButtonCaNhan = new RadioButton();
            radioButtonNu = new RadioButton();
            groupBox1 = new GroupBox();
            radioButtonNam = new RadioButton();
            buttonThemAnh = new Button();
            buttonLuu = new Button();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            textBoxGhiChu = new TextBox();
            label9 = new Label();
            textBoxTenCongTy = new TextBox();
            label8 = new Label();
            textBoxDienThoai = new TextBox();
            label6 = new Label();
            textBoxDiaChi = new TextBox();
            label5 = new Label();
            label4 = new Label();
            textBoxTenKH = new TextBox();
            textBoxCCCD = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label = new Label();
            pictureBoxKhachHang = new PictureBox();
            labelMaKH = new Label();
            textBoxMaKH = new TextBox();
            textBoxCHinh = new TextBox();
            labelDonViTinh = new Label();
            textBoxEmail = new TextBox();
            labelGia = new Label();
            textBoxMaSoThue = new TextBox();
            buttonBoQua = new Button();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKhachHang).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(radioButtonCongTy);
            groupBox2.Controls.Add(radioButtonCaNhan);
            groupBox2.Location = new Point(1027, 149);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 45);
            groupBox2.TabIndex = 136;
            groupBox2.TabStop = false;
            // 
            // radioButtonCongTy
            // 
            radioButtonCongTy.AutoSize = true;
            radioButtonCongTy.Location = new Point(9, 11);
            radioButtonCongTy.Name = "radioButtonCongTy";
            radioButtonCongTy.Size = new Size(81, 24);
            radioButtonCongTy.TabIndex = 102;
            radioButtonCongTy.TabStop = true;
            radioButtonCongTy.Text = "Cong ty";
            radioButtonCongTy.UseVisualStyleBackColor = true;
            radioButtonCongTy.CheckedChanged += radioButtonCongTy_CheckedChanged;
            // 
            // radioButtonCaNhan
            // 
            radioButtonCaNhan.AutoSize = true;
            radioButtonCaNhan.Location = new Point(101, 11);
            radioButtonCaNhan.Name = "radioButtonCaNhan";
            radioButtonCaNhan.Size = new Size(86, 24);
            radioButtonCaNhan.TabIndex = 103;
            radioButtonCaNhan.TabStop = true;
            radioButtonCaNhan.Text = "Ca Nhan";
            radioButtonCaNhan.UseVisualStyleBackColor = true;
            // 
            // radioButtonNu
            // 
            radioButtonNu.AutoSize = true;
            radioButtonNu.Location = new Point(101, 19);
            radioButtonNu.Name = "radioButtonNu";
            radioButtonNu.Size = new Size(49, 24);
            radioButtonNu.TabIndex = 101;
            radioButtonNu.TabStop = true;
            radioButtonNu.Text = "Nu";
            radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonNam);
            groupBox1.Controls.Add(radioButtonNu);
            groupBox1.Location = new Point(1027, 98);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 50);
            groupBox1.TabIndex = 135;
            groupBox1.TabStop = false;
            // 
            // radioButtonNam
            // 
            radioButtonNam.AutoSize = true;
            radioButtonNam.Location = new Point(9, 19);
            radioButtonNam.Name = "radioButtonNam";
            radioButtonNam.Size = new Size(62, 24);
            radioButtonNam.TabIndex = 100;
            radioButtonNam.TabStop = true;
            radioButtonNam.Text = "Nam";
            radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // buttonThemAnh
            // 
            buttonThemAnh.Location = new Point(70, 344);
            buttonThemAnh.Name = "buttonThemAnh";
            buttonThemAnh.Size = new Size(103, 32);
            buttonThemAnh.TabIndex = 134;
            buttonThemAnh.Text = "Them Anh";
            buttonThemAnh.Click += buttonThemAnh_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(1119, 499);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(75, 32);
            buttonLuu.TabIndex = 133;
            buttonLuu.Text = "Luu";
            buttonLuu.Click += buttonLuu_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(497, 207);
            dateTimePicker1.MaxDate = new DateTime(2025, 6, 16, 14, 59, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 27);
            dateTimePicker1.TabIndex = 132;
            dateTimePicker1.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(850, 112);
            label1.Name = "label1";
            label1.Size = new Size(65, 20);
            label1.TabIndex = 131;
            label1.Text = "Gioi tinh";
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Location = new Point(1027, 273);
            textBoxGhiChu.Multiline = true;
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.ScrollBars = ScrollBars.Vertical;
            textBoxGhiChu.Size = new Size(200, 73);
            textBoxGhiChu.TabIndex = 130;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(850, 262);
            label9.Name = "label9";
            label9.Size = new Size(61, 20);
            label9.TabIndex = 129;
            label9.Text = "Ghi chu:";
            // 
            // textBoxTenCongTy
            // 
            textBoxTenCongTy.Enabled = false;
            textBoxTenCongTy.Location = new Point(1027, 376);
            textBoxTenCongTy.Name = "textBoxTenCongTy";
            textBoxTenCongTy.Size = new Size(200, 27);
            textBoxTenCongTy.TabIndex = 128;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(850, 379);
            label8.Name = "label8";
            label8.Size = new Size(87, 20);
            label8.TabIndex = 127;
            label8.Text = "Ten Cong ty";
            // 
            // textBoxDienThoai
            // 
            textBoxDienThoai.Location = new Point(497, 262);
            textBoxDienThoai.Name = "textBoxDienThoai";
            textBoxDienThoai.Size = new Size(200, 27);
            textBoxDienThoai.TabIndex = 126;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(353, 262);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 125;
            label6.Text = "Dien Thoai";
            // 
            // textBoxDiaChi
            // 
            textBoxDiaChi.Location = new Point(1027, 200);
            textBoxDiaChi.Multiline = true;
            textBoxDiaChi.Name = "textBoxDiaChi";
            textBoxDiaChi.ScrollBars = ScrollBars.Vertical;
            textBoxDiaChi.Size = new Size(200, 67);
            textBoxDiaChi.TabIndex = 124;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(850, 203);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 123;
            label5.Text = "Dia chi";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(850, 159);
            label4.Name = "label4";
            label4.Size = new Size(118, 20);
            label4.TabIndex = 122;
            label4.Text = "Loai Khach hang";
            // 
            // textBoxTenKH
            // 
            textBoxTenKH.Location = new Point(497, 156);
            textBoxTenKH.Name = "textBoxTenKH";
            textBoxTenKH.Size = new Size(200, 27);
            textBoxTenKH.TabIndex = 121;
            // 
            // textBoxCCCD
            // 
            textBoxCCCD.Location = new Point(497, 372);
            textBoxCCCD.Name = "textBoxCCCD";
            textBoxCCCD.Size = new Size(200, 27);
            textBoxCCCD.TabIndex = 120;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(353, 379);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 119;
            label3.Text = "So CCCD/CMND";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(353, 207);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 118;
            label2.Text = "Ngay sinh";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(353, 156);
            label.Name = "label";
            label.Size = new Size(79, 20);
            label.TabIndex = 117;
            label.Text = "Ten Khach:";
            // 
            // pictureBoxKhachHang
            // 
            pictureBoxKhachHang.Location = new Point(12, 108);
            pictureBoxKhachHang.Name = "pictureBoxKhachHang";
            pictureBoxKhachHang.Size = new Size(235, 215);
            pictureBoxKhachHang.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxKhachHang.TabIndex = 116;
            pictureBoxKhachHang.TabStop = false;
            // 
            // labelMaKH
            // 
            labelMaKH.AutoSize = true;
            labelMaKH.Location = new Point(353, 108);
            labelMaKH.Name = "labelMaKH";
            labelMaKH.Size = new Size(111, 20);
            labelMaKH.TabIndex = 108;
            labelMaKH.Text = "Ma Khach hang";
            // 
            // textBoxMaKH
            // 
            textBoxMaKH.Location = new Point(497, 101);
            textBoxMaKH.Name = "textBoxMaKH";
            textBoxMaKH.ReadOnly = true;
            textBoxMaKH.Size = new Size(200, 27);
            textBoxMaKH.TabIndex = 109;
            // 
            // textBoxCHinh
            // 
            textBoxCHinh.BackColor = SystemColors.Control;
            textBoxCHinh.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            textBoxCHinh.ForeColor = SystemColors.MenuHighlight;
            textBoxCHinh.Location = new Point(12, 12);
            textBoxCHinh.Name = "textBoxCHinh";
            textBoxCHinh.ReadOnly = true;
            textBoxCHinh.Size = new Size(321, 43);
            textBoxCHinh.TabIndex = 110;
            textBoxCHinh.Text = "THEM KHACH HANG";
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.Location = new Point(353, 426);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(46, 20);
            labelDonViTinh.TabIndex = 111;
            labelDonViTinh.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(497, 423);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(200, 27);
            textBoxEmail.TabIndex = 112;
            // 
            // labelGia
            // 
            labelGia.AutoSize = true;
            labelGia.Location = new Point(353, 322);
            labelGia.Name = "labelGia";
            labelGia.Size = new Size(85, 20);
            labelGia.TabIndex = 113;
            labelGia.Text = "Ma so Thue";
            // 
            // textBoxMaSoThue
            // 
            textBoxMaSoThue.Location = new Point(497, 319);
            textBoxMaSoThue.Name = "textBoxMaSoThue";
            textBoxMaSoThue.Size = new Size(200, 27);
            textBoxMaSoThue.TabIndex = 114;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Location = new Point(1268, 499);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(75, 32);
            buttonBoQua.TabIndex = 115;
            buttonBoQua.Text = "Bo qua";
            buttonBoQua.Click += buttonBoQua_Click;
            // 
            // FormSuaKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1367, 543);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(buttonThemAnh);
            Controls.Add(buttonLuu);
            Controls.Add(dateTimePicker1);
            Controls.Add(label1);
            Controls.Add(textBoxGhiChu);
            Controls.Add(label9);
            Controls.Add(textBoxTenCongTy);
            Controls.Add(label8);
            Controls.Add(textBoxDienThoai);
            Controls.Add(label6);
            Controls.Add(textBoxDiaChi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxTenKH);
            Controls.Add(textBoxCCCD);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label);
            Controls.Add(pictureBoxKhachHang);
            Controls.Add(labelMaKH);
            Controls.Add(textBoxMaKH);
            Controls.Add(textBoxCHinh);
            Controls.Add(labelDonViTinh);
            Controls.Add(textBoxEmail);
            Controls.Add(labelGia);
            Controls.Add(textBoxMaSoThue);
            Controls.Add(buttonBoQua);
            Name = "FormSuaKhachHang";
            Text = "FormSuaKhachHang";
            Load += FormSuaKhachHang_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxKhachHang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private RadioButton radioButtonCongTy;
        private RadioButton radioButtonCaNhan;
        private RadioButton radioButtonNu;
        private GroupBox groupBox1;
        private RadioButton radioButtonNam;
        private Button buttonThemAnh;
        private Button buttonLuu;
        private DateTimePicker dateTimePicker1;
        private Label label1;
        private TextBox textBoxGhiChu;
        private Label label9;
        private TextBox textBoxTenCongTy;
        private Label label8;
        private TextBox textBoxDienThoai;
        private Label label6;
        private TextBox textBoxDiaChi;
        private Label label5;
        private Label label4;
        private TextBox textBoxTenKH;
        private TextBox textBoxCCCD;
        private Label label3;
        private Label label2;
        private Label label;
        private PictureBox pictureBoxKhachHang;
        private Label labelMaKH;
        private TextBox textBoxMaKH;
        private TextBox textBoxCHinh;
        private Label labelDonViTinh;
        private TextBox textBoxEmail;
        private Label labelGia;
        private TextBox textBoxMaSoThue;
        private Button buttonBoQua;
    }
}