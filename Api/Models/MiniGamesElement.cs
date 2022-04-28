using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class MiniGamesElement : IXMLElement
    {
        public string Version;

        public List<MysteryBoxElement> MysteryBoxes;

        public void Read(XElement element)
        {
            Version = element.GetStringAttribute("version");
            
            MysteryBoxes = element.GetList<MysteryBoxElement>("MysteryBox");
        }
    }
}
