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
    public class CustomerCategoryTest
    {
        [Fact]
        public void GetAllCustomerCategories_Test()
        {
            int numTests = 20;
            var service = new Mock<Customer_CategoryService>();

            //Arrange
            var customerCategories = GetFakeData(numTests);
            service.Setup(x => x.GetAll(1, numTests)).Returns(customerCategories);

            //Act
            var controller = new Customer_CategoryController(service.Object);
            var results = controller.GetAll();

            //Assert
            var count = results.Value.Items.Count();
            Assert.Equal(numTests, count);
        }

        [Fact]
        public void GetCustomerCategoryById_Test()
        {
            var service = new Mock<Customer_CategoryService>();

            //Arrange
            var customerCategories = GetFakeData(1);
            var firstCustomerCategory = customerCategories.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstCustomerCategory);

            //Act
            var controller = new Customer_CategoryController(service.Object);
            var result = controller.GetById(1);
            var customerCategory = result.Value;
            //Assert
            Assert.Equal(1, customerCategory.Customer_CategoryId);
        }

        [Fact]
        public void CreateCustomerCategory_Test()
        {
            var service = new Mock<Customer_CategoryService>();
            var fakeCustomerCategory = new Mock<Customer_CategoryCreateDto>();

            //Arrange
            service.Setup(x => x.Create(fakeCustomerCategory.Object)).Returns(new Customer_CategoryDto());

            //Act
            var controller = new Customer_CategoryController(service.Object);
            var result = controller.Create(fakeCustomerCategory.Object);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateCustomerCategory_Test()
        {
            var service = new Mock<Customer_CategoryService>();
            var fakeCustomerCategory = new Mock<Customer_CategoryUpdateDto>();

            //Arrange
            var CustomerCategories = GetFakeData(1);
            var firstCustomerCategory = CustomerCategories.Items.First();
            service.Setup(x => x.Update(It.IsAny<int>(), fakeCustomerCategory.Object));

            //Act
            var controller = new Customer_CategoryController(service.Object);
            var result = controller.Update(firstCustomerCategory.Customer_CategoryId, fakeCustomerCategory.Object);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }
        [Fact]
        public void RemoveCustomerCategory_Test()
        {
            var service = new Mock<Customer_CategoryService>();
            var fakeCustomerCategory = new Mock<Customer_CategoryDto>();

            //Arrange
            service.Setup(x => x.Remove(It.IsAny<int>()));

            //Act
            var controller = new Customer_CategoryController(service.Object);
            var result = controller.Remove(fakeCustomerCategory.Object.Customer_CategoryId);

            //Assert
            Assert.IsType<NoContentResult>(result);
        }

        private DataCollection<Customer_CategoryDto> GetFakeData(int size)
        {
            var i = 1;
            var customerCategories = A.ListOf<Customer_CategoryDto>(size);
            customerCategories.ForEach(x => x.Customer_CategoryId = i++);
            DataCollection<Customer_CategoryDto> toreturn = new DataCollection<Customer_CategoryDto>();
            toreturn.Items = customerCategories.Select(_ => _);
            return toreturn;
        }
    }
}
