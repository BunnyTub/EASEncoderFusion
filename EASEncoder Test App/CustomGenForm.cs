using System;
using System.Drawing;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class CustomGenForm : Form
    {
        public CustomGenForm()
        {
            InitializeComponent();
        }

        private void txtCustomData_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAnnouncement_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOutputFile_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Create your custom message?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            EASEncoderFusion.EASEncoder.CreateNewMessageFromRawData(message: txtCustomData.Text, ebsTone: checkBoxEBS.Checked, nwsTone: checkBoxNWR.Checked, censorTone: checkBoxNWR.Checked, filename: txtOutputFile.Text);
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Size = new Size(544, 574);
            button3.Enabled = false;
            //button4.Show();
            this.ResumeLayout();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Size = new Size(920, 574);
            button3.Enabled = true;
            button4.Hide();
            this.ResumeLayout();
        }
    }
}
