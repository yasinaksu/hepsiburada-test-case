using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class Order
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
