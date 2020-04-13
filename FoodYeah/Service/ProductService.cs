using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTodo.Commons;
using WebApiTodo.Dto;
using WebApiTodo.Model;


namespace WebApiTodo.Service
{
    public interface ProductService
    {
        DataCollection<ProductDto> GetAll(int page, int take);
        ProductDto GetById(int id);
        ProductDto Create(ProductCreateDto model);
        void Update(int id, ProductUpdateDto model);
        void Remove(int id);
    }
}
    