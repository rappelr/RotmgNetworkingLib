using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class ForgeUnlockedBlueprints : IncomingPacket
    {
        public int[] UnlockedItems;

        public override void Read(RotmgBinaryReader reader)
        {
            UnlockedItems = new int[reader.ReadByte()];

            for (int i = 0; i < UnlockedItems.Length; i++)
                UnlockedItems[i] = reader.ReadCompressed();
        }
    }
}
