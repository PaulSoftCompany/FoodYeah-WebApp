using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Service;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("warehouses")]
    public class WarehouseController : ControllerBase
    {
        private readonly WarehouseService _warehouseService;

        public WarehouseController(WarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        

        [HttpGet]
        public ActionResult<List<WarehouseProductDto>> GetAll()
        //public ActionResult<List<Warehouse>> GetAll()
        {
            return _warehouseService.GetAllWithProducts();
        }
    }
}
