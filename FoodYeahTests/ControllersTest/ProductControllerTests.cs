using FoodYeah.Commons;
using FoodYeah.Controllers;
using FoodYeah.Dto;
using FoodYeah.Service;
using GenFu;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using Xunit;

namespace FoodYeahTests.ControllersTest
{
    public class ProductControllerTests
    {
        [Fact]
        public void GetAllProducts_Test()
        {
            var service = new Mock<ProductService>();

            // Arrange
            var products = GetFakeData();
            service.Setup(x => x.GetAll(1, 20)).Returns(products);

            //Act
            var controller = new ProductController(service.Object);
            var results = controller.GetAll();//Este result en el codigo original es un IEnumerable
                                              //Por ende, se podría contar con Count, que es una funcion de ^, pero como no tenemos eso tenemos que usar otro metodo

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(20, count);
        }

        [Fact]
        public void GetProductById_Test()
        {
            var service = new Mock<ProductService>();

            // Arrange
            var products = GetFakeData();
            var firstProduct = products.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstProduct);

            // Act
            var controller = new ProductController(service.Object);
            var result = controller.GetById(1);
            var product = result.Value;

            // Assert
            Assert.Equal(1, product.ProductId);
        }
        [Fact]
        public void GetProductByDay_Test()
        {
            var service = new Mock<ProductService>();

            // Arrange
            var products = GetFakeData();
            service.Setup(x => x.GetByDay(Enums.DaySold.Lunes,1,20)).Returns(products);

            // Act
            var controller = new ProductController(service.Object);
            var results = controller.GetByDay(Enums.DaySold.Lunes, 1, 20);

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(20, count);
        }

        [Fact]
        public void GetProductByWeek_Test()
        {
            var service = new Mock<ProductService>();

            // Arrange
            var products = GetFakeData();
            service.Setup(x => x.GetByWeek(1, 20)).Returns(products);

            // Act
            var controller = new ProductController(service.Object);
            var results = controller.GetByWeek(1, 20);

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(20, count);
        }
        [Fact]
        public void CreateProduct_Test()
        {
            var service = new Mock<ProductService>();
            var fakeProduct = new Mock<ProductCreateDto>();

            // Arrange
            var products = GetFakeData();
            service.Setup(x => x.Create(fakeProduct.Object)).Returns(new ProductDto());

            // Act
            var controller = new ProductController(service.Object);
            var result = controller.Create(fakeProduct.Object);
            // Assert
            Assert.IsType<CreatedAtActionResult>(result);
        }

        [Fact]
        public void UpdateProduct_Test()
        {
            var service = new Mock<ProductService>();
            var fakeProduct = new Mock<ProductUpdateDto>();

            // Arrange
            var products = GetFakeData();
            var firstProduct = products.Items.First();
            service.Setup(x => x.Update(It.IsAny<int>(), fakeProduct.Object));

            // Act
            var controller = new ProductController(service.Object);
            var result = controller.Update(firstProduct.ProductId, fakeProduct.Object);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void RemoveProduct_Test()
        {
            var service = new Mock<ProductService>();
            var fakeProduct = new Mock<ProductDto>();

            // Arrange            
            service.Setup(x => x.Remove(It.IsAny<int>()));

            // Act
            var controller = new ProductController(service.Object);
            var result = controller.Remove(fakeProduct.Object.ProductId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        private DataCollection<ProductDto> GetFakeData()
        {
            var i = 1;
            var product = A.ListOf<ProductDto>(20);
            product.ForEach(x => x.ProductId = i++);
            DataCollection<ProductDto> toreturn = new DataCollection<ProductDto>();
            toreturn.Items = product.Select(_ => _);
            return toreturn;
        }
    }
}
