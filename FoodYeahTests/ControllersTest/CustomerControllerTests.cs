using FoodYeah.Commons;
using FoodYeah.Controllers;
using FoodYeah.Dto;
using FoodYeah.Service;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

namespace FoodYeahTest.ControllersTest
{
    public class CustomerControllerTest
    {
        [Fact]
        public void GetAllCustomers_Test()
        {
            int numtests = 20;
            var service = new Mock<CustomerService>();

            //Arrange
            var customers = GetFakeData(numtests);
            service.Setup(x => x.GetAll(1, numtests)).Returns(customers);

            //Act
            var controller = new CustomerController(service.Object);
            var results = controller.GetAll();

            //Assert
            var count = results.Value.Items.Count();
            Assert.Equal(numtests, count);
        }
        [Fact]
        public void GetCustomerById_Test()
        {
            var service = new Mock<CustomerService>();
            //Arrange
            var customers = GetFakeData(1);
            var firstcustomer = customers.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstcustomer);

            //Act
            var controller = new CustomerController(service.Object);
            var result = controller.GetById(1);
            var customer = result.Value;

            //Assert
            Assert.Equal(1, customer.CustomerId);
        }
        [Fact]
        public void CreateCustomer_Test()
        {
            var service = new Mock<CustomerService>();
            var fakeCustomer = new Mock<CustomerCreateDto>();

            //Arrange
            service.Setup(x => x.Create(fakeCustomer.Object))
                .Returns(new CustomerDto());
            //Act 
            var controller = new CustomerController(service.Object);
            var result = controller.Create(fakeCustomer.Object);

            //Assert
            Assert.IsType<OkResult>(result);
        }
        [Fact]
        public void UpdateCustomer_Test()
        {
            var service = new Mock<CustomerService>();
            var fakeCustomer = new Mock<CustomerUpdateDto>();

            // Arrange
            var customers = GetFakeData(1);
            var firstcustomer = customers.Items.First();
            service.Setup(x => x.Update(It.IsAny<int>(), fakeCustomer.Object));

            // Act
            var controller = new CustomerController(service.Object);
            var result = controller.Update(firstcustomer.CustomerId, fakeCustomer.Object);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void RemoveCustomer_Test()
        {
            var service = new Mock<CustomerService>();
            var fakeCustomer = new Mock<CustomerDto>();

            // Arrange            
            service.Setup(x => x.Remove(It.IsAny<int>()));

            // Act
            var controller = new CustomerController(service.Object);
            var result = controller.Remove(fakeCustomer.Object.CustomerId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
        private DataCollection<CustomerDto> GetFakeData(int size)
        {
            int i = 1;
            var customers = A.ListOf<CustomerDto>(size);
            customers.ForEach(x => x.CustomerId = i++);
            DataCollection<CustomerDto> toreturn = new DataCollection<CustomerDto>();
            toreturn.Items = customers.Select(_ => _);
            return toreturn;
        }
    }
}
