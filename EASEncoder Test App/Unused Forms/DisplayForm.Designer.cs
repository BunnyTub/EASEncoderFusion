namespace EASEncoder_UI
{
    partial class DisplayForm
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
            this.components = new System.ComponentModel.Container();
            this.ScrollingText1 = new System.Windows.Forms.Timer(this.components);
            this.TitleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ScrollingText1
            // 
            this.ScrollingText1.Interval = 2500;
            this.ScrollingText1.Tick += new System.EventHandler(this.ScrollingText1_Tick);
            // 
            // TitleLabel
            // 
            this.TitleLabel.BackColor = System.Drawing.Color.Red;
            this.TitleLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleLabel.Font = new System.Drawing.Font("VCR EAS", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLabel.Location = new System.Drawing.Point(0, 0);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(1920, 113);
            this.TitleLabel.TabIndex = 0;
            this.TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleLabel.UseMnemonic = false;
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.TitleLabel);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1918, 1038);
            this.Name = "DisplayForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EASEncoder Visual Display";
            this.TransparencyKey = System.Drawing.Color.Pink;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DisplayForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer ScrollingText1;
        private System.Windows.Forms.Label TitleLabel;
    }
}