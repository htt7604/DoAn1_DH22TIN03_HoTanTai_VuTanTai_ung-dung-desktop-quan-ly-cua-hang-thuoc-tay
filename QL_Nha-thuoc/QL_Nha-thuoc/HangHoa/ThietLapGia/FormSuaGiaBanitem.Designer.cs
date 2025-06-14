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
            labelHienThi.Location = new Point(14, 53);
            labelHienThi.Name = "labelHienThi";
            labelHienThi.Size = new Size(133, 20);
            labelHienThi.TabIndex = 0;
            labelHienThi.Text = "Gia moi [ 00000 ]=";
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(230, 49);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(151, 28);
            comboBoxLoaiGia.TabIndex = 1;
            comboBoxLoaiGia.SelectedIndexChanged += comboBoxLoaiGia_SelectedIndexChanged;
            // 
            // buttonCong
            // 
            buttonCong.Location = new Point(397, 49);
            buttonCong.Name = "buttonCong";
            buttonCong.Size = new Size(36, 29);
            buttonCong.TabIndex = 2;
            buttonCong.Text = "+";
            buttonCong.UseVisualStyleBackColor = true;
            buttonCong.Click += btnCong_Click;
            // 
            // buttonTru
            // 
            buttonTru.Location = new Point(439, 49);
            buttonTru.Name = "buttonTru";
            buttonTru.Size = new Size(34, 29);
            buttonTru.TabIndex = 3;
            buttonTru.Text = "-";
            buttonTru.UseVisualStyleBackColor = true;
            buttonTru.Click += btnTru_Click;
            // 
            // textBoxSoNhap
            // 
            textBoxSoNhap.Location = new Point(512, 50);
            textBoxSoNhap.Name = "textBoxSoNhap";
            textBoxSoNhap.Size = new Size(125, 27);
            textBoxSoNhap.TabIndex = 5;
            textBoxSoNhap.Click += textBoxSoNhap_Click;
            textBoxSoNhap.TextChanged += textBoxSoNhap_TextChanged;
            textBoxSoNhap.KeyPress += textBoxSoNhap_KeyPress;
            // 
            // buttonVND
            // 
            buttonVND.Location = new Point(654, 50);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(54, 29);
            buttonVND.TabIndex = 6;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += btnVND_Click;
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Location = new Point(724, 50);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(34, 29);
            buttonPhanTram.TabIndex = 7;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += btnPhanTram_Click;
            // 
            // buttonDongY
            // 
            buttonDongY.Location = new Point(634, 198);
            buttonDongY.Name = "buttonDongY";
            buttonDongY.Size = new Size(74, 29);
            buttonDongY.TabIndex = 8;
            buttonDongY.Text = "Dong y";
            buttonDongY.UseVisualStyleBackColor = true;
            buttonDongY.Click += buttonDongY_Click;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Location = new Point(746, 198);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(90, 29);
            buttonBoQua.TabIndex = 9;
            buttonBoQua.Text = "Bo qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            // 
            // checkBoxApDungAll
            // 
            checkBoxApDungAll.AutoSize = true;
            checkBoxApDungAll.Location = new Point(113, 161);
            checkBoxApDungAll.Name = "checkBoxApDungAll";
            checkBoxApDungAll.Size = new Size(234, 24);
            checkBoxApDungAll.TabIndex = 10;
            checkBoxApDungAll.Text = "Ap dung cho tat ca hang hoa ?";
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
            Text = "FormSuaGiaBanitem";
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