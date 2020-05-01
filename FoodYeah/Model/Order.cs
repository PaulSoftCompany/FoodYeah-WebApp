using System.Collections.Generic;

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
