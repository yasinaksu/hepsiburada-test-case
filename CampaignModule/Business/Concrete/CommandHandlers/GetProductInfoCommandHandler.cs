using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommandHandlers
{
    public class GetProductInfoCommandHandler : IObserverCommandHandler
    {
        private readonly IProductService _productService;
        public GetProductInfoCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("get_product_info"))
            {
                return;
            }
            var productCode = this.ParseCommand(command);
            var product = _productService.GetProductByProductCode(productCode).Body;
            var message = $"Product {product.ProductCode} info; price {product.Price.ToString("0")}, stock {product.Stock}";
            Console.WriteLine(message);
        }

        private string ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var productCode = commandWords[1];
            return productCode;
        }
    }
}
