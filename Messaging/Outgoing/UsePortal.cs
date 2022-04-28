using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class UsePortal : OutgoingPacket
    {
        public int ObjectId;

        public override void Write(RotmgBinaryWriter writer) => writer.Write(ObjectId);
    }
}
