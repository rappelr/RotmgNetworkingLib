using RotmgNetworkingLib.Extensions;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ClassStatsElement : IXMLElement
    {
        public short ObjectType;
        public byte BestLevel;
        public int BestBaseFame;
        public int BestTotalFame;

        public void Read(XElement element)
        {
            ObjectType = Convert.ToInt16(element.GetStringAttribute("objectType"), 16);
            BestLevel = element.GetByte("BestLevel");
            BestBaseFame = element.GetInt("BestBaseFame");
            BestTotalFame = element.GetInt("BestTotalFame");
        }
    }
}
