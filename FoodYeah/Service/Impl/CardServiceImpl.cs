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
    public class CardServiceImpl : CardService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public CardServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }

        public CardDto Create(CardCreateDto model)
        {
            Costumer costumer = _context.Costumers.Single(x => x.CostumerId == model.CostumerId);
            var entry = new Card
            {
                CardId = id++,
                CardNumber = model.CardNumber,
                CostumerId = model.CostumerId,
                CardType = model.CardType,
                CardCvi = model.CardCvi,
                CardOwnerName = costumer.CostumerName,
                CardExpireDate = model.CardExpireDate
            };
            
            _context.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<CardDto>(entry);
        }

        public void Remove(int id)
        {
            _context.Remove(new Card
            {
                CardId = id
            });
            _context.SaveChanges();
        }

        public void Update(int id, CardUpdateDto model)
        {
            var entry = _context.Cards.Single(x => x.CardId == id);
            entry.CardOwnerName = model.CardOwnerName;

            _context.SaveChanges();
        }

        public DataCollection<CardDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<CardDto>>(
                 _context.Cards
                              .Include(x => x.Costumer)
                              .OrderByDescending(x => x.CostumerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public CardDto GetById(int id)
        {
            return _mapper.Map<CardDto>(
                 _context.Cards.Single(x => x.CardId == id)
            );
        }
    }
}
