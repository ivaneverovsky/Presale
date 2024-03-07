using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Data
{
    internal class Storage
    {
        private List<Authentification> _auth = new List<Authentification>();
        public List<Authentification> Auth { get {  return _auth; } }
        public void AddAuth(Authentification auth)
        {
            _auth.Add(auth);
        }
    }
}
