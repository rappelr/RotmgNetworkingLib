using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ItemCostElement : IXMLElement
    {
        public short Type;

        public bool Purchasable;
        public bool Expires;

        public int Cost;

        public void Read(XElement element)
        {
            Type = element.GetShortAttribute("type");

            Purchasable = element.GetBoolAttribute("purchasable");
            Expires = element.GetBoolAttribute("expires");

            Cost = int.Parse(element.Value);
        }
    }
}
