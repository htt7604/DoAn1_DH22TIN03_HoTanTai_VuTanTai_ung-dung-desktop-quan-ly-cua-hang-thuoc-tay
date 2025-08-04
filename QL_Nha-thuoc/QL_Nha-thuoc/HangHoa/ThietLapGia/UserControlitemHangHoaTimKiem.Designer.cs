namespace QL_Nha_thuoc.HangHoa.ThietLapGia
{
    partial class UserControlitemHangHoaTimKiem
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
            labelTenHangHoa = new Label();
            labelMaHangHoa = new Label();
            labelDonViTinh = new Label();
            SuspendLayout();
            // 
            // labelTenHangHoa
            // 
            labelTenHangHoa.AutoSize = true;
            labelTenHangHoa.Font = new Font("Segoe UI", 10F);
            labelTenHangHoa.Location = new Point(16, 11);
            labelTenHangHoa.Name = "labelTenHangHoa";
            labelTenHangHoa.Size = new Size(55, 23);
            labelTenHangHoa.TabIndex = 0;
            labelTenHangHoa.Text = "label1";
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.AutoSize = true;
            labelMaHangHoa.Location = new Point(16, 34);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(50, 20);
            labelMaHangHoa.TabIndex = 1;
            labelMaHangHoa.Text = "label1";
            // 
            // labelDonViTinh
            // 
            labelDonViTinh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelDonViTinh.AutoSize = true;
            labelDonViTinh.ForeColor = SystemColors.HotTrack;
            labelDonViTinh.Location = new Point(260, 14);
            labelDonViTinh.Name = "labelDonViTinh";
            labelDonViTinh.Size = new Size(50, 20);
            labelDonViTinh.TabIndex = 2;
            labelDonViTinh.Text = "label1";
            // 
            // UserControlitemHangHoaTimKiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelDonViTinh);
            Controls.Add(labelMaHangHoa);
            Controls.Add(labelTenHangHoa);
            Name = "UserControlitemHangHoaTimKiem";
            Size = new Size(338, 61);
            Click += UserControlitemHangHoa_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenHangHoa;
        private Label labelMaHangHoa;
        private Label labelDonViTinh;
    }
}
