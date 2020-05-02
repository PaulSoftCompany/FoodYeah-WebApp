using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [Route("costumer_categories")]
    [ApiController]
    public class Costumer_CategoryController : ControllerBase
    {
        private readonly Costumer_CategoryService _Costumer_CategoryService;

        public Costumer_CategoryController(Costumer_CategoryService clientService)
        {
            _Costumer_CategoryService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<Costumer_CategoryDto>> GetAll(int page=1, int take = 20) => _Costumer_CategoryService.GetAll(page, take);
        [HttpGet("{id}")]
        public ActionResult<Costumer_CategoryDto> GetById(int id) => _Costumer_CategoryService.GetById(id);
        [HttpPost]
        public ActionResult Create(Costumer_CategoryCreateDto Costumer_Category)
        {
            _Costumer_CategoryService.Create(Costumer_Category);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Costumer_CategoryUpdateDto model)
        {
            _Costumer_CategoryService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _Costumer_CategoryService.Remove(id);
            return NoContent();
        }
    }
}