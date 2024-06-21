using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat
{
    public partial class Call : Form
    {

        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WaveInEvent? waveSource = null;
        private WaveFileWriter? waveFile = null;
        private Queue<double> soundLevels = new Queue<double>();
        private const int soundLevelAverageCount = 10;
        private int selectedCamIndex = -1;

        public Call()
        {
            InitializeComponent();

            CB_cam.SelectedIndexChanged += CB_cam_SelectedIndexChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            if (waveSource != null)
            {
                waveSource.StopRecording();
            }
        }

        private void InitializeVideoCapture()
        {
            // Enumerate video devices
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count == 0)
            {
                MessageBox.Show("No camera");
                return;
            }

            // Populate CB_cam with the names of all available video devices
            CB_cam.Items.Clear(); // Clear existing items
            foreach (FilterInfo device in videoDevices)
            {
                CB_cam.Items.Add(device.Name);
            }
            CB_cam.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void CB_cam_SelectedIndexChanged(object sender, EventArgs e)
        {
            PB_me.Image = null;

            if (videoSource != null && videoSource.IsRunning)
            {
                // Stop the current video source
                videoSource.SignalToStop();
                videoSource.WaitForStop();

                // Check if a valid selection is made
                if (CB_cam.SelectedIndex != -1)
                {
                    // Create video source with the selected camera
                    videoSource = new VideoCaptureDevice(videoDevices[CB_cam.SelectedIndex].MonikerString);
                    videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

                    // Start the video source
                    videoSource.Start();
                }
            }

            selectedCamIndex = CB_cam.SelectedIndex;
        }

        private void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap originalBitmap = (Bitmap)eventArgs.Frame.Clone();
            Bitmap resizedBitmap = new Bitmap(originalBitmap, new Size(PB_me.Width, PB_me.Height));

            PB_me.BeginInvoke((MethodInvoker)delegate
            {
                if (PB_me.Image != null)
                {
                    var oldImage = PB_me.Image;
                    PB_me.Image = resizedBitmap;
                    oldImage.Dispose();
                }
                else
                {
                    PB_me.Image = resizedBitmap;
                }
            });

            // Dispose the original bitmap to free up resources
            originalBitmap.Dispose();
        }

        private void BT_cam_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                PB_me.Image = null;
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            else
            {
                PB_me.Image = null;
                InitializeVideoCapture();
                if (selectedCamIndex == -1)
                {
                    CB_cam.SelectedIndex = 0;
                }
                else
                {
                    CB_cam.SelectedIndex = selectedCamIndex;
                }
                // Create video source with the selected camera
                videoSource = new VideoCaptureDevice(videoDevices[CB_cam.SelectedIndex].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);

                // Start the video source
                videoSource.Start();
            }
        }

        private void InitializeAudioCapture()
        {
            waveSource = new WaveInEvent();
            waveSource.DeviceNumber = 0; // Default microphone
            waveSource.WaveFormat = new WaveFormat(44100, 1); // CD quality audio

            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSource_RecordingStopped);

            // Start capturing audio
            waveSource.StartRecording();
        }

        private void waveSource_RecordingStopped(object sender, StoppedEventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }

            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            // Write to file if waveFile is not null
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }

            // Calculate the max amplitude from the buffer for UI update
            int max = 0;
            for (int index = 0; index < e.BytesRecorded; index += 2)
            {
                short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index]);
                var absSample = Math.Abs(sample);
                if (absSample > max) max = absSample;
            }

            // Convert to a percentage of the maximum value of a 16-bit audio sample
            double percent = (double)max / short.MaxValue;

            // Add the current level to the queue and remove the oldest if necessary
            soundLevels.Enqueue(percent);
            if (soundLevels.Count > soundLevelAverageCount)
            {
                soundLevels.Dequeue();
            }

            // Calculate the average sound level
            double averagePercent = soundLevels.Average();

            // Amplify the average sound level to make the bar move more
            double amplifiedAveragePercent = averagePercent * 2; // Amplification factor of 2
                                                                 // Ensure the amplified value does not exceed 1
            amplifiedAveragePercent = Math.Min(amplifiedAveragePercent, 1);

            // Update the ProgressBar on the UI thread
            PBar_sound.BeginInvoke((MethodInvoker)delegate
            {
                PBar_sound.Value = (int)(amplifiedAveragePercent * PBar_sound.Maximum);
            });
        }


        private void BT_mic_Click(object sender, EventArgs e)
        {
            if (waveSource != null)
            {
                waveSource.StopRecording();
                // Reset the sound level indicator
                PBar_sound.BeginInvoke((MethodInvoker)delegate
                {
                    PBar_sound.Value = PBar_sound.Minimum;
                });
                soundLevels.Clear();
            }
            else
            {
                InitializeAudioCapture();
            }
        }
    }
}
