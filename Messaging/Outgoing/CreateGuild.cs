using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class CreateGuild : OutgoingPacket
    {
        public string Name;

        public override void Write(RotmgBinaryWriter writer) => writer.WriteUTF(this.Name);
    }
}
