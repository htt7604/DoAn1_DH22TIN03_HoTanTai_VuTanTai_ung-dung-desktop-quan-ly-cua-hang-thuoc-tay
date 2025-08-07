namespace QL_Nha_thuoc.BanHang
{
    partial class FormChonTaiKhoanNganHang
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTaiKhoan;

        private void InitializeComponent()
        {
            panelMain = new Panel();
            flowLayoutPanelTaiKhoan = new FlowLayoutPanel();
            txtTimKiem = new TextBox();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.Controls.Add(flowLayoutPanelTaiKhoan);
            panelMain.Controls.Add(txtTimKiem);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(3, 4, 3, 4);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(450, 750);
            panelMain.TabIndex = 0;
            // 
            // flowLayoutPanelTaiKhoan
            // 
            flowLayoutPanelTaiKhoan.AutoScroll = true;
            flowLayoutPanelTaiKhoan.Dock = DockStyle.Fill;
            flowLayoutPanelTaiKhoan.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelTaiKhoan.Location = new Point(0, 30);
            flowLayoutPanelTaiKhoan.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanelTaiKhoan.Name = "flowLayoutPanelTaiKhoan";
            flowLayoutPanelTaiKhoan.Padding = new Padding(5, 6, 5, 6);
            flowLayoutPanelTaiKhoan.Size = new Size(450, 720);
            flowLayoutPanelTaiKhoan.TabIndex = 0;
            flowLayoutPanelTaiKhoan.WrapContents = false;
            flowLayoutPanelTaiKhoan.SizeChanged += flowLayoutPanelTaiKhoan_SizeChanged;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Dock = DockStyle.Top;
            txtTimKiem.Font = new Font("Segoe UI", 10F);
            txtTimKiem.Location = new Point(0, 0);
            txtTimKiem.Margin = new Padding(5, 6, 5, 6);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo tên hoặc số tài khoản...";
            txtTimKiem.Size = new Size(450, 30);
            txtTimKiem.TabIndex = 1;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // FormChonTaiKhoanNganHang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(450, 750);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormChonTaiKhoanNganHang";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Chọn tài khoản ngân hàng";
            Load += FormChonTaiKhoanNganHang_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }



        #endregion
    }
}