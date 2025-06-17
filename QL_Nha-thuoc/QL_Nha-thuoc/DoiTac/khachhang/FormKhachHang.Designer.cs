namespace QL_Nha_thuoc.DoiTac
{
    partial class FormKhachHang
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            splitContainer1 = new SplitContainer();
            dataGridViewdsDMKH = new DataGridView();
            panel1 = new Panel();
            comboBoxLocTheo = new ComboBox();
            buttonThemKH = new Button();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimKH = new TextBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMKH).BeginInit();
            panel1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsDMKH);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 250;
            splitContainer1.TabIndex = 0;
            // 
            // dataGridViewdsDMKH
            // 
            dataGridViewdsDMKH.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsDMKH.BackgroundColor = SystemColors.Window;
            dataGridViewdsDMKH.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewdsDMKH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewdsDMKH.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewdsDMKH.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewdsDMKH.Dock = DockStyle.Fill;
            dataGridViewdsDMKH.Location = new Point(0, 54);
            dataGridViewdsDMKH.MultiSelect = false;
            dataGridViewdsDMKH.Name = "dataGridViewdsDMKH";
            dataGridViewdsDMKH.RowHeadersWidth = 51;
            dataGridViewdsDMKH.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsDMKH.Size = new Size(1128, 598);
            dataGridViewdsDMKH.TabIndex = 38;
            dataGridViewdsDMKH.CellDoubleClick += dataGridViewdsDMKH_CellDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(comboBoxLocTheo);
            panel1.Controls.Add(buttonThemKH);
            panel1.Controls.Add(panel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1128, 54);
            panel1.TabIndex = 0;
            // 
            // comboBoxLocTheo
            // 
            comboBoxLocTheo.FormattingEnabled = true;
            comboBoxLocTheo.Location = new Point(534, 13);
            comboBoxLocTheo.Name = "comboBoxLocTheo";
            comboBoxLocTheo.Size = new Size(151, 28);
            comboBoxLocTheo.TabIndex = 39;
            comboBoxLocTheo.SelectedIndexChanged += comboBoxLocTheo_SelectedIndexChanged;
            // 
            // buttonThemKH
            // 
            buttonThemKH.BackColor = Color.LimeGreen;
            buttonThemKH.Location = new Point(731, 6);
            buttonThemKH.Name = "buttonThemKH";
            buttonThemKH.Size = new Size(108, 40);
            buttonThemKH.TabIndex = 38;
            buttonThemKH.Text = "+ Them moi";
            buttonThemKH.UseVisualStyleBackColor = false;
            buttonThemKH.Click += buttonThemKH_Click;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(3, 3);
            panel.Name = "panel";
            panel.Size = new Size(491, 49);
            panel.TabIndex = 37;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Window;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimKH, 1, 0);
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
            // textBoxTimKH
            // 
            textBoxTimKH.BorderStyle = BorderStyle.None;
            textBoxTimKH.Font = new Font("Segoe UI", 11F);
            textBoxTimKH.Location = new Point(55, 3);
            textBoxTimKH.Multiline = true;
            textBoxTimKH.Name = "textBoxTimKH";
            textBoxTimKH.PlaceholderText = "Tìm theo mã, tên khach hang";
            textBoxTimKH.Size = new Size(325, 31);
            textBoxTimKH.TabIndex = 5;
            textBoxTimKH.Tag = "";
            textBoxTimKH.TextChanged += textBoxTimKH_TextChanged;
            // 
            // FormKhachHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormKhachHang";
            Text = "FormKhachHang";
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsDMKH).EndInit();
            panel1.ResumeLayout(false);
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView dataGridViewdsDMKH;
        private Panel panel1;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimKH;
        private Button buttonThemKH;
        private ComboBox comboBoxLocTheo;
    }
}