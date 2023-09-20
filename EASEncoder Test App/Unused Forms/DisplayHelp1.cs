using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Management;
using System.Threading;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class DisplayHelp1 : Form
    {
        public DisplayHelp1()
        {
            InitializeComponent();
        }

        private void btnActivate_Click(object sender, EventArgs e)
        {
            try
            {
                btnInstall.Enabled = false;
                string tempDirectory = Path.Combine(Path.GetTempPath(), "usbmmidd\\");

                Process.Start(tempDirectory, "");

                //using (Stream zipStream = new MemoryStream(Properties.Resources.usbmmidd_v2))
                //{
                //    using (ZipArchive archive = new ZipArchive(zipStream))
                //    {
                //        foreach (ZipArchiveEntry entry in archive.Entries)
                //        {
                //            string destinationPath = Path.Combine(tempDirectory, entry.FullName);

                //            // Create directory structure if necessary
                //            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                //            if (entry.Length > 0)
                //            {
                //                using (Stream entryStream = entry.Open())
                //                {
                //                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create))
                //                    {
                //                        entryStream.CopyTo(fileStream);
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}

                string pathToDeviceInstaller = tempDirectory + "deviceinstaller64.exe";

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pathToDeviceInstaller,
                    Arguments = "install usbmmidd.inf usbmmidd",
                    Verb = "runas",
                    WorkingDirectory = tempDirectory
                };

                try
                {
                    Process proc = Process.Start(startInfo);
                    proc.WaitForExit();
                    if (proc.ExitCode != 0)
                    {
                        MessageBox.Show("An error has occurred. (" + proc.ExitCode.ToString() + ")", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TitleBar.Text = "Activation Failed";
                        this.DialogResult = DialogResult.No;
                        return;
                    }

                    startInfo.Arguments = "enableidd 1";
                    Process procs = Process.Start(startInfo);
                    procs.WaitForExit();
                    if (procs.ExitCode != 0)
                    {
                        MessageBox.Show("An error has occurred. (" + procs.ExitCode.ToString() + ")", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TitleBar.Text = "Activation Failed";
                        this.DialogResult = DialogResult.No;
                        return;
                    }

                    Thread.Sleep(5000);

                    if (FindGenericNonPnPMonitor())
                    {
                        MessageBox.Show("Installation succeeded.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        TitleBar.Text = "Activation Successful";
                        this.DialogResult = DialogResult.Yes;
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Installation failed.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        TitleBar.Text = "Activation Failed";
                        this.DialogResult = DialogResult.No;
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Installation failed.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TitleBar.Text = "Activation Failed";
                    this.DialogResult = DialogResult.No;
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Installation failed.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.No;
            }
        }

        static bool FindGenericNonPnPMonitor()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name LIKE '%USB Mobile Monitor Virtual Display%'");
                ManagementObjectCollection monitors = searcher.Get();

                return monitors.Count > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while querying for data. " + ex.Message);
                return false;
            }
        }

        private bool FindGenericNonPnPVirtualGraphicsCard()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController WHERE Description LIKE '%USB Mobile Monitor Virtual Display%'");
            ManagementObjectCollection displayAdapters = searcher.Get();

            return displayAdapters.Count > 0;
        }

        private void HelpDisplayForm_Load(object sender, EventArgs e)
        {
            btnInstall.Enabled = false;
            if (!FindGenericNonPnPMonitor())
            {
                if (!FindGenericNonPnPVirtualGraphicsCard())
                {
                    btnInstall.Enabled = true;
                    return;
                }
                else
                {
                    // The monitor isn't connected, however the driver is installed.
                    // Let's enable the virtual monitor.

                    TitleBar.Text = "Waiting For Activation";

                    MessageBox.Show("Click OK to enable USBMMIDD_v2.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    try
                    {
                        string tempDirectory = Path.Combine(Path.GetTempPath(), "usbmmidd\\");

                        //using (Stream zipStream = new MemoryStream(Properties.Resources.usbmmidd_v2))
                        //{
                        //    using (ZipArchive archive = new ZipArchive(zipStream))
                        //    {
                        //        foreach (ZipArchiveEntry entry in archive.Entries)
                        //        {
                        //            string destinationPath = Path.Combine(tempDirectory, entry.FullName);

                        //            // Create directory structure if necessary
                        //            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        //            if (entry.Length > 0)
                        //            {
                        //                using (Stream entryStream = entry.Open())
                        //                {
                        //                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create))
                        //                    {
                        //                        entryStream.CopyTo(fileStream);
                        //                    }
                        //                }
                        //            }
                        //        }
                        //    }
                        //}

                        string pathToDeviceInstaller = tempDirectory + "deviceinstaller64.exe";

                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = pathToDeviceInstaller,
                            Arguments = "enable idd 1",
                            Verb = "runas",
                            WorkingDirectory = tempDirectory
                        };

                        Process procs = Process.Start(startInfo);
                        procs.WaitForExit();
                        if (procs.ExitCode != 0)
                        {
                            MessageBox.Show("An error has occurred. (" + procs.ExitCode.ToString() + ")", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            TitleBar.Text = "Activation Failed";
                            this.DialogResult = DialogResult.No;
                            return;
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Installation failed.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = DialogResult.No;
                    }
                }
            }
            else
            {
                // Everything is working properly.
                // "Do you see the test pattern?"
                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
        }

        private void DisplayHelp1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //MessageBox.Show("Installation cancelled.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (this.DialogResult != DialogResult.Yes) this.DialogResult = DialogResult.No;
        }
    }
}
