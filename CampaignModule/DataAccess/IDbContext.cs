using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDbContext
    {
        List<Product> Products { get; }
        List<Order> Orders { get; }
        List<Campaign> Campaigns { get; }
    }
}
