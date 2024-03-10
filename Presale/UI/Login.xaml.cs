using System.Windows;

namespace Presale.UI
{
    public partial class Login : Window
    {
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

                txtPassword.Clear();
                Hide();
            }
        }
        public void Register(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
        }
    }
}
