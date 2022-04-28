using RotmgNetworkingLib.Binary;

using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class InvSwap : OutgoingPacket
    {
        public int Time;

        public WorldPosData Position;
        public SlotObjectData SlotObject1;
        public SlotObjectData SlotObject2;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(Time);

            Position.Write(writer);
            SlotObject1.Write(writer);
            SlotObject2.Write(writer);
        }
    }
}
