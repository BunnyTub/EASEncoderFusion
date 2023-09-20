namespace EASDecoderFusion_UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtAnnouncement = new System.Windows.Forms.TextBox();
            this.btnPlayAudio = new System.Windows.Forms.Button();
            this.btnPlayTest = new System.Windows.Forms.Button();
            this.TimeAndDate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAnnouncement
            // 
            this.txtAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.txtAnnouncement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAnnouncement.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAnnouncement.Font = new System.Drawing.Font("VCR EAS", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnnouncement.ForeColor = System.Drawing.Color.White;
            this.txtAnnouncement.Location = new System.Drawing.Point(11, 11);
            this.txtAnnouncement.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnnouncement.MaxLength = 500;
            this.txtAnnouncement.Multiline = true;
            this.txtAnnouncement.Name = "txtAnnouncement";
            this.txtAnnouncement.Size = new System.Drawing.Size(586, 82);
            this.txtAnnouncement.TabIndex = 16;
            this.txtAnnouncement.Tag = "disable";
            this.txtAnnouncement.Text = "ABCDEFGHIJKLMNOPQRSTUVWXYZ\r\n1234567890!@#$%^&*()_+-=[]";
            this.txtAnnouncement.WordWrap = false;
            // 
            // btnPlayAudio
            // 
            this.btnPlayAudio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPlayAudio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPlayAudio.FlatAppearance.BorderSize = 4;
            this.btnPlayAudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayAudio.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlayAudio.Location = new System.Drawing.Point(447, 97);
            this.btnPlayAudio.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayAudio.Name = "btnPlayAudio";
            this.btnPlayAudio.Size = new System.Drawing.Size(150, 86);
            this.btnPlayAudio.TabIndex = 20;
            this.btnPlayAudio.Text = "PLAY";
            this.btnPlayAudio.UseVisualStyleBackColor = false;
            this.btnPlayAudio.Click += new System.EventHandler(this.btnPlayAudio_Click);
            // 
            // btnPlayTest
            // 
            this.btnPlayTest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnPlayTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayTest.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold);
            this.btnPlayTest.Location = new System.Drawing.Point(293, 97);
            this.btnPlayTest.Margin = new System.Windows.Forms.Padding(2);
            this.btnPlayTest.Name = "btnPlayTest";
            this.btnPlayTest.Size = new System.Drawing.Size(150, 86);
            this.btnPlayTest.TabIndex = 105;
            this.btnPlayTest.Tag = "disable";
            this.btnPlayTest.Text = "TEST";
            this.btnPlayTest.UseVisualStyleBackColor = false;
            this.btnPlayTest.Click += new System.EventHandler(this.btnPlayTest_Click);
            // 
            // TimeAndDate
            // 
            this.TimeAndDate.Enabled = true;
            this.TimeAndDate.Interval = 1000;
            this.TimeAndDate.Tick += new System.EventHandler(this.TimeAndDate_Tick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 23);
            this.label1.TabIndex = 106;
            this.label1.Text = "WARNING";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkOrange;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(277, 23);
            this.label2.TabIndex = 107;
            this.label2.Text = "WATCH";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Green;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(11, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 23);
            this.label3.TabIndex = 108;
            this.label3.Text = "ADVISORY / STATEMENT";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(608, 194);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlayTest);
            this.Controls.Add(this.btnPlayAudio);
            this.Controls.Add(this.txtAnnouncement);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EASDecoder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtAnnouncement;
        private System.Windows.Forms.Button btnPlayAudio;
        private System.Windows.Forms.Button btnPlayTest;
        private System.Windows.Forms.Timer TimeAndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

