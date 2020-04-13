using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Product
    {
        public uint productId { get; set; }

        public List<Product_Category> product_Categories { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
        [Required]
        public string productName { get; set; }
        public decimal productPrice { get; set; }
    }
}
