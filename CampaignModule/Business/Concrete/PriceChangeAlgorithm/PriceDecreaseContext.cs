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
    public class PriceDecreaseContext : IPriceDecreaseContext
    {
        private readonly IPriceDecreaseStrategy _priceDecreaseStrategy;

        public PriceDecreaseContext(IPriceDecreaseStrategy priceDecreaseStrategy)
        {
            _priceDecreaseStrategy = priceDecreaseStrategy;
        }

        public decimal DecreasePrice(PriceDecreaseRequest priceDecreaseRequest)
        {
            return _priceDecreaseStrategy.DecreasePrice(priceDecreaseRequest);
        }
    }
}
