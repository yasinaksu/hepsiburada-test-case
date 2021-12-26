using DataAccess.Abstract;
using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbContext _context;
        public ProductRepository(IDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public Product GetProductByProductCode(string productCode)
        {
            return _context.Products.FirstOrDefault(product => product.ProductCode == productCode);
        }

        public void Update(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(p => p.ProductCode == product.ProductCode);
            productToUpdate = product;
        }
    }
}
