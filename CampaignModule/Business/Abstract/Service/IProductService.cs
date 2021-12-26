using Entities.Domain;
using Entities.Dtos;
using Entities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Service
{
    public interface IProductService
    {
        Result Add(ProductDto productDto);
        DataResult<ProductDto> GetProductByProductCode(string productCode);
        Result Update(ProductDto productDto);
        Result DecreaseStock(string productCode, int quantity);
        Result IncreasePriceByDemand(string productCode, int demand);
        Result UpdateProductByCampaign(CampaignDto campaignDto);
        Result DecreaseAllPromotionalProductPrice(int hour);
    }
}
