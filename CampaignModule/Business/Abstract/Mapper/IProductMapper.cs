using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Mapper
{
    public interface IProductMapper
    {
        ProductDto MapToDto(Product product);
        Product MapToProduct(ProductDto productDto);
        ProductDto MapToDtoIfCampaignExist(Product product);
    }
}
