using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
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
        public void CheckAuth(string login, string password)
        {
            socket = client.Client;
            try
            {
                string requestAuth = "/auth:[login " + login + "\npassword " + password + "]";
                MessageBox.Show(requestAuth);

                socket.Send(Encoding.UTF8.GetBytes(requestAuth));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send failed\n" + ex.Message, "Error");
                if (!socket.Connected)
                {
                    return;
                }
            }
            return;
        }
        public void SendServerMessage(string userLogin, string chatId, string message)
        {
            socket = client.Client;
            if (userLogin != "" && chatId != "" && message != "")
            {
                try
                {
                    string requestMessage = "/message:[" + message + "]";

                    socket.Send(Encoding.UTF8.GetBytes(requestMessage));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Send failed\n" + ex.Message, "Error");
                    if (!socket.Connected)
                    {
                        return;
                    }
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
                    {
                        return;
                    }
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
