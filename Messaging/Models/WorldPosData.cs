using RotmgNetworkingLib.Binary;
using System;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class WorldPosData : IWritable, IReadable
    {
        public float X;
        public float Y;

        public WorldPosData() { }

        public WorldPosData(float x, float y)
        {
            X = x;
            Y = y;
        }

        public WorldPosData(WorldPosData data)
        {
            X = data.X;
            Y = data.Y;
        }

        public void Write(RotmgBinaryWriter writer)
        {
            writer.Write(X);
            writer.Write(Y);
        }
        public void Read(RotmgBinaryReader reader)
        {
            X = reader.ReadSingle();
            Y = reader.ReadSingle();
        }

        public float Distance(WorldPosData position)
        {
            double dX = position.X - X;
            double dY = position.Y - Y;
            return (float)Math.Sqrt(dX * dX + dY * dY);
        }

        public override string ToString() => "[" + X + "," + Y + "]";
    }
}
