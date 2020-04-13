using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;


namespace WebApiTodo.Service
{
    public interface ClientService
    {
        DataCollection<ClientDto> GetAll(int page, int take);
       
        ClientDto GetById(int id);
        ClientDto Create(ClientCreateDto model);
        void Update(int id, ClientUpdateDto model);
        void Remove(int id);
    }
}
