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
        ServerConnection _server = new ServerConnection();
        Calculation _calc = new Calculation();
        Authentification _auth = new Authentification("", "");

        Login _login = new Login("", "");

        private readonly List<Authentification> authList = new List<Authentification>();

        public MainWindow()
        {
            InitializeComponent();
            _server.ConnectServer();
            _login.ShowDialog();

            bool bull = CheckAuth();
            if (bull)
            {
                MessageBox.Show("Authentification true", "Alert");

                _auth = new Authentification(_login.UserLogin, _login.UserPassword);
                _calc.AddAuth(_auth);
                authList = _calc.CollectAuth();

                _login.Close();
            }
            else
            {
                MessageBox.Show("Authorisation failed", "Error");
            }
        }

        private void Connection(object sender, RoutedEventArgs e)
        {
            _server.ConnectServer();
        }
        private void SendMessage(object sender, RoutedEventArgs e)
        {
            string chatId = "1";
            string message = txtMessage.Text;
            if (authList.Count != 0 && message != "")
            {
                _server.SendServerMessage(authList[0].UserLogin, chatId, message);

                txtMessage.Clear();
                txtMessage.Focus();
            }
            else
            {
                MessageBox.Show("Authorise first", "Alert");
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
        private bool CheckAuth()
        {
            try
            {
                string respond = _server.CheckAuth(_login.UserLogin, _login.UserPassword);
                if (respond == "True")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
    }
}