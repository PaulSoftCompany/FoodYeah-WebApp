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

            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderDetailCreateDto, OrderDetail>();

            CreateMap<Card, CardDto>();
            CreateMap<DataCollection<Card>, DataCollection<CardDto>>();

            CreateMap<Product_Category, Product_CategoryDto>();
            CreateMap<DataCollection<Product_Category>, DataCollection<Product_CategoryDto>>();

            CreateMap<Customer_Category, Customer_CategoryDto>();
            CreateMap<DataCollection<Customer_Category>, DataCollection<Customer_CategoryDto>>();

            //Simple Dtos
            CreateMap<Customer, CustomerSimpleDto>();
            CreateMap<DataCollection<Customer>, DataCollection<CustomerSimpleDto>>();

            CreateMap<Product, ProductSimpleDto>();
            CreateMap<DataCollection<Product>, DataCollection<ProductSimpleDto>>();

            CreateMap<Order, OrderSimpleDto>();
            CreateMap<DataCollection<Order>, DataCollection<OrderSimpleDto>>();

            CreateMap<Card, CardSimpleDto>();
            CreateMap<DataCollection<Card>, DataCollection<CardSimpleDto>>();

            CreateMap<Product_Category, Product_CategorySimpleDto>();
            CreateMap<DataCollection<Product_Category>, DataCollection<Product_CategorySimpleDto>>();

            CreateMap<Customer_Category, Customer_CategorySimpleDto>();
            CreateMap<DataCollection<Customer_Category>, DataCollection<Customer_CategorySimpleDto>>();

            
        }
    }
}
