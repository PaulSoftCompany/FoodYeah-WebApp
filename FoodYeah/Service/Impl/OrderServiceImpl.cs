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

            PrepareDetail(entry.orderDetails);

             _context.Add(entry);
             _context.SaveChanges();

            return _mapper.Map<OrderDto>(
                 GetById(entry.orderId)
            );
        }

        public DataCollection<OrderDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<OrderDto>>(
                _context.orders.OrderByDescending(x => x.orderId)
                                   .Include(x => x.costumer)
                                   .Include(x => x.orderDetails)
                                       .ThenInclude(x => x.product)
                                   .AsQueryable()
                                   .Paged(page, take)
           );
        }

        public OrderDto GetById(uint id)
        {
            return _mapper.Map<OrderDto>(
                  _context.orders
                     .Include(x => x.costumer)
                     .Include(x => x.orderDetails)
                         .ThenInclude(x => x.product)
                     .Single(x => x.orderId == id)
             );
        }


        private void PrepareDetail(IEnumerable<OrderDetail> orderDetails)
        {
            foreach (var item in orderDetails)
            {
                item.totalPrice = item.unitPrice * item.quantity;
                item.time = DateTime.Now.ToString("h:mm:ss tt");
                item.date = DateTime.Now.Date;
            }
        }
    }
}
