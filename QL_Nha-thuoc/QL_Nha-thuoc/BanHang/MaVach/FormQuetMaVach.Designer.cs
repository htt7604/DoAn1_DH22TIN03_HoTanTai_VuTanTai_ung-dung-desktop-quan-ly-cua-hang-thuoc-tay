namespace QL_Nha_thuoc.BanHang.MaVach
{
    partial class FormQuetMaVach
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
            pictureBoxCammera = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxCammera).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxCammera
            // 
            pictureBoxCammera.Location = new Point(233, 12);
            pictureBoxCammera.Name = "pictureBoxCammera";
            pictureBoxCammera.Size = new Size(606, 598);
            pictureBoxCammera.TabIndex = 0;
            pictureBoxCammera.TabStop = false;
            // 
            // FormQuetMaVach
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1040, 633);
            Controls.Add(pictureBoxCammera);
            Name = "FormQuetMaVach";
            Text = "FormQuetMaVach";
            ((System.ComponentModel.ISupportInitialize)pictureBoxCammera).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBoxCammera;
    }
}