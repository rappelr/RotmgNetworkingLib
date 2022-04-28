using RotmgNetworkingLib.Models;
using RotmgNetworkingLib.Utilities;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ChestElement : IXMLElement
    {
        public IdItem[] Contents;

        public void Read(XElement element)
        {
            Contents = Array.ConvertAll(element.Value.Split(','), IdItem.Parse);
        }

        public ushort?[] ParseUShortArray()
        {
            ushort?[] result = new ushort?[Contents.Length];

            for (int i = 0; i < result.Length; i++)
                result[i] = Conversion.IntToNullableUShort(Contents[i].Type);

            return result;
        }
    }
}
