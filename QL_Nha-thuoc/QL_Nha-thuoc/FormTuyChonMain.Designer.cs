namespace QL_Nha_thuoc
{
    partial class FormTuyChonMain
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
            btnDangXuat = new Button();
            SuspendLayout();
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.Red;
            btnDangXuat.Dock = DockStyle.Top;
            btnDangXuat.Location = new Point(0, 0);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(279, 40);
            btnDangXuat.TabIndex = 1;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // FormTuyChonMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(279, 43);
            Controls.Add(btnDangXuat);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormTuyChonMain";
            Text = "FormTuyChonMain";
            ResumeLayout(false);
        }

        #endregion

        private Button btnDangXuat;
    }
}