namespace QL_Nha_thuoc.GiaoDich.NhapHang
{
    partial class FormGiamGiaPopup
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
            buttonVND = new Button();
            buttonPhanTram = new Button();
            textBoxGiaTri = new TextBox();
            SuspendLayout();
            // 
            // buttonVND
            // 
            buttonVND.Location = new Point(148, 24);
            buttonVND.Name = "buttonVND";
            buttonVND.Size = new Size(94, 29);
            buttonVND.TabIndex = 0;
            buttonVND.Text = "VND";
            buttonVND.UseVisualStyleBackColor = true;
            buttonVND.Click += buttonVND_Click;
            // 
            // buttonPhanTram
            // 
            buttonPhanTram.Location = new Point(248, 24);
            buttonPhanTram.Name = "buttonPhanTram";
            buttonPhanTram.Size = new Size(94, 29);
            buttonPhanTram.TabIndex = 1;
            buttonPhanTram.Text = "%";
            buttonPhanTram.UseVisualStyleBackColor = true;
            buttonPhanTram.Click += buttonPhanTram_Click;
            // 
            // textBoxGiaTri
            // 
            textBoxGiaTri.Location = new Point(12, 25);
            textBoxGiaTri.Name = "textBoxGiaTri";
            textBoxGiaTri.Size = new Size(125, 27);
            textBoxGiaTri.TabIndex = 2;
            textBoxGiaTri.TextChanged += textBoxGiaTri_TextChanged;
            // 
            // FormGiamGiaPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 82);
            Controls.Add(textBoxGiaTri);
            Controls.Add(buttonPhanTram);
            Controls.Add(buttonVND);
            Name = "FormGiamGiaPopup";
            Text = "FormGiamGiaPopup";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonVND;
        private Button buttonPhanTram;
        private TextBox textBoxGiaTri;
    }
}