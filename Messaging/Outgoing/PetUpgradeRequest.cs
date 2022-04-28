using RotmgNetworkingLib.Binary;

using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class PetUpgradeRequest : OutgoingPacket
    {
        public byte PetTransType;
        public byte PaymentType;

        public int PIDOne;
        public int PIDTwo;
        public int ObjectId;

        public SlotObjectData[] Slots;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(PetTransType);
            writer.Write(PIDOne);
            writer.Write(PIDTwo);
            writer.Write(ObjectId);
            writer.Write(PaymentType);

            writer.Write((short)Slots.Length);
            for (int index = 0; index < Slots.Length; ++index)
                Slots[index].Write(writer);
        }
    }
}
