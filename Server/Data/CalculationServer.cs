using Server.Models;

namespace Server.Data
{
    internal class CalculationServer
    {
        DBConnection _db = new DBConnection();
        Storage _stor = new Storage();

        private List<object> dbData = new List<object>();

        //auth
        public async Task<string> CheckAuth(string login, string password)
        {
            string request = @"SELECT * FROM [Presale].[dbo].[Users] WHERE login = '" + login + "' AND password = '" + password + "'";
            string respond = "False";

            await _db.CreateConnection();
            dbData = await _db.SendCommandRequest(request);
            _db.CloseConnection();

            if (dbData.Count == 1)
            {
                object[] value = (object[])dbData[0];
                var auth = new Authorisation(
                    value[0].ToString(), 
                    value[1].ToString(), 
                    value[2].ToString(), 
                    value[3].ToString(), 
                    value[4].ToString(), 
                    value[5].ToString(), 
                    value[6].ToString(), 
                    value[7].ToString(), 
                    value[8].ToString(), 
                    true);
                _stor.AddAuth(auth);

                dbData.Clear();
                respond = BuildAuthRespond(auth);
            }
            return respond;
        }
        private string BuildAuthRespond(Authorisation auth)
        {
            string respond = "name:[" + auth.Name + "]:surname:[" + auth.Surname + "]:email:[" + auth.Email + "]:phone:[" + auth.Phone + "]:accountType:[" + auth.AccountType + "]:login:[" + auth.Login + "]:passwprd:[" + auth.Password + "]:department:[" + auth.Department + "]:occupation:[" + auth.Occupation +  "]:authorised:[" + auth.Authorised + "]";

            return respond;
        }
        
        //contacts
        public async Task RequestContacts()
        {
            string request = @"SELECT UserName, UserSurname, Login, Department, Occupation FROM [Presale].[dbo].[Users]";

            await _db.CreateConnection();
            dbData = await _db.SendCommandRequest(request);
            _db.CloseConnection();
        }
        public List<Contacts> CollectContacts()
        {
            List<Contacts> respond = [];
            if (dbData != null && _stor.Contacts.Count == 0)
            {
                for (int i = 0; i < dbData.Count; i++)
                {
                    object[] value = (object[])dbData[i];
                    var contact = new Contacts(
                        value[0].ToString() + " " + value[1].ToString(),
                        value[2].ToString(),
                        value[3].ToString(),
                        value[4].ToString()
                        );
                    _stor.AddContact(contact);
                }
                dbData.Clear();
            }
            respond = _stor.Contacts;
            return respond;
        }

        //new request
        public async Task CreateRequest()
        {
            string request = @"";

            await _db.CreateConnection();
            dbData = await _db.SendCommandRequest(request);
            _db.CloseConnection();
        }
    }
}
