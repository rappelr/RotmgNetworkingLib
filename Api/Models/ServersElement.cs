using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ServersElement : IXMLElement
    {
        public List<ServerElement> Servers;

        public void Read(XElement element)
        {
            Servers = element.GetList<ServerElement>("Server");
        }
    }
}
