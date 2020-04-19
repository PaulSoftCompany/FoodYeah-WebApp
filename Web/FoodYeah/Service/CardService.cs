using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;


namespace FoodYeah.Service
{
    public interface CardService
    {
        DataCollection<CardDto> GetAll(int page, int take);
       
        CardDto GetById(int id);
        CardDto Create(CardCreateDto model);
        void Update(int id, CardUpdateDto model);
        void Remove(int id);
    }
}