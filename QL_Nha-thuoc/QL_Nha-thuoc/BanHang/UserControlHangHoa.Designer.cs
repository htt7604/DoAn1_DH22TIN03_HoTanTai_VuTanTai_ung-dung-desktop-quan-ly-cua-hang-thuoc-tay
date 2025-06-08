namespace QL_Nha_thuoc.BanHang
{
    partial class UserControlHangHoa
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
            buttonXoa = new Button();
            numericUpDown1 = new NumericUpDown();
            textBoxGiaBan = new TextBox();
            labelSTT = new Label();
            labelMaHangHoa = new Label();
            labelTenHang = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // buttonXoa
            // 
            buttonXoa.Location = new Point(91, 13);
            buttonXoa.Name = "buttonXoa";
            buttonXoa.Size = new Size(45, 29);
            buttonXoa.TabIndex = 0;
            buttonXoa.Text = "x";
            buttonXoa.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(451, 16);
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(47, 27);
            numericUpDown1.TabIndex = 1;
            // 
            // textBoxGiaBan
            // 
            textBoxGiaBan.Location = new Point(543, 15);
            textBoxGiaBan.Name = "textBoxGiaBan";
            textBoxGiaBan.Size = new Size(125, 27);
            textBoxGiaBan.TabIndex = 2;
            // 
            // labelSTT
            // 
            labelSTT.AutoSize = true;
            labelSTT.Location = new Point(19, 18);
            labelSTT.Name = "labelSTT";
            labelSTT.Size = new Size(33, 20);
            labelSTT.TabIndex = 3;
            labelSTT.Text = "STT";
            // 
            // labelMaHangHoa
            // 
            labelMaHangHoa.AutoSize = true;
            labelMaHangHoa.Location = new Point(159, 18);
            labelMaHangHoa.Name = "labelMaHangHoa";
            labelMaHangHoa.Size = new Size(67, 20);
            labelMaHangHoa.TabIndex = 4;
            labelMaHangHoa.Text = "Ma hang";
            // 
            // labelTenHang
            // 
            labelTenHang.AutoSize = true;
            labelTenHang.Location = new Point(286, 18);
            labelTenHang.Name = "labelTenHang";
            labelTenHang.Size = new Size(68, 20);
            labelTenHang.TabIndex = 5;
            labelTenHang.Text = "TenHang";
            // 
            // UserControlHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            Controls.Add(labelTenHang);
            Controls.Add(labelMaHangHoa);
            Controls.Add(labelSTT);
            Controls.Add(textBoxGiaBan);
            Controls.Add(numericUpDown1);
            Controls.Add(buttonXoa);
            Name = "UserControlHangHoa";
            Size = new Size(935, 58);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonXoa;
        private NumericUpDown numericUpDown1;
        private TextBox textBoxGiaBan;
        private Label labelSTT;
        private Label labelMaHangHoa;
        private Label labelTenHang;
    }
}
