using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Dto
{
    public class ProductCreateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }

    public class ProductUpdateDto
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }

    public class ProductDto
    {
        public uint ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
