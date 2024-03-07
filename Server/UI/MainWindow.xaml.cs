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
    public partial class MainWindow : Window
    {
        ClientConnection client = new ClientConnection();
        DBConnection _db = new DBConnection();
        public MainWindow()
        {
            InitializeComponent();
            StartServer();
        }

        public void StartReceivingRequest(object sender, RoutedEventArgs e)
        {
            //await _db.CreateConnection();

            //client.ConnectClient();
            //await client.ReceiveClientRequests();
        }

        private async void StartServer()
        {
            await _db.CreateConnection();

            client.ConnectClient();
            await client.ReceiveClientRequests();
        }
    }
}