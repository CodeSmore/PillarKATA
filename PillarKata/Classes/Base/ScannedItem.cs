using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata.Classes
{
    // An Item object that would be put into the cart
    public class ScannedItem
    {
        public Item Item { get; set; }
        public double WeightInLbs { get; set; }

        public ScannedItem(Item item, double weightInLbs = 0)
        {
            Item = new Item();

            Item.Name = item.Name;
            Item.BasePrice = item.BasePrice;

            WeightInLbs = weightInLbs;
        }
    }
}
