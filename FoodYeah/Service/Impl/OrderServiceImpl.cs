using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;
using WebApiTodo.Persistence;

namespace WebApiTodo.Service.Impl
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

            // Prepare order detail
            PrepareDetail(entry.Items);

            // Prepare order header
            PrepareHeader(entry);

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
                                   .Include(x => x.Client)
                                   .Include(x => x.Items)
                                       .ThenInclude(x => x.Product)
                                   .AsQueryable()
                                   .Paged(page, take)
           );
        }

        public OrderDto GetById(int id)
        {
            return _mapper.Map<OrderDto>(
                  _context.Orders
                     .Include(x => x.Client)
                     .Include(x => x.Items)
                         .ThenInclude(x => x.Product)
                     .Single(x => x.OrderId == id)
             );
        }


        private void PrepareDetail(IEnumerable<OrderDetail> items)
        {
            foreach (var item in items)
            {
                item.Total = item.UnitPrice * item.Quantity;
                item.Iva = item.Total * IvaRate;
                item.SubTotal = item.Total - item.Iva;
            }
        }

        private void PrepareHeader(Order order)
        {
            order.SubTotal = order.Items.Sum(x => x.SubTotal);
            order.Iva = order.Items.Sum(x => x.Iva);
            order.Total = order.Items.Sum(x => x.Total);
        }
    }
}
