using Presale.Data;
using Presale.UI;
using System.Windows;
using System.Windows.Controls;

namespace Presale
{
    public partial class MainWindow : Window
    {
        ServerConnection _server = new ServerConnection();
        Calculation _calc = new Calculation();

        private readonly List<Authentification> authList = new List<Authentification>();

        Login _login = new Login("", "");

        public MainWindow()
        {
            InitializeComponent();
            _server.ConnectServer();
            _login.ShowDialog();

            string respond = _server.CheckAuth(_login.UserLogin, _login.UserPassword);
            if (respond == "False")
                MessageBox.Show("Authorisation failed", "Error");
            else
            {
                _login.Close();
                _calc.AddAuth(respond);
                authList = _calc.CollectAuth();
            }
        }
        private void SendMessage(object sender, RoutedEventArgs e)
        {
            string chatId = "1";
            string message = txtMessage.Text;
            if (authList.Count != 0 && message != "")
            {
                _server.SendServerMessage(authList[0].Login, chatId, message);

                txtMessage.Clear();
                txtMessage.Focus();
            }
            else
            {
                MessageBox.Show("Authorisation first", "Alert");
                txtMessage.Clear();
            }
        }
        private void FilterChat(object sender, TextChangedEventArgs e)
        {
            string filter = txtFilter.Text;
            if (filter != "")
            {
                _server.SendServerFilter(filter);
            }
        }
    }
}