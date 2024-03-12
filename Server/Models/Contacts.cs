using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Models
{
    internal class Contacts
    {
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public Contacts(string fullName, string department, string occupation)
        {
            FullName = fullName;
            Department = department;
            Occupation = occupation;
        }
    }
}
