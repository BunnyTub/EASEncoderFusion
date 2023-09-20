using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Media;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Forms;
using EASEncoder.Models;
using EASEncoder.Models.SAME;
using EASEncoder_UI.Properties;
using NAudio.Wave;

namespace EASEncoder_UI
{
    public partial class MainForm : Form
    {
        private readonly List<SAMERegion> Regions = new List<SAMERegion>();
        private string _length;
        private SAMEMessageAlertCode _selectedAlertCode;
        private SAMECounty _selectedCounty;
        private SAMEMessageOriginator _selectedOriginator;
        private SAMEState _selectedState;
        private string _senderId;
        private DateTime _start;
        private WaveOutEvent player;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();

            //if (Debugger.IsAttached)
            //{
            //    //chkStressTest.Show();
            //}
            //else
            //{
            //    //chkStressTest.Hide();
            //}

            if (File.Exists("label.ini"))
            {
                this.Text = File.OpenText("label.ini").ReadToEnd();
            }

            lblVersion.Text = this.Tag.ToString() + "\nBunnyTub on Discord";
            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            lblOutputDirectory.Text = Environment.CurrentDirectory;
            var bindingList = new BindingList<SAMERegion>(Regions);
            var source = new BindingSource(bindingList, null);
            datagridRegions.DataSource = source;

            dateStart.ShowUpDown = true;
            dateStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dateStart.Format = DateTimePickerFormat.Custom;

            bool DoNotShowIllegal = Settings.Default.ShowNonCompliant;

            var alerts = MessageTypes.AlertCodes
            .Where(x => x.Compliant == true) // Change to x => x.Compliant == false for false values
            .OrderBy(x => x.Name)
            .Select(x => x.Name)
            .ToArray();

            var originators = MessageTypes.Originators
            .Where(x => x.Compliant == true) // Change to x => x.Compliant == false for false values
            .OrderBy(x => x.Name)
            .Select(x => x.Name)
            .ToArray();

            comboState.Items.AddRange(MessageRegions.States.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
            if (!DoNotShowIllegal) comboCode.Items.AddRange(alerts);
            else comboCode.Items.AddRange(MessageTypes.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
            if (!DoNotShowIllegal) comboOriginator.Items.AddRange(originators);
            else comboOriginator.Items.AddRange(MessageTypes.Originators.OrderBy(x => x.Name).Select(x => x.Name).ToArray());

            for (int x = 0; x <= 99; x++)
            {
                if (x <= 60)
                {
                    comboLengthMinutes.Items.Add(x.ToString());
                }
                comboLengthHour.Items.Add(x.ToString());
            }

            comboOriginator.DrawItem += ComboBox1_DrawItem;
            comboOriginator.MeasureItem += ComboBox1_MeasureItem;

            this.ResumeLayout();
        }

        private void ComboState_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedState = MessageRegions.States.FirstOrDefault(x => x.Name == comboState.Text);
            if (_selectedState != null)
            {
                comboCounty.Items.Clear();
                comboCounty.Text = "";
                _selectedCounty = null;
                foreach (
                    var thisCounty in
                        MessageRegions.Counties.Where(x => x.state.Id == _selectedState.Id).OrderBy(x => x.Name))
                {
                    comboCounty.Items.Add(thisCounty.Name);
                }
                //if (comboState.SelectedItem.ToString() == "Ohio")
                //{
                //    try
                //    {
                //        //SoundPlayer player = new SoundPlayer("https://github.com/gadielisawesome/files/raw/master/boom.wav");
                //        //player.Load();
                //        //player.Play();
                //        //if (player != null && player.IsLoadCompleted)
                //        //    player.Stop();
                //    }
                //    catch (Exception)
                //    {
                        
                //    }
                //}
            }
        }

        private void ComboCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCounty =
                MessageRegions.Counties.FirstOrDefault(
                    x => x.state.Id == _selectedState.Id && x.Name == comboCounty.Text);
        }

        private void ComboCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedAlertCode = MessageTypes.AlertCodes.FirstOrDefault(y => y.Name == comboCode.Text);
            if (_selectedAlertCode != null && !_selectedAlertCode.Compliant)
            {
                MessageBox.Show("The event " + "\"" + _selectedAlertCode.Id + "\"" + " is unofficial, and does not comply with Emergency Alert System standards.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //bool MockAlertShown = false;

        private void ComboOriginator_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedOriginator = MessageTypes.Originators.FirstOrDefault(y => y.Name == comboOriginator.Text);
            if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
            {
                //if (!MockAlertShown)
                //{
                //    MessageBox.Show("You have activated the Mock Alert. Select any other originator to disable. This is a feature that attempts to prevent activations of TVs and radios. It attempts to achieve this by modifying the S.A.M.E. preamble, and setting the originator to an unknown value (MCK). This will also disable using custom Sender IDs, and will generate a randomized one.\n\nIf the originator (MCK) becomes an actual originator, it will be changed in the next version.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    MockAlertShown = true;
                //}
                txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
                txtSender.ReadOnly = true;
                btnRandomID.Enabled = false;
                Randomization.Start();
                return;
            }
            else
            {
                txtSender.ReadOnly = false;
                btnRandomID.Enabled = true;
                Randomization.Stop();
            }

            SAMEMessageOriginator selectedOriginator = MessageTypes.Originators.FirstOrDefault(x => x.Name == comboOriginator.SelectedItem.ToString());
            if (selectedOriginator != null && !selectedOriginator.Compliant)
            {
                MessageBox.Show("The originator " + "\"" + selectedOriginator.Id + "\"" + " is unofficial, and does not comply with Emergency Alert System standards.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ComboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            //e.ItemHeight = 20; // Set the desired item height
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //// Check if the current item is the "Mock Alert" item
            //if (e.Index >= 0 && comboOriginator.Items[e.Index].ToString() == "Mock Alert")
            //{
            //    // Set the desired color for the "Mock Alert" item
            //    e.Graphics.DrawString(comboOriginator.Items[e.Index].ToString(), e.Font, Brushes.Red, e.Bounds);
            //}
            //else
            //{
            //    // Set the default color for other items
            //    e.DrawBackground();
            //    e.Graphics.DrawString(comboOriginator.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds);
            //}
        }


        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidateInput(true))
            {
                return;
            }

            if (chkBurstHeaders.Checked)
            {
                MessageBox.Show("You cannot save a SASMEX message.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _start = dateStart.Value.ToUniversalTime();
            _senderId = txtSender.Text;
            _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);

            var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
                Regions, _length, _start, _senderId);

            if (string.IsNullOrEmpty(txtOutputFile.Text))
            {
                MessageBox.Show("You must enter a valid file name for the EAS audio message.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string illegalFileNameCharacter = "<>:\"/\\|?*";
            string outputFileName = txtOutputFile.Text;

            foreach (char illegalChar in illegalFileNameCharacter)
            {
                if (outputFileName.Contains(illegalChar))
                {
                    return;
                }
            }

            if (outputFileName == ("con") ||
                outputFileName == ("prn") ||
                outputFileName == ("aux") ||
                outputFileName == ("nul") ||
                outputFileName == ("com1") ||
                outputFileName == ("com2") ||
                outputFileName == ("com3") ||
                outputFileName == ("com4") ||
                outputFileName == ("com5") ||
                outputFileName == ("com6") ||
                outputFileName == ("com7") ||
                outputFileName == ("com8") ||
                outputFileName == ("com9") ||
                outputFileName == ("lpt1") ||
                outputFileName == ("lpt2") ||
                outputFileName == ("lpt3") ||
                outputFileName == ("lpt4") ||
                outputFileName == ("lpt5") ||
                outputFileName == ("lpt6") ||
                outputFileName == ("lpt7") ||
                outputFileName == ("lpt8") ||
                outputFileName == ("lpt9"))
            {
                MessageBox.Show("Object error. Check the file name and try again.");
                return;
            }

            StringBuilder extractedText = new StringBuilder();
            foreach (DataGridViewRow row in datagridRegions.Rows)
            {
                bool isNotEnd = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        extractedText.Append(cell.Value.ToString());
                        if (isNotEnd)
                        {
                            extractedText.Append(", ");
                            isNotEnd = false;
                        }
                    }
                }
                extractedText.AppendLine();
            }

            string locationText = extractedText.ToString().TrimEnd();

            DateTime ClockEnd = _start;
            ClockEnd = ClockEnd.AddHours(comboLengthHour.SelectedIndex);
            ClockEnd = ClockEnd.AddMinutes(comboLengthMinutes.SelectedIndex);
            if (MessageBox.Show("Save the following message?\n\n" +
                "Originator: " + comboOriginator.Text + "\n" +
                "Event Type: " + comboCode.Text + "\n" +
                "EBS Tone: " + chkEbsTones.Checked.ToString() + "\n" +
                "NWS Tone: " + chkNwsTone.Checked.ToString() + "\n" +
                "BEEP Tone: " + chkCensorTone.Checked.ToString() + "\n" +
                "Announcement Generated: " + chkGenerateAnnouncement.Checked.ToString() + "\n" +
                "Starting At: " + _start.ToString("u").Substring(0, _start.ToString("u").Length - 1) + " UTC\n" +
                "Ending At: " + ClockEnd.ToString("u").Substring(0, ClockEnd.ToString("u").Length - 1) + " UTC\n" +
                "Locations:\n" + locationText, "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            var generatedData = EASEncoderFusion.EASEncoder.CreateNewMessage(newMessage, chkEbsTones.Checked, chkNwsTone.Checked, chkCensorTone.Checked,
                FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked, txtOutputFile.Text);
            var generatedData2 = generatedData.Replace("\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab\xab", "[Preamble]");
            txtGeneratedData.Text = generatedData2;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            GeneratePlay();
            //if (UseCard()) GeneratePlay();
            //else MessageBox.Show("General read failure or timed out.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool UseBarcode()
        {
            //if (new BarScanForm().ShowDialog() == DialogResult.Yes)
            //{
            //    return true;
            //}
            //else return false;
            return false;
        }

        private bool UseCard()
        {
            if (new SwipeCard().ShowDialog() == DialogResult.Yes) return true;
            else return false;
        }

        private void GeneratePlay()
        {
            if (player != null)
            {
                btnGeneratePlay.Enabled = false;
                DialogResult response = MessageBox.Show("Are you sure you want to end your message early?\n\nPress ABORT to abruptly stop the message.\nPress RETRY to stop the message with EOM.\nPress IGNORE to go back.", "EASEncoder Fusion", MessageBoxButtons.AbortRetryIgnore);
                if (response == DialogResult.Abort)
                {
                    try
                    {
                        player.Stop();
                        player = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (this.WindowState != FormWindowState.Normal && this.WindowState != FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.BringToFront();
                    }
                    EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                    btnGeneratePlay.Enabled = true;
                    UpTown.Stop();
                    DownTown.Start();
                    if (comboOriginator.SelectedItem != null)
                    if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
                    {
                        txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
                        txtSender.ReadOnly = true;
                        btnRandomID.Enabled = false;
                        Randomization.Start();
                    }
                    else
                    {
                        txtSender.ReadOnly = false;
                        btnRandomID.Enabled = true;
                        Randomization.Stop();
                    }
                    if (chkBurstHeaders.Checked)
                    {
                        dateStart.Enabled = false;
                        comboCode.Enabled = false;
                        comboOriginator.Enabled = false;
                        comboLengthHour.Enabled = false;
                        comboLengthMinutes.Enabled = false;
                        comboState.Enabled = false;
                        comboCounty.Enabled = false;
                        btnAddRegion.Enabled = false;
                        btnRemoveAllRegions.Enabled = false;
                        datagridRegions.Enabled = false;
                        chkEbsTones.Enabled = false;
                        chkNwsTone.Enabled = false;
                        chkCensorTone.Enabled = false;
                        chkGenerateAnnouncement.Enabled = false;
                        txtAnnouncement.Enabled = false;
                        txtOutputFile.Enabled = false;
                    }
                    return;
                }
                else if (response == DialogResult.Retry)
                {
                    try
                    {
                        player.Stop();
                        player = null;
                        new SoundPlayer(Resources.EOM).PlaySync();
                    }
                    catch (Exception)
                    {

                    }
                    if (this.WindowState != FormWindowState.Normal && this.WindowState != FormWindowState.Maximized)
                    {
                        this.WindowState = FormWindowState.Normal;
                        this.BringToFront();
                    }
                    EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                    btnGeneratePlay.Enabled = true;
                    UpTown.Stop();
                    DownTown.Start();
                    if (comboOriginator.SelectedItem != null)
                    if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
                    {
                        txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
                        txtSender.ReadOnly = true;
                        btnRandomID.Enabled = false;
                        Randomization.Start();
                    }
                    else
                    {
                        txtSender.ReadOnly = false;
                        btnRandomID.Enabled = true;
                        Randomization.Stop();
                    }
                    if (chkBurstHeaders.Checked)
                    {
                        dateStart.Enabled = false;
                        comboCode.Enabled = false;
                        comboOriginator.Enabled = false;
                        comboLengthHour.Enabled = false;
                        comboLengthMinutes.Enabled = false;
                        comboState.Enabled = false;
                        comboCounty.Enabled = false;
                        btnAddRegion.Enabled = false;
                        btnRemoveAllRegions.Enabled = false;
                        datagridRegions.Enabled = false;
                        chkEbsTones.Enabled = false;
                        chkNwsTone.Enabled = false;
                        chkCensorTone.Enabled = false;
                        chkGenerateAnnouncement.Enabled = false;
                        txtAnnouncement.Enabled = false;
                        txtOutputFile.Enabled = false;
                    }
                    return;
                }
                else if (response == DialogResult.Ignore)
                {
                    btnGeneratePlay.Enabled = true;
                    return;
                }
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                btnGeneratePlay.Enabled = true;
                return;
            }

            if (!chkBurstHeaders.Checked)
            {
                if (!ValidateInput(true))
                {
                    return;
                }
            }

            //if (!UseBarcode()) return;

            _start = dateStart.Value.ToUniversalTime();

            _senderId = txtSender.Text;

            _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);
            
            EASMessage newMessage = new EASMessage("CIV", "EQW", new List<SAMERegion>(), "0005", DateTime.Now.ToUniversalTime(), _senderId);

            if (!chkBurstHeaders.Checked) newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
                Regions, _length, _start, _senderId);

            MemoryStream messageStream = null;

            //using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("EAS_FUSION", PipeDirection.Out))
            //{
            //    // Wait 5 seconds before timing out
            //    pipeServer.WriteTimeout = 5000;
            //    pipeServer.ReadTimeout = 5000;
            //    pipeServer.WaitForConnection();

            //    if (pipeServer.IsConnected)
            //    {
            //        using (StreamWriter writer = new StreamWriter(pipeServer))
            //        {
            //            string textboxData = "Data from the textbox";
            //            writer.WriteLine(textboxData);
            //            writer.Flush();
            //            writer.WriteLine("\xab");
            //        }
            //        pipeServer.Close();
            //    }
            //    pipeServer.Dispose();
            //}

            StringBuilder extractedText = new StringBuilder();
            foreach (DataGridViewRow row in datagridRegions.Rows)
            {
                bool isNotEnd = true;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        extractedText.Append(cell.Value.ToString());
                        if (isNotEnd)
                        {
                            extractedText.Append(", ");
                            isNotEnd = false;
                        }
                    }
                }
                extractedText.AppendLine();
            }

            string locationText = extractedText.ToString().TrimEnd();

            DateTime ClockEnd = _start;
            ClockEnd = ClockEnd.AddHours(comboLengthHour.SelectedIndex);
            ClockEnd = ClockEnd.AddMinutes(comboLengthMinutes.SelectedIndex);
            
            // Implement functionality for pre-audio and post-audio here

            Randomization.Stop();

            if (chkBurstHeaders.Checked)
            {
                if (MessageBox.Show("Send the following SASMEX message?\n\n" +
                "Originator: " + "Civil Authority" + "\n" +
                "Event Type: " + "Earthquake Warning" + "\n" +
                "Starting At: " + _start.ToString("u").Substring(0, _start.ToString("u").Length - 1) + " UTC\n" +
                "Ending At: " + ClockEnd.ToString("u").Substring(0, ClockEnd.ToString("u").Length - 1) + " UTC\n",
                "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
                    {
                        Randomization.Start();
                    }
                    else
                    {
                        Randomization.Stop();
                    }
                    return;
                }
                MessageWait.ShowWait();
                messageStream = EASEncoderFusion.EASEncoder.GetMemoryStreamFromSASMEX(_senderId);
                MessageWait.HideWait();
            }
            else
            {
                if (MessageBox.Show("Send the following message?\n\n" +
                "Originator: " + comboOriginator.Text + "\n" +
                "Event Type: " + comboCode.Text + "\n" +
                "EBS Tone: " + chkEbsTones.Checked.ToString() + "\n" +
                "NWS Tone: " + chkNwsTone.Checked.ToString() + "\n" +
                "BEEP Tone: " + chkCensorTone.Checked.ToString() + "\n" +
                "Announcement Generated: " + chkGenerateAnnouncement.Checked.ToString() + "\n" +
                "Starting At: " + _start.ToString("u").Substring(0, _start.ToString("u").Length - 1) + " UTC\n" +
                "Ending At: " + ClockEnd.ToString("u").Substring(0, ClockEnd.ToString("u").Length - 1) + " UTC\n" +
                "Locations:\n" + locationText, "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
                    {
                        Randomization.Start();
                    }
                    else
                    {
                        Randomization.Stop();
                    }
                    return;
                }
                MessageWait.ShowWait();
                if (chkGenerateAnnouncement.Checked) messageStream = EASEncoderFusion.EASEncoder.GetMemoryStreamFromNewMessage(newMessage, chkEbsTones.Checked,
                chkNwsTone.Checked, chkCensorTone.Checked, FormatAnnouncement(GetAnnouncementFromDetails()), chkBurstHeaders.Checked);
                else messageStream = EASEncoderFusion.EASEncoder.GetMemoryStreamFromNewMessage(newMessage, chkEbsTones.Checked,
                chkNwsTone.Checked, chkCensorTone.Checked, FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked);
                MessageWait.HideWait();
            }

            if (messageStream == null)
            {
                MessageBox.Show("An error occurred while attempting to create the EAS message. Please try again later.");
                return;
            }
            
            if (comboOriginator.SelectedItem != null)
            if (comboOriginator.SelectedItem.ToString() == "Mock Alert")
            {
                Randomization.Start();
            }
            else
            {
                Randomization.Stop();
            }

            WaveStream mainOutputStream = new RawSourceWaveStream(messageStream, new WaveFormat());
            var volumeStream = new WaveChannel32(mainOutputStream)
            {
                PadWithZeroes = false
            };

            if (mainOutputStream.TotalTime.TotalSeconds > 120)
            {
                if (MessageBox.Show($"The message you are attempting to send is longer than the maximum of 2 minutes ({(int)mainOutputStream.TotalTime.TotalSeconds} currently). Most decoders will abruptly cut off the message beyond the allocated time, and send the end of message tones." +
                    "\n\nDo you want to continue anyway?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                {
                    volumeStream.Dispose();
                    mainOutputStream.Dispose();
                    return;
                }
            }

            //btnGeneratePlay.BackColor = Color.Red;
            DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
            btnGeneratePlay.Text = "STOP";

            player = new WaveOutEvent();
            player.PlaybackStopped += (o, args) =>
            {
                if (this.WindowState != FormWindowState.Normal && this.WindowState != FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal;
                    this.BringToFront();
                }
                this.SuspendLayout();
                try { player = null; player?.Dispose(); } catch (Exception) { }
                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                btnGeneratePlay.Text = "PLAY";
                UpTown.Stop();
                DownTown.Start();
                if (chkBurstHeaders.Checked)
                {
                    dateStart.Enabled = false;
                    comboCode.Enabled = false;
                    comboOriginator.Enabled = false;
                    comboLengthHour.Enabled = false;
                    comboLengthMinutes.Enabled = false;
                    comboState.Enabled = false;
                    comboCounty.Enabled = false;
                    btnAddRegion.Enabled = false;
                    btnRemoveAllRegions.Enabled = false;
                    datagridRegions.Enabled = false;
                    chkEbsTones.Enabled = false;
                    chkNwsTone.Enabled = false;
                    chkCensorTone.Enabled = false;
                    chkGenerateAnnouncement.Enabled = false;
                    txtAnnouncement.Enabled = false;
                    txtOutputFile.Enabled = false;
                }
                this.ResumeLayout();
                if (Settings.Default.QuitOnFinish) this.Close();
            };

            player.Init(volumeStream);

            UpTown.Start();
            DownTown.Stop();

            if (Settings.Default.UseCountdown)
            {
                btnGeneratePlay.Enabled = false;
                PlayCountdown.Start();
                return;
            }

            //new DisplayForm().Show();
            player.Play();
        }

        private string GetAnnouncementFromDetails()
        {
            string combination = "";

            switch (comboOriginator.Text)
            {
                case "Civil Authority":
                    combination += " " + "Civil Authority";
                    break;
                case "Emergency Alert System Participant":
                    combination += " " + "An Emergency Alert System Participant";
                    break;
                case "Mock Alert":
                    combination += " " + "Civil Authority";
                    break;
                case "National Weather Service":
                    RegionInfo country = new RegionInfo(CultureInfo.CurrentCulture.LCID);
                    if (country.DisplayName == "Canada") combination += " " + "Environment Canada";
                    else combination += " " + "The National Weather Service";
                    break;
                case "Primary Entry Point System":
                    combination += " " + "A Primary Entry Point System";
                    break;
                default:
                    combination += " " + "An Unrecognized Originator";
                    break;
            }

            combination += " " + "has issued a";

            combination += " " + comboCode.Text + " " + "for";

            bool isCounty = true;
            bool Skip = false;
            
            foreach (DataGridViewRow row in datagridRegions.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        string cellText = cell.Value.ToString();
                        if (cellText.Contains("All of "))
                        {
                            Skip = true;
                            combination += " " + cellText + ",";
                            break;
                        }
                        if (Skip)
                        {
                            Skip = false;
                            break;
                        }
                        combination += " " + cellText + ",";
                        isCounty = !isCounty;
                    }
                }
            }

            combination += " " + "valid for ";
            if (comboLengthHour.SelectedIndex == 1) combination += comboLengthHour.SelectedIndex.ToString() + " hour and ";
            else combination += comboLengthHour.SelectedIndex.ToString() + " hours and ";

            if (comboLengthMinutes.SelectedIndex == 1) combination += comboLengthMinutes.SelectedIndex.ToString() + " minute. ";
            else combination += comboLengthMinutes.SelectedIndex.ToString() + " minutes. ";

            return combination;
        }

        internal string ZeroPad(string String, int Length)
        {
            if (string.IsNullOrEmpty(String))
            {
                String = "0";
            }
            if (String.Length > Length)
            {
                return String;
            }

            while (String.Length < Length)
            {
                String = "0" + String;
            }

            return String;
        }

        private string FormatAnnouncement(string announcement)
        {
            return
                announcement.Replace("*", "")
                    .Replace("\r\n", " ")
                    .ToLower()
                    .Replace(" cdt", "central daylight time")
                    .Replace(" cst", "central standard time")
                    .Replace(" edt", "eastern daylight time")
                    .Replace(" est", "eastern standard time")
                    .Replace(" mdt", "mountain daylight time")
                    .Replace(" mst", "moutain standard time")
                    .Replace(" pdt", "pacific daylight time")
                    .Replace(" pst", "pacific standard time")
                    .Replace(" mph", "miles per hour")
                    .Replace(" winds", "whinds")
                    .Replace("  ", " ")
                    .Replace("...", ", ")
                    .Replace("precautionary/preparedness actions", "")
                    .Replace("911", "nine one one")
                    .Replace("9-1-1", "nine one one")
                    .ToLower();

        }

        private bool ValidateInput(bool ShowDialog)
        {
            if (string.IsNullOrEmpty(txtSender.Text) || txtSender.TextLength != 8)
            {
                if (ShowDialog) MessageBox.Show("You must enter a 'Sender' id.  Ensure it is 8 characters in length.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(comboOriginator.Text))
            {
                if (ShowDialog) MessageBox.Show("You must select an 'Originator' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(comboCode.Text))
            {
                if (ShowDialog) MessageBox.Show("You must select a 'Code' (event) from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(comboLengthHour.Text))
            {
                if (ShowDialog) MessageBox.Show("You must select a 'Length Hour' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (string.IsNullOrEmpty(comboLengthMinutes.Text))
            {
                if (ShowDialog) MessageBox.Show("You must select a 'Length Minute' from the drop down menu.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Regions.Count < 1)
            {
                if (ShowDialog) MessageBox.Show("You must select and add at least 1 location (state/county).", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        int AmountOfLocations = 0;

        private void BtnAddRegion_Click(object sender, EventArgs e)
        {
            if (comboState.SelectedIndex >= 0 && comboCounty.SelectedIndex >= 0 && !Regions.Exists(x => x.County.Id == _selectedCounty.Id && x.State.Id == _selectedState.Id))
            {
                if (AmountOfLocations >= 25)
                {
                    MessageBox.Show("You have reached the maximum location limit. Remove some locations and try again to add more.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                } else AmountOfLocations++;

                Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
                var bindingList = new BindingList<SAMERegion>(Regions);
                var source = new BindingSource(bindingList, null);
                datagridRegions.DataSource = source;

                comboCounty.SelectedIndex = -1;
                _selectedCounty = null;
            }

            //if (comboState.SelectedIndex >= 0 && comboCounty.SelectedIndex >= 0)
            //{
            //    for (int i = 0; i < 5000; i++)
            //    {
            //        Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
            //        var bindingList = new BindingList<SAMERegion>(Regions);
            //        var source = new BindingSource(bindingList, null);
            //        datagridRegions.DataSource = source;
            //        Application.DoEvents();
            //    }
            //}
        }

        private void TxtAnnouncement_TextChanged(object sender, EventArgs e)
        {
            //parse vtec
            // (\/)(O)(.)(NEW|CON|EXT|EXA|EXB|UPG|CAN|EXP|COR|ROU)(.)([\w]{4})(.)([A-Z][A-Z])(.)([WAYSFON])(.)([0-9]{4})(.)([0-9]{6})(T)([0-9]{4})(Z)([-])([0-9]{6})([T])([0-9]{4})([Z])(\/)?
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            AboutForm aboutDialog = new AboutForm();
            this.Hide();
            aboutDialog.ShowDialog();
            this.Show();
            //int frequency1 = 540; // Frequency of the first tone in Hz
            //int frequency2 = 420; // Frequency of the second tone in Hz

            //WaveOutEvent waveOut = new WaveOutEvent();
            //SignalGenerator toneGenerator = new SignalGenerator();

            //toneGenerator.Frequency = frequency1;
            //toneGenerator.Type = SignalGeneratorType.Sin;

            //waveOut.Init(toneGenerator);
            //waveOut.Play();

            //while (true)
            //{
            //    Thread.Sleep(1);
            //    toneGenerator.Frequency = (toneGenerator.Frequency == frequency1) ? frequency2 : frequency1;
            //}
        }

        private void BtnTTSSettings_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Some SAPI voices are currently incompatible.", "EASEncoder Fusion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //int b = 0;
            //_ = 1 / b;
            Process.Start("C:\\WINDOWS\\SYSWOW64\\SPEECH\\SPEECHUX\\SAPI.CPL");
            //var synthesizer = new SpeechSynthesizer();

            //// Get the installed voices
            //var installedVoices = synthesizer.GetInstalledVoices();

            //// Iterate over the installed voices and print their names
            //foreach (var installedVoice in installedVoices)
            //{
            //    var voiceInfo = installedVoice.VoiceInfo;
            //    MessageBox.Show(voiceInfo.Name);
            //}
        }

        private void TxtGeneratedData_TextChanged(object sender, EventArgs e)
        {

        }

        //private void btnGenerateTTSOnly_Click(object sender, EventArgs e)
        //{
        //    DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
        //    btnGeneratePlay.Enabled = false;
        //    try
        //    {
        //        var synthesizer = new SpeechSynthesizer
        //        {
        //            Volume = 100
        //        };

        //        var audioStream = new MemoryStream();
        //        synthesizer.SetOutputToWaveStream(audioStream);

        //        synthesizer.Speak(txtAnnouncement.Text);

        //        synthesizer.SetOutputToDefaultAudioDevice();

        //        audioStream.Position = 0;
        //        using (var audioPlayer = new SoundPlayer(audioStream))
        //        {
        //            audioPlayer.PlaySync();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    finally
        //    {
        //        EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
        //        btnGeneratePlay.Enabled = true;
        //    }
        //}

        private void chkBurstHeaders_CheckedChanged(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (chkBurstHeaders.Checked)
            {
                dateStart.Enabled = false;
                comboCode.Enabled = false;
                comboOriginator.Enabled = false;
                comboLengthHour.Enabled = false;
                comboLengthMinutes.Enabled = false;
                comboState.Enabled = false;
                comboCounty.Enabled = false;
                btnAddRegion.Enabled = false;
                btnRemoveAllRegions.Enabled = false;
                datagridRegions.Enabled = false;
                chkEbsTones.Enabled = false;
                chkNwsTone.Enabled = false;
                chkCensorTone.Enabled = false;
                chkGenerateAnnouncement.Enabled = false;
                txtAnnouncement.Enabled = false;
                txtOutputFile.Enabled = false;
            }
            else
            {
                dateStart.Enabled = true;
                comboCode.Enabled = true;
                comboOriginator.Enabled = true;
                comboLengthHour.Enabled = true;
                comboLengthMinutes.Enabled = true;
                comboState.Enabled = true;
                comboCounty.Enabled = true;
                btnAddRegion.Enabled = true;
                btnRemoveAllRegions.Enabled = true;
                datagridRegions.Enabled = true;
                chkEbsTones.Enabled = true;
                chkNwsTone.Enabled = true;
                chkCensorTone.Enabled = true;
                chkGenerateAnnouncement.Enabled = true;
                txtAnnouncement.Enabled = true;
                txtOutputFile.Enabled = true;
            }
            this.ResumeLayout();
        }

        int i = 15;

        private void PlayCountdown_Tick(object sender, EventArgs e)
        {
            if (PlayCountdown.Interval < 1000) PlayCountdown.Interval = 1000;
            btnGeneratePlay.Text = i.ToString();
            if (i != 0) i--;
            else
            {
                PlayCountdown.Stop();
                i = 15;
                btnGeneratePlay.Enabled = true;
                btnGeneratePlay.Text = "STOP";
                //new DisplayForm().Show();
                player.Play();
            }
        }

        private void txtSender_TextChanged(object sender, EventArgs e)
        {
            txtSender.Text.Trim();
        }

        int GridIndexRow = -1;
        //int GridIndexColumn = -1;

        private void datagridRegions_CellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (e.Button == MouseButtons.Right)
                {
                    GridIndexRow = e.RowIndex;
                    //GridIndexColumn = e.ColumnIndex;
                    LocationContextMenu.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void deleteLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            try { datagridRegions.Rows.RemoveAt(GridIndexRow); AmountOfLocations--; } catch (Exception) { }
            this.ResumeLayout();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Do you want to forcefully redraw all elements?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this.Invalidate();
            //    this.Validate();
            //}

            

        }

        private void btnCopyHeader_Click(object sender, EventArgs e)
        {
            txtGeneratedData.SelectAll();
            txtGeneratedData.Copy();
            string temp = txtGeneratedData.Text;
            txtGeneratedData.Clear();
            txtGeneratedData.Text = temp;
        }

        //private readonly Random rnd = new Random(DateTime.Now.Millisecond);

        //private void checkBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkStressTest.Checked)
        //    {
        //        if (MessageBox.Show("This will start testing now. It may take a few minutes to fully complete due to the hardcore nature of this test. Your computer may become unresponsive for a few minutes while processing the headers.\n\nDo you want to continue?", "EASEncoder Fusion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //        {
        //            DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
        //            comboOriginator.SelectedIndex = rnd.Next(1, 3);
        //            txtSender.Text = "TESTDEMO";
        //            comboCode.SelectedIndex = rnd.Next(1, 20);
        //            comboLengthHour.SelectedIndex = rnd.Next(1, 99);
        //            comboLengthMinutes.SelectedIndex = rnd.Next(1, 60);
        //            for (int i = 0; i < 1000; i++)
        //            {
        //                try
        //                {
        //                    comboState.SelectedIndex = rnd.Next(1, 40);
        //                    comboCounty.SelectedIndex = rnd.Next(1, 5);
        //                    Regions.Add(new SAMERegion(_selectedState, _selectedCounty));
        //                }
        //                catch (Exception) { }
        //            }

        //            try
        //            {
        //                datagridRegions.DataSource = new BindingSource(new BindingList<SAMERegion>(Regions), null);
        //            }
        //            catch (Exception) { }

        //            if (rnd.Next(1, 2) == 1) chkEbsTones.Checked = true;
        //            else chkEbsTones.Checked = false;

        //            if (rnd.Next(1, 2) == 1) chkNwsTone.Checked = true;
        //            else chkNwsTone.Checked = false;

        //            chkBurstHeaders.Checked = false;

        //            txtAnnouncement.Text = "Rainbow meadow dances, tranquil breeze painting whimsical symphony. Serendipitous whispers caress ethereal whispers, blooming moonbeams caressing starlit whispers. Enchanted twilight waltzes, mystic lullabies enchant celestial fireflies. Velvet petals float, embracing whispers of serenity, twilight's embrace cascading gently. Ethereal echoes shimmer, whispering dreamsong amidst enchanted meadows. Luminous whispers guide ethereal wanderers, weaving ephemeral tapestries of infinite wonder. Spiraling stardust illuminates nocturnal whispers, entwining galaxies with ethereal lullabies. Midnight symphony dances, cosmic whispers enthralling the universe. Celestial rivers flow, whispering secrets in celestial languages. Enigmatic whispers echo through enchanted realms, beckoning ethereal voyagers.";

        //            _start = dateStart.Value.ToUniversalTime();
        //            _senderId = txtSender.Text;
        //            _length = ZeroPad(comboLengthHour.Text, 2) + ZeroPad(comboLengthMinutes.Text, 2);

        //            var newMessage = new EASMessage(_selectedOriginator.Id, _selectedAlertCode.Id,
        //                Regions, _length, _start, _senderId);


        //            var messageStream = EASEncoderFusion.EASEncoderFusion.GetMemoryStreamFromNewMessage(newMessage, chkEbsTones.Checked,
        //                chkNwsTone.Checked, FormatAnnouncement(txtAnnouncement.Text), chkBurstHeaders.Checked);

        //            DisableElementsWithTag.DisableControlsWithTag(this.Controls, "disable");
        //            btnGeneratePlay.Text = "STOP";

        //            WaveStream mainOutputStream = new RawSourceWaveStream(messageStream, new WaveFormat());
        //            var volumeStream = new WaveChannel32(mainOutputStream)
        //            {
        //                PadWithZeroes = false
        //            };

        //            player = new WaveOutEvent();
        //            player.PlaybackStopped += (o, args) =>
        //            {
        //                this.SuspendLayout();
        //                try { player = null; player?.Dispose(); } catch (Exception) { }
        //                EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
        //                this.ResumeLayout();
        //                btnGeneratePlay.Text = "PLAY";
        //                this.Hide();
        //                MessageBox.Show("Processed 500 areas.");
        //                this.Close();
        //                //chkStressTest.Checked = false;
        //            };

        //            player.Init(volumeStream);

        //            player.Play();
        //        }
        //        //else //chkStressTest.Checked = false;
        //    }
        //    else
        //    {
        //        EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
        //    }
        //}

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            
        }

        private void txtAnnouncement_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void EditContextMenu_Opening(object sender, CancelEventArgs e)
        {
            toolCut.Enabled = false;
            toolCopy.Enabled = false;
            toolDelete.Enabled = false;
            toolPaste.Enabled = false;
            toolUndoRedo.Enabled = false;

            if (txtAnnouncement.SelectedText != "")
            {
                toolCut.Enabled = true;
                toolCopy.Enabled = true;
                toolDelete.Enabled = true;
            }
            if (Clipboard.ContainsText())
            {
                toolPaste.Enabled = true;
            }
            if (txtAnnouncement.CanUndo)
            {
                toolUndoRedo.Enabled = true;
            }
        }

        private void toolUndoRedo_Click(object sender, EventArgs e)
        {
            if (txtAnnouncement.CanUndo) txtAnnouncement.Undo();
        }

        private void toolCut_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                Clipboard.SetText(txtAnnouncement.SelectedText);
                txtAnnouncement.Text = txtAnnouncement.Text.Remove(txtAnnouncement.SelectionStart, txtAnnouncement.SelectionLength);
            }
        }


        private void toolCopy_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                Clipboard.SetText(txtAnnouncement.SelectedText);
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtAnnouncement.SelectedText))
            {
                txtAnnouncement.Text = txtAnnouncement.Text.Remove(txtAnnouncement.SelectionStart, txtAnnouncement.SelectionLength);
            }
        }

        private void toolPaste_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                string clipboardText = Clipboard.GetText();
                int caretPosition = txtAnnouncement.SelectionStart;
                txtAnnouncement.Text = txtAnnouncement.Text.Insert(caretPosition, clipboardText);
                txtAnnouncement.SelectionStart = caretPosition + clipboardText.Length;
            }
        }

        private void lblOutputDirectory_Click(object sender, EventArgs e)
        {
            ProcessStartInfo stInfo = new ProcessStartInfo
            {
                UseShellExecute = true,
                FileName = lblOutputDirectory.Text
            };
            Process.Start(stInfo);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (player != null)
            {
                btnGeneratePlay.Enabled = false;
                DialogResult response = MessageBox.Show("Are you sure you want to end your message early?\n\nPress ABORT to abruptly stop the message.\nPress RETRY to stop the message with EOM.\nPress IGNORE to go back.", "EASEncoder Fusion", MessageBoxButtons.AbortRetryIgnore);
                if (response == DialogResult.Abort)
                {
                    try
                    {
                        player.Stop();
                        player = null;
                        EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                        btnGeneratePlay.Enabled = true;
                    }
                    catch (Exception)
                    {

                    }
                    e.Cancel = false;
                    return;
                }
                else if (response == DialogResult.Retry)
                {
                    try
                    {
                        player.Stop();
                        player = null;
                        new SoundPlayer(Resources.EOM).PlaySync();
                        EnableElementsWithTag.EnableControlsWithTag(this.Controls, "disable");
                        btnGeneratePlay.Enabled = true;
                    }
                    catch (Exception)
                    {

                    }
                    e.Cancel = false;
                    return;
                }
                else if (response == DialogResult.Ignore)
                {
                    btnGeneratePlay.Enabled = true;
                    e.Cancel = true;
                    return;
                }
                btnGeneratePlay.Enabled = true;
                e.Cancel = true;
                return;
            }
        }

        private void btnRemoveAllRegions_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in datagridRegions.Rows)
            //{
            //    datagridRegions.Rows.RemoveAt(row.Index);
            //}

            while (datagridRegions.Rows.Count > 0)
            {
                datagridRegions.Rows.RemoveAt(0);
            }

            AmountOfLocations = 0;
        }

        private void LocationContextMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        string previous = "";

        private void chkGenerateAnnouncement_CheckedChanged(object sender, EventArgs e)
        {
            if (chkGenerateAnnouncement.Checked)
            {
                previous = txtAnnouncement.Text;
                txtAnnouncement.Text = "Once you click PLAY, or SAVE, an announcement will automatically be generated based on the configuration.";
                txtAnnouncement.ReadOnly = true;
            }
            else
            {
                txtAnnouncement.Text = "";
                txtAnnouncement.Text = previous;
                txtAnnouncement.ReadOnly = false;
            }
        }

        private void DownTown_Tick(object sender, EventArgs e)
        {
            btnGeneratePlay.Text = "PLAY";
            i = 15;
            PlayCountdown.Stop();

            if (chkBurstHeaders.Checked && txtSender.Text.Length == 8)
            {
                btnGeneratePlay.BackColor = Color.LimeGreen;
                btnGeneratePlay.ForeColor = Color.White;
                btnGeneratePlay.FlatAppearance.BorderColor = Color.Green;
                btnGeneratePlay.FlatAppearance.BorderSize = 4;
                btnGeneratePlay.Enabled = true;
                btnGenerate.BackColor = Color.FromArgb(255, 255, 255);
                btnGenerate.ForeColor = Color.Black;
                btnGenerate.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                btnGenerate.FlatAppearance.BorderSize = 4;
                btnGenerate.Enabled = false;
                return;
            }
            if (!ValidateInput(false))
            {
                btnGeneratePlay.BackColor = Color.FromArgb(255, 255, 255);
                btnGeneratePlay.ForeColor = Color.Black;
                btnGeneratePlay.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                btnGeneratePlay.FlatAppearance.BorderSize = 4;
                btnGeneratePlay.Enabled = false;
                btnGenerate.BackColor = Color.FromArgb(255, 255, 255);
                btnGenerate.ForeColor = Color.Black;
                btnGenerate.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
                btnGenerate.FlatAppearance.BorderSize = 4;
                btnGenerate.Enabled = false;
                return;
            }
            btnGeneratePlay.BackColor = Color.LimeGreen;
            btnGeneratePlay.ForeColor = Color.White;
            btnGeneratePlay.FlatAppearance.BorderColor = Color.Green;
            btnGeneratePlay.FlatAppearance.BorderSize = 4;
            btnGeneratePlay.Enabled = true;
            btnGenerate.BackColor = Color.Orange;
            btnGenerate.ForeColor = Color.White;
            btnGenerate.FlatAppearance.BorderColor = Color.FromArgb(215, 120, 0);
            btnGenerate.FlatAppearance.BorderSize = 4;
            btnGenerate.Enabled = true;
        }

        private void UpTown_Tick(object sender, EventArgs e)
        {
            btnGeneratePlay.BackColor = (btnGeneratePlay.BackColor == Color.Red) ? Color.White : Color.Red;
            btnGeneratePlay.ForeColor = (btnGeneratePlay.BackColor == Color.White) ? Color.Red : Color.White;
            btnGeneratePlay.FlatAppearance.BorderColor = Color.OrangeRed;
            btnGeneratePlay.FlatAppearance.BorderSize = 4;
            btnGeneratePlay.Enabled = true;
            if (!chkBurstHeaders.Checked)
            {
                btnGenerate.BackColor = (btnGenerate.BackColor == Color.FromArgb(55, 55, 55)) ? Color.LightGray : Color.FromArgb(55, 55, 55);
                btnGenerate.ForeColor = (btnGenerate.BackColor == Color.LightGray) ? Color.FromArgb(55, 55, 55) : Color.LightGray;
                btnGenerate.FlatAppearance.BorderColor = Color.DarkSlateGray;
                btnGenerate.FlatAppearance.BorderSize = 4;
                btnGenerate.Enabled = false;
            }
        }

        private void lblFileName_Click(object sender, EventArgs e)
        {

        }

        private void txtOutputFile_TextChanged(object sender, EventArgs e)
        {

        }

        int RandomizerClickAmount = 0;

        private void btnRandomID_Click(object sender, EventArgs e)
        {
            if (RandomizerClickAmount != 69) txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
            if (RandomizerClickAmount == 69) txtSender.Text = "6IX-9INE";
            if (RandomizerClickAmount == 420) txtSender.Text = "4OUR-20!";
            if (RandomizerClickAmount <= 420) RandomizerClickAmount++;
        }

        private void Randomization_Tick(object sender, EventArgs e)
        {
            txtSender.Text = new string(Enumerable.Range(65, 26).OrderBy(_ => Guid.NewGuid()).Take(8).Select(x => (char)x).ToArray());
        }
    }

    public static class DisableElementsWithTag
    {
        public static void DisableControlsWithTag(Control.ControlCollection controls, string tag)
        {
            foreach (Control control in controls)
            {
                if (control.Tag != null && control.Tag.ToString() == tag)
                {
                    control.Enabled = false;
                }

                if (control.HasChildren)
                {
                    DisableControlsWithTag(control.Controls, tag);
                }
            }
        }
    }

    public static class EnableElementsWithTag
    {
        public static void EnableControlsWithTag(Control.ControlCollection controls, string tag)
        {
            foreach (Control control in controls)
            {
                if (control.Tag != null && control.Tag.ToString() == tag)
                {
                    control.Enabled = true;
                }

                if (control.HasChildren)
                {
                    EnableControlsWithTag(control.Controls, tag);
                }
            }
        }
    }
}