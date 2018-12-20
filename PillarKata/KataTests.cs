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
        [TestMethod()]
        public void CalculateTotalPriceOfOneItem()
        {
            CheckoutOrderTotalAPI api = new CheckoutOrderTotalAPI();
            List<Item> cart = new List<Item>();

            Assert.AreEqual(1.69d, api.CalculateTotalPrice(cart));
        }
    }
}
