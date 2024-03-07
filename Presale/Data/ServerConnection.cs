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

        public void SendServerRequest(string message)
        {
            socket = client.Client;
            if (message != "")
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(message));
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
            else
            {
                return;
            }
        }

        public void DisconnectServer()
        {
            socket?.Disconnect(false);

            client.Close();
            MessageBox.Show("Connection closed", "Alert");
        }
    }
}
