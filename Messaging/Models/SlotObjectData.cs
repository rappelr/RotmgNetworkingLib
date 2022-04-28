using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class SlotObjectData : IWritable
    {
        public int ObjectId;
        public int SlotId;
        public int ObjectType;

        public void Write(RotmgBinaryWriter writer)
        {
            writer.Write(ObjectId);
            writer.Write(SlotId);
            writer.Write(ObjectType);
        }
    }
}
