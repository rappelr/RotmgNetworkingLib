using RotmgNetworkingLib.Extensions;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ClassPowerUpStatsElement : IXMLElement
    {
        public short Class;
        public byte[] Stats;

        public void Read(XElement element)
        {
            Class = element.GetShortAttribute("class");
            Stats = Array.ConvertAll(element.Value.Split(','), byte.Parse);
        }
    }
}
