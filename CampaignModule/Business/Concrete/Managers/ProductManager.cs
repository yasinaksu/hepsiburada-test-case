using Business.Abstract.Mapper;
using Business.Abstract.Service;
using Business.Concrete.PriceChangeAlgorithm;
using DataAccess;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Entities.Requests;
using Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Managers
{
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductMapper _productMapper;
        private readonly ICampaignService _campaignService;
        private readonly ITimeService _timeService;
        private readonly IPriceIncreaseContext _priceIncreaseContext;
        private readonly IPriceDecreaseContext _priceDecreaseContext;
        public ProductManager(IProductRepository productRepository, IProductMapper productMapper, IPriceIncreaseContext priceIncreaseContext, ICampaignService campaignService, ITimeService timeService, IPriceDecreaseContext priceDecreaseContext)
        {
            _productRepository = productRepository;
            _productMapper = productMapper;
            _priceIncreaseContext = priceIncreaseContext;
            _campaignService = campaignService;
            _timeService = timeService;
            _priceDecreaseContext = priceDecreaseContext;
        }

        public Result Add(ProductDto productDto)
        {
            var product = _productMapper.MapToProduct(productDto);
            _productRepository.Add(product);
            return Result.Ok();
        }

        public Result DecreaseStock(string productCode, int quantity)
        {
            var product = _productRepository.GetProductByProductCode(productCode);
            product.Stock -= quantity;
            _productRepository.Update(product);
            return Result.Ok();
        }

        public DataResult<ProductDto> GetProductByProductCode(string productCode)
        {
            var product = _productRepository.GetProductByProductCode(productCode);
            var productDto = MappingStrategy(product);
            return DataResult<ProductDto>.Ok(productDto);
        }

        public Result IncreasePriceByDemand(string productCode, int demand)
        {
            var currentCampaign = _campaignService.GetCurrentCampaignByProductCode(productCode,_timeService.GetCurrentTime());
            if(currentCampaign != null)
            {
                var product = _productRepository.GetProductByProductCode(productCode);
                var priceIncreaseRequest = this.CreatePriceIncreaseRequest(product, demand);
                product.PromotionalPrice = _priceIncreaseContext.IncreasePrice(priceIncreaseRequest);
                _productRepository.Update(product);
            }            
            return Result.Ok();
        }

        public Result Update(ProductDto productDto)
        {
            var product = _productMapper.MapToProduct(productDto);
            _productRepository.Update(product);
            return Result.Ok();
        }
        public Result UpdateProductByCampaign(CampaignDto campaignDto)
        {
            var product = _productRepository.GetProductByProductCode(campaignDto.ProductCode);
            product.MaxIncreasedPrice = this.CalculateMaxPriceIncreasing(campaignDto.PriceManipulationLimit, product.Price);
            product.MinDecreasedPrice = this.CalculateMinPriceIncreasing(campaignDto.PriceManipulationLimit, product.Price);
            product.PromotionalPrice = product.Price;
            _productRepository.Update(product);
            return Result.Ok();
        }
        private PriceIncreaseRequest CreatePriceIncreaseRequest(Product product, int demand)
        {
            var request = new PriceIncreaseRequest
            {
                CurrentPrice = product.PromotionalPrice,
                OrderCount = demand,
                MaxPrice = product.MaxIncreasedPrice
            };
            return request;
        }

        private decimal CalculateMaxPriceIncreasing(int priceManipulationLimit, decimal price)
        {
            var maxPrice = (1.0m + (decimal)priceManipulationLimit / 100.0m) * price;
            return maxPrice;
        }

        private decimal CalculateMinPriceIncreasing(int priceManipulationLimit, decimal price)
        {
            var minPrice = (1.0m - (decimal)priceManipulationLimit / 100.0m) * price;
            return minPrice;
        }

        private ProductDto MappingStrategy(Product product)
        {
            var activeCampaign = _campaignService.GetCurrentCampaignByProductCode(product.ProductCode, _timeService.GetCurrentTime());
            if (activeCampaign != null)
            {
                return _productMapper.MapToDtoIfCampaignExist(product);
            }
            return _productMapper.MapToDto(product);
        }

        public Result DecreaseAllPromotionalProductPrice(int hour)
        {
            var activeCampaignDtos = _campaignService.GetAllCurrentCampaigns();
            foreach (var campaignDto in activeCampaignDtos)
            {
                var product = _productRepository.GetProductByProductCode(campaignDto.ProductCode);
                this.DecreasePriceByHour(product, hour);
            }
            return Result.Ok();
        }

        private void DecreasePriceByHour(Product product, int hour)
        {            
            var priceDecreaseRequest = this.CreatePriceDecreaseRequest(product, hour);
            product.PromotionalPrice = _priceDecreaseContext.DecreasePrice(priceDecreaseRequest);
            _productRepository.Update(product);
        }

        private PriceDecreaseRequest CreatePriceDecreaseRequest(Product product, int hour)
        {
            var request = new PriceDecreaseRequest
            {
                CurrentPrice = product.PromotionalPrice,
                HourWithoutOrder = hour,
                MinPrice = product.MinDecreasedPrice
            };
            return request;
        }
    }
}
