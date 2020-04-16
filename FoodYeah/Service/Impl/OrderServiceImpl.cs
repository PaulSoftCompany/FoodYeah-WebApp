using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;

namespace FoodYeah.Service.Impl
{
    public class OrderServiceImpl : OrderService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private const decimal IvaRate = 0.18m;

        public OrderServiceImpl(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            _context = context;
            _mapper = mapper;
        }


        public OrderDto Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);

            PrepareDetail(entry.OrderDetails);

             _context.Add(entry);
             _context.SaveChanges();

            return _mapper.Map<OrderDto>(
                 GetById(entry.OrderId)
            );
        }

        public DataCollection<OrderDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                _context.Orders.OrderByDescending(x => x.OrderId)
                                   .Include(x => x.Costumer)
                                   .Include(x => x.OrderDetails)
                                       .ThenInclude(x => x.Product)
                                   .AsQueryable()
                                   .Paged(page, take)
           );
        }

        public OrderDto GetById(uint id)
        {
            return _mapper.Map<OrderDto>(
                  _context.Orders
                     .Include(x => x.Costumer)
                     .Include(x => x.OrderDetails)
                         .ThenInclude(x => x.Product)
                     .Single(x => x.OrderId == id)
             );
        }


        private void PrepareDetail(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var item in orderDetails)
            {
                item.TotalPrice = item.UnitPrice * item.Quantity;
                item.Time = DateTime.Now.ToString("h:mm:ss tt");
                item.Date = DateTime.Now.Date;
            }
        }
    }
}
