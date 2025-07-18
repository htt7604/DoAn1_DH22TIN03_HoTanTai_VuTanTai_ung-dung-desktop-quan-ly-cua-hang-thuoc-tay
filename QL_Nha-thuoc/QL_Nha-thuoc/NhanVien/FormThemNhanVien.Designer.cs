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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            tabControl1.SuspendLayout();
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
    }
}