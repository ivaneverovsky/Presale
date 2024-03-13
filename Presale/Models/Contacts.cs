using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Presale.Models
{
    internal class Contacts
    {
        [JsonProperty(PropertyName = "FullName", Required = Required.Always)]
        public string FullName { get; set; }
        [JsonProperty(PropertyName = "Login", Required = Required.Always)]
        public string Login { get; set; }
        [JsonProperty(PropertyName = "Department", Required = Required.Always)]
        public string Department { get; set; }
        [JsonProperty(PropertyName = "Occupation", Required = Required.Always)]
        public string Occupation { get; set; }
        public Contacts(string fullName, string login, string department, string occupation)
        {
            FullName = fullName;
            Login = login;
            Department = department;
            Occupation = occupation;
        }
    }
}
