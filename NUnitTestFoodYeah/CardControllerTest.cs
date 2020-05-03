using FoodYeah.Commons;
using FoodYeah.Controllers;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Service;
using GenFu;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace NUnitTestFoodYeah
{
    public class CardControllerTests
    {
        [Fact]
        public void GetCardTest()
        {
            //arrange
            var service = new Mock<CardService>();
            var cards = GetFakeData();
            service.Setup(x => x.GetAll(1, 20)).Returns(cards);

            var controller = new CardController(service.Object);

            //Act
            var results = controller.GetAll();//Este result en el codigo original es un IEnumerable
            //Por ende, se podría contar con Count, que es una funcion de ^, pero como no tenemos eso tenemos que usar otro metodo
            var count = results.Value.Items.Count();
            Assert.Equal(count, 20);
        }
        [Fact]
        public void GetCard()
        {
            //arrange
            var service = new Mock<CardService>();

            var cards = GetFakeData();
            var firstCard = cards.Items.First();
            service.Setup(x => x.GetById(1)).Returns(firstCard);

            var controller = new CardController(service.Object);

            //act
            var result = controller.GetById(1);
            var card = result.Value;
            //assert
            Assert.Equal(1, card.CardId);
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
