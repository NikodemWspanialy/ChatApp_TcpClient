using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Network.IO
{
    internal class PacketBuilder
    {
        MemoryStream stream;

        public PacketBuilder()
        {
            stream = new MemoryStream();

        }

        public void WriteFuncCode(byte funcCode)
        {
            stream.WriteByte(funcCode);
        }
        public void WriteData(string data)
        {
            var lenght = data.Length;

            stream.Write(BitConverter.GetBytes(lenght));
            stream.Write(Encoding.ASCII.GetBytes(data));
        }
        public Byte[] GetStream() => stream.ToArray();
    }
}
