using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Create : OutgoingPacket
    {
        public short ClassType;
        public short SkinType;
        public bool IsChallenger;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(ClassType);
            writer.Write(SkinType);
        }
    }
}
