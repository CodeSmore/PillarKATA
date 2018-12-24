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
        public SpecialsCatalogue specialsCatalogue = new SpecialsCatalogue();

        // GET
        public decimal CalculateTotalPrice(List<ScannedItem> cart)
        {
            decimal totalPrice = 0;

            foreach (ScannedItem item in cart)
            {
                decimal itemTotal = 0;

                itemTotal = item.Item.BasePrice;

                // Check and apply Markdown
                foreach (Markdown markdown in markdownCatalogue.Markdowns)
                {
                    if (item.Item.Name == markdown.ItemName)
                    {
                        itemTotal -= markdown.MarkdownAmount;
                    }
                }

                // Check and count Special item purchases
                foreach (Special special in specialsCatalogue.Specials)
                {
                    if (special.ItemName == item.Item.Name)
                    {
                        special.CurrentAmountInCart++;
                    }
                }

                // Check and apply weight
                if (item.WeightInLbs != 0)
                {
                    itemTotal *= (decimal)item.WeightInLbs;
                }


                totalPrice += itemTotal;
            }

            // Apply Specials
            foreach (Special special in specialsCatalogue.Specials)
            {
                var numSpecialUses = special.MaxUsesOfDiscount;
                while (special.CurrentAmountInCart >= special.RequiredPurchaseAmount)
                {
                    if (numSpecialUses > 0)
                    {
                        numSpecialUses--;
                    }
                    else if (numSpecialUses == 0)
                    {
                        break;
                    }

                    special.CurrentAmountInCart -= special.RequiredPurchaseAmount;
                    totalPrice -= special.Discount;

                }
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

        // DEL
        // Removes item from cart at supplied index
        public bool RemoveItem(int index)
        {
            if (cart.Count < index + 1 || index < 0)
            {
                return false;
            }
            else
            {
                cart.RemoveAt(index);

                return true;
            }
        }
    }
}
