using RotmgNetworkingLib.Extensions;
using RotmgNetworkingLib.Models;
using System.Collections.Generic;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class AccountElement : IXMLElement
    {

        public int Credits;
        public int FortuneToken;
        public int UnityCampaignPoints;
        public int NextCharSlotPrice;
        public int EarlyGameEventTracker;
        public int MaxNumChars;
        public int TeleportWait;
        public int PetYardType;
        public int ForgeFireEnergy;
        public int BestCharFame;
        public int Fame;
        public int TotalFame;

        public int? AccessTokenTimestamp;
        public int? AccessTokenExpiration;
        public int? ArenaTickets;

        public long AccountId;

        public string Name;
        public string PaymentProvider;
        public string Originating;
        public string LastServer;
        public string AccessToken;

        public bool NameChosen;
        public bool IsAgeVerified;
        public bool VerifiedEmail;
        public bool HasGifts;

        public ushort[] ForgeFireBlueprints, Gifts;

        public int[] Potions;

        public GuildElement Guild;
        public SecurityQuestionsElement SecurityQuestions;
        public List<ClassStatsElement> ClassStats;
        public UniqueItemInfoElement UniqueItemInfo;
        public VaultElement Vault;

        // ignored campaign

        public void Read(XElement element)
        {
            Credits = element.GetInt("Credits");
            FortuneToken = element.GetInt("FortuneToken");
            UnityCampaignPoints = element.GetInt("UnityCampaignPoints");
            NextCharSlotPrice = element.GetInt("NextCharSlotPrice");
            EarlyGameEventTracker = element.GetInt("EarlyGameEventTracker");
            MaxNumChars = element.GetInt("MaxNumChars");
            TeleportWait = element.GetInt("TeleportWait");
            PetYardType = element.GetInt("PetYardType");
            ForgeFireEnergy = element.GetInt("ForgeFireEnergy");

            AccessTokenTimestamp = element.GetNullableInt("AccessTokenTimestamp");
            AccessTokenExpiration = element.GetNullableInt("AccessTokenExpiration");
            ArenaTickets = element.GetNullableInt("ArenaTickets");

            AccountId = element.GetLong("AccountId");

            Name = element.GetString("Name");
            PaymentProvider = element.GetString("PaymentProvider");
            Originating = element.GetString("Originating");

            AccessToken = element.GetNullableString("AccessToken");
            LastServer = element.GetNullableString("LastServer");

            IsAgeVerified = element.GetBool("IsAgeVerified");

            NameChosen = element.GetFlag("NameChosen");
            VerifiedEmail = element.GetFlag("VerifiedEmail");
            HasGifts = element.GetFlag("HasGifts");

            ForgeFireBlueprints = element.GetUShortList("ForgeFireBlueprints");

            Gifts = element.Element("Gifts") != null ? element.GetUShortList("Gifts") : null;

            Potions = element.Element("Potions") != null ? element.GetIntList("Potions") : null;

            Guild = element.GetNullable<GuildElement>("Guild");

            Vault = element.GetNullable<VaultElement>("Vault");

            SecurityQuestions = element.Get<SecurityQuestionsElement>("SecurityQuestions");

            UniqueItemInfo = element.GetNullable<UniqueItemInfoElement>("UniqueItemInfo");

            XElement stats = element.Element("Stats");

            ClassStats = stats.GetList<ClassStatsElement>("ClassStats");
            BestCharFame = stats.GetInt("BestCharFame");
            TotalFame = stats.GetInt("TotalFame");
            Fame = stats.GetInt("Fame");
        }

        public int CalculateStarCount()
        {
            if (ClassStats == null || ClassStats.Count == 0)
                return 0;

            int result = 0;

            foreach(ClassStatsElement classStat in ClassStats)
            {
                if (classStat.BestBaseFame >= 15000)
                    result += 5;
                else if (classStat.BestBaseFame >= 5000)
                    result += 4;
                else if (classStat.BestBaseFame >= 1500)
                    result += 3;
                else if (classStat.BestBaseFame >= 500)
                    result += 2;
                else if (classStat.BestBaseFame >= 20)
                    result += 1;
            }

            return result;
        }

        public AccessToken ParseAccessToken() => AccessToken != null ? new AccessToken()
        {
            Value = AccessToken,
            Expiry = AccessTokenExpiration.Value,
            Timestamp = AccessTokenTimestamp.Value
        } : throw new RotmgNetworkingException("Access token not included in model");
    }
}
