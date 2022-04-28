using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class MapInfo : IncomingPacket
    {
        public int Width;
        public int Height;
        public int Difficulty;
        public int Background;
        public int MaxPlayers;

        public uint Seed;
        public uint GameOpenedTime;

        public string Name;
        public string DisplayName;
        public string RealmName;
        public string LastGuid;
        public string ClientVersion;

        public string[] ClientXML;
        public string[] ExtraXML;

        public bool AllowPlayerTeleport;
        public bool ShowDisplays;
        public bool Unknown1;

        public override void Read(RotmgBinaryReader reader)
        {
            Width = reader.ReadInt32();
            Height = reader.ReadInt32();
            Name = reader.ReadUTF();
            DisplayName = reader.ReadUTF();
            RealmName = reader.ReadUTF();
            Seed = reader.ReadUInt32();
            Background = reader.ReadInt32();
            Difficulty = reader.ReadInt32();
            AllowPlayerTeleport = reader.ReadBoolean();
            ShowDisplays = reader.ReadBoolean();
            Unknown1 = reader.ReadBoolean();
            MaxPlayers = reader.ReadInt16();
            GameOpenedTime = reader.ReadUInt32();
            ClientVersion = reader.ReadUTF();
        }
    }
}
