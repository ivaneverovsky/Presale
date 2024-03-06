using Presale.Data;
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

namespace Presale
{
    public partial class MainWindow : Window
    {
        ServerConnection server = new ServerConnection();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Connection(object sender, RoutedEventArgs e)
        {
            server.ConnectServer();
        }
        public void SendMessage(object sender, RoutedEventArgs e)
        {
            string message = txtMessage.Text;
            if (message != "")
            {
                server.SendServerRequest(message);

                txtMessage.Clear();
                txtMessage.Focus();
            }
        }
    }
}