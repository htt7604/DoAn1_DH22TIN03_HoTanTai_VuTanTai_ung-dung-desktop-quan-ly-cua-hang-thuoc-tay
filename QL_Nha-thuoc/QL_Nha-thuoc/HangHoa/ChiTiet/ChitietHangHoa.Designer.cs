namespace QL_Nha_thuoc.HangHoa
{
    partial class ChitietHangHoa
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
        /// 
        private System.Windows.Forms.Label labelMaHH;
        private System.Windows.Forms.TextBox textBoxMaHH;
        private System.Windows.Forms.TextBox textBoxTenHH;
        private System.Windows.Forms.Label labelDonViTinh;
        private System.Windows.Forms.TextBox textBoxDonViTinh;
        private System.Windows.Forms.Label labelGia;
        private System.Windows.Forms.TextBox textBoxGiaVon;
        private System.Windows.Forms.Button buttonDong;

        private void InitializeComponent()
        {
            labelMaHH = new Label();
            textBoxMaHH = new TextBox();
            textBoxTenHH = new TextBox();
            labelDonViTinh = new Label();
            textBoxDonViTinh = new TextBox();
            labelGia = new Label();
            textBoxGiaVon = new TextBox();
            buttonDong = new Button();
            buttonCapNhat = new Button();
            buttonXoa = new Button();
            pictureBoxHangHoa = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxGiaBan = new TextBox();
            textBoxNhomHang = new TextBox();
            textBoxMaVach = new TextBox();
            textBoxLoaiHang = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBoxQuyCachDongGoi = new TextBox();
            label6 = new Label();
            textBoxHangSanXuat = new TextBox();
            label7 = new Label();
            label8 = new Label();
            textBoxNhaCungCap = new TextBox();
            label9 = new Label();
            textBoxGhiChu = new TextBox();
            dateTimePickerNgayHetHan = new DateTimePicker();
            buttonNgungKinhDoanh = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHangHoa).BeginInit();
            SuspendLayout();
            // 
            // labelMaHH
            // 
            labelMaHH.AutoSize = true;
            labelMaHH.Location = new Point(409, 120);
            labelMaHH.Name = "labelMaHH";
            labelMaHH.Size = new Size(70, 20);
            labelMaHH.TabIndex = 0;
            labelMaHH.Text = "Mã hàng:";
            // 
            // textBoxMaHH
            // 
            textBoxMaHH.Location = new Point(515, 113);
            textBoxMaHH.Name = "textBoxMaHH";
            textBoxMaHH.ReadOnly = true;
            textBoxMaHH.Size = new Size(200, 27);
            textBoxMaHH.TabIndex = 1;
            // 
            // textBoxTenHH
            // 
            textBoxTenHH.BackColor = SystemColors.Control;
            textBoxTenHH.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            textBoxTenHH.ForeColor = SystemColors.MenuHighlight;
            textBoxTenHH.Location = new Point(30, 24);
            textBoxTenHH.Name = "textBoxTenHH";
            textBoxTenHH.ReadOnly = true;
            textBoxTenHH.Size = new Size(321, 43);
            textBoxTenHH.TabIndex = 3;
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.Location = new Point(409, 438);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(84, 20);
            labelDonViTinh.TabIndex = 4;
            labelDonViTinh.Text = "Đơn vị tính:";
            // 
            // textBoxDonViTinh
            // 
            textBoxDonViTinh.Location = new Point(515, 435);
            textBoxDonViTinh.Name = "textBoxDonViTinh";
            textBoxDonViTinh.ReadOnly = true;
            textBoxDonViTinh.Size = new Size(200, 27);
            textBoxDonViTinh.TabIndex = 5;
            // 
            // labelGia
            // 
            labelGia.AutoSize = true;
            labelGia.Location = new Point(409, 334);
            labelGia.Name = "labelGia";
            labelGia.Size = new Size(62, 20);
            labelGia.TabIndex = 6;
            labelGia.Text = "Giá von:";
            // 
            // textBoxGiaVon
            // 
            textBoxGiaVon.Location = new Point(515, 331);
            textBoxGiaVon.Name = "textBoxGiaVon";
            textBoxGiaVon.ReadOnly = true;
            textBoxGiaVon.Size = new Size(200, 27);
            textBoxGiaVon.TabIndex = 7;
            // 
            // buttonDong
            // 
            buttonDong.Location = new Point(1286, 511);
            buttonDong.Name = "buttonDong";
            buttonDong.Size = new Size(75, 32);
            buttonDong.TabIndex = 8;
            buttonDong.Text = "Đóng";
            buttonDong.Click += buttonDong_Click;
            // 
            // buttonCapNhat
            // 
            buttonCapNhat.Location = new Point(793, 511);
            buttonCapNhat.Name = "buttonCapNhat";
            buttonCapNhat.Size = new Size(116, 32);
            buttonCapNhat.TabIndex = 9;
            buttonCapNhat.Text = "Cap Nhat";
            buttonCapNhat.Click += buttonCapNhat_Click;
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(1170, 511);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(75, 32);
            buttonXoa.TabIndex = 10;
            buttonXoa.Text = "Xoa";
            buttonXoa.Click += buttonXoa_Click;
            // 
            // pictureBoxHangHoa
            // 
            pictureBoxHangHoa.Location = new Point(30, 120);
            pictureBoxHangHoa.Name = "pictureBoxHangHoa";
            pictureBoxHangHoa.Size = new Size(321, 338);
            pictureBoxHangHoa.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHangHoa.TabIndex = 11;
            pictureBoxHangHoa.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(409, 168);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 12;
            label1.Text = "Mã vach:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(409, 219);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 13;
            label2.Text = "Nhom hang:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(409, 391);
            label3.Name = "label3";
            label3.Size = new Size(63, 20);
            label3.TabIndex = 14;
            label3.Text = "Giá ban:";
            // 
            // textBoxGiaBan
            // 
            textBoxGiaBan.Location = new Point(515, 384);
            textBoxGiaBan.Name = "textBoxGiaBan";
            textBoxGiaBan.ReadOnly = true;
            textBoxGiaBan.Size = new Size(200, 27);
            textBoxGiaBan.TabIndex = 15;
            // 
            // textBoxNhomHang
            // 
            textBoxNhomHang.Location = new Point(515, 212);
            textBoxNhomHang.Name = "textBoxNhomHang";
            textBoxNhomHang.ReadOnly = true;
            textBoxNhomHang.Size = new Size(200, 27);
            textBoxNhomHang.TabIndex = 16;
            // 
            // textBoxMaVach
            // 
            textBoxMaVach.Location = new Point(515, 168);
            textBoxMaVach.Name = "textBoxMaVach";
            textBoxMaVach.ReadOnly = true;
            textBoxMaVach.Size = new Size(200, 27);
            textBoxMaVach.TabIndex = 17;
            // 
            // textBoxLoaiHang
            // 
            textBoxLoaiHang.Location = new Point(515, 274);
            textBoxLoaiHang.Name = "textBoxLoaiHang";
            textBoxLoaiHang.ReadOnly = true;
            textBoxLoaiHang.Size = new Size(200, 27);
            textBoxLoaiHang.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(409, 281);
            label4.Name = "label4";
            label4.Size = new Size(77, 20);
            label4.TabIndex = 19;
            label4.Text = "Loai hang:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(868, 195);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 20;
            label5.Text = "Quy cach dong goi:";
            // 
            // textBoxQuyCachDongGoi
            // 
            textBoxQuyCachDongGoi.Location = new Point(1045, 188);
            textBoxQuyCachDongGoi.Name = "textBoxQuyCachDongGoi";
            textBoxQuyCachDongGoi.ReadOnly = true;
            textBoxQuyCachDongGoi.Size = new Size(200, 27);
            textBoxQuyCachDongGoi.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(868, 120);
            label6.Name = "label6";
            label6.Size = new Size(106, 20);
            label6.TabIndex = 22;
            label6.Text = "Hang san xuat:";
            // 
            // textBoxHangSanXuat
            // 
            textBoxHangSanXuat.Location = new Point(1045, 117);
            textBoxHangSanXuat.Name = "textBoxHangSanXuat";
            textBoxHangSanXuat.ReadOnly = true;
            textBoxHangSanXuat.Size = new Size(200, 27);
            textBoxHangSanXuat.TabIndex = 23;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(868, 442);
            label7.Name = "label7";
            label7.Size = new Size(100, 20);
            label7.TabIndex = 24;
            label7.Text = "Ngay het han:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(868, 391);
            label8.Name = "label8";
            label8.Size = new Size(103, 20);
            label8.TabIndex = 26;
            label8.Text = "Nha cung cap:";
            // 
            // textBoxNhaCungCap
            // 
            textBoxNhaCungCap.Location = new Point(1045, 388);
            textBoxNhaCungCap.Name = "textBoxNhaCungCap";
            textBoxNhaCungCap.ReadOnly = true;
            textBoxNhaCungCap.Size = new Size(200, 27);
            textBoxNhaCungCap.TabIndex = 27;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(868, 274);
            label9.Name = "label9";
            label9.Size = new Size(61, 20);
            label9.TabIndex = 28;
            label9.Text = "Ghi chu:";
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Location = new Point(1045, 250);
            textBoxGhiChu.Multiline = true;
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.ScrollBars = ScrollBars.Vertical;
            textBoxGhiChu.Size = new Size(200, 108);
            textBoxGhiChu.TabIndex = 29;
            // 
            // dateTimePickerNgayHetHan
            // 
            dateTimePickerNgayHetHan.Location = new Point(1045, 438);
            dateTimePickerNgayHetHan.Name = "dateTimePickerNgayHetHan";
            dateTimePickerNgayHetHan.Size = new Size(265, 27);
            dateTimePickerNgayHetHan.TabIndex = 30;
            // 
            // buttonNgungKinhDoanh
            // 
            buttonNgungKinhDoanh.Location = new Point(958, 511);
            buttonNgungKinhDoanh.Name = "buttonNgungKinhDoanh";
            buttonNgungKinhDoanh.Size = new Size(167, 32);
            buttonNgungKinhDoanh.TabIndex = 33;
            buttonNgungKinhDoanh.Text = "Ngung kinh doanh";
            buttonNgungKinhDoanh.Click += buttonNgungKinhDoanh_Click;
            // 
            // ChitietHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(1373, 556);
            Controls.Add(buttonNgungKinhDoanh);
            Controls.Add(dateTimePickerNgayHetHan);
            Controls.Add(textBoxGhiChu);
            Controls.Add(label9);
            Controls.Add(textBoxNhaCungCap);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBoxHangSanXuat);
            Controls.Add(label6);
            Controls.Add(textBoxQuyCachDongGoi);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(textBoxLoaiHang);
            Controls.Add(textBoxMaVach);
            Controls.Add(textBoxNhomHang);
            Controls.Add(textBoxGiaBan);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBoxHangHoa);
            Controls.Add(buttonXoa);
            Controls.Add(buttonCapNhat);
            Controls.Add(labelMaHH);
            Controls.Add(textBoxMaHH);
            Controls.Add(textBoxTenHH);
            Controls.Add(labelDonViTinh);
            Controls.Add(textBoxDonViTinh);
            Controls.Add(labelGia);
            Controls.Add(textBoxGiaVon);
            Controls.Add(buttonDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ChitietHangHoa";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chi tiết Hàng Hóa";
            ((System.ComponentModel.ISupportInitialize)pictureBoxHangHoa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Button buttonCapNhat;
        private Button buttonXoa;
        private PictureBox pictureBoxHangHoa;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxQuyCachDongGoi;
        private TextBox textBoxHangSanXuat;
        private TextBox textBoxLoaiHang;
        private TextBox textBoxGiaBan;
        private TextBox textBoxNhomHang;
        private TextBox textBoxMaVach;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox textBoxNhaCungCap;
        private Label label9;
        private TextBox textBoxGhiChu;
        private DateTimePicker dateTimePickerNgayHetHan;
        private Button buttonNgungKinhDoanh;
    }
}