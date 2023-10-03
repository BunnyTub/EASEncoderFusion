using System;
using System.Threading;
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
            MessageWait.ShowWait();
            EASEncoderFusion.EASEncoder.CreateNewMessageFromRawData(message: txtCustomData.Text, ebsTone: checkBoxEBS.Checked, nwsTone: checkBoxNWR.Checked, censorTone: checkBoxCENSOR.Checked, filename: txtOutputFile.Text);
            Thread.Sleep(500);
            MessageWait.HideWait();
            MessageBox.Show("Saved successfully.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The custom S.A.M.E. headers you generate may not comply withindustry standards. Please don't broadcast or air these headers on radio or television. As the operator of this software, you take the sole responsibility for any outcomes arising from its usage.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void CustomGenForm_Load(object sender, EventArgs e)
        {
            lblVersion.Text = this.Tag.ToString(); //+ "\nBunnyTub on Discord";
        }
    }
}
