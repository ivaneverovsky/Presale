using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Server.Data
{
    class ClientConnection
    {
        const int PortNum = 25000;
        const int InByfferSize = 1024;

        Socket? socket;

        public void ConnectClient()
        {
            TcpListener listener = new TcpListener(IPAddress.Any, PortNum);
            listener.Start();
            MessageBox.Show("Waiting for connection", "Server alert");

            socket = listener.AcceptSocket();
            MessageBox.Show("Client connected", "Server alert");
        }

        public void ReceiveClientRequest()
        {
            byte[] buf = new byte[InByfferSize];
            if (socket?.Available > 0)
            {
                int received = socket.Receive(buf);
                if (received > 0)
                    MessageBox.Show(Encoding.ASCII.GetString(buf, 0, received), "Server alert");
            }
        }

        public void DisconnectClient()
        {
            socket?.Disconnect(false);
            socket?.Close();
            MessageBox.Show("Closed connection.", "Server alert");
        }
    }
}
