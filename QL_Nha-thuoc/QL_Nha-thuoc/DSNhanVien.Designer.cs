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
            groupBox1 = new GroupBox();
            radioButton1 = new RadioButton();
            panel2 = new Panel();
            button1 = new Button();
            label1 = new Label();
            panel3 = new Panel();
            dataGridViewdsNV = new DataGridView();
            radioButton2 = new RadioButton();
            textBox1 = new TextBox();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNV).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(2, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 539);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(10, 13);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(176, 123);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Trạng thái nhân viên ";
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
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button1);
            panel2.Location = new Point(208, 1);
            panel2.Name = "panel2";
            panel2.Size = new Size(1025, 60);
            panel2.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.LimeGreen;
            button1.Location = new Point(639, 10);
            button1.Name = "button1";
            button1.Size = new Size(130, 40);
            button1.TabIndex = 0;
            button1.Text = "+ Nhân viên ";
            button1.UseVisualStyleBackColor = false;
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
            dataGridViewdsNV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsNV.Dock = DockStyle.Fill;
            dataGridViewdsNV.Location = new Point(0, 0);
            dataGridViewdsNV.Name = "dataGridViewdsNV";
            dataGridViewdsNV.RowHeadersWidth = 51;
            dataGridViewdsNV.Size = new Size(1025, 539);
            dataGridViewdsNV.TabIndex = 0;
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
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(64, 15);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(285, 27);
            textBox1.TabIndex = 1;
            textBox1.Text = "Tìm theo mã, tên nhân viên";
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private Label label1;
        private Panel panel3;
        private DataGridView dataGridViewdsNV;
        private GroupBox groupBox1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private TextBox textBox1;
    }
}