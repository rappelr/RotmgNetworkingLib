using RotmgNetworkingLib.Extensions;
using RotmgNetworkingLib.Models;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ServerElement : IXMLElement
    {
        public string Name;
        public string DNS;

        public double Lat;
        public double Long;
        public double Usage;

        public void Read(XElement element)
        {
            Name = element.GetString("Name");
            DNS = element.GetString("DNS");

            Lat = element.GetDouble("Lat");
            Long = element.GetDouble("Long");
            Usage = element.GetDouble("Usage");
        }

        public Server ParseServer() => new Server()
        {
            DNS = DNS,
            Name = Name
        };
    }
}
