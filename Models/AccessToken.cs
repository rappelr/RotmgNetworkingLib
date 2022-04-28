using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Models
{
    public class AccessToken : IReadable, IWritable
    {
        public string Value;
        public int Timestamp;
        public int Expiry;

        public void Read(RotmgBinaryReader reader)
        {
            Value = reader.ReadUTF();
            Timestamp = reader.ReadInt32();
            Expiry = reader.ReadInt32();
        }

        public void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(Value);
            writer.Write(Timestamp);
            writer.Write(Expiry);
        }
    }
}
