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
            CreateMap<Customer, CustomerDto>();
            CreateMap<DataCollection<Customer>, DataCollection<CustomerDto>>();

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

            CreateMap<Customer_Category, Customer_CategoryDto>();
            CreateMap<DataCollection<Customer_Category>, DataCollection<Customer_CategoryDto>>();
        }
    }
}
