namespace QL_Nha_thuoc.GiaoDich.HoaDon
{
    partial class FormChiTietHoaDon
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
            panel3 = new Panel();
            buttonMoPhieu = new Button();
            buttonIn = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            labelKhachTra = new Label();
            labelTongTienHang = new Label();
            labelGiamGiaHoaDon = new Label();
            labelTongSoLuong = new Label();
            buttonHuyBo = new Button();
            buttonLuu = new Button();
            panel1 = new Panel();
            labelTenNguoiTao = new Label();
            labelTrangThai = new Label();
            labelBangGia = new Label();
            labelThoiGian = new Label();
            labelMaHoaDon = new Label();
            labelTenKhachHang = new Label();
            label6 = new Label();
            textBoxGhiChu = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            dataGridViewdsHoaDon = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsHoaDon).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Controls.Add(buttonMoPhieu);
            panel3.Controls.Add(buttonIn);
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Controls.Add(buttonHuyBo);
            panel3.Controls.Add(buttonLuu);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 549);
            panel3.Name = "panel3";
            panel3.Size = new Size(1108, 217);
            panel3.TabIndex = 2;
            // 
            // buttonMoPhieu
            // 
            buttonMoPhieu.Location = new Point(580, 165);
            buttonMoPhieu.Name = "buttonMoPhieu";
            buttonMoPhieu.Size = new Size(94, 43);
            buttonMoPhieu.TabIndex = 9;
            buttonMoPhieu.Text = "Mở phiếu";
            buttonMoPhieu.UseVisualStyleBackColor = true;
            buttonMoPhieu.Visible = false;
            // 
            // buttonIn
            // 
            buttonIn.Location = new Point(710, 165);
            buttonIn.Name = "buttonIn";
            buttonIn.Size = new Size(94, 43);
            buttonIn.TabIndex = 8;
            buttonIn.Text = "In";
            buttonIn.UseVisualStyleBackColor = true;
            buttonIn.Click += buttonIn_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(labelKhachTra, 0, 3);
            tableLayoutPanel2.Controls.Add(labelTongTienHang, 0, 1);
            tableLayoutPanel2.Controls.Add(labelGiamGiaHoaDon, 0, 2);
            tableLayoutPanel2.Controls.Add(labelTongSoLuong, 0, 0);
            tableLayoutPanel2.Location = new Point(862, 8);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RightToLeft = RightToLeft.Yes;
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(237, 154);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // labelKhachTra
            // 
            labelKhachTra.AutoSize = true;
            labelKhachTra.Location = new Point(142, 114);
            labelKhachTra.Name = "labelKhachTra";
            labelKhachTra.Size = new Size(92, 20);
            labelKhachTra.TabIndex = 6;
            labelKhachTra.Text = "Khach da tra";
            // 
            // labelTongTienHang
            // 
            labelTongTienHang.AutoSize = true;
            labelTongTienHang.Location = new Point(125, 38);
            labelTongTienHang.Name = "labelTongTienHang";
            labelTongTienHang.Size = new Size(109, 20);
            labelTongTienHang.TabIndex = 4;
            labelTongTienHang.Text = "Tổng tien hang";
            // 
            // labelGiamGiaHoaDon
            // 
            labelGiamGiaHoaDon.AutoSize = true;
            labelGiamGiaHoaDon.Location = new Point(102, 76);
            labelGiamGiaHoaDon.Name = "labelGiamGiaHoaDon";
            labelGiamGiaHoaDon.Size = new Size(132, 20);
            labelGiamGiaHoaDon.TabIndex = 5;
            labelGiamGiaHoaDon.Text = "Giam gia hoa don ";
            // 
            // labelTongSoLuong
            // 
            labelTongSoLuong.AutoSize = true;
            labelTongSoLuong.Location = new Point(125, 0);
            labelTongSoLuong.Name = "labelTongSoLuong";
            labelTongSoLuong.Size = new Size(109, 20);
            labelTongSoLuong.TabIndex = 3;
            labelTongSoLuong.Text = "Tổng So Luong";
            // 
            // buttonHuyBo
            // 
            buttonHuyBo.Location = new Point(987, 168);
            buttonHuyBo.Name = "buttonHuyBo";
            buttonHuyBo.Size = new Size(94, 40);
            buttonHuyBo.TabIndex = 1;
            buttonHuyBo.Text = "Hủy bỏ";
            buttonHuyBo.UseVisualStyleBackColor = true;
            buttonHuyBo.Click += buttonHuyBo_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(836, 168);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 40);
            buttonLuu.TabIndex = 0;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelTenNguoiTao);
            panel1.Controls.Add(labelTrangThai);
            panel1.Controls.Add(labelBangGia);
            panel1.Controls.Add(labelThoiGian);
            panel1.Controls.Add(labelMaHoaDon);
            panel1.Controls.Add(labelTenKhachHang);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBoxGhiChu);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1108, 163);
            panel1.TabIndex = 0;
            // 
            // labelTenNguoiTao
            // 
            labelTenNguoiTao.AutoSize = true;
            labelTenNguoiTao.Location = new Point(460, 59);
            labelTenNguoiTao.Name = "labelTenNguoiTao";
            labelTenNguoiTao.Size = new Size(15, 20);
            labelTenNguoiTao.TabIndex = 17;
            labelTenNguoiTao.Text = "..";
            // 
            // labelTrangThai
            // 
            labelTrangThai.AutoSize = true;
            labelTrangThai.Location = new Point(460, 16);
            labelTrangThai.Name = "labelTrangThai";
            labelTrangThai.Size = new Size(15, 20);
            labelTrangThai.TabIndex = 16;
            labelTrangThai.Text = "..";
            // 
            // labelBangGia
            // 
            labelBangGia.AutoSize = true;
            labelBangGia.Location = new Point(121, 134);
            labelBangGia.Name = "labelBangGia";
            labelBangGia.Size = new Size(15, 20);
            labelBangGia.TabIndex = 15;
            labelBangGia.Text = "..";
            // 
            // labelThoiGian
            // 
            labelThoiGian.AutoSize = true;
            labelThoiGian.Location = new Point(121, 55);
            labelThoiGian.Name = "labelThoiGian";
            labelThoiGian.Size = new Size(15, 20);
            labelThoiGian.TabIndex = 14;
            labelThoiGian.Text = "..";
            // 
            // labelMaHoaDon
            // 
            labelMaHoaDon.AutoSize = true;
            labelMaHoaDon.Location = new Point(121, 16);
            labelMaHoaDon.Name = "labelMaHoaDon";
            labelMaHoaDon.Size = new Size(15, 20);
            labelMaHoaDon.TabIndex = 13;
            labelMaHoaDon.Text = "..";
            // 
            // labelTenKhachHang
            // 
            labelTenKhachHang.AutoSize = true;
            labelTenKhachHang.Location = new Point(121, 92);
            labelTenKhachHang.Name = "labelTenKhachHang";
            labelTenKhachHang.Size = new Size(15, 20);
            labelTenKhachHang.TabIndex = 12;
            labelTenKhachHang.Text = "..";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(18, 134);
            label6.Name = "label6";
            label6.Size = new Size(71, 20);
            label6.TabIndex = 11;
            label6.Text = "Bảng giá:";
            // 
            // textBoxGhiChu
            // 
            textBoxGhiChu.Location = new Point(710, 9);
            textBoxGhiChu.Multiline = true;
            textBoxGhiChu.Name = "textBoxGhiChu";
            textBoxGhiChu.Size = new Size(284, 134);
            textBoxGhiChu.TabIndex = 6;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(18, 55);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 5;
            label5.Text = "Thời gian:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 92);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 4;
            label4.Text = "Khách hàng:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(352, 16);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 3;
            label3.Text = "Trạng thái:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(352, 59);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 2;
            label2.Text = "Người tạo:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 16);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã hóa đơn:";
            // 
            // dataGridViewdsHoaDon
            // 
            dataGridViewdsHoaDon.BackgroundColor = SystemColors.Window;
            dataGridViewdsHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsHoaDon.Dock = DockStyle.Fill;
            dataGridViewdsHoaDon.Location = new Point(3, 172);
            dataGridViewdsHoaDon.Name = "dataGridViewdsHoaDon";
            dataGridViewdsHoaDon.RowHeadersWidth = 51;
            dataGridViewdsHoaDon.Size = new Size(1108, 371);
            dataGridViewdsHoaDon.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel3, 0, 2);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(dataGridViewdsHoaDon, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 22.1024265F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.0566025F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 28.840971F));
            tableLayoutPanel1.Size = new Size(1114, 769);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // FormChiTietHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1114, 769);
            Controls.Add(tableLayoutPanel1);
            Name = "FormChiTietHoaDon";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChiTietHoaDon";
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsHoaDon).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private Button buttonMoPhieu;
        private Button buttonIn;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelKhachTra;
        private Label labelTongTienHang;
        private Label labelGiamGiaHoaDon;
        private Label labelTongSoLuong;
        private Button buttonHuyBo;
        private Button buttonLuu;
        private Panel panel1;
        private TextBox textBoxGhiChu;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dataGridViewdsHoaDon;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelTenKhachHang;
        private Label label6;
        private Label labelTenNguoiTao;
        private Label labelTrangThai;
        private Label labelBangGia;
        private Label labelThoiGian;
        private Label labelMaHoaDon;
    }
}