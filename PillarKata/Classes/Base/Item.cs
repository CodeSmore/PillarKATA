using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    // Basic Item object that would show up in the catalogue
    public class Item
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }

        public Item()
        { }

        public Item(string name, decimal basePrice)
        {
            Name = name;
            BasePrice = basePrice;
        }
    }
}
