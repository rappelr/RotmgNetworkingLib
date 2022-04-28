using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class AcceptTrade : OutgoingPacket
    {
        public bool[] ClientOffer;
        public bool[] PartnerOffer;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write((short)ClientOffer.Length);
            foreach (bool flag in ClientOffer)
                writer.Write(flag);

            writer.Write((short)PartnerOffer.Length);
            foreach (bool flag in PartnerOffer)
                writer.Write(flag);
        }
    }
}
