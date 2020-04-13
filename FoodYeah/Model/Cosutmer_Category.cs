using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodYeah.Model
{
    public class Costumer_Category
    {
        public uint costumer_categoryId { get; set; }

        public uint costumerId { get; set; }
        public Costumer costumer { get; set; }
        [Required]
        public string costumer_categoryName { get; set; }
        
    }
}
