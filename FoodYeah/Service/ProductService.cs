﻿using FoodYeah.Commons;
using FoodYeah.Dto;
using System.Collections.Generic;

namespace FoodYeah.Service
{
    public interface ProductService
    {
        DataCollection<ProductDto> GetAll(int page, int take);

        //List<ProductDto> GetAll2();
        DataCollection<ProductSimpleDto> GetAllSimple(int page, int take);
        ProductDto GetById(int id);
        DataCollection<ProductDto> GetByDay(Enums.DaySold day, int page, int take);
        DataCollection<ProductDto> GetByWeek(int page, int take);
        DataCollection<ProductDto> GetByType(int type, int page, int take);
        ProductDto Create(ProductCreateDto model);
        void AddStock(int id, ProductUpdateStockDto model);
        void Update(int id, ProductUpdateDto model);
        void Remove(int id);
    }
}
    