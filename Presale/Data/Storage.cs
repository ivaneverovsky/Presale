﻿using Presale.Models;

namespace Presale.Data
{
    internal class Storage
    {
        private List<Authentification> _auth = new List<Authentification>();
        public List<Authentification> Auth { get { return _auth; } }
        public void AddAuth(Authentification auth) { _auth.Add(auth); }

        private List<Contacts> _contacts = new List<Contacts>();
        public List<Contacts> Contacts { get { return _contacts; } }
        public void AddContacts(Contacts contacts) { _contacts.Add(contacts); }
        public void RemoveContacts() { _contacts.Clear(); }
    }
}
