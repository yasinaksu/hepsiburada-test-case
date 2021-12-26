using Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetProductByProductCode(string productCode);
        void Update(Product product);
    }
}
