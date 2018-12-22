using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    public class Item
    {
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public double WeightInLbs { get; set; }

        public Item()
        { }

        public Item(string name, decimal basePrice, double weight = 0)
        {
            Name = name;
            BasePrice = basePrice;
            WeightInLbs = weight;
        }
    }
}
