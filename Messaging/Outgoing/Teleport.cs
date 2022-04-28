using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Teleport : OutgoingPacket
    {
        public int ObjectId;
        public string ObjectName;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(ObjectId);
            writer.WriteUTF(ObjectName);
        }
    }
}
