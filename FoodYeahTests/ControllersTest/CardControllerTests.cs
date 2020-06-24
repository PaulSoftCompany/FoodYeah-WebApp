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
    public class CardControllerTests
    {
        [Fact]
        public void GetAllCards_Test()
        {
            var service = new Mock<CardService>();

            // Arrange
            var cards = GetFakeData();
            service.Setup(x => x.GetAll(1, 20)).Returns(cards);

            //Act
            var controller = new CardController(service.Object);
            var results = controller.GetAll();//Este result en el codigo original es un IEnumerable
                                              //Por ende, se podría contar con Count, que es una funcion de ^, pero como no tenemos eso tenemos que usar otro metodo

            // Assert
            var count = results.Value.Items.Count();
            Assert.Equal(20, count);
        }

        [Fact]
        public void GetCardById_Test()
        {
            var service = new Mock<CardService>();

            // Arrange
            var cards = GetFakeData();
            var firstCard = cards.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstCard);

            // Act
            var controller = new CardController(service.Object);
            var result = controller.GetById(1);
            var card = result.Value;

            // Assert
            Assert.Equal(1, card.CardId);
        }

        [Fact]
        public void CreateCard_Test()
        {
            var service = new Mock<CardService>();
            var fakeCard = new Mock<CardCreateDto>();

            // Arrange
            service.Setup(x => x.Create(fakeCard.Object))
                .Returns(new CardDto());

            // Act
            var controller = new CardController(service.Object);
            var result = controller.Create(fakeCard.Object);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void UpdateCard_Test()
        {
            var service = new Mock<CardService>();
            var fakeCard = new Mock<CardUpdateDto>();

            // Arrange
            var cards = GetFakeData();
            var firstCard = cards.Items.First();
            service.Setup(x => x.Update(It.IsAny<int>(), fakeCard.Object));

            // Act
            var controller = new CardController(service.Object);
            var result = controller.Update(firstCard.CardId, fakeCard.Object);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void RemoveCard_Test()
        {
            var service = new Mock<CardService>();
            var fakeCard = new Mock<CardDto>();

            // Arrange            
            service.Setup(x => x.Remove(It.IsAny<int>()));

            // Act
            var controller = new CardController(service.Object);
            var result = controller.Remove(fakeCard.Object.CardId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        private DataCollection<CardDto> GetFakeData()
        {
            var i = 1;
            var card = A.ListOf<CardDto>(20);
            card.ForEach(x => x.CardId = i++);
            DataCollection<CardDto> toreturn = new DataCollection<CardDto>();
            toreturn.Items = card.Select(_ => _);
            return toreturn;
        }
    }
}
