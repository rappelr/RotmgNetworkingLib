using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class VaultElement : IXMLElement
    {
        public List<ChestElement> Chests;

        public void Read(XElement element)
        {
            Chests = element.GetList<ChestElement>("Chest");
        }

        public ushort?[][] ParseUShortMap()
        {
            ushort?[][] result = new ushort?[Chests.Count][];

            for (int i = 0; i < result.Length; i++)
                result[i] = Chests[i].ParseUShortArray();

            return result;
        }
    }
}
