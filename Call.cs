using AForge.Video;
using AForge.Video.DirectShow;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace anonymous_chat
{
    public partial class Call : Form
    {
        public Main? main;
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private WaveInEvent? waveSource = null;
        private WaveFileWriter? waveFile = null;
        private Queue<double> soundLevels = new Queue<double>();
        private const int soundLevelAverageCount = 10;
        private int selectedCamIndex = -1;
        private TcpClient video;
        private TcpClient audio;
        private bool receiveAudioEnabled = true;

        public Call()
        {
            InitializeComponent();
            CB_cam.SelectedIndexChanged += CB_cam_SelectedIndexChanged;
            Thread connectVideo = new Thread(VideoConnect);
            connectVideo.IsBackground = true;
            connectVideo.Start();
            Thread connectAudio = new Thread(AudioConnect);
            connectAudio.IsBackground = true;
            connectAudio.Start();
        }

        public void Start()
        {
            Thread receiveVideoThread = new Thread(ReceiveVideo);
            receiveVideoThread.IsBackground = true;
            receiveVideoThread.Start();

            Thread receiveAudioThread = new Thread(() => ReceiveAudio());
            receiveAudioThread.IsBackground = true;
            receiveAudioThread.Start();
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
            main.Send("ENDCALL=" + main.UID);
        }

        private void AudioConnect()
        {
            while (true)
            {
                try
                {
                    audio = new TcpClient("127.0.0.1", 9000);
                    break;
                }
                catch (SocketException)
                {
                    Thread.Sleep(1000);
                }
            }
            audio.GetStream();
            byte[] message = Encoding.UTF8.GetBytes("UIDCALL=" + main.UID);
            audio.GetStream().Write(message, 0, message.Length);
        }

        private async void ReceiveAudio()
        {
            NetworkStream stream = audio.GetStream();
            BufferedWaveProvider? bufferedWaveProvider = null;
            WaveOut? waveOut = null;
            var timeoutDuration = TimeSpan.FromSeconds(3);

            while (true)
            {
                if (!receiveAudioEnabled)
                {
                    await Task.Delay(500); // Wait for a bit before checking again
                    PBar_resound.Value = PBar_resound.Minimum;
                    continue;
                }

                // Read the size of the next audio data chunk
                byte[] sizeBytes = new byte[4];
                if (await stream.ReadAsync(sizeBytes, 0, sizeBytes.Length) != sizeBytes.Length)
                {
                    // Clear the progress bar on error
                    this.Invoke((MethodInvoker)delegate
                    {
                        PBar_resound.Value = PBar_resound.Minimum;
                    });
                    break; // Connection closed or error
                }

                int dataSize = BitConverter.ToInt32(sizeBytes, 0);
                byte[] dataBytes = new byte[dataSize];

                // Read the audio data itself
                int bytesRead = 0;
                while (bytesRead < dataSize)
                {
                    int read = await stream.ReadAsync(dataBytes, bytesRead, dataSize - bytesRead);
                    if (read == 0)
                    {
                        // Clear the progress bar on error
                        this.Invoke((MethodInvoker)delegate
                        {
                            PBar_resound.Value = PBar_resound.Minimum;
                        });
                        break; // Connection closed or error
                    }
                    bytesRead += read;
                }

                if (bytesRead == dataSize)
                {
                    try
                    {
                        // Ensure the wave provider and wave out are initialized
                        if (bufferedWaveProvider == null)
                        {
                            WaveFormat waveFormat = new WaveFormat(44100, 1); // Match the format used for recording
                            bufferedWaveProvider = new BufferedWaveProvider(waveFormat);
                            bufferedWaveProvider.BufferLength = 20 * 1024 * 1024;
                            bufferedWaveProvider.DiscardOnBufferOverflow = true;
                            waveOut = new WaveOut();
                            waveOut.Init(bufferedWaveProvider);
                            waveOut.Play();
                        }

                        // Add the received audio data to the buffered wave provider
                        bufferedWaveProvider?.AddSamples(dataBytes, 0, bytesRead);

                        // Calculate the max amplitude from the buffer for UI update
                        int max = 0;
                        for (int index = 0; index < bytesRead; index += 2)
                        {
                            short sample = (short)((dataBytes[index + 1] << 8) | dataBytes[index]);
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

                        // Update PBar_resound based on the received audio data
                        this.Invoke((MethodInvoker)delegate
                        {
                            PBar_resound.Value = (int)(amplifiedAveragePercent * PBar_resound.Maximum);
                        });
                    }
                    catch (Exception ex)
                    {
                        // Clear the progress bar on error
                        this.Invoke((MethodInvoker)delegate
                        {
                            PBar_resound.Value = PBar_resound.Minimum;
                        });
                        Debug.WriteLine("Error playing audio: " + ex.Message);
                    }
                }
                else
                {
                    // Clear the progress bar on error
                    this.Invoke((MethodInvoker)delegate
                    {
                        PBar_resound.Value = PBar_resound.Minimum;
                    });
                }
            }
        }


        private void VideoConnect()
        {
            while (true)
            {
                try
                {
                    video = new TcpClient("127.0.0.1", 9001);
                    break;
                }
                catch (SocketException)
                {
                    Thread.Sleep(1000);
                }
            }
            video.GetStream();
            byte[] message = Encoding.UTF8.GetBytes("UIDCALL=" + main.UID);
            video.GetStream().Write(message, 0, message.Length);
        }

        private async void ReceiveVideo()
        {
            NetworkStream stream = video.GetStream();
            var timeoutDuration = TimeSpan.FromSeconds(5);
            DateTime lastReceived = DateTime.Now;
            while (true)
            {
                // Read the size of the next frame
                byte[] sizeBytes = new byte[4];
                if (await stream.ReadAsync(sizeBytes, 0, sizeBytes.Length) != sizeBytes.Length)
                {
                    // Clear the PictureBox on error or connection closed
                    this.Invoke((MethodInvoker)delegate
                    {
                        PB_you.Image = null;
                    });
                    break; // Connection closed or error
                }

                int frameSize = BitConverter.ToInt32(sizeBytes, 0);
                byte[] frameBytes = new byte[frameSize];

                // Read the frame itself
                int bytesRead = 0;
                while (bytesRead < frameSize)
                {
                    int read = await stream.ReadAsync(frameBytes, bytesRead, frameSize - bytesRead);
                    if (read == 0)
                    {
                        // Clear the PictureBox on error or connection closed
                        this.Invoke((MethodInvoker)delegate
                        {
                            PB_you.Image = null;
                        });
                        break; // Connection closed or error
                    }
                    bytesRead += read;
                }

                if (bytesRead == frameSize)
                {
                    // Convert byte array to image
                    Image frameImage;
                    using (MemoryStream ms = new MemoryStream(frameBytes))
                    {
                        frameImage = Image.FromStream(ms);
                    }
                    Image resizedImage = ResizeImage(frameImage, PB_you.Width, PB_you.Height);
                    // Update the PictureBox on the UI thread
                    this.Invoke((MethodInvoker)delegate
                    {
                        // Assuming PB_me is your PictureBox
                        PB_you.Image?.Dispose(); // Dispose the previous image to free resources
                        PB_you.Image = resizedImage;
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        PB_you.Image = null;
                    });
                    break;
                }
            }
        }

        private Image ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
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

        private async void CB_cam_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                // Stop the current video source
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                await Task.Delay(100);
                PB_me.Image = Properties.Resources.user300x300;

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

            SendVideoFrame(resizedBitmap);

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

        private void SendVideoFrame(Bitmap frame)
        {
            if (video != null && video.Connected)
            {
                try
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        frame.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); // Consider using a more efficient format/encoding
                        byte[] frameBytes = ms.ToArray();
                        NetworkStream stream = video.GetStream();
                        // Send the frame size followed by the frame bytes
                        byte[] frameSize = BitConverter.GetBytes(frameBytes.Length);
                        stream.Write(frameSize, 0, frameSize.Length);
                        stream.Write(frameBytes, 0, frameBytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., connection issues)
                    Debug.WriteLine("Error sending video frame: " + ex.Message);
                }
            }
        }

        private async void BT_cam_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                BT_cam.BackColor = Color.Red;
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                main.Send("CAMOFF=" + main.UID);
                await Task.Delay(100);
                PB_me.Image = Properties.Resources.user300x300;
            }
            else
            {
                BT_cam.BackColor = Color.White;
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
            if (audio != null && audio.Connected)
            {
                try
                {
                    NetworkStream stream = audio.GetStream();
                    // Send the audio data size followed by the audio data bytes
                    byte[] dataSize = BitConverter.GetBytes(e.BytesRecorded);
                    stream.Write(dataSize, 0, dataSize.Length);
                    stream.Write(e.Buffer, 0, e.BytesRecorded);
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., connection issues)
                    Debug.WriteLine("Error sending audio data: " + ex.Message);
                }
            }

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
                try
                {
                    short sample = (short)((e.Buffer[index + 1] << 8) | e.Buffer[index]);
                    var absSample = Math.Abs(sample);
                    if (absSample > max) max = absSample;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error calculating max amplitude: " + ex.Message);
                }
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


        private async void BT_mic_Click(object sender, EventArgs e)
        {
            if (waveSource != null)
            {
                BT_mic.BackColor = Color.Red;
                waveSource.StopRecording();
                // Reset the sound level indicator
                soundLevels.Clear();
                main.Send("MICOFF=" + main.UID);
                await Task.Delay(100);
                PBar_sound.Value = PBar_sound.Minimum;
            }
            else
            {
                BT_mic.BackColor = Color.White;
                InitializeAudioCapture();
            }
        }

        private void BT_sound_Click(object sender, EventArgs e)
        {
            receiveAudioEnabled = !receiveAudioEnabled;
            BT_sound.BackColor = receiveAudioEnabled ? Color.White : Color.Red;
        }

        private void BT_exit_Click(object sender, EventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
            }
            if (waveSource != null)
            {
                waveSource.StopRecording();
            }
            main.Send("ENDCALL=" + main.UID);
            Dispose();
        }
    }
}
