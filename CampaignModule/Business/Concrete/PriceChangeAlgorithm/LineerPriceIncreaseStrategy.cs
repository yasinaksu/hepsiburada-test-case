using Business.Abstract.PriceChangeAlgorithm;
using Entities.Domain;
using Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.PriceChangeAlgorithm
{
    public class LineerPriceIncreaseStrategy : IPriceIncreaseStrategy
    {
        public decimal IncreasePrice(PriceIncreaseRequest priceIncreaseRequest)
        {            
            var newPrice = priceIncreaseRequest.CurrentPrice + priceIncreaseRequest.OrderCount * (0.2m);
            if (priceIncreaseRequest.MaxPrice > newPrice)
            {
                return newPrice;
            }            
            return priceIncreaseRequest.MaxPrice;
        }
    }
}
