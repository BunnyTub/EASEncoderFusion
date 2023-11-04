using System;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class FusionPopup : Form
    {
        public FusionPopup()
        {
            InitializeComponent();
        }

        private int Clock = 10;
        private bool AllowExit = false;

        private void CloseThisWindow_Tick(object sender, EventArgs e)
        {
            if (Clock == 0)
            {
                CloseThisWindow.Stop();
                AllowExit = true;
                this.Close();
                return;
            }
            Clock--;
            label2.Text = "Continuing in " + Clock.ToString() + "...";
        }

        private void FusionPopup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllowExit) e.Cancel = true;
            else e.Cancel = false;
        }

        private void titlebar_Click(object sender, EventArgs e)
        {
            CloseThisWindow.Interval = 5;
        }

        private void FusionPopup_Load(object sender, EventArgs e)
        {
            AllowExit = Properties.Settings.Default.NoSplash;
            this.Close();
        }
    }
}
