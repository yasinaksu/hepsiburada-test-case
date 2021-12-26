using Entities.Dtos;
using Entities.Results;

namespace Business.Abstract.Service
{
    public interface IOrderService
    {
        Result Add(OrderDto orderDto);
    }
}
