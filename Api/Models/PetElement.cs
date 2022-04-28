using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class PetElement : IXMLElement
    {
        public string Name;

        public short Type;

        public int InstanceId;
        public int Rarity;
        public int MaxAbilityPower;
        public int Skin;

        public List<AbilityElement> Abilities;

        public void Read(XElement element)
        {
            Name = element.GetStringAttribute("name");

            Type = element.GetShortAttribute("type");

            InstanceId = element.GetIntAttribute("instanceId");
            Rarity = element.GetIntAttribute("rarity");
            MaxAbilityPower = element.GetIntAttribute("maxAbilityPower");
            Skin = element.GetIntAttribute("skin");

            Abilities = element.Element("Abilities").GetList<AbilityElement>("Ability");
        }
    }
}
