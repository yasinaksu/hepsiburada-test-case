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
    public interface IPriceIncreaseContext
    {
        decimal IncreasePrice(PriceIncreaseRequest priceIncreaseRequest);
    }
}
