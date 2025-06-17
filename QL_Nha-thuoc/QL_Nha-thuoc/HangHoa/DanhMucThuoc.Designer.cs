namespace QL_Nha_thuoc
{
    partial class DanhMucThuoc
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
            label1 = new Label();
            dataGridViewdsThuoc = new DataGridView();
            panel2 = new Panel();
            comboBoxLoaiTimKiem = new ComboBox();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimThuoc = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsThuoc).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsThuoc);
            splitContainer1.Panel2.Controls.Add(panel2);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 178;
            splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(3, 20);
            label1.Name = "label1";
            label1.Size = new Size(158, 25);
            label1.TabIndex = 4;
            label1.Text = "Danh mục thuốc";
            // 
            // dataGridViewdsThuoc
            // 
            dataGridViewdsThuoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsThuoc.BackgroundColor = SystemColors.Window;
            dataGridViewdsThuoc.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewdsThuoc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewdsThuoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewdsThuoc.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewdsThuoc.Dock = DockStyle.Fill;
            dataGridViewdsThuoc.Location = new Point(0, 57);
            dataGridViewdsThuoc.MultiSelect = false;
            dataGridViewdsThuoc.Name = "dataGridViewdsThuoc";
            dataGridViewdsThuoc.RowHeadersWidth = 51;
            dataGridViewdsThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsThuoc.Size = new Size(1200, 595);
            dataGridViewdsThuoc.TabIndex = 39;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboBoxLoaiTimKiem);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1200, 57);
            panel2.TabIndex = 9;
            // 
            // comboBoxLoaiTimKiem
            // 
            comboBoxLoaiTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiTimKiem.FormattingEnabled = true;
            comboBoxLoaiTimKiem.Location = new Point(371, 16);
            comboBoxLoaiTimKiem.Name = "comboBoxLoaiTimKiem";
            comboBoxLoaiTimKiem.Size = new Size(151, 28);
            comboBoxLoaiTimKiem.TabIndex = 3;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(textBoxTimThuoc);
            panel4.Location = new Point(6, 10);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 2, 5, 2);
            panel4.Size = new Size(347, 41);
            panel4.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(8, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimThuoc
            // 
            textBoxTimThuoc.BorderStyle = BorderStyle.None;
            textBoxTimThuoc.Location = new Point(68, 7);
            textBoxTimThuoc.Multiline = true;
            textBoxTimThuoc.Name = "textBoxTimThuoc";
            textBoxTimThuoc.PlaceholderText = "Tìm theo tên thuốc";
            textBoxTimThuoc.Size = new Size(260, 25);
            textBoxTimThuoc.TabIndex = 1;
            textBoxTimThuoc.Tag = "";
            // 
            // DanhMucThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DanhMucThuoc";
            Text = "DanhMucThuoc";
            Load += DanhMucThuoc_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsThuoc).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private Panel panel2;
        private ComboBox comboBoxLoaiTimKiem;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimThuoc;
        private DataGridView dataGridViewdsThuoc;
    }
}