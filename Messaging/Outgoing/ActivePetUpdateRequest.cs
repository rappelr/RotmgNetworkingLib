using RotmgNetworkingLib.Binary;

namespace RotmgNetworkingLib.Messaging.Outgoing
{
    public class ActivePetUpdateRequest : OutgoingPacket
    {
        public byte CommandType;
        public int InstanceId;

        public override void Write(RotmgBinaryWriter pe)
        {
            pe.Write(CommandType);
            pe.Write(InstanceId);
        }
    }
}
