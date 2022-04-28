using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class TradeRequested : IncomingPacket
    {
        public string Name;

        public override void Read(RotmgBinaryReader reader) => Name = reader.ReadUTF();
    }
}
