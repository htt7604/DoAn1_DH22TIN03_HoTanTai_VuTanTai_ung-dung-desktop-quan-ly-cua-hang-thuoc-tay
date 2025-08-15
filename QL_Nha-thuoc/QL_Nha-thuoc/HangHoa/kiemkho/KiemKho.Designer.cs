namespace QL_Nha_thuoc
{
    partial class KiemKho
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
            groupBox2 = new GroupBox();
            checkBoxDahuy = new CheckBox();
            checkBoxDaCanBang = new CheckBox();
            checkBoxPhieuTam = new CheckBox();
            buttonThemKiemKho = new Button();
            label1 = new Label();
            panel3 = new Panel();
            dataGridViewdsPhieuKiemKho = new DataGridView();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxTimNV = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            buttonGopPhieu = new Button();
            buttonX = new Button();
            labelSoX = new Label();
            buttonTimKiem = new Button();
            comboBoxLoaiTimKiem = new ComboBox();
            panel5 = new Panel();
            pictureBox2 = new PictureBox();
            textBoxTimPhieuKiem = new TextBox();
            groupBox1 = new GroupBox();
            comboBoxNhanVien = new ComboBox();
            groupBox2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsPhieuKiemKho).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(checkBoxDahuy);
            groupBox2.Controls.Add(checkBoxDaCanBang);
            groupBox2.Controls.Add(checkBoxPhieuTam);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 89);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 120);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Trạng thái";
            // 
            // checkBoxDahuy
            // 
            checkBoxDahuy.AutoSize = true;
            checkBoxDahuy.Font = new Font("Segoe UI", 9F);
            checkBoxDahuy.Location = new Point(11, 86);
            checkBoxDahuy.Name = "checkBoxDahuy";
            checkBoxDahuy.Size = new Size(77, 24);
            checkBoxDahuy.TabIndex = 2;
            checkBoxDahuy.Text = "Đã hủy";
            checkBoxDahuy.UseVisualStyleBackColor = true;
            checkBoxDahuy.CheckedChanged += checkBoxDahuy_CheckedChanged;
            // 
            // checkBoxDaCanBang
            // 
            checkBoxDaCanBang.AutoSize = true;
            checkBoxDaCanBang.Font = new Font("Segoe UI", 9F);
            checkBoxDaCanBang.Location = new Point(11, 56);
            checkBoxDaCanBang.Name = "checkBoxDaCanBang";
            checkBoxDaCanBang.Size = new Size(143, 24);
            checkBoxDaCanBang.TabIndex = 1;
            checkBoxDaCanBang.Text = "Đã cân bằng kho";
            checkBoxDaCanBang.UseVisualStyleBackColor = true;
            checkBoxDaCanBang.CheckedChanged += checkBoxDaCanBang_CheckedChanged;
            // 
            // checkBoxPhieuTam
            // 
            checkBoxPhieuTam.AutoSize = true;
            checkBoxPhieuTam.Font = new Font("Segoe UI", 9F);
            checkBoxPhieuTam.Location = new Point(11, 26);
            checkBoxPhieuTam.Name = "checkBoxPhieuTam";
            checkBoxPhieuTam.Size = new Size(97, 24);
            checkBoxPhieuTam.TabIndex = 0;
            checkBoxPhieuTam.Text = "Phiếu tạm";
            checkBoxPhieuTam.UseVisualStyleBackColor = true;
            checkBoxPhieuTam.CheckedChanged += checkBoxPhieuTam_CheckedChanged;
            // 
            // buttonThemKiemKho
            // 
            buttonThemKiemKho.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonThemKiemKho.BackColor = Color.LimeGreen;
            buttonThemKiemKho.Location = new Point(989, 9);
            buttonThemKiemKho.Name = "buttonThemKiemKho";
            buttonThemKiemKho.Size = new Size(130, 40);
            buttonThemKiemKho.TabIndex = 0;
            buttonThemKiemKho.Text = "+ Kiểm kho";
            buttonThemKiemKho.UseVisualStyleBackColor = false;
            buttonThemKiemKho.Click += buttonThemKiemKho_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(149, 25);
            label1.TabIndex = 4;
            label1.Text = "Phiếu kiểm kho";
            // 
            // panel3
            // 
            panel3.Controls.Add(groupBox1);
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(label1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(251, 652);
            panel3.TabIndex = 5;
            // 
            // dataGridViewdsPhieuKiemKho
            // 
            dataGridViewdsPhieuKiemKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsPhieuKiemKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewdsPhieuKiemKho.BackgroundColor = SystemColors.Window;
            dataGridViewdsPhieuKiemKho.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridViewdsPhieuKiemKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewdsPhieuKiemKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewdsPhieuKiemKho.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridViewdsPhieuKiemKho.Dock = DockStyle.Fill;
            dataGridViewdsPhieuKiemKho.Location = new Point(251, 57);
            dataGridViewdsPhieuKiemKho.MultiSelect = false;
            dataGridViewdsPhieuKiemKho.Name = "dataGridViewdsPhieuKiemKho";
            dataGridViewdsPhieuKiemKho.RowHeadersVisible = false;
            dataGridViewdsPhieuKiemKho.RowHeadersWidth = 51;
            dataGridViewdsPhieuKiemKho.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewdsPhieuKiemKho.Size = new Size(1131, 595);
            dataGridViewdsPhieuKiemKho.TabIndex = 38;
            dataGridViewdsPhieuKiemKho.CellDoubleClick += dataGridViewdsPhieuKiemKho_CellDoubleClick;
            dataGridViewdsPhieuKiemKho.CellValueChanged += dataGridViewdsPhieuKiemKho_CellValueChanged;
            dataGridViewdsPhieuKiemKho.CurrentCellDirtyStateChanged += dataGridViewdsPhieuKiemKho_CurrentCellDirtyStateChanged;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ButtonHighlight;
            panel4.Controls.Add(pictureBox1);
            panel4.Controls.Add(textBoxTimNV);
            panel4.Location = new Point(6, 6);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(5, 2, 5, 2);
            panel4.Size = new Size(425, 37);
            panel4.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Image = Properties.Resources.search;
            pictureBox1.Location = new Point(8, 5);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 25);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBoxTimNV
            // 
            textBoxTimNV.BorderStyle = BorderStyle.None;
            textBoxTimNV.Location = new Point(54, 5);
            textBoxTimNV.Multiline = true;
            textBoxTimNV.Name = "textBoxTimNV";
            textBoxTimNV.PlaceholderText = "Tìm theo mã phiếu kiểm";
            textBoxTimNV.Size = new Size(354, 25);
            textBoxTimNV.TabIndex = 1;
            textBoxTimNV.Tag = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(251, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1131, 57);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.Controls.Add(buttonGopPhieu);
            panel2.Controls.Add(buttonX);
            panel2.Controls.Add(labelSoX);
            panel2.Controls.Add(buttonTimKiem);
            panel2.Controls.Add(buttonThemKiemKho);
            panel2.Controls.Add(comboBoxLoaiTimKiem);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1131, 57);
            panel2.TabIndex = 6;
            // 
            // buttonGopPhieu
            // 
            buttonGopPhieu.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonGopPhieu.BackColor = Color.LimeGreen;
            buttonGopPhieu.Location = new Point(853, 9);
            buttonGopPhieu.Name = "buttonGopPhieu";
            buttonGopPhieu.Size = new Size(130, 40);
            buttonGopPhieu.TabIndex = 53;
            buttonGopPhieu.Text = "Gộp phiếu";
            buttonGopPhieu.UseVisualStyleBackColor = false;
            buttonGopPhieu.Click += buttonGopPhieu_Click;
            // 
            // buttonX
            // 
            buttonX.BackColor = SystemColors.Control;
            buttonX.FlatAppearance.BorderColor = SystemColors.Control;
            buttonX.FlatAppearance.BorderSize = 0;
            buttonX.ForeColor = SystemColors.ControlText;
            buttonX.Location = new Point(806, 15);
            buttonX.Name = "buttonX";
            buttonX.Size = new Size(41, 29);
            buttonX.TabIndex = 52;
            buttonX.TabStop = false;
            buttonX.Text = "X";
            buttonX.UseVisualStyleBackColor = false;
            buttonX.Visible = false;
            buttonX.Click += buttonX_Click;
            // 
            // labelSoX
            // 
            labelSoX.AutoSize = true;
            labelSoX.Location = new Point(616, 19);
            labelSoX.Name = "labelSoX";
            labelSoX.RightToLeft = RightToLeft.No;
            labelSoX.Size = new Size(50, 20);
            labelSoX.TabIndex = 51;
            labelSoX.Text = "label1";
            labelSoX.TextAlign = ContentAlignment.MiddleCenter;
            labelSoX.Visible = false;
            // 
            // buttonTimKiem
            // 
            buttonTimKiem.Location = new Point(516, 15);
            buttonTimKiem.Name = "buttonTimKiem";
            buttonTimKiem.Size = new Size(94, 29);
            buttonTimKiem.TabIndex = 4;
            buttonTimKiem.Text = "Tim kiem";
            buttonTimKiem.UseVisualStyleBackColor = true;
            buttonTimKiem.Click += buttonTimKiem_Click;
            // 
            // comboBoxLoaiTimKiem
            // 
            comboBoxLoaiTimKiem.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxLoaiTimKiem.FormattingEnabled = true;
            comboBoxLoaiTimKiem.Location = new Point(359, 16);
            comboBoxLoaiTimKiem.Name = "comboBoxLoaiTimKiem";
            comboBoxLoaiTimKiem.Size = new Size(151, 28);
            comboBoxLoaiTimKiem.TabIndex = 3;
            comboBoxLoaiTimKiem.SelectedIndexChanged += comboBoxLoaiTimKiem_SelectedIndexChanged;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonHighlight;
            panel5.Controls.Add(pictureBox2);
            panel5.Controls.Add(textBoxTimPhieuKiem);
            panel5.Location = new Point(6, 10);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(5, 2, 5, 2);
            panel5.Size = new Size(347, 41);
            panel5.TabIndex = 2;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.Image = Properties.Resources.search;
            pictureBox2.Location = new Point(8, 7);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(40, 25);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // textBoxTimPhieuKiem
            // 
            textBoxTimPhieuKiem.BorderStyle = BorderStyle.None;
            textBoxTimPhieuKiem.Location = new Point(68, 7);
            textBoxTimPhieuKiem.Multiline = true;
            textBoxTimPhieuKiem.Name = "textBoxTimPhieuKiem";
            textBoxTimPhieuKiem.PlaceholderText = "Tìm theo tên thuốc";
            textBoxTimPhieuKiem.Size = new Size(260, 25);
            textBoxTimPhieuKiem.TabIndex = 1;
            textBoxTimPhieuKiem.Tag = "";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxNhanVien);
            groupBox1.Location = new Point(12, 241);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 125);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // comboBoxNhanVien
            // 
            comboBoxNhanVien.FormattingEnabled = true;
            comboBoxNhanVien.Location = new Point(14, 52);
            comboBoxNhanVien.Name = "comboBoxNhanVien";
            comboBoxNhanVien.Size = new Size(151, 28);
            comboBoxNhanVien.TabIndex = 0;
            comboBoxNhanVien.SelectedIndexChanged += comboBoxNhanVien_SelectedIndexChanged;
            // 
            // KiemKho
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(dataGridViewdsPhieuKiemKho);
            Controls.Add(panel1);
            Controls.Add(panel3);
            FormBorderStyle = FormBorderStyle.None;
            Name = "KiemKho";
            Text = "KiemKho";
            Load += KiemKho_Load;
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsPhieuKiemKho).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button buttonThemKiemKho;
        private Label label1;
        private GroupBox groupBox2;
        private CheckBox checkBoxDahuy;
        private CheckBox checkBoxDaCanBang;
        private CheckBox checkBoxPhieuTam;
        private Panel panel3;
        private DataGridView dataGridViewdsPhieuKiemKho;
        private Panel panel4;
        private PictureBox pictureBox1;
        private TextBox textBoxTimNV;
        private Panel panel1;
        private Panel panel2;
        private Button buttonTimKiem;
        private ComboBox comboBoxLoaiTimKiem;
        private Panel panel5;
        private PictureBox pictureBox2;
        private TextBox textBoxTimPhieuKiem;
        private Button buttonX;
        private Label labelSoX;
        private Button buttonGopPhieu;
        private GroupBox groupBox1;
        private ComboBox comboBoxNhanVien;
    }
}