using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;

namespace WebApiTodo.Service
{
    public interface OrderService
    {
        DataCollection<OrderDto> GetAll(int page, int take);
        OrderDto GetById(int id);
        OrderDto Create(OrderCreateDto model);
    }
}
