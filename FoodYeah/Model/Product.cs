using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Product
    {
        public uint ProductId { get; set; }

        public List<Product_Category> Product_Categories { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
