using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class EnemyShoot : IncomingPacket
    {
        public byte BulletId;
        public int OwnerId;

        public override void Read(RotmgBinaryReader reader)
        {
            BulletId = reader.ReadByte();
            OwnerId = reader.ReadInt32();
        }
    }
}
