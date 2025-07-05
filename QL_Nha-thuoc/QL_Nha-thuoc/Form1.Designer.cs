namespace QL_Nha_thuoc
{
    partial class Form1
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
            button1 = new Button();
            textBoxGiamGia = new TextBox();
            textBoxSoTienKhachDua = new TextBox();
            comboBoxTaiKhoan = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            textBoxSoTienCanTra = new TextBox();
            textBoxTienTraLai = new TextBox();
            splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 96);
            button1.Name = "button1";
            button1.Size = new Size(94, 10);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBoxGiamGia
            // 
            textBoxGiamGia.BackColor = SystemColors.Window;
            textBoxGiamGia.Font = new Font("Segoe UI", 12F);
            textBoxGiamGia.Location = new Point(457, 502);
            textBoxGiamGia.Name = "textBoxGiamGia";
            textBoxGiamGia.ReadOnly = true;
            textBoxGiamGia.Size = new Size(151, 34);
            textBoxGiamGia.TabIndex = 52;
            // 
            // textBoxSoTienKhachDua
            // 
            textBoxSoTienKhachDua.Font = new Font("Segoe UI", 12F);
            textBoxSoTienKhachDua.Location = new Point(420, 562);
            textBoxSoTienKhachDua.Name = "textBoxSoTienKhachDua";
            textBoxSoTienKhachDua.Size = new Size(151, 34);
            textBoxSoTienKhachDua.TabIndex = 43;
            // 
            // comboBoxTaiKhoan
            // 
            comboBoxTaiKhoan.FormattingEnabled = true;
            comboBoxTaiKhoan.Location = new Point(-225, -3);
            comboBoxTaiKhoan.Name = "comboBoxTaiKhoan";
            comboBoxTaiKhoan.Size = new Size(196, 28);
            comboBoxTaiKhoan.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(-197, 313);
            label2.Name = "label2";
            label2.Size = new Size(90, 28);
            label2.TabIndex = 2;
            label2.Text = "Giam gia";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(-249, 226);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 1;
            label1.Text = "Tong tien hang";
            // 
            // textBoxSoTienCanTra
            // 
            textBoxSoTienCanTra.BackColor = SystemColors.Window;
            textBoxSoTienCanTra.Enabled = false;
            textBoxSoTienCanTra.Font = new Font("Segoe UI", 12F);
            textBoxSoTienCanTra.Location = new Point(487, 413);
            textBoxSoTienCanTra.Name = "textBoxSoTienCanTra";
            textBoxSoTienCanTra.ReadOnly = true;
            textBoxSoTienCanTra.Size = new Size(151, 34);
            textBoxSoTienCanTra.TabIndex = 51;
            // 
            // textBoxTienTraLai
            // 
            textBoxTienTraLai.Font = new Font("Segoe UI", 12F);
            textBoxTienTraLai.Location = new Point(387, 633);
            textBoxTienTraLai.Name = "textBoxTienTraLai";
            textBoxTienTraLai.Size = new Size(151, 34);
            textBoxTienTraLai.TabIndex = 53;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 197);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(textBoxTienTraLai);
            splitContainer1.Panel2.Controls.Add(textBoxSoTienCanTra);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(comboBoxTaiKhoan);
            splitContainer1.Panel2.Controls.Add(textBoxSoTienKhachDua);
            splitContainer1.Panel2.Controls.Add(textBoxGiamGia);
            splitContainer1.Size = new Size(1281, 231);
            splitContainer1.SplitterDistance = 914;
            splitContainer1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1337, 859);
            Controls.Add(splitContainer1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private TextBox textBoxGiamGia;
        private TextBox textBoxSoTienKhachDua;
        private ComboBox comboBoxTaiKhoan;
        private Label label2;
        private Label label1;
        private TextBox textBoxSoTienCanTra;
        private TextBox textBoxTienTraLai;
        private SplitContainer splitContainer1;
    }
}