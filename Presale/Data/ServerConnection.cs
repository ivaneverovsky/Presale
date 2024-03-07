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
            client.Connect(IPAddress.Loopback, PortNum);
            MessageBox.Show("Connected", "Alert");
        }

        public void SendServerRequest(string line)
        {
            socket = client.Client;
            if (line != "")
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(line));
                }
                catch (SocketException)
                {
                    MessageBox.Show("Send failed", "Error");
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
