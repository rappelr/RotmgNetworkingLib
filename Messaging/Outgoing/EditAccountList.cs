using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class EditAccountList : OutgoingPacket
    {
        public int AccountListId;
        public bool Add;
        public int ObjectId;

        public override void Write(RotmgBinaryWriter writer)
        {
            writer.Write(AccountListId);
            writer.Write(Add);
            writer.Write(ObjectId);
        }
    }
}
