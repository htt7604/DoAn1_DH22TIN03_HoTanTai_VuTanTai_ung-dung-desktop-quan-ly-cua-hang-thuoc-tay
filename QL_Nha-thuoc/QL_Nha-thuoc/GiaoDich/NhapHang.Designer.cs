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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            groupBox3 = new GroupBox();
            comboBox2 = new ComboBox();
            groupBox2 = new GroupBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            label1 = new Label();
            dataGridViewdsDMHH = new DataGridView();
            panel6 = new Panel();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            buttonThemHH = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMHH).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(groupBox3);
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsDMHH);
            splitContainer1.Panel2.Controls.Add(panel6);
            splitContainer1.Size = new Size(1271, 658);
            splitContainer1.SplitterDistance = 229;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(3, 436);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(223, 101);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Người nhập";
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(19, 48);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 230);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(223, 135);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Trạng thái";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Font = new Font("Segoe UI", 9F);
            checkBox2.Location = new Point(11, 105);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(77, 24);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Đã hủy";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 9F);
            checkBox3.Location = new Point(11, 66);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(124, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Đã nhập hàng";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Segoe UI", 9F);
            checkBox1.Location = new Point(11, 26);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(98, 24);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "phiếu tạm";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(3, 60);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(223, 123);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thời gian";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 9F);
            radioButton2.Location = new Point(23, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(124, 24);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "Lựa chọn khác";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Font = new Font("Segoe UI", 9F);
            radioButton1.Location = new Point(23, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Tháng này";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(26, 19);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 10;
            label1.Text = "Phiếu nhập hàng";
            // 
            // dataGridViewdsDMHH
            // 
            dataGridViewdsDMHH.BackgroundColor = SystemColors.Window;
            dataGridViewdsDMHH.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewdsDMHH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewdsDMHH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dataGridViewdsDMHH.DefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewdsDMHH.Dock = DockStyle.Fill;
            dataGridViewdsDMHH.Location = new Point(0, 66);
            dataGridViewdsDMHH.MultiSelect = false;
            dataGridViewdsDMHH.Name = "dataGridViewdsDMHH";
            dataGridViewdsDMHH.RowHeadersWidth = 51;
            dataGridViewdsDMHH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsDMHH.Size = new Size(1038, 592);
            dataGridViewdsDMHH.TabIndex = 42;
            // 
            // panel6
            // 
            panel6.Controls.Add(panel);
            panel6.Controls.Add(buttonThemHH);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1038, 66);
            panel6.TabIndex = 41;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(0, 4);
            panel.Name = "panel";
            panel.Size = new Size(491, 55);
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
            tableLayoutPanel5.Location = new Point(28, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(383, 42);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 36);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimHH
            // 
            textBoxTimHH.BorderStyle = BorderStyle.None;
            textBoxTimHH.Font = new Font("Segoe UI", 11F);
            textBoxTimHH.Location = new Point(55, 3);
            textBoxTimHH.Multiline = true;
            textBoxTimHH.Name = "textBoxTimHH";
            textBoxTimHH.PlaceholderText = "Tìm theo mã, tên hang hoa";
            textBoxTimHH.Size = new Size(325, 31);
            textBoxTimHH.TabIndex = 5;
            textBoxTimHH.Tag = "";
            // 
            // buttonThemHH
            // 
            buttonThemHH.BackColor = Color.LimeGreen;
            buttonThemHH.Location = new Point(548, 13);
            buttonThemHH.Name = "buttonThemHH";
            buttonThemHH.Size = new Size(108, 40);
            buttonThemHH.TabIndex = 37;
            buttonThemHH.Text = "+ Them moi";
            buttonThemHH.UseVisualStyleBackColor = false;
            // 
            // NhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 658);
            Controls.Add(splitContainer1);
            Name = "NhapHang";
            Text = "NhapHang";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMHH).EndInit();
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
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private ComboBox comboBox2;
        private Panel panel6;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
        private Button buttonThemHH;
        private DataGridView dataGridViewdsDMHH;
    }
}