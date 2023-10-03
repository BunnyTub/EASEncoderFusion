namespace EASEncoder_UI
{
    partial class CustomGenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomGenForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomData = new System.Windows.Forms.TextBox();
            this.checkBoxNWR = new System.Windows.Forms.CheckBox();
            this.checkBoxEBS = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnnouncement = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.checkBoxCENSOR = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 84);
            this.label1.TabIndex = 100;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(9, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 100;
            this.label2.Text = "[Preamble]-ZCZC-";
            // 
            // txtCustomData
            // 
            this.txtCustomData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtCustomData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomData.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCustomData.ForeColor = System.Drawing.Color.White;
            this.txtCustomData.Location = new System.Drawing.Point(111, 104);
            this.txtCustomData.Name = "txtCustomData";
            this.txtCustomData.Size = new System.Drawing.Size(381, 23);
            this.txtCustomData.TabIndex = 0;
            this.txtCustomData.TextChanged += new System.EventHandler(this.txtCustomData_TextChanged);
            // 
            // checkBoxNWR
            // 
            this.checkBoxNWR.AutoSize = true;
            this.checkBoxNWR.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxNWR.Location = new System.Drawing.Point(12, 174);
            this.checkBoxNWR.Name = "checkBoxNWR";
            this.checkBoxNWR.Size = new System.Drawing.Size(203, 24);
            this.checkBoxNWR.TabIndex = 3;
            this.checkBoxNWR.Text = "Use NWS Attention Tone";
            this.checkBoxNWR.UseVisualStyleBackColor = true;
            // 
            // checkBoxEBS
            // 
            this.checkBoxEBS.AutoSize = true;
            this.checkBoxEBS.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxEBS.Location = new System.Drawing.Point(12, 143);
            this.checkBoxEBS.Name = "checkBoxEBS";
            this.checkBoxEBS.Size = new System.Drawing.Size(194, 24);
            this.checkBoxEBS.TabIndex = 2;
            this.checkBoxEBS.Text = "Use EBS Attention Tone";
            this.checkBoxEBS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(9, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Announcement Text";
            // 
            // txtAnnouncement
            // 
            this.txtAnnouncement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtAnnouncement.ForeColor = System.Drawing.Color.White;
            this.txtAnnouncement.Location = new System.Drawing.Point(12, 229);
            this.txtAnnouncement.Multiline = true;
            this.txtAnnouncement.Name = "txtAnnouncement";
            this.txtAnnouncement.Size = new System.Drawing.Size(480, 253);
            this.txtAnnouncement.TabIndex = 5;
            this.txtAnnouncement.TextChanged += new System.EventHandler(this.txtAnnouncement_TextChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 488);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(93, 488);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(181, 491);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Output File Name";
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOutputFile.ForeColor = System.Drawing.Color.White;
            this.txtOutputFile.Location = new System.Drawing.Point(288, 488);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(204, 23);
            this.txtOutputFile.TabIndex = 8;
            this.txtOutputFile.Text = "custom-output";
            this.txtOutputFile.TextChanged += new System.EventHandler(this.txtOutputFile_TextChanged);
            // 
            // checkBoxCENSOR
            // 
            this.checkBoxCENSOR.AutoSize = true;
            this.checkBoxCENSOR.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.checkBoxCENSOR.Location = new System.Drawing.Point(245, 143);
            this.checkBoxCENSOR.Name = "checkBoxCENSOR";
            this.checkBoxCENSOR.Size = new System.Drawing.Size(226, 24);
            this.checkBoxCENSOR.TabIndex = 4;
            this.checkBoxCENSOR.Text = "Use CENSOR Attention Tone";
            this.checkBoxCENSOR.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVersion.ForeColor = System.Drawing.Color.Magenta;
            this.lblVersion.Location = new System.Drawing.Point(304, 182);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(188, 44);
            this.lblVersion.TabIndex = 105;
            this.lblVersion.Text = "v0.0.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // CustomGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(504, 531);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.checkBoxCENSOR);
            this.Controls.Add(this.txtOutputFile);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAnnouncement);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBoxEBS);
            this.Controls.Add(this.checkBoxNWR);
            this.Controls.Add(this.txtCustomData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 570);
            this.Name = "CustomGenForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EASEncoder Fusion [Custom Mode]";
            this.Load += new System.EventHandler(this.CustomGenForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txtCustomData;
        internal System.Windows.Forms.CheckBox checkBoxNWR;
        internal System.Windows.Forms.CheckBox checkBoxEBS;
        internal System.Windows.Forms.TextBox txtAnnouncement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtOutputFile;
        internal System.Windows.Forms.CheckBox checkBoxCENSOR;
        private System.Windows.Forms.Label lblVersion;
    }
}