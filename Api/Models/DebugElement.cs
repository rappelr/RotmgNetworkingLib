using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class DebugElement : IXMLElement
    {
        public string Content;

        public void Read(XElement element) => Console.WriteLine("\n" + (Content = element.ToString()) + "\n");
    }
}
