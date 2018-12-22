﻿using System;
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
        public decimal Discount { get; set; }

        public Special(string name, int requiredAmount, decimal discount)
        {
            ItemName = name;
            RequiredPurchaseAmount = requiredAmount;
            Discount = discount;
        }
    }
}
