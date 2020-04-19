using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FoodYeah.Model;

namespace FoodYeah.Dto
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int Product_CategoryId { get; set; }
    }

    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }

    public class ProductDto
    {
        private Product_CategoryDto product_Category;

        public int ProductId { get; set; }
        public int Product_CategoryId { get; set; }
        public Product_CategoryDto Product_Category { get => product_Category; set => product_Category = value; }

        public List<OrderDetailDto> OrderDetails { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
