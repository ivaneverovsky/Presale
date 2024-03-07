using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Models
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(int id, string name, string surname, string email, string phone, string accountType, string login, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            AccountType = accountType;
            Login = login;
            Password = password;

        }
    }
}
