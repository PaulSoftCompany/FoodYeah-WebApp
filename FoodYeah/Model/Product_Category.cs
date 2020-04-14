using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{ 
    //Dejamelo comentado, porque eso se hace relación
    //Estoy en CostumerCofig porsiaca
    public class Product_Category
    {
        public uint Costumer_CategoryId { get; set; }

        public uint ProductId { get; set; }
        public Product Product { get; set; }
        [Required]
        public string Costumer_categoryName { get; set; }
        [Required]
        public string Costumer_categoryDescription { get; set; }
    }
}
