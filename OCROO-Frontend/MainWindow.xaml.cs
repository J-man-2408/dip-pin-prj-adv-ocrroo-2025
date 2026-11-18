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
        private static readonly HttpClient client = new()
        {
            BaseAddress = new Uri("http://127.0.0.1:8000")
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void GET_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxGetInformation.Text = "Loading...";

            try
            {
                HttpResponseMessage response = await client.GetAsync("/video");
                response.EnsureSuccessStatusCode();
                TextBoxGetInformation.Text = await response.Content.ReadAsStringAsync();
            }
            catch (HttpRequestException ex)
            {
                TextBoxGetInformation.Text = $"Error: cannot reach the server. {ex.Message}";
            }
        }
    }
}