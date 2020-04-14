using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Order
    {
        public uint OrderId { get; set; }
      
        public List<OrderDetail> OrderDetails { get; set; }

        public uint CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        
        public uint PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}
