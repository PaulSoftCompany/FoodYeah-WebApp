using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class ProductCreateDto
    {
        public string productName { get; set; }
        public decimal productPrice { get; set; }
    }

    public class ProductUpdateDto
    {
        public string productName { get; set; }
        public decimal productPrice { get; set; }
    }

    public class ProductDto
    {
        public uint productId { get; set; }
        public string productName { get; set; }
        public decimal productPrice { get; set; }
    }
}
