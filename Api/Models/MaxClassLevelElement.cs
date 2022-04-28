using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class MaxClassLevelElement : IXMLElement
    {
        public short ClassType;
        public byte MaxLevel;

        public void Read(XElement element)
        {
            ClassType = element.GetShortAttribute("classType");
            MaxLevel = element.GetByteAttribute("maxLevel");
        }
    }
}
