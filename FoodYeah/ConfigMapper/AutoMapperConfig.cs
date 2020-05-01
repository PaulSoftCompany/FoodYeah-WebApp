using AutoMapper;
using FoodYeah.Commons;
using FoodYeah.Dto;
using FoodYeah.Model;

namespace FoodYeah.ConfigMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Costumer, CostumerDto>();
            CreateMap<DataCollection<Costumer>, DataCollection<CostumerDto>>();

            CreateMap<Product, ProductDto>();
            CreateMap<DataCollection<Product>, DataCollection<ProductDto>>();

            CreateMap<Order, OrderDto>();
            CreateMap<OrderDetail, OrderDetailDto>();
            CreateMap<DataCollection<Order>, DataCollection<OrderDto>>();

            // Order creation
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();

            CreateMap<Card, CardDto>();
            CreateMap<DataCollection<Card>, DataCollection<CardDto>>();

            CreateMap<Product_Category, Product_CategoryDto>();
            CreateMap<DataCollection<Product_Category>, DataCollection<Product_CategoryDto>>();

            CreateMap<Costumer_Category, Costumer_CategoryDto>();
            CreateMap<DataCollection<Costumer_Category>, DataCollection<Costumer_CategoryDto>>();
        }
    }
}
