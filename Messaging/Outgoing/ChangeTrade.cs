using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class ChangeTrade : OutgoingPacket
    {
        public bool[] Offer;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write((short)Offer.Length);
            for (int index = 0; index < Offer.Length; ++index)
                writer.Write(Offer[index]);
        }
    }
}
