﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    // 'Database' of available items to purchase
    public class ItemCatalogue
    {
        public List<Item> Catalogue { get; set; }


        public ItemCatalogue()
        {
            Catalogue = new List<Item>();
            Catalogue.Add(new Item("swiss cheese", 1.69m));
            Catalogue.Add(new Item("bread", 2.30m));
            Catalogue.Add(new Item("salmon", 1.50m));
        }

        public Item GetItem(string name)
        {
            foreach (Item item in Catalogue)
            {
                if (name == item.Name)
                {
                    return item;
                }
            }

            return null;
        }
    }
}
