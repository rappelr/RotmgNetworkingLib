using RotmgNetworkingLib.Extensions;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class PackageElement : IXMLElement
    {
        public int Id;
        public int Left;
        public int MaxPurchase;
        public int PurchaseLeft;
        public int Total;
        public int Slot;
        public int CharSlot;
        public int VaultSlot;
        public int Gold;
        public int BonusPoints;
        public int Weight;

        public bool ShowOnLogin;

        public string Title;
        public string Description;
        public string StartTime;
        public string EndTime;
        public string Tags; //unknown value type
        public string Image;
        public string PopupImage;

        public ushort[] Contents;

        public PriceElement Price;

        public SaleElement Sale;

        public void Read(XElement element)
        {
            Id = element.GetIntAttribute("id");
            Weight = element.GetIntAttribute("weight");

            Title = element.GetStringAttribute("title");

            Left = element.GetInt("Left");
            MaxPurchase = element.GetInt("MaxPurchase");
            PurchaseLeft = element.GetInt("PurchaseLeft");
            Total = element.GetInt("Total");
            Slot = element.GetInt("Slot");
            CharSlot = element.GetInt("CharSlot");
            VaultSlot = element.GetInt("VaultSlot");
            Gold = element.GetInt("Gold");
            BonusPoints = element.GetInt("BonusPoints");

            ShowOnLogin = element.GetBool("ShowOnLogin");

            Description = element.GetString("Description");
            StartTime = element.GetString("StartTime");
            EndTime = element.GetString("EndTime");
            Tags = element.GetString("Tags");
            Image = element.GetString("Image");
            PopupImage = element.GetString("PopupImage");

            Contents = element.GetUShortList("Contents");

            Price = element.Get<PriceElement>("Price");
            Sale = element.Get<SaleElement>("Sale");
        }
    }
}
