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

            // reset count of items that are part of a special
            foreach (Special special in specialsCatalogue.Specials)
            {
                special.CurrentAmountInCart = 0;
            }

            foreach (ScannedItem item in cart)
            {
                decimal itemTotalPrice = 0;

                itemTotalPrice = item.Item.BasePrice;

                // Check and apply Markdown
                itemTotalPrice = GetItemPriceWithMarkdown(item);

                // Check and count Special item purchases
                CheckForSpecialRelatedItems(item);
                

                // Check and apply weight
                if (item.WeightInLbs != 0)
                {
                    itemTotalPrice *= (decimal)item.WeightInLbs;
                }

                totalPrice += itemTotalPrice;
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
        decimal GetItemPriceWithMarkdown(ScannedItem item)
        {
            decimal newTotalItemPrice = item.Item.BasePrice;

            foreach (Markdown markdown in markdownCatalogue.Markdowns)
            {
                if (item.Item.Name == markdown.ItemName)
                {
                    newTotalItemPrice = item.Item.BasePrice - markdown.MarkdownAmount;
                }
            }

            return newTotalItemPrice;
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
                while (special.CurrentAmountInCart >= special.RequiredPurchaseQuantity)
                {
                    if (numSpecialUses > 0)
                    {
                        numSpecialUses--;
                    }
                    else if (numSpecialUses == 0)
                    {
                        break;
                    }

                    special.CurrentAmountInCart -= special.RequiredPurchaseQuantity;


                    if (special.SpecialType == SpecialType.staticPriceSpecial)
                    {
                        totalPrice -= GetStaticPriceSpecialAdjustment(special);
                    }
                    else if (special.SpecialType == SpecialType.weightedPercentSpecial)
                    {
                        totalPrice -= GetWeightedPercentSpecialAdjustment(special);          
                    }
                    else if (special.SpecialType == SpecialType.percentSpecial)
                    {

                        totalPrice -= GetPercentSpecialAdjustment(special);
                    }
                }
            }

            return totalPrice;
        }

        decimal GetStaticPriceSpecialAdjustment(Special special)
        {
            decimal specialPriceAdjustment = 0;
            ScannedItem itemsInCart = null;

            foreach (ScannedItem item in cart)
            {
                if (item.Item.Name == special.ItemName)
                {
                    itemsInCart = item;
                }
            }
            specialPriceAdjustment = (GetItemPriceWithMarkdown(itemsInCart) * special.RequiredPurchaseQuantity - special.StaticSpecialPrice);

            return specialPriceAdjustment;
        }

        decimal GetWeightedPercentSpecialAdjustment(Special special)
        {
            decimal specialPriceAdjustment = 0;

            if (cart.Count > 1)
            {
                List<ScannedItem> itemsThatApplyWeightedDiscount = new List<ScannedItem>();

                foreach (ScannedItem item in cart)
                {
                    if (item.WeightInLbs != 0 && item.Item.Name == special.ItemName)
                    {
                        itemsThatApplyWeightedDiscount.Add(item);
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

                specialPriceAdjustment = special.DiscountPercentage * (itemWithLowestPrice.Item.BasePrice * (decimal)itemWithLowestPrice.WeightInLbs * special.DiscountedQuantity);
                //break;
            }

            return specialPriceAdjustment;
        }

        decimal GetPercentSpecialAdjustment(Special special)
        {
            decimal specialPriceAdjustment = 0;

            foreach (ScannedItem item in cart)
            {
                if (item.Item.Name == special.ItemName)
                {
                    specialPriceAdjustment = special.DiscountPercentage * special.DiscountedQuantity * GetItemPriceWithMarkdown(item);
                    break;
                }
            }

            return specialPriceAdjustment;
        }
    }
}
