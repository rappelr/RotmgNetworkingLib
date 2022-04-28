using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ClassAvailabilityElement : IXMLElement
    {
        public string Id;
        public string Availability;

        public void Read(XElement element)
        {
            Id = element.GetStringAttribute("id");
            Availability = element.Value;
        }
    }
}
