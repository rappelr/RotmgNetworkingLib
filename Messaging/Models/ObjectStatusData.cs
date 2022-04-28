using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class ObjectStatus : IReadable
    {
        public int ObjectId;
        public WorldPosData Position;
        public StatData[] Stats;

        public void Read(RotmgBinaryReader reader)
        {
            ObjectId = reader.ReadCompressed();
            Position = new WorldPosData(reader.ReadSingle(), reader.ReadSingle());

            Stats = new StatData[reader.ReadCompressed()];
            for (int index = 0; index < Stats.Length; ++index)
                (Stats[index] = new StatData()).Read(reader);
        }
    }
}
