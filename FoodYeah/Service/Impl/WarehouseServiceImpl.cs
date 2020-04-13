using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Dto;
using WebApiTodo.Model;
using WebApiTodo.Persistence;

namespace WebApiTodo.Service.Impl
{
    public class WarehouseServiceImpl : WarehouseService
    {

        private readonly ApplicationDbContext _context;
       

        public WarehouseServiceImpl(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<WarehouseProductDto> GetAllWithProducts()
        //public List<Warehouse> GetAllWithProducts()
        {
            //return _context.Warehouses
            //    .Include(x => x.Products)
            //      .ThenInclude(x => x.Product)

            //    .ToList();

            return (
               from w in _context.Warehouses
                   //from wp in _context.WarehouseProduct.Where(x => x.WarehouseId == w.WarehouseId && x.Product.Price >= 1000)
                from wp in _context.WarehouseProduct.Where(x => x.WarehouseId == w.WarehouseId)
               select new WarehouseProductDto
               {
                   WarehouseName = w.Name,
                   ProductName = wp.Product.Name,
                   ProductPrice = wp.Product.Price
               }
           ).ToList();
        }
    }
}
