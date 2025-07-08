namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    partial class UserControlNhaCungCap
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
            labelTenNCC = new Label();
            labelSDT = new Label();
            SuspendLayout();
            // 
            // labelTenNCC
            // 
            labelTenNCC.AutoSize = true;
            labelTenNCC.Location = new Point(15, 15);
            labelTenNCC.Name = "labelTenNCC";
            labelTenNCC.Size = new Size(50, 20);
            labelTenNCC.TabIndex = 0;
            labelTenNCC.Text = "label1";
            // 
            // labelSDT
            // 
            labelSDT.AutoSize = true;
            labelSDT.Location = new Point(165, 15);
            labelSDT.Name = "labelSDT";
            labelSDT.Size = new Size(50, 20);
            labelSDT.TabIndex = 1;
            labelSDT.Text = "label1";
            // 
            // UserControlNhaCungCap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(labelSDT);
            Controls.Add(labelTenNCC);
            Name = "UserControlNhaCungCap";
            Size = new Size(306, 47);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelTenNCC;
        private Label labelSDT;
    }
}
