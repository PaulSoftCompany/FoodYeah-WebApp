using Microsoft.AspNetCore.Mvc;
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
            return _orderService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(OrderCreateDto model)
        {
            var result = _orderService.Create(model);

            return new JsonResult(new { Message = "Su Pedido se ha realizado correctamente",
                DetalleDeOrden = result });
        }

        [HttpPut("{id}")]
        public ActionResult OrdenTerminada(int id,string status) {
            var orden = _orderService.UpdateStatus(id, status);
            if (orden.Status == "TERMINADA") return new JsonResult(new { DetalleOrden = orden });
            else return new JsonResult(new { Mensaje = "Orden en preparacion" });
        }
    }
}
