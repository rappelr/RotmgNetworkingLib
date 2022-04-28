using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class JoinGuild : OutgoingPacket
    {
        public string Name;

        public override void Write(RotmgBinaryWriter writer) => writer.WriteUTF(Name);
    }
}
