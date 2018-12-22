using PillarKata.Classes;
using PillarKata.Classes.Base;
using PillarKata.Classes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    public class CheckoutOrderTotalAPI
    {
        public List<ScannedItem> cart = new List<ScannedItem>();
        public ItemCatalogue itemCatalogue = new ItemCatalogue();
        public MarkdownCatalogue markdownCatalogue = new MarkdownCatalogue();

        // GET
        public decimal CalculateTotalPrice(List<ScannedItem> cart)
        {
            decimal totalPrice = 0;

            foreach (ScannedItem item in cart)
            {
                decimal itemTotal = 0;

                itemTotal = item.Item.BasePrice;

                foreach (Markdown markdown in markdownCatalogue.Markdowns)
                {
                    if (item.Item.Name == markdown.ItemName)
                    {
                        itemTotal -= markdown.MarkdownAmount;
                    }
                }

                if (item.WeightInLbs != 0)
                {
                    itemTotal *= (decimal)item.WeightInLbs;
                }


                totalPrice += itemTotal;
            }

            return totalPrice;
        }

        // POST
        public bool ScanItem(string itemName, double weightInLbs = 0)
        {
            Item catalogueResponse = itemCatalogue.GetItem(itemName);

            if (catalogueResponse == null)
            {
                return false;
            }
            else
            {
                cart.Add(new ScannedItem(catalogueResponse, weightInLbs));

                return true;
            }
        }
    }
}
