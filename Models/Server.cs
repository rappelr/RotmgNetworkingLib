using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Models
{
    public class Server : IReadable, IWritable
    {
        public string Name, DNS;

        public Server(string name, string DNS)
        {
            Name = name;
            this.DNS = DNS;
        }

        public Server()
        {
            Name = null;
            DNS = null;
        }

        public void Read(RotmgBinaryReader reader)
        {
            Name = reader.ReadUTF();
            DNS = reader.ReadUTF();
        }

        public void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(Name);
            writer.WriteUTF(DNS);
        }

        public override string ToString()
        {
            return "[" + Name + "@" + DNS + "]";
        }
    }
}
