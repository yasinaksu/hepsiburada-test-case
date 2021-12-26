using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Domain
{
    public class Product
    {        
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public decimal PromotionalPrice { get; set; }
        public decimal MaxIncreasedPrice { get; set; }
        public decimal MinDecreasedPrice { get; set; }
    }
}
