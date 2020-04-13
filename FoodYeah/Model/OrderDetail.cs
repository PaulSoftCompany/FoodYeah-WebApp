using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class OrderDetail
    {
        public uint orderDetailId { get; set; }

        public uint orderId { get; set; }
        public Order order { get; set; }

        public uint productId { get; set; }
        public Product product { get; set; }

        public uint time { get; set; }
        public DateTime date { get; set; }
        public byte quantity { get; set; }
        public decimal price { get; set; }
        public decimal totalPrice { get; set; }
    }
}
