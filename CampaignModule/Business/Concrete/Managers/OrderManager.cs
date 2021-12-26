using Business.Abstract.Mapper;
using Business.Abstract.Service;
using DataAccess;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Entities.Results;

namespace Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderMapper _orderMapper;
        public OrderManager(IOrderRepository orderRepository, IOrderMapper orderMapper)
        {
            _orderRepository = orderRepository;
            _orderMapper = orderMapper;
        }

        public Result Add(OrderDto orderDto)
        {
            var order = _orderMapper.MapToOrder(orderDto);
            _orderRepository.Add(order);
            return Result.Ok();
        }
    }
}
