﻿using FoodYeah.Commons;
using FoodYeah.Dto;

namespace FoodYeah.Service
{
    public interface ProductService
    {
        DataCollection<ProductDto> GetAll(int page, int take);
        ProductDto GetById(int id);
        DataCollection<ProductDto> GetByWeek(int page, int take);
        DataCollection<ProductDto> GetByDay(Enums.DaySold day, int page, int take);
        ProductDto Create(ProductCreateDto model);
        DataCollection<ProductDto> GetByType(int type, int page, int take);
        void Update(int id, ProductUpdateDto model);
        void Remove(int id);
    }
}
    