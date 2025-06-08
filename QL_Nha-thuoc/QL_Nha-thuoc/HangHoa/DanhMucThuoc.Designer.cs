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
            label1 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            buttonTimKiem = new Button();
            comboBoxLoaiTimKiem = new ComboBox();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimThuoc = new TextBox();
            panel7 = new Panel();
            dataGridViewdsThuoc = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsThuoc).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(10, 19);
            label1.Name = "label1";
            label1.Size = new Size(158, 25);
            label1.TabIndex = 3;
            label1.Text = "Danh mục thuốc";
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(174, 652);
            panel1.TabIndex = 4;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonTimKiem);
            panel2.Controls.Add(comboBoxLoaiTimKiem);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(174, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1208, 57);
            panel2.TabIndex = 5;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(678, 20);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(94, 29);
            buttonTimKiem.TabIndex = 4;
            buttonTimKiem.Text = "Tim kiem";
            buttonTimKiem.UseVisualStyleBackColor = true;
            buttonTimKiem.Click += buttonTimKiem_Click;
            // 
            // comboBoxLoaiTimKiem
            // 
            comboBoxLoaiTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiTimKiem.FormattingEnabled = true;
            comboBoxLoaiTimKiem.Location = new Point(371, 16);
            comboBoxLoaiTimKiem.Name = "comboBoxLoaiTimKiem";
            comboBoxLoaiTimKiem.Size = new Size(151, 28);
            comboBoxLoaiTimKiem.TabIndex = 3;
            comboBoxLoaiTimKiem.SelectedIndexChanged += comboBoxLoaiTimKiem_SelectedIndexChanged;
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
            textBoxTimThuoc.TextChanged += comboBoxLoaiTimKiem_SelectedIndexChanged;
            // 
            // panel7
            // 
            panel7.Controls.Add(dataGridViewdsThuoc);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(174, 57);
            panel7.Name = "panel7";
            panel7.Size = new Size(1208, 595);
            panel7.TabIndex = 6;
            // 
            // dataGridViewdsThuoc
            // 
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
            dataGridViewdsThuoc.Location = new Point(0, 0);
            dataGridViewdsThuoc.MultiSelect = false;
            dataGridViewdsThuoc.Name = "dataGridViewdsThuoc";
            dataGridViewdsThuoc.RowHeadersWidth = 51;
            dataGridViewdsThuoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsThuoc.Size = new Size(1208, 595);
            dataGridViewdsThuoc.TabIndex = 38;
            // 
            // DanhMucThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(panel7);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DanhMucThuoc";
            Text = "DanhMucThuoc";
            Load += DanhMucThuoc_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsThuoc).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimThuoc;
        private Panel panel7;
        private DataGridView dataGridViewdsThuoc;
        private ComboBox comboBoxLoaiTimKiem;
        private Button buttonTimKiem;
    }
}