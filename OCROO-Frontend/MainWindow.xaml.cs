using System.Linq.Expressions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OCROO_Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPanel.Visibility = MenuPanel.Visibility == Visibility.Visible
                ? Visibility.Collapsed : Visibility.Visible;
        }

        private void HomeMenu_Click(object sender, RoutedEventArgs e) => Show(HomePageView);
        private void VideoMenu_Click(object sender, RoutedEventArgs e) => Show(VideoPageView);
        private void ExtractionMenu_Click(object sender, RoutedEventArgs e) => Show(ExtractionPageView);
        private void AboutMenu_Click(object sender, RoutedEventArgs e) => Show(AboutPageView);

        private void Show(UserControl page)
        {
            HomePageView.Visibility = Visibility.Collapsed;
            VideoPageView.Visibility = Visibility.Collapsed;
            ExtractionPageView.Visibility = Visibility.Collapsed;
            AboutPageView.Visibility = Visibility.Collapsed;

            page.Visibility = Visibility.Visible;

            if (page != VideoPageView)
                VideoPageView.PauseVideo();

            MenuPanel.Visibility = Visibility.Collapsed;
        }
    }
}