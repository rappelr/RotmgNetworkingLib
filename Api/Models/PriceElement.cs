using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class PriceElement : IXMLElement
    {
        public int Amount;

        public byte Currency;

        public void Read(XElement element)
        {
            Amount = element.GetIntAttribute("amount");
            Currency = element.GetByteAttribute("currency");
        }
    }
}
