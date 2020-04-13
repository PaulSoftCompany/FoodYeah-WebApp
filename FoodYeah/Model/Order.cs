using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Order
    {
        public uint orderId { get; set; }
      
        public List<OrderDetail> orderDetails { get; set; }

        public uint costumerId { get; set; }
        public Costumer costumer { get; set; }
        
        public uint paymentId { get; set; }
        public Payment payment { get; set; }
    }
}
