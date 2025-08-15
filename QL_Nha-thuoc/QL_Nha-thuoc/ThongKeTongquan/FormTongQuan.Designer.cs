namespace QL_Nha_thuoc.ThongKeTongquan
{
    partial class FormTongQuan
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel1 = new Panel();
            panel4 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel6 = new Panel();
            comboBoxThoiGianLocDoanhThu = new ComboBox();
            label6 = new Label();
            panel3 = new Panel();
            chartTop10HangHoa = new System.Windows.Forms.DataVisualization.Charting.Chart();
            panel2 = new Panel();
            label4 = new Label();
            labelSoTienDoanhThu = new Label();
            labelSoHoaDon = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel6.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartTop10HangHoa).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1382, 1055);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.Window;
            panel4.Controls.Add(tableLayoutPanel1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 196);
            panel4.Name = "panel4";
            panel4.Size = new Size(1382, 859);
            panel4.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel6, 0, 0);
            tableLayoutPanel1.Controls.Add(panel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 7.15990448F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 92.8400955F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1382, 859);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // panel6
            // 
            panel6.Controls.Add(comboBoxThoiGianLocDoanhThu);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(1376, 54);
            panel6.TabIndex = 4;
            // 
            // comboBoxThoiGianLocDoanhThu
            // 
            comboBoxThoiGianLocDoanhThu.FormattingEnabled = true;
            comboBoxThoiGianLocDoanhThu.Location = new Point(371, 10);
            comboBoxThoiGianLocDoanhThu.Name = "comboBoxThoiGianLocDoanhThu";
            comboBoxThoiGianLocDoanhThu.Size = new Size(151, 28);
            comboBoxThoiGianLocDoanhThu.TabIndex = 3;
            comboBoxThoiGianLocDoanhThu.SelectedIndexChanged += comboBoxThoiGianLocDoanhThu_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label6.Location = new Point(9, 13);
            label6.Name = "label6";
            label6.Size = new Size(343, 25);
            label6.TabIndex = 3;
            label6.Text = "TOP 10 SẢN PHẨM BÁN CHẠY NHẤT";
            // 
            // panel3
            // 
            panel3.Controls.Add(chartTop10HangHoa);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(3, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(1376, 772);
            panel3.TabIndex = 5;
            // 
            // chartTop10HangHoa
            // 
            chartTop10HangHoa.BorderlineColor = Color.IndianRed;
            chartArea2.Name = "ChartArea1";
            chartTop10HangHoa.ChartAreas.Add(chartArea2);
            chartTop10HangHoa.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartTop10HangHoa.Legends.Add(legend2);
            chartTop10HangHoa.Location = new Point(0, 0);
            chartTop10HangHoa.Name = "chartTop10HangHoa";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartTop10HangHoa.Series.Add(series2);
            chartTop10HangHoa.Size = new Size(1376, 772);
            chartTop10HangHoa.TabIndex = 4;
            chartTop10HangHoa.Text = "chart1";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(labelSoTienDoanhThu);
            panel2.Controls.Add(labelSoHoaDon);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1382, 196);
            panel2.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F);
            label4.Location = new Point(39, 145);
            label4.Name = "label4";
            label4.Size = new Size(99, 25);
            label4.TabIndex = 3;
            label4.Text = "doanh thu";
            // 
            // labelSoTienDoanhThu
            // 
            labelSoTienDoanhThu.AutoSize = true;
            labelSoTienDoanhThu.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelSoTienDoanhThu.Location = new Point(38, 99);
            labelSoTienDoanhThu.Name = "labelSoTienDoanhThu";
            labelSoTienDoanhThu.Size = new Size(40, 46);
            labelSoTienDoanhThu.TabIndex = 2;
            labelSoTienDoanhThu.Text = "0";
            // 
            // labelSoHoaDon
            // 
            labelSoHoaDon.AutoSize = true;
            labelSoHoaDon.Font = new Font("Segoe UI", 11F);
            labelSoHoaDon.Location = new Point(39, 74);
            labelSoHoaDon.Name = "labelSoHoaDon";
            labelSoHoaDon.Size = new Size(97, 25);
            labelSoHoaDon.TabIndex = 1;
            labelSoHoaDon.Text = "0 hoa don";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(23, 9);
            label1.Name = "label1";
            label1.Size = new Size(391, 35);
            label1.TabIndex = 0;
            label1.Text = "KẾT QUẢ BÁN HÀNG HÔM NAY";
            // 
            // FormTongQuan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1382, 1055);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTongQuan";
            Text = "FormTongQuan";
            Load += FormTongQuan_Load;
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)chartTop10HangHoa).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private TableLayoutPanel tableLayoutPanel1;
        private ComboBox comboBoxThoiGianLocDoanhThu;
        private Panel panel6;
        private Label label6;
        private Panel panel2;
        private Label label4;
        private Label labelSoTienDoanhThu;
        private Label labelSoHoaDon;
        private Label label1;
        private Panel panel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTop10HangHoa;
    }
}