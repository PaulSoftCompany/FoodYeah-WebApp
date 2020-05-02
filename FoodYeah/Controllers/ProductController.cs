﻿using Microsoft.AspNetCore.Mvc;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Service;

namespace FoodYeah.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService ProductService)
        {
            _productService = ProductService;
        }

        //http://localhost:52451/products?page=1&take=1
        [HttpGet]
        public ActionResult<DataCollection<ProductDto>> GetAll(int page=1, int take = 20) => _productService.GetAll(page, take);

        [HttpGet("week")]
        public ActionResult<DataCollection<ProductDto>> GetByWeek(int page=1, int take = 20)
        {
            return _productService.GetByWeek(page, take);
        }

        [HttpGet("day/{day}")]
        public ActionResult<DataCollection<ProductDto>> GetByDay(Enums.DaySold day, int page=1, int take = 20)
        {
            return _productService.GetByDay(day, page, take);
        }

        // Ex: Products/1
        [HttpGet("{id}")]
        public ActionResult<ProductDto> GetById(int id)
        {
            return  _productService.GetById(id);
        }

        [HttpPost]
        public ActionResult Create(ProductCreateDto model)
        {
            var result = _productService.Create(model);

            return CreatedAtAction(
                "GetById",
                new { id = result.ProductId },
                result
            );
        }

        [HttpPut("{id}")]
        public  ActionResult Update(int id, ProductUpdateDto model)
        {
            _productService.Update(id, model);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public  ActionResult Remove(int id)
        {
            _productService.Remove(id);
            return NoContent();
        }

    }
}
