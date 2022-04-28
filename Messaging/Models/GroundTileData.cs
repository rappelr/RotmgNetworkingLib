using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class GroundTile : IReadable
    {
        public short X;
        public short Y;

        public ushort Type;

        public GroundTile() { }

        public GroundTile(short x, short y, ushort type)
        {
            X = x;
            Y = y;
            Type = type;
        }

        public void Read(RotmgBinaryReader reader)
        {
            X = reader.ReadInt16();
            Y = reader.ReadInt16();
            Type = reader.ReadUInt16();
        }
    }
}
