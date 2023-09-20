using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EASEncoder_UI
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        //private readonly string textToScroll = "This is a sample scrolling text.";
        //private int scrollOffset;

        private string text = "This is just some placeholder text I'm using for now until I can get this working properly. This application is made in C# WinForms, and was originally on on GitHub. Let me know what you think!";
        private List<string> splitStrings;
        private int totalStrings = 0;
        private int currentString = 0;

        private void ScrollingText1_Tick(object sender, EventArgs e)
        {
            TitleLabel.Text = splitStrings[currentString];
            if (currentString == totalStrings - 1)
            {
                currentString = 0;
                return;
            }
            else
            {
                currentString++;
            }
        }

        private void DisplayForm_Load(object sender, EventArgs e)
        {
            this.Invalidate();
            this.WindowState = FormWindowState.Normal;
            //while (MoveFormToMonitor("USB Mobile Monitor Virtual Display"))
            //{
            //    new DisplayHelp1().ShowDialog();
            //}
            foreach (Screen display in Screen.AllScreens)
            {
                if (!display.Primary)
                {
                    this.Location = new Point(display.WorkingArea.X, display.WorkingArea.Y);
                    this.WindowState = FormWindowState.Maximized;
                    if (text.Length > 32)
                    {
                        splitStrings = SplitString(text);
                        foreach (string splitString in splitStrings)
                        {
                            totalStrings++;
                        }
                        ScrollingText1.Start();
                        return;
                    }
                    else TitleLabel.Text = text;
                    return;
                }
            }
            //if (Screen.AllScreens.Length > 1)
            //    this.Location = Screen.AllScreens[1].WorkingArea.Location;
        }

        public static List<string> SplitString(string input)
        {
            const int maxLength = 32;
            var result = new List<string>();
            var currentIndex = 0;

            while (currentIndex < input.Length)
            {
                int substringLength = Math.Min(maxLength, input.Length - currentIndex);

                if (substringLength == maxLength)
                {
                    int spaceIndex = input.LastIndexOf(' ', currentIndex + maxLength - 1, maxLength);

                    if (spaceIndex != -1 && spaceIndex >= currentIndex)
                    {
                        substringLength = spaceIndex - currentIndex + 1;
                    }
                }

                string substring = input.Substring(currentIndex, substringLength);
                result.Add(substring);

                currentIndex += substringLength;
            }

            return result;
        }
    }
}
