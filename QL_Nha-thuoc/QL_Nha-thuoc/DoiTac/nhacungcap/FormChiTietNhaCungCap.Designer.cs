namespace QL_Nha_thuoc.DoiTac.nhacungcap
{
    partial class FormChiTietNhaCungCap
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label8 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPageThongTin = new TabPage();
            buttonNgungHoatDong = new Button();
            label7 = new Label();
            textBoxMaSoThue = new TextBox();
            label6 = new Label();
            textBoxTenCongTy = new TextBox();
            buttonCapNhat = new Button();
            buttonXoa = new Button();
            label5 = new Label();
            textBoxGhiChu = new TextBox();
            label3 = new Label();
            textBoxEmail = new TextBox();
            label4 = new Label();
            textBoxDiaChi = new TextBox();
            label2 = new Label();
            textBoxSDT = new TextBox();
            label1 = new Label();
            textBoxTenNCC = new TextBox();
            labelMaKH = new Label();
            textBoxMaNCC = new TextBox();
            tabPageLichSu = new TabPage();
            dataGridViewLichSu = new DataGridView();
            ColumnMaPhieuNhap = new DataGridViewLinkColumn();
            ColumnThoiGian = new DataGridViewTextBoxColumn();
            ColumnNguoiTao = new DataGridViewTextBoxColumn();
            ColumnTongCong = new DataGridViewTextBoxColumn();
            ColumnTrangThai = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageThongTin.SuspendLayout();
            tabPageLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewLichSu).BeginInit();
            SuspendLayout();
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label8.ForeColor = Color.Blue;
            label8.Location = new Point(3, 0);
            label8.Name = "label8";
            label8.Size = new Size(182, 34);
            label8.TabIndex = 149;
            label8.Text = "Nhà cung cấp ";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 1);
            tableLayoutPanel1.Controls.Add(label8, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.448718F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.5512848F));
            tableLayoutPanel1.Size = new Size(1389, 624);
            tableLayoutPanel1.TabIndex = 150;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageThongTin);
            tabControl1.Controls.Add(tabPageLichSu);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.ItemSize = new Size(150, 30);
            tabControl1.Location = new Point(3, 37);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(7, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1383, 584);
            tabControl1.TabIndex = 151;
            // 
            // tabPageThongTin
            // 
            tabPageThongTin.BackColor = Color.Transparent;
            tabPageThongTin.BorderStyle = BorderStyle.FixedSingle;
            tabPageThongTin.Controls.Add(buttonNgungHoatDong);
            tabPageThongTin.Controls.Add(label7);
            tabPageThongTin.Controls.Add(textBoxMaSoThue);
            tabPageThongTin.Controls.Add(label6);
            tabPageThongTin.Controls.Add(textBoxTenCongTy);
            tabPageThongTin.Controls.Add(buttonCapNhat);
            tabPageThongTin.Controls.Add(buttonXoa);
            tabPageThongTin.Controls.Add(label5);
            tabPageThongTin.Controls.Add(textBoxGhiChu);
            tabPageThongTin.Controls.Add(label3);
            tabPageThongTin.Controls.Add(textBoxEmail);
            tabPageThongTin.Controls.Add(label4);
            tabPageThongTin.Controls.Add(textBoxDiaChi);
            tabPageThongTin.Controls.Add(label2);
            tabPageThongTin.Controls.Add(textBoxSDT);
            tabPageThongTin.Controls.Add(label1);
            tabPageThongTin.Controls.Add(textBoxTenNCC);
            tabPageThongTin.Controls.Add(labelMaKH);
            tabPageThongTin.Controls.Add(textBoxMaNCC);
            tabPageThongTin.ForeColor = SystemColors.WindowText;
            tabPageThongTin.Location = new Point(4, 34);
            tabPageThongTin.Name = "tabPageThongTin";
            tabPageThongTin.Padding = new Padding(3);
            tabPageThongTin.Size = new Size(1375, 546);
            tabPageThongTin.TabIndex = 0;
            tabPageThongTin.Text = "Thông tin";
            // 
            // buttonNgungHoatDong
            // 
            buttonNgungHoatDong.Font = new Font("Segoe UI", 9F);
            buttonNgungHoatDong.Location = new Point(954, 428);
            buttonNgungHoatDong.Name = "buttonNgungHoatDong";
            buttonNgungHoatDong.Size = new Size(188, 46);
            buttonNgungHoatDong.TabIndex = 169;
            buttonNgungHoatDong.Text = "Ngừng hoạt động";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(614, 201);
            label7.Name = "label7";
            label7.Size = new Size(96, 23);
            label7.TabIndex = 167;
            label7.Text = "mã số thuế";
            // 
            // textBoxMaSoThue
            // 
            textBoxMaSoThue.Font = new Font("Segoe UI", 10F);
            textBoxMaSoThue.Location = new Point(755, 191);
            textBoxMaSoThue.Name = "textBoxMaSoThue";
            textBoxMaSoThue.ReadOnly = true;
            textBoxMaSoThue.Size = new Size(296, 30);
            textBoxMaSoThue.TabIndex = 168;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(614, 132);
            label6.Name = "label6";
            label6.Size = new Size(75, 23);
            label6.TabIndex = 165;
            label6.Text = "Công ty ";
            // 
            // textBoxTenCongTy
            // 
            textBoxTenCongTy.Font = new Font("Segoe UI", 10F);
            textBoxTenCongTy.Location = new Point(755, 122);
            textBoxTenCongTy.Name = "textBoxTenCongTy";
            textBoxTenCongTy.ReadOnly = true;
            textBoxTenCongTy.Size = new Size(296, 30);
            textBoxTenCongTy.TabIndex = 166;
            // 
            // buttonCapNhat
            // 
            buttonCapNhat.Font = new Font("Segoe UI", 9F);
            buttonCapNhat.Location = new Point(804, 428);
            buttonCapNhat.Name = "buttonCapNhat";
            buttonCapNhat.Size = new Size(106, 46);
            buttonCapNhat.TabIndex = 164;
            buttonCapNhat.Text = "Cập nhật";
            // 
            // buttonXoa
            // 
            buttonXoa.Font = new Font("Segoe UI", 9F);
            buttonXoa.Location = new Point(1186, 428);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(106, 46);
            buttonXoa.TabIndex = 163;
            buttonXoa.Text = "Xóa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(614, 272);
            label5.Name = "label5";
            label5.Size = new Size(69, 23);
            label5.TabIndex = 161;
            label5.Text = "Ghi chú";
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Font = new Font("Segoe UI", 10F);
            textBoxGhiChu.Location = new Point(755, 262);
            textBoxGhiChu.Multiline = true;
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.ReadOnly = true;
            textBoxGhiChu.Size = new Size(296, 134);
            textBoxGhiChu.TabIndex = 162;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(614, 52);
            label3.Name = "label3";
            label3.Size = new Size(51, 23);
            label3.TabIndex = 159;
            label3.Text = "Email";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Font = new Font("Segoe UI", 10F);
            textBoxEmail.Location = new Point(755, 42);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.ReadOnly = true;
            textBoxEmail.Size = new Size(296, 30);
            textBoxEmail.TabIndex = 160;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(34, 272);
            label4.Name = "label4";
            label4.Size = new Size(62, 23);
            label4.TabIndex = 157;
            label4.Text = "Dia chi";
            // 
            // textBoxDiaChi
            // 
            textBoxDiaChi.Font = new Font("Segoe UI", 10F);
            textBoxDiaChi.Location = new Point(191, 262);
            textBoxDiaChi.Multiline = true;
            textBoxDiaChi.Name = "textBoxDiaChi";
            textBoxDiaChi.ReadOnly = true;
            textBoxDiaChi.Size = new Size(296, 134);
            textBoxDiaChi.TabIndex = 158;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(34, 201);
            label2.Name = "label2";
            label2.Size = new Size(39, 23);
            label2.TabIndex = 155;
            label2.Text = "SDT";
            // 
            // textBoxSDT
            // 
            textBoxSDT.Font = new Font("Segoe UI", 10F);
            textBoxSDT.Location = new Point(191, 191);
            textBoxSDT.Name = "textBoxSDT";
            textBoxSDT.ReadOnly = true;
            textBoxSDT.Size = new Size(296, 30);
            textBoxSDT.TabIndex = 156;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(34, 132);
            label1.Name = "label1";
            label1.Size = new Size(41, 23);
            label1.TabIndex = 153;
            label1.Text = "Tên ";
            // 
            // textBoxTenNCC
            // 
            textBoxTenNCC.Font = new Font("Segoe UI", 10F);
            textBoxTenNCC.Location = new Point(191, 122);
            textBoxTenNCC.Name = "textBoxTenNCC";
            textBoxTenNCC.ReadOnly = true;
            textBoxTenNCC.Size = new Size(296, 30);
            textBoxTenNCC.TabIndex = 154;
            // 
            // labelMaKH
            // 
            labelMaKH.AutoSize = true;
            labelMaKH.Font = new Font("Segoe UI", 10F);
            labelMaKH.Location = new Point(34, 52);
            labelMaKH.Name = "labelMaKH";
            labelMaKH.Size = new Size(143, 23);
            labelMaKH.TabIndex = 151;
            labelMaKH.Text = "Mã nhà cung cấp";
            // 
            // textBoxMaNCC
            // 
            textBoxMaNCC.Font = new Font("Segoe UI", 10F);
            textBoxMaNCC.Location = new Point(191, 49);
            textBoxMaNCC.Name = "textBoxMaNCC";
            textBoxMaNCC.ReadOnly = true;
            textBoxMaNCC.Size = new Size(296, 30);
            textBoxMaNCC.TabIndex = 152;
            // 
            // tabPageLichSu
            // 
            tabPageLichSu.Controls.Add(dataGridViewLichSu);
            tabPageLichSu.Location = new Point(4, 34);
            tabPageLichSu.Name = "tabPageLichSu";
            tabPageLichSu.Padding = new Padding(3);
            tabPageLichSu.Size = new Size(1375, 546);
            tabPageLichSu.TabIndex = 1;
            tabPageLichSu.Text = "Lịch sử nhập";
            tabPageLichSu.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLichSu
            // 
            dataGridViewLichSu.AllowUserToAddRows = false;
            dataGridViewLichSu.AllowUserToDeleteRows = false;
            dataGridViewLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLichSu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewLichSu.BackgroundColor = SystemColors.Window;
            dataGridViewLichSu.CausesValidation = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewLichSu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLichSu.Columns.AddRange(new DataGridViewColumn[] { ColumnMaPhieuNhap, ColumnThoiGian, ColumnNguoiTao, ColumnTongCong, ColumnTrangThai });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dataGridViewLichSu.DefaultCellStyle = dataGridViewCellStyle5;
            dataGridViewLichSu.Dock = DockStyle.Fill;
            dataGridViewLichSu.Location = new Point(3, 3);
            dataGridViewLichSu.MultiSelect = false;
            dataGridViewLichSu.Name = "dataGridViewLichSu";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewLichSu.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewLichSu.RowHeadersVisible = false;
            dataGridViewLichSu.RowHeadersWidth = 51;
            dataGridViewLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLichSu.Size = new Size(1369, 540);
            dataGridViewLichSu.TabIndex = 0;
            dataGridViewLichSu.CellContentClick += dataGridViewLichSu_CellContentClick;
            // 
            // ColumnMaPhieuNhap
            // 
            ColumnMaPhieuNhap.HeaderText = "Ma phieu";
            ColumnMaPhieuNhap.MinimumWidth = 6;
            ColumnMaPhieuNhap.Name = "ColumnMaPhieuNhap";
            ColumnMaPhieuNhap.Resizable = DataGridViewTriState.True;
            ColumnMaPhieuNhap.SortMode = DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnThoiGian
            // 
            ColumnThoiGian.HeaderText = "Thoi gian";
            ColumnThoiGian.MinimumWidth = 6;
            ColumnThoiGian.Name = "ColumnThoiGian";
            ColumnThoiGian.ReadOnly = true;
            // 
            // ColumnNguoiTao
            // 
            ColumnNguoiTao.HeaderText = "Nguoi tao";
            ColumnNguoiTao.MinimumWidth = 6;
            ColumnNguoiTao.Name = "ColumnNguoiTao";
            ColumnNguoiTao.ReadOnly = true;
            // 
            // ColumnTongCong
            // 
            ColumnTongCong.HeaderText = "Tong Cong";
            ColumnTongCong.MinimumWidth = 6;
            ColumnTongCong.Name = "ColumnTongCong";
            ColumnTongCong.ReadOnly = true;
            // 
            // ColumnTrangThai
            // 
            ColumnTrangThai.HeaderText = "Trang thai";
            ColumnTrangThai.MinimumWidth = 6;
            ColumnTrangThai.Name = "ColumnTrangThai";
            ColumnTrangThai.ReadOnly = true;
            // 
            // FormChiTietNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightYellow;
            ClientSize = new Size(1389, 624);
            Controls.Add(tableLayoutPanel1);
            MaximizeBox = false;
            Name = "FormChiTietNhaCungCap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChiTietNhaCungCap";
            Load += FormChiTietNhaCungCap_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageThongTin.ResumeLayout(false);
            tabPageThongTin.PerformLayout();
            tabPageLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewLichSu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label8;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPageThongTin;
        private Button buttonNgungHoatDong;
        private Label label7;
        private TextBox textBoxMaSoThue;
        private Label label6;
        private TextBox textBoxTenCongTy;
        private Button buttonCapNhat;
        private Button buttonXoa;
        private Label label5;
        private TextBox textBoxGhiChu;
        private Label label3;
        private TextBox textBoxEmail;
        private Label label4;
        private TextBox textBoxDiaChi;
        private Label label2;
        private TextBox textBoxSDT;
        private Label label1;
        private TextBox textBoxTenNCC;
        private Label labelMaKH;
        private TextBox textBoxMaNCC;
        private TabPage tabPageLichSu;
        private DataGridView dataGridViewLichSu;
        private DataGridViewLinkColumn ColumnMaPhieuNhap;
        private DataGridViewTextBoxColumn ColumnThoiGian;
        private DataGridViewTextBoxColumn ColumnNguoiTao;
        private DataGridViewTextBoxColumn ColumnTongCong;
        private DataGridViewTextBoxColumn ColumnTrangThai;
    }
}