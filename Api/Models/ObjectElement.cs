using RotmgNetworkingLib.Extensions;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class ObjectElement : IXMLElement
    {
        public ushort Type;
        public string Id, Class;

        public void Read(XElement element)
        {
            Type = Convert.ToUInt16(element.GetStringAttribute("type"), 16);

            Id = element.GetStringAttribute("id");

            Class = element.GetNullableString("Class");
        }
    }
}
