using System;
using System.IO;
using System.Net;
using System.Text;

namespace RotmgNetworkingLib.Binary
{
    public class RotmgBinaryWriter : BinaryWriter
    {
        public RotmgBinaryWriter(Stream s) : base(s) { }

        public byte[] ToByteArray() => (BaseStream as MemoryStream).ToArray();

        public override void Write(short value) => base.Write(IPAddress.NetworkToHostOrder(value));

        public override void Write(ushort value) => base.Write((ushort)IPAddress.HostToNetworkOrder((short)value));

        public override void Write(int value) => base.Write(IPAddress.NetworkToHostOrder(value));

        public override void Write(string value) => WriteUTF(value);

        public override void Write(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            Array.Reverse(bytes);
            Write(bytes);
        }

        public void WriteUTF(string s)
        {
            Write((short)s.Length);
            Write(Encoding.UTF8.GetBytes(s));
        }

        public void WriteUTF32(string s)
        {
            Write(s.Length);
            Write(Encoding.UTF8.GetBytes(s));
        }

        public void WriteArray<T>(Write<T> writer, T[] array, bool writeLength = true)
        {
            if (writeLength)
                Write(array.Length);
            for (int i = 0; i < array.Length; i++)
                writer.Invoke(array[i]);
        }

        public void GWrite<T>(T t) where T : IWritable
        {
            t.Write(this);
        }
    }

    public delegate void Write<T>(T @object);

    public interface IWritable
    {
        void Write(RotmgBinaryWriter writer);
    }
}
