namespace EASEncoder_UI
{
    partial class HoldOnForm
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
            this.StaticProgress = new System.Windows.Forms.ProgressBar();
            this.TakingTooLong = new System.Windows.Forms.Timer(this.components);
            this.lblTooLong = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // StaticProgress
            // 
            this.StaticProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StaticProgress.Location = new System.Drawing.Point(9, 9);
            this.StaticProgress.Margin = new System.Windows.Forms.Padding(0);
            this.StaticProgress.MarqueeAnimationSpeed = 50;
            this.StaticProgress.Name = "StaticProgress";
            this.StaticProgress.Size = new System.Drawing.Size(366, 33);
            this.StaticProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.StaticProgress.TabIndex = 0;
            this.StaticProgress.Value = 50;
            // 
            // TakingTooLong
            // 
            this.TakingTooLong.Enabled = true;
            this.TakingTooLong.Interval = 5000;
            this.TakingTooLong.Tick += new System.EventHandler(this.TakingTooLong_Tick);
            // 
            // lblTooLong
            // 
            this.lblTooLong.BackColor = System.Drawing.Color.Transparent;
            this.lblTooLong.LinkColor = System.Drawing.Color.White;
            this.lblTooLong.Location = new System.Drawing.Point(9, 46);
            this.lblTooLong.Name = "lblTooLong";
            this.lblTooLong.Size = new System.Drawing.Size(366, 16);
            this.lblTooLong.TabIndex = 1;
            this.lblTooLong.Visible = false;
            // 
            // HoldOnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(384, 51);
            this.ControlBox = false;
            this.Controls.Add(this.lblTooLong);
            this.Controls.Add(this.StaticProgress);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HoldOnForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processing";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HoldOnForm_FormClosing);
            this.Load += new System.EventHandler(this.HoldOnForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar StaticProgress;
        private System.Windows.Forms.Timer TakingTooLong;
        private System.Windows.Forms.LinkLabel lblTooLong;
    }
}