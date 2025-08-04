namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class FormSuaGiaBanitem
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
            labelHienThi = new Label();
            comboBoxLoaiGia = new ComboBox();
            buttonCong = new Button();
            buttonTru = new Button();
            textBoxSoNhap = new TextBox();
            buttonVND = new Button();
            buttonPhanTram = new Button();
            buttonDongY = new Button();
            buttonBoQua = new Button();
            checkBoxApDungAll = new CheckBox();
            SuspendLayout();
            // 
            // labelHienThi
            // 
            labelHienThi.AutoSize = true;
            labelHienThi.Font = new Font("Segoe UI", 11F);
            labelHienThi.Location = new Point(14, 53);
            labelHienThi.Name = "labelHienThi";
            labelHienThi.Size = new Size(167, 25);
            labelHienThi.TabIndex = 0;
            labelHienThi.Text = "Giá mới [ 00000 ]=";
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiGia.Font = new Font("Segoe UI", 11F);
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(213, 49);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(168, 33);
            comboBoxLoaiGia.TabIndex = 1;
            comboBoxLoaiGia.SelectedIndexChanged += comboBoxLoaiGia_SelectedIndexChanged;
            // 
            // buttonCong
            // 
            buttonCong.Font = new Font("Segoe UI", 11F);
            buttonCong.Location = new Point(397, 49);
            buttonCong.Name = "buttonCong";
            buttonCong.Size = new Size(36, 33);
            buttonCong.TabIndex = 2;
            buttonCong.Text = "+";
            buttonCong.UseVisualStyleBackColor = true;
            buttonCong.Click += btnCong_Click;
            // 
            // buttonTru
            // 
            buttonTru.Font = new Font("Segoe UI", 11F);
            buttonTru.Location = new Point(439, 49);
            buttonTru.Name = "buttonTru";
            buttonTru.Size = new Size(34, 33);
            buttonTru.TabIndex = 3;
            buttonTru.Text = "-";
            buttonTru.UseVisualStyleBackColor = true;
            buttonTru.Click += btnTru_Click;
            // 
            // textBoxSoNhap
            // 
            textBoxSoNhap.Font = new Font("Segoe UI", 11F);
            textBoxSoNhap.Location = new Point(501, 50);
            textBoxSoNhap.Name = "textBoxSoNhap";
            textBoxSoNhap.Size = new Size(136, 32);
            textBoxSoNhap.TabIndex = 5;
            textBoxSoNhap.TextChanged += textBoxSoNhap_TextChanged;
            textBoxSoNhap.KeyPress += textBoxSoNhap_KeyPress;
            // 
            // buttonVND
            // 
            buttonVND.Font = new Font("Segoe UI", 11F);
            buttonVND.Location = new Point(654, 50);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(54, 32);
            buttonVND.TabIndex = 6;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += btnVND_Click;
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            buttonPhanTram.Location = new Point(724, 50);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(43, 32);
            buttonPhanTram.TabIndex = 7;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += btnPhanTram_Click;
            // 
            // buttonDongY
            // 
            buttonDongY.Font = new Font("Segoe UI", 11F);
            buttonDongY.Location = new Point(560, 188);
            buttonDongY.Name = "buttonDongY";
            buttonDongY.Size = new Size(129, 39);
            buttonDongY.TabIndex = 8;
            buttonDongY.Text = "Đồng ý";
            buttonDongY.UseVisualStyleBackColor = true;
            buttonDongY.Click += buttonDongY_Click;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Font = new Font("Segoe UI", 11F);
            buttonBoQua.Location = new Point(746, 188);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(111, 39);
            buttonBoQua.TabIndex = 9;
            buttonBoQua.Text = "Bỏ qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            buttonBoQua.Click += buttonBoQua_Click;
            // 
            // checkBoxApDungAll
            // 
            checkBoxApDungAll.AutoSize = true;
            checkBoxApDungAll.Font = new Font("Segoe UI", 11F);
            checkBoxApDungAll.Location = new Point(33, 138);
            checkBoxApDungAll.Name = "checkBoxApDungAll";
            checkBoxApDungAll.Size = new Size(381, 29);
            checkBoxApDungAll.TabIndex = 10;
            checkBoxApDungAll.Text = "Áp dụng công thức cho tất cả hàng hóa ?";
            checkBoxApDungAll.UseVisualStyleBackColor = true;
            // 
            // FormSuaGiaBanitem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(896, 239);
            Controls.Add(checkBoxApDungAll);
            Controls.Add(buttonBoQua);
            Controls.Add(buttonDongY);
            Controls.Add(buttonPhanTram);
            Controls.Add(buttonVND);
            Controls.Add(textBoxSoNhap);
            Controls.Add(buttonTru);
            Controls.Add(buttonCong);
            Controls.Add(comboBoxLoaiGia);
            Controls.Add(labelHienThi);
            MaximizeBox = false;
            Name = "FormSuaGiaBanitem";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Sửa giá";
            Load += FormSuaGiaBanitem_Load;
            Click += FormSuaGiaBanitem_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelHienThi;
        private ComboBox comboBoxLoaiGia;
        private Button buttonCong;
        private Button buttonTru;
        private TextBox textBoxSoNhap;
        private Button buttonVND;
        private Button buttonPhanTram;
        private Button buttonDongY;
        private Button buttonBoQua;
        private CheckBox checkBoxApDungAll;
    }
}