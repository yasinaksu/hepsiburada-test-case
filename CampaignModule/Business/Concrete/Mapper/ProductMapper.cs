using Business.Abstract.Mapper;
using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Mapper
{
    public class ProductMapper : IProductMapper
    {
        public ProductDto MapToDto(Product product)
        {
            var productDto = new ProductDto
            {
                Price = product.Price,
                ProductCode = product.ProductCode,
                Stock = product.Stock
            };
            return productDto;
        }

        public ProductDto MapToDtoIfCampaignExist(Product product)
        {
            var productDto = new ProductDto
            {
                Price = product.PromotionalPrice,
                ProductCode = product.ProductCode,
                Stock = product.Stock
            };
            return productDto;
        }

        public Product MapToProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Price = productDto.Price,
                ProductCode = productDto.ProductCode,
                Stock = productDto.Stock
            };
            return product;
        }
    }
}
