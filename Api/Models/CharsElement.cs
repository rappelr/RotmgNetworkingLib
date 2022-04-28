using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class CharsElement : IXMLElement
    {
        public int? NextCharId;
        public int? MaxNumChars;

        public double Lat;
        public double Long;

        public string SalesForce;

        public short[] OwnedSkins;

        public AccountElement Account;

        public List<CharElement> Chars;
        public List<ItemCostElement> ItemCosts;
        public List<NewsItemElement> News;
        public List<ServerElement> Servers;
        public List<ClassAvailabilityElement> ClassAvailabilityList;
        public List<MaxClassLevelElement> MaxClassLevelList;
        public List<ClassPowerUpStatsElement> PowerUpStats;

        public void Read(XElement element)
        {
            NextCharId = element.GetNullableIntAttribute("nextCharId");
            MaxNumChars = element.GetNullableIntAttribute("maxNumChars");

            Lat = element.GetDouble("Lat");
            Long = element.GetDouble("Long");

            SalesForce = element.GetString("SalesForce");

            Chars = element.GetList<CharElement>("Char");
            Account = element.Get<AccountElement>("Account");

            News = element.Element("News").GetList<NewsItemElement>("Item");
            Servers = element.Element("Servers").GetList<ServerElement>("Server");

            ClassAvailabilityList = element.Element("ClassAvailabilityList").GetList<ClassAvailabilityElement>("ClassAvailability");

            OwnedSkins = element.GetShortList("OwnedSkins");

            PowerUpStats = element.Element("PowerUpStats").GetList<ClassPowerUpStatsElement>("ClassStats");

            MaxClassLevelList = element.Element("MaxClassLevelList").GetList<MaxClassLevelElement>("MaxClassLevel");
        }
    }
}
