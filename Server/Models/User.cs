namespace Server.Models
{
    internal class User
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
        public User(string name, string surname, string email, string phone, string accountType, string login, string password, string department, string occupation)
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
        }
    }
}
