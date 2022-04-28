using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ErrorElement : IXMLElement
    {
        public string ErrorMessage;

        public void Read(XElement element)
        {
            ErrorMessage = element.Value;
        }
    }
}
