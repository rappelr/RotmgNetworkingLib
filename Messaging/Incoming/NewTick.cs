using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class NewTick : IncomingPacket
    {
        public int TickId;
        public int TickTime;
        public int ServerRealTimeMS;
        public int LastServerRTMS;
        public ObjectStatus[] Statuses;

        public override void Read(RotmgBinaryReader reader)
        {
            TickId = reader.ReadInt32();
            TickTime = reader.ReadInt32();
            ServerRealTimeMS = reader.ReadInt32();
            LastServerRTMS = reader.ReadUInt16();

            Statuses = new ObjectStatus[reader.ReadInt16()];
            for (int index = 0; index < Statuses.Length; ++index)
                (Statuses[index] = new ObjectStatus()).Read(reader);
        }
    }
}
