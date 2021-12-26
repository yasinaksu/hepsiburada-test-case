using Business.Abstract.PriceChangeAlgorithm;
using Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PriceChangeAlgorithm
{
    public class LineerPriceDecreaseStrategy : IPriceDecreaseStrategy
    {        
        public decimal DecreasePrice(PriceDecreaseRequest priceDecreaseRequest)
        {
            var newPrice = priceDecreaseRequest.CurrentPrice - priceDecreaseRequest.HourWithoutOrder * 3;
            if (priceDecreaseRequest.MinPrice < newPrice)
            {                
                return newPrice;
            }
            return priceDecreaseRequest.MinPrice;
        }
    }
}
