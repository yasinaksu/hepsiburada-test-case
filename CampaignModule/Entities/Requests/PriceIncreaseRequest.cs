using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
    public class PriceIncreaseRequest
    {
        public decimal MaxPrice { get; set; }
        public int OrderCount { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
