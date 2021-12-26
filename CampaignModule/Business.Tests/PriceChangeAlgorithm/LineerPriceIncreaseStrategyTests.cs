using Business.Abstract.PriceChangeAlgorithm;
using Business.Concrete.PriceChangeAlgorithm;
using Entities.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Business.Tests.PriceChangeAlgorithm
{
    [TestClass]
    public class LineerPriceIncreaseStrategyTests
    {
        IPriceIncreaseStrategy _priceIncreaseStrategy;
        [TestInitialize]
        public void Initialize()
        {
            _priceIncreaseStrategy = new LineerPriceIncreaseStrategy();
        }
        [TestMethod]
        public void IncreasePrice_ReturnNewPrice_IfCalculatedPriceLessThanMaxPrice()
        {
            var priceIncreaseRequest = new PriceIncreaseRequest { CurrentPrice = 100, MaxPrice = 120, OrderCount = 10 };
            var result = _priceIncreaseStrategy.IncreasePrice(priceIncreaseRequest);
            decimal expectedPrice = 102;
            Assert.AreEqual(expectedPrice, result);
        }

        [TestMethod]
        public void IncreasePrice_ReturnMaxPrice_IfCalculatedPriceGreaterThanMaxPrice()
        {
            var priceIncreaseRequest = new PriceIncreaseRequest { CurrentPrice = 100, MaxPrice = 120, OrderCount = 110 };
            var result = _priceIncreaseStrategy.IncreasePrice(priceIncreaseRequest);
            decimal expectedPrice = 120;
            Assert.AreEqual(expectedPrice, result);
        }
    }
}
