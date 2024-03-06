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
           // MessageBox.Show("Waiting for connection", "Server alert");

            socket = listener.AcceptSocket();
            MessageBox.Show("Client connected", "Server alert");
        }

        public async Task ReceiveClientRequest()
        {
            while (true)
            {
                await Task.Delay(3000);
                await Task.Run(() => ReadRequest());
            }
        }

        public void ReadRequest()
        {
            byte[] buf = new byte[InByfferSize];
            try
            {
                if (socket?.Available > 0)
                {
                    int received = socket.Receive(buf);
                    string request = "";
                    if (received > 0)
                    {
                        request = Encoding.UTF8.GetString(buf, 0, received);
                        MessageBox.Show(request, "Server alert");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server error");
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
