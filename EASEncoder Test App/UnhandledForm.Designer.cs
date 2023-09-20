namespace EASEncoder_UI
{
    partial class UnhandledForm
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

        protected void Empty()
        {

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnhandledForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblStop = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTerminate = new System.Windows.Forms.Button();
            this.UpTown = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::EASEncoder_UI.Properties.Resources.warning_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lblStop
            // 
            this.lblStop.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblStop.Location = new System.Drawing.Point(93, 12);
            this.lblStop.Margin = new System.Windows.Forms.Padding(0);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(348, 45);
            this.lblStop.TabIndex = 1;
            this.lblStop.Text = "Application Exception";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.label1.Location = new System.Drawing.Point(98, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(343, 115);
            this.label1.TabIndex = 2;
            this.label1.Text = "An error has occurred, and the app needs to close. Sorry for the mishap.\r\n\r\n(Exce" +
    "ption)";
            // 
            // btnTerminate
            // 
            this.btnTerminate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTerminate.BackColor = System.Drawing.Color.Red;
            this.btnTerminate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnTerminate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTerminate.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnTerminate.Location = new System.Drawing.Point(11, 194);
            this.btnTerminate.Margin = new System.Windows.Forms.Padding(2);
            this.btnTerminate.Name = "btnTerminate";
            this.btnTerminate.Size = new System.Drawing.Size(432, 36);
            this.btnTerminate.TabIndex = 1;
            this.btnTerminate.Tag = "";
            this.btnTerminate.Text = "Terminate Application";
            this.btnTerminate.UseVisualStyleBackColor = false;
            this.btnTerminate.Click += new System.EventHandler(this.btnTerminate_Click);
            // 
            // UpTown
            // 
            this.UpTown.Enabled = true;
            this.UpTown.Interval = 500;
            this.UpTown.Tick += new System.EventHandler(this.UpTown_Tick);
            // 
            // UnhandledForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(454, 241);
            this.Controls.Add(this.btnTerminate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStop);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UnhandledForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EASEncoder Fusion [Exception]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnhandledForm_FormClosing);
            this.Shown += new System.EventHandler(this.UnhandledForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblStop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTerminate;
        private System.Windows.Forms.Timer UpTown;
    }
}