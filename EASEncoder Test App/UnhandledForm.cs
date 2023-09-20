using System;
using System.Drawing;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class UnhandledForm : Form
    {
        /// <summary>
        /// Used for component initialization. Do not remove.
        /// </summary>
        public UnhandledForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Flashes btnTerminate white and red.
        /// </summary>
        private void UpTown_Tick(object sender, EventArgs e)
        {
            btnTerminate.BackColor = (btnTerminate.BackColor == Color.Red) ? Color.White : Color.Red;
            btnTerminate.ForeColor = (btnTerminate.BackColor == Color.White) ? Color.Red : Color.White;
            btnTerminate.FlatAppearance.BorderColor = Color.OrangeRed;
            btnTerminate.FlatAppearance.BorderSize = 1;
            btnTerminate.Enabled = true;
        }

        /// <summary>
        /// Closes all open windows on event.
        /// </summary>
        private void UnhandledForm_Shown(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (this != form) form.Dispose();
            }
        }

        private void btnTerminate_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UnhandledForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
