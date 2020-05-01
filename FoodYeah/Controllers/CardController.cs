using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("cards")]
    public class CardController : ControllerBase
    {
        private readonly CardService _CardService;

        public CardController(CardService clientService)
        {
            _CardService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<CardDto>> GetById(int page, int take=20)
        {
            return _CardService.GetAll(page,take);
        }
        [HttpGet]
        public ActionResult<CardDto> GetById(int id)
        {
            return _CardService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(CardCreateDto Card)
        {
            _CardService.Create(Card);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CardUpdateDto model)
        {
            _CardService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _CardService.Remove(id);
            return NoContent();
        }
    }
}