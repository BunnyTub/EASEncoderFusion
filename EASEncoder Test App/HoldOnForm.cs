using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class HoldOnForm : Form
    {
        public HoldOnForm()
        {
            InitializeComponent();
        }

        private void HoldOnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("The application is currently processing information.\n\nIf you feel the application has frozen, click YES.\nOtherwise, click NO to continue.", "EASEncoder fusion", MessageBoxButtons.YesNo) != DialogResult.Yes)
            //{
            //    e.Cancel = true;
            //    return;
            //}

            //Environment.FailFast("The user has terminated the processor.", new TaskCanceledException());

            e.Cancel = true;

            // Exit Codes
            // 0 - Success / No Error
            // 1 - Forced Quit
            //Environment.Exit(1);
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
    }
}
