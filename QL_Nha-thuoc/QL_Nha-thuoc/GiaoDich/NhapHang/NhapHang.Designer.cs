namespace QL_Nha_thuoc
{
    partial class NhapHang
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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            label1 = new Label();
            dataGridViewdsNhapHang = new DataGridView();
            panel6 = new Panel();
            comboBoxLoaiTimKiem = new ComboBox();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            buttonThemNhapHang = new Button();
            radioButtonTatCa = new RadioButton();
            radioButtonDaNhap = new RadioButton();
            radioButtonDaHuy = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNhapHang).BeginInit();
            panel6.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsNhapHang);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Size = new Size(1271, 658);
            splitContainer1.SplitterDistance = 234;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(radioButtonDaHuy);
            groupBox2.Controls.Add(radioButtonDaNhap);
            groupBox2.Controls.Add(radioButtonTatCa);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 87);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(223, 183);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Trạng thái";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 11;
            label1.Text = "Phiếu nhập hàng";
            // 
            // dataGridViewdsNhapHang
            // 
            dataGridViewdsNhapHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsNhapHang.BackgroundColor = SystemColors.Window;
            dataGridViewdsNhapHang.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle9.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dataGridViewdsNhapHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dataGridViewdsNhapHang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            dataGridViewdsNhapHang.DefaultCellStyle = dataGridViewCellStyle10;
            dataGridViewdsNhapHang.Dock = DockStyle.Fill;
            dataGridViewdsNhapHang.Location = new Point(0, 58);
            dataGridViewdsNhapHang.MultiSelect = false;
            dataGridViewdsNhapHang.Name = "dataGridViewdsNhapHang";
            dataGridViewdsNhapHang.RowHeadersWidth = 51;
            dataGridViewdsNhapHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsNhapHang.Size = new Size(1033, 600);
            dataGridViewdsNhapHang.TabIndex = 43;
            dataGridViewdsNhapHang.CellDoubleClick += dataGridViewdsNhapHang_CellDoubleClick;
            // 
            // panel6
            // 
            panel6.Controls.Add(comboBoxLoaiTimKiem);
            panel6.Controls.Add(panel);
            panel6.Controls.Add(buttonThemNhapHang);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1033, 58);
            panel6.TabIndex = 42;
            // 
            // comboBoxLoaiTimKiem
            // 
            comboBoxLoaiTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiTimKiem.FormattingEnabled = true;
            comboBoxLoaiTimKiem.Location = new Point(497, 12);
            comboBoxLoaiTimKiem.Name = "comboBoxLoaiTimKiem";
            comboBoxLoaiTimKiem.Size = new Size(151, 28);
            comboBoxLoaiTimKiem.TabIndex = 38;
            comboBoxLoaiTimKiem.SelectedIndexChanged += comboBoxLoaiTimKiem_SelectedIndexChanged;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(0, 4);
            panel.Name = "panel";
            panel.Size = new Size(491, 49);
            panel.TabIndex = 36;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Window;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimHH, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(0, 0);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(491, 49);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(61, 43);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimHH
            // 
            textBoxTimHH.BorderStyle = BorderStyle.None;
            textBoxTimHH.Dock = DockStyle.Fill;
            textBoxTimHH.Font = new Font("Segoe UI", 11F);
            textBoxTimHH.Location = new Point(70, 3);
            textBoxTimHH.Multiline = true;
            textBoxTimHH.Name = "textBoxTimHH";
            textBoxTimHH.PlaceholderText = "Tìm theo mã phiếu nhập";
            textBoxTimHH.Size = new Size(418, 43);
            textBoxTimHH.TabIndex = 5;
            textBoxTimHH.Tag = "";
            textBoxTimHH.TextChanged += textBoxTimHH_TextChanged;
            textBoxTimHH.KeyDown += textBoxTimHH_KeyDown;
            // 
            // buttonThemNhapHang
            // 
            buttonThemNhapHang.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonThemNhapHang.BackColor = Color.LimeGreen;
            buttonThemNhapHang.Location = new Point(815, 7);
            buttonThemNhapHang.Name = "buttonThemNhapHang";
            buttonThemNhapHang.Size = new Size(108, 40);
            buttonThemNhapHang.TabIndex = 37;
            buttonThemNhapHang.Text = "+ Thêm mới";
            buttonThemNhapHang.UseVisualStyleBackColor = false;
            buttonThemNhapHang.Click += buttonThemNhapHang_Click;
            // 
            // radioButtonTatCa
            // 
            radioButtonTatCa.AutoSize = true;
            radioButtonTatCa.Location = new Point(49, 37);
            radioButtonTatCa.Name = "radioButtonTatCa";
            radioButtonTatCa.Size = new Size(72, 24);
            radioButtonTatCa.TabIndex = 14;
            radioButtonTatCa.TabStop = true;
            radioButtonTatCa.Text = "Tất cả";
            radioButtonTatCa.UseVisualStyleBackColor = true;
            radioButtonTatCa.CheckedChanged += radioButtonTatCa_CheckedChanged;
            // 
            // radioButtonDaNhap
            // 
            radioButtonDaNhap.AutoSize = true;
            radioButtonDaNhap.Location = new Point(49, 79);
            radioButtonDaNhap.Name = "radioButtonDaNhap";
            radioButtonDaNhap.Size = new Size(88, 24);
            radioButtonDaNhap.TabIndex = 15;
            radioButtonDaNhap.TabStop = true;
            radioButtonDaNhap.Text = "Đã nhập";
            radioButtonDaNhap.UseVisualStyleBackColor = true;
            radioButtonDaNhap.CheckedChanged += radioButtonDaNhap_CheckedChanged;
            // 
            // radioButtonDaHuy
            // 
            radioButtonDaHuy.AutoSize = true;
            radioButtonDaHuy.Location = new Point(49, 126);
            radioButtonDaHuy.Name = "radioButtonDaHuy";
            radioButtonDaHuy.Size = new Size(124, 24);
            radioButtonDaHuy.TabIndex = 16;
            radioButtonDaHuy.TabStop = true;
            radioButtonDaHuy.Text = "radioButton3";
            radioButtonDaHuy.UseVisualStyleBackColor = true;
            radioButtonDaHuy.CheckedChanged += radioButtonDaHuy_CheckedChanged;
            // 
            // NhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 658);
            Controls.Add(splitContainer1);
            Name = "NhapHang";
            Text = "NhapHang";
            WindowState = FormWindowState.Maximized;
            Load += NhapHang_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNhapHang).EndInit();
            panel6.ResumeLayout(false);
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private GroupBox groupBox2;
        private Panel panel6;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
        private Button buttonThemNhapHang;
        private DataGridView dataGridViewdsNhapHang;
        private ComboBox comboBoxLoaiTimKiem;
        private RadioButton radioButtonDaHuy;
        private RadioButton radioButtonDaNhap;
        private RadioButton radioButtonTatCa;
    }
}