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
        private static int id;

        public OrderServiceImpl(
            ApplicationDbContext context,
            IMapper mapper
        )
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }

        public OrderDto Create(OrderCreateDto model)
        {
            var entry = _mapper.Map<Order>(model);

            PrepareDetail(entry.OrderDetails);

            PrepareHeader(entry);

            _context.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<OrderDto>(GetById(entry.OrderId)
            );
        }

        public DataCollection<OrderDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                _context.Orders.OrderByDescending(x => x.OrderId)
                                   .Include(x => x.Costumer)
                                   .Include(x => x.OrderDetails)
                                    .ThenInclude(x => x.Order)
                                   .Include(x => x.OrderDetails)
                                    .ThenInclude(x => x.Product)
                                   .AsQueryable()
                                   .Paged(page, take)
           );
        }

        public OrderDto GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                  _context.Orders
                     .Include(x => x.Costumer)

                                   .Include(x => x.OrderDetails)
                                    .ThenInclude(x => x.Order)
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
            }
        }

        private void PrepareHeader(Order order)
        {
            order.OrderId = id++;
            order.Date = DateTime.Now.ToString("yyyy-MM-dd");
            order.Time = DateTime.Now.ToString("h:mm tt");
            //order.Time = (new Random().Next(1, 8)).ToString() + ":" + (new Random().Next(1, 59)).ToString();
            order.TotalPrice = order.OrderDetails.Sum(x => x.TotalPrice);
        }
    }
}
