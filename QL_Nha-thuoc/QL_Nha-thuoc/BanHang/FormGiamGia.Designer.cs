namespace QL_Nha_thuoc.BanHang
{
    partial class FormGiamGia
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
            textBoxGiaTriGiamGiaTongHang = new TextBox();
            buttonPhanTram = new Button();
            buttonVND = new Button();
            label6 = new Label();
            SuspendLayout();
            // 
            // textBoxGiaTriGiamGiaTongHang
            // 
            textBoxGiaTriGiamGiaTongHang.Location = new Point(108, 23);
            textBoxGiaTriGiamGiaTongHang.Name = "textBoxGiaTriGiamGiaTongHang";
            textBoxGiaTriGiamGiaTongHang.Size = new Size(141, 27);
            textBoxGiaTriGiamGiaTongHang.TabIndex = 10;
            textBoxGiaTriGiamGiaTongHang.TextChanged += textBoxGiaTriGiamGiaTongHang_TextChanged;
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Location = new Point(344, 23);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(58, 29);
            buttonPhanTram.TabIndex = 9;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += buttonPhanTram_Click;
            // 
            // buttonVND
            // 
            buttonVND.Location = new Point(271, 23);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(67, 29);
            buttonVND.TabIndex = 8;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += buttonVND_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(12, 23);
            label6.Name = "label6";
            label6.Size = new Size(90, 28);
            label6.TabIndex = 7;
            label6.Text = "Giảm giá";
            // 
            // FormGiamGia
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 71);
            Controls.Add(textBoxGiaTriGiamGiaTongHang);
            Controls.Add(buttonPhanTram);
            Controls.Add(buttonVND);
            Controls.Add(label6);
            Name = "FormGiamGia";
            Text = "FormGiamGia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxGiaTriGiamGiaTongHang;
        private Button buttonPhanTram;
        private Button buttonVND;
        private Label label6;
    }
}