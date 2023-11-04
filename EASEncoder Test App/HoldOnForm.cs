using System;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class HoldOnForm : Form
    {
        public HoldOnForm()
        {
            InitializeComponent();
        }

        public void CloseForm()
        {
            this.BeginInvoke(new Action(() => {
                CancelExit = false;
                this.Close();
                }));
        }

        private bool CancelExit = true;

        private void HoldOnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = CancelExit;
        }

        private void HoldOnForm_Load(object sender, EventArgs e)
        {

        }

        private void TakingTooLong_Tick(object sender, EventArgs e)
        {
            this.Size = new System.Drawing.Size(400, 90);
            this.Size = new System.Drawing.Size(400, 110);
            lblTooLong.Show();
            lblTooLong.Text = "Taking too long? Click here to terminate the application.";
            TakingTooLong.Stop();
        }

        private void lblTooLong_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
