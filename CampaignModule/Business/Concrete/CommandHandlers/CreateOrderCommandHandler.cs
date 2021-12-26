using Business.Abstract.CommandHandler;
using Business.Abstract.Service;
using Business.Concrete.PriceChangeAlgorithm;
using Entities.Domain;
using Entities.Dtos;
using Entities.Requests;
using System;

namespace Business.Concrete.CommandHandlers
{
    public class CreateOrderCommandHandler : IObserverCommandHandler
    {
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;
        public CreateOrderCommandHandler(IOrderService orderService, IProductService productService, ICampaignService campaignService, ITimeService timeService)
        {
            _orderService = orderService;
            _productService = productService;
        }

        public void Execute(string command)
        {
            if (!command.Contains("create_order"))
            {
                return;
            }
            var orderDto = this.ParseCommand(command);
            _orderService.Add(orderDto);
            _productService.DecreaseStock(orderDto.ProductCode, orderDto.Quantity);
            _productService.IncreasePriceByDemand(orderDto.ProductCode, orderDto.Quantity);
            this.SendMessage(orderDto);
        }
        

        private OrderDto ParseCommand(string command)
        {
            var commandWords = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var orderDto = new OrderDto
            {
                ProductCode = commandWords[1],
                Quantity = Convert.ToInt32(commandWords[2])
            };
            return orderDto;
        }        

        private void SendMessage(OrderDto orderDto)
        {
            var message = $"Order created; product {orderDto.ProductCode}, quantity {orderDto.Quantity}";
            Console.WriteLine(message);
        }
    }
}
