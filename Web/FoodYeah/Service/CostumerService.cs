using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;


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
