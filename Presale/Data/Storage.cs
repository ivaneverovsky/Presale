using Presale.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Data
{
    class Storage
    {
        private List<User> _users = new List<User>();
        public List<User> Users { get { return _users; } }
        public void AddUser(User user)
        {
            _users.Add(user);
        }
    }
}
