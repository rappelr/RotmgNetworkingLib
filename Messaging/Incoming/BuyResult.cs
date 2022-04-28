using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class BuyResult : IncomingPacket
    {
        public int Result;
        public string ResultString;

        public override void Read(RotmgBinaryReader reader)
        {
            Result = reader.ReadInt32();
            ResultString = reader.ReadUTF();
        }
    }
}
