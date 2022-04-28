using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Goto : IncomingPacket
    {
        public int ObjectId;
        public WorldPosData Position;

        public override void Read(RotmgBinaryReader reader)
        {
            ObjectId = reader.ReadInt32();
            Position = new WorldPosData(reader.ReadSingle(), reader.ReadSingle());
        }
    }
}
