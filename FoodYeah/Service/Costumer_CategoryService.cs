using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;


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