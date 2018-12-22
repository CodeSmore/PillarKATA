using PillarKata.Classes;
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
        public ItemCatalogue catalogue = new ItemCatalogue();

        // GET
        public decimal CalculateTotalPrice(List<ScannedItem> cart)
        {
            decimal totalPrice = 0;

            foreach (ScannedItem item in cart)
            {
                if (item.WeightInLbs == 0)
                {
                    totalPrice += item.Item.BasePrice;
                }
                else
                {
                    totalPrice += item.Item.BasePrice * (decimal)item.WeightInLbs;
                }
            }

            return totalPrice;
        }

        // POST
        public bool ScanItem(string itemName, double weightInLbs = 0)
        {
            Item catalogueResponse = catalogue.GetItem(itemName);

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
