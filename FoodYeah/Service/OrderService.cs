using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;

namespace FoodYeah.Service
{
    public interface OrderService
    {
        DataCollection<OrderDto> GetAll(int page, int take);
        OrderDto GetById(int id);
        public OrderDto UpdateStatus(int id, string status);
        OrderDto Create(OrderCreateDto model);
    }
}
