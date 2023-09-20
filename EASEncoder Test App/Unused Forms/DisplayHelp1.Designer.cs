namespace EASEncoder_UI
{
    partial class DisplayHelp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.TitleBar = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInstall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(120, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 75);
            this.label1.TabIndex = 24;
            this.label1.Text = "To continue, grant administrative rights to install\r\nUSBMMIDD_v2 on your system. " +
    "Your display may\r\nturn black for a few seconds while installing.";
            // 
            // TitleBar
            // 
            this.TitleBar.AutoSize = true;
            this.TitleBar.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.Location = new System.Drawing.Point(117, 12);
            this.TitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.Size = new System.Drawing.Size(510, 45);
            this.TitleBar.TabIndex = 23;
            this.TitleBar.Text = "Required Application Not Installed";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EASEncoder_UI.Properties.Resources.uac;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // btnInstall
            // 
            this.btnInstall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnInstall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInstall.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnInstall.Location = new System.Drawing.Point(548, 160);
            this.btnInstall.Margin = new System.Windows.Forms.Padding(2);
            this.btnInstall.Name = "btnInstall";
            this.btnInstall.Size = new System.Drawing.Size(115, 30);
            this.btnInstall.TabIndex = 27;
            this.btnInstall.Tag = "disable";
            this.btnInstall.Text = "Install";
            this.btnInstall.UseVisualStyleBackColor = false;
            this.btnInstall.Click += new System.EventHandler(this.btnActivate_Click);
            // 
            // DisplayHelp1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(674, 201);
            this.Controls.Add(this.btnInstall);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DisplayHelp1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EASEncoder Fusion";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DisplayHelp1_FormClosing);
            this.Load += new System.EventHandler(this.HelpDisplayForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TitleBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInstall;
    }
}