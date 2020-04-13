using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Service;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {

        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<DataCollection<ClientDto>> GetById(int page, int take = 20)
        {
            return _clientService.GetAll(page, take);
        }



        [HttpGet("{id}")]
        public  ActionResult<ClientDto> GetById(int id)
        {
            return  _clientService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(ClientCreateDto client)
        {
            var result = _clientService.Create(client);

            return CreatedAtAction(
               "GetById",
               new { id = result.ClientId },
               result
           );
        }

        [HttpPut("{id}")]
        public  ActionResult Update(int id, ClientUpdateDto model)
        {
            _clientService.Update(id, model);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public  ActionResult Remove(int id)
        {
            _clientService.Remove(id);
            return NoContent();
        }
    }
}
