using SpotifyAPI.Web;
using System.Windows;

namespace SpotifyCSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Controller controller = new Controller();
            controller.Start();
        }
    }
}
