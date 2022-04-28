using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class AnyElement : IXMLElement
    {
        public XElement Element;

        public void Read(XElement element)
        {
            Element = element;
        }
    }
}