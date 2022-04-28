using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Pong : OutgoingPacket
    {
        public int Serial;
        public int Time;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(Serial);
            writer.Write(Time);
        }
    }
}
