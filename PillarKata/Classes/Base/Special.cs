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
        public int RequiredPurchaseAmount { get; set; }
        public int CurrentAmountInCart { get; set; }
        public int MaxUsesOfDiscount { get; set; }
        public decimal Discount { get; set; }
        public bool IsWeightedSpecial { get; set; }

        public Special(string name, int requiredAmount, decimal discount, int maxUses = -1)
        {
            ItemName = name;
            RequiredPurchaseAmount = requiredAmount;
            Discount = discount;
            MaxUsesOfDiscount = maxUses;
            IsWeightedSpecial = false;
        }

        public Special(string name, int requiredAmount, float percentDiscount, int maxUses = -1)
        {
            ItemName = name;
            RequiredPurchaseAmount = requiredAmount;
            Discount = (decimal)percentDiscount;
            MaxUsesOfDiscount = maxUses;
            IsWeightedSpecial = true;
        }
    }
}
