using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.CommandHandlers
{
    public class CreateProductCommandHandler : IObserverCommandHandler
    {
        private readonly IProductService _productService;
        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("create_product"))
            {
                return;
            }
            var productDto = this.ParseCommand(command);
            _productService.Add(productDto);
            var message = $"Product created; code {productDto.ProductCode}, price {productDto.Price.ToString("0")}, stock {productDto.Stock}";
            Console.WriteLine(message);
        }

        private ProductDto ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var productDto = new ProductDto
            {
                ProductCode = commandWords[1],
                Price = Convert.ToDecimal(commandWords[2]),
                Stock = Convert.ToInt32(commandWords[3])
            };
            return productDto;
        }
    }
}
