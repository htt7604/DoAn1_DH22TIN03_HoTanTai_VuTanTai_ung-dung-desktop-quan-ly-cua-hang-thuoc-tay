namespace QL_Nha_thuoc.HangHoa
{
    partial class FormThietLapGia
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
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            comboBoxNhomHang = new ComboBox();
            groupBox1 = new GroupBox();
            comboBoxLoc = new ComboBox();
            comboBoxLoaiGia = new ComboBox();
            label1 = new Label();
            flowLayoutPanelThietLapGia = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(groupBox2);
            splitContainer1.Panel1.Controls.Add(groupBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanelThietLapGia);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 234;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(comboBoxNhomHang);
            groupBox2.Location = new Point(12, 140);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(199, 125);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            groupBox2.Text = "Nhom hang";
            // 
            // comboBoxNhomHang
            // 
            comboBoxNhomHang.FormattingEnabled = true;
            comboBoxNhomHang.Location = new Point(22, 53);
            comboBoxNhomHang.Name = "comboBoxNhomHang";
            comboBoxNhomHang.Size = new Size(151, 28);
            comboBoxNhomHang.TabIndex = 1;
            comboBoxNhomHang.SelectedIndexChanged += comboBoxNhomHang_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(comboBoxLoc);
            groupBox1.Controls.Add(comboBoxLoaiGia);
            groupBox1.Location = new Point(13, 311);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(219, 86);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Giá Bán";
            // 
            // comboBoxLoc
            // 
            comboBoxLoc.FormattingEnabled = true;
            comboBoxLoc.Location = new Point(5, 41);
            comboBoxLoc.Name = "comboBoxLoc";
            comboBoxLoc.Size = new Size(41, 28);
            comboBoxLoc.TabIndex = 2;
            comboBoxLoc.SelectedIndexChanged += comboBoxLoc_SelectedIndexChanged;
            // 
            // comboBoxLoaiGia
            // 
            comboBoxLoaiGia.FormattingEnabled = true;
            comboBoxLoaiGia.Location = new Point(62, 41);
            comboBoxLoaiGia.Name = "comboBoxLoaiGia";
            comboBoxLoaiGia.Size = new Size(136, 28);
            comboBoxLoaiGia.TabIndex = 3;
            comboBoxLoaiGia.SelectedIndexChanged += comboBoxLoaiGia_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(47, 32);
            label1.Name = "label1";
            label1.Size = new Size(137, 28);
            label1.TabIndex = 0;
            label1.Text = "Thiet Lap Gia";
            // 
            // flowLayoutPanelThietLapGia
            // 
            flowLayoutPanelThietLapGia.BackColor = SystemColors.Control;
            flowLayoutPanelThietLapGia.Dock = DockStyle.Fill;
            flowLayoutPanelThietLapGia.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelThietLapGia.Location = new Point(0, 0);
            flowLayoutPanelThietLapGia.Name = "flowLayoutPanelThietLapGia";
            flowLayoutPanelThietLapGia.Size = new Size(1144, 652);
            flowLayoutPanelThietLapGia.TabIndex = 0;
            flowLayoutPanelThietLapGia.SizeChanged += flowLayoutPanelThietLapGia_SizeChanged;
            // 
            // FormThietLapGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            Name = "FormThietLapGia";
            Text = "FormThietLapGia";
            Load += FormThietLapGia_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelThietLapGia;
        private ComboBox comboBoxNhomHang;
        private GroupBox groupBox1;
        private ComboBox comboBoxLoc;
        private ComboBox comboBoxLoaiGia;
        private GroupBox groupBox2;
    }
}