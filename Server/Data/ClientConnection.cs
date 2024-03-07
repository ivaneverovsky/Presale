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

        TcpListener listener = new TcpListener(IPAddress.Any, PortNum);

        Socket? socket;

        public void ConnectClient()
        {
            listener.Start();

            socket = listener.AcceptSocket();
            MessageBox.Show("Client connected", "Server alert");
        }

        public async Task ReceiveClientRequests()
        {
            while (true)
            {
                await Task.Delay(5000);
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

                        string[] method = request.Split(':');
                        string result = method[0];

                        switch (result)
                        {
                            case "/message":
                                {
                                    result = method[1].Substring(1, method[1].Length - 2);
                                    MessageBox.Show(result);

                                    break;
                                }
                            case "/filter":
                                {
                                    result = method[1].Substring(1, method[1].Length - 2);
                                    MessageBox.Show(result);

                                    break;
                                }
                            case "/auth":
                                {
                                    result = method[1].Substring(1, method[1].Length - 2);
                                    MessageBox.Show(result);

                                    break;
                                }
                            default:
                                break;
                        }
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
            socket?.Shutdown(SocketShutdown.Both);
            socket?.Close();
        }
    }
}
