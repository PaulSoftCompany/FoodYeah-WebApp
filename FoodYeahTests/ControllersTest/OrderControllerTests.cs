using FoodYeah.Commons;
using FoodYeah.Controllers;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Service;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace FoodYeahTest.ControllersTest
{
    public class OrderControllerTest
    {

        [Fact]
        public void GetAllOrders_Test()
        {
            int numTests = 20;
            var service = new Mock<OrderService>();

            // Arrange
            var orders = GetFakeData(numTests);
            service.Setup(x => x.GetAll(1, numTests)).Returns(orders);

            //Act
            var controller = new OrderController(service.Object);
            var results = controller.GetAll();//Este result en el codigo original es un IEnumerable
                                              //Por ende, se podría contar con Count, que es una funcion de ^, pero como no tenemos eso tenemos que usar otro metodo

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(numTests, count);
        }

        [Fact]
        public void GetOrderById_Test()
        {
            var service = new Mock<OrderService>();

            // Arrange
            var orders = GetFakeData(1);
            var firstOrder = orders.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstOrder);

            // Act
            var controller = new OrderController(service.Object);
            var result = controller.GetById(1);
            var order = result.Value;

            // Assert
            Assert.Equal(1, order.OrderId);
        }


        [Fact]
        public void CreateOrder_Test()
        {
            var service = new Mock<OrderService>();
            var fakeOrder = new Mock<OrderCreateDto>();

            // Arrange
            service.Setup(x => x.Create(fakeOrder.Object))
                .Returns(new OrderDto());

            // Act
            var controller = new OrderController(service.Object);
            var result = controller.Create(fakeOrder.Object);

            // Assert
            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void UpdateEndTime_Test()
        {
            var service = new Mock<OrderService>();
            var fakeOrder = new Mock<OrderDto>();

            // Arrange
            service.Setup(x => x.SetEndTime(fakeOrder.Object.CustomerId));

            // Act
            var controller = new OrderController(service.Object);
            var result = controller.UpdateEndTime(fakeOrder.Object.CustomerId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void GetAverageTime_Test()
        {
            var service = new Mock<OrderService>();
            var fakeOrder = new Mock<OrderDto>();

            // Arrange
            service.Setup(x => x.GetAverageTime());

            // Act
            var controller = new OrderController(service.Object);
            var result = controller.GetAverageTime();

            // Assert
            Assert.IsType<JsonResult>(result);
        }
        private DataCollection<OrderDto> GetFakeData(int size)
        {
            var i = 1;
            var order = A.ListOf<OrderDto>(size);
            order.ForEach(x => x.OrderId = i++);
            DataCollection<OrderDto> toreturn = new DataCollection<OrderDto>();
            toreturn.Items = order.Select(_ => _);
            return toreturn;
        }
    }
}
