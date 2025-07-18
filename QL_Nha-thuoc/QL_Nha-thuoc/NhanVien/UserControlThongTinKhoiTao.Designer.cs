namespace QL_Nha_thuoc.NhanVien
{
    partial class UserControlThongTinKhoiTao
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            pictureBox1 = new PictureBox();
            buttonHienThiThem = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(35, 164);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.Window;
            pictureBox1.Location = new Point(19, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(125, 112);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // buttonHienThiThem
            // 
            buttonHienThiThem.Location = new Point(193, 246);
            buttonHienThiThem.Name = "buttonHienThiThem";
            buttonHienThiThem.Size = new Size(151, 29);
            buttonHienThiThem.TabIndex = 6;
            buttonHienThiThem.Text = "Hien Thi Them";
            buttonHienThiThem.UseVisualStyleBackColor = true;
            buttonHienThiThem.Click += buttonHienThiThem_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 16);
            label2.Name = "label2";
            label2.Size = new Size(130, 20);
            label2.TabIndex = 0;
            label2.Text = "Thong tin khoi tao";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 66);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 1;
            label3.Text = "Ma nhan vien ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 120);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 2;
            label4.Text = "So dien thoai";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(451, 66);
            label5.Name = "label5";
            label5.Size = new Size(99, 20);
            label5.TabIndex = 3;
            label5.Text = "Ten nhan vien";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(199, 63);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(181, 27);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(199, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(181, 27);
            textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(598, 63);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(244, 27);
            textBox3.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Window;
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(193, 31);
            panel3.Name = "panel3";
            panel3.Size = new Size(957, 184);
            panel3.TabIndex = 5;
            // 
            // UserControlThongTinKhoiTao
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonHienThiThem);
            Controls.Add(panel3);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            Name = "UserControlThongTinKhoiTao";
            Size = new Size(1194, 293);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private PictureBox pictureBox1;
        private Button buttonHienThiThem;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Panel panel3;
    }
}
