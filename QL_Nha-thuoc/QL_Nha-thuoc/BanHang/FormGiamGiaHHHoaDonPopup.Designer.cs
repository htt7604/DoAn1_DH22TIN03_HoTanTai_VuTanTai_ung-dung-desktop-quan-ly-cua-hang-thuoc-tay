namespace QL_Nha_thuoc.BanHang
{
    partial class FormGiamGiaHHHoaDonPopup
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxDonGia = new TextBox();
            textBoxGiamGia = new TextBox();
            textBoxGiaBan = new TextBox();
            buttonVND = new Button();
            buttonPhanTram = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 22);
            label1.Name = "label1";
            label1.Size = new Size(62, 20);
            label1.TabIndex = 0;
            label1.Text = "Đơn giá";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 76);
            label2.Name = "label2";
            label2.Size = new Size(69, 20);
            label2.TabIndex = 1;
            label2.Text = "Giảm giá";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 132);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 2;
            label3.Text = "Giá bán";
            // 
            // textBoxDonGia
            // 
            textBoxDonGia.Location = new Point(99, 19);
            textBoxDonGia.Name = "textBoxDonGia";
            textBoxDonGia.Size = new Size(219, 27);
            textBoxDonGia.TabIndex = 3;
            // 
            // textBoxGiamGia
            // 
            textBoxGiamGia.Location = new Point(99, 73);
            textBoxGiamGia.Name = "textBoxGiamGia";
            textBoxGiamGia.Size = new Size(115, 27);
            textBoxGiamGia.TabIndex = 4;
            // 
            // textBoxGiaBan
            // 
            textBoxGiaBan.Location = new Point(99, 125);
            textBoxGiaBan.Name = "textBoxGiaBan";
            textBoxGiaBan.Size = new Size(219, 27);
            textBoxGiaBan.TabIndex = 5;
            textBoxGiaBan.TextChanged += GiaBan_TextChanged;
            // 
            // buttonVND
            // 
            buttonVND.Location = new Point(220, 73);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(51, 29);
            buttonVND.TabIndex = 6;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += buttonVND_Click;
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Location = new Point(277, 73);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(41, 29);
            buttonPhanTram.TabIndex = 7;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += buttonPhanTram_Click;
            // 
            // FormGiamGiaHHHoaDonPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 173);
            Controls.Add(buttonPhanTram);
            Controls.Add(buttonVND);
            Controls.Add(textBoxGiaBan);
            Controls.Add(textBoxGiamGia);
            Controls.Add(textBoxDonGia);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormGiamGiaHHHoaDonPopup";
            Text = "FormGiamGiaHHHoaDonPopup";
            FormClosed += FormGiamGiaHHHoaDonPopup_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxDonGia;
        private TextBox textBoxGiamGia;
        private TextBox textBoxGiaBan;
        private Button buttonVND;
        private Button buttonPhanTram;
    }
}