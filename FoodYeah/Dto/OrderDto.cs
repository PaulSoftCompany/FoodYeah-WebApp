using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Dto
{
    public class OrderCreateDto
    {
        public List<OrderDetailCreateDto> orderDetails { get; set; }
        public uint costumerId { get; set; }
        public uint paymentId { get; set; }
    }

    public class OrderDetailCreateDto
    {
        public uint productId { get; set; }
        public byte quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }
    }

    public class OrderDto
    {
        public uint orderId { get; set; }
      
        public List<OrderDetailDto> orderDetails { get; set; }

        public uint costumerId { get; set; }
        public CostumerDto costumer { get; set; }
        
        public uint paymentId { get; set; }
    }

    public class OrderDetailDto
    {
        public uint orderDetailId { get; set; }

        public uint orderId { get; set; }
        public OrderDto order { get; set; }

        public uint productId { get; set; }
        public ProductDto product { get; set; }

        public string time { get; set; }
        public DateTime date { get; set; }
        public byte quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }
    }
}
