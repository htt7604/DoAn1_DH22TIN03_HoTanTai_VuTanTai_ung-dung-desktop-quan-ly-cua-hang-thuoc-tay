namespace QL_Nha_thuoc.BanHang
{
    partial class FormQRThanhToan
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
            pictureBoxQR = new PictureBox();
            label1 = new Label();
            buttonIn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxQR
            // 
            pictureBoxQR.Location = new Point(71, 47);
            pictureBoxQR.Name = "pictureBoxQR";
            pictureBoxQR.Size = new Size(338, 417);
            pictureBoxQR.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxQR.TabIndex = 0;
            pictureBoxQR.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label1.Location = new Point(100, 9);
            label1.Name = "label1";
            label1.Size = new Size(284, 35);
            label1.TabIndex = 1;
            label1.Text = "Mã VietQR thanh toán ";
            // 
            // buttonIn
            // 
            buttonIn.Location = new Point(174, 479);
            buttonIn.Name = "buttonIn";
            buttonIn.Size = new Size(135, 48);
            buttonIn.TabIndex = 2;
            buttonIn.Text = "In mã";
            buttonIn.UseVisualStyleBackColor = true;
            buttonIn.Click += buttonIn_Click;
            // 
            // FormQRThanhToan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(518, 539);
            Controls.Add(buttonIn);
            Controls.Add(label1);
            Controls.Add(pictureBoxQR);
            Name = "FormQRThanhToan";
            Text = "FormQRThanhToan";
            ((System.ComponentModel.ISupportInitialize)pictureBoxQR).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBoxQR;
        private Label label1;
        private Button buttonIn;
    }
}