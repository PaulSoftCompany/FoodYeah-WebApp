using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Dto;
using WebApiTodo.Model;

namespace WebApiTodo.Service
{
    public interface WarehouseService
    {
        List<WarehouseProductDto> GetAllWithProducts();
        //List<Warehouse> GetAllWithProducts();
    }
}
