using AutoMapper;
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
    public class ProductServiceImpl : ProductService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProductDto Create(ProductCreateDto model)
        {
            var entry = new Product
            {
                productName = model.productName,
                productPrice = model.productPrice
            };

             _context.Add(entry);
             _context.SaveChanges();

            return _mapper.Map<ProductDto>(entry);
        }

        public DataCollection<ProductDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                  _context.products.OrderByDescending(x => x.productId)
                               .AsQueryable()
                               .Paged(page, take)
             );
        }

        public ProductDto GetById(uint id)
        {
            return _mapper.Map<ProductDto>(
                _context.products.Single(x => x.productId == id)
           );
        }

        public void Remove(uint id)
        {
            _context.Remove(new Product
            {
                productId = id
            });

            _context.SaveChanges();
        }

        public void Update(uint id, ProductUpdateDto model)
        {
            var entry = _context.products.Single(x => x.productId == id);

            entry.productName = model.productName;
            entry.productPrice = model.productPrice;

            _context.SaveChanges();
        }
    }
}
