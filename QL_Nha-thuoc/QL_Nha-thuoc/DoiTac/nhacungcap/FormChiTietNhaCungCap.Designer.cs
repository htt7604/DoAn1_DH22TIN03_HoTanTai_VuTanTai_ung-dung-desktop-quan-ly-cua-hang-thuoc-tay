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
            label8 = new Label();
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
            ColumnMaPhieuNhap = new DataGridViewTextBoxColumn();
            ColumnThoiGian = new DataGridViewTextBoxColumn();
            ColumnNguoiTao = new DataGridViewTextBoxColumn();
            ColumnTongCong = new DataGridViewTextBoxColumn();
            ColumnTrangThai = new DataGridViewTextBoxColumn();
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
            label8.Location = new Point(13, 11);
            label8.Name = "label8";
            label8.Size = new Size(207, 35);
            label8.TabIndex = 149;
            label8.Text = "NHA CUNG CAP";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageThongTin);
            tabControl1.Controls.Add(tabPageLichSu);
            tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabControl1.Font = new Font("Segoe UI", 10F);
            tabControl1.ItemSize = new Size(150, 30);
            tabControl1.Location = new Point(13, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(7, 3);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1364, 569);
            tabControl1.TabIndex = 150;
            tabControl1.DrawItem += tabControl1_DrawItem;
            // 
            // tabPageThongTin
            // 
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
            tabPageThongTin.Location = new Point(4, 34);
            tabPageThongTin.Name = "tabPageThongTin";
            tabPageThongTin.Padding = new Padding(3);
            tabPageThongTin.Size = new Size(1356, 531);
            tabPageThongTin.TabIndex = 0;
            tabPageThongTin.Text = "Thong tin";
            tabPageThongTin.UseVisualStyleBackColor = true;
            // 
            // buttonNgungHoatDong
            // 
            buttonNgungHoatDong.Font = new Font("Segoe UI", 9F);
            buttonNgungHoatDong.Location = new Point(954, 428);
            buttonNgungHoatDong.Name = "buttonNgungHoatDong";
            buttonNgungHoatDong.Size = new Size(188, 46);
            buttonNgungHoatDong.TabIndex = 169;
            buttonNgungHoatDong.Text = "Ngung Hoat Dong";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(611, 198);
            label7.Name = "label7";
            label7.Size = new Size(96, 23);
            label7.TabIndex = 167;
            label7.Text = "Ma so thue";
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
            label6.Location = new Point(611, 129);
            label6.Name = "label6";
            label6.Size = new Size(72, 23);
            label6.TabIndex = 165;
            label6.Text = "Cong Ty";
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
            buttonCapNhat.Text = "Cap nhat";
            // 
            // buttonXoa
            // 
            buttonXoa.Font = new Font("Segoe UI", 9F);
            buttonXoa.Location = new Point(1186, 428);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(106, 46);
            buttonXoa.TabIndex = 163;
            buttonXoa.Text = "Xoa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(611, 269);
            label5.Name = "label5";
            label5.Size = new Size(69, 23);
            label5.TabIndex = 161;
            label5.Text = "Ghi chu";
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
            label3.Location = new Point(611, 49);
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
            label4.Location = new Point(31, 269);
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
            label2.Location = new Point(31, 198);
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
            label1.Location = new Point(31, 129);
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
            labelMaKH.Location = new Point(31, 49);
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
            tabPageLichSu.Size = new Size(1356, 531);
            tabPageLichSu.TabIndex = 1;
            tabPageLichSu.Text = "Lich su Nhap/tra hang";
            tabPageLichSu.UseVisualStyleBackColor = true;
            // 
            // dataGridViewLichSu
            // 
            dataGridViewLichSu.AllowUserToAddRows = false;
            dataGridViewLichSu.AllowUserToDeleteRows = false;
            dataGridViewLichSu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewLichSu.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewLichSu.BackgroundColor = SystemColors.Window;
            dataGridViewLichSu.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewLichSu.Columns.AddRange(new DataGridViewColumn[] { ColumnMaPhieuNhap, ColumnThoiGian, ColumnNguoiTao, ColumnTongCong, ColumnTrangThai });
            dataGridViewLichSu.Dock = DockStyle.Fill;
            dataGridViewLichSu.Location = new Point(3, 3);
            dataGridViewLichSu.Name = "dataGridViewLichSu";
            dataGridViewLichSu.RowHeadersVisible = false;
            dataGridViewLichSu.RowHeadersWidth = 51;
            dataGridViewLichSu.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewLichSu.Size = new Size(1350, 525);
            dataGridViewLichSu.TabIndex = 0;
            // 
            // ColumnMaPhieuNhap
            // 
            ColumnMaPhieuNhap.HeaderText = "Ma phieu";
            ColumnMaPhieuNhap.MinimumWidth = 6;
            ColumnMaPhieuNhap.Name = "ColumnMaPhieuNhap";
            // 
            // ColumnThoiGian
            // 
            ColumnThoiGian.HeaderText = "Thoi gian";
            ColumnThoiGian.MinimumWidth = 6;
            ColumnThoiGian.Name = "ColumnThoiGian";
            // 
            // ColumnNguoiTao
            // 
            ColumnNguoiTao.HeaderText = "Nguoi tao";
            ColumnNguoiTao.MinimumWidth = 6;
            ColumnNguoiTao.Name = "ColumnNguoiTao";
            // 
            // ColumnTongCong
            // 
            ColumnTongCong.HeaderText = "Tong Cong";
            ColumnTongCong.MinimumWidth = 6;
            ColumnTongCong.Name = "ColumnTongCong";
            // 
            // ColumnTrangThai
            // 
            ColumnTrangThai.HeaderText = "Trang thai";
            ColumnTrangThai.MinimumWidth = 6;
            ColumnTrangThai.Name = "ColumnTrangThai";
            // 
            // FormChiTietNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(1389, 624);
            Controls.Add(tabControl1);
            Controls.Add(label8);
            Name = "FormChiTietNhaCungCap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChiTietNhaCungCap";
            Load += FormChiTietNhaCungCap_Load;
            tabControl1.ResumeLayout(false);
            tabPageThongTin.ResumeLayout(false);
            tabPageThongTin.PerformLayout();
            tabPageLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewLichSu).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label8;
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
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dataGridViewLichSu;
        private DataGridViewTextBoxColumn ColumnMaPhieuNhap;
        private DataGridViewTextBoxColumn ColumnThoiGian;
        private DataGridViewTextBoxColumn ColumnNguoiTao;
        private DataGridViewTextBoxColumn ColumnTongCong;
        private DataGridViewTextBoxColumn ColumnTrangThai;
    }
}