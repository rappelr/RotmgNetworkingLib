using System;
using System.IO;
using System.Net;
using System.Text;

namespace RotmgNetworkingLib.Binary
{
    public class RotmgBinaryReader : BinaryReader
    {
        public RotmgBinaryReader(Stream s) : base(s) { }

        public override short ReadInt16() => IPAddress.NetworkToHostOrder(base.ReadInt16());

        public override ushort ReadUInt16() => (ushort)IPAddress.NetworkToHostOrder((short)base.ReadUInt16());

        public override int ReadInt32() => IPAddress.NetworkToHostOrder(base.ReadInt32());

        public override float ReadSingle()
        {
            byte[] array = ReadBytes(4);
            Array.Reverse(array);
            return BitConverter.ToSingle(array, 0);
        }

        public int ReadCompressed()
        {
            byte num1 = ReadByte();
            bool flag = (num1 & 64U) > 0U;
            int num2 = 6;
            int num3 = num1 & 63;

            while ((num1 & 128) > 0)
            {
                num1 = ReadByte();
                num3 |= (num1 & sbyte.MaxValue) << num2;
                num2 += 7;
            }

            return flag ? -num3 : num3;
        }

        public string ReadUTF() => Encoding.UTF8.GetString(ReadBytes((int)ReadInt16()));

        public string ReadUTF32() => Encoding.UTF8.GetString(ReadBytes(ReadInt32()));

        public T[] ReadArray<T>(Read<T> reader, int? length = null)
        {
            T[] arr = new T[length ?? ReadInt32()];

            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] = reader.Invoke();
            }

            return arr;
        }

        public T Read<T>() where T : IReadable, new()
        {
            T t = new T();
            t.Read(this);
            return t;
        }

        public T Read<T>(T t) where T : IReadable
        {
            t.Read(this);
            return t;
        }

        public int Remaining() => (int)(BaseStream.Length - BaseStream.Position);
    }

    public delegate T Read<T>();

    public interface IReadable
    {
        void Read(RotmgBinaryReader reader);
    }
}
