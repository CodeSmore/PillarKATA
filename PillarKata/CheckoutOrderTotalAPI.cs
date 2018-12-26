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

        // Calculates pre-tax total
        public decimal CalculateTotalPrice(List<ScannedItem> cart)
        {
            decimal totalPrice = 0;

            // reset specials count
            foreach (Special special in specialsCatalogue.Specials)
            {
                special.CurrentAmountInCart = 0;
            }

            foreach (ScannedItem item in cart)
            {
                decimal itemTotal = 0;

                itemTotal = item.Item.BasePrice;

                // Check and apply Markdown
                itemTotal = GetItemMarkdown(itemTotal, item);

                // Check and count Special item purchases
                CheckForSpecialRelatedItems(item);
                

                // Check and apply weight
                if (item.WeightInLbs != 0)
                {
                    itemTotal *= (decimal)item.WeightInLbs;
                }

                totalPrice += itemTotal;
            }

            // Apply Specials
            totalPrice = GetSpecialsPriceAdjustments(totalPrice);

            return totalPrice;
        }

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

        // -------------------------------------------------------------
        // Helper Methods for CalculateTotalPrice()
        decimal GetItemMarkdown(decimal priorItemTotal, ScannedItem item)
        {
            decimal resultingItemTotal = priorItemTotal;

            foreach (Markdown markdown in markdownCatalogue.Markdowns)
            {
                if (item.Item.Name == markdown.ItemName)
                {
                    resultingItemTotal = priorItemTotal - markdown.MarkdownAmount;
                }
            }

            return resultingItemTotal;
        }

        void CheckForSpecialRelatedItems(ScannedItem item)
        {
            foreach (Special special in specialsCatalogue.Specials)
            {
                if (special.ItemName == item.Item.Name)
                {
                    special.CurrentAmountInCart++;
                }
            }
        }

        decimal GetSpecialsPriceAdjustments(decimal priorTotalPrice)
        {
            decimal totalPrice = priorTotalPrice;

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


                    if (special.IsWeightedSpecial)
                    {
                        if (cart.Count > 1)
                        {
                            List<ScannedItem> itemsThatApplyWeightedDiscount = new List<ScannedItem>();

                            foreach (ScannedItem item in cart)
                            {
                                if (item.WeightInLbs != 0 && item.Item.Name == special.ItemName)
                                {
                                    itemsThatApplyWeightedDiscount.Add(item);
                                    //totalPrice -= special.Discount * (item.Item.BasePrice * (decimal)item.WeightInLbs);
                                    //break;
                                }
                            }

                            ScannedItem itemWithLowestPrice = null;
                            foreach (ScannedItem item in itemsThatApplyWeightedDiscount)
                            {
                                if (itemWithLowestPrice == null || itemWithLowestPrice.WeightInLbs > item.WeightInLbs)
                                {
                                    itemWithLowestPrice = item;
                                }
                            }

                            totalPrice -= special.Discount * (itemWithLowestPrice.Item.BasePrice * (decimal)itemWithLowestPrice.WeightInLbs);
                            break;
                        }
                    }
                    else
                    {
                        totalPrice -= special.Discount;
                    }
                }
            }

            return totalPrice;
        }
    }
}
