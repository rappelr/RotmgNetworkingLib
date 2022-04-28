using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class PlayerText : OutgoingPacket
    {
        public string Text;

        public override void Write(RotmgBinaryWriter writer) => writer.WriteUTF(Text);
    }
}
