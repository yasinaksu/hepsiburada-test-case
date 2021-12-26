using Business.Abstract.Mapper;
using Business.Abstract.Service;
using Business.Concrete.Managers;
using Business.Concrete.PriceChangeAlgorithm;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Entities.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Business.Tests.Manager
{
    [TestClass]
    public class ProductManagerTests
    {
        Mock<IProductRepository> _productRepository;
        Mock<IProductMapper> _productMapper;
        Mock<IPriceIncreaseContext> _priceIncreaseContext;
        Mock<ICampaignService> _campaignService;
        Mock<ITimeService> _timeService;
        Mock<IPriceDecreaseContext> _priceDecreaseContext;
        IProductService _productService;

        [TestInitialize]
        public void Initialize()
        {
            _productRepository = new Mock<IProductRepository>();
            _productMapper = new Mock<IProductMapper>();
            _priceIncreaseContext = new Mock<IPriceIncreaseContext>();
            _campaignService = new Mock<ICampaignService>();
            _timeService = new Mock<ITimeService>();
            _priceDecreaseContext = new Mock<IPriceDecreaseContext>();
            _productService = new ProductManager(
                _productRepository.Object,
                _productMapper.Object,
                _priceIncreaseContext.Object,
                _campaignService.Object,
                _timeService.Object,
                _priceDecreaseContext.Object);
        }
        [TestMethod]
        public void AddTest()
        {
            var productDto = new ProductDto { Price = 100, ProductCode = "P1", Stock = 1000 };

            var result = _productService.Add(productDto);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void GetProductByProductCodeTest()
        {
            var productCode = "P1";
            var productDto = new ProductDto { Price = 100, ProductCode = "P1", Stock = 1000 };
            var product = new Product { Price = 100, ProductCode = "P1", Stock = 1000 };
            _productRepository.Setup(x => x.GetProductByProductCode(It.IsAny<string>())).Returns(product);
            _productMapper.Setup(x => x.MapToDto(It.IsAny<Product>())).Returns(productDto);
            var result = _productService.GetProductByProductCode(productCode);
            var expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var productDto = new ProductDto { Price = 100, ProductCode = "P1", Stock = 1000 };

            var result = _productService.Update(productDto);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void DecreaseStockTest()
        {
            var productCode = "P1";
            var quantity = 10;
            var product = new Product { Price = 100, ProductCode = "P1", Stock = 1000 };
            _productRepository.Setup(x => x.GetProductByProductCode(It.IsAny<string>())).Returns(product);

            var result = _productService.DecreaseStock(productCode, quantity);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void IncreasePriceByDemandTest()
        {
            var productCode = "P1";
            var quantity = 10;
            var product = new Product { Price = 100, ProductCode = "P1", Stock = 1000 };
            _productRepository.Setup(x => x.GetProductByProductCode(It.IsAny<string>())).Returns(product);
            _priceIncreaseContext.Setup(x => x.IncreasePrice(It.IsAny<PriceIncreaseRequest>())).Returns(80);
            var result = _productService.IncreasePriceByDemand(productCode, quantity);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void UpdateProductByCampaignTest()
        {
            var currentTime = DateTime.Now;
            var campaignDto = new CampaignDto
            {
                Duration = 10,
                EndTime = currentTime.AddHours(10),
                IsActive = true,
                Name = "C1",
                PriceManipulationLimit = 10,
                ProductCode = "P1",
                StartTime = currentTime,
                TargetSalesCount = 100
            };
            var product = new Product { Price = 100, ProductCode = "P1", Stock = 1000 };
            _productRepository.Setup(x => x.GetProductByProductCode(It.IsAny<string>())).Returns(product);
            var result = _productService.UpdateProductByCampaign(campaignDto);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }

        [TestMethod]
        public void DecreaseAllPromotionalProductPriceTest()
        {
            
            var campaignDtoList = new List<CampaignDto>();
            _campaignService.Setup(x => x.GetAllCurrentCampaigns()).Returns(campaignDtoList);
            var product = new Product { Price = 100, ProductCode = "P1", Stock = 1000 };
            _productRepository.Setup(x => x.GetProductByProductCode(It.IsAny<string>())).Returns(product);
            var hour = 3;
            var result = _productService.DecreaseAllPromotionalProductPrice(hour);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }
    }
}
