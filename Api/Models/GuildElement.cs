using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class GuildElement : IXMLElement
    {
        public long Id;
        public string Name;
        public int Rank;

        public void Read(XElement element)
        {
            Id = element.GetLongAttribute("id");
            Name = element.GetString("Name");
            Rank = element.GetInt("Rank");
        }
    }
}
