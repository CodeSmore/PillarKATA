using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    public class Item
    {
        public int Id { get; set; }
        public decimal BasePrice { get; set; }

        public Item()
        { }

        public Item(int id, decimal basePrice)
        {
            Id = id;
            BasePrice = basePrice;
        }
    }
}
