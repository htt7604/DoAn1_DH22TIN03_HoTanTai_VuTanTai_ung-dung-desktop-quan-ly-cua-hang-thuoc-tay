namespace QL_Nha_thuoc.HangHoa.kiemkho
{
    partial class FormThemKiemKho
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            panel3 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel = new Panel();
            buttonThemHangHoa = new Button();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimHH = new TextBox();
            label1 = new Label();
            buttonTroLai = new Button();
            panelKiemKho = new Panel();
            panelKetQuaTimKiem = new Panel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelKiemKho.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 1);
            tableLayoutPanel1.Controls.Add(panel3, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 8.282208F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 91.71779F));
            tableLayoutPanel1.Size = new Size(1382, 652);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(panelKiemKho);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(1376, 592);
            panel1.TabIndex = 3;
            // 
            // panel3
            // 
            panel3.Controls.Add(tableLayoutPanel2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1376, 48);
            panel3.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 3.05232549F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.0465117F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.90116F));
            tableLayoutPanel2.Controls.Add(panel, 2, 0);
            tableLayoutPanel2.Controls.Add(label1, 1, 0);
            tableLayoutPanel2.Controls.Add(buttonTroLai, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(1376, 48);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel
            // 
            panel.Controls.Add(buttonThemHangHoa);
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(197, 3);
            panel.Name = "panel";
            panel.Size = new Size(747, 42);
            panel.TabIndex = 1;
            // 
            // buttonThemHangHoa
            // 
            buttonThemHangHoa.Location = new Point(517, 6);
            buttonThemHangHoa.Name = "buttonThemHangHoa";
            buttonThemHangHoa.Size = new Size(129, 29);
            buttonThemHangHoa.TabIndex = 0;
            buttonThemHangHoa.Text = "Thêm hàng hóa";
            buttonThemHangHoa.Click += buttonThemHangHoa_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Control;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.4F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimHH, 1, 0);
            tableLayoutPanel5.Location = new Point(3, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel5.Size = new Size(428, 39);
            tableLayoutPanel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(52, 33);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimHH
            // 
            textBoxTimHH.BackColor = SystemColors.Control;
            textBoxTimHH.BorderStyle = BorderStyle.None;
            textBoxTimHH.Font = new Font("Segoe UI", 11F);
            textBoxTimHH.Location = new Point(61, 3);
            textBoxTimHH.Multiline = true;
            textBoxTimHH.Name = "textBoxTimHH";
            textBoxTimHH.PlaceholderText = "Tìm theo mã, tên hàng hóa";
            textBoxTimHH.Size = new Size(325, 31);
            textBoxTimHH.TabIndex = 1;
            textBoxTimHH.TextChanged += textBoxTimHH_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(45, 0);
            label1.Name = "label1";
            label1.Size = new Size(146, 48);
            label1.TabIndex = 0;
            label1.Text = "Kiểm kho";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonTroLai
            // 
            buttonTroLai.BackColor = SystemColors.Control;
            buttonTroLai.Location = new Point(3, 3);
            buttonTroLai.Name = "buttonTroLai";
            buttonTroLai.Size = new Size(36, 42);
            buttonTroLai.TabIndex = 2;
            buttonTroLai.Text = "<-";
            buttonTroLai.UseVisualStyleBackColor = false;
            buttonTroLai.Click += buttonTroLai_Click;
            // 
            // panelKiemKho
            // 
            panelKiemKho.Controls.Add(panelKetQuaTimKiem);
            panelKiemKho.Dock = DockStyle.Fill;
            panelKiemKho.Location = new Point(0, 0);
            panelKiemKho.Name = "panelKiemKho";
            panelKiemKho.Size = new Size(1376, 592);
            panelKiemKho.TabIndex = 4;
            // 
            // panelKetQuaTimKiem
            // 
            panelKetQuaTimKiem.AutoScroll = true;
            panelKetQuaTimKiem.Location = new Point(197, 3);
            panelKetQuaTimKiem.Name = "panelKetQuaTimKiem";
            panelKetQuaTimKiem.Size = new Size(428, 355);
            panelKetQuaTimKiem.TabIndex = 5;
            panelKetQuaTimKiem.Visible = false;
            // 
            // FormThemKiemKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(1382, 652);
            Controls.Add(tableLayoutPanel1);
            Name = "FormThemKiemKho";
            Text = "Thêm kiểm kho";
            Load += FormThemKiemKho_Load;
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelKiemKho.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flowLayoutPanelTatCa;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel2;
        private Label label1;
        private Panel panel;
        private Button buttonThemHangHoa;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimHH;
        private Panel panel3;
        private Button buttonTroLai;
        private Panel panelKiemKho;
        private Panel panelKetQuaTimKiem;
    }
}
