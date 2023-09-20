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
            if (MessageBox.Show("The application is currently processing information.\n\nIf you feel the application has frozen, click YES.\nOtherwise, click NO to continue.", "EASEncoder fusion", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                e.Cancel = true;
                return;
            }

            Environment.FailFast("The user has terminated the processor.", new TaskCanceledException());
        }
    }
}
