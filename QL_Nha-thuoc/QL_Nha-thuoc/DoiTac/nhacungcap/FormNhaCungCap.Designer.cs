namespace QL_Nha_thuoc.DoiTac
{
    partial class FormNhaCungCap
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
            panel1 = new Panel();
            buttonXoa = new Button();
            buttonX = new Button();
            labelSoX = new Label();
            comboBoxLocTheo = new ComboBox();
            buttonThemNCC = new Button();
            panel = new Panel();
            tableLayoutPanel5 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            textBoxTimNCC = new TextBox();
            splitContainer1 = new SplitContainer();
            dataGridViewdsNCC = new DataGridView();
            Columncheckbox = new DataGridViewCheckBoxColumn();
            ColumnMaNCC = new DataGridViewTextBoxColumn();
            ColumnTenNCC = new DataGridViewTextBoxColumn();
            ColumnDienThoai = new DataGridViewTextBoxColumn();
            ColumnEmail = new DataGridViewTextBoxColumn();
            ColumnNoCanTra = new DataGridViewTextBoxColumn();
            ColumnTongMua = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNCC).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
            panel1.Controls.Add(buttonXoa);
            panel1.Controls.Add(buttonX);
            panel1.Controls.Add(labelSoX);
            panel1.Controls.Add(comboBoxLocTheo);
            panel1.Controls.Add(buttonThemNCC);
            panel1.Controls.Add(panel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1139, 57);
            panel1.TabIndex = 1;
            // 
            // buttonXoa
            // 
            buttonXoa.BackColor = Color.Salmon;
            buttonXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            buttonXoa.ForeColor = SystemColors.ButtonHighlight;
            buttonXoa.Location = new Point(863, 9);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(94, 37);
            buttonXoa.TabIndex = 42;
            buttonXoa.Text = "Xoa";
            buttonXoa.UseVisualStyleBackColor = false;
            buttonXoa.Visible = false;
            buttonXoa.Click += buttonXoa_Click;
            // 
            // buttonX
            // 
            buttonX.BackColor = SystemColors.Control;
            buttonX.FlatAppearance.BorderColor = SystemColors.Control;
            buttonX.FlatAppearance.BorderSize = 0;
            buttonX.ForeColor = SystemColors.ControlText;
            buttonX.Location = new Point(791, 13);
            buttonX.Name = "buttonX";
            buttonX.Size = new Size(41, 29);
            buttonX.TabIndex = 41;
            buttonX.TabStop = false;
            buttonX.Text = "X";
            buttonX.UseVisualStyleBackColor = false;
            buttonX.Visible = false;
            buttonX.Click += buttonX_Click;
            // 
            // labelSoX
            // 
            labelSoX.AutoSize = true;
            labelSoX.Location = new Point(714, 18);
            labelSoX.Name = "labelSoX";
            labelSoX.Size = new Size(50, 20);
            labelSoX.TabIndex = 40;
            labelSoX.Text = "label1";
            labelSoX.Visible = false;
            // 
            // comboBoxLocTheo
            // 
            comboBoxLocTheo.FormattingEnabled = true;
            comboBoxLocTheo.Location = new Point(534, 13);
            comboBoxLocTheo.Name = "comboBoxLocTheo";
            comboBoxLocTheo.Size = new Size(151, 28);
            comboBoxLocTheo.TabIndex = 39;
            // 
            // buttonThemNCC
            // 
            buttonThemNCC.BackColor = Color.LimeGreen;
            buttonThemNCC.Location = new Point(991, 6);
            buttonThemNCC.Name = "buttonThemNCC";
            buttonThemNCC.Size = new Size(108, 40);
            buttonThemNCC.TabIndex = 38;
            buttonThemNCC.Text = "+ Them moi";
            buttonThemNCC.UseVisualStyleBackColor = false;
            buttonThemNCC.Click += buttonThemNCC_Click;
            // 
            // panel
            // 
            panel.Controls.Add(tableLayoutPanel5);
            panel.Location = new Point(3, 3);
            panel.Name = "panel";
            panel.Size = new Size(491, 43);
            panel.TabIndex = 37;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.BackColor = SystemColors.Window;
            tableLayoutPanel5.ColumnCount = 2;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.6674261F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 86.33257F));
            tableLayoutPanel5.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel5.Controls.Add(textBoxTimNCC, 1, 0);
            tableLayoutPanel5.Location = new Point(28, 3);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel5.Size = new Size(383, 35);
            tableLayoutPanel5.TabIndex = 8;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(46, 29);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimNCC
            // 
            textBoxTimNCC.BorderStyle = BorderStyle.None;
            textBoxTimNCC.Font = new Font("Segoe UI", 11F);
            textBoxTimNCC.Location = new Point(55, 3);
            textBoxTimNCC.Multiline = true;
            textBoxTimNCC.Name = "textBoxTimNCC";
            textBoxTimNCC.PlaceholderText = "Tìm theo mã, tên nha cung cap";
            textBoxTimNCC.Size = new Size(325, 29);
            textBoxTimNCC.TabIndex = 5;
            textBoxTimNCC.Tag = "";
            textBoxTimNCC.TextChanged += textBoxTimNCC_TextChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridViewdsNCC);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 239;
            splitContainer1.TabIndex = 1;
            // 
            // dataGridViewdsNCC
            // 
            dataGridViewdsNCC.AllowUserToAddRows = false;
            dataGridViewdsNCC.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsNCC.BackgroundColor = SystemColors.Window;
            dataGridViewdsNCC.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.LightBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewdsNCC.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewdsNCC.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewdsNCC.Columns.AddRange(new DataGridViewColumn[] { Columncheckbox, ColumnMaNCC, ColumnTenNCC, ColumnDienThoai, ColumnEmail, ColumnNoCanTra, ColumnTongMua });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridViewdsNCC.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewdsNCC.Dock = DockStyle.Fill;
            dataGridViewdsNCC.EnableHeadersVisualStyles = false;
            dataGridViewdsNCC.Location = new Point(0, 57);
            dataGridViewdsNCC.MultiSelect = false;
            dataGridViewdsNCC.Name = "dataGridViewdsNCC";
            dataGridViewdsNCC.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewdsNCC.RowHeadersVisible = false;
            dataGridViewdsNCC.RowHeadersWidth = 51;
            dataGridViewdsNCC.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsNCC.Size = new Size(1139, 595);
            dataGridViewdsNCC.TabIndex = 39;
            dataGridViewdsNCC.CellValueChanged += dataGridViewdsNCC_CellValueChanged;
            dataGridViewdsNCC.CurrentCellDirtyStateChanged += dataGridViewdsNCC_CurrentCellDirtyStateChanged;
            dataGridViewdsNCC.DoubleClick += dataGridViewdsNCC_DoubleClick;
            // 
            // Columncheckbox
            // 
            Columncheckbox.HeaderText = "";
            Columncheckbox.MinimumWidth = 6;
            Columncheckbox.Name = "Columncheckbox";
            // 
            // ColumnMaNCC
            // 
            ColumnMaNCC.FillWeight = 120F;
            ColumnMaNCC.HeaderText = "Mã NCC";
            ColumnMaNCC.MinimumWidth = 6;
            ColumnMaNCC.Name = "ColumnMaNCC";
            // 
            // ColumnTenNCC
            // 
            ColumnTenNCC.FillWeight = 200F;
            ColumnTenNCC.HeaderText = "Tên NCC";
            ColumnTenNCC.MinimumWidth = 6;
            ColumnTenNCC.Name = "ColumnTenNCC";
            // 
            // ColumnDienThoai
            // 
            ColumnDienThoai.FillWeight = 120F;
            ColumnDienThoai.HeaderText = "Điện Thoại";
            ColumnDienThoai.MinimumWidth = 6;
            ColumnDienThoai.Name = "ColumnDienThoai";
            // 
            // ColumnEmail
            // 
            ColumnEmail.FillWeight = 180F;
            ColumnEmail.HeaderText = "Email";
            ColumnEmail.MinimumWidth = 6;
            ColumnEmail.Name = "ColumnEmail";
            // 
            // ColumnNoCanTra
            // 
            ColumnNoCanTra.FillWeight = 150F;
            ColumnNoCanTra.HeaderText = "Nợ Cần Trả NCC";
            ColumnNoCanTra.MinimumWidth = 6;
            ColumnNoCanTra.Name = "ColumnNoCanTra";
            // 
            // ColumnTongMua
            // 
            ColumnTongMua.HeaderText = "Tổng Mua";
            ColumnTongMua.MinimumWidth = 6;
            ColumnTongMua.Name = "ColumnTongMua";
            // 
            // FormNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormNhaCungCap";
            Text = "FormNhaCungCap";
            Load += FormNhaCungCap_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsNCC).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ComboBox comboBoxLocTheo;
        private Button buttonThemNCC;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBox pictureBox1;
        private TextBox textBoxTimNCC;
        private SplitContainer splitContainer1;
        private DataGridView dataGridViewdsNCC;
        private Label labelSoX;
        private DataGridViewCheckBoxColumn Columncheckbox;
        private DataGridViewTextBoxColumn ColumnMaNCC;
        private DataGridViewTextBoxColumn ColumnTenNCC;
        private DataGridViewTextBoxColumn ColumnDienThoai;
        private DataGridViewTextBoxColumn ColumnEmail;
        private DataGridViewTextBoxColumn ColumnNoCanTra;
        private DataGridViewTextBoxColumn ColumnTongMua;
        private Button buttonX;
        private Button buttonXoa;
    }
}