using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Models
{
    public class MoveRecord : IWritable
    {
        public int Time;
        public float X;
        public float Y;

        public MoveRecord(int time, float x, float y)
        {
            Time = time;
            X = x;
            Y = y;
        }

        public void Write(RotmgBinaryWriter writer)
        {
            writer.Write(Time);
            writer.Write(X);
            writer.Write(Y);
        }
    }
}
