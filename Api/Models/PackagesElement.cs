using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class PackagesElement : IXMLElement
    {
        public string Version;

        public List<PackageElement> Packages;

        public void Read(XElement element)
        {
            Version = element.GetStringAttribute("version");

            Packages = element.GetList<PackageElement>("Package");
        }
    }
}
