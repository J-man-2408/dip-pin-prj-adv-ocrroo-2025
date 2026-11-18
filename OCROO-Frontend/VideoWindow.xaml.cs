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

namespace OCROO_Frontend
{
    /// <summary>
    /// Interaction logic for VideoWindow.xaml
    /// </summary>
    public partial class VideoWindow : Window
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
        }

        private bool isPlaying = true;

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
    }
}
