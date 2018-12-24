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
            // TODO
            // The third parameter for each special should be calculated based on ItemCatalogue price and 
            // MarkdownCatalogue rather than using static values since changes to either one would lead to
            // incorrect discounts

            // Also TODO
            // Refactor specials into 3 categories to make adding/adjusting specials easier
       

            // Special 1 Buy 2 Get 1 free
            Specials.Add(new Special("bread", 3, 2.30m, 2));

            // Special 1 Buy 5 Get 1 Half-off
            Specials.Add(new Special("popcorn", 6, 0.95m));
        }
    }
}
