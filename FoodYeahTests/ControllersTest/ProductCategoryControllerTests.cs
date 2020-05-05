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

namespace FoodYeahTests.ControllersTest
{

    public class Product_CategoryControllerTests
    {
        [Fact]
        public void GetAllProduct_Categorys_Test()
        {
            int numtest = 20;
            var service = new Mock<Product_CategoryService>();

            // Arrange
            var productCategories = GetFakeData(numtest);
            service.Setup(x => x.GetAll(1, numtest)).Returns(productCategories);

            //Act
            var controller = new Product_CategoryController(service.Object);
            var results = controller.GetAll();//Este result en el codigo original es un IEnumerable
                                              //Por ende, se podría contar con Count, que es una funcion de ^, pero como no tenemos eso tenemos que usar otro metodo

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(numtest, count);
        }

        [Fact]
        public void GetProduct_CategoryById_Test()
        {
            var service = new Mock<Product_CategoryService>();

            // Arrange
            var productCategories = GetFakeData(1);
            var firstProduct_Category = productCategories.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstProduct_Category);

            // Act
            var controller = new Product_CategoryController(service.Object);
            var result = controller.GetById(1);
            var card = result.Value;

            // Assert
            Assert.Equal(1, card.Product_CategoryId);
        }

        [Fact]
        public void CreateProduct_Category_Test()
        {
            var service = new Mock<Product_CategoryService>();
            var fakeProduct_Category = new Mock<Product_CategoryCreateDto>();

            // Arrange
            service.Setup(x => x.Create(fakeProduct_Category.Object))
                .Returns(new Product_CategoryDto());

            // Act
            var controller = new Product_CategoryController(service.Object);
            var result = controller.Create(fakeProduct_Category.Object);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateProduct_Category_Test()
        {
            var service = new Mock<Product_CategoryService>();
            var fakeProduct_Category = new Mock<Product_CategoryUpdateDto>();

            // Arrange
            var productCategories = GetFakeData(1);
            var firstProduct_Category = productCategories.Items.First();
            service.Setup(x => x.Update(It.IsAny<int>(), fakeProduct_Category.Object));

            // Act
            var controller = new Product_CategoryController(service.Object);
            var result = controller.Update(firstProduct_Category.Product_CategoryId, fakeProduct_Category.Object);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void RemoveProduct_Category_Test()
        {
            var service = new Mock<Product_CategoryService>();
            var fakeProduct_Category = new Mock<Product_CategoryDto>();

            // Arrange            
            service.Setup(x => x.Remove(It.IsAny<int>()));

            // Act
            var controller = new Product_CategoryController(service.Object);
            var result = controller.Remove(fakeProduct_Category.Object.Product_CategoryId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        private DataCollection<Product_CategoryDto> GetFakeData(int size)
        {
            var i = 1;
            var card = A.ListOf<Product_CategoryDto>(size);
            card.ForEach(x => x.Product_CategoryId = i++);
            DataCollection<Product_CategoryDto> toreturn = new DataCollection<Product_CategoryDto>();
            toreturn.Items = card.Select(_ => _);
            return toreturn;
        }
    }
}
