using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    internal class Authorisation
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AccountType { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public bool Authorised { get; set; }
        public Authorisation(string name, string surname, string email, string phone, string accountType, string login, string password, string department, string occupation, bool authorised)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Phone = phone;
            AccountType = accountType;
            Login = login;
            Password = password;
            Department = department;
            Occupation = occupation;
            Authorised = authorised;
        }
    }
}
