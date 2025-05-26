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
            dataGridViewdsDMT = new DataGridView();
            panel2 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimNV = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMT).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // dataGridViewdsDMT
            // 
            dataGridViewdsDMT.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewdsDMT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsDMT.Dock = DockStyle.Fill;
            dataGridViewdsDMT.Location = new Point(0, 0);
            dataGridViewdsDMT.Name = "dataGridViewdsDMT";
            dataGridViewdsDMT.RowHeadersWidth = 51;
            dataGridViewdsDMT.Size = new Size(1063, 734);
            dataGridViewdsDMT.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(176, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(887, 60);
            panel2.TabIndex = 2;
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
            textBoxTimNV.PlaceholderText = "Tìm theo tên thuốc";
            textBoxTimNV.Size = new Size(354, 25);
            textBoxTimNV.TabIndex = 1;
            textBoxTimNV.Tag = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(158, 25);
            label1.TabIndex = 3;
            label1.Text = "Danh mục thuốc";
            // 
            // DanhMucThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1063, 734);
            Controls.Add(label1);
            Controls.Add(panel2);
            Controls.Add(dataGridViewdsDMT);
            Name = "DanhMucThuoc";
            Text = "DanhMucThuoc";
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMT).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewdsDMT;
        private Panel panel2;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimNV;
        private Label label1;
    }
}