using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;


namespace FoodYeah.Service
{
    public interface ProductService
    {
        DataCollection<ProductDto> GetAll(int page, int take);
        ProductDto GetById(int id);
        DataCollection<ProductDto> GetByWeek(int page, int take);
        DataCollection<ProductDto> GetByDay(Enums.DaySold day);
        ProductDto Create(ProductCreateDto model);
        void Update(int id, ProductUpdateDto model);
        void Remove(int id);
    }
}
    