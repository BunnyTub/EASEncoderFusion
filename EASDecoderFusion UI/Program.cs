using EASDecoderFusion_UI.Properties;
using System;
using System.Windows.Forms;

namespace EASDecoderFusion_UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //if (Settings.Default.)
            Application.Run(new MainForm());
        }
    }
}
