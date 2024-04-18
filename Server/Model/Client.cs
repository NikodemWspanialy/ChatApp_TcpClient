using Server.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server.Model
{
    internal class Client
    {
        public TcpClient TcpClient { get; set; }
        public string UID { get; set; }
        public string Username { get; set; }

        private PacketReader streamReader { get; set; }
        public Client(TcpClient tcpClient)
        {
            this.TcpClient = tcpClient;
            streamReader = new PacketReader(tcpClient.GetStream());

            var functionCode = streamReader.ReadByte();
            Username = streamReader.ReadData();
            UID = Guid.NewGuid().ToString();
            Console.WriteLine($"[{DateTime.Now}] client connected with username: {Username}");
        
        }
        public void Send(byte[] packet)
        {
            var stream = TcpClient.GetStream();
            stream.Write(packet, 0, packet.Length);
        }

        public byte ReadFunctionCode()
        {
            return streamReader.ReadByte();
        }
        public string ReadData()
        {
            return streamReader.ReadData();
        }
    }
}
