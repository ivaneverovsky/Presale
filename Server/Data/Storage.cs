using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Data
{
    internal class Storage
    {
        private List<User> _users = new List<User>();
        public List<User> Users { get { return _users; } }
        public void AddUser(User user) { _users.Add(user); }

        private List<Authorisation> _auth = new List<Authorisation>();
        public List<Authorisation> Auth { get { return _auth; } }
        public void AddAuth(Authorisation auth) { _auth.Add(auth); }
    }
}
