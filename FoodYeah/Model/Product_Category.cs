using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Product_Category
    {
        public uint costumer_CategoryId { get; set; }

        public uint productId { get; set; }
        public Product product { get; set; }
        [Required]
        public string costumer_categoryName { get; set; }
        [Required]
        public string costumer_categoryDescription { get; set; }
    }
}
