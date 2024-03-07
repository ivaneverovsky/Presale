using Presale.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Presale.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ServerConnection _server = new ServerConnection();

        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
        public Login(string userLogin, string userPassword)
        {
            InitializeComponent();

            UserLogin = userLogin;
            UserPassword = userPassword;
        }

        public void SignIn(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text != "" && txtPassword.Password != "")
            {
                UserLogin = txtLogin.Text;
                UserPassword = txtPassword.Password;

                try
                {
                    bool respond = false;

                    _server.ConnectServer();
                    _server.CheckAuth(UserLogin, UserPassword);

                    //wait here for respond
                    //
                    // respond = fuck you
                    //
                    //till here

                    if (respond)
                    {
                        MessageBox.Show("Authentification true", "Alert");

                        _server.DisconnectServer();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Authentification false", "Error");
                        _server.DisconnectServer();

                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                    return;
                }
            }
        }
        public void Register(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
