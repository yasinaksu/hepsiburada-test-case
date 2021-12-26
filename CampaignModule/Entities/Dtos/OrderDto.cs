using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class OrderDto
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
