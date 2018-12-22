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
            // Special 1
            Specials.Add(new Special("bread", 3, 2.30m));
        }
    }
}
