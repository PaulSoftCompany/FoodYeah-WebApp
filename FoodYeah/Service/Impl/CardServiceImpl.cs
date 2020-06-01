using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Stripe;
using Microsoft.CodeAnalysis.Options;

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
            StripeConfiguration.ApiKey = "sk_test_Q0IOeF2i1XAEQsnoeLNcdC4o007MXqlyvo";
            id = 0;
            _context = context;
            _mapper = mapper;
        }

        public CardDto Create(CardCreateDto model)
        {



            Model.Customer Customer = _context.Customers.Single(x => x.CustomerId == model.CustomerId);
            var entry = new Model.Card
            {
                CardId = id++,
                CardNumber = model.CardNumber,
                CustomerId = model.CustomerId,
                Customer = Customer,
                CardType = model.CardType,
                CardCvi = model.CardCvi,
                CardOwnerName = Customer.CustomerName,
                CardExpireYear = model.CardExpireYear,
                CardExpireMonth = model.CardExpireMonth
            };
            //STRIPE
            var paymentMethod = new PaymentMethodCreateOptions
            {
                Type = "card",
                Card = new PaymentMethodCardCreateOptions
                {
                    Number = entry.CardNumber,
                    ExpMonth = entry.CardExpireMonth,
                    ExpYear = entry.CardExpireYear,
                    Cvc = entry.CardCvi.ToString(),
                },

            };
            var service = new PaymentMethodService();

            var customerStripe = new PaymentMethodAttachOptions
            {
                Customer = Customer.StripeIdentificador,
            };

            service.Create(paymentMethod);

            var IdMethod = service.Create(paymentMethod).Id;
            service.Attach(IdMethod, customerStripe);

            _context.Cards.Add(entry);
            _context.SaveChanges(); 

          
            

            return _mapper.Map<CardDto>(entry);
        }

        public void Remove(int id)
        {
            _context.Remove(new Model.Card
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
                              .Include(x => x.Customer)
                              .OrderByDescending(x => x.CustomerId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }

        public DataCollection<CardSimpleDto> GetAllSimple(int page, int take)
        {
            return _mapper.Map<DataCollection<CardSimpleDto>>(
                 _context.Cards
                              .OrderByDescending(x => x.CustomerId)
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
