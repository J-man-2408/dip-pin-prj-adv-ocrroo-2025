using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Win32;

namespace OCRRoo_Frontend
{
    /// <summary>
    /// Interaction logic for ExtractionTextWindow.xaml
    /// </summary>
    public partial class ExtractionTextWindow : UserControl
    {
        public ExtractionTextWindow()
        {
            InitializeComponent();
            ExtractionList.ItemsSource = ExtractionStore.Items;
            ExtractionStore.Items.CollectionChanged += (s, e) => UpdateEmptyState();
            UpdateEmptyState();
        }

        private void UpdateEmptyState()
        {
            if (ExtractionList.Items.Count == 0)
                NoExtractions.Visibility = Visibility.Visible;
            else
                NoExtractions.Visibility = Visibility.Collapsed;

        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Extraction extraction)
                Clipboard.SetText(extraction.Text);

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Extraction extraction)
                ExtractionStore.Items.Remove(extraction);
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is not Extraction extraction)
                return;

            var dialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt",
                FileName = $"extraction-{extraction.Timing.Replace(" seconds", "s")}.txt"
            };

            if (dialog.ShowDialog() != true)
                return;   //cancelled

            string content =
                $"Extraction File: {extraction.Location}{Environment.NewLine}" +
                $"Extraction Time: {extraction.Timing}{Environment.NewLine}{Environment.NewLine}" +
                $"Extraction Text:{Environment.NewLine}{extraction.Text}";

            try
            {
                File.WriteAllText(dialog.FileName, content);
                MessageBox.Show("Saved to " + dialog.FileName, "Download");
            }
            catch (Exception ex) when (ex is IOException || ex is UnauthorizedAccessException)
            {
                MessageBox.Show("Error: could not save the file. Try a different folder.", "Download");
            }
        }

        private void SmallerButton_Click(object sender, RoutedEventArgs e) => AppSettings.Instance.TextSize -= 2;
        private void LargerButton_Click(object sender, RoutedEventArgs e) => AppSettings.Instance.TextSize += 2;
    }
}
