using RotmgNetworkingLib.Binary;
using System;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class ServerPlayerShoot : IncomingPacket
    {
        public uint BulletId;
        //TODO

        public override void Read(RotmgBinaryReader reader)
        {
            //throw new NotImplementedException();
        }
    }
}
