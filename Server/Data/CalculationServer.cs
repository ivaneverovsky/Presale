using Server.Models;

namespace Server.Data
{
    internal class CalculationServer
    {
        DBConnection _db = new DBConnection();
        Storage _stor = new Storage();

        private List<object> dbData = new List<object>();

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

                respond = BuildAuthRespond(auth);
                return respond;
            }

            return respond;
        }
        public string BuildAuthRespond(Authorisation auth)
        {
            string respond = "name:[" + auth.Name + "]:surname:[" + auth.Surname + "]:email:[" + auth.Email + "]:phone:[" + auth.Phone + "]:accountType:[" + auth.AccountType + "]:login:[" + auth.Login + "]:passwprd:[" + auth.Password + "]:department:[" + auth.Department + "]:occupation:[" + auth.Occupation +  "]:authorised:[" + auth.Authorised + "]";
            

            return respond;
        }
    }
}
