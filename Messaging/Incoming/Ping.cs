using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Ping : IncomingPacket
    {
        public int Serial;

        public override void Read(RotmgBinaryReader reader) => Serial = reader.ReadInt32();
    }
}
