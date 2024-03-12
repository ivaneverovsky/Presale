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
                //MessageBox.Show("Connected", "Alert");
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
                return respond = Encoding.UTF8.GetString(buf, 0, received);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed\n" + ex.Message, "Error");
                if (!socket.Connected)
                    return respond;
            }
            return respond;
        }
        public string GetContacts(string request)
        {
            string respond = "False";
            socket = client.Client;
            try
            {
                socket.Send(Encoding.UTF8.GetBytes(request));

                //wait respond
                byte[] buf = new byte[1024];
                int received = socket.Receive(buf);
                return respond = Encoding.UTF8.GetString(buf, 0, received);
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
        public void CreateRequest()
        {
            socket = client.Client;
            try
            {
                string request = "";

                socket.Send(Encoding.UTF8.GetBytes(request));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed\n" + ex.Message, "Error");
                if (!socket.Connected)
                    return;
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
