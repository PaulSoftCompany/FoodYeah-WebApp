using System.Collections.Generic;

namespace FoodYeah.Model
{
    public class Order
    {
        public int OrderId { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public decimal TotalPrice { get; set; }
        public string Status { get; set; }
    }
}
