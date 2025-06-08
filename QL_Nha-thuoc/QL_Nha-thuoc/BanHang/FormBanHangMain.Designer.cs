namespace QL_Nha_thuoc.BanHang
{
    partial class FormBanHangMain
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
            panel2 = new Panel();
            panel3 = new Panel();
            tabControlHoaDon = new TabControl();
            tabPageHoaDon1 = new TabPage();
            panelKetQuaTimKiem = new Panel();
            panel1 = new Panel();
            buttonThemHoaDon = new Button();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            tabControlHoaDon.SuspendLayout();
            panel1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1400, 749);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(tabControlHoaDon);
            panel3.Controls.Add(panelKetQuaTimKiem);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(1400, 686);
            panel3.TabIndex = 4;
            // 
            // tabControlHoaDon
            // 
            tabControlHoaDon.Controls.Add(tabPageHoaDon1);
            tabControlHoaDon.Dock = DockStyle.Fill;
            tabControlHoaDon.Location = new Point(0, 0);
            tabControlHoaDon.Name = "tabControlHoaDon";
            tabControlHoaDon.SelectedIndex = 0;
            tabControlHoaDon.Size = new Size(1400, 686);
            tabControlHoaDon.TabIndex = 41;
            // 
            // tabPageHoaDon1
            // 
            tabPageHoaDon1.BackColor = SystemColors.Control;
            tabPageHoaDon1.Location = new Point(4, 29);
            tabPageHoaDon1.Name = "tabPageHoaDon1";
            tabPageHoaDon1.Padding = new Padding(3);
            tabPageHoaDon1.Size = new Size(1392, 653);
            tabPageHoaDon1.TabIndex = 0;
            tabPageHoaDon1.Text = "Hoa don 1";
            // 
            // panelKetQuaTimKiem
            // 
            panelKetQuaTimKiem.AutoScroll = true;
            panelKetQuaTimKiem.BackColor = SystemColors.Control;
            panelKetQuaTimKiem.Location = new Point(45, 6);
            panelKetQuaTimKiem.Name = "panelKetQuaTimKiem";
            panelKetQuaTimKiem.Size = new Size(463, 221);
            panelKetQuaTimKiem.TabIndex = 40;
            // 
            // panel1
            // 
            panel1.Controls.Add(buttonThemHoaDon);
            panel1.Controls.Add(panel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1400, 63);
            panel1.TabIndex = 3;
            // 
            // buttonThemHoaDon
            // 
            buttonThemHoaDon.Location = new Point(752, 12);
            buttonThemHoaDon.Name = "buttonThemHoaDon";
            buttonThemHoaDon.Size = new Size(151, 29);
            buttonThemHoaDon.TabIndex = 38;
            buttonThemHoaDon.Text = "Them Hoa don";
            buttonThemHoaDon.UseVisualStyleBackColor = true;
            buttonThemHoaDon.Click += buttonThemHoaDon_Click;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(4, 3);
            panel.Name = "panel";
            panel.Size = new Size(491, 55);
            panel.TabIndex = 37;
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
            textBoxTimHH.TextChanged += textBoxTimHH_TextChanged_1;
            // 
            // FormBanHangMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 749);
            Controls.Add(panel2);
            Name = "FormBanHangMain";
            Text = "FormBanHangMain";
            Load += FormBanHangMain_Load;
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tabControlHoaDon.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Panel panel3;
        private Panel panelKetQuaTimKiem;
        private Panel panel1;
        private Button buttonThemHoaDon;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
        private TabControl tabControlHoaDon;
        private TabPage tabPageHoaDon1;
    }
}