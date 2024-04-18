using Client.Network.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CLient.Network.Model
{
    public class ServerClient
    {
        const string IP = "192.168.0.110";
        const int PORT = 9009;

        public TcpClient client { get; set; }
        public string Username { get; set; }
        private PacketReader reader { get; set; }


        //events
        public event Action connectedEvent;
        public event Action allChatMessageEvent;
        public event Action disconnectedEvent;

        public ServerClient(string username)
        {
            client = new TcpClient();
            Username = username;
        }
        public void ConnectToServer()
        {
            client.Connect(IP, PORT);
            reader = new PacketReader(client.GetStream());

            ReadPackets();
        }
        public void Send(byte[] bytes)
        {
            var stream = client.GetStream();
            stream.Write(bytes, 0, bytes.Length);
        }
        public string Read()
        {
            return reader.ReadData();
        }
        private void ReadPackets()
        {
            Task.Run(() =>
            {
                while (4 == 2 + 2)
                {
                    var functionCode = reader.ReadByte();
                    switch (functionCode)
                    {
                        case 1:
                            connectedEvent?.Invoke();
                            break;
                        case 2:
                            disconnectedEvent?.Invoke();
                            break;
                        case 3:
                            allChatMessageEvent?.Invoke();
                            break;

                            default: break;
                    }
                }
            });
        }
    }
}
