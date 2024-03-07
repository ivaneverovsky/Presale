using Server.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClientConnection client = new ClientConnection();
        public MainWindow()
        {
            InitializeComponent();
            client.ConnectClient();
        }

        public void StartReceivingRequest(object sender, RoutedEventArgs e)
        {
            client.ReceiveClientRequest();
        }
    }
}