using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Commons;
using FoodYeah.Model;

namespace FoodYeah.Dto
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Product_CategoryId { get; set; }
        public Enums.DaySold SellDay { get; set; }
    }

    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.DaySold SellDay { get; set; }

    }

    public class ProductDto
    {

        public int ProductId { get; set; }
        public Product_CategoryDto Product_Category { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public Enums.DaySold SellDay { get; set; }
    }
}
