namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlFormHoaDon
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
            panel1 = new Panel();
            button1 = new Button();
            flowLayoutPanelTTHH = new FlowLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            buttonThemKhachHang = new Button();
            panel1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Window;
            panel1.Controls.Add(panel);
            panel1.Controls.Add(comboBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(929, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(466, 656);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(130, 536);
            button1.Name = "button1";
            button1.Size = new Size(236, 67);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanelTTHH
            // 
            flowLayoutPanelTTHH.Dock = DockStyle.Fill;
            flowLayoutPanelTTHH.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelTTHH.Location = new Point(0, 0);
            flowLayoutPanelTTHH.Name = "flowLayoutPanelTTHH";
            flowLayoutPanelTTHH.Size = new Size(929, 656);
            flowLayoutPanelTTHH.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 122);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 187);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(37, 16);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 3;
            // 
            // panel
            // 
            panel.Controls.Add(buttonThemKhachHang);
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(6, 50);
            panel.Name = "panel";
            panel.Size = new Size(446, 55);
            panel.TabIndex = 38;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Window;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimHH, 1, 0);
            tableLayoutPanel5.Location = new Point(3, 3);
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
            // buttonThemKhachHang
            // 
            buttonThemKhachHang.Location = new Point(392, 6);
            buttonThemKhachHang.Name = "buttonThemKhachHang";
            buttonThemKhachHang.Size = new Size(41, 39);
            buttonThemKhachHang.TabIndex = 39;
            buttonThemKhachHang.Text = "+";
            buttonThemKhachHang.UseVisualStyleBackColor = true;
            // 
            // UserControlFormHoaDon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(flowLayoutPanelTTHH);
            Controls.Add(panel1);
            Name = "UserControlFormHoaDon";
            Size = new Size(1395, 656);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Button button1;
        private FlowLayoutPanel flowLayoutPanelTTHH;
        private ComboBox comboBox1;
        private Label label2;
        private Label label1;
        private Panel panel;
        private Button buttonThemKhachHang;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
    }
}
