using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using ZXing.Common;

namespace EASEncoder_UI
{
    public partial class BarScanForm : Form
    {
        private readonly FilterInfoCollection _videoDevices;
        private VideoCaptureDevice _videoCaptureDevice;

        readonly string[] validBarcodes = {
            "2FENY",
            "barcode2",
            "barcode3"
        };

        public BarScanForm()
        {
            InitializeComponent();
            MessageBox.Show("Present your ID card to the camera.\n\nKeep the ID card 5 to 10 inches away from the camera, and keep the ID card centered and still. Make sure the area around you isn't too bright or too dark.");
            _videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in _videoDevices)
            {
                comboCameraList.Items.Add(device.MonikerString);
            }
            comboCameraList.Text = _videoDevices[1].MonikerString;
            //BarcodeTimer.Start();
            this.comboCameraList.SelectedIndexChanged += new EventHandler(this.comboCameraList_SelectedIndexChanged);
        }

        private void comboCameraList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
            {
                _videoCaptureDevice.SignalToStop();
                _videoCaptureDevice.WaitForStop();
            }
            _videoCaptureDevice = new VideoCaptureDevice(comboCameraList.Text);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.Start();
        }

        private void StartCamera()
        {
            if (_videoDevices.Count == 0)
            {
                MessageBox.Show("No cameras found.");
                this.DialogResult = DialogResult.Cancel;
                return;
            }

            _videoCaptureDevice = new VideoCaptureDevice(_videoDevices[1].MonikerString);
            _videoCaptureDevice.NewFrame += VideoCaptureDevice_NewFrame;
            _videoCaptureDevice.Start();
            //comboCameraList.Text = _videoDevices[1].MonikerString;
        }

        private void VideoCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxCameraFeed.Image = bitmap;
        }

        private void ScanBarcode(Bitmap bitmap)
        {
            BarcodeReader barcodeReader = new BarcodeReader
            {
                Options = new DecodingOptions
                {
                    AllowedLengths = new int[] { 16 },
                    TryInverted = true,
                    TryHarder = true,
                    PureBarcode = false,
                    UseCode39ExtendedMode = false,
                    PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.CODE_128 }
                }
            };
            Result result = barcodeReader.Decode(bitmap);

            if (result != null)
            {
                string barcodeText = result.Text;
                BarcodeTimer.Stop();
                if (validBarcodes.Contains(barcodeText))
                {
                    this.DialogResult = DialogResult.Yes;
                }
                else
                {
                    var dg = MessageBox.Show("Invalid card.\nCheck that the card isn't scratched.", "EASEncoder Fusion", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (dg == DialogResult.Retry)
                    {
                        BarcodeTimer.Start();
                    }
                    else this.DialogResult = DialogResult.No;
                }
            }
        }

        private void BarScanForm_Load(object sender, EventArgs e)
        {
            StartCamera();
        }

        private void BarScanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
            {
                _videoCaptureDevice.SignalToStop();
                _videoCaptureDevice.WaitForStop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning)
            {
                Bitmap currentFrame = (Bitmap)pictureBoxCameraFeed.Image.Clone();
                ScanBarcode(currentFrame);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (_videoCaptureDevice != null && _videoCaptureDevice.IsRunning && pictureBoxCameraFeed.Image != null)
            {
                Bitmap currentFrame = (Bitmap)pictureBoxCameraFeed.Image.Clone();
                ScanBarcode(currentFrame);
            }
        }
    }
}
