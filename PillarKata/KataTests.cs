using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PillarKata
{
    [TestClass()]
    public class KataTests
    {
        List<Item> cart;
        CheckoutOrderTotalAPI api = new CheckoutOrderTotalAPI();

        [TestInitialize]
        public void Initialize()
        {
            cart = new List<Item>();
        }

        [TestMethod()]
        public void CalculateTotalPriceOfOneItem()
        {
            
            List<Item> cart = new List<Item>();

            cart.Add(new Item(1, 1.69m));
            Assert.AreEqual(1.69m, api.CalculateTotalPrice(cart));
        }

        [TestMethod()]
        public void CalculateTotalPriceOfTwoItems()
        {
            cart.Add(new Item(1, 1.69m));
            cart.Add(new Item(2, 2.30m));
            
            Assert.AreEqual(3.99m, api.CalculateTotalPrice(cart));
        }
    }
}
