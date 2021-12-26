using Business.Abstract.Mapper;
using Business.Abstract.Service;
using Business.Concrete.Managers;
using DataAccess.Abstract;
using Entities.Domain;
using Entities.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tests.Manager
{
    [TestClass]
    public class OrderManagerTests
    {
        Mock<IOrderRepository> _mockOrderRepository;
        Mock<IOrderMapper> _mockOrderMapper;
        IOrderService _orderService;

        [TestInitialize]
        public void Initialize()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockOrderMapper = new Mock<IOrderMapper>();
            _orderService = new OrderManager(
                _mockOrderRepository.Object,
                _mockOrderMapper.Object
            );
        }

        [TestMethod]
        public void AddTest()
        {
            var orderDto = new OrderDto { ProductCode = "P1", Quantity = 10 };
            var order = new Order { ProductCode = "P1", Quantity = 10 };
            _mockOrderMapper.Setup(x => x.MapToOrder(It.IsAny<OrderDto>())).Returns(order);
            var result = _orderService.Add(orderDto);
            bool expected = true;
            Assert.AreEqual(expected, result.IsSuccess);
        }
    }
}
