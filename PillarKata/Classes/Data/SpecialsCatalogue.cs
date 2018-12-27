using PillarKata.Classes.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata.Classes.Data
{
    public class SpecialsCatalogue
    {
        public List<Special> Specials = new List<Special>();

        public SpecialsCatalogue()
        {
            // 3 types of specials are...
            // 1. buy n get m for x% off
            // 2. buy n get m of equal or lesser value for x% (weighted items only)
            // 3. buy n for $x

            // Special type 1
            // Buy 2 Get 1 free
            Specials.Add(new Special("bread", SpecialType.percentSpecial, 3, 1, 1.00m, 2));
            // Buy 3 Get 1 Half-off
            Specials.Add(new Special("popcorn", SpecialType.percentSpecial, 4, 1, 0.50m));

            // Special type 2
            // Buy 2 Get 1 for 10% off on weighted item
            Specials.Add(new Special("salmon", SpecialType.weightedPercentSpecial, 3, 1, 0.10m));
            // Buy 3 Get 4 for 5% off on weighted item
            Specials.Add(new Special("honey ham", SpecialType.weightedPercentSpecial, 7, 4, 0.05m));

            // Special type 3
            // Buy 10 for $15
            Specials.Add(new Special("swiss cheese", SpecialType.staticPriceSpecial, 10, 10.00m));
        }
    }
}
