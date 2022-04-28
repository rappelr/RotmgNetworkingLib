using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Move : OutgoingPacket
    {
        public int TickId;
        public int Time;
        public MoveRecord[] Records;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(TickId);
            writer.Write(Time);

            writer.Write((short)Records.Length);
            foreach (MoveRecord record in Records)
                record.Write(writer);
        }
    }
}
