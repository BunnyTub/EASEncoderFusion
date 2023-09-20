using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //ProcessStartInfo psInfo = new ProcessStartInfo
            //{
            //    FileName = "https://discord.gg/2mfsz5bCnk",
            //    UseShellExecute = true
            //};
            //Process.Start(psInfo);
        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Settings\n\n" +
                "'Output errors and warnings quietly'\nThis will completely silence any dialogs that popup.\n\n" +
                "'Use performance themed window style'\nThis can improve visual performance on older systems.\n\n" +
                "'Wait 15 seconds before relaying message'\nThis will process the audio first, wait 15 seconds, then relay it.\n\n" +
                "'Use performance themed fonts'\nThis makes the fonts look a bit better on older versions of Windows, but may cause black boxes around labels.\n\n" +
                "'Quit after message finishes'\nThis closes the application after playback finishes. This doesn't apply to manual stops.\n\n" +
                "'Show non-compliant options'\nShows non-compliant options for creating EAS messages.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show(
                "Runtime\n\n" +
                "'Mock Alert'\nThis is a feature that attempts to prevent activations of TVs and radios. It attempts to achieve this by modifying the S.A.M.E. preamble, and setting the originator to an unknown value (MCK). This will also disable using custom Sender IDs, and will generate a randomized one. If the originator (MCK) becomes an actual originator, it will be modified in the next release. Select any other originator to disable.\n\n", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SilenceErrors = checkBox1.Checked;
            Properties.Settings.Default.Use95Design = checkBox2.Checked;
            Properties.Settings.Default.UseCountdown = checkBox3.Checked;
            Properties.Settings.Default.LegacyFont = checkBox4.Checked;
            Properties.Settings.Default.QuitOnFinish = checkBox5.Checked;
            Properties.Settings.Default.ShowNonCompliant = checkBox6.Checked;
            //Properties.Settings.Default.Swipe = txtCard.Text;
            Properties.Settings.Default.Save();
            MessageBox.Show("Some changes may not take effect until you restart the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            checkBox1.Checked = Properties.Settings.Default.SilenceErrors;
            checkBox2.Checked = Properties.Settings.Default.Use95Design;
            checkBox3.Checked = Properties.Settings.Default.UseCountdown;
            checkBox4.Checked = Properties.Settings.Default.LegacyFont;
            checkBox5.Checked = Properties.Settings.Default.QuitOnFinish;
            checkBox6.Checked = Properties.Settings.Default.ShowNonCompliant;
            this.ResumeLayout();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to restore the settings to their defaults?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                Properties.Settings.Default.Save();
                MessageBox.Show("The application will now restart.");
                Process.Start(Application.ExecutablePath);
                Application.Exit();
            }
        }
    }
}
