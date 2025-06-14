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
            label1 = new Label();
            flowLayoutPanelThietLapGia = new FlowLayoutPanel();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(comboBox1);
            splitContainer1.Panel1.Controls.Add(label1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(flowLayoutPanelThietLapGia);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 234;
            splitContainer1.TabIndex = 0;
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
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(47, 164);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 1;
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
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanelThietLapGia;
        private ComboBox comboBox1;
    }
}