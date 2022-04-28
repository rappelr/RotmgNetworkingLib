using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class Hello : OutgoingPacket
    {
        public string BuildVersion;
        public string Guid;
        public string Password;
        public string Secret;
        //public string MapJSON;
        public string EntryTag;
        public string GameNet;
        public string GameNetUserId;
        public string PlayPlatform;
        public string PlatformToken;
        public string UserToken;
        public string ClientToken;
        public string Token;
        public string LastGuid;

        public int GameId;
        public int KeyTime;

        public byte[] Key;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.WriteUTF(this.BuildVersion);
            writer.Write(this.GameId);
            writer.WriteUTF(this.Guid);
            writer.Write(this.KeyTime);
            writer.Write((short)this.Key.Length);
            writer.Write(this.Key);
            //writer.WriteUTF32(this.MapJSON);
            writer.WriteUTF(this.EntryTag);
            writer.WriteUTF(this.GameNet);
            writer.WriteUTF(this.GameNetUserId);
            //writer.WriteUTF(this.PlayPlatform);
            //writer.WriteUTF(this.PlatformToken);
            writer.WriteUTF(this.UserToken);
            writer.WriteUTF(this.Token);
        }
    }
}
