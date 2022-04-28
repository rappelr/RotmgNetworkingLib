using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class ShowEffect : IncomingPacket
    {
        public uint EffectType;
        public int TargetObjectId, Color, Size;
        public WorldPosData Position1, Position2;
        public float Duration;

        public override void Read(RotmgBinaryReader reader)
        {
            Position1 = new WorldPosData();
            Position2 = new WorldPosData();

            EffectType = reader.ReadByte();

            uint option = reader.ReadByte();

            TargetObjectId = ((option & 0b_0100_0000) > 0) ? reader.ReadCompressed() : 0;
            Position1.X = ((option & 0b_0000_0010) > 0) ? reader.ReadSingle() : 0;
            Position1.Y = ((option & 0b_0000_0100) > 0) ? reader.ReadSingle() : 0;
            Position2.X = ((option & 0b_0000_1000) > 0) ? reader.ReadSingle() : 0;
            Position2.Y = ((option & 0b_0001_0000) > 0) ? reader.ReadSingle() : 0;
            Color = ((option & 0b_0000_0001) > 0) ? reader.ReadInt32() : 0;
            Duration = ((option & 0b_0010_0000) > 0) ? reader.ReadSingle() : 1f;
            Size = ((option & 0b_1000_0000) > 0) ? reader.ReadByte() : 100;
        }
    }
}
