using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    public class CheckoutOrderTotalAPI
    {
        public List<Item> cart = new List<Item>();
        public ItemCatalogue catalogue = new ItemCatalogue();

        // GET
        public decimal CalculateTotalPrice(List<Item> cart)
        {
            decimal totalPrice = 0;

            foreach (Item item in cart)
            {
                totalPrice += item.BasePrice;
            }

            return totalPrice;
        }

        // POST
        public bool AddToCart(string itemName)
        {
            Item catalogueResponse = catalogue.GetItem(itemName);

            if (catalogueResponse == null)
            {
                return false;
            }
            else {
                cart.Add(catalogue.GetItem(itemName));

                return true;
            }
        }

    }
}
