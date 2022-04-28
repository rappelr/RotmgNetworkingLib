using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class InvitedToGuild : IncomingPacket
    {
        public string Name;
        public string GuildName;

        public override void Read(RotmgBinaryReader reader)
        {
            Name = reader.ReadUTF();
            GuildName = reader.ReadUTF();
        }
    }
}
