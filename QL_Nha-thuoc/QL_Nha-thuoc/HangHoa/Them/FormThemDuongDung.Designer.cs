namespace QL_Nha_thuoc.HangHoa.Them
{
    partial class FormThemDuongDung
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
            buttonHuy = new Button();
            buttonLuu = new Button();
            textBoxduongDungThuoc = new TextBox();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // buttonHuy
            // 
            buttonHuy.Location = new Point(428, 137);
            buttonHuy.Name = "buttonHuy";
            buttonHuy.Size = new Size(94, 29);
            buttonHuy.TabIndex = 9;
            buttonHuy.Text = "Hủy";
            buttonHuy.UseVisualStyleBackColor = true;
            buttonHuy.Click += buttonHuy_Click;
            // 
            // buttonLuu
            // 
            buttonLuu.Location = new Point(298, 137);
            buttonLuu.Name = "buttonLuu";
            buttonLuu.Size = new Size(94, 29);
            buttonLuu.TabIndex = 8;
            buttonLuu.Text = "Lưu";
            buttonLuu.UseVisualStyleBackColor = true;
            buttonLuu.Click += buttonLuu_Click;
            // 
            // textBoxduongDungThuoc
            // 
            textBoxduongDungThuoc.Location = new Point(27, 87);
            textBoxduongDungThuoc.Name = "textBoxduongDungThuoc";
            textBoxduongDungThuoc.Size = new Size(506, 27);
            textBoxduongDungThuoc.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.Location = new Point(27, 54);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 6;
            label2.Text = "Dường dùng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.Location = new Point(27, 18);
            label1.Name = "label1";
            label1.Size = new Size(180, 25);
            label1.TabIndex = 5;
            label1.Text = "Thêm đường dùng";
            // 
            // FormThemDuongDung
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(553, 175);
            Controls.Add(buttonHuy);
            Controls.Add(buttonLuu);
            Controls.Add(textBoxduongDungThuoc);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormThemDuongDung";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FormThemDuongDung";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonHuy;
        private Button buttonLuu;
        private TextBox textBoxduongDungThuoc;
        private Label label2;
        private Label label1;
    }
}