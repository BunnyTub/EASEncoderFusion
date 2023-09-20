using System;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class SwipeCard : Form
    {
        public SwipeCard()
        {
            InitializeComponent();
        }

        private void WaitForSwipe_Tick(object sender, EventArgs e)
        {
            textBox1.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OnCardSwipe.Start();
        }

        private void OnCardSwipe_Tick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text == Properties.Settings.Default.Swipe)
            {
                DialogResult = DialogResult.Yes;
            }
            //else DialogResult = DialogResult.No;
        }
    }
}
