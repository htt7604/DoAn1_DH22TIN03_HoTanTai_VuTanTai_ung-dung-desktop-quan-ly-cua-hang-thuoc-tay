namespace QL_Nha_thuoc.HangHoa
{
    partial class UC_ItemThuoc
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
            labelTenHH = new Label();
            labelMaHH = new Label();
            labelGiaBanHH = new Label();
            labelTonHH = new Label();
            pictureBoxHinhAnhHH = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnhHH).BeginInit();
            SuspendLayout();
            // 
            // labelTenHH
            // 
            labelTenHH.AutoSize = true;
            labelTenHH.Font = new Font("Segoe UI", 12F);
            labelTenHH.Location = new Point(116, 0);
            labelTenHH.Name = "labelTenHH";
            labelTenHH.Size = new Size(65, 28);
            labelTenHH.TabIndex = 0;
            labelTenHH.Text = "label1";
            // 
            // labelMaHH
            // 
            labelMaHH.AutoSize = true;
            labelMaHH.Font = new Font("Segoe UI", 6F);
            labelMaHH.Location = new Point(125, 28);
            labelMaHH.Name = "labelMaHH";
            labelMaHH.Size = new Size(30, 12);
            labelMaHH.TabIndex = 1;
            labelMaHH.Text = "label2";
            // 
            // labelGiaBanHH
            // 
            labelGiaBanHH.AutoSize = true;
            labelGiaBanHH.Font = new Font("Segoe UI", 6F);
            labelGiaBanHH.Location = new Point(204, 48);
            labelGiaBanHH.Name = "labelGiaBanHH";
            labelGiaBanHH.Size = new Size(30, 12);
            labelGiaBanHH.TabIndex = 2;
            labelGiaBanHH.Text = "label3";
            // 
            // labelTonHH
            // 
            labelTonHH.AutoSize = true;
            labelTonHH.Font = new Font("Segoe UI", 6F);
            labelTonHH.Location = new Point(125, 48);
            labelTonHH.Name = "labelTonHH";
            labelTonHH.Size = new Size(30, 12);
            labelTonHH.TabIndex = 3;
            labelTonHH.Text = "label4";
            // 
            // pictureBoxHinhAnhHH
            // 
            pictureBoxHinhAnhHH.Location = new Point(19, 3);
            pictureBoxHinhAnhHH.Name = "pictureBoxHinhAnhHH";
            pictureBoxHinhAnhHH.Size = new Size(74, 64);
            pictureBoxHinhAnhHH.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxHinhAnhHH.TabIndex = 4;
            pictureBoxHinhAnhHH.TabStop = false;
            // 
            // UC_ItemThuoc
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.Window;
            Controls.Add(pictureBoxHinhAnhHH);
            Controls.Add(labelTonHH);
            Controls.Add(labelGiaBanHH);
            Controls.Add(labelMaHH);
            Controls.Add(labelTenHH);
            Name = "UC_ItemThuoc";
            Size = new Size(281, 73);
            Load += UC_ItemThuoc_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxHinhAnhHH).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenHH;
        private Label labelMaHH;
        private Label labelGiaBanHH;
        private Label labelTonHH;
        private PictureBox pictureBoxHinhAnhHH;

    }
}
