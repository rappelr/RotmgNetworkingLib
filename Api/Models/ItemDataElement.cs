using RotmgNetworkingLib.Extensions;
using RotmgNetworkingLib.Models;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ItemDataElement : IXMLElement
    {

        public long? Id;
        public ushort Type;

        public void Read(XElement element)
        {
            Id = element.GetNullableLongAttribute("id");
            Type = element.GetUShortAttribute("type");
        }

        public IdItem ParseIdItem() => new IdItem(Id, Type);
    }
}
