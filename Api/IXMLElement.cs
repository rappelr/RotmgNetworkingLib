using System.Xml.Linq;

namespace RotmgNetworkingLib.Api
{
    public interface IXMLElement
    {
        void Read(XElement element);
    }
}
