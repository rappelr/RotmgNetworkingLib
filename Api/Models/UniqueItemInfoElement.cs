using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class UniqueItemInfoElement : IXMLElement
    {
        public List<ItemDataElement> ItemData;

        public void Read(XElement element)
        {
            ItemData = element.GetList<ItemDataElement>("ItemData");
        }
    }
}
