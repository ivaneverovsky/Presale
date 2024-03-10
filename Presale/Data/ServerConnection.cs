using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Presale.Data
{
    class ServerConnection
    {
        const int PortNum = 25000;
        Socket? socket;
        TcpClient client = new TcpClient();

        public void ConnectServer()
        {
            try
            {
                client.Connect(IPAddress.Loopback, PortNum);
                MessageBox.Show("Connected", "Alert");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public string CheckAuth(string login, string password)
        {
            string respond = "False";
            socket = client.Client;
            try
            {
                string requestAuth = "/auth:/login:[" + login + "]" + ":/password:[" + password + "]";
                socket.Send(Encoding.UTF8.GetBytes(requestAuth));

                //wait respond
                byte[] buf = new byte[1024];
                int received = socket.Receive(buf);
                respond = Encoding.UTF8.GetString(buf, 0, received);
                string[] method = respond.Split(':');

                if (respond == "False")
                    return respond;
                else
                    return method[19].Substring(1, method[19].Length - 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed\n" + ex.Message, "Error");
                if (!socket.Connected)
                    return respond;
            }
            return respond;
        }
        public void SendServerMessage(string userLogin, string chatId, string message)
        {
            socket = client.Client;
            if (userLogin != "" && chatId != "" && message != "")
            {
                try
                {
                    string requestMessage = "/message:[" + message + "]" + ":/login:[" + userLogin + "]" + ":/chatId:[" + chatId + "]";

                    socket.Send(Encoding.UTF8.GetBytes(requestMessage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send failed\n" + ex.Message, "Error");
                    if (!socket.Connected)
                        return;
                }
            }
        }
        public void SendServerFilter(string filter)
        {
            socket = client.Client;
            if (filter != "")
            {
                try
                {
                    string requestFilter = "/filter:[" + filter + "]";

                    socket.Send(Encoding.UTF8.GetBytes(requestFilter));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send failed\n" + ex.Message, "Error");
                    if (!socket.Connected)
                        return;
                }
            }
        }
        public void DisconnectServer()
        {
            socket?.Disconnect(false);
            socket?.Shutdown(SocketShutdown.Both);
            client.Close();
        }
    }
}
