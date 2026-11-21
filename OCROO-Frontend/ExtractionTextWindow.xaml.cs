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

namespace OCROO_Frontend
{
    /// <summary>
    /// Interaction logic for ExtractionTextWindow.xaml
    /// </summary>
    public partial class ExtractionTextWindow : Window
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
    }
}
