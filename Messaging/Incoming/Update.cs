using RotmgNetworkingLib.Binary;

using RotmgNetworkingLib.Messaging.Models;

namespace RotmgNetworkingLib.Messaging.Incoming
{
    public class Update : IncomingPacket
    {
        public WorldPosData Position;
        public byte Unknown1;
        public GroundTile[] Tiles;
        public ObjectData[] NewObjects;
        public int[] Drops;

        public override void Read(RotmgBinaryReader reader)
        {
            (Position = new WorldPosData()).Read(reader);
            Unknown1 = reader.ReadByte();

            Tiles = new GroundTile[reader.ReadCompressed()];
            for (int index = 0; index < Tiles.Length; ++index)
                (Tiles[index] = new GroundTile()).Read(reader);

            NewObjects = new ObjectData[reader.ReadCompressed()];
            for (int index = 0; index < NewObjects.Length; ++index)
                (NewObjects[index] = new ObjectData()).Read(reader);

            Drops = new int[reader.ReadCompressed()];
            for (int index = 0; index < Drops.Length; ++index)
                Drops[index] = reader.ReadCompressed();
        }
    }
}
