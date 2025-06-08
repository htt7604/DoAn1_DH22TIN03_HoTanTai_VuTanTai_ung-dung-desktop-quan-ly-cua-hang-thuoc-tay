namespace QL_Nha_thuoc.HangHoa.Them
{
    partial class FormThemNhomHangHoa
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
            buttonLuu = new Button();
            buttonBoQua = new Button();
            comboBoxLoaiHang = new ComboBox();
            label1 = new Label();
            textBoxTenNhom = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(332, 141);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 29);
            buttonLuu.TabIndex = 0;
            buttonLuu.Text = "Luu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // buttonBoQua
            // 
            buttonBoQua.Location = new Point(462, 141);
            buttonBoQua.Name = "buttonBoQua";
            buttonBoQua.Size = new Size(94, 29);
            buttonBoQua.TabIndex = 1;
            buttonBoQua.Text = "Bo qua";
            buttonBoQua.UseVisualStyleBackColor = true;
            // 
            // comboBoxLoaiHang
            // 
            comboBoxLoaiHang.FormattingEnabled = true;
            comboBoxLoaiHang.Location = new Point(180, 94);
            comboBoxLoaiHang.Name = "comboBoxLoaiHang";
            comboBoxLoaiHang.Size = new Size(226, 28);
            comboBoxLoaiHang.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.ForeColor = SystemColors.MenuHighlight;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(178, 28);
            label1.TabIndex = 3;
            label1.Text = "Them nhom hang";
            // 
            // textBoxTenNhom
            // 
            textBoxTenNhom.Location = new Point(180, 53);
            textBoxTenNhom.Name = "textBoxTenNhom";
            textBoxTenNhom.Size = new Size(226, 27);
            textBoxTenNhom.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 56);
            label2.Name = "label2";
            label2.Size = new Size(74, 20);
            label2.TabIndex = 5;
            label2.Text = "Ten nhom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 102);
            label3.Name = "label3";
            label3.Size = new Size(37, 20);
            label3.TabIndex = 6;
            label3.Text = "Loai";
            // 
            // FormThemNhomHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 182);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxTenNhom);
            Controls.Add(label1);
            Controls.Add(comboBoxLoaiHang);
            Controls.Add(buttonBoQua);
            Controls.Add(buttonLuu);
            Name = "FormThemNhomHangHoa";
            Text = "FormThemNhomHangHoa";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLuu;
        private Button buttonBoQua;
        private ComboBox comboBoxLoaiHang;
        private Label label1;
        private TextBox textBoxTenNhom;
        private Label label2;
        private Label label3;
    }
}