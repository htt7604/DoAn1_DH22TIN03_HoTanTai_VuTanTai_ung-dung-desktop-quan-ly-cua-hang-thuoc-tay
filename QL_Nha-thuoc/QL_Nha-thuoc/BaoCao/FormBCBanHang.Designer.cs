namespace QL_Nha_thuoc.BaoCao
{
    partial class FormBCBanHang
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
            splitContainer1 = new SplitContainer();
            groupBox2 = new GroupBox();
            dateTimePickerDenNgay = new DateTimePicker();
            dateTimePickerTuNgay = new DateTimePicker();
            checkBoxLuaChonThoiGian = new CheckBox();
            comboBoxkhoanthoigian = new ComboBox();
            groupBox1 = new GroupBox();
            radioButtonqtthoigian = new RadioButton();
            radioButtonqtnhanvien = new RadioButton();
            chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).BeginInit();
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
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(chartDoanhThu);
            splitContainer1.Size = new Size(1382, 652);
            splitContainer1.SplitterDistance = 280;
            splitContainer1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dateTimePickerDenNgay);
            groupBox2.Controls.Add(dateTimePickerTuNgay);
            groupBox2.Controls.Add(checkBoxLuaChonThoiGian);
            groupBox2.Controls.Add(comboBoxkhoanthoigian);
            groupBox2.Location = new Point(12, 325);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(265, 292);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "thoi gian ";
            // 
            // dateTimePickerDenNgay
            // 
            dateTimePickerDenNgay.Location = new Point(6, 208);
            dateTimePickerDenNgay.Name = "dateTimePickerDenNgay";
            dateTimePickerDenNgay.Size = new Size(250, 27);
            dateTimePickerDenNgay.TabIndex = 3;
            // 
            // dateTimePickerTuNgay
            // 
            dateTimePickerTuNgay.Location = new Point(6, 138);
            dateTimePickerTuNgay.Name = "dateTimePickerTuNgay";
            dateTimePickerTuNgay.Size = new Size(250, 27);
            dateTimePickerTuNgay.TabIndex = 2;
            // 
            // checkBoxLuaChonThoiGian
            // 
            checkBoxLuaChonThoiGian.AutoSize = true;
            checkBoxLuaChonThoiGian.Location = new Point(15, 91);
            checkBoxLuaChonThoiGian.Name = "checkBoxLuaChonThoiGian";
            checkBoxLuaChonThoiGian.Size = new Size(101, 24);
            checkBoxLuaChonThoiGian.TabIndex = 1;
            checkBoxLuaChonThoiGian.Text = "checkBox1";
            checkBoxLuaChonThoiGian.UseVisualStyleBackColor = true;
            checkBoxLuaChonThoiGian.CheckedChanged += checkBoxLuaChonThoiGian_CheckedChanged;
            // 
            // comboBoxkhoanthoigian
            // 
            comboBoxkhoanthoigian.FormattingEnabled = true;
            comboBoxkhoanthoigian.Location = new Point(15, 41);
            comboBoxkhoanthoigian.Name = "comboBoxkhoanthoigian";
            comboBoxkhoanthoigian.Size = new Size(151, 28);
            comboBoxkhoanthoigian.TabIndex = 0;
            comboBoxkhoanthoigian.SelectedIndexChanged += comboBoxkhoanthoigian_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButtonqtthoigian);
            groupBox1.Controls.Add(radioButtonqtnhanvien);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(222, 203);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Moi quan tam";
            // 
            // radioButtonqtthoigian
            // 
            radioButtonqtthoigian.AutoSize = true;
            radioButtonqtthoigian.Location = new Point(40, 104);
            radioButtonqtthoigian.Name = "radioButtonqtthoigian";
            radioButtonqtthoigian.Size = new Size(96, 24);
            radioButtonqtthoigian.TabIndex = 1;
            radioButtonqtthoigian.TabStop = true;
            radioButtonqtthoigian.Text = "Thoi gian ";
            radioButtonqtthoigian.UseVisualStyleBackColor = true;
            radioButtonqtthoigian.CheckedChanged += radioButtonqtthoigian_CheckedChanged;
            // 
            // radioButtonqtnhanvien
            // 
            radioButtonqtnhanvien.AutoSize = true;
            radioButtonqtnhanvien.Location = new Point(40, 52);
            radioButtonqtnhanvien.Name = "radioButtonqtnhanvien";
            radioButtonqtnhanvien.Size = new Size(100, 24);
            radioButtonqtnhanvien.TabIndex = 0;
            radioButtonqtnhanvien.TabStop = true;
            radioButtonqtnhanvien.Text = "Nhan vien ";
            radioButtonqtnhanvien.UseVisualStyleBackColor = true;
            radioButtonqtnhanvien.CheckedChanged += radioButtonqtnhanvien_CheckedChanged;
            // 
            // chartDoanhThu
            // 
            chartArea2.Name = "ChartArea1";
            chartDoanhThu.ChartAreas.Add(chartArea2);
            chartDoanhThu.Dock = DockStyle.Fill;
            legend2.Name = "Legend1";
            chartDoanhThu.Legends.Add(legend2);
            chartDoanhThu.Location = new Point(0, 0);
            chartDoanhThu.Name = "chartDoanhThu";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartDoanhThu.Series.Add(series2);
            chartDoanhThu.Size = new Size(1098, 652);
            chartDoanhThu.TabIndex = 0;
            chartDoanhThu.Text = "chart1";
            // 
            // FormBCBanHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1382, 652);
            Controls.Add(splitContainer1);
            Name = "FormBCBanHang";
            Text = "FormBCBanHang";
            Load += FormBCBanHang_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)chartDoanhThu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox groupBox2;
        private DateTimePicker dateTimePickerDenNgay;
        private DateTimePicker dateTimePickerTuNgay;
        private CheckBox checkBoxLuaChonThoiGian;
        private ComboBox comboBoxkhoanthoigian;
        private GroupBox groupBox1;
        private RadioButton radioButtonqtthoigian;
        private RadioButton radioButtonqtnhanvien;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
    }
}