using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("costumers")]
    public class CostumerController : ControllerBase
    {
        private readonly CostumerService _costumerService;

        public CostumerController(CostumerService clientService)
        {
            _costumerService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<CostumerDto>> GetAll(int page=1, int take=20) => _costumerService.GetAll(page,take);
        [HttpGet("{id}")]
        public ActionResult<CostumerDto> GetById(int id) => _costumerService.GetById(id);

        [HttpPost]
        public ActionResult Create(CostumerCreateDto costumer)
        {
            _costumerService.Create(costumer);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CostumerUpdateDto model)
        {
            _costumerService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _costumerService.Remove(id);
            return NoContent();
        }
    }
}
