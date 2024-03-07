using Presale.Data;
using Presale.UI;
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
        Calculation _calc = new Calculation();
        Authentification _auth = new Authentification("", "");

        Login _login = new Login("", "");

        List<Authentification> auth = new List<Authentification>();

        public MainWindow()
        {
            _login.ShowDialog();
            _auth = new Authentification(_login.UserLogin, _login.UserPassword);
            _calc.AddAuth(_auth);
            auth = _calc.CollectAuth();

            InitializeComponent();
        }

        public void Connection(object sender, RoutedEventArgs e)
        {
            server.ConnectServer();
        }
        public void SendMessage(object sender, RoutedEventArgs e)
        {

            string chatId = "1";
            string message = txtMessage.Text;
            if (message != "")
            {
                server.SendServerMessage("", chatId, message);

                txtMessage.Clear();
                txtMessage.Focus();
            }
        }
        public void FilterChat(object sender, TextChangedEventArgs e)
        {
            string filter = txtFilter.Text;
            if (filter != "")
            {
                server.SendServerFilter(filter);
            }
        }
    }
}