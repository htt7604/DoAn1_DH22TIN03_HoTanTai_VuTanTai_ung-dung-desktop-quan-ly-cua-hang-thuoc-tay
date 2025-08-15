namespace QL_Nha_thuoc
{
    partial class HoaDon
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            groupBox5 = new GroupBox();
            radioButtonChuyenKhoan = new RadioButton();
            radioButtonTienMat = new RadioButton();
            radioButton4 = new RadioButton();
            label1 = new Label();
            dataGridViewdsHoaDon = new DataGridView();
            panel2 = new Panel();
            buttonTim = new Button();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimHD = new TextBox();
            buttonThemHoaDon = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsHoaDon).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(groupBox5);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsHoaDon);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1262, 1017);
            splitContainer1.SplitterDistance = 249;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = SystemColors.ButtonHighlight;
            groupBox5.Controls.Add(radioButtonChuyenKhoan);
            groupBox5.Controls.Add(radioButtonTienMat);
            groupBox5.Controls.Add(radioButton4);
            groupBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox5.Location = new Point(3, 87);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(229, 177);
            groupBox5.TabIndex = 20;
            groupBox5.TabStop = false;
            groupBox5.Text = "Hình thức thanh toán ";
            // 
            // radioButtonChuyenKhoan
            // 
            radioButtonChuyenKhoan.AutoSize = true;
            radioButtonChuyenKhoan.Font = new Font("Segoe UI", 9F);
            radioButtonChuyenKhoan.Location = new Point(23, 123);
            radioButtonChuyenKhoan.Name = "radioButtonChuyenKhoan";
            radioButtonChuyenKhoan.Size = new Size(122, 24);
            radioButtonChuyenKhoan.TabIndex = 2;
            radioButtonChuyenKhoan.TabStop = true;
            radioButtonChuyenKhoan.Text = "Chuyển khoản";
            radioButtonChuyenKhoan.UseVisualStyleBackColor = true;
            radioButtonChuyenKhoan.CheckedChanged += radioButtonChuyenKhoan_CheckedChanged;
            // 
            // radioButtonTienMat
            // 
            radioButtonTienMat.AutoSize = true;
            radioButtonTienMat.Font = new Font("Segoe UI", 9F);
            radioButtonTienMat.Location = new Point(23, 77);
            radioButtonTienMat.Name = "radioButtonTienMat";
            radioButtonTienMat.Size = new Size(88, 24);
            radioButtonTienMat.TabIndex = 1;
            radioButtonTienMat.TabStop = true;
            radioButtonTienMat.Text = "Tiền mặt";
            radioButtonTienMat.UseVisualStyleBackColor = true;
            radioButtonTienMat.CheckedChanged += radioButtonTienMat_CheckedChanged;
            // 
            // radioButton4
            // 
            radioButton4.AutoSize = true;
            radioButton4.Font = new Font("Segoe UI", 9F);
            radioButton4.Location = new Point(23, 38);
            radioButton4.Name = "radioButton4";
            radioButton4.Size = new Size(70, 24);
            radioButton4.TabIndex = 0;
            radioButton4.TabStop = true;
            radioButton4.Text = "Tất cả";
            radioButton4.UseVisualStyleBackColor = true;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(66, 25);
            label1.Name = "label1";
            label1.Size = new Size(90, 25);
            label1.TabIndex = 16;
            label1.Text = "Hóa đơn";
            // 
            // dataGridViewdsHoaDon
            // 
            dataGridViewdsHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsHoaDon.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewdsHoaDon.BackgroundColor = SystemColors.Window;
            dataGridViewdsHoaDon.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewdsHoaDon.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewdsHoaDon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewdsHoaDon.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewdsHoaDon.Dock = DockStyle.Fill;
            dataGridViewdsHoaDon.Location = new Point(0, 64);
            dataGridViewdsHoaDon.MultiSelect = false;
            dataGridViewdsHoaDon.Name = "dataGridViewdsHoaDon";
            dataGridViewdsHoaDon.RowHeadersVisible = false;
            dataGridViewdsHoaDon.RowHeadersWidth = 51;
            dataGridViewdsHoaDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsHoaDon.Size = new Size(1009, 953);
            dataGridViewdsHoaDon.TabIndex = 39;
            dataGridViewdsHoaDon.CellDoubleClick += dataGridViewdsHoaDon_CellDoubleClick;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonTim);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(buttonThemHoaDon);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1009, 64);
            panel2.TabIndex = 13;
            // 
            // buttonTim
            // 
            buttonTim.BackColor = SystemColors.Window;
            buttonTim.Location = new Point(414, 10);
            buttonTim.Name = "buttonTim";
            buttonTim.Size = new Size(130, 40);
            buttonTim.TabIndex = 2;
            buttonTim.Text = "Tìm kiếm";
            buttonTim.UseVisualStyleBackColor = false;
            buttonTim.Click += buttonTim_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(textBoxTimHD);
            panel4.Location = new Point(23, 10);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 2, 5, 2);
            panel4.Size = new Size(357, 40);
            panel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(8, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimHD
            // 
            textBoxTimHD.BorderStyle = BorderStyle.None;
            textBoxTimHD.Location = new Point(71, 5);
            textBoxTimHD.Multiline = true;
            textBoxTimHD.Name = "textBoxTimHD";
            textBoxTimHD.PlaceholderText = "Tìm theo mã hóa dơn";
            textBoxTimHD.Size = new Size(278, 25);
            textBoxTimHD.TabIndex = 1;
            textBoxTimHD.Tag = "";
            // 
            // buttonThemHoaDon
            // 
            buttonThemHoaDon.BackColor = Color.LimeGreen;
            buttonThemHoaDon.Location = new Point(639, 10);
            buttonThemHoaDon.Name = "buttonThemHoaDon";
            buttonThemHoaDon.Size = new Size(130, 40);
            buttonThemHoaDon.TabIndex = 0;
            buttonThemHoaDon.Text = "+ Thêm mới";
            buttonThemHoaDon.UseVisualStyleBackColor = false;
            buttonThemHoaDon.Click += buttonThemHoaDon_Click;
            // 
            // HoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 1017);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "HoaDon";
            Text = "FormHoaDon";
            Load += HoaDon_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsHoaDon).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private GroupBox groupBox5;
        private RadioButton radioButtonChuyenKhoan;
        private RadioButton radioButtonTienMat;
        private RadioButton radioButton4;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHD;
        private Button buttonThemHoaDon;
        private DataGridView dataGridViewdsHoaDon;
        private Button buttonTim;
    }
}