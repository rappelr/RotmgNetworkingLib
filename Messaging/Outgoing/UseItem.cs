using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class UseItem : OutgoingPacket
    {
        public int Time;
        public SlotObjectData SlotData;
        public WorldPosData ItemUsePos;
        public byte UseType;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(this.Time);

            SlotData.Write(writer);
            ItemUsePos.Write(writer);

            writer.Write(this.UseType);
        }
    }
}
