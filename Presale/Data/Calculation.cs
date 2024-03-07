using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presale.Data
{
    internal class Calculation
    {
        Storage _stor = new Storage();


        public void AddAuth(Authentification auth) { _stor.AddAuth(auth); }
        public List<Authentification> CollectAuth() { return _stor.Auth; }
    }
}
