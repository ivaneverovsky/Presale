using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Server.Data
{
    class ClientConnection
    {
        const int PortNum = 25000;
        const int InByfferSize = 1024;

        CalculationServer _calc = new CalculationServer();
        TcpListener listener = new TcpListener(IPAddress.Any, PortNum);

        Socket? socket;

        public void ConnectClient()
        {
            listener.Start();
            socket = listener.AcceptSocket();
            //MessageBox.Show("Client connected", "Server alert");
        }
        public async Task ReceiveClientRequests()
        {
            while (true)
            {
                await Task.Delay(3000);
                await Task.Run(() => ReadRequest());
            }
        }
        public async void ReadRequest()
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
                        switch (method[0])
                        {
                            case "/message":
                                {
                                    string message = method[1].Substring(1, method[1].Length - 2);
                                    string login = method[3].Substring(1, method[3].Length - 2);
                                    string chatId = method[5].Substring(1, method[5].Length - 2);

                                    MessageBox.Show("login: " + login + "\nchat id: " + chatId + "\nmessage: " + message);

                                    break;
                                }
                            case "/filter":
                                {
                                    string filter = method[1].Substring(1, method[1].Length - 2);

                                    MessageBox.Show(filter);

                                    break;
                                }
                            case "/auth":
                                {
                                    string login = method[2].Substring(1, method[2].Length - 2);
                                    string password = method[4].Substring(1, method[4].Length - 2);

                                    string respond = await Task.Run(() => _calc.CheckAuth(login, password));
                                    SendRespond(respond);

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
        public void SendRespond(string respond)
        {
            try
            {
                if (/*socket?.Available > 0 || */socket != null)
                {
                    socket.Send(Encoding.UTF8.GetBytes(respond));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Server Error");
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
