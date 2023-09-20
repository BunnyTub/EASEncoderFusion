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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOutputFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(466, 84);
            this.label1.TabIndex = 100;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(15, 118);
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
            this.txtCustomData.Location = new System.Drawing.Point(117, 114);
            this.txtCustomData.Name = "txtCustomData";
            this.txtCustomData.Size = new System.Drawing.Size(362, 23);
            this.txtCustomData.TabIndex = 0;
            this.txtCustomData.TextChanged += new System.EventHandler(this.txtCustomData_TextChanged);
            // 
            // checkBoxNWR
            // 
            this.checkBoxNWR.AutoSize = true;
            this.checkBoxNWR.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBoxNWR.Location = new System.Drawing.Point(18, 178);
            this.checkBoxNWR.Name = "checkBoxNWR";
            this.checkBoxNWR.Size = new System.Drawing.Size(138, 25);
            this.checkBoxNWR.TabIndex = 1;
            this.checkBoxNWR.Text = "Use NWS Tones";
            this.checkBoxNWR.UseVisualStyleBackColor = true;
            // 
            // checkBoxEBS
            // 
            this.checkBoxEBS.AutoSize = true;
            this.checkBoxEBS.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.checkBoxEBS.Location = new System.Drawing.Point(18, 147);
            this.checkBoxEBS.Name = "checkBoxEBS";
            this.checkBoxEBS.Size = new System.Drawing.Size(128, 25);
            this.checkBoxEBS.TabIndex = 2;
            this.checkBoxEBS.Text = "Use EBS Tones";
            this.checkBoxEBS.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label3.Location = new System.Drawing.Point(15, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 100;
            this.label3.Text = "Announcement Text";
            // 
            // txtAnnouncement
            // 
            this.txtAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnnouncement.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAnnouncement.ForeColor = System.Drawing.Color.White;
            this.txtAnnouncement.Location = new System.Drawing.Point(18, 229);
            this.txtAnnouncement.Multiline = true;
            this.txtAnnouncement.Name = "txtAnnouncement";
            this.txtAnnouncement.Size = new System.Drawing.Size(461, 257);
            this.txtAnnouncement.TabIndex = 3;
            this.txtAnnouncement.TextChanged += new System.EventHandler(this.txtAnnouncement_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(18, 492);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(99, 492);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label6.Location = new System.Drawing.Point(181, 495);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Output File Name";
            // 
            // txtOutputFile
            // 
            this.txtOutputFile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFile.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOutputFile.ForeColor = System.Drawing.Color.White;
            this.txtOutputFile.Location = new System.Drawing.Point(288, 492);
            this.txtOutputFile.Name = "txtOutputFile";
            this.txtOutputFile.Size = new System.Drawing.Size(191, 23);
            this.txtOutputFile.TabIndex = 6;
            this.txtOutputFile.Text = "custom-output";
            this.txtOutputFile.TextChanged += new System.EventHandler(this.txtOutputFile_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(502, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(390, 100);
            this.label4.TabIndex = 100;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(742, 118);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(150, 23);
            this.button3.TabIndex = 101;
            this.button3.Text = "I understand";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.button4.Location = new System.Drawing.Point(503, 13);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 125);
            this.button4.TabIndex = 103;
            this.button4.Text = "!";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // CustomGenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(904, 535);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
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
            this.Name = "CustomGenForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EASEncoder Fusion [Custom Mode]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        internal System.Windows.Forms.TextBox txtCustomData;
        internal System.Windows.Forms.CheckBox checkBoxNWR;
        internal System.Windows.Forms.CheckBox checkBoxEBS;
        internal System.Windows.Forms.TextBox txtAnnouncement;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtOutputFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}