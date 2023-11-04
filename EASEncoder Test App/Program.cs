using EASEncoder_UI.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    internal class Interesting
    {
        public NotifyIcon NtIcon = new NotifyIcon
        {
            BalloonTipIcon = ToolTipIcon.Error,
            BalloonTipTitle = "Encoder Failure",
            BalloonTipText = "Something unexpected has occurred.\nClick here to view more advanced details about the error.",
            Visible = true,
            Text = "EASEncoder Fusion",
            Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath)
        };
    }

    internal static class Program
    {
        static Interesting Notify;

        //public static bool NETCheck()
        //{
        //    using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Client"))
        //    {
        //        if (key != null)
        //        {
        //            if (key.GetValue("Install") is int installed && installed == 1)
        //            {
        //                if (key.GetValue("Version") is string version && version.StartsWith("4.8"))
        //                {
        //                    return true;
        //                }
        //            }
        //        }
        //    }
        //    return false;
        //}
        //
        //if (!NETCheck())
        //{
        //    MessageBox.Show("It appears that .NET Framework 4.8 is not installed. Please install it from the Microsoft website.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    return;
        //}
        //
        // Sadly had to remove or Windows Defender gets triggered.

        static readonly int MajorVersion = 4;
        static readonly int MinorVersion = 0;
        static readonly int Revision = 0;
        static readonly bool DevelopmentBuild = true;
        static string FusionVersion = "v0.0.0";

        /// <summary>
        /// The entry point for EASEncoder Fusion.
        /// </summary>
        [STAThread]
        internal static void Main()
        {
            FusionVersion = "v" + MajorVersion.ToString() + "." + MinorVersion.ToString() + "." + Revision.ToString();
            Settings.Default.VersionOpened = FusionVersion;
            Settings.Default.Save();

            if (!File.Exists("EASEncoderFusion.dll"))
            {
                MessageBox.Show("It appears that you either forgot to extract the *.zip file first, or you have deleted 'EASEncoderFusion.dll'. Please re-download the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!File.Exists("NAudio.dll"))
            {
                MessageBox.Show("It appears that you either forgot to extract the *.zip file first, or you have deleted 'NAudio.dll'. Please re-download the program.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ProperTermination;
            Application.ThreadException += UnhandledTermination;
            Settings.Default.SettingsSaving += SavingContents;

            if (Settings.Default.Use95Design) Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            else Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(Settings.Default.LegacyFont);

            Notify = new Interesting();
            Notify.NtIcon.BalloonTipClicked += ErrorInformation;
            Notify.NtIcon.BalloonTipClosed += ClosedWithoutClick;

            new FusionPopup { Tag = DevelopmentBuild }.ShowDialog();

            //foreach (string unique in deviceNameList)
            //{
            //    if (Environment.MachineName.ToUpper() == unique)
            //    {
            //        MessageBox.Show("This device is banned.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            string[] args = Environment.GetCommandLineArgs();

            if (args.Length > 1)
            {
                string arg = args[1];
                if (!string.IsNullOrEmpty(arg))
                {
                    switch (arg)
                    {
                        case "-c":
                            Application.Run(new CustomGenForm { Tag = FusionVersion });
                            return;
                    }
                }
            }

            Application.Run(new MainForm { Tag = FusionVersion });
        }

        private static void UnhandledTaskTermination(object sender, UnobservedTaskExceptionEventArgs e)
        {
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.Dispose();
            //}

            //HResult = e.Exception.HResult.ToString();
            //ExceptionMessage = e.Exception.Message;
            //ExceptionStackTrace = e.Exception.StackTrace;
            //Notify.NtIcon.ShowBalloonTip(15000);
        }

        private static void AllUnhandledTermination(object sender, UnhandledExceptionEventArgs e)
        {
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.Dispose();
            //}
            
            //HResult = "???";
            //ExceptionMessage = "An unknown error has occurred.";
            //ExceptionStackTrace = "Unknown stack trace.";
            //Notify.NtIcon.ShowBalloonTip(15000);
        }

        private static void ClosedWithoutClick(object sender, EventArgs e)
        {
            //Notify.NtIcon.ShowBalloonTip(15000);
        }

        private static string HResult = "?";
        private static string ExceptionMessage = "An unknown error has occurred.";
        private static string ExceptionStackTrace = "Unknown stack trace.";

        private static void ErrorInformation(object sender, EventArgs e)
        {
            Notify.NtIcon.Visible = false;
            System.Windows.Forms.MessageBox.Show(HResult + "\n" + ExceptionMessage + "\n" + ExceptionStackTrace + "\n\nIt may be possible to continue normally.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            foreach (Form form in Application.OpenForms)
            {
                if (form.CanFocus && !form.InvokeRequired) form.BringToFront();
            }
            Notify.NtIcon.Visible = true;
        }

        //private static void ExternalUI()
        //{
        //    Application.Run(new MainFormLowRes());
        //}

        private static void SavingContents(object sender, CancelEventArgs e)
        {
            
        }

        //static string GetDownloadUrl(string releaseUrl)
        //{
        //    using (var client = new WebClient())
        //    {
        //        try
        //        {
        //            string htmlContent = client.DownloadString(releaseUrl);
        //            int assetIndex = htmlContent.IndexOf("browser_download_url");

        //            if (assetIndex != -1)
        //            {
        //                int downloadUrlStartIndex = htmlContent.IndexOf('"', assetIndex) + 1;
        //                int downloadUrlEndIndex = htmlContent.IndexOf('"', downloadUrlStartIndex);

        //                return htmlContent.Substring(downloadUrlStartIndex, downloadUrlEndIndex - downloadUrlStartIndex);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error fetching release information. " + ex.Message);
        //        }
        //    }

        //    return null;
        //}

        internal static void ProperTermination(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                form.Dispose();
            }
        }

        public static void UnhandledTermination(object sender, ThreadExceptionEventArgs e)
        {
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            //foreach (Form form in Application.OpenForms)
            //{
            //    form.Dispose();
            //}

            if (e.Exception == new NullReferenceException())
            {
                //Debug.Fail("Null reference occurred in code. This may possibly be due to system events, and is probably not related to the application.");
                //Debug.WriteLine(e.Exception.Message);
                //Debug.Flush();
                return;
            }

            if (e.Exception.HResult == -2147467261)
            {
                //Debug.Fail("Object exists, but is not assigned. This may possibly be due to system events, and is probably not related to the application.");
                //Debug.WriteLine(e.Exception.Message);
                //Debug.Flush();
                return;
            }
            
            //try { MessageWait.HideWait(); } catch (Exception) { }
            //Debug.Fail("Failure. Check exception.");
            //Debug.WriteLine(e.Exception.Message);
            //Debug.Flush();
            HResult = e.Exception.HResult.ToString();
            ExceptionMessage = e.Exception.Message;
            ExceptionStackTrace = e.Exception.StackTrace;
            Notify.NtIcon.ShowBalloonTip(15000);
        }
    }

    static public class Theme
    {
        // /// <summary>
        // /// Changes the provided Form to a theme.
        // /// </summary>
        // /// <param name="form">The Form to apply changes to.</param>

        // Finished
        public static void BlackStyle(Form form, bool loadOnly)
        {
            if (!loadOnly)
            {
                Settings.Default.StyleColor = "Black";
                Settings.Default.Save();
            }
            form.BackColor = Color.Black;
            form.ForeColor = Color.White;
            foreach (Control ctrl in form.Controls)
            {
                if (!(ctrl is DataGridView) && !ctrl.Name.Contains("btnGenerate"))
                {
                    try
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                    catch (Exception)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 40, 40, 40);
                    }

                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 40, 40, 40);
                    }
                    ctrl.ForeColor = Color.White;
                    continue;
                }

                if (ctrl.Name == "datagridRegions")
                {
                    ((DataGridView)ctrl).BackgroundColor = Color.FromArgb(255, 40, 40, 40);
                    ((DataGridView)ctrl).GridColor = Color.FromArgb(255, 40, 40, 40);
                    ((DataGridView)ctrl).DefaultCellStyle.BackColor = SystemColors.WindowFrame;
                    ((DataGridView)ctrl).DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    continue;
                }
            }
        }

        // Finished
        public static void WhiteStyle(Form form, bool loadOnly)
        {
            if (!loadOnly)
            {
                Settings.Default.StyleColor = "White";
                Settings.Default.Save();
            }
            form.BackColor = Color.FromArgb(255, 255, 255, 255);
            form.ForeColor = Color.FromArgb(255, 0, 0, 0);
            foreach (Control ctrl in form.Controls)
            {
                if (!ctrl.Name.Contains("btnGenerate") && !(ctrl is DataGridView))
                {
                    try
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                    catch (Exception)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 235, 235, 235);
                    }

                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 235, 235, 235);
                    }
                    ctrl.ForeColor = Color.Black;
                    continue;
                }

                if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(255, 255, 255, 255);
                    grid.GridColor = Color.FromArgb(255, 235, 235, 235);
                    grid.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235, 235);
                    grid.DefaultCellStyle.ForeColor = Color.FromArgb(255, 0, 0, 0);
                    continue;
                }
            }
        }

        // Finished
        public static void RedStyle(Form form, bool loadOnly)
        {
            if (!loadOnly)
            {
                Settings.Default.StyleColor = "Red";
                Settings.Default.Save();
            }
            form.BackColor = Color.DarkRed;
            form.ForeColor = Color.White;
            foreach (Control ctrl in form.Controls)
            {
                if (!(ctrl is DataGridView) && !ctrl.Name.Contains("btnGenerate"))
                {
                    try
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                    catch (Exception)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 220, 0, 0);
                    }

                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 220, 0, 0);
                    }
                    ctrl.ForeColor = Color.White;
                    continue;
                }

                if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(255, 255, 0, 0);
                    grid.GridColor = Color.FromArgb(255, 220, 0, 0);
                    grid.DefaultCellStyle.BackColor = Color.FromArgb(255, 220, 0, 0);
                    grid.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    continue;
                }
            }
        }

        // Finished
        public static void GreenStyle(Form form, bool loadOnly)
        {
            if (!loadOnly)
            {
                Settings.Default.StyleColor = "Green";
                Settings.Default.Save();
            }
            form.BackColor = Color.DarkGreen;
            form.ForeColor = Color.White;
            foreach (Control ctrl in form.Controls)
            {
                if (!(ctrl is DataGridView) && !ctrl.Name.Contains("btnGenerate"))
                {
                    try
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                    catch (Exception)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 0, 200, 0);
                    }

                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 0, 200, 0);
                    }
                    ctrl.ForeColor = Color.White;
                    continue;
                }

                if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(255, 0, 220, 0);
                    grid.GridColor = Color.FromArgb(255, 0, 200, 0);
                    grid.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 200, 0);
                    grid.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    continue;
                }
            }
        }

        // Finished
        public static void BlueStyle(Form form, bool loadOnly)
        {
            if (!loadOnly)
            {
                Settings.Default.StyleColor = "Blue";
                Settings.Default.Save();
            }
            form.BackColor = Color.DarkBlue;
            form.ForeColor = Color.White;
            foreach (Control ctrl in form.Controls)
            {
                if (!(ctrl is DataGridView) && !ctrl.Name.Contains("btnGenerate"))
                {
                    try
                    {
                        ctrl.BackColor = Color.Transparent;
                    }
                    catch (Exception)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 0, 0, 220);
                    }

                    if (ctrl is Button)
                    {
                        ctrl.BackColor = Color.FromArgb(255, 0, 0, 220);
                    }
                    ctrl.ForeColor = Color.White;
                    continue;
                }

                if (ctrl is DataGridView grid)
                {
                    grid.BackgroundColor = Color.FromArgb(255, 0, 0, 100);
                    grid.GridColor = Color.FromArgb(255, 0, 0, 220);
                    grid.DefaultCellStyle.BackColor = Color.FromArgb(255, 0, 0, 220);
                    grid.DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    continue;
                }
            }
        }
    }

    public static class MessageWait
    {
        static Thread t;

        public static void ShowWait()
        {
            t = new Thread(new ThreadStart(Show));
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        public static void HideWait()
        {
            if (t.ThreadState == ThreadState.Running)
            {
                HoldOn.CloseForm();
                t.Join();
            }
            t = null;
        }

        internal static HoldOnForm HoldOn = new HoldOnForm();

        internal static void Show()
        {
            Application.ThreadException += Application_ThreadException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            HoldOn = new HoldOnForm();
            HoldOn.ShowDialog();
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {

        }

    }

    public static class MessageBox
    {
        public static DialogResult Show(string text = "", string title = "EASEncoder Fusion", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            try
            {
                if (Settings.Default.SilenceErrors) return System.Windows.Forms.MessageBox.Show(text, title, buttons);
                else return System.Windows.Forms.MessageBox.Show(text, title, buttons, icon);
            }
            catch (Exception)
            {
                return DialogResult.None;
            }
        }
    }

    //public class AutoUpdater
    //{
    //    //private const string GitHubOwner = "gadielisawesome";
    //    //private const string GitHubRepo = "EASEncoderFusion";
    //    //private const string ReleasesUrl = "https://api.github.com/repos/" + GitHubOwner + "/" + GitHubRepo + "/releases/latest";

    //    //public void CheckForUpdates(string CurrentVersion)
    //    //{
    //    //    using (var client = new WebClient())
    //    //    {
    //    //        client.Headers.Add("User-Agent", "request"); // GitHub API requires a user-agent header

    //    //        try
    //    //        {
    //    //            var json = client.DownloadString(ReleasesUrl);
    //    //            var options = new JsonSerializerOptions
    //    //            {
    //    //                PropertyNameCaseInsensitive = true
    //    //            };

    //    //            var release = JsonSerializer.Deserialize<Release>(json, options);
    //    //            string latestVersion = release.TagName;

    //    //            if (latestVersion != CurrentVersion)
    //    //            {
    //    //                // New version available, download and update
    //    //                string downloadUrl = release.Assets[0].BrowserDownloadUrl; // Assuming the first asset is the update file
    //    //                //DownloadAndReplaceFiles(downloadUrl);

    //    //                // Restart the application
    //    //                RestartApplication();
    //    //            }
    //    //            else
    //    //            {
    //    //                Console.WriteLine("No updates available.");
    //    //            }
    //    //        }
    //    //        catch (Exception ex)
    //    //        {
    //    //            Console.WriteLine("Error checking for updates: " + ex.Message);
    //    //        }
    //    //    }
    //    //}

    //    //private async Task DownloadAndReplaceFiles(string downloadUrl)
    //    //{
    //    //    using (var client = new WebClient())
    //    //    {
    //    //        // Download the update file
    //    //        await client.DownloadFileTaskAsync(downloadUrl, "update.zip");

    //    //        // Extract and replace files as needed
    //    //        // Implement the logic here to extract the downloaded zip file and replace/update the necessary files in your application directory
    //    //    }
    //    //}

    //    //private void RestartApplication()
    //    //{
    //    //    // Start a new instance of your application and exit the current instance
    //    //    Process.Start("path_to_your_application.exe");
    //    //    Environment.Exit(0);
    //    //}

    //    //private class Release
    //    //{
    //    //    public string TagName { get; set; }
    //    //    public Asset[] Assets { get; set; }
    //    //}

    //    //private class Asset
    //    //{
    //    //    public string BrowserDownloadUrl { get; set; }
    //    //}
    //}
}