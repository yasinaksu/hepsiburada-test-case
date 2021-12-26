using Business.Abstract.PriceChangeAlgorithm;
using Business.Concrete.PriceChangeAlgorithm;
using Entities.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.PriceChangeAlgorithm
{
    [TestClass]
    public class LineerPriceDecreaseStrategyTests
    {
        IPriceDecreaseStrategy _priceDecreaseStrategy;
        [TestInitialize]
        public void Initialize()
        {
            _priceDecreaseStrategy = new LineerPriceDecreaseStrategy();
        }
        [TestMethod]
        public void DecreasePrice_ReturnMinPrice_IfCalculatedPriceLessThanMinPrice()
        {
            var priceDecreaseRequest = new PriceDecreaseRequest { CurrentPrice = 100, HourWithoutOrder = 10, MinPrice = 80 };
            var result = _priceDecreaseStrategy.DecreasePrice(priceDecreaseRequest);
            decimal expectedPrice = 80;
            Assert.AreEqual(expectedPrice, result);
        }

        [TestMethod]
        public void DecreasePrice_ReturnNewPrice_IfCalculatedPriceGreaterThanMinPrice()
        {
            var priceDecreaseRequest = new PriceDecreaseRequest { CurrentPrice = 100, HourWithoutOrder = 3, MinPrice = 80 };
            var result = _priceDecreaseStrategy.DecreasePrice(priceDecreaseRequest);
            decimal expectedPrice = 91;
            Assert.AreEqual(expectedPrice, result);
        }
    }
}
