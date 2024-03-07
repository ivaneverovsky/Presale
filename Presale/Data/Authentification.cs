using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Data
{
    internal class Authentification
    {
        public string UserLogin { get; set; }
        public string Password { get; set; }
        public Authentification(string userLogin, string password)
        {
            UserLogin = userLogin;
            Password = password;
        }
    }
}
