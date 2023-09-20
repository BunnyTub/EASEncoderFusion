namespace EASEncoder_UI
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.lblWarning = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.lblLowRes = new System.Windows.Forms.Label();
            this.btnResetSettings = new System.Windows.Forms.Button();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.comboOriginator = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblProduct
            // 
            this.lblProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.ForeColor = System.Drawing.Color.White;
            this.lblProduct.Location = new System.Drawing.Point(6, 373);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(258, 37);
            this.lblProduct.TabIndex = 100;
            this.lblProduct.Text = "EASEncoder Fusion";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAuthor.ForeColor = System.Drawing.Color.White;
            this.lblAuthor.Location = new System.Drawing.Point(469, 138);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(320, 120);
            this.lblAuthor.TabIndex = 100;
            this.lblAuthor.Text = "This project was originally called EASEncoder.\r\nForked from Wolf20482.\r\n\r\nDevelop" +
    "er: BunnyTub\r\nLogo Designer: ApatheticDELL\r\nLicense: GNU Lesser General Public L" +
    "icense v3.0";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblAuthor.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblWarning
            // 
            this.lblWarning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(451, 9);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(339, 120);
            this.lblWarning.TabIndex = 100;
            this.lblWarning.Text = resources.GetString("lblWarning.Text");
            this.lblWarning.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnApply.FlatAppearance.BorderSize = 0;
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.btnApply.Location = new System.Drawing.Point(643, 317);
            this.btnApply.Margin = new System.Windows.Forms.Padding(2);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(147, 57);
            this.btnApply.TabIndex = 7;
            this.btnApply.Tag = "disable";
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnCancel.Location = new System.Drawing.Point(643, 378);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(147, 30);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Tag = "disable";
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox1.Location = new System.Drawing.Point(13, 47);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(210, 19);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Output errors and warnings quietly";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 100;
            this.label3.Text = "Need help?";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Lime;
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.linkLabel1.LinkColor = System.Drawing.Color.Magenta;
            this.linkLabel1.Location = new System.Drawing.Point(89, 12);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(76, 20);
            this.linkLabel1.TabIndex = 0;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Click here.";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox2.Location = new System.Drawing.Point(13, 72);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(232, 19);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Use performance themed window style";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox3.Location = new System.Drawing.Point(13, 97);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(242, 19);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Wait 15 seconds before relaying message";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox4.Location = new System.Drawing.Point(13, 122);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(190, 19);
            this.checkBox4.TabIndex = 4;
            this.checkBox4.Text = "Use performance themed fonts";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox5.Location = new System.Drawing.Point(13, 147);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(325, 19);
            this.checkBox5.TabIndex = 5;
            this.checkBox5.Text = "Quit after message finishes (doesn\'t affect manual stops)";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // lblLowRes
            // 
            this.lblLowRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLowRes.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblLowRes.ForeColor = System.Drawing.Color.White;
            this.lblLowRes.Location = new System.Drawing.Point(-293, -121);
            this.lblLowRes.Name = "lblLowRes";
            this.lblLowRes.Size = new System.Drawing.Size(288, 116);
            this.lblLowRes.TabIndex = 28;
            this.lblLowRes.Text = resources.GetString("lblLowRes.Text");
            this.lblLowRes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnResetSettings
            // 
            this.btnResetSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnResetSettings.FlatAppearance.BorderSize = 0;
            this.btnResetSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetSettings.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnResetSettings.Location = new System.Drawing.Point(13, 348);
            this.btnResetSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnResetSettings.Name = "btnResetSettings";
            this.btnResetSettings.Size = new System.Drawing.Size(147, 30);
            this.btnResetSettings.TabIndex = 6;
            this.btnResetSettings.Tag = "disable";
            this.btnResetSettings.Text = "Reset All Settings";
            this.btnResetSettings.UseVisualStyleBackColor = false;
            this.btnResetSettings.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.checkBox6.Location = new System.Drawing.Point(13, 172);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(181, 19);
            this.checkBox6.TabIndex = 101;
            this.checkBox6.Text = "Show non-compliant options";
            this.checkBox6.UseVisualStyleBackColor = true;
            // 
            // comboOriginator
            // 
            this.comboOriginator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.comboOriginator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboOriginator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboOriginator.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.comboOriginator.ForeColor = System.Drawing.Color.White;
            this.comboOriginator.FormattingEnabled = true;
            this.comboOriginator.Items.AddRange(new object[] {
            "United States",
            "Canada",
            "Other"});
            this.comboOriginator.Location = new System.Drawing.Point(643, 284);
            this.comboOriginator.Margin = new System.Windows.Forms.Padding(2);
            this.comboOriginator.Name = "comboOriginator";
            this.comboOriginator.Size = new System.Drawing.Size(147, 29);
            this.comboOriginator.TabIndex = 102;
            this.comboOriginator.Tag = "disable";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(801, 419);
            this.Controls.Add(this.comboOriginator);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.btnResetSettings);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblLowRes);
            this.Controls.Add(this.checkBox5);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.lblProduct);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EASEncoder Fusion Settings";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.Label lblLowRes;
        private System.Windows.Forms.Button btnResetSettings;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox comboOriginator;
    }
}