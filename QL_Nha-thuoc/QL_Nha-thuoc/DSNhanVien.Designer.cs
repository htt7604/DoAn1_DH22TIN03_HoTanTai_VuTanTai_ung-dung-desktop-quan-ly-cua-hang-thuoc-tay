namespace QL_Nha_thuoc
{
    partial class DSNhanVien
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
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            comboBox2 = new ComboBox();
            groupBox2 = new GroupBox();
            comboBox1 = new ComboBox();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimNV = new TextBox();
            buttonThemNV = new Button();
            label1 = new Label();
            panel3 = new Panel();
            dataGridViewdsNV = new DataGridView();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(2, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 539);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
            groupBox3.Controls.Add(comboBox2);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(0, 289);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(200, 101);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Nhiệu vụ";
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
            groupBox2.Controls.Add(comboBox1);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(0, 160);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 102);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Chức danh";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(19, 42);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(0, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 123);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trạng thái nhân viên ";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 9F);
            radioButton2.Location = new Point(23, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(82, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Đã nghỉ";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 9F);
            radioButton1.Location = new Point(23, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(125, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Đang làm việc";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(buttonThemNV);
            panel2.Location = new Point(208, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1025, 60);
            panel2.TabIndex = 1;
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
            textBoxTimNV.PlaceholderText = "Tìm theo mã, tên nhân viên";
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
            buttonThemNV.Text = "+ Nhân viên ";
            buttonThemNV.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(2, 26);
            label1.Name = "label1";
            label1.Size = new Size(194, 25);
            label1.TabIndex = 2;
            label1.Text = "Danh sách nhân viên";
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridViewdsNV);
            panel3.Location = new Point(208, 76);
            panel3.Name = "panel3";
            panel3.Size = new Size(1025, 539);
            panel3.TabIndex = 1;
            // 
            // dataGridViewdsNV
            // 
            dataGridViewdsNV.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewdsNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsNV.Dock = DockStyle.Fill;
            dataGridViewdsNV.Location = new Point(0, 0);
            dataGridViewdsNV.Name = "dataGridViewdsNV";
            dataGridViewdsNV.RowHeadersWidth = 51;
            dataGridViewdsNV.Size = new Size(1025, 539);
            dataGridViewdsNV.TabIndex = 0;
            // 
            // DSNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            ClientSize = new Size(1238, 616);
            Controls.Add(panel3);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DSNhanVien";
            Text = "DSNhanVien";
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button buttonThemNV;
        private Label label1;
        private Panel panel3;
        private DataGridView dataGridViewdsNV;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBoxTimNV;
        private GroupBox groupBox3;
        private ComboBox comboBox2;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private Panel panel4;
        private PictureBox pictureBox1;
    }
}