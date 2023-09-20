using EASEncoder_UI.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

        [STAThread]
        internal static void Main()
        {
            //Environment.GetCommandLineArgs();
            //Environment.FailFast("Product activation was modified by the user. This is a violation of the licensing terms.");
            //int a = 0;
            //foreach (string arg in Environment.GetCommandLineArgs())
            //{
            //    if (a != 1)
            //    {
            //        a++;
            //    }
            //    if (arg == "") a++;
            //    //MessageBox.Show(arg);
            //}

            int MajorVersion = 3;
            int MinorVersion = 1;
            int Revision = 0;
            string FusionVersion = "v" + MajorVersion.ToString() + "." + MinorVersion.ToString() + "." + Revision.ToString();

            if (Settings.Default.VersionOpened != FusionVersion)
            {
                if (Settings.Default.VersionOpened != "v0.0.0")
                {
                    if (MessageBox.Show("Another version of the program has been detected.\nIt may malfunction if you open this version.\n\nDo you want to continue?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
                    Settings.Default.VersionOpened = FusionVersion;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.VersionOpened = FusionVersion;
                    Settings.Default.Save();
                }
            }


            string[] deviceNameList = {
                //"QUANTUM-FURRET"
            };

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ApplicationExit += ProperTermination;
            Application.ThreadException += UnhandledTermination;
            AppDomain.CurrentDomain.UnhandledException += AllUnhandledTermination;
            TaskScheduler.UnobservedTaskException += UnhandledTaskTermination;
            Settings.Default.SettingsSaving += SavingContents;

            if (Settings.Default.Use95Design) Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            else Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.ClientAndNonClientAreasEnabled;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(Settings.Default.LegacyFont);

            Notify = new Interesting();
            Notify.NtIcon.BalloonTipClicked += ErrorInformation;
            Notify.NtIcon.BalloonTipClosed += ClosedWithoutClick;

            //if (new BarScanForm().ShowDialog() != DialogResult.Yes) return;

            //new UnhandledForm().ShowDialog();

            if (Settings.Default.Use95Design || Settings.Default.LegacyFont) Console.WriteLine("Using compatibility mode.");
            else new FusionPopup { Tag = FusionVersion }.ShowDialog();

            foreach (string deviceName in deviceNameList)
            {
                if (Environment.MachineName.ToUpper() == deviceName)
                {
                    MessageBox.Show("This device is banned.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

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

                //MessageBox.Show("This program is in pre-release stages and is known to be unstable. Use caution before proceeding. Do not rely on this software for life threatening situations.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (Screen.PrimaryScreen.Bounds.Width < 1599 || Screen.PrimaryScreen.Bounds.Height < 899)
                {
                    MessageBox.Show("The resolution on this display is lower than the recommended minimum of 1600x900. Some elements may not fit on the screen.");
                    //Settings.Default.LowRes = true;
                    //Settings.Default.Save();
                }
                Application.Run(new MainForm { Tag = FusionVersion });
                //Application.Run(new MainFormLowRes());
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
                form.BringToFront();
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
                Debug.Fail("Null reference occurred in code. This may possibly be due to system events, and is probably not related to the application.");
                Debug.WriteLine(e.Exception.Message);
                Debug.Flush();
                return;
            }

            if (e.Exception.HResult == -2147467261)
            {
                Debug.Fail("Object exists, but is not assigned. This may possibly be due to system events, and is probably not related to the application.");
                Debug.WriteLine(e.Exception.Message);
                Debug.Flush();
                return;
            }
            
            try { MessageWait.HideWait(); } catch (Exception) { }
            Debug.Fail("Failure. Check exception.");
            Debug.WriteLine(e.Exception.Message);
            Debug.Flush();
            HResult = e.Exception.HResult.ToString();
            ExceptionMessage = e.Exception.Message;
            ExceptionStackTrace = e.Exception.StackTrace;
            Notify.NtIcon.ShowBalloonTip(15000);
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
            if (t.ThreadState == System.Threading.ThreadState.Running) t.Abort();
            t = null;
        }

        internal static void Show()
        {
            HoldOnForm HoldOn = new HoldOnForm();
            HoldOn.ShowDialog(null);
        }
    }

    public static class MessageBox
    {
        public static DialogResult Show(string text = "", string title = "EASEncoder Fusion", MessageBoxButtons buttons = MessageBoxButtons.OK, MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            if (Settings.Default.SilenceErrors) return System.Windows.Forms.MessageBox.Show(text, title, buttons);
            else return System.Windows.Forms.MessageBox.Show(text, title, buttons, icon);
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