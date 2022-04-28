using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class ClaimLoginRewardMsg : OutgoingPacket
    {
        public string ClaimKey;
        public string ClaimType;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(ClaimKey);
            writer.WriteUTF(ClaimType);
        }
    }
}
