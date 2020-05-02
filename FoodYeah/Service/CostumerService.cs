using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface CostumerService
    {
        DataCollection<CostumerDto> GetAll(int page, int take);
        CostumerDto GetById(int id);
        CostumerDto Create(CostumerCreateDto model);
        void Update(int id, CostumerUpdateDto model);
        void Remove(int id);
    }
}
