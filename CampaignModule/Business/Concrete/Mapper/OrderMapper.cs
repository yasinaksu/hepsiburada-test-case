using Business.Abstract.Mapper;
using Entities.Domain;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.Mapper
{
    public class OrderMapper : IOrderMapper
    {
        public OrderDto MapToDto(Order order)
        {
            var orderDto = new OrderDto
            {
                ProductCode = order.ProductCode,
                Quantity = order.Quantity
            };
            return orderDto;
        }

        public Order MapToOrder(OrderDto orderDto)
        {
            var order = new Order
            {
                ProductCode = orderDto.ProductCode,
                Quantity = orderDto.Quantity
            };
            return order;
        }
    }
}
