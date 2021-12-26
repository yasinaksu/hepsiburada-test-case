using Entities.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.PriceChangeAlgorithm
{
    public interface IPriceDecreaseStrategy
    {
        decimal DecreasePrice(PriceDecreaseRequest priceDecreaseRequest);
    }
}
