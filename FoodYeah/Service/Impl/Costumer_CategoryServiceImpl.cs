using System.Linq;
using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;
using FoodYeah.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FoodYeah.Service
{
    class Costumer_CategoryServiceImpl : Costumer_CategoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private static int id;
        public Costumer_CategoryServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            id = 0;
            _context = context;
            _mapper = mapper;
        }
        public Costumer_CategoryDto Create(Costumer_CategoryCreateDto model)
        {
            var entry = new Costumer_Category
            {
                Costumer_CategoryName = model.Costumer_CategoryName,
                Costumer_CategoryDescription = model.Costumer_CategoryDescription,
                Costumer_CategoryId = id++
            };
            
            _context.Add(entry);
            _context.SaveChanges();

            return _mapper.Map<Costumer_CategoryDto>(entry);
        }

        public DataCollection<Costumer_CategoryDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<Costumer_CategoryDto>>(
                _context.Costumer_Categories
                        .Include(x => x.Costumers)
                            .ThenInclude(x => x.CostumerId)
                        .OrderByDescending(x => x.Costumer_CategoryId)
                        .AsQueryable()
                        .Paged(page, take)
            );
        }

        public Costumer_CategoryDto GetById(int id)
        {
            return _mapper.Map<Costumer_CategoryDto>(
                _context.Costumer_Categories.Single(x => x.Costumer_CategoryId == id)
           );
        }

        public void Remove(int id)
        {
            _context.Remove(new Costumer_Category
            {
                Costumer_CategoryId = id
            });

            _context.SaveChanges();
        }

        public void Update(int id, Costumer_CategoryUpdateDto model)
        {
            var entry = _context.Costumer_Categories.Single(x => x.Costumer_CategoryId == id);
            entry.Costumer_CategoryName = model.Costumer_CategoryName;
            entry.Costumer_CategoryDescription = model.Costumer_CategoryDescription;

            _context.SaveChanges();
        }
    }

}