using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;
using WebApiTodo.Persistence;

namespace WebApiTodo.Service
{
    public class ClientServiceImpl : ClientService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientServiceImpl(ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        
        

        public ClientDto Create(ClientCreateDto model)
        {
            var entry = new Client
            {
                Name = model.Name,
                ClientNumber=model.ClientNumber,
                Country_Id =model.Country_Id
            };

             _context.Add(entry);
             _context.SaveChanges();

            return _mapper.Map<ClientDto>(entry);
        }

        

        public void Remove(int id)
        {
            _context.Remove(new Client
            {
                ClientId = id
            });

             _context.SaveChanges();
        }


        public void Update(int id, ClientUpdateDto model)
        {
            var entry = _context.Clients.Single(x => x.ClientId == id);
            entry.Name = model.Name;

             _context.SaveChanges();
        }

        public DataCollection<ClientDto> GetAll(int page, int take)
        {
            return _mapper.Map<DataCollection<ClientDto>>(
                 _context.Clients
                              .Include(x => x.Country)
                              .OrderByDescending(x => x.ClientId)
                              .AsQueryable()
                              .Paged(page, take)
            );
        }
        

        public ClientDto GetById(int id)
        {
            return _mapper.Map<ClientDto>(
                 _context.Clients.Single(x => x.ClientId == id)
            );
        }
    }
}
