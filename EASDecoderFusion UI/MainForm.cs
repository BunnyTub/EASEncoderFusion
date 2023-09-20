using System;
using System.Windows.Forms;

namespace EASDecoderFusion_UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.SuspendLayout();
            this.Select();
            btnPlayAudio.Select();
            txtAnnouncement.ReadOnly = true;
            txtAnnouncement.Text = "EASDECODER\r\nVERSION 1";
            this.ResumeLayout();
        }

        private void btnPlayAudio_Click(object sender, EventArgs e)
        {

        }

        private bool Testing = false;

        private void btnPlayTest_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            if (Testing)
            {
                Testing = false;
                return;
            }
            else
            {

            }
            txtAnnouncement.Text = "*** TESTING ***\r\nPRESS TEST TO STOP";
            this.ResumeLayout();
        }

        private bool DoNotShowClock = false;

        private void TimeAndDate_Tick(object sender, EventArgs e)
        {
            if (!DoNotShowClock)
            {
                txtAnnouncement.Text = DateTime.Now.ToString("t") + " " + DateTime.Now.ToString("d");
            }
        }

        public string Originator = "Unknown Originator";
        public string EventCode = "Unrecognized Event";
        public string EventLocation = "Unknown Location";
        public string TimeCode = "Unknown Time Code";
        public string JulianDate = "Unknown Date";
        public string Time = "Unknown Time";
        public string End = "Unknown";

        private void Decode(string input)
        {
            // <Preamble>ZCZC-ORG-EEE-PSSCCC+TTTT-JJJHHMM-LLLLLLLL-
            //Console.WriteLine("/xab");
            input.Trim();
            string sameMessage = "ZCZC-ORG-EEE-PSSCCC+TTTT-JJJHHMM-LLLLLLLL-"; // Replace with your SAME message

            // Remove the start and end identifiers
            string messageWithoutIdentifiers = sameMessage.TrimStart('Z').TrimEnd('-');

            // Split the message into its components
            string[] messageComponents = messageWithoutIdentifiers.Split('-');

            if (messageComponents.Length >= 6)
            {
                string organization = messageComponents[0];
                string eventCode = messageComponents[1];
                string locationCode = messageComponents[2];
                string timeCode = messageComponents[3];
                string julianDate = messageComponents[4].Substring(0, 3);
                string time = messageComponents[4].Substring(3);
                string endIdentifier = messageComponents[5];

                // Print the decoded information
                Console.WriteLine("Organization: " + organization);
                Console.WriteLine("Event Code: " + eventCode);
                Console.WriteLine("Location Code: " + locationCode);
                Console.WriteLine("Time Code: " + timeCode);
                Console.WriteLine("Julian Date: " + julianDate);
                Console.WriteLine("Time: " + time);
                Console.WriteLine("End Identifier: " + endIdentifier);

                switch (organization)
                {
                    case "PEP":
                        Console.WriteLine("Primary Entry Point System");
                        break;
                    case "CIV":
                        Console.WriteLine("Civil Authorites");
                        break;
                    case "WXR":
                        Console.WriteLine("NWS / Environment Canada");
                        break;
                    case "EAS":
                        Console.WriteLine("EAS Participant");
                        break;
                    case "EAN":
                        Console.WriteLine("Emergency Action Notification\r\n(Deprecated)");
                        break;
                    default:
                        Console.WriteLine("Unidentified Originator");
                        break;
                }

            }
            else
            {
                Console.WriteLine("SAME message invalid. Processing as unknown.");
            }
            //return input;
        }
    }
}