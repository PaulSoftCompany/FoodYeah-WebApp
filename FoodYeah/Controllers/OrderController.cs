using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService OrderService)
        {
            _orderService = OrderService;
        }

        [HttpGet]
        public ActionResult<DataCollection<OrderDto>> GetById(int page, int take = 20)
        {
            return _orderService.GetAll(page, take);
        }

        [HttpGet("{id}")]
        public ActionResult<OrderDto> GetById(int id)
        {
            return  _orderService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateDto model)
        {
            var result =  _orderService.Create(model);

            return new JsonResult(new {Message = "Su Pedido se ha realizado correctamente",
                DetalleDeOrden = result } );
        }
    }
}
