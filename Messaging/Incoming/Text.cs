using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Text : IncomingPacket
    {
        public string Name;
        public string Recipient;
        public string Message;
        public string CleanText;

        public int ObjectId;
        public int NumStars;
        public int StarBg;

        public byte BubbleTime;
        public bool IsSupporter;

        public override void Read(RotmgBinaryReader reader)
        {
            Name = reader.ReadUTF();
            ObjectId = reader.ReadInt32();
            NumStars = reader.ReadInt16();
            BubbleTime = reader.ReadByte();
            Recipient = reader.ReadUTF();
            Message = reader.ReadUTF();
            CleanText = reader.ReadUTF();
            IsSupporter = reader.ReadBoolean();
            StarBg = reader.ReadInt32();
        }
    }
}
