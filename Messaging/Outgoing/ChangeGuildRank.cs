using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class ChangeGuildRank : OutgoingPacket
    {
        public string Name;
        public int Rank;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(Name);
            writer.Write(Rank);
        }
    }
}
