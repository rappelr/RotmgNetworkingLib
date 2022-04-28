using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class AbilityElement : IXMLElement
    {
        public int Type, Power, Points;

        public void Read(XElement element)
        {
            Type = element.GetIntAttribute("type");
            Power = element.GetIntAttribute("power");
            Points = element.GetIntAttribute("points");
        }
    }
}
