using RotmgNetworkingLib.Binary;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RotmgNetworkingLib.Messaging
{
    public class Packet
    {
        private static readonly Dictionary<Type, byte> _typeToId = new Dictionary<Type, byte>();
        private static readonly Dictionary<byte, Type> _idToType = new Dictionary<byte, Type>();

        public static byte Convert(Type type) => _typeToId[type];

        public static Type Convert(byte type) => _idToType[type];

        static Packet()
        {
            Prepare();
        }

        internal static void Prepare()
        {
            foreach (Type type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type?.BaseType?.BaseType == typeof(Packet))
                {
                    if (Enum.TryParse(type.Name, true, out PacketMapping packetType))
                    {
                        _typeToId.Add(type, (byte)packetType);
                        _idToType.Add((byte)packetType, type);
                    }
                    else
                        Console.WriteLine("Failed to bind packet to mapping " + type.Name);
                }
            }
        }

        public byte ByteType => Convert(GetType());
    }


    public abstract class IncomingPacket : Packet, IReadable
    {
        public abstract void Read(RotmgBinaryReader reader);
    }


    public abstract class OutgoingPacket : Packet, IWritable
    {
        public abstract void Write(RotmgBinaryWriter writer);
    }
}
