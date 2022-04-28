using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class ObjectData : IReadable
    {
        public ushort ObjectType;
        public ObjectStatus Status;

        public void Read(RotmgBinaryReader reader)
        {
            ObjectType = reader.ReadUInt16();
            (Status = new ObjectStatus()).Read(reader);
        }
    }
}
