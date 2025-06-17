namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlKhachHangitem
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
            labelTenKachHang = new Label();
            labelMaKhachHang = new Label();
            SuspendLayout();
            // 
            // labelTenKachHang
            // 
            labelTenKachHang.AutoSize = true;
            labelTenKachHang.Font = new Font("Segoe UI", 8F);
            labelTenKachHang.Location = new Point(27, 7);
            labelTenKachHang.Name = "labelTenKachHang";
            labelTenKachHang.Size = new Size(45, 19);
            labelTenKachHang.TabIndex = 0;
            labelTenKachHang.Text = "label1";
            // 
            // labelMaKhachHang
            // 
            labelMaKhachHang.AutoSize = true;
            labelMaKhachHang.Font = new Font("Segoe UI", 6F);
            labelMaKhachHang.Location = new Point(27, 28);
            labelMaKhachHang.Name = "labelMaKhachHang";
            labelMaKhachHang.Size = new Size(30, 12);
            labelMaKhachHang.TabIndex = 1;
            labelMaKhachHang.Text = "label2";
            // 
            // UserControlKhachHangitem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(labelMaKhachHang);
            Controls.Add(labelTenKachHang);
            Name = "UserControlKhachHangitem";
            Size = new Size(351, 54);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenKachHang;
        private Label labelMaKhachHang;
    }
}
