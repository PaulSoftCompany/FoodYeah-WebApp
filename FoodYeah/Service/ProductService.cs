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
        ProductDto GetById(uint id);
        ProductDto Create(ProductCreateDto model);
        void Update(uint id, ProductUpdateDto model);
        void Remove(uint id);
    }
}
    