using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;

namespace FoodYeah.Service
{
    public class CostumerServiceImpl : CostumerService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;

        public CostumerServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }


        public CostumerDto Create(CostumerCreateDto model)
        {
            var entry = new Costumer
            {
                CostumerName = model.CostumerName,
                CostumerAge = model.CostumerAge,
                Costumer_CategoryId = model.Costumer_CategoryId,
                CostumerId = id
            };
            id++;
            _context.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<CostumerDto>(entry);
        }


        public void Remove(int id)
        {
            _context.Remove(new Costumer
            {
                CostumerId = id
            });

            _context.SaveChanges();
        }


        public void Update(int id, CostumerUpdateDto model)
        {
            var entry = _context.Costumers.Single(x => x.CostumerId == id);
            entry.CostumerName = model.CostumerName;

            _context.SaveChanges();
        }

        public DataCollection<CostumerDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CostumerDto>>(
                 _context.Costumers
                              .Include(x => x.Orders)
                              .Include(x => x.Cards)
                              .Include(x => x.Costumer_Category)
                              .OrderByDescending(x => x.CostumerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public CostumerDto GetById(int id)
        {
            return _mapper.Map<CostumerDto>(
                 _context.Costumers.Single(x => x.CostumerId == id)
            );
        }
    }
}
