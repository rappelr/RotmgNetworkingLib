using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class TradeAccepted : IncomingPacket
    {
        public bool[] ClientOffer;
        public bool[] PartnerOffer;

        public override void Read(RotmgBinaryReader reader)
        {
            ClientOffer = new bool[reader.ReadInt16()];
            for (int index = 0; index < ClientOffer.Length; ++index)
                ClientOffer[index] = reader.ReadBoolean();

            PartnerOffer = new bool[reader.ReadInt16()];
            for (int index = 0; index < PartnerOffer.Length; ++index)
                PartnerOffer[index] = reader.ReadBoolean();
        }
    }
}
