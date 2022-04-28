using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Failure : IncomingPacket
    {
        public int ErrorId;
        public string ErrorDescription;

        public override void Read(RotmgBinaryReader reader)
        {
            ErrorId = reader.ReadInt32();
            ErrorDescription = reader.ReadUTF();
        }
    }
}
