using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{ 
    public class Product_Category
    {
        public uint Product_CategoryId { get; set; }

        public uint ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string Product_CategoryName { get; set; }
        [Required]
        public string Product_CategoryDescription { get; set; }
    }
}
