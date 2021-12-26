using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DbContext : IDbContext
    {        
        public DbContext()
        {
            Products = new List<Product>();
            Orders = new List<Order>();
            Campaigns = new List<Campaign>();
        }
        public List<Product> Products { get; private set; }
        public List<Order> Orders { get; private set; }
        public List<Campaign> Campaigns { get; private set; }
    }
}
