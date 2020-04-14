using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ActionResult<DataCollection<CostumerDto>> GetById(int page, int take=20)
        {
            return _costumerService.GetAll(page,take);
        }
        [HttpGet]
        public ActionResult<CostumerDto> GetById(uint id)
        {
            return _costumerService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(CostumerCreateDto costumer)
        {
            _costumerService.Create(costumer);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(uint id, CostumerUpdateDto model)
        {
            _costumerService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(uint id)
        {
            _costumerService.Remove(id);
            return NoContent();
        }
    }
}
