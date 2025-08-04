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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            groupBox2 = new GroupBox();
            checkBox3 = new CheckBox();
            checkBoxDaCanBang = new CheckBox();
            checkBoxPhieuTam = new CheckBox();
            groupBox1 = new GroupBox();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            buttonThemKiemKho = new Button();
            label1 = new Label();
            panel3 = new Panel();
            groupBox3 = new GroupBox();
            textBox1 = new TextBox();
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
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewdsPhieuKiemKho).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonHighlight;
            groupBox2.Controls.Add(checkBox3);
            groupBox2.Controls.Add(checkBoxDaCanBang);
            groupBox2.Controls.Add(checkBoxPhieuTam);
            groupBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox2.Location = new Point(3, 271);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(228, 120);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Trạng thái";
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Font = new Font("Segoe UI", 9F);
            checkBox3.Location = new Point(11, 86);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(77, 24);
            checkBox3.TabIndex = 2;
            checkBox3.Text = "Đã hủy";
            checkBox3.UseVisualStyleBackColor = true;
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
            checkBoxPhieuTam.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonHighlight;
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox1.Location = new Point(3, 94);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(228, 123);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thời gian";
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Font = new Font("Segoe UI", 9F);
            radioButton2.Location = new Point(23, 77);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(124, 24);
            radioButton2.TabIndex = 1;
            radioButton2.TabStop = true;
            radioButton2.Text = "Lựa chọn khác";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Font = new Font("Segoe UI", 9F);
            radioButton1.Location = new Point(23, 38);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 24);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "Tháng này";
            radioButton1.UseVisualStyleBackColor = true;
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
            panel3.Controls.Add(groupBox3);
            panel3.Controls.Add(groupBox2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(groupBox1);
            panel3.Dock = DockStyle.Left;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(251, 652);
            panel3.TabIndex = 5;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = SystemColors.ButtonHighlight;
            groupBox3.Controls.Add(textBox1);
            groupBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            groupBox3.Location = new Point(14, 438);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(228, 102);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Người tạo";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 49);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(196, 27);
            textBox1.TabIndex = 0;
            // 
            // dataGridViewdsPhieuKiemKho
            // 
            dataGridViewdsPhieuKiemKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewdsPhieuKiemKho.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewdsPhieuKiemKho.BackgroundColor = SystemColors.Window;
            dataGridViewdsPhieuKiemKho.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridViewdsPhieuKiemKho.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewdsPhieuKiemKho.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridViewdsPhieuKiemKho.DefaultCellStyle = dataGridViewCellStyle4;
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
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
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
            ResumeLayout(false);
        }

        #endregion
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Button buttonThemKiemKho;
        private Label label1;
        private GroupBox groupBox2;
        private CheckBox checkBox3;
        private CheckBox checkBoxDaCanBang;
        private CheckBox checkBoxPhieuTam;
        private Panel panel3;
        private GroupBox groupBox3;
        private TextBox textBox1;
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
    }
}