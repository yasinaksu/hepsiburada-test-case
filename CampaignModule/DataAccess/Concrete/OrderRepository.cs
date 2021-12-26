using DataAccess.Abstract;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbContext _context;
        public OrderRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Order order)
        {
            _context.Orders.Add(order);
        }
    }
}
