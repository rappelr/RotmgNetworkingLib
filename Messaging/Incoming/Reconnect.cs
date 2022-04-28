using RotmgNetworkingLib.Binary;
using RotmgNetworkingLib.Models;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Reconnect : IncomingPacket
    {
        public string Name;
        public string Host;

        public int Port;
        public int GameId;
        public int KeyTime;

        public byte[] Key;

        public bool IsFromArena;

        public override void Read(RotmgBinaryReader reader)
        {
            Name = reader.ReadUTF();
            Host = reader.ReadUTF();
            Port = reader.ReadUInt16();
            GameId = reader.ReadInt32();
            KeyTime = reader.ReadInt32();
            IsFromArena = reader.ReadBoolean();

            Key = new byte[reader.ReadInt16()];
            for (int index = 0; index < Key.Length; ++index)
                Key[index] = reader.ReadByte();
        }

        public ReconnectKey ParseReconnectKey()
        {
            return new ReconnectKey()
            {
                Value = Key,
                Port = Port,
                Time = KeyTime
            };
        }
    }
}
