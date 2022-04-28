using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Reference;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class StatData : IReadable
    {
        public byte StatType;
        public int StatValue;
        public string StringValue;
        public byte MagicNumber;

        public void Read(RotmgBinaryReader reader)
        {
            StatType = reader.ReadByte();

            if (StatisticMapping.IsStringStat(StatType))
                StringValue = reader.ReadUTF();
            else
                StatValue = reader.ReadCompressed();

            MagicNumber = reader.ReadByte();
        }
    }
}
