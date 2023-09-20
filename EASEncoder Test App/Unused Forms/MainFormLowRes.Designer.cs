namespace EASEncoder_UI
{
    partial class MainFormLowRes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFormLowRes));
            this.BorderStylePanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.Front = new System.Windows.Forms.Timer(this.components);
            this.BorderStylePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BorderStylePanel
            // 
            this.BorderStylePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BorderStylePanel.Controls.Add(this.btnMinimize);
            this.BorderStylePanel.Controls.Add(this.lblTitleBar);
            this.BorderStylePanel.Controls.Add(this.btnClose);
            this.BorderStylePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BorderStylePanel.Location = new System.Drawing.Point(0, 0);
            this.BorderStylePanel.Margin = new System.Windows.Forms.Padding(0);
            this.BorderStylePanel.Name = "BorderStylePanel";
            this.BorderStylePanel.Size = new System.Drawing.Size(468, 52);
            this.BorderStylePanel.TabIndex = 0;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Olive;
            this.btnMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMinimize.BackgroundImage")));
            this.btnMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMinimize.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Olive;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.Location = new System.Drawing.Point(392, 10);
            this.btnMinimize.Margin = new System.Windows.Forms.Padding(2);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 1;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Tag = "disable";
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.AutoSize = true;
            this.lblTitleBar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBar.Location = new System.Drawing.Point(8, 9);
            this.lblTitleBar.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Size = new System.Drawing.Size(190, 30);
            this.lblTitleBar.TabIndex = 0;
            this.lblTitleBar.Text = "EASEncoder Fusion";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Maroon;
            this.btnClose.BackgroundImage = global::EASEncoder_UI.Properties.Resources.close_r;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(426, 10);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = false;
            this.btnClose.Tag = "disable";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Front
            // 
            this.Front.Interval = 1000;
            this.Front.Tick += new System.EventHandler(this.Front_Tick);
            // 
            // MainFormLowRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(468, 52);
            this.ControlBox = false;
            this.Controls.Add(this.BorderStylePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainFormLowRes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "EASEncoder Fusion Controls";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.MainFormLowRes_Load);
            this.BorderStylePanel.ResumeLayout(false);
            this.BorderStylePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderStylePanel;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Timer Front;
    }
}