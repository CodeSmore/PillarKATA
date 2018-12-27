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
        public void Test00_SamepleTest()
        {
            Assert.AreEqual(true, true);
        }

        [TestMethod()]
        public void Test01_CalculateTotalPriceOfOneItem()
        {
            api.ScanItem("swiss cheese");
            Assert.AreEqual(1.69m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test02_CalculateTotalPriceOfTwoItems()
        {
            api.ScanItem("swiss cheese");
            api.ScanItem("bread");

            Assert.AreEqual(3.99m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test03_CalculateTotalPriceIncludingWeightedItem()
        {
            api.ScanItem("salmon", 0.5);

            Assert.AreEqual(0.75m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test04_CalculateTotalPriceWithMarkdownedItem()
        {
            api.ScanItem("popcorn");

            Assert.AreEqual(1.90m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test05_CalculateTotalPriceWithBuy2Get1Special()
        {
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test06_CalculateTotalPriceWithBuy3Get1HalfOffSpecialOnItemWithMarkdown()
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
        public void Test07_CalculateTotalPriceWithLimitedSpecial()
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
        public void Test08_CalculateTotalPriceAfterRemovingItemFromCart()
        {
            // Four bread scans
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");
            api.ScanItem("bread");

            Assert.AreEqual(6.90m, api.CalculateTotalPrice(api.cart));

            // The following tests verify that the special on purchasing bread is applied/removed correctly after each
            // removal from the cart
            api.RemoveItem(3);

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));

            api.RemoveItem(0);

            Assert.AreEqual(4.60m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test09_CalculateTotalPriceWith_Buy2Get1OfEqualOrLesserValueFor10PercentOff_Special()
        {
            api.ScanItem("salmon", 2);
            api.ScanItem("salmon", 3);
            api.ScanItem("salmon", 2);

            Assert.AreEqual(10.20m, api.CalculateTotalPrice(api.cart));

            api.cart.Clear();

            api.ScanItem("salmon", 3);
            api.ScanItem("salmon", 2);
            api.ScanItem("salmon", 2);

            Assert.AreEqual(10.20m, api.CalculateTotalPrice(api.cart));

            api.cart.Clear();

            api.ScanItem("salmon", 2);
            api.ScanItem("salmon", 2);
            api.ScanItem("salmon", 3);

            Assert.AreEqual(10.20m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test10_CalculateTotalPriceWith_BuyNGetMOfEqualOrLesserValueForXPercentOff_Special()
        {
            // Seven honey ham scans
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);
            api.ScanItem("honey ham", 1);

            Assert.AreEqual(47.60m, api.CalculateTotalPrice(api.cart));
        }

        [TestMethod()]
        public void Test11_CalculateTotalPriceWith_BuyNForXDollars_Special()
        {
            // Ten swiss cheese scans
            for (int i = 0; i < 10; ++i)
            {
                api.ScanItem("swiss cheese");
            }

            Assert.AreEqual(10.00m, api.CalculateTotalPrice(api.cart));
        }
    }
}
