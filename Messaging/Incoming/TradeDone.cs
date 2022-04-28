using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class TradeDone : IncomingPacket
    {
        public int TradeCode;
        public string Description;

        public override void Read(RotmgBinaryReader reader)
        {
            TradeCode = reader.ReadInt32();
            Description = reader.ReadUTF();
        }
    }
}
