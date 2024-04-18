using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network.IO
{
    internal class PacketReader : BinaryReader
    {
        private NetworkStream stream;
        public PacketReader(NetworkStream stream) : base(stream)
        {
            this.stream = stream;
        }

        public string ReadData()
        {
            byte[] buffer;
            var lenght = ReadInt32();
            buffer = new byte[lenght];
            stream.Read(buffer, 0, buffer.Length);
            return Encoding.ASCII.GetString(buffer);
        }
    }
}
