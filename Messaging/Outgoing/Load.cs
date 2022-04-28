using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Load : OutgoingPacket
    {
        public int CharId;
        public bool IsChallenger;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(CharId);
            writer.Write(IsChallenger);
        }
    }
}
