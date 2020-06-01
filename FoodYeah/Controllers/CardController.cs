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
        public ActionResult<DataCollection<CardDto>> GetAll(int page = 1, int take = 20) => _CardService.GetAll(page, take);

        [HttpGet("simple")]
        public ActionResult<DataCollection<CardSimpleDto>> GetAllSimple(int page = 1, int take = 20) => _CardService.GetAllSimple(page, take);

        [HttpGet("{id}")]
        public ActionResult<CardDto> GetById(int id) => _CardService.GetById(id);

        [HttpGet("{customer/id}")]
        public ActionResult<CardDto> GetByCustomerId(int id) => _CardService.GetByCustomerId(id);

        [HttpPost]
        public ActionResult Create(CardCreateDto Card)
        {
            var result = _CardService.Create(Card);
            if (result != null)
            {
                return new JsonResult(new
                {
                    Message = "Datos de la tarjeta ingresados correctamente. ¿Desearía que la aplicación recuerde los datos de su tarjeta?",
                    TarjetaRegistrada = result
                });
            }
            else {
                 return new JsonResult(new
                {
                    Message = "Error al ingresar los datos, verifique bien si los datos que ha ingresado existen o estan correctos."
                });
            }
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