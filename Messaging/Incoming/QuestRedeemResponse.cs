using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class QuestRedeemResponse : IncomingPacket
    {
        public bool Ok;
        public string Message;

        public override void Read(RotmgBinaryReader reader)
        {
            Ok = reader.ReadBoolean();
            Message = reader.ReadUTF();
        }
    }
}
