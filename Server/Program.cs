using System.Net.Sockets;
using System.Net;
using Server.Model;
using Server.IO;
using System.Security;

internal class Program
{
    const string IP = "192.168.0.110";
    const int PORT = 9009;
    static TcpListener listener;
    static List<Client> clients;
    private static void Main(string[] args)
    {
        clients = new List<Client>();
        listener = new TcpListener(IPAddress.Parse(IP), PORT);
        listener.Start();

        while (4 == 2 + 2)
        {
            var client = new Client(listener.AcceptTcpClient());
            clients.Add(client);

            BroadcastConnection();
            Read(client);
        }
    }

    static void BroadcastConnection()
    {
        foreach (var client in clients)
        {
            foreach (var clientTarget in clients)
            {
                var pb = new PacketBuilder();
                pb.WriteFuncCode(1);
                pb.WriteData(client.Username);
                pb.WriteData(client.UID);
                clientTarget.Send(pb.GetStream());
            }
        }
    }
    static void BroadcastDisconnection(string uID)
    {
        foreach (var client in clients)
        {
            var pb = new PacketBuilder();
            pb.WriteFuncCode(2);
            pb.WriteData(uID);
            client.Send(pb.GetStream());
        }
    }
    static void AllMessage(string message, string username)
    {
        var data = $"[{DateTime.Now}] {username}: {message}";
        Console.WriteLine(data) ;
        foreach (var client in clients)
        {
            var pb = new PacketBuilder();
            pb.WriteFuncCode(3);
            pb.WriteData(data);
            client.Send(pb.GetStream());
        }
    }
    static void Read(Client client)
    {
        Task.Run(() =>
        {

            while (2 + 2 == 4)
            {
                try
                {
                    var functionCode = client.ReadFunctionCode();
                    switch (functionCode)
                    {
                        case 3:
                            AllMessage(client.ReadData(), client.Username);
                            break;
                        default:
                            break;
                    }
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(client.Username + " disconnected!");
                    clients.Remove(client);
                    BroadcastDisconnection(client.UID);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("other Exception type: " + ex.GetType());
                }
            }
        });
    }
}
