namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlitemtkNganHang
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelTenNganHang = new Label();
            labelSTK = new Label();
            labelTenTaiKhoan = new Label();
            SuspendLayout();
            // 
            // labelTenNganHang
            // 
            labelTenNganHang.AutoSize = true;
            labelTenNganHang.Font = new Font("Microsoft Sans Serif", 7.20000029F);
            labelTenNganHang.Location = new Point(12, 9);
            labelTenNganHang.Name = "labelTenNganHang";
            labelTenNganHang.Size = new Size(44, 16);
            labelTenNganHang.TabIndex = 2;
            labelTenNganHang.Text = "label1";
            // 
            // labelSTK
            // 
            labelSTK.AutoSize = true;
            labelSTK.Font = new Font("Microsoft Sans Serif", 7.20000029F);
            labelSTK.Location = new Point(12, 43);
            labelSTK.Name = "labelSTK";
            labelSTK.Size = new Size(44, 16);
            labelSTK.TabIndex = 1;
            labelSTK.Text = "label2";
            // 
            // labelTenTaiKhoan
            // 
            labelTenTaiKhoan.AutoSize = true;
            labelTenTaiKhoan.Font = new Font("Microsoft Sans Serif", 7.20000029F);
            labelTenTaiKhoan.Location = new Point(149, 9);
            labelTenTaiKhoan.Name = "labelTenTaiKhoan";
            labelTenTaiKhoan.Size = new Size(44, 16);
            labelTenTaiKhoan.TabIndex = 0;
            labelTenTaiKhoan.Text = "label1";
            // 
            // UserControlitemtkNganHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(labelTenNganHang);
            Controls.Add(labelSTK);
            Controls.Add(labelTenTaiKhoan);
            Name = "UserControlitemtkNganHang";
            Size = new Size(340, 67);
            Load += UserControlitemtkNganHang_Load;
            Click += UserControlitemtkNganHang_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenNganHang;
        private Label labelSTK;
        private Label labelTenTaiKhoan;
    }
}
