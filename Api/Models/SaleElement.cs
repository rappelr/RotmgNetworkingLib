using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class SaleElement : IXMLElement
    {
        public int Price;

        public byte Currency;

        public void Read(XElement element)
        {
            Price = element.GetIntAttribute("price");
            Currency = element.GetByteAttribute("currency");
        }
    }
}
