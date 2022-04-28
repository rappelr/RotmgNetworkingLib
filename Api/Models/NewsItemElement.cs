using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class NewsItemElement : IXMLElement
    {
        public string Icon;
        public string Title;
        public string TagLine;
        public string Link;

        public int Date;

        public void Read(XElement element)
        {
            Icon = element.GetString("Icon");
            Title = element.GetString("Title");
            TagLine = element.GetString("TagLine");
            Link = element.GetString("Link");

            Date = element.GetInt("Date");
        }
    }
}
