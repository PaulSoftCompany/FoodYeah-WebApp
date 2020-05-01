using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface Costumer_CategoryService
    {
        DataCollection<Costumer_CategoryDto> GetAll(int page, int take);
       
        Costumer_CategoryDto GetById(int id);
        Costumer_CategoryDto Create(Costumer_CategoryCreateDto model);
        void Update(int id, Costumer_CategoryUpdateDto model);
        void Remove(int id);
    }
}