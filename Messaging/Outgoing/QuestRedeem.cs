using RotmgNetworkingLib.Binary;

using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class QuestRedeem : OutgoingPacket
    {
        public string QuestId;
        public int Item;
        public SlotObjectData[] Slots;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(QuestId);
            writer.Write(Item);

            writer.Write((short)Slots.Length);
            foreach (SlotObjectData slot in Slots)
                slot.Write(writer);
        }
    }
}
