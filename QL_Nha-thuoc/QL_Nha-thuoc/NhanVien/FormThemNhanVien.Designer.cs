namespace QL_Nha_thuoc.NhanVien
{
    partial class FormThemNhanVien
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
            label1 = new Label();
            buttonX = new Button();
            panel2 = new Panel();
            buttonBoQua = new Button();
            buttonLuu = new Button();
            tabControl1 = new TabControl();
            tabPageThongTin = new TabPage();
            tabPageThietLapLuong = new TabPage();
            panel3 = new Panel();
            label2 = new Label();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageThongTin.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label1);
            panel1.Controls.Add(buttonX);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1293, 57);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(153, 25);
            label1.TabIndex = 1;
            label1.Text = "Them nhan vien";
            // 
            // buttonX
            // 
            buttonX.Location = new Point(1235, 12);
            buttonX.Name = "buttonX";
            buttonX.Size = new Size(46, 29);
            buttonX.TabIndex = 0;
            buttonX.Text = "X";
            buttonX.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonBoQua);
            panel2.Controls.Add(buttonLuu);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 455);
            panel2.Name = "panel2";
            panel2.Size = new Size(1293, 61);
            panel2.TabIndex = 2;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Location = new Point(981, 20);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(127, 29);
            buttonBoQua.TabIndex = 2;
            buttonBoQua.Text = "Bo qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(811, 20);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(131, 29);
            buttonLuu.TabIndex = 1;
            buttonLuu.Text = "Luu";
            buttonLuu.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageThongTin);
            tabControl1.Controls.Add(tabPageThietLapLuong);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 57);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1293, 398);
            tabControl1.TabIndex = 3;
            // 
            // tabPageThongTin
            // 
            tabPageThongTin.AutoScroll = true;
            tabPageThongTin.BackColor = SystemColors.Control;
            tabPageThongTin.Controls.Add(panel3);
            tabPageThongTin.Location = new Point(4, 29);
            tabPageThongTin.Name = "tabPageThongTin";
            tabPageThongTin.Padding = new Padding(3);
            tabPageThongTin.Size = new Size(1285, 365);
            tabPageThongTin.TabIndex = 0;
            tabPageThongTin.Text = "Thong tin";
            // 
            // tabPageThietLapLuong
            // 
            tabPageThietLapLuong.BackColor = SystemColors.Control;
            tabPageThietLapLuong.Location = new Point(4, 29);
            tabPageThietLapLuong.Name = "tabPageThietLapLuong";
            tabPageThietLapLuong.Padding = new Padding(3);
            tabPageThietLapLuong.Size = new Size(1285, 365);
            tabPageThietLapLuong.TabIndex = 1;
            tabPageThietLapLuong.Text = "Thiet lap luong";
            // 
            // panel3
            // 
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(55, 29);
            panel3.Name = "panel3";
            panel3.Size = new Size(1156, 268);
            panel3.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 23);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 0;
            label2.Text = "Luong chinh";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(166, 82);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(277, 28);
            comboBox1.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 85);
            label3.Name = "label3";
            label3.Size = new Size(79, 20);
            label3.TabIndex = 2;
            label3.Text = "Loai luong";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 171);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 3;
            label4.Text = "Muc luong";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(166, 164);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(277, 27);
            textBox1.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(449, 167);
            label5.Name = "label5";
            label5.Size = new Size(32, 20);
            label5.TabIndex = 5;
            label5.Text = "/Ca";
            // 
            // FormThemNhanVien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1293, 516);
            Controls.Add(tabControl1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormThemNhanVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormThemNhanVien";
            Load += FormThemNhanVien_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPageThongTin.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button buttonX;
        private Panel panel2;
        private Button buttonBoQua;
        private Button buttonLuu;
        private TabControl tabControl1;
        private TabPage tabPageThongTin;
        private TabPage tabPageThietLapLuong;
        private Panel panel3;
        private Label label5;
        private TextBox textBox1;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
        private Label label2;
    }
}