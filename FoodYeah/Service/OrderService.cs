using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface OrderService
    {
        DataCollection<OrderDto> GetAll(int page, int take);
        DataCollection<OrderSimpleDto> GetAllSimple(int page, int take);
        OrderDto GetById(int id);
        OrderSimpleDto GetByIdSimple(int id);
        OrderDto Create(OrderCreateDto model);
        void SetEndTime(int id);
        string GetAverageTime();
        void DecreaseStock(int id);
    }
}
