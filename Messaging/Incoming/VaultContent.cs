using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class VaultContent : IncomingPacket
    {
        public int[] VaultContents;
        public int[] GiftContents;
        public int[] PotionContents;

        public int vaultUpgradeCost;
        public int PotionUpgradeCost;
        public int CurrentPotionMax;
        public int NextPotionMax;

        public override void Read(RotmgBinaryReader reader) // fix?
        {
            reader.ReadCompressed();
            reader.ReadCompressed();
            reader.ReadCompressed();
            reader.ReadCompressed();

            VaultContents = new int[reader.ReadCompressed()];
            for (int index = 0; index < VaultContents.Length; ++index)
                VaultContents[index] = reader.ReadCompressed();

            GiftContents = new int[reader.ReadCompressed()];
            for (int index = 0; index < GiftContents.Length; ++index)
                GiftContents[index] = reader.ReadCompressed();

            PotionContents = new int[reader.ReadCompressed()];
            for (int index = 0; index < PotionContents.Length; ++index)
                PotionContents[index] = reader.ReadCompressed();
        }
    }
}
