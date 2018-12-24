using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PillarKata.Classes;

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
        public void Test0_SamepleTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void Test1_CalculateTotalPriceOfOneItem()
        {
            api.ScanItem("swiss cheese");
            Assert.AreEqual(1.69m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test2_CalculateTotalPriceOfTwoItems()
        {
            api.ScanItem("swiss cheese");
            api.ScanItem("bread");
            
            Assert.AreEqual(3.99m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test3_CalculateTotalPriceIncludingWeightedItem()
        {
            api.ScanItem("salmon", 0.5);

            Assert.AreEqual(0.75m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test4_CalculateTotalPriceWithMarkdownedItem()
        {
            api.ScanItem("popcorn");

            Assert.AreEqual(1.90m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test5_CalculateTotalPriceWithBuy2Get1Special()
        {
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test6_CalculateTotalPriceWithBuy3Get1HalfOffSpecial()
        {
            // Six popcorn scans
            api.ScanItem("popcorn");
            api.ScanItem("popcorn");
            api.ScanItem("popcorn");
            api.ScanItem("popcorn");
            api.ScanItem("popcorn");
            api.ScanItem("popcorn");

            Assert.AreEqual(10.45m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test7_CalculateTotalPriceWithLimitedSpecial()
        {
            // Nine bread scans
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");

            Assert.AreEqual(16.10m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test8_CalculateTotalPriceAfterRemovingItemFromCart()
        {
            // Nine bread scans
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");

            Assert.AreEqual(6.90m, api.CalculateTotalPrice(api.cart));

            api.RemoveItem(3);

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));

            api.RemoveItem(0);

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));
        }
    }
}
