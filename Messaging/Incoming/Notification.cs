using RotmgNetworkingLib.Binary;
using System;
using System.Collections.Generic;
using System.Text;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Notification : IncomingPacket
    {
        public int Type;
        public string Text;

        public override void Read(RotmgBinaryReader reader)
        {
            Type = reader.ReadInt32();
            Text = reader.ReadUTF();
        }
    }
}
