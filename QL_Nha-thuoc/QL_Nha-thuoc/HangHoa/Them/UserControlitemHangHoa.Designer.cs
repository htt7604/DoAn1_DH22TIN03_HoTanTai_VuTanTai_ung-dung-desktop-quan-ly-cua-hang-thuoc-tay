namespace QL_Nha_thuoc.HangHoa.Them
{
    partial class UserControlitemHangHoa
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBoxAnhHangHoa = new PictureBox();
            panel1 = new Panel();
            labelMaVach = new Label();
            labelTenHangHoa = new Label();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnhHangHoa).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Window;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.32558F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.6744156F));
            tableLayoutPanel1.Controls.Add(pictureBoxAnhHangHoa, 0, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(394, 84);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBoxAnhHangHoa
            // 
            pictureBoxAnhHangHoa.Dock = DockStyle.Fill;
            pictureBoxAnhHangHoa.Location = new Point(3, 3);
            pictureBoxAnhHangHoa.Name = "pictureBoxAnhHangHoa";
            pictureBoxAnhHangHoa.Size = new Size(81, 78);
            pictureBoxAnhHangHoa.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxAnhHangHoa.TabIndex = 0;
            pictureBoxAnhHangHoa.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(labelMaVach);
            panel1.Controls.Add(labelTenHangHoa);
            panel1.Location = new Point(90, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(244, 72);
            panel1.TabIndex = 1;
            // 
            // labelMaVach
            // 
            labelMaVach.AutoSize = true;
            labelMaVach.Font = new Font("Segoe UI", 7F);
            labelMaVach.Location = new Point(20, 42);
            labelMaVach.Name = "labelMaVach";
            labelMaVach.Size = new Size(52, 15);
            labelMaVach.TabIndex = 1;
            labelMaVach.Text = "Ma vach";
            // 
            // labelTenHangHoa
            // 
            labelTenHangHoa.AutoSize = true;
            labelTenHangHoa.Location = new Point(20, 9);
            labelTenHangHoa.Name = "labelTenHangHoa";
            labelTenHangHoa.Size = new Size(32, 20);
            labelTenHangHoa.TabIndex = 0;
            labelTenHangHoa.Text = "Ten";
            // 
            // UserControlitemHangHoa
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "UserControlitemHangHoa";
            Size = new Size(394, 84);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxAnhHangHoa).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBoxAnhHangHoa;
        private Panel panel1;
        private Label labelMaVach;
        private Label labelTenHangHoa;
    }
}
