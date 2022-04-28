using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class ShootAck : OutgoingPacket
    {
        public int Time;

        public override void Write(RotmgBinaryWriter writer) => writer.Write(Time);
    }
}
