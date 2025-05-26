namespace QL_Nha_thuoc
{
    partial class FormMain
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
            panel2 = new Panel();
            panelloc = new Panel();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1263, 57);
            panel2.TabIndex = 1;
            // 
            // panelloc
            // 
            panelloc.Location = new Point(0, 63);
            panelloc.Name = "panelloc";
            panelloc.Size = new Size(1263, 655);
            panelloc.TabIndex = 2;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 721);
            Controls.Add(panelloc);
            Controls.Add(panel2);
            Name = "FormMain";
            Text = "FormMain";
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panelloc;
    }
}