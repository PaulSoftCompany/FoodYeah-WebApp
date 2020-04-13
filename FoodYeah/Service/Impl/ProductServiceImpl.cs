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
                Name = model.Name,
                Description = model.Description,
                Price = model.Price
            };

             _context.Add(entry);
             _context.SaveChanges();

            return _mapper.Map<ProductDto>(entry);
        }

        public DataCollection<ProductDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ProductDto>>(
                  _context.Products.OrderByDescending(x => x.ProductId)
                               .AsQueryable()
                               .Paged(page, take)
             );
        }

        public ProductDto GetById(int id)
        {
            return _mapper.Map<ProductDto>(
                _context.Products.Single(x => x.ProductId == id)
           );
        }

        public void Remove(int id)
        {
            _context.Remove(new Product
            {
                ProductId = id
            });

            _context.SaveChanges();
        }

        public void Update(int id, ProductUpdateDto model)
        {
            var entry = _context.Products.Single(x => x.ProductId == id);

            entry.Name = model.Name;
            entry.Description = model.Description;
            entry.Price = model.Price;

            _context.SaveChanges();
        }
    }
}
