//namespace EASEncoder_UI
//{
//    partial class BarScanForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.pictureBoxCameraFeed = new System.Windows.Forms.PictureBox();
//            this.btnManualEntry = new System.Windows.Forms.Button();
//            this.BarcodeTimer = new System.Windows.Forms.Timer(this.components);
//            this.btnClose = new System.Windows.Forms.Button();
//            this.comboCameraList = new System.Windows.Forms.ComboBox();
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCameraFeed)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // pictureBoxCameraFeed
//            // 
//            this.pictureBoxCameraFeed.BackColor = System.Drawing.Color.Black;
//            this.pictureBoxCameraFeed.Dock = System.Windows.Forms.DockStyle.Fill;
//            this.pictureBoxCameraFeed.Location = new System.Drawing.Point(0, 0);
//            this.pictureBoxCameraFeed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
//            this.pictureBoxCameraFeed.Name = "pictureBoxCameraFeed";
//            this.pictureBoxCameraFeed.Size = new System.Drawing.Size(500, 300);
//            this.pictureBoxCameraFeed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
//            this.pictureBoxCameraFeed.TabIndex = 0;
//            this.pictureBoxCameraFeed.TabStop = false;
//            // 
//            // btnManualEntry
//            // 
//            this.btnManualEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
//            this.btnManualEntry.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnManualEntry.Font = new System.Drawing.Font("Segoe UI Black", 10F);
//            this.btnManualEntry.ForeColor = System.Drawing.Color.White;
//            this.btnManualEntry.Location = new System.Drawing.Point(9, 9);
//            this.btnManualEntry.Margin = new System.Windows.Forms.Padding(0);
//            this.btnManualEntry.Name = "btnManualEntry";
//            this.btnManualEntry.Size = new System.Drawing.Size(368, 36);
//            this.btnManualEntry.TabIndex = 1;
//            this.btnManualEntry.Text = "Enter ID Manually";
//            this.btnManualEntry.UseVisualStyleBackColor = false;
//            this.btnManualEntry.Click += new System.EventHandler(this.button1_Click);
//            // 
//            // BarcodeTimer
//            // 
//            this.BarcodeTimer.Enabled = true;
//            this.BarcodeTimer.Interval = 500;
//            this.BarcodeTimer.Tick += new System.EventHandler(this.timer1_Tick);
//            // 
//            // btnClose
//            // 
//            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
//            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
//            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F);
//            this.btnClose.ForeColor = System.Drawing.Color.White;
//            this.btnClose.Location = new System.Drawing.Point(376, 9);
//            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
//            this.btnClose.Name = "btnClose";
//            this.btnClose.Size = new System.Drawing.Size(69, 36);
//            this.btnClose.TabIndex = 2;
//            this.btnClose.Text = "Close";
//            this.btnClose.UseVisualStyleBackColor = false;
//            // 
//            // comboCameraList
//            // 
//            this.comboCameraList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
//            this.comboCameraList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.comboCameraList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.comboCameraList.Font = new System.Drawing.Font("Segoe UI", 12F);
//            this.comboCameraList.ForeColor = System.Drawing.Color.White;
//            this.comboCameraList.FormattingEnabled = true;
//            this.comboCameraList.Location = new System.Drawing.Point(9, 44);
//            this.comboCameraList.Margin = new System.Windows.Forms.Padding(0);
//            this.comboCameraList.Name = "comboCameraList";
//            this.comboCameraList.Size = new System.Drawing.Size(436, 29);
//            this.comboCameraList.TabIndex = 3;
//            this.comboCameraList.Tag = "disable";
//            // 
//            // BarScanForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(500, 300);
//            this.ControlBox = false;
//            this.Controls.Add(this.comboCameraList);
//            this.Controls.Add(this.btnClose);
//            this.Controls.Add(this.btnManualEntry);
//            this.Controls.Add(this.pictureBoxCameraFeed);
//            this.Font = new System.Drawing.Font("Segoe UI", 9F);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.Name = "BarScanForm";
//            this.ShowIcon = false;
//            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
//            this.Text = "Barcode Scanner";
//            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
//            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BarScanForm_FormClosing);
//            this.Load += new System.EventHandler(this.BarScanForm_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCameraFeed)).EndInit();
//            this.ResumeLayout(false);

//        }

//        #endregion

//        private System.Windows.Forms.PictureBox pictureBoxCameraFeed;
//        private System.Windows.Forms.Button btnManualEntry;
//        private System.Windows.Forms.Timer BarcodeTimer;
//        private System.Windows.Forms.Button btnClose;
//        private System.Windows.Forms.ComboBox comboCameraList;
//    }
//}