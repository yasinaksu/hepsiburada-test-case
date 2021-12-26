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
    public class PriceIncreaseContext : IPriceIncreaseContext
    {
        private readonly IPriceIncreaseStrategy _priceIncreaseStrategy;

        public PriceIncreaseContext(IPriceIncreaseStrategy priceIncreaseStrategy)
        {
            _priceIncreaseStrategy = priceIncreaseStrategy;
        }

        public decimal IncreasePrice(PriceIncreaseRequest priceIncreaseRequest)
        {
            return _priceIncreaseStrategy.IncreasePrice(priceIncreaseRequest);
        }
    }
}
