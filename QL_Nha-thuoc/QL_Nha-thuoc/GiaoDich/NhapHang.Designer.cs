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
            dataGridViewdsNH = new DataGridView();
            label1 = new Label();
            panel2 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimNV = new TextBox();
            buttonThemNV = new Button();
            panel1 = new Panel();
            groupBox5 = new GroupBox();
            comboBox3 = new ComboBox();
            groupBox2 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox3 = new GroupBox();
            comboBox2 = new ComboBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNH).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewdsNH
            // 
            dataGridViewdsNH.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewdsNH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsNH.Dock = DockStyle.Fill;
            dataGridViewdsNH.Location = new Point(0, 0);
            dataGridViewdsNH.Name = "dataGridViewdsNH";
            dataGridViewdsNH.RowHeadersWidth = 51;
            dataGridViewdsNH.Size = new Size(1271, 658);
            dataGridViewdsNH.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(162, 25);
            label1.TabIndex = 4;
            label1.Text = "Phiếu nhập hàng";
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(buttonThemNV);
            panel2.Location = new Point(180, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1089, 60);
            panel2.TabIndex = 5;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(textBoxTimNV);
            panel4.Location = new Point(45, 11);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 2, 5, 2);
            panel4.Size = new Size(449, 46);
            panel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(22, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimNV
            // 
            textBoxTimNV.BorderStyle = BorderStyle.None;
            textBoxTimNV.Location = new Point(68, 14);
            textBoxTimNV.Multiline = true;
            textBoxTimNV.Name = "textBoxTimNV";
            textBoxTimNV.PlaceholderText = "Tìm theo mã phiếu nhập";
            textBoxTimNV.Size = new Size(354, 25);
            textBoxTimNV.TabIndex = 1;
            textBoxTimNV.Tag = "";
            // 
            // buttonThemNV
            // 
            buttonThemNV.BackColor = Color.LimeGreen;
            buttonThemNV.Location = new Point(639, 10);
            buttonThemNV.Name = "buttonThemNV";
            buttonThemNV.Size = new Size(130, 40);
            buttonThemNV.TabIndex = 0;
            buttonThemNV.Text = "+ Nhập hàng";
            buttonThemNV.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(groupBox3);
            panel1.Location = new Point(12, 66);
            panel1.Name = "panel1";
            panel1.Size = new Size(229, 595);
            panel1.TabIndex = 6;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = SystemColors.ButtonHighlight;
            groupBox5.Controls.Add(comboBox3);
            groupBox5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox5.Location = new Point(11, 398);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(231, 101);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Người tạo";
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(19, 48);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(checkBox2);
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBox1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 163);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 135);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "Trạng thái";
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
            groupBox1.Location = new Point(0, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(229, 123);
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
            radioButton2.TabStop = true;
            radioButton2.Text = "Lựa chọn khác";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 9F);
            radioButton1.Location = new Point(23, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Tháng này";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(3, 471);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(231, 101);
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
            // NhapHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1271, 658);
            Controls.Add(groupBox5);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(dataGridViewdsNH);
            Name = "NhapHang";
            Text = "NhapHang";
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNH).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewdsNH;
        private Label label1;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimNV;
        private Button buttonThemNV;
        private Panel panel1;
        private GroupBox groupBox5;
        private ComboBox comboBox3;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox3;
        private ComboBox comboBox2;
        private CheckBox checkBox2;
    }
}