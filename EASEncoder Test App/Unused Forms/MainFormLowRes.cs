using System;
using System.Drawing;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class MainFormLowRes : Form
    {
        public MainFormLowRes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            lblTitleBar.Select();
            Application.Exit();
        }

        private bool Minimized = false;

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            lblTitleBar.Select();
            if (Minimized)
            {
                Minimized = false;
                btnMinimize.BackgroundImage = Properties.Resources.minimize;
                foreach (Form form in Application.OpenForms)
                {
                    if (!form.IsDisposed) try { form.Show(); } catch { }
                }
            }
            else
            {
                Minimized = true;
                btnMinimize.BackgroundImage = Properties.Resources.maximize;
                foreach (Form form in Application.OpenForms)
                {
                    if (form != this) try { form.Hide(); } catch { }
                }
            }
            this.BringToFront();
        }

        private void MainFormLowRes_Load(object sender, EventArgs e)
        {
            // Get the current screen
            Screen currentScreen = Screen.FromPoint(this.Location);

            // Calculate the top center point of the screen
            int screenWidth = currentScreen.WorkingArea.Width;
            int topX = currentScreen.WorkingArea.Left + (screenWidth - this.Width) / 2;
            int topY = currentScreen.WorkingArea.Top;

            // Set the form's location to the top center point
            this.Location = new Point(topX, topY + 5);
            this.Opacity = 1.00;
        }

        private void Front_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
