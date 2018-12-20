using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillarKata
{
    public class CheckoutOrderTotalAPI
    {
        public decimal CalculateTotalPrice(List<Item> cart)
        {
            decimal totalPrice = 0;

            foreach (Item item in cart)
            {
                totalPrice += item.BasePrice;
            }

            return totalPrice;
        }

    }
}
