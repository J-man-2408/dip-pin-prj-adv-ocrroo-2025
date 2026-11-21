using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Globalization;
using System.Net.Http;

namespace OCRRoo_Frontend
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : UserControl
    {
        private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("http://127.0.0.1:8000")
        };
        public VideoWindow()
        {
            InitializeComponent();

            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "video.mp4");
            VideoPlayer.Source = new Uri(path);
            VideoPlayer.Play();
            VideoPlayer.Pause();
        }

        private bool isPlaying = true;

        public void PauseVideo()
        {
            VideoPlayer.Pause();
            PlayPauseButton.Content = "PLAY";
            isPlaying = false;
        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (isPlaying)
            {
                VideoPlayer.Pause();
                PlayPauseButton.Content = "PLAY";
            }
            else
            {
                VideoPlayer.Play();
                PlayPauseButton.Content = "PAUSE";
            }
            isPlaying = !isPlaying;
        }

        private async void ExtractButton_Click(object sender, RoutedEventArgs e)
        {
            double seconds = VideoPlayer.Position.TotalSeconds;
            ExtractButton.IsEnabled = false;
            ExtractButton.Content = "READING...";

            try
            {
                string url = $"/video/demo/frame/{seconds.ToString("F2", CultureInfo.InvariantCulture)}/ocr";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string text = (await response.Content.ReadAsStringAsync()).Trim();

                if (text.Length == 0)
                {
                    MessageBox.Show("Error: no text was found in that frame", "Extract");
                }

                else
                {
                    ExtractionStore.Items.Add(new Extraction
                    {
                        Location = "demo (resources/video.mp4)",
                        Timing = $"{seconds:F2} seconds",
                        Text = text
                    });
                    MessageBox.Show("Text extracted and added to Extraction Text page", "Extract");
                }
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("Error: can't reach the server. Check that it is running and try again.", "Extract");
            }
            finally
            {
                ExtractButton.IsEnabled = true;
                ExtractButton.Content = "EXTRACT";
            }
        }
    }
}
