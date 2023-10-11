using Presale.Interfaces;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Presale;

public static class MauiProgram
{
    const int PortNum = 25000;

    public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IAlertService, AlertService>();


		//connection to server
		TcpClient client = new TcpClient();
		client.Connect(IPAddress.Loopback, PortNum);

        var socket = client.Client;
        string line;
        do
        {
            line = "suck";
            if (line != "")
            {
                try
                {
                    socket.Send(Encoding.ASCII.GetBytes(line));
                }
                catch (SocketException)
                {
                    Console.WriteLine("Send failed");
                    if (!socket.Connected)
                        break;
                }
            }
        } while (line != "");

        socket.Disconnect(false);
        client.Close();
        //end connection

        return builder.Build();
	}
}
