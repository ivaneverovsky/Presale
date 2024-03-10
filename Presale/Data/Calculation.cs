using System.Windows;

namespace Presale.Data
{
    internal class Calculation
    {
        Storage _stor = new Storage();
        public void AddAuth(string respond) 
        {
            try
            {
                string[] values = respond.Split(':');
                values[19].Substring(1, values[19].Length - 2);

                
                var auth = new Authentification(
                    values[1].Substring(1, values[1].Length - 2),
                    values[3].Substring(1, values[3].Length - 2),
                    values[5].Substring(1, values[5].Length - 2),
                    values[7].Substring(1, values[7].Length - 2),
                    values[9].Substring(1, values[9].Length - 2),
                    values[11].Substring(1, values[11].Length - 2),
                    values[13].Substring(1, values[13].Length - 2),
                    values[15].Substring(1, values[15].Length - 2),
                    values[17].Substring(1, values[17].Length - 2),
                    values[19].Substring(1, values[19].Length - 2)
                    );
                _stor.AddAuth(auth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public List<Authentification> CollectAuth() { return _stor.Auth; }
    }
}
