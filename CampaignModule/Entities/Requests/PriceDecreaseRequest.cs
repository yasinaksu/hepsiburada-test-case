using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Requests
{
    public class PriceDecreaseRequest
    {
        public decimal MinPrice { get; set; }
        public int HourWithoutOrder { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
