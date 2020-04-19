using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface OrderService
    {
        DataCollection<OrderDto> GetAll(int page, int take);
        OrderDto GetById(int id);
        OrderDto Create(OrderCreateDto model);
    }
}
