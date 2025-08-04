namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class FormThemBangGia
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
            panel1 = new Panel();
            tabControlThemBangGia = new TabControl();
            tabPageThongTin = new TabPage();
            dateTimePickerDenNgay = new DateTimePicker();
            dateTimePickerTuNgay = new DateTimePicker();
            radioButtonChuaApDung = new RadioButton();
            radioButtonApDung = new RadioButton();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBoxTenBangGia = new TextBox();
            tabPageThietLap = new TabPage();
            radioButtonKhongChoPhep = new RadioButton();
            radioButtonChonPhep = new RadioButton();
            label6 = new Label();
            buttonPhanTram = new Button();
            buttonVND = new Button();
            textBoxSoNhap = new TextBox();
            buttonTru = new Button();
            buttonCong = new Button();
            comboBoxLoaiGia = new ComboBox();
            labelHienThi = new Label();
            buttonBoQua = new Button();
            buttonLuu = new Button();
            panel2 = new Panel();
            panel1.SuspendLayout();
            tabControlThemBangGia.SuspendLayout();
            tabPageThongTin.SuspendLayout();
            tabPageThietLap.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 0;
            label1.Text = "Thêm bảng giá";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Microsoft Sans Serif", 10.2F);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 50);
            panel1.TabIndex = 1;
            // 
            // tabControlThemBangGia
            // 
            tabControlThemBangGia.Controls.Add(tabPageThongTin);
            tabControlThemBangGia.Controls.Add(tabPageThietLap);
            tabControlThemBangGia.Dock = DockStyle.Fill;
            tabControlThemBangGia.Font = new Font("Segoe UI", 10F);
            tabControlThemBangGia.Location = new Point(0, 50);
            tabControlThemBangGia.Name = "tabControlThemBangGia";
            tabControlThemBangGia.SelectedIndex = 0;
            tabControlThemBangGia.Size = new Size(886, 370);
            tabControlThemBangGia.TabIndex = 2;
            // 
            // tabPageThongTin
            // 
            tabPageThongTin.Controls.Add(dateTimePickerDenNgay);
            tabPageThongTin.Controls.Add(dateTimePickerTuNgay);
            tabPageThongTin.Controls.Add(radioButtonChuaApDung);
            tabPageThongTin.Controls.Add(radioButtonApDung);
            tabPageThongTin.Controls.Add(label5);
            tabPageThongTin.Controls.Add(label4);
            tabPageThongTin.Controls.Add(label3);
            tabPageThongTin.Controls.Add(label2);
            tabPageThongTin.Controls.Add(textBoxTenBangGia);
            tabPageThongTin.Font = new Font("Segoe UI", 10F);
            tabPageThongTin.Location = new Point(4, 32);
            tabPageThongTin.Name = "tabPageThongTin";
            tabPageThongTin.Padding = new Padding(3);
            tabPageThongTin.Size = new Size(878, 334);
            tabPageThongTin.TabIndex = 0;
            tabPageThongTin.Text = "Thông tin";
            tabPageThongTin.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerDenNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerDenNgay.Location = new Point(525, 105);
            dateTimePickerDenNgay.MaxDate = new DateTime(2099, 6, 16, 14, 59, 0, 0);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(259, 30);
            dateTimePickerDenNgay.TabIndex = 134;
            dateTimePickerDenNgay.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            dateTimePickerDenNgay.ValueChanged += dateTimePickerDenNgay_ValueChanged;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerTuNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerTuNgay.Location = new Point(161, 106);
            dateTimePickerTuNgay.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(242, 30);
            dateTimePickerTuNgay.TabIndex = 133;
            dateTimePickerTuNgay.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            // 
            // radioButtonChuaApDung
            // 
            radioButtonChuaApDung.AutoSize = true;
            radioButtonChuaApDung.Font = new Font("Segoe UI", 10F);
            radioButtonChuaApDung.Location = new Point(318, 179);
            radioButtonChuaApDung.Name = "radioButtonChuaApDung";
            radioButtonChuaApDung.Size = new Size(140, 27);
            radioButtonChuaApDung.TabIndex = 7;
            radioButtonChuaApDung.TabStop = true;
            radioButtonChuaApDung.Text = "Chưa áp dụng";
            radioButtonChuaApDung.UseVisualStyleBackColor = true;
            // 
            // radioButtonApDung
            // 
            radioButtonApDung.AutoSize = true;
            radioButtonApDung.Font = new Font("Segoe UI", 10F);
            radioButtonApDung.Location = new Point(161, 179);
            radioButtonApDung.Name = "radioButtonApDung";
            radioButtonApDung.Size = new Size(97, 27);
            radioButtonApDung.TabIndex = 6;
            radioButtonApDung.TabStop = true;
            radioButtonApDung.Text = "Áp dụng";
            radioButtonApDung.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(9, 179);
            label5.Name = "label5";
            label5.Size = new Size(92, 23);
            label5.TabIndex = 5;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(9, 112);
            label4.Name = "label4";
            label4.Size = new Size(143, 23);
            label4.TabIndex = 4;
            label4.Text = "Hiệu lực từ ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(409, 110);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 3;
            label3.Text = "Đến ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(9, 49);
            label2.Name = "label2";
            label2.Size = new Size(113, 23);
            label2.TabIndex = 1;
            label2.Text = "Tên bảng giá";
            // 
            // textBoxTenBangGia
            // 
            textBoxTenBangGia.Font = new Font("Segoe UI", 10F);
            textBoxTenBangGia.Location = new Point(161, 42);
            textBoxTenBangGia.Name = "textBoxTenBangGia";
            textBoxTenBangGia.Size = new Size(623, 30);
            textBoxTenBangGia.TabIndex = 0;
            // 
            // tabPageThietLap
            // 
            tabPageThietLap.Controls.Add(radioButtonKhongChoPhep);
            tabPageThietLap.Controls.Add(radioButtonChonPhep);
            tabPageThietLap.Controls.Add(label6);
            tabPageThietLap.Controls.Add(buttonPhanTram);
            tabPageThietLap.Controls.Add(buttonVND);
            tabPageThietLap.Controls.Add(textBoxSoNhap);
            tabPageThietLap.Controls.Add(buttonTru);
            tabPageThietLap.Controls.Add(buttonCong);
            tabPageThietLap.Controls.Add(comboBoxLoaiGia);
            tabPageThietLap.Controls.Add(labelHienThi);
            tabPageThietLap.Font = new Font("Segoe UI", 10F);
            tabPageThietLap.Location = new Point(4, 32);
            tabPageThietLap.Name = "tabPageThietLap";
            tabPageThietLap.Padding = new Padding(3);
            tabPageThietLap.Size = new Size(878, 334);
            tabPageThietLap.TabIndex = 1;
            tabPageThietLap.Text = "Thiết lập";
            tabPageThietLap.UseVisualStyleBackColor = true;
            // 
            // radioButtonKhongChoPhep
            // 
            radioButtonKhongChoPhep.AutoSize = true;
            radioButtonKhongChoPhep.Font = new Font("Segoe UI", 10F);
            radioButtonKhongChoPhep.Location = new Point(84, 194);
            radioButtonKhongChoPhep.Name = "radioButtonKhongChoPhep";
            radioButtonKhongChoPhep.Size = new Size(399, 27);
            radioButtonKhongChoPhep.TabIndex = 17;
            radioButtonKhongChoPhep.TabStop = true;
            radioButtonKhongChoPhep.Text = "Không cho phép chọn hành hóa ngoài bảng giá";
            radioButtonKhongChoPhep.UseVisualStyleBackColor = true;
            // 
            // radioButtonChonPhep
            // 
            radioButtonChonPhep.AutoSize = true;
            radioButtonChonPhep.Font = new Font("Segoe UI", 10F);
            radioButtonChonPhep.Location = new Point(84, 151);
            radioButtonChonPhep.Name = "radioButtonChonPhep";
            radioButtonChonPhep.Size = new Size(347, 27);
            radioButtonChonPhep.TabIndex = 16;
            radioButtonChonPhep.TabStop = true;
            radioButtonChonPhep.Text = "Cho phép chọn hàng hóa ngoài bảng giá";
            radioButtonChonPhep.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(75, 110);
            label6.Name = "label6";
            label6.Size = new Size(328, 23);
            label6.TabIndex = 15;
            label6.Text = "Chọn hàng hóa trên màn hình bán hàng";
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Font = new Font("Segoe UI", 10F);
            buttonPhanTram.Location = new Point(700, 34);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(43, 30);
            buttonPhanTram.TabIndex = 14;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += buttonPhanTram_Click;
            // 
            // buttonVND
            // 
            buttonVND.Font = new Font("Segoe UI", 10F);
            buttonVND.Location = new Point(630, 34);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(54, 30);
            buttonVND.TabIndex = 13;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += buttonVND_Click;
            // 
            // textBoxSoNhap
            // 
            textBoxSoNhap.Font = new Font("Segoe UI", 10F);
            textBoxSoNhap.Location = new Point(477, 34);
            textBoxSoNhap.Name = "textBoxSoNhap";
            textBoxSoNhap.Size = new Size(136, 30);
            textBoxSoNhap.TabIndex = 12;
            textBoxSoNhap.TextChanged += textBoxSoNhap_TextChanged;
            // 
            // buttonTru
            // 
            buttonTru.Font = new Font("Segoe UI", 10F);
            buttonTru.Location = new Point(415, 33);
            buttonTru.Name = "buttonTru";
            buttonTru.Size = new Size(34, 28);
            buttonTru.TabIndex = 11;
            buttonTru.Text = "-";
            buttonTru.UseVisualStyleBackColor = true;
            buttonTru.Click += buttonTru_Click;
            // 
            // buttonCong
            // 
            buttonCong.Font = new Font("Segoe UI", 10F);
            buttonCong.Location = new Point(373, 33);
            buttonCong.Name = "buttonCong";
            buttonCong.Size = new Size(36, 28);
            buttonCong.TabIndex = 10;
            buttonCong.Text = "+";
            buttonCong.UseVisualStyleBackColor = true;
            buttonCong.Click += buttonCong_Click;
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiGia.Font = new Font("Segoe UI", 10F);
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(189, 33);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(168, 31);
            comboBoxLoaiGia.TabIndex = 9;
            // 
            // labelHienThi
            // 
            labelHienThi.AutoSize = true;
            labelHienThi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelHienThi.Location = new Point(75, 37);
            labelHienThi.Name = "labelHienThi";
            labelHienThi.Size = new Size(88, 23);
            labelHienThi.TabIndex = 8;
            labelHienThi.Text = "Giá bán =";
            // 
            // buttonBoQua
            // 
            buttonBoQua.Font = new Font("Segoe UI", 10F);
            buttonBoQua.Location = new Point(731, 8);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(94, 43);
            buttonBoQua.TabIndex = 9;
            buttonBoQua.Text = "Bỏ qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            buttonBoQua.Click += buttonBoQua_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Font = new Font("Segoe UI", 10F);
            buttonLuu.Location = new Point(622, 6);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 45);
            buttonLuu.TabIndex = 8;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonLuu);
            panel2.Controls.Add(buttonBoQua);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 362);
            panel2.Name = "panel2";
            panel2.Size = new Size(886, 58);
            panel2.TabIndex = 3;
            // 
            // FormThemBangGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 420);
            Controls.Add(panel2);
            Controls.Add(tabControlThemBangGia);
            Controls.Add(panel1);
            Name = "FormThemBangGia";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormThemBangGia";
            Load += FormThemBangGia_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControlThemBangGia.ResumeLayout(false);
            tabPageThongTin.ResumeLayout(false);
            tabPageThongTin.PerformLayout();
            tabPageThietLap.ResumeLayout(false);
            tabPageThietLap.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TabControl tabControlThemBangGia;
        private TabPage tabPageThongTin;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxTenBangGia;
        private TabPage tabPageThietLap;
        private RadioButton radioButtonChuaApDung;
        private RadioButton radioButtonApDung;
        private Label label5;
        private Button buttonBoQua;
        private Button buttonLuu;
        private Button buttonPhanTram;
        private Button buttonVND;
        private TextBox textBoxSoNhap;
        private Button buttonTru;
        private Button buttonCong;
        private ComboBox comboBoxLoaiGia;
        private Label labelHienThi;
        private Label label6;
        private RadioButton radioButtonKhongChoPhep;
        private RadioButton radioButtonChonPhep;
        private DateTimePicker dateTimePickerDenNgay;
        private DateTimePicker dateTimePickerTuNgay;
        private Panel panel2;
    }
}