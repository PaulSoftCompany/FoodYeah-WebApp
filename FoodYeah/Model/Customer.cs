using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodYeah.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public int Customer_CategoryId { get; set; }
        public Customer_Category Customer_Category { get; set; }
        public List<Card> Cards { get; set; } 
        public List<Order> Orders {get; set;}
        public string StripeIdentificador { get; set; }

        [Required]
        public string CustomerName { get; set; }
        public byte CustomerAge { get; set; }
    }
}
