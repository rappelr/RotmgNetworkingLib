using RotmgNetworkingLib.Extensions;
using System;
using System.Xml.Linq;

namespace RotmgNetworkingLib.Api.Models
{
    public class MysteryBoxElement : IXMLElement
    {
        public int Id;
        public int Left;
        public int MaxPurchase;
        public int PurchaseLeft;
        public int Total;
        public int Slot;
        public int Rolls;
        public int BonusPoints;
        public int Weight;

        public string Title;
        public string Description;
        public string StartTime;
        public string EndTime;
        public string Tags; //unknown value type
        public string Image;
        public string Icon;

        public ushort[] DisplayedItems;

        public ushort[][] Jackpots;

        public ushort[][][] Contents;

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
            Rolls = element.GetInt("Rolls");
            BonusPoints = element.GetInt("BonusPoints");

            Description = element.GetString("Description");
            StartTime = element.GetString("StartTime");
            EndTime = element.GetString("EndTime");
            Tags = element.GetString("Tags");
            Image = element.GetString("Image");
            Icon = element.GetString("Icon");

            string[] boxes = element.GetString("Contents").Split('|');
            Contents = new ushort[boxes.Length][][];
            for(int boxIndex = 0; boxIndex < Contents.Length; boxIndex++)
            {
                string[] groups = boxes[boxIndex].Split(';');
                Contents[boxIndex] = new ushort[groups.Length][];
                for(int groupIndex = 0; groupIndex < Contents[boxIndex].Length; groupIndex++)
                    Contents[boxIndex][groupIndex] = Array.ConvertAll(groups[groupIndex].Split(','), ushort.Parse);
            }

            string[] jackpots = element.GetString("Jackpots").Split('|');
            Jackpots = new ushort[jackpots.Length][];
            for (int jackpotIndex = 0; jackpotIndex < Jackpots.Length; jackpotIndex++)
                Jackpots[jackpotIndex] = Array.ConvertAll(jackpots[jackpotIndex].Split(','), ushort.Parse);

            Price = element.Get<PriceElement>("Price");
            Sale = element.Get<SaleElement>("Sale");
        }
    }
}