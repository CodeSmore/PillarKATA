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
        CheckoutOrderTotalAPI api = new CheckoutOrderTotalAPI();

        [TestInitialize]
        public void Initialize()
        {
            api.cart.Clear();
        }

        [TestMethod()]
        public void CalculateTotalPriceOfOneItem()
        {
            api.AddToCart("swiss cheese");
            Assert.AreEqual(1.69m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void CalculateTotalPriceOfTwoItems()
        {
            api.AddToCart("swiss cheese");
            api.AddToCart("bread");
            
            Assert.AreEqual(3.99m, api.CalculateTotalPrice(api.cart));
        }
    }
}
