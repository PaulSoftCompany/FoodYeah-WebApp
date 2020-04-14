using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Dto
{
    public class OrderCreateDto
    {
        public List<OrderDetailCreateDto> OrderDetails { get; set; }
        public uint CostumerId { get; set; }
        public uint PaymentId { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public uint ProductId { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public class OrderDto
    {
        public uint OrderId { get; set; }
      
        public List<OrderDetailDto> OrderDetails { get; set; }

        public uint CostumerId { get; set; }
        public CostumerDto Costumer { get; set; }
        
        public uint PaymentId { get; set; }
    }

    public class OrderDetailDto
    {
        public uint OrderDetailId { get; set; }

        public uint OrderId { get; set; }
        public OrderDto Order { get; set; }

        public uint ProductId { get; set; }
        public ProductDto Product { get; set; }

        public string Time { get; set; }
        public DateTime Date { get; set; }
        public byte Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
