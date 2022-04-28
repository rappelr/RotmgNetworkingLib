using RotmgNetworkingLib.Binary;
using System;

namespace RotmgNetworkingLib.Models
{
    public class CharTarget : IReadable, IWritable
    {
        public bool Create;
        public short Type, Skin;
        public int Id;

        public void Read(RotmgBinaryReader reader)
        {
            Create = reader.ReadBoolean();

            if (Create)
            {
                Type = reader.ReadInt16();
                Skin = reader.ReadInt16();
            }
            
            Id = reader.ReadInt32();
        }

        public void Write(RotmgBinaryWriter writer)
        {
            writer.Write(Create);

            if (Create)
            {
                writer.Write(Type);
                writer.Write(Skin);
            }
            
            writer.Write(Id);
        }
    }
}
