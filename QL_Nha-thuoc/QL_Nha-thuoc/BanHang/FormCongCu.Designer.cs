namespace QL_Nha_thuoc.BanHang
{
    partial class FormCongCu
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
        private Button btnDangXuat;
        private Button btnQuayLaiQL;

        private void InitializeComponent()
        {
            btnDangXuat = new Button();
            btnQuayLaiQL = new Button();
            SuspendLayout();
            // 
            // btnDangXuat
            // 
            btnDangXuat.BackColor = Color.Red;
            btnDangXuat.Dock = DockStyle.Top;
            btnDangXuat.Location = new Point(0, 40);
            btnDangXuat.Name = "btnDangXuat";
            btnDangXuat.Size = new Size(300, 40);
            btnDangXuat.TabIndex = 0;
            btnDangXuat.Text = "Đăng xuất";
            btnDangXuat.UseVisualStyleBackColor = false;
            btnDangXuat.Click += btnDangXuat_Click;
            // 
            // btnQuayLaiQL
            // 
            btnQuayLaiQL.BackColor = Color.Chartreuse;
            btnQuayLaiQL.Dock = DockStyle.Top;
            btnQuayLaiQL.Location = new Point(0, 0);
            btnQuayLaiQL.Name = "btnQuayLaiQL";
            btnQuayLaiQL.Size = new Size(300, 40);
            btnQuayLaiQL.TabIndex = 1;
            btnQuayLaiQL.Text = "Quay lại quản lý";
            btnQuayLaiQL.UseVisualStyleBackColor = false;
            btnQuayLaiQL.Click += btnQuayLaiQL_Click;
            // 
            // FormCongCu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 87);
            Controls.Add(btnDangXuat);
            Controls.Add(btnQuayLaiQL);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCongCu";
            StartPosition = FormStartPosition.Manual;
            Text = "FormCongCu";
            TopMost = true;
            ResumeLayout(false);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        #endregion
    }
}