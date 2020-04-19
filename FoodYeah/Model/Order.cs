using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int CostumerId { get; set; }
        public Costumer Costumer { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
