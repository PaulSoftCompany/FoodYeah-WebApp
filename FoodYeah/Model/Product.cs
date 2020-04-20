using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public enum SellDay
    {
        Lunes=1,
        Martes=2,
        Miercoles=3,
        Jueves=4,
        Viernes=5
    }
    public class Product
    {
        public int ProductId { get; set; }

        public int Product_CategoryId { get; set; }
        public Product_Category Product_Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
        [Required]
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public SellDay SellDay { get; set; }
    }
}
