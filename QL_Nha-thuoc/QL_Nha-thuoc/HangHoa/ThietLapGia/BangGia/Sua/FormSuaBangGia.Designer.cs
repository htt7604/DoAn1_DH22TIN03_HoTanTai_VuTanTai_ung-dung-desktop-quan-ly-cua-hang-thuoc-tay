namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class FormSuaBangGia
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
            panel1 = new Panel();
            label1 = new Label();
            tabControl = new TabControl();
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
            panel2 = new Panel();
            buttonXoa = new Button();
            buttonBoQua = new Button();
            buttonLuu = new Button();
            panel1.SuspendLayout();
            tabControl.SuspendLayout();
            tabPageThongTin.SuspendLayout();
            tabPageThietLap.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Font = new Font("Microsoft Sans Serif", 10.2F);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(886, 50);
            panel1.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(116, 23);
            label1.TabIndex = 0;
            label1.Text = "Sửa bảng giá";
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPageThongTin);
            tabControl.Controls.Add(tabPageThietLap);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 50);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(886, 386);
            tabControl.TabIndex = 4;
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
            tabPageThongTin.Location = new Point(4, 29);
            tabPageThongTin.Name = "tabPageThongTin";
            tabPageThongTin.Padding = new Padding(3);
            tabPageThongTin.Size = new Size(878, 353);
            tabPageThongTin.TabIndex = 0;
            tabPageThongTin.Text = "Thông tin";
            tabPageThongTin.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerDenNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerDenNgay.Location = new Point(552, 89);
            dateTimePickerDenNgay.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(259, 27);
            dateTimePickerDenNgay.TabIndex = 145;
            dateTimePickerDenNgay.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerTuNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerTuNgay.Location = new Point(188, 90);
            dateTimePickerTuNgay.MaxDate = new DateTime(2099, 12, 31, 0, 0, 0, 0);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(242, 27);
            dateTimePickerTuNgay.TabIndex = 144;
            dateTimePickerTuNgay.Value = new DateTime(2025, 6, 16, 0, 0, 0, 0);
            // 
            // radioButtonChuaApDung
            // 
            radioButtonChuaApDung.AutoSize = true;
            radioButtonChuaApDung.Font = new Font("Segoe UI", 10F);
            radioButtonChuaApDung.Location = new Point(345, 163);
            radioButtonChuaApDung.Name = "radioButtonChuaApDung";
            radioButtonChuaApDung.Size = new Size(140, 27);
            radioButtonChuaApDung.TabIndex = 141;
            radioButtonChuaApDung.TabStop = true;
            radioButtonChuaApDung.Text = "Chưa áp dụng";
            radioButtonChuaApDung.UseVisualStyleBackColor = true;
            // 
            // radioButtonApDung
            // 
            radioButtonApDung.AutoSize = true;
            radioButtonApDung.Font = new Font("Segoe UI", 10F);
            radioButtonApDung.Location = new Point(188, 163);
            radioButtonApDung.Name = "radioButtonApDung";
            radioButtonApDung.Size = new Size(97, 27);
            radioButtonApDung.TabIndex = 140;
            radioButtonApDung.TabStop = true;
            radioButtonApDung.Text = "Áp dụng";
            radioButtonApDung.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(36, 163);
            label5.Name = "label5";
            label5.Size = new Size(92, 23);
            label5.TabIndex = 139;
            label5.Text = "Trạng thái";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(36, 96);
            label4.Name = "label4";
            label4.Size = new Size(143, 23);
            label4.TabIndex = 138;
            label4.Text = "Hiệu lực từ ngày";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(436, 94);
            label3.Name = "label3";
            label3.Size = new Size(86, 23);
            label3.TabIndex = 137;
            label3.Text = "Đến ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(36, 33);
            label2.Name = "label2";
            label2.Size = new Size(113, 23);
            label2.TabIndex = 136;
            label2.Text = "Tên bảng giá";
            // 
            // textBoxTenBangGia
            // 
            textBoxTenBangGia.Font = new Font("Segoe UI", 10F);
            textBoxTenBangGia.Location = new Point(188, 26);
            textBoxTenBangGia.Name = "textBoxTenBangGia";
            textBoxTenBangGia.Size = new Size(623, 30);
            textBoxTenBangGia.TabIndex = 135;
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
            tabPageThietLap.Location = new Point(4, 29);
            tabPageThietLap.Name = "tabPageThietLap";
            tabPageThietLap.Padding = new Padding(3);
            tabPageThietLap.Size = new Size(878, 353);
            tabPageThietLap.TabIndex = 1;
            tabPageThietLap.Text = "Thiết lập";
            tabPageThietLap.UseVisualStyleBackColor = true;
            // 
            // radioButtonKhongChoPhep
            // 
            radioButtonKhongChoPhep.AutoSize = true;
            radioButtonKhongChoPhep.Font = new Font("Segoe UI", 10F);
            radioButtonKhongChoPhep.Location = new Point(68, 180);
            radioButtonKhongChoPhep.Name = "radioButtonKhongChoPhep";
            radioButtonKhongChoPhep.Size = new Size(399, 27);
            radioButtonKhongChoPhep.TabIndex = 29;
            radioButtonKhongChoPhep.TabStop = true;
            radioButtonKhongChoPhep.Text = "Không cho phép chọn hành hóa ngoài bảng giá";
            radioButtonKhongChoPhep.UseVisualStyleBackColor = true;
            // 
            // radioButtonChonPhep
            // 
            radioButtonChonPhep.AutoSize = true;
            radioButtonChonPhep.Font = new Font("Segoe UI", 10F);
            radioButtonChonPhep.Location = new Point(68, 137);
            radioButtonChonPhep.Name = "radioButtonChonPhep";
            radioButtonChonPhep.Size = new Size(347, 27);
            radioButtonChonPhep.TabIndex = 28;
            radioButtonChonPhep.TabStop = true;
            radioButtonChonPhep.Text = "Cho phép chọn hàng hóa ngoài bảng giá";
            radioButtonChonPhep.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(59, 96);
            label6.Name = "label6";
            label6.Size = new Size(328, 23);
            label6.TabIndex = 27;
            label6.Text = "Chọn hàng hóa trên màn hình bán hàng";
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Font = new Font("Segoe UI", 10F);
            buttonPhanTram.Location = new Point(684, 20);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(43, 30);
            buttonPhanTram.TabIndex = 26;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += buttonPhanTram_Click;
            // 
            // buttonVND
            // 
            buttonVND.Font = new Font("Segoe UI", 10F);
            buttonVND.Location = new Point(614, 20);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(54, 30);
            buttonVND.TabIndex = 25;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += buttonVND_Click;
            // 
            // textBoxSoNhap
            // 
            textBoxSoNhap.Font = new Font("Segoe UI", 10F);
            textBoxSoNhap.Location = new Point(461, 20);
            textBoxSoNhap.Name = "textBoxSoNhap";
            textBoxSoNhap.Size = new Size(136, 30);
            textBoxSoNhap.TabIndex = 24;
            // 
            // buttonTru
            // 
            buttonTru.Font = new Font("Segoe UI", 10F);
            buttonTru.Location = new Point(399, 19);
            buttonTru.Name = "buttonTru";
            buttonTru.Size = new Size(34, 28);
            buttonTru.TabIndex = 23;
            buttonTru.Text = "-";
            buttonTru.UseVisualStyleBackColor = true;
            buttonTru.Click += buttonTru_Click;
            // 
            // buttonCong
            // 
            buttonCong.Font = new Font("Segoe UI", 10F);
            buttonCong.Location = new Point(357, 19);
            buttonCong.Name = "buttonCong";
            buttonCong.Size = new Size(36, 28);
            buttonCong.TabIndex = 22;
            buttonCong.Text = "+";
            buttonCong.UseVisualStyleBackColor = true;
            buttonCong.Click += buttonCong_Click;
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiGia.Font = new Font("Segoe UI", 10F);
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(173, 19);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(168, 31);
            comboBoxLoaiGia.TabIndex = 21;
            // 
            // labelHienThi
            // 
            labelHienThi.AutoSize = true;
            labelHienThi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelHienThi.Location = new Point(59, 23);
            labelHienThi.Name = "labelHienThi";
            labelHienThi.Size = new Size(88, 23);
            labelHienThi.TabIndex = 20;
            labelHienThi.Text = "Giá bán =";
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonXoa);
            panel2.Controls.Add(buttonBoQua);
            panel2.Controls.Add(buttonLuu);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 361);
            panel2.Name = "panel2";
            panel2.Size = new Size(886, 75);
            panel2.TabIndex = 5;
            // 
            // buttonXoa
            // 
            buttonXoa.Font = new Font("Segoe UI", 10F);
            buttonXoa.Location = new Point(780, 15);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(94, 48);
            buttonXoa.TabIndex = 146;
            buttonXoa.Text = "Xóa";
            buttonXoa.UseVisualStyleBackColor = true;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Font = new Font("Segoe UI", 10F);
            buttonBoQua.Location = new Point(666, 15);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(94, 48);
            buttonBoQua.TabIndex = 145;
            buttonBoQua.Text = "Bỏ qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            buttonBoQua.Click += buttonBoQua_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Font = new Font("Segoe UI", 10F);
            buttonLuu.Location = new Point(536, 15);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 48);
            buttonLuu.TabIndex = 144;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // FormSuaBangGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(886, 436);
            Controls.Add(panel2);
            Controls.Add(tabControl);
            Controls.Add(panel1);
            Name = "FormSuaBangGia";
            Text = "FormSuaBangGia";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPageThongTin.ResumeLayout(false);
            tabPageThongTin.PerformLayout();
            tabPageThietLap.ResumeLayout(false);
            tabPageThietLap.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private TabControl tabControl;
        private TabPage tabPageThongTin;
        private TabPage tabPageThietLap;
        private DateTimePicker dateTimePickerDenNgay;
        private DateTimePicker dateTimePickerTuNgay;
        private RadioButton radioButtonChuaApDung;
        private RadioButton radioButtonApDung;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBoxTenBangGia;
        private RadioButton radioButtonKhongChoPhep;
        private RadioButton radioButtonChonPhep;
        private Label label6;
        private Button buttonPhanTram;
        private Button buttonVND;
        private TextBox textBoxSoNhap;
        private Button buttonTru;
        private Button buttonCong;
        private ComboBox comboBoxLoaiGia;
        private Label labelHienThi;
        private Panel panel2;
        private Button buttonXoa;
        private Button buttonBoQua;
        private Button buttonLuu;
    }
}