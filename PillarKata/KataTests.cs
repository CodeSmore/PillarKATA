﻿using System;
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
    }
}
