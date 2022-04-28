using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class InvResult : IncomingPacket
    {
        public byte Result;

        public override void Read(RotmgBinaryReader reader) => Result = reader.ReadByte();
    }
}
