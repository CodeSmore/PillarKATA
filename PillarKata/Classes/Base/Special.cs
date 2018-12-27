using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata.Classes.Base
{
    public class Special
    {
        public string ItemName { get; set; }
        public int RequiredPurchaseQuantity { get; set; }
        public int DiscountedQuantity { get; set; }
        public int CurrentAmountInCart { get; set; }
        public int MaxUsesOfDiscount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public bool IsWeightedSpecial { get; set; }

        public SpecialType SpecialType { get; set; }
        public decimal StaticSpecialPrice { get; set; } 

        public Special(string name, int requiredQuantity, int discountedQuantity, decimal discountPercentage, bool isWeightedSpecial = false, int maxUses = -1)
        {
            ItemName = name;
            RequiredPurchaseQuantity = requiredQuantity;
            DiscountedQuantity = discountedQuantity;
            DiscountPercentage = discountPercentage;
            MaxUsesOfDiscount = maxUses;
            IsWeightedSpecial = isWeightedSpecial;
        }

        public Special(string name, int requiredQuantity, SpecialType specialType, decimal staticSpecialPrice, int maxUses = -1)
        {
            ItemName = name;
            RequiredPurchaseQuantity = requiredQuantity;
            MaxUsesOfDiscount = maxUses;
            SpecialType = specialType;
            StaticSpecialPrice = staticSpecialPrice;
        }
    }

    public enum SpecialType
    {
        percentSpecial,
        weightedPercentSpecial,
        staticPriceSpecial
    };
}
