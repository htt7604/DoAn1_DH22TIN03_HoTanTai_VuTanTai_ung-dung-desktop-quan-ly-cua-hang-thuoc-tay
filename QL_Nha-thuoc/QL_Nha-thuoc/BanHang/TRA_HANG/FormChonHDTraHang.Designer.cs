namespace QL_Nha_thuoc.BanHang.TRA_HANG
{
    partial class FormChonHDTraHang
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
            splitContainer1 = new SplitContainer();
            buttonTImKiem = new Button();
            groupBox2 = new GroupBox();
            dateTimePickerDenNgay = new DateTimePicker();
            dateTimePickerTuNgay = new DateTimePicker();
            groupBox1 = new GroupBox();
            textBoxTenHang = new TextBox();
            textBoxMaHangHoa = new TextBox();
            textBoxKhachHang = new TextBox();
            textBoxMaHoaDon = new TextBox();
            dataGridViewHoaDon = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoaDon).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(buttonTImKiem);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewHoaDon);
            splitContainer1.Size = new Size(1068, 713);
            splitContainer1.SplitterDistance = 273;
            splitContainer1.TabIndex = 0;
            // 
            // buttonTImKiem
            // 
            buttonTImKiem.Location = new Point(74, 537);
            buttonTImKiem.Name = "buttonTImKiem";
            buttonTImKiem.Size = new Size(94, 59);
            buttonTImKiem.TabIndex = 2;
            buttonTImKiem.Text = "Tìm kiếm";
            buttonTImKiem.UseVisualStyleBackColor = true;
            buttonTImKiem.Click += buttonTImKiem_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(dateTimePickerDenNgay);
            groupBox2.Controls.Add(dateTimePickerTuNgay);
            groupBox2.Location = new Point(12, 332);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(247, 184);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Thời gian ";
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerDenNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerDenNgay.Location = new Point(6, 132);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(213, 27);
            dateTimePickerDenNgay.TabIndex = 1;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.CustomFormat = "dd/MM/yyyy";
            dateTimePickerTuNgay.Format = DateTimePickerFormat.Custom;
            dateTimePickerTuNgay.Location = new Point(6, 64);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(213, 27);
            dateTimePickerTuNgay.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBoxTenHang);
            groupBox1.Controls.Add(textBoxMaHangHoa);
            groupBox1.Controls.Add(textBoxKhachHang);
            groupBox1.Controls.Add(textBoxMaHoaDon);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(247, 280);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tìm kiếm";
            // 
            // textBoxTenHang
            // 
            textBoxTenHang.Location = new Point(30, 223);
            textBoxTenHang.Name = "textBoxTenHang";
            textBoxTenHang.PlaceholderText = "Theo tên hàng ";
            textBoxTenHang.Size = new Size(182, 27);
            textBoxTenHang.TabIndex = 3;
            // 
            // textBoxMaHangHoa
            // 
            textBoxMaHangHoa.Location = new Point(30, 162);
            textBoxMaHangHoa.Name = "textBoxMaHangHoa";
            textBoxMaHangHoa.PlaceholderText = "Theo mã hàng hóa";
            textBoxMaHangHoa.Size = new Size(182, 27);
            textBoxMaHangHoa.TabIndex = 2;
            // 
            // textBoxKhachHang
            // 
            textBoxKhachHang.Location = new Point(30, 105);
            textBoxKhachHang.Name = "textBoxKhachHang";
            textBoxKhachHang.PlaceholderText = "Tên khách hàng ";
            textBoxKhachHang.Size = new Size(182, 27);
            textBoxKhachHang.TabIndex = 1;
            // 
            // textBoxMaHoaDon
            // 
            textBoxMaHoaDon.Location = new Point(30, 46);
            textBoxMaHoaDon.Name = "textBoxMaHoaDon";
            textBoxMaHoaDon.PlaceholderText = "tìm theo mã hóa đơn";
            textBoxMaHoaDon.Size = new Size(182, 27);
            textBoxMaHoaDon.TabIndex = 0;
            // 
            // dataGridViewHoaDon
            // 
            dataGridViewHoaDon.AllowUserToAddRows = false;
            dataGridViewHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHoaDon.Dock = DockStyle.Fill;
            dataGridViewHoaDon.Location = new Point(0, 0);
            dataGridViewHoaDon.Name = "dataGridViewHoaDon";
            dataGridViewHoaDon.RowHeadersWidth = 51;
            dataGridViewHoaDon.Size = new Size(791, 713);
            dataGridViewHoaDon.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 41);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 2;
            label1.Text = "Từ ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 109);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 3;
            label2.Text = "Đến ngày";
            // 
            // FormChonHDTraHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1068, 713);
            Controls.Add(splitContainer1);
            Name = "FormChonHDTraHang";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormChonHDTraHang";
            Load += FormChonHDTraHang_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHoaDon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox textBoxTenHang;
        private TextBox textBoxMaHangHoa;
        private TextBox textBoxKhachHang;
        private TextBox textBoxMaHoaDon;
        private DataGridView dataGridViewHoaDon;
        private DateTimePicker dateTimePickerDenNgay;
        private DateTimePicker dateTimePickerTuNgay;
        private Button buttonTImKiem;
        private Label label2;
        private Label label1;
    }
}