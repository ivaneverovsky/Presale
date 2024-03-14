using Microsoft.Win32;
using Presale.Data;
using Presale.Models;
using Presale.UI;
using System.Windows;
using System.Windows.Controls;

namespace Presale
{
    public partial class MainWindow : Window
    {
        ServerConnection _server = new ServerConnection();
        Calculation _calc = new Calculation();
        FileLoader _fl = new FileLoader();

        Login _login = new Login("", "");

        private readonly List<Authentification> authList = new List<Authentification>();

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
        private void CreateRequest(object sender, RoutedEventArgs e)
        {
            if (authList.Count != 0)
            {
                NewRequest nr = new NewRequest();

                List<Contacts> contacts = _server.GetContacts("/contacts");
                if (contacts != null)
                {
                    foreach (Contacts contact in contacts)
                        if (contact.Login != authList[0].Login)
                            _calc.AddContacts(contact);

                    nr.DataContext = _calc.CollectContacts();
                    nr.BuildUI();
                    nr.ShowDialog();
                }

                if (nr.RequestName != null && nr.RequestMessage != null)
                {
                    if (nr.RequestFiles != null)
                        _fl.Load(nr.RequestFiles);

                    _server.CreateRequest();
                }
            }
            else
            {
                MessageBox.Show("Authorisation first", "Alert");
                return;
            }
        }
        private void AttachFileToMessage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel files|*.xlsx;*.xlsb;*.xls|Word files|*.doc;*.docx|All files (*.*)|*.*",
                Multiselect = true
            };
            ofd.ShowDialog();

            if (ofd.FileName == "")
                return;

            _fl.Load(ofd);
        }
    }
}