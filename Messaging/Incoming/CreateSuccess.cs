using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class CreateSuccess : IncomingPacket
    {
        public int ObjectId;
        public int CharId;

        public override void Read(RotmgBinaryReader reader)
        {
            ObjectId = reader.ReadInt32();
            CharId = reader.ReadInt32();
        }
    }
}
