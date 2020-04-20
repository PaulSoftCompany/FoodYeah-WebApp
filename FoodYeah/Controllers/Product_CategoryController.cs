using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodYeah.Controllers
{
    [Route("product_categories")]
    [ApiController]
    public class Product_CategoryController : ControllerBase
    {
        private readonly Product_CategoryService _Product_CategoryService;

        public Product_CategoryController(Product_CategoryService clientService)
        {
            _Product_CategoryService = clientService;
        }
        [HttpGet]
        public ActionResult<DataCollection<Product_CategoryDto>> GetAll(int page, int take = 20) {
            return _Product_CategoryService.GetAll(page,take);
        }
        [HttpGet("{id}")]  //agregar el id
        public ActionResult<Product_CategoryDto> GetById(int id)
        {
            return _Product_CategoryService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(Product_CategoryCreateDto Product_Category)
        {
            _Product_CategoryService.Create(Product_Category);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, Product_CategoryUpdateDto model)
        {
            _Product_CategoryService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            _Product_CategoryService.Remove(id);
            return NoContent();
        }
    }
}