using RotmgNetworkingLib.Extensions;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class CharElement : IXMLElement
    {
        public ushort ObjectType;

        public int Id;
        public int Level;
        public int Exp;
        public int CurrentFame;
        public int MaxHitPoints;
        public int HitPoints;
        public int MaxMagicPoints;
        public int MagicPoints;
        public int Attack;
        public int Defense;
        public int Speed;
        public int Dexterity;
        public int HpRegen;
        public int MpRegen;

        public int? Tex1;
        public int? Tex2;
        public int? Texture;
        public int? XpTimer;
        public int? LDTimer;
        public int? LTTimer;
        public int? HealthStackCount;
        public int? MagicStackCount;

        public bool XpBoosted;
        public bool HasBackpack;
        public bool Has3Quickslots;
        public bool Dead;

        public string CreationDate;
        public string PCStats;
        public string AccountName;

        public int[] Equipment;

        public PetElement Pet;
        public List<ItemDataElement> UniqueItemInfo;

        // ignored EquipmentQS

        public void Read(XElement element)
        {
            Id = element.GetIntAttribute("id");

            ObjectType = element.GetUShort("ObjectType");

            Tex1 = element.GetNullableInt("Tex1");
            Tex2 = element.GetNullableInt("Tex2");
            Texture = element.GetNullableInt("Texture");
            XpTimer = element.GetNullableInt("XpTimer");
            LDTimer = element.GetNullableInt("LDTimer");
            LTTimer = element.GetNullableInt("LTTimer");
            HealthStackCount = element.GetNullableInt("HealthStackCount");
            MagicStackCount = element.GetNullableInt("MagicStackCount");

            Level = element.GetInt("Level");
            Exp = element.GetInt("Exp");
            CurrentFame = element.GetInt("CurrentFame");
            MaxHitPoints = element.GetInt("MaxHitPoints");
            HitPoints = element.GetInt("HitPoints");
            MaxMagicPoints = element.GetInt("MaxMagicPoints");
            MagicPoints = element.GetInt("MagicPoints");
            Attack = element.GetInt("Attack");
            Defense = element.GetInt("Defense");
            Speed = element.GetInt("Speed");
            Dexterity = element.GetInt("Dexterity");
            HpRegen = element.GetInt("HpRegen");
            MpRegen = element.GetInt("MpRegen");

            XpBoosted = element.GetBool("XpBoosted");
            HasBackpack = element.GetBool("HasBackpack");
            Has3Quickslots = element.GetBool("Has3Quickslots");
            Dead = element.GetBool("Dead");

            CreationDate = element.GetNullableString("CreationDate");
            PCStats = element.GetString("PCStats");
            AccountName = element.Element("Account").GetString("Name");

            Equipment = element.GetIntList("Equipment");

            Pet = element.GetNullable<PetElement>("Pet");

            UniqueItemInfo = element.Element("UniqueItemInfo").GetList<ItemDataElement>("ItemData");
        }
    }
}
