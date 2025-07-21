namespace QL_Nha_thuoc.HangHoa
{
    partial class FormThemHangSX
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
            textBoxTenHangSX = new TextBox();
            buttonLuu = new Button();
            buttonHuy = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(28, 9);
            label1.Name = "label1";
            label1.Size = new Size(191, 25);
            label1.TabIndex = 0;
            label1.Text = "Thêm hãng sản xuất";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(28, 45);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên hãng sản xuất";
            // 
            // textBoxTenHangSX
            // 
            textBoxTenHangSX.Location = new Point(28, 78);
            textBoxTenHangSX.Name = "textBoxTenHangSX";
            textBoxTenHangSX.Size = new Size(506, 27);
            textBoxTenHangSX.TabIndex = 2;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(299, 128);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 29);
            buttonLuu.TabIndex = 3;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // buttonHuy
            // 
            buttonHuy.Location = new Point(429, 128);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(94, 29);
            buttonHuy.TabIndex = 4;
            buttonHuy.Text = "Hủy";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Click += buttonHuy_Click;
            // 
            // FormThemHangSX
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(547, 171);
            Controls.Add(buttonHuy);
            Controls.Add(buttonLuu);
            Controls.Add(textBoxTenHangSX);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormThemHangSX";
            Text = "Thêm hãng sản xuất";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBoxTenHangSX;
        private Button buttonLuu;
        private Button buttonHuy;
    }
}